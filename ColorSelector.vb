
Partial Friend Class ColorSelector

	'Form Events
	Friend Sub New()
		InitializeComponent()
		Skye.UI.ThemeManager.ApplyTheme(Me)
	End Sub

	'Control Events
	Private Sub CombobxColor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combobxColor.SelectedIndexChanged
		If Me.Visible Then
			Me.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.Close()
		End If
	End Sub

End Class
