using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Reflection;

namespace DahlDesign.Plugin
{
    public class UpdateManager
    {
        public bool UpdateAvailable { get; private set; } = false;
        public string LatestVersion { get; private set; } = "";
        public string DownloadUrl { get; private set; } = "";

        private static readonly HttpClient client = new HttpClient();

        public UpdateManager()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            client.DefaultRequestHeaders.Add("User-Agent", "DahlDesignProperties-Updater");
        }

        public async Task CheckForUpdatesAsync(string currentVersion)
        {
            try
            {
                var response = await client.GetStringAsync("https://api.github.com/repos/andreasdahl1987/DahlDesignProperties/releases/latest");

                // Very basic regex parsing to avoid bringing in JSON dependencies, since this needs to be minimal
                var tagMatch = Regex.Match(response, "\"tag_name\":\\s*\"(.*?)\"");
                var assetMatch = Regex.Match(response, "\"browser_download_url\":\\s*\"(.*?)\"");

                if (tagMatch.Success && assetMatch.Success)
                {
                    string latestTag = tagMatch.Groups[1].Value;
                    string assetUrl = assetMatch.Groups[1].Value;

                    // Remove any 'v' prefix if present
                    string cleanLatest = latestTag.TrimStart('v', 'V');
                    string cleanCurrent = currentVersion.TrimStart('v', 'V');

                    Version vLatest, vCurrent;
                    if (Version.TryParse(cleanLatest, out vLatest) && Version.TryParse(cleanCurrent, out vCurrent))
                    {
                        if (vLatest > vCurrent)
                        {
                            UpdateAvailable = true;
                            LatestVersion = cleanLatest;
                            DownloadUrl = assetUrl;
                            SimHub.Logging.Current.Info($"[DahlDesign] Update available: {LatestVersion}");
                        }
                    }
                    else if (cleanLatest != cleanCurrent) // Fallback to simple string comparison
                    {
                        UpdateAvailable = true;
                        LatestVersion = cleanLatest;
                        DownloadUrl = assetUrl;
                        SimHub.Logging.Current.Info($"[DahlDesign] Update available (string cmp): {LatestVersion}");
                    }
                }
            }
            catch (Exception ex)
            {
                SimHub.Logging.Current.Error($"[DahlDesign] Update check failed: {ex.Message}");
            }
        }

        public async Task UpdateAndRestartAsync()
        {
            if (!UpdateAvailable || string.IsNullOrEmpty(DownloadUrl))
                return;

            try
            {
                string tempDir = Path.Combine(Path.GetTempPath(), "DahlDesignUpdate");
                if (!Directory.Exists(tempDir))
                {
                    Directory.CreateDirectory(tempDir);
                }

                string tempDllPath = Path.Combine(tempDir, "DahlDesign.dll");

                // Download the new DLL
                byte[] fileBytes = await client.GetByteArrayAsync(DownloadUrl);
                File.WriteAllBytes(tempDllPath, fileBytes);

                // We need to copy the file to the SimHub root where it is located.
                // Assuming this DLL is executing from the SimHub folder
                string currentAssemblyPath = Assembly.GetExecutingAssembly().Location;
                string simHubFolder = Path.GetDirectoryName(currentAssemblyPath);
                string simHubExecutable = Path.Combine(simHubFolder, "SimHubWPF.exe");

                string targetDllPath = Path.Combine(simHubFolder, "DahlDesign.dll");

                string batFilePath = Path.Combine(tempDir, "update_simhub.bat");

                string batContent = $@"
@echo off
timeout /t 2 /nobreak > nul
taskkill /F /IM SimHubWPF.exe > nul 2>&1
timeout /t 2 /nobreak > nul
copy /Y ""{tempDllPath}"" ""{targetDllPath}""
start """" ""{simHubExecutable}""
del ""%~f0""
";
                File.WriteAllText(batFilePath, batContent);

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = batFilePath,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Verb = "runas" // Request administrator privileges if necessary for Program Files copying
                };
                Process.Start(psi);

                // The batch script will kill SimHub shortly, but we can also just let it happen.
            }
            catch (Exception ex)
            {
                SimHub.Logging.Current.Error($"[DahlDesign] Update execution failed: {ex.Message}");
            }
        }
    }
}
