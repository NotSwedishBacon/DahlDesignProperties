using System.Windows.Controls;

namespace DahlDesign.Plugin
{
    /// <summary>
    /// Logique d'interaction pour SettingsControlDemo.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public DahlDesign Plugin { get; }

        public SettingsControl()
        {
            InitializeComponent();
        }

        public SettingsControl(DahlDesign plugin) : this()
        {
            this.Plugin = plugin;
            this.Loaded += ControlsEditor_Loaded;
        }

        private void ControlsEditor_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Plugin != null && Plugin.Updater != null && Plugin.Updater.UpdateAvailable)
            {
                UpdatePanel.Visibility = System.Windows.Visibility.Visible;
                UpdateText.Text = $"An update is available! Latest version: {Plugin.Updater.LatestVersion}";
            }
        }

        private async void UpdateButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateButton.IsEnabled = false;
            UpdateButton.Content = "Updating...";
            if (Plugin != null && Plugin.Updater != null)
            {
                await Plugin.Updater.UpdateAndRestartAsync();
            }
        }
    }
}
