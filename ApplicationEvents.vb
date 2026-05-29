
Namespace My

	Partial Friend Class MyApplication

		'App Declarations
		Friend CurrentProcess As Diagnostics.Process = Diagnostics.Process.GetCurrentProcess

		'App Events
		Public Sub New()
			MyBase.New(ApplicationServices.AuthenticationMode.Windows)
			CurrentProcess.PriorityClass = Diagnostics.ProcessPriorityClass.High
			Me.IsSingleInstance = True
			Me.EnableVisualStyles = True
			Me.SaveMySettingsOnExit = False
			Me.ShutdownStyle = ApplicationServices.ShutdownMode.AfterMainFormCloses
		End Sub
		Protected Overrides Function OnStartup(e As ApplicationServices.StartupEventArgs) As Boolean
			If e.Cancel Then : Return False
			Else
				My.App.Initialize()
				Return True
			End If
		End Function
		Protected Overrides Sub OnCreateMainForm()
			Me.MainForm = My.App.FrmMain
		End Sub

	End Class

End Namespace
