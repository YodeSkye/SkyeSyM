
Imports System.Threading
Imports Skye.UI

Namespace My

	Friend Module App

		' Declarations
		Friend FrmMain As MainForm
		Friend FrmHelp As Help
		Friend FrmLog As Skye.UI.Log.LogViewer
		Friend FrmSettings As Settings
		Friend ReadOnly Property FrmHelpVisible As Boolean
			Get
				If FrmHelp IsNot Nothing Then Return FrmHelp.Visible
				Return False
			End Get
		End Property
		Friend ReadOnly Property FrmLogVisible As Boolean
			Get
				If FrmLog IsNot Nothing Then Return FrmLog.Visible
				Return False
			End Get
		End Property
		Friend Const WinTaskManagerPath As String = "C:\Windows\System32\taskmgr.exe"
		Friend Const WinResourceMonitorPath As String = "C:\Windows\System32\resmon.exe"
		Friend Const WinPerformanceMonitorPath As String = "C:\Windows\System32\perfmon.exe"
		Friend Const AdjustScreenBoundsNormalWindow As Byte = 8 'AdjustScreenBoundsNormalWindow is the number of pixels to adjust the screen bounds for normal windows.
		Friend Const AdjustScreenBoundsDialogWindow As Byte = 10 'AdjustScreenBoundsDialogWindow is the number of pixels to adjust the screen bounds for dialog windows.
		Private ReadOnly ctsScreenSaver As New CancellationTokenSource()
		Private ScreenSaverRunning As Boolean = False
		Private WorkStationLocked As Boolean = False

		' HotKeys
		Friend FrmHK As HotKeyWindow
		Friend Structure HKType
			Dim WinID As Integer
			Dim Key As Keys
			Dim KeyCode As Byte
			Dim KeyMod As Byte
		End Structure

		' SyM
		Friend FrmSyM As SyM
		Friend Const KBConversion As UInt16 = 1024
		Friend Const MBConversion As UInt32 = 1048576
		Friend Const GBConversion As UInt32 = 1073741824
		Friend Enum SyMCounters
			SystemUpTime
			PagingFileUsage
			Processes
			Processor
			ProcessorUser
			ProcessorSystem
			Memory
			MemoryPhysical
			MemoryPhysicalGB
			MemoryPhysicalPercent
			Disk
			Disk0
			Disk1
			Disk2
			Disk3
			Network
			NetworkDownload
			NetworkUpload
			ProcessProcessor
			ProcessMemoryPhysical
			ProcessMemoryPhysicalPercent
			ProcessThreads
			ProcessHandles
			ProcessPriority
			ProcessTime
			ProcessID
		End Enum
		Friend Enum SyMProcessPriority
			Realtime = 24
			High = 13
			AboveNormal = 10
			Normal = 8
			BelowNormal = 6
			Low = 4
			NA = 0
		End Enum
		Friend Structure SyMColors
			Dim Background As Color
			Dim ForegroundOnBackground As Color
			Dim Foreground As Color
			Dim BarBackground As Color
			Dim BarForeground As Color
			Dim BarProcessorUserForeground As Color
			Dim BarProcessorSystemForeground As Color
			Shared Function Defaults() As SyMColors
				Defaults = New SyMColors With {
					.Background = Color.WhiteSmoke,
					.ForegroundOnBackground = Color.Crimson,
					.Foreground = Color.Crimson,
					.BarBackground = Color.WhiteSmoke,
					.BarForeground = Color.Teal,
					.BarProcessorUserForeground = Color.MediumBlue,
					.BarProcessorSystemForeground = Color.Crimson}
			End Function
			Shared Function IsNullOrEmpty(colors As SyMColors) As Boolean
				If colors.Background = Color.Empty And colors.ForegroundOnBackground = Color.Empty And colors.Foreground = Color.Empty And colors.BarBackground = Color.Empty And colors.BarForeground = Color.Empty And colors.BarProcessorUserForeground = Color.Empty And colors.BarProcessorSystemForeground = Color.Empty Then
					Return True
				Else
					Return False
				End If
			End Function
		End Structure
		Friend ReadOnly SyMMemoryPhysicalMaximum As Integer = CInt(My.Computer.Info.TotalPhysicalMemory / MBConversion)
		Friend ReadOnly SyMMemoryPhysicalMaximumRaw As UInt64 = CULng(My.Computer.Info.TotalPhysicalMemory)
		Friend ReadOnly SyMColorTransparencyKey As Color = Color.FromArgb(254, 0, 0)
		Friend SyMProcessInstance As String = My.Application.Info.AssemblyName
		Friend SyMProcessIconCache As New Dictionary(Of String, Icon)
		Private ctsSyM As CancellationTokenSource
		Public Class SyMSnapshot
			' MainForm-only data
			Public SystemUpTime As Integer
			Public PagingFileUsage As Integer

			' Processor
			Public ProcessorRaw As Single
			Public ProcessorSystemRaw As Single
			Public Processor As Integer
			Public ProcessorSystem As Integer
			Public ProcessorUser As Integer
			Public ProcessorUserRaw As Single

			' Processes
			Public Processes As Integer

			' Memory Physical
			Public MemoryPhysicalRaw As Single
			Public MemoryPhysicalMB As Integer
			Public MemoryPhysicalFreeRaw As Single

			' Disk
			Public Disk0Raw As Single
			Public Disk0 As Integer
			Public Disk1Raw As Single
			Public Disk1 As Integer

			' Network
			Public NetworkDownloadRaw As Single
			Public NetworkDownloadKB As Integer
			Public NetworkUploadRaw As Single
			Public NetworkUploadKB As Integer

			' Instance (Process)
			Public ProcCPU As Integer
			Public ProcCPURaw As Single
			Public ProcID As Integer
			Public ProcPriority As Integer
			Public ProcTime As Integer
			Public ProcThreads As Integer
			Public ProcHandles As Integer
			Public ProcMemRaw As Single
			Public ProcMemMB As Integer
		End Class
		Private SyMpcSystemUpTime As Diagnostics.PerformanceCounter
		Private SyMpcPagingFileUsage As Diagnostics.PerformanceCounter
		Private SyMpcProcesses As Diagnostics.PerformanceCounter
		Private SyMpcProcessor As Diagnostics.PerformanceCounter
		Private SyMpcProcessorSystem As Diagnostics.PerformanceCounter
		Private SyMpcMemoryPhysical As Diagnostics.PerformanceCounter
		Private SyMpcDisk0 As Diagnostics.PerformanceCounter
		Private SyMpcDisk1 As Diagnostics.PerformanceCounter
		Private SyMpcNetworkDownload As Diagnostics.PerformanceCounter
		Private SyMpcNetworkUpload As Diagnostics.PerformanceCounter
		Private SyMpcProcessProcessor As Diagnostics.PerformanceCounter
		Private SyMpcProcessMemoryPhysical As Diagnostics.PerformanceCounter
		Private SyMpcProcessThreads As Diagnostics.PerformanceCounter
		Private SyMpcProcessHandles As Diagnostics.PerformanceCounter
		Private SyMpcProcessPriority As Diagnostics.PerformanceCounter
		Private SyMpcProcessTime As Diagnostics.PerformanceCounter
		Private SyMpcProcessID As Diagnostics.PerformanceCounter

		' Saved Settings
		Friend SyMAutoMinimal As Boolean 'Default = True
		Friend SyMAutoClose As Boolean 'Default = True
		Friend SyMUpdateInterval As UInt16 '250ms-60000ms
		Friend SyMQuickHideInterval As Byte 'Range 5-60, Default 5
		Friend SyMOpacity As Byte '10%-100%, 10% Increments
		Friend SyMNetworkDownloadMaximum As UInt16
		Friend SyMNetworkUploadMaximum As UInt16
		Friend SyMNetworkInstance As String
		Friend SyMColor As SyMColors
		Friend SyMLocation As Point
		Friend SyMPinnedProcesses As New List(Of String)
		Friend HKEnabled As Boolean
		Friend HKSyM As New HKType
		Friend Theme As Skye.UI.SkyeTheme
		Friend ThemeAuto As Boolean

		' Handlers
		Private Sub OnThemeChanged(sender As Object, e As EventArgs)
			For Each f As Form In Application.OpenForms
				If TypeOf f IsNot SyM Then
					ThemeManager.ApplyTheme(f)
				End If
			Next
		End Sub
		Private Sub OnHotKey(id As Integer)
			HKPerformAction(id)
		End Sub
		Private Async Sub StartScreenSaverWatcher()
			Dim timer As New PeriodicTimer(TimeSpan.FromSeconds(2))
			Try
				While Await timer.WaitForNextTickAsync(ctsScreenSaver.Token)
					Dim ssStatus As Boolean = False
					Skye.WinAPI.SystemParametersInfo(Skye.WinAPI.SPI_GETSCREENSAVERRUNNING, 0, ssStatus, 0)
					If ssStatus AndAlso Not ScreenSaverRunning Then
						ScreenSaverRunning = True
						Skye.Common.Log.Write("ScreenSaver Activated")
						If SyMAutoClose AndAlso FrmMain IsNot Nothing AndAlso Not FrmMain.IsDisposed Then
							FrmMain.BeginInvoke(Sub() FrmMain.ShowSyM(True))
						End If
					ElseIf Not ssStatus AndAlso ScreenSaverRunning Then
						ScreenSaverRunning = False
						Skye.Common.Log.Write("ScreenSaver DeActivated")
					End If
				End While
			Catch ex As OperationCanceledException
				' Normal shutdown
			End Try
		End Sub
		Private Sub WorkStationLockedHandler(sender As Object, e As Microsoft.Win32.SessionSwitchEventArgs)
			If e.Reason = Microsoft.Win32.SessionSwitchReason.SessionLock Then
				WorkStationLocked = True
				'Debug.Print("SessionSwitch: Workstation Locked @ " & Now)
				Skye.Common.Log.Write("WorkStation Locked")
				If SyMAutoClose Then FrmMain.ShowSyM(True)
			ElseIf e.Reason = Microsoft.Win32.SessionSwitchReason.SessionUnlock Then
				WorkStationLocked = False
				'Debug.Print("SessionSwitch: Workstation UNLocked @ " & Now)
				Skye.Common.Log.Write("WorkStation UnLocked")
			End If
		End Sub
		Public Async Sub StartSyMLoop()
			ctsSyM = New CancellationTokenSource()
			Dim timer As New PeriodicTimer(TimeSpan.FromMilliseconds(SyMUpdateInterval))

			Try
				While True

					' SAFETY CHECK: loop was stopped/reset while running
					If ctsSyM Is Nothing Then Exit While

					' Wait for next tick
					If Not Await timer.WaitForNextTickAsync(ctsSyM.Token) Then Exit While

					' Collect data off UI thread
					Dim snap = Await Task.Run(Function() CollectSyMData())

					' Apply to UI
					If FrmSyM IsNot Nothing AndAlso FrmSyM.IsHandleCreated Then
						FrmSyM.BeginInvoke(Sub() ApplySyMData(snap))
					End If

				End While

			Catch ex As OperationCanceledException
				' normal shutdown
			End Try
		End Sub

		' Methods
		Friend Sub Initialize()
			Debug.Print(My.Application.Info.ProductName + " Starting...")
