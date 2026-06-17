
Imports SkyeSyM.My

Partial Friend Class Help

	' Declarations
	Private dialogSaveAs As New System.Windows.Forms.SaveFileDialog
	Private mMove As Boolean = False
	Private mOffset, mPosition As Point

	' Form Events
	Friend Sub New()
		' Initialize Globals
		' Initialize Locals
		dialogSaveAs.DefaultExt = "txt"
		dialogSaveAs.Filter = "Text Files|*.txt"
		dialogSaveAs.RestoreDirectory = True
		dialogSaveAs.Title = "Save Message ..."
		' Initialize Form
		InitializeComponent()
		Skye.UI.ThemeManager.ApplyTheme(Me)
	End Sub
	Private Sub FrmPreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs) Handles btnClose.PreviewKeyDown
		Select Case e.KeyData
			Case Keys.Escape : Me.Close()
			Case Keys.S Or Keys.Control : SaveAs()
		End Select
	End Sub
	Private Sub FrmMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
		If e.Button = MouseButtons.Left And Me.WindowState = FormWindowState.Normal Then
			mMove = True
			mOffset = New Point(-e.X - SystemInformation.FrameBorderSize.Width * 2, -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height * 2)
		End If
	End Sub
	Private Sub FrmMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove
		If mMove Then
			mPosition = Control.MousePosition
			mPosition.Offset(mOffset.X, mOffset.Y)
			CheckMove(mPosition)
			Location = mPosition
		End If
	End Sub
	Private Sub FrmMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseUp
		mMove = False
	End Sub
	Private Sub FrmMove(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Move
		If Not mMove AndAlso Me.WindowState = FormWindowState.Normal Then CheckMove(Me.Location)
	End Sub
	Private Sub FrmDoubleClick(ByVal sender As Object, ByVal e As EventArgs)
		ChangeWindowState()
	End Sub

	' Control Events
	Private Sub TextPreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs) Handles tbPostMessage.PreviewKeyDown, rtbMessage.PreviewKeyDown
		Dim senderTXBX As TextBoxBase = CType(sender, TextBoxBase)
		Select Case e.KeyData
			Case Keys.Escape : Me.Close()
			Case Keys.C Or Keys.Control : If senderTXBX.SelectionLength > 0 Then senderTXBX.Copy()
			Case Keys.A Or Keys.Control : senderTXBX.SelectAll()
			Case Keys.S Or Keys.Control : SaveAs()
		End Select
	End Sub
	Private Sub ContextmenuRTBOpening(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles contextmenuRTB.Opening
		Dim sendersourcecontrolname As String = CType(sender, ContextMenuStrip).SourceControl.Name
		Me.cmiCopy.Tag = sendersourcecontrolname
		Me.cmiSelectAll.Tag = sendersourcecontrolname
		Me.cmiCopy.Enabled = True
		Select Case sendersourcecontrolname
			Case Me.rtbMessage.Name : If Me.rtbMessage.SelectionLength = 0 Then Me.cmiCopy.Enabled = False
			Case Me.tbPostMessage.Name : If Me.tbPostMessage.SelectionLength = 0 Then Me.cmiCopy.Enabled = False
		End Select
	End Sub
	Private Sub CMICopyMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles cmiCopy.MouseUp
		If e.Button = MouseButtons.Left Then
			Select Case CType(sender, ToolStripMenuItem).Tag.ToString
				Case Me.rtbMessage.Name : Me.rtbMessage.Copy()
				Case Me.tbPostMessage.Name : Me.tbPostMessage.Copy()
			End Select
		End If
	End Sub
	Private Sub CMISelectAllMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles cmiSelectAll.MouseUp
		If e.Button = MouseButtons.Left Then
			Select Case CType(sender, ToolStripMenuItem).Tag.ToString
				Case Me.rtbMessage.Name : Me.rtbMessage.SelectAll()
				Case Me.tbPostMessage.Name : Me.tbPostMessage.SelectAll()
			End Select
		End If
	End Sub
	Private Sub CMISaveAsMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles cmiSaveAs.MouseUp
		If e.Button = MouseButtons.Left Then SaveAs()
	End Sub
	Private Sub BtnEnter(ByVal sender As Object, ByVal e As EventArgs)
		btnClose.Focus()
	End Sub
	Private Sub BtnCloseClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnClose.Click
		Me.Close()
	End Sub

	' Procedures
	Friend Sub ChangeWindowState()
		Select Case Me.WindowState
			Case FormWindowState.Normal : Me.WindowState = FormWindowState.Maximized
			Case FormWindowState.Maximized : Me.WindowState = FormWindowState.Normal
		End Select
		Me.rtbMessage.Focus()
	End Sub
	Private Sub SaveAs()
		Dim r As DialogResult = Me.dialogSaveAs.ShowDialog(Me)
		If r = DialogResult.OK Then
			IO.File.AppendAllText(Me.dialogSaveAs.FileName, Me.Text + Chr(13) + Chr(13) + Me.rtbMessage.Text + Chr(13) + Chr(13) + Me.tbPostMessage.Text)
		End If
	End Sub
	Private Sub CheckMove(ByRef location As Point)
		Dim screen = System.Windows.Forms.Screen.FromControl(Me).WorkingArea
		If location.X + Width > screen.Right Then location.X = screen.Right - Width + App.AdjustScreenBoundsNormalWindow
		If location.Y + Height > screen.Bottom Then location.Y = screen.Bottom - Height + App.AdjustScreenBoundsNormalWindow
		If location.X < screen.Left Then location.X = screen.Left - App.AdjustScreenBoundsNormalWindow
		If location.Y < screen.Top Then location.Y = screen.Top
	End Sub

End Class
