<a name="readme-top"></a>

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]

<br />
<div align="center">
    <img src="images/blackLogo.png" alt="blackLogo" height=150 >

  <h2 align="center">DAHL DESIGN <br /> PROPERTIES</h2>

  <h3 align="center">SimHub plugin for iRacing.</h3>
  <h4 align="center"> 1/4 of the quadfecta
    <br />
    <a href="https://github.com/NotSwedishBacon/DahlDesignProperties">Properties</a>
    ·
    <a href="https://github.com/andreasdahl1987/DahlDesignLED">LED</a>
    ·
    <a href="https://github.com/andreasdahl1987/DahlDesignDash">Dashboard</a>
    ·
    <a href="https://github.com/andreasdahl1987/DahlDesignDDC">DDC</a>
  </h4>
</div>

<h5 align="center">Welcome to the repository! To get the most out of this plugin, check out the properties documented below or the manual.</h5>
<h2 align="center"><a href="https://dahl-design.gitbook.io/properties/">MANUAL</a></h2>

---

## Available Properties

- [🚘 Car](#-car)
- [⚙️ Gear and RPM](#️-gear-and-rpm)
- [🏎️ Driving](#️-driving)
- [🔄 Stint](#-stint)
- [🏁 Race](#-race)
- [✖️ Opponents](#️-opponents)
- [⏱️ Lap Timing](#️-lap-timing)
- [📊 Lap Sectors](#-lap-sectors)
- [🚀 Launch](#-launch)
- [⛽ Fuel and Strategy](#-fuel-and-strategy)
- [🔧 Pit Service](#-pit-service)
- [⤴️ Pit Exit](#️-pit-exit)
- [🔨 Utility](#-utility)
- [🖥️ Dashboard Settings](#️-dashboard-settings)
- [🎛️ Dashboard Control](#️-dashboard-control)
- [🚥 LED Control](#-led-control)
- [🎮 DDC](#-ddc)
- [🕹️ SW1](#️-sw1)

---

### 🚘 Car

Car specific properties.

| Name | Description | Type |
| --- | --- | --- |
| TCActive | Simulated TC-activation | boolean |
| TCToggle | TC turned on/off with toggle control (supported by some cars) OR by setting TC to a mode where it is off. | boolean |
| SlipLF / SlipRF / SlipLR / SlipRR | Wheel is slipping. Only right/left sensitive, front and rear values are identical. | 0 - 100 |
| ABSToggle | ABS turned on/off with toggle control (supported by some cars) OR by setting ABS to a mode where it is off. | boolean |
| MapHigh | Value of the engine mode that gives the most power | integer |
| MapLow | Value of the engine mode that gives the least power | integer |
| HasTC | Whether the car is equipped with traction control or not | boolean |
| HasABS | Whether the car is equipped with ABS or not | boolean |
| HasDRS | Whether the car has a DRS system or not | boolean |
| HasAntiStall | Whether the car has anti-stall or not | boolean |
| HasOvertake | Whether the car has an overtake system or not | boolean |
| CurrentFrontWing | Current setting for front wing angle, updates on pit stop | various |
| CurrentRearWing | Current setting for rear wing angle, updates on pit stop | various |
| CurrentTape | Current setting for tape, updates on pit stop | integer |
| CurrentPowersteer | Current setting for power steering, updates on pit stop | integer |
| ERSTarget | Tracks/computes actual current ERS setting for McLaren MP4-30 | 25 / 50 / 75 |
| ERSCharges | Tracks/computes available charges for changing ERS setting in Mercedes W12 | 0 - 4 |
| P2PStatus | Whether P2P is active or not | boolean |
| P2PCount | How many P2P uses left in the race | 0 - 10 |
| OvertakeMode | True if eligible to engage an overtake enhancement (DRS/P2P) | boolean |
| DRSState | DRS status: None, Acquired, Ready, Open | string |
| DRSCount | Remaining DRS uses (relevant for FR3.5) | integer |
| CenterDashType | Sets center dash type for this car in DahlDesign dashboard | string |
| MenuType | Sets 12-position menu type for this car in DahlDesign dashboard | string |
| AnimationType | LED profile for DahlDesign DDU/SW1 for this car | string |
| SF23.OTActive | Super Formula SF23 specific: Overtake is active | boolean |
| SF23.OTAllowed | Allowed to use overtake at current track location/session | boolean |
| SF23.OTCooldownActive | Overtake cooldown is running | boolean |
| SF23.OTCooldownTimer | Counts down to 0 from 100 when overtake is deactivated | 0 - 100 |
| SF23.OTTimeLeft | Active overtake time left in session | 0 - 200 |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

### ⚙️ Gear and RPM

Properties for gear, shifting, and RPM.

| Name | Description | Type |
| --- | --- | --- |
| SmoothGear | Gear representation with transition "N" smoothed out | string |
| LastGear | Previous gear | string |
| LastGearMaxRPM | Highest RPM reached on previous gear | rpm |
| IdleRPM | RPM with engine on and clutch pressed | rpm |
| OptimalShiftGear(X) | Optimal shift point (RPM) going from gear (X) to next | rpm |
| OptimalShiftCurrentGear | Optimal shift point (RPM) going from current gear to next | rpm |
| OptimalShiftLastGear | Optimal shift point (RPM) going from previous gear to current gear | rpm |
| ShiftLightRPM | Calculated RPM at which shift alert should trigger, considering reaction time | rpm |
| ReactionTime | Measured reaction time from shift alert to shift completion | ms |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

### 🏎️ Driving

Properties describing driving telemetry and vehicle usage.

| Name | Description | Type |
| --- | --- | --- |
| Idle | Whether you are in the cockpit with car control | boolean |
| AccelerationTo100KPH | Time from standstill to 100 KPH | seconds |
| AccelerationTo200KPH | Time from standstill to 200 KPH | seconds |
| BrakeCurveValues | String representing 4-second recording of previous brake pedal input | string |
| BrakeCurvePeak | Highest input during previous brake application | integer |
| BrakeCurveAUC | Area under brake curve over 4 seconds, reflecting total brake work | decimal |
| ThrottleCurveValues | String representing 3-second recording of previous throttle input | string |
| ThrottleAgro | Time from initial throttle application to full throttle | decimal |
| MinimumCornerSpeed | Slower speed between last throttle release and throttle re-application | integer |
| StraightLineSpeed | Highest speed reached before previous brake application | integer |
| TrackEntry | Evaluates if driver is re-entering or entering the track | boolean |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

### 🔄 Stint

Properties tracking current stint metrics (resets on pit stop).

| Name | Description | Type |
| --- | --- | --- |
| StintTimer | Time spent in current stint | timespan |
| StintTotalTime | Expected stint duration based on fuel capacity or session end | timespan |
| StintCurrentHotlap | Count of completed flying laps this stint | integer |
| StintTotalHotlaps | Expected count of flying laps this stint | integer |
| StintValidLaps | Count of completed valid flying laps this stint | integer |
| StintInvalidLaps | Count of completed invalid flying laps this stint | integer |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

### 🏁 Race

Properties relevant to live race tracking, spotter calls, and session status.

| Name | Description | Type |
| --- | --- | --- |
| LapsRemaining | Calculated remaining laps based on time left, pace, leader position, and pit stops | integer |
| LapBalance | Track position when session finishes; proximity to a +/-1 lap difference | decimal |
| RaceFinished | You finished the race | boolean |
| JokerThisLap | Whether current lap is a joker lap | boolean |
| JokerCount | Number of joker laps completed this stint | integer |
| Position | Live updated race position | integer |
| HotLapPosition | Position on "fastest lap" leaderboard | integer |
| HotLapLivePosition | Predicted position on "fastest lap" leaderboard for current lap | integer |
| LeftCarGap | Distance to car on left side (forward/backward) | decimal |
| LeftCarName | Driver name of left side car | string |
| RightCarGap | Distance to car on right side (forward/backward) | decimal |
| RightCarName | Driver name of right side car | string |
| RadioName | Name of driver currently using radio | string |
| RadioPosition | Position of driver using radio | integer |
| RadioIsSpectator | True if person on radio is not a driver in the race | boolean |
| MyClassColor | Your class color in hexadecimal format | hexadecimal |
| SoF | Strength of field | iRating |
| IRChange | Estimated change in iRating based on current race position | iRating |
| TrackType | 0 = road, 1-3 = rallycross, 4 = dirt road w/o joker, 5-7 = ovals, 8 = dirt oval | 0 - 8 |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

### ✖️ Opponents

Properties tracking relative, gap, and leader information for opponents.

#### Geographically Close Opponents (`CarAhead01` - `CarAhead05` & `CarBehind01` - `CarBehind05`)

For each car slot `(CarAhead01..05, CarBehind01..05)`:

| Name | Description | Type |
| --- | --- | --- |
| Name | Full driver name | string |
| Position | Race position | integer |
| Relative | Relative gap estimated from lap time and track position | seconds |
| Gap | Total gap estimated from lap time and track position | seconds |
| RealGap | Total gap measured with stopwatch timing | seconds |
| RealRelative | Relative gap measured with stopwatch timing | seconds |
| BestLap | Best valid lap time | timespan |
| ClassColor | iRacing class color | hexadecimal |
| ClassDifference | Difference in class level relative to you (-4 to +4) | integer |
| IsAhead | Opponent is ahead in race standings | boolean |
| IsClassLeader | Opponent is class leader | boolean |
| IsInPit | Opponent is in pit lane/stall | boolean |
| LapsSincePit | Completed laps since last pit stop | integer |
| P2PStatus | Opponent has active push-to-pass | boolean |
| P2PCount | Remaining push-to-pass uses | 0 - 10 |
| JokerLaps | Number of completed joker laps | integer |
| IRating | Opponent iRating | integer |
| License | License and safety rating | string |

#### Key Race Positions (CarInFront, CarBehind, ClassLeader, OverallLeader, PitTarget, etc.)

| Name | Description | Type |
| --- | --- | --- |
| CarInFrontName / CarBehindName | Name of car ahead/behind in race standings | string |
| CarInFrontGap / CarBehindGap | Gap to car ahead/behind in race standings | seconds |
| CarInFrontRealGap / CarBehindRealGap | Measured stopwatch gap to car ahead/behind | seconds |
| CarInFrontPace / CarBehindPace | Estimated pace of car ahead/behind | timespan |
| CarInFrontIsClassLeader | Car in front is class leader | boolean |
| CarInFrontClassDifference / CarBehindClassDifference | Class level difference (-4 to +4) | integer |
| CarInFrontDeltaPace / CarBehindDeltaPace | Difference in pace compared to you | seconds |
| CarInFrontP2PStatus / CarBehindP2PStatus | Car ahead/behind has active P2P | boolean |
| CarInFrontP2PCount / CarBehindP2PCount | Car ahead/behind remaining P2P uses | 0 - 10 |
| CarInFrontIsInPit / CarBehindIsInPit | Car ahead/behind is in pit | boolean |
| CarInFrontLapsSincePit / CarBehindLapsSincePit | Car ahead/behind laps since last pit stop | integer |
| CarInFrontIsConnected / CarBehindIsConnected | Driver connection status | boolean |
| LapsToCatch / LapsToOvertake | Estimated laps to reach / overtake car in front | integer |
| P1Name / P1Gap / P1Pace / P1Finished | Overall leader information | various |
| ClassP1Name / ClassP1Gap / ClassP1RealGap / ClassP1Pace | Class leader information | various |
| LuckyDogName / LuckyDogGap / LuckyDogRealGap / LuckyDogPositionsAhead | Lucky Dog status and gap information | various |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

### ⏱️ Lap Timing

Properties for timing, deltas, and lap predictions.

| Name | Description | Type |
| --- | --- | --- |
| BestLap | Your overall best lap time in current session | timespan |
| BestSector1 / BestSector2 / BestSector3 | Sector times from your best lap | timespan |
| BestValidLap | Best valid lap time (excluding invalid laps) | timespan |
| LastLap | Time of previous lap | timespan |
| LastLapValid | Previous lap was clean / valid | boolean |
| LastLapInLap / LastLapOutLap / LastLapJoker | Previous lap status flags | boolean |
| LastLapSector1 / LastLapSector2 / LastLapSector3 | Previous lap sector times | timespan |
| LastLapFuel | Fuel used during previous lap | liters / gal |
| CurLapSector1 / CurLapSector2 / CurLapSector3 | Current lap completed sector times | timespan |
| CurLapValid | Current lap is valid so far | boolean |
| CurLapJoker | Current lap is a joker lap | boolean |
| CurLapCleanJoker | Current lap is a clean joker lap | boolean |
| PredictedLapTime | Calculated lap time prediction for current lap | timespan |
| DeltaToBest | Delta to your best lap time | seconds |
| DeltaToBestValid | Delta to your best valid lap time | seconds |
| DeltaToSessionBest | Delta to overall session best lap time | seconds |
| DeltaToClassSessionBest | Delta to class best lap time | seconds |
| DeltaToOptimal | Delta to your optimal theoretical lap time | seconds |
| DeltaToPace | Delta to your calculated race pace | seconds |
| DeltaToTargetPace | Delta to target fuel save pace | seconds |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

### 📊 Lap Sectors

Properties tracking sector performance, deltas, and theoretical optimal lap.

| Name | Description | Type |
| --- | --- | --- |
| SectorCount | Total number of sectors defined on track | integer |
| CurrentSector | Current active sector number | 1 - N |
| OptimalLap | Theoretical optimal lap sum of best sectors | timespan |
| Sector1Delta / Sector2Delta / Sector3Delta | Sector time deltas compared to best lap sectors | seconds |
| Sector1Best / Sector2Best / Sector3Best | Personal best sector times across session | timespan |
| ClassBestSector1 / ClassBestSector2 / ClassBestSector3 | Class best sector times across session | timespan |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

### 🚀 Launch

Properties used for launch control and dual-clutch bite point assist.

| Name | Description | Type |
| --- | --- | --- |
| LaunchBitePoint | Optimal clutch value for dual clutch release | 0 - 100 |
| LaunchSpin | Highest clutch value that produces wheel spin on launch | 0 - 100 |
| LaunchIdealRangeStart | Minimum clutch value for competitive launch | 0 - 100 |
| LaunchIdealRangeStop | Maximum clutch value for competitive launch | 0 - 100 |
| LaunchGearRelease | Target gear during initial clutch release | integer |
| LaunchGearReleased | Target gear when bite point clutch is fully released | integer |
| LaunchTimeRelease | Timing percentage for starting bite point release | 0 - 100 |
| LaunchTimeReleased | Timing percentage for complete bite point release | 0 - 100 |
| HighPower | True if both throttle and clutch must be modulated on launch | boolean |
| LaunchThrottle | Ideal throttle percentage for high-power launch | 0 - 100 |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

### ⛽ Fuel and Strategy

Properties for fuel calculations, fuel saving, and stint strategy.

| Name | Description | Type |
| --- | --- | --- |
| FuelDelta | Fuel margin at end of session (+/- liters/gal) | liters / gal |
| FuelPitWindowFirst | Earliest lap to pit and finish race without further refueling | integer |
| FuelPitWindowLast | Latest lap you can pit before running out of fuel | integer |
| FuelMinimumFuelFill | Minimum fuel needed at pit stop to complete race | liters / gal |
| FuelMaximumFuelFill | Maximum useful fuel to add at pit stop | liters / gal |
| FuelPitStops | Remaining required pit stops for fuel | integer |
| FuelConserveToSaveAStop | Fuel needed to save per lap to eliminate a pit stop | liters / gal |
| FuelAlert | Trigger alert when fuel level is low or critical | boolean |
| CalcLastLapFuel | Fuel consumption on last lap | liters / gal |
| CalcFuelPerLap | Estimated fuel consumption per lap | liters / gal |
| CalcAverageFuel | Average fuel consumption per lap over stint | liters / gal |
| FuelDeltaLL | Fuel delta calculated using last lap consumption | liters / gal |
| FuelPitWindowFirstLL | Earliest pit lap calculated using last lap consumption | integer |
| FuelPitWindowLastLL | Latest pit lap calculated using last lap consumption | integer |
| FuelMinimumFuelFillLL | Minimum fuel fill calculated using last lap consumption | liters / gal |
| FuelMaximumFuelFillLL | Maximum fuel fill calculated using last lap consumption | liters / gal |
| FuelPitStopsLL | Pit stops required calculated using last lap consumption | integer |
| FuelConserveToSaveAStopLL | Conserve target calculated using last lap consumption | liters / gal |
| FuelSlowestFuelSavePace | Slowest lap time allowed to save enough fuel | timespan |
| FuelSaveDeltaValue | Delta to fuel-save target pace | seconds |
| FuelPerLapTarget | Target fuel consumption per lap | liters / gal |
| FuelPerLapTargetLocked | Target fuel consumption lock status | boolean |
| FuelPerLapTargetLastLapDelta | Delta between last lap fuel consumption and target | liters / gal |
| FuelTargetDeltaCumulative | Cumulative fuel saved/spent relative to target | liters / gal |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

### 🔧 Pit Service

Properties tracking pit service selections, durations, and pit stall status.

| Name | Description | Type |
| --- | --- | --- |
| BoxApproach | True if within pit box area and pit stop is pending | boolean |
| PitEntry | Evaluates if entering pit lane with speed limiter | boolean |
| PitSpeeding | Speeding in pit lane indicator | boolean |
| PitCrewType | Crew tire change method (1: Single, 2: Pairs front/rear, 3: Pairs left/right, 4: All 4) | integer |
| PitServiceFuelTarget | Target fuel fill requested for pit service | liters / gal |
| PitTimeTires | Expected duration of tire change | seconds |
| PitTimeFuel | Expected duration of refueling | seconds |
| PitTimeWindscreen | Expected duration of windscreen tear-off | seconds |
| PitTimeAdjustment | Expected duration of car setup adjustments in pit | seconds |
| PitTimeDriveThrough | Expected time lost doing a drive-through penalty | seconds |
| PitTimeService | Expected total duration in pit stall | seconds |
| PitTimeTotal | Total pit stop time lost (Service + DriveThrough) | seconds |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

### ⤴️ Pit Exit

Properties predicting pit exit position and surrounding traffic.

| Name | Description | Type |
| --- | --- | --- |
| PitExitPosition | Predicted race position after exiting pit | integer |
| PitExitCar(1..14)Name | First 3 letters of surname (uppercase) for pit exit traffic | string |
| PitExitCar(1..14)Gap | Expected gap at pit exit (negative = ahead, positive = behind) | decimal |
| PitExitCar(1..14)Position | Predicted race position of car after your pit stop | integer |
| PitExitCar(1..14)ClassDifference | Class difference level relative to you | integer |
| PitExitCar(1..14)IsAhead | Car will be ahead in race standings after pit exit | boolean |
| PitExitCar(1..14)IsFaster | Car has a faster best lap time | boolean |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

### 🔨 Utility

Utility properties used in dashboards and controls.

| Name | Description | Type |
| --- | --- | --- |
| SteeringAngle | Angle of steering wheel | 0 - 360 |
| StopWatch | Timer value for pit menu stopwatch | timespan |
| StopWatchSplit | Split time for pit menu stopwatch | timespan |
| TestProperty | Property used for plugin test purposes | various |
| Version | Version string of the plugin | string |
| MyClutch | Clutch pedal output from mapped axis | percent |
| MyBitePoint | Bite point output from mapped axis | percent |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

### 🖥️ Dashboard Settings

Properties reflecting plugin configuration settings.

| Name | Description | Type |
| --- | --- | --- |
| DashLEDEnabled | Uses simulated LEDs instead of RPM bar | boolean |
| ShowMapEnabled | Shows track map instead of gear in center box | boolean |
| ShowBrakeThrottleGaugesEnabled | Displays throttle and brake input gauges on center box frame | boolean |
| DashType | Current graphic theme setting for center box | string |
| Dashboard.LeftScreen | Current left screen page index | 1 - 9 |
| Dashboard.RightScreen | Current right screen page index | 1 - 8 |
| Dashboard.DeltaScreen | Current delta screen page index | 1 - 5 |
| DeltaBarSensitivity | Sensitivity factor for delta bar display | decimal |
| Dashboard.ShowGenericSplashEnabled | Enables generic splash screen during in-car adjustments | boolean |
| LapInfoScreen | Shows lap summary when starting a new lap | boolean |
| ShiftTimingAssist | Enables shift timing assist tools outside practice | boolean |
| ShiftWarning | RPM bar changes color for shift alert | boolean |
| ARBswapped | Flips ARB lever graphics in Supercars dash type | boolean |
| ARBstiffForward | Reverses ARB lever graphics in Supercars dash type | boolean |
| SmallFuelIncrement | Selected fuel increment for small adjustments in PitMenu | integer |
| LargeFuelIncrement | Selected fuel increment for large adjustments in PitMenu | integer |
| CoupleInCarToPit | Couples InCarMenu and PitMenu navigation | boolean |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

### 🎛️ Dashboard Control

Properties controlling UI element visibility and menu navigation.

| Name | Description | Type |
| --- | --- | --- |
| LaunchScreen | Launch screen visibility | boolean |
| PitScreen | Pit screen visibility | boolean |
| PaceCheck | Pace screen visibility | boolean |
| TCOffTimer | Active countdown timer for traction control deactivation | timespan |
| PitMenu | Current position in PitMenu | 1 - 12 |
| InCarMenu | Current position in InCarMenu | 1 - 12 |
| BitePointAdjust | Lock status of bite point potentiometer | boolean |
| NoBoost | NoBoost active status (e.g. Porsche 919) | boolean |
| Radio | Push-to-talk radio active status | boolean |
| LEDWarnings | Guide light warnings toggle for DDU | boolean |
| SpotterMode | Spotter mode toggle (hides idle screen) | boolean |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

### 🚥 LED Control

Properties for SimHub RGB LED mapping and control.

| Name | Description | Type |
| --- | --- | --- |
| DDUstartLED | First LED index assigned to DahlDesign DDU in SimHub RGB chain | integer |
| DDUEnabled | Enables DahlDesign DDU LED integration | boolean |
| SW1startLED | First LED index assigned to DahlDesign SW1 in SimHub RGB chain | integer |
| SW1Enabled | Enables DahlDesign SW1 LED integration and dashboard features | boolean |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

### 🎮 DDC

Properties read from Dahl Design Controller (DDC) devices.

| Name | Description | Type |
| --- | --- | --- |
| DDCclutch | Clutch output signal from controller | 0 - 100 |
| DDCbitePoint | Clutch bite point setting | 0 - 100 |
| DDCbrake | Brake output signal from controller | 0 - 100 |
| DDCthrottle | Throttle output signal from controller | 0 - 100 |
| DDCDDSMode | Mode of DDS switch | 0 - 3 |
| DDCDDSEnabled | Controller has an active DDS switch | boolean |
| DDCEnabled | Enables reading from DDC controller | boolean |
| DDCclutchMode | Dual-clutch operational mode | 0 - 3 |
| DDCbiteSetting | Step size for bite point adjustment (0: Off, 1: 10%, 2: 1%, 3: 0.1%) | 0 - 3 |
| DDCPreset | Active preset index | 1 - 12 |
| DDCneutralActive | Neutral button status | boolean |
| DDCneutralMode | Mode of neutral button | 0 - 1 |
| DDChandbrakeActive | Handbrake active status | boolean |
| DDCthrottleHoldActive | Throttle hold active status | boolean |
| DDCmagicActive | Brake magic active status | boolean |
| DDCquickSwitchMode | Main quick switch mode | 0 - 1 |
| DDCquickSwitchActive | Main quick switch status | boolean |
| DDCB1..DDCB4 | Value from button field bits 1 to 4 | 0 - 1 |
| DDCR1..DDCR8, DDCR15 | Value from rotary field bits 1 to 8 and 15 | 0 - 1 |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

---

### 🕹️ SW1

Properties read from Dahl Design SW1 steering wheel controller.

| Name | Description | Type |
| --- | --- | --- |
| SW1Clutch | Clutch output signal from SW1 | 0 - 100 |
| SW1BitePoint | Clutch bite point setting | 0 - 100 |
| SW1Brake | Brake output signal from SW1 | 0 - 100 |
| SW1Throttle | Throttle output signal from SW1 | 0 - 100 |
| SW1DDSMode | Mode of DDS switch | 0 - 3 |
| SW1ClutchMode | Mode of dual clutches | 0 - 3 |
| SW1BiteSetting | Step size for bite point adjustment (0: Off, 1: 10%, 2: 1%, 3: 0.1%) | 0 - 3 |
| SW1Preset | Active preset index | 1 - 12 |
| SW1NeutralActive | Neutral button status | boolean |
| SW1NeutralMode | Mode of neutral button | 0 - 1 |
| SW1ThrottleHoldActive | Throttle hold status | boolean |
| SW1MagicToggleActive | Brake magic active status | boolean |
| SW1MagicToggleMode | Mode of magic toggle switch | 0 - 1 |
| SW1QuickSwitchMode | Quick switch operational mode | 0 - 1 |
| SW1QuickSwitchActive | Quick switch status | boolean |
| SW1HandbrakeActive | Handbrake active status | boolean |
| SW1RadioButtonMode | Radio button operational mode | 0 - 1 |
| SW1RightRotaryMode | Mode of right 12-position switch | 0 - 1 |
| SW1LeftRotaryMode | Mode of left 12-position switch | 0 - 1 |
| SW1RightToggleMode | Mode of right toggle switch | 0 - 1 |
| SW1LeftToggleMode | Mode of left toggle switch | 0 - 1 |
| SW1ShifterMode | Mode of the 4 shifter paddles | 0 - 1 |

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- MARKDOWN LINKS & IMAGES -->
[contributors-shield]: https://img.shields.io/github/contributors/NotSwedishBacon/DahlDesignProperties.svg?style=for-the-badge
[contributors-url]: https://github.com/NotSwedishBacon/DahlDesignProperties/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/NotSwedishBacon/DahlDesignProperties.svg?style=for-the-badge
[forks-url]: https://github.com/NotSwedishBacon/DahlDesignProperties/network/members
[stars-shield]: https://img.shields.io/github/stars/NotSwedishBacon/DahlDesignProperties.svg?style=for-the-badge
[stars-url]: https://github.com/NotSwedishBacon/DahlDesignProperties/stargazers
[issues-shield]: https://img.shields.io/github/issues/NotSwedishBacon/DahlDesignProperties.svg?style=for-the-badge
[issues-url]: https://github.com/NotSwedishBacon/DahlDesignProperties/issues