#If DEBUG Then
			Skye.Common.Log.Initialize(My.Computer.FileSystem.SpecialDirectories.Temp + "\" + My.Application.Info.ProductName + "DEV") ' Initialize Log With Path To Log Folder. Log File Will Be Created Automatically When First Log Entry Is Written. Log Folder Will Be Created If It Does Not Exist.
			Skye.Common.RegistryHelper.BaseKey = "Software\\" + My.Application.Info.ProductName + "DEV" 'BaseKey is the path to the registry key where application settings are stored.
#Else
            Skye.Common.Log.Initialize(My.Computer.FileSystem.SpecialDirectories.Temp + "\" + My.Application.Info.ProductName) ' Initialize Log With Path To Log Folder. Log File Will Be Created Automatically When First Log Entry Is Written. Log Folder Will Be Created If It Does Not Exist.
			Skye.Common.RegistryHelper.BaseKey = "Software\\" + My.Application.Info.ProductName 'BaseKey is the path to the registry key where application settings are stored.
#End If
			Skye.Common.Log.Write(My.Application.Info.ProductName + " Started...")
			GetSettings()
			If ThemeAuto Then
				Skye.UI.ThemeManager.SetTheme(Skye.UI.ThemeManager.DetectWindowsTheme())
			Else
				Skye.UI.ThemeManager.CurrentTheme = Theme
			End If
			AddHandler Skye.UI.ThemeManager.ThemeChanged, AddressOf OnThemeChanged
			FrmMain = New MainForm
			SyMSet()
			StartScreenSaverWatcher()
			AddHandler Microsoft.Win32.SystemEvents.SessionSwitch, AddressOf WorkStationLockedHandler
			FrmHK = New HotKeyWindow
			AddHandler FrmHK.HotKeyPressed, AddressOf OnHotKey
			If HKEnabled Then HKRegister(True)
		End Sub
		Friend Sub Finalize()
			ctsScreenSaver.Cancel()
			StopSyMLoop()
			SyMSet(True)
			If HKEnabled Then HKRegister(False)
			Skye.Common.Log.Write("..." + My.Application.Info.ProductName + " Closed")
		End Sub
		Friend Sub GetSettings()

			' HK
			HKEnabled = Skye.Common.RegistryHelper.GetBool("HKEnabled", False)
			HKSyM.WinID = 1
			HKSyM.Key = CType(Skye.Common.RegistryHelper.GetInt("HKSyMKey", CInt(Keys.None)), Keys)
			HKSyM.KeyCode = CByte(Skye.Common.RegistryHelper.GetInt("HKSyMKeyCode", 0))
			HKSyM.KeyMod = CByte(Skye.Common.RegistryHelper.GetInt("HKSyMKeyMod", 0))

			' SyM
			SyMAutoMinimal = Skye.Common.RegistryHelper.GetBool("SyMAutoMinimal", True)
			SyMAutoClose = Skye.Common.RegistryHelper.GetBool("SyMAutoClose", True)
			SyMUpdateInterval = CUShort(Skye.Common.RegistryHelper.GetInt("SyMUpdateInterval", 750))
			If SyMUpdateInterval < 250 OrElse SyMUpdateInterval > 60000 Then SyMUpdateInterval = 750
			SyMQuickHideInterval = CByte(Skye.Common.RegistryHelper.GetInt("SyMQuickHideInterval", 5))
			If SyMQuickHideInterval < 5 OrElse SyMQuickHideInterval > 60 Then SyMQuickHideInterval = 5
			SyMOpacity = CByte(Skye.Common.RegistryHelper.GetInt("SyMOpacity", 100))
			If SyMOpacity < 10 OrElse SyMOpacity > 100 Then SyMOpacity = 100
			SyMOpacity = CByte((SyMOpacity \ 10) * 10)
			SyMNetworkDownloadMaximum = CUShort(Skye.Common.RegistryHelper.GetInt("SyMNetworkDownloadMaximum", 32))
			SyMNetworkUploadMaximum = CUShort(Skye.Common.RegistryHelper.GetInt("SyMNetworkUploadMaximum", 32))
			SyMNetworkInstance = Skye.Common.RegistryHelper.GetString("SyMNetworkInstance", String.Empty)
			SyMColor = New SyMColors With {
				.Background = Color.FromArgb(Skye.Common.RegistryHelper.GetInt("SyMColorBackground", SyMColors.Defaults.Background.ToArgb)),
				.ForegroundOnBackground = Color.FromArgb(Skye.Common.RegistryHelper.GetInt("SyMColorForegroundOnBackground", SyMColors.Defaults.ForegroundOnBackground.ToArgb)),
				.Foreground = Color.FromArgb(Skye.Common.RegistryHelper.GetInt("SyMColorForeground", SyMColors.Defaults.Foreground.ToArgb)),
				.BarBackground = Color.FromArgb(Skye.Common.RegistryHelper.GetInt("SyMColorBarBackground", SyMColors.Defaults.BarBackground.ToArgb)),
				.BarForeground = Color.FromArgb(Skye.Common.RegistryHelper.GetInt("SyMColorBarForeground", SyMColors.Defaults.BarForeground.ToArgb)),
				.BarProcessorUserForeground = Color.FromArgb(Skye.Common.RegistryHelper.GetInt("SyMColorBarProcessorUserForeground", SyMColors.Defaults.BarProcessorUserForeground.ToArgb)),
				.BarProcessorSystemForeground = Color.FromArgb(Skye.Common.RegistryHelper.GetInt("SyMColorBarProcessorSystemForeground", SyMColors.Defaults.BarProcessorSystemForeground.ToArgb))
			}
			SyMLocation.X = Skye.Common.RegistryHelper.GetInt("SyMLocationX", 0)
			SyMLocation.Y = Skye.Common.RegistryHelper.GetInt("SyMLocationY", 0)
			App.SyMPinnedProcesses.Clear()
			App.SyMPinnedProcesses.AddRange(Skye.Common.RegistryHelper.GetStringArray("SyMPinnedProcesses", Array.Empty(Of String)()))

			' Theme
			Dim themeName As String = Skye.Common.RegistryHelper.GetString("Theme", "Light")
			Theme = SkyeThemes.GetTheme(themeName)
			ThemeAuto = Skye.Common.RegistryHelper.GetBool("ThemeAuto", True)

#If DEBUG Then
			GetSettingsDebug()
#End If
			Skye.Common.Log.Write("Settings Loaded")
		End Sub
		Friend Sub SaveSettings()

			' HK
			Skye.Common.RegistryHelper.SetBool("HKEnabled", HKEnabled)
			Skye.Common.RegistryHelper.SetInt("HKSyMKey", CInt(HKSyM.Key))
			Skye.Common.RegistryHelper.SetInt("HKSyMKeyCode", HKSyM.KeyCode)
			Skye.Common.RegistryHelper.SetInt("HKSyMKeyMod", HKSyM.KeyMod)

			' SyM
			Skye.Common.RegistryHelper.SetBool("SyMAutoMinimal", SyMAutoMinimal)
			Skye.Common.RegistryHelper.SetBool("SyMAutoClose", SyMAutoClose)
			Skye.Common.RegistryHelper.SetInt("SyMUpdateInterval", SyMUpdateInterval)
			Skye.Common.RegistryHelper.SetInt("SyMQuickHideInterval", SyMQuickHideInterval)
			Skye.Common.RegistryHelper.SetInt("SyMOpacity", SyMOpacity)
			Skye.Common.RegistryHelper.SetInt("SyMNetworkDownloadMaximum", SyMNetworkDownloadMaximum)
			Skye.Common.RegistryHelper.SetInt("SyMNetworkUploadMaximum", SyMNetworkUploadMaximum)
			Skye.Common.RegistryHelper.SetString("SyMNetworkInstance", SyMNetworkInstance)
			Skye.Common.RegistryHelper.SetInt("SyMColorBackground", SyMColor.Background.ToArgb)
			Skye.Common.RegistryHelper.SetInt("SyMColorForegroundOnBackground", SyMColor.ForegroundOnBackground.ToArgb)
			Skye.Common.RegistryHelper.SetInt("SyMColorForeground", SyMColor.Foreground.ToArgb)
			Skye.Common.RegistryHelper.SetInt("SyMColorBarBackground", SyMColor.BarBackground.ToArgb)
			Skye.Common.RegistryHelper.SetInt("SyMColorBarForeground", SyMColor.BarForeground.ToArgb)
			Skye.Common.RegistryHelper.SetInt("SyMColorBarProcessorUserForeground", SyMColor.BarProcessorUserForeground.ToArgb)
			Skye.Common.RegistryHelper.SetInt("SyMColorBarProcessorSystemForeground", SyMColor.BarProcessorSystemForeground.ToArgb)
			Skye.Common.RegistryHelper.SetInt("SyMLocationX", SyMLocation.X)
			Skye.Common.RegistryHelper.SetInt("SyMLocationY", SyMLocation.Y)
			Skye.Common.RegistryHelper.SetStringArray("SyMPinnedProcesses", SyMPinnedProcesses.ToArray)

			' Theme
			Skye.Common.RegistryHelper.SetString("Theme", Theme.Name)
			Skye.Common.RegistryHelper.SetBool("ThemeAuto", ThemeAuto)

			Skye.Common.Log.Write("Settings Saved")
		End Sub
		Friend Sub ShowSettings()
			If FrmSettings Is Nothing OrElse FrmSettings.IsDisposed Then FrmSettings = New Settings With {.Text = My.Application.Info.ProductName & " Settings"}
			Dim wa = Screen.FromControl(FrmSettings).WorkingArea
			FrmSettings.WindowState = FormWindowState.Normal
			FrmSettings.Show()
			FrmSettings.Activate()
		End Sub
		Friend Sub ShowHelp()

			If FrmHelpVisible() Then FrmHelp.Close()
			FrmHelp = New Help With {
				.Text = My.Application.Info.ProductName + " Help & About"
			}

			Dim message As String = "System Monitor -- Processor Utilization Is the amount Of time the processor Is active, relative To total capacity Of the processor. This Is the 'CPU Usage' graph in Windows Task Manager. Processor Time is the amount of time the processor is active for the specified process, relative to the total processor usage of all processes."
			message += Chr(13) + Chr(13) + "System Monitor -- Physical Memory Relative Utilization is the percentage of memory a process is using relative to the total memory in use by all processes. This applies only to the percentage value, not the actual MB value."
			message += Chr(13) + Chr(13) + "System Monitor -- " + SyMGetCounterDescription(SyMCounters.PagingFileUsage) + " is the percent of total paging capacity currently utilized. This includes all Paging Files currently defined."
			message += Chr(13) + Chr(13) + "System Monitor -- A System Process is an App or Service run from anywhere in the Windows Install Folder."
			message += Chr(13) + Chr(13) + "System Monitor -- Your best bet for text color when the System Monitor is 'Minimal' is a red color. To hide the text completely in 'Minimal' mode, set the Foreground color to RGB:254,0,0."
			message += Chr(13) + Chr(13) + "Settings -- Auto Close means the System Monitor will automatically close when the computer is locked or the screen saver is activated."
			message += Chr(13) + Chr(13) + "Settings -- The QuickHide Interval is the amount of time it takes for the System Monitor to come back after it is hidden. This setting also applies to the Stay On Top feature."
			message += Chr(13) + Chr(13) + "SkyeSM -- Tray Icon Click Actions -->" + vbCr + vbTab + vbTab + "LeftClick = Toggle System Monitor" + vbCr + vbTab + vbTab + "DoubleLeftClick = Show Settings"

			FrmHelp.rtbMessage.ResetText()
			FrmHelp.rtbMessage.AppendText(message)
			FrmHelp.rtbMessage.Select(0, 0)
			FrmHelp.tbPostMessage.Text = "v" + My.Application.Info.Version.Major.ToString + "." + My.Application.Info.Version.Minor.ToString

			FrmHelp.btnClose.Select()
			FrmHelp.Show()

		End Sub
		Friend Sub ShowLog()
			If FrmLogVisible Then FrmLog.Close()
            FrmLog = New Skye.UI.Log.LogViewer With {
                .Icon = Resources.Resources.iconApp,
                .StartPosition = FormStartPosition.CenterScreen
            }
            Skye.UI.ThemeManager.ApplyTheme(FrmLog)
            FrmLog.Show()
		End Sub
		Friend Sub StartFile(filepath As String)
			Try : Diagnostics.Process.Start(filepath)
			Catch ex As Exception
				Skye.Common.Log.Write("Cannot Start '" + filepath + "'" + Chr(13) + ex.ToString)
				MsgBox("Cannot Start '" + filepath + "'" + vbCr + ex.Message + vbCr + "Please Check Your Settings And Try Again")
			End Try
		End Sub
		<Diagnostics.ConditionalAttribute("DEBUG")> Private Sub GetSettingsDebug()
			'SkyeSM
			'HotKeys (HK)
			HKEnabled = True
			'If HKEnabled Then
			'	HKSyM.Key = CType(262227, Keys)
			'	HKSyM.KeyCode = 83
			'	HKSyM.KeyMod = 1
			'End If
			'System Monitor (SM)
			SyMNetworkDownloadMaximum = 640
			SyMNetworkUploadMaximum = 128
			'SMNetworkInstance = "Realtek PCIe GBE Family Controller"
			SyMUpdateInterval = 1000
			SyMLocation = New Point(800, 75)
			'SMOpacity = 100
			SyMQuickHideInterval = 5
			SyMAutoMinimal = False
			SyMColor.Foreground = Color.FromArgb(254, 0, 0)
			SyMColor.BarBackground = Color.FromArgb(192, 192, 192)
		End Sub

		' HK
		Friend Sub HKRegister(Optional mode As Boolean = True)
			If HKEnabled Then
				Static status As Boolean
				Select Case mode
					Case True 'Register All HotKeys Where Key Is Not 'NONE'
						If Not HKSyM.Key = Keys.None Then
							status = Skye.WinAPI.RegisterHotKey(FrmHK.Handle, HKSyM.WinID, HKSyM.KeyMod, HKSyM.KeyCode)
							Skye.Common.Log.Write("HotKey '" + " (" + HKSyM.WinID.ToString + ") (" + HKSyM.Key.ToString + ") (" + HKSyM.KeyCode.ToString + " mod " + HKSyM.KeyMod.ToString + ")' " + IIf(status, "Successfully Registered", "Failed To Register").ToString)
						End If
					Case False 'UnRegister HotKeys
						If Not HKSyM.Key = Keys.None Then
							status = Skye.WinAPI.UnregisterHotKey(FrmHK.Handle, HKSyM.WinID)
							Skye.Common.Log.Write("HotKey '" + " (" + HKSyM.WinID.ToString + ")' " + IIf(status, "Successfully UNRegistered", "Failed To UNRegister").ToString)
						End If
				End Select
			End If
		End Sub
		Friend Sub HKPerformAction(hotkey As Integer)
			If hotkey = HKSyM.WinID Then FrmMain.ShowSyM()
		End Sub

		' SyM
		Friend Sub SyMSet(Optional forceterminate As Boolean = False)
			Skye.Common.Log.Write("SyMSet: Begin")

			' Stop loop
			Skye.Common.Log.Write("SyMSet: Stopping loop")
			StopSyMLoop()
			Thread.Sleep(100) ' Extra safety gap before touching counters

			' Disconnect loop from form BEFORE closing it
			Skye.Common.Log.Write("SyMSet: Disconnecting form")
			Dim oldForm = FrmSyM
			FrmSyM = Nothing

			' Close old SyM form
			If oldForm IsNot Nothing Then
				Skye.Common.Log.Write("SyMSet: Closing old form")
				Try
					oldForm.Close()
				Catch ex As Exception
					Skye.Common.Log.Write("SyMSet: Error closing form: " & ex.Message)
				End Try
			Else
				Skye.Common.Log.Write("SyMSet: No old form to close")
			End If

			' Dispose counters
			Skye.Common.Log.Write("SyMSet: Disposing counters")
			Try
				DisposeSyMCounters()
			Catch ex As Exception
				Skye.Common.Log.Write("SyMSet: Error disposing counters: " & ex.Message)
			End Try

			Skye.Common.Log.Write("System Monitor UnLoaded")

			If forceterminate Then
				Skye.Common.Log.Write("SyMSet: forceterminate=True, exiting")
				Exit Sub
			End If

			' Recreate counters
			Skye.Common.Log.Write("SyMSet: Initializing counters")
			Try
				InitializeSyMCounters()
			Catch ex As Exception
				Skye.Common.Log.Write("SyMSet: Error initializing counters: " & ex.Message)
			End Try

			' Recreate SyM form
			Skye.Common.Log.Write("SyMSet: Creating new SyM form")
			Try
				FrmSyM = New SyM()
			Catch ex As Exception
				Skye.Common.Log.Write("SyMSet: Error creating new form: " & ex.Message)
			End Try

			Skye.Common.Log.Write("System Monitor Initialized")

		End Sub
		Private Sub InitializeSyMCounters()

			PerformanceCounter.CloseSharedResources()
			Thread.Sleep(100)

			SyMpcSystemUpTime = New PerformanceCounter("System", "System Up Time", True)
			SyMpcPagingFileUsage = New PerformanceCounter("Paging File", "% Usage", "_Total", True)
			SyMpcProcesses = New PerformanceCounter("System", "Processes", True)

			SyMpcProcessor = New PerformanceCounter("Processor Information", "% Processor Utility", "_Total", True)
			SyMpcProcessorSystem = New PerformanceCounter("Processor Information", "% Privileged Utility", "_Total", True)

			SyMpcMemoryPhysical = New PerformanceCounter("Memory", "Available Bytes", True)

			SyMpcDisk0 = New PerformanceCounter("PhysicalDisk", "% Disk Time", "0 C:", True)
			SyMpcDisk1 = New PerformanceCounter("PhysicalDisk", "% Disk Time", "1 D:", True)

			SyMpcNetworkDownload = New PerformanceCounter("Network Interface", "Bytes Received/sec", SyMNetworkInstance, True)
			SyMpcNetworkUpload = New PerformanceCounter("Network Interface", "Bytes Sent/sec", SyMNetworkInstance, True)

			SyMpcProcessProcessor = New PerformanceCounter("Process", "% Processor Time", SyMProcessInstance, True)
			SyMpcProcessMemoryPhysical = New PerformanceCounter("Process", "Working Set", SyMProcessInstance, True)
			SyMpcProcessThreads = New PerformanceCounter("Process", "Thread Count", SyMProcessInstance, True)
			SyMpcProcessHandles = New PerformanceCounter("Process", "Handle Count", SyMProcessInstance, True)
			SyMpcProcessPriority = New PerformanceCounter("Process", "Priority Base", SyMProcessInstance, True)
			SyMpcProcessTime = New PerformanceCounter("Process", "Elapsed Time", SyMProcessInstance, True)
			SyMpcProcessID = New PerformanceCounter("Process", "ID Process", SyMProcessInstance, True)

			' Warm-up calls
			Dim warmups() As PerformanceCounter = {
				SyMpcSystemUpTime,
				SyMpcPagingFileUsage,
				SyMpcProcesses,
				SyMpcProcessor,
				SyMpcProcessorSystem,
				SyMpcMemoryPhysical,
				SyMpcDisk0,
				SyMpcDisk1,
				SyMpcNetworkDownload,
				SyMpcNetworkUpload,
				SyMpcProcessProcessor,
				SyMpcProcessMemoryPhysical,
				SyMpcProcessThreads,
				SyMpcProcessHandles,
				SyMpcProcessPriority,
				SyMpcProcessTime,
				SyMpcProcessID
			}
			For Each pc In warmups
				Try : pc.NextValue() : Catch : End Try
			Next

		End Sub
		Private Sub DisposeSyMCounters()
			Dim counters() As PerformanceCounter = {
				SyMpcSystemUpTime,
				SyMpcPagingFileUsage,
				SyMpcProcesses,
				SyMpcProcessor,
				SyMpcProcessorSystem,
				SyMpcMemoryPhysical,
				SyMpcDisk0,
				SyMpcDisk1,
				SyMpcNetworkDownload,
				SyMpcNetworkUpload,
				SyMpcProcessProcessor,
				SyMpcProcessMemoryPhysical,
				SyMpcProcessThreads,
				SyMpcProcessHandles,
				SyMpcProcessPriority,
				SyMpcProcessTime,
				SyMpcProcessID
			}
			For Each pc In counters
				If pc IsNot Nothing Then
					Try : pc.Dispose() : Catch : End Try
				End If
			Next
		End Sub
		Friend Sub SyMSetLoop(Optional forceterminate As Boolean = False)
			If FrmSyM Is Nothing Then Exit Sub

			' If SyM is visible and loop is not running, start it
			If FrmSyM.Visible AndAlso ctsSyM Is Nothing AndAlso Not forceterminate Then
				StartSyMLoop()
				Skye.Common.Log.Write("System Monitor Loop ON")
			ElseIf ctsSyM IsNot Nothing Then ' If loop is running, stop it
				StopSyMLoop()
				Skye.Common.Log.Write("System Monitor Loop OFF")
			End If

		End Sub
		Private Sub StopSyMLoop()
			If ctsSyM IsNot Nothing Then
				Try
					ctsSyM.Cancel()
				Catch
				End Try
				Thread.Sleep(100) ' Wait to finish any running loop iterations to prevent conflicts when disposing counters and closing form
				Try
					ctsSyM.Dispose()
				Catch
				End Try
				ctsSyM = Nothing
			End If
		End Sub
		Private Function CollectSyMData() As SyMSnapshot
			Dim snap As New SyMSnapshot()

			Try : snap.SystemUpTime = CInt(SyMpcSystemUpTime.NextValue()) : Catch : snap.SystemUpTime = 0 : End Try

			' Processor
			Try : snap.ProcessorRaw = SyMpcProcessor.NextValue() : Catch : snap.ProcessorRaw = 0 : End Try
			Try : snap.ProcessorSystemRaw = SyMpcProcessorSystem.NextValue() : Catch : snap.ProcessorSystemRaw = 0 : End Try

			snap.Processor = CInt(Math.Min(100, snap.ProcessorRaw))
			snap.ProcessorSystem = CInt(Math.Min(100, snap.ProcessorSystemRaw))
			snap.ProcessorUserRaw = snap.ProcessorRaw - snap.ProcessorSystemRaw
			snap.ProcessorUser = Math.Max(0, CInt(snap.ProcessorUserRaw))

			' Processes
			Try : snap.Processes = CInt(SyMpcProcesses.NextValue()) : Catch : snap.Processes = 0 : End Try

			' Memory Physical
			Try : snap.MemoryPhysicalRaw = SyMpcMemoryPhysical.NextValue() : Catch : snap.MemoryPhysicalRaw = 0 : End Try
			snap.MemoryPhysicalMB = CInt(snap.MemoryPhysicalRaw / MBConversion)
			snap.MemoryPhysicalFreeRaw = SyMMemoryPhysicalMaximumRaw - snap.MemoryPhysicalRaw
			Try : snap.PagingFileUsage = CInt(SyMpcPagingFileUsage.NextValue()) : Catch : snap.PagingFileUsage = 0 : End Try

			' Disk 0
			Try : snap.Disk0Raw = SyMpcDisk0.NextValue() : Catch : snap.Disk0Raw = 0 : End Try
			snap.Disk0 = Math.Min(100, CInt(snap.Disk0Raw))

			' Disk 1
			Try : snap.Disk1Raw = SyMpcDisk1.NextValue() : Catch : snap.Disk1Raw = 0 : End Try
			snap.Disk1 = Math.Min(100, CInt(snap.Disk1Raw))

			' Network Download
			Try : snap.NetworkDownloadRaw = SyMpcNetworkDownload.NextValue() : Catch : snap.NetworkDownloadRaw = 0 : End Try
			snap.NetworkDownloadKB = CInt(snap.NetworkDownloadRaw / KBConversion)
			snap.NetworkDownloadKB = Math.Min(snap.NetworkDownloadKB, My.App.SyMNetworkDownloadMaximum)

			' Network Upload
			Try : snap.NetworkUploadRaw = SyMpcNetworkUpload.NextValue() : Catch : snap.NetworkUploadRaw = 0 : End Try
			snap.NetworkUploadKB = CInt(snap.NetworkUploadRaw / KBConversion)
			snap.NetworkUploadKB = Math.Min(snap.NetworkUploadKB, My.App.SyMNetworkUploadMaximum)

			' Instance (Process)
			Try : snap.ProcCPURaw = SyMpcProcessProcessor.NextValue() : Catch : snap.ProcCPURaw = 0 : End Try
			snap.ProcCPU = Math.Min(100, CInt(snap.ProcCPURaw))

			Try : snap.ProcID = CInt(SyMpcProcessID.NextValue()) : Catch : snap.ProcID = 0 : End Try
			Try : snap.ProcPriority = CInt(SyMpcProcessPriority.NextValue()) : Catch : snap.ProcPriority = 0 : End Try
			Try : snap.ProcTime = CInt(SyMpcProcessTime.NextValue()) : Catch : snap.ProcTime = 0 : End Try
			Try : snap.ProcThreads = CInt(SyMpcProcessThreads.NextValue()) : Catch : snap.ProcThreads = 0 : End Try
			Try : snap.ProcHandles = CInt(SyMpcProcessHandles.NextValue()) : Catch : snap.ProcHandles = 0 : End Try

			Try : snap.ProcMemRaw = SyMpcProcessMemoryPhysical.NextValue() : Catch : snap.ProcMemRaw = 0 : End Try
			snap.ProcMemMB = CInt(snap.ProcMemRaw / MBConversion)
			snap.ProcMemMB = Math.Min(snap.ProcMemMB, My.App.SyMMemoryPhysicalMaximum)

			Return snap
		End Function
        Private Sub ApplySyMData(snap As SyMSnapshot)

            FrmMain.ShowDataSystemUpTime(snap.SystemUpTime)

            ' Processor
            FrmSyM.ShowDataProcessor(snap.Processor, snap.ProcessorRaw, snap.ProcessorUser, snap.ProcessorUserRaw, snap.ProcessorSystem, snap.ProcessorSystemRaw)

			' Processes
			FrmSyM.ShowDataProcesses(snap.Processes)

            ' Memory
            FrmSyM.ShowDataMemoryPhysical(snap.MemoryPhysicalMB, snap.MemoryPhysicalRaw, snap.MemoryPhysicalFreeRaw)
			FrmSyM.ShowDataPagingFileUsage(snap.PagingFileUsage)

			' Disk
			FrmSyM.ShowDataDisk0(snap.Disk0, snap.Disk0Raw)
			FrmSyM.ShowDataDisk1(snap.Disk1, snap.Disk1Raw)

			' Network
			FrmSyM.ShowDataNetworkDownload(snap.NetworkDownloadKB, snap.NetworkDownloadRaw)
			FrmSyM.ShowDataNetworkUpload(snap.NetworkUploadKB, snap.NetworkUploadRaw)

			' Instance
			FrmSyM.ShowDataProcessProcessor(snap.ProcCPU, snap.ProcCPURaw)
			FrmSyM.ShowDataProcessID(snap.ProcID)
			FrmSyM.ShowDataProcessPriority(snap.ProcPriority)
			FrmSyM.ShowDataProcessTime(snap.ProcTime)
			FrmSyM.ShowDataProcessThreads(snap.ProcThreads)
			FrmSyM.ShowDataProcessHandles(snap.ProcHandles)
			FrmSyM.ShowDataProcessMemoryPhysical(snap.ProcMemMB, snap.ProcMemRaw)

		End Sub
		Friend Function SyMGetCounterDescription(counter As SyMCounters) As String
			Select Case counter
				Case SyMCounters.SystemUpTime : Return "System UpTime"
				Case SyMCounters.PagingFileUsage : Return "Paging File Utilization"
				Case SyMCounters.Processes : Return "# Of Processes"
				Case SyMCounters.Processor : Return "Processor Utilization"
				Case SyMCounters.ProcessorUser : Return "Processor Utilization (User)"
				Case SyMCounters.ProcessorSystem : Return "Processor Utilization (System)"
				Case SyMCounters.Memory : Return "Memory Utilization"
				Case SyMCounters.MemoryPhysical : Return "Physical Memory Utilization (" + My.App.SyMMemoryPhysicalMaximum.ToString + " MB MAX)"
				Case SyMCounters.MemoryPhysicalGB : Return "Physical Memory Utilization (" + (My.App.SyMMemoryPhysicalMaximumRaw / GBConversion).ToString("N2") + " GB MAX)"
				Case SyMCounters.MemoryPhysicalPercent : Return "Physical Memory Utilization"
				Case SyMCounters.Disk : Return "Disk Utilization"
				Case SyMCounters.Disk0 : Return "Disk Utilization For C:"
				Case SyMCounters.Disk1 : Return "Disk Utilization For D:"
				Case SyMCounters.Disk2 : Return "Disk Utilization For E:"
				Case SyMCounters.Disk3 : Return "Disk Utilization For F:"
				Case SyMCounters.Network : Return "Network Activity"
				Case SyMCounters.NetworkDownload : Return "Network Download Activity (" + My.App.SyMNetworkDownloadMaximum.ToString + " KB/sec MAX)"
				Case SyMCounters.NetworkUpload : Return "Network Upload Activity (" + My.App.SyMNetworkUploadMaximum.ToString + " KB/sec MAX)"
				Case SyMCounters.ProcessProcessor : Return "Processor Time"
				Case SyMCounters.ProcessMemoryPhysical : Return "Physical Memory Utilization (" + My.App.SyMMemoryPhysicalMaximum.ToString + " MB MAX)"
				Case SyMCounters.ProcessMemoryPhysicalPercent : Return "Physical Memory Relative Utilization"
				Case SyMCounters.ProcessThreads : Return "Threads"
				Case SyMCounters.ProcessHandles : Return "Handles"
				Case SyMCounters.ProcessPriority : Return "Priority"
				Case SyMCounters.ProcessTime : Return "RunTime"
				Case SyMCounters.ProcessID : Return "ID"
				Case Else : Return "< UnKnown Counter>"
			End Select
		End Function
		Friend Function SyMGetProcessPriority(data As Integer) As String
			Try : SyMGetProcessPriority = [Enum].GetName(GetType(My.App.SyMProcessPriority), data).ToString
			Catch : SyMGetProcessPriority = "UnKnown"
			End Try
		End Function
		Friend Function SyMGetNetworkInstanceNames() As String()
			Try
				Dim nicCat As New Diagnostics.PerformanceCounterCategory("Network Interface")
				Dim names = nicCat.GetInstanceNames()
				If names Is Nothing OrElse names.Length = 0 Then
					Return New String() {"< No Instances >"}
				End If

				Array.Sort(names)
				Return names

			Catch ex As Exception
				Return New String() {"< No Instances >"}
			End Try
		End Function
		Friend Function SyMGetProcessInstanceNames() As String()
			Try
				For Each pcc As Diagnostics.PerformanceCounterCategory In Diagnostics.PerformanceCounterCategory.GetCategories
					If pcc.CategoryName = "Process" Then
						SyMGetProcessInstanceNames = pcc.GetInstanceNames
						Array.Sort(SyMGetProcessInstanceNames)
						Exit Function
					End If
				Next
				SyMGetProcessInstanceNames = New String() {"< No Instances >"}
			Catch : SyMGetProcessInstanceNames = New String() {"< No Instances >"}
			End Try
		End Function

	End Module

	Public Class HotKeyWindow
		Inherits NativeWindow

		Public Event HotKeyPressed(id As Integer)

		Protected Overrides Sub WndProc(ByRef m As Message)
			If m.Msg = Skye.WinAPI.WM_HOTKEY Then
				RaiseEvent HotKeyPressed(m.WParam.ToInt32())
			End If
			MyBase.WndProc(m)
		End Sub
		Public Sub New()
			Dim cp As New CreateParams With {
				.Caption = "",
				.ClassName = Nothing,
				.Style = 0,
				.ExStyle = 0,
				.Parent = New IntPtr(-3)
			}
			CreateHandle(cp)
		End Sub

	End Class

End Namespace
