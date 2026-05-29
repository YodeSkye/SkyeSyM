Friend Partial Class Help
Inherits System.Windows.Forms.Form
	Private components As System.ComponentModel.IContainer
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
    Private Sub InitializeComponent
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Help))
        rtbMessage = New RichTextBox()
        contextmenuRTB = New ContextMenuStrip(components)
        cmiCopy = New ToolStripMenuItem()
        cmiSelectAll = New ToolStripMenuItem()
        toolStripSeparator1 = New ToolStripSeparator()
        cmiSaveAs = New ToolStripMenuItem()
        btnClose = New Button()
        tbPostMessage = New TextBox()
        contextmenuRTB.SuspendLayout()
        SuspendLayout()
        ' 
        ' rtbMessage
        ' 
        rtbMessage.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        rtbMessage.AutoWordSelection = True
        rtbMessage.BorderStyle = BorderStyle.None
        rtbMessage.ContextMenuStrip = contextmenuRTB
        rtbMessage.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rtbMessage.HideSelection = False
        rtbMessage.Location = New Point(0, 0)
        rtbMessage.Margin = New Padding(0)
        rtbMessage.Name = "rtbMessage"
        rtbMessage.ReadOnly = True
        rtbMessage.ShortcutsEnabled = False
        rtbMessage.ShowSelectionMargin = True
        rtbMessage.Size = New Size(584, 288)
        rtbMessage.TabIndex = 0
        rtbMessage.Text = "MESSAGE"
        ' 
        ' contextmenuRTB
        ' 
        contextmenuRTB.Items.AddRange(New ToolStripItem() {cmiCopy, cmiSelectAll, toolStripSeparator1, cmiSaveAs})
        contextmenuRTB.Name = "contextmenuRTB"
        contextmenuRTB.Size = New Size(165, 76)
        ' 
        ' cmiCopy
        ' 
        cmiCopy.Image = My.Resources.Resources.imageCopy
        cmiCopy.Name = "cmiCopy"
        cmiCopy.ShortcutKeys = Keys.Control Or Keys.C
        cmiCopy.Size = New Size(164, 22)
        cmiCopy.Text = "Copy"
        ' 
        ' cmiSelectAll
        ' 
        cmiSelectAll.Image = My.Resources.Resources.imageSelectAll
        cmiSelectAll.Name = "cmiSelectAll"
        cmiSelectAll.ShortcutKeys = Keys.Control Or Keys.A
        cmiSelectAll.Size = New Size(164, 22)
        cmiSelectAll.Text = "Select All"
        ' 
        ' toolStripSeparator1
        ' 
        toolStripSeparator1.Name = "toolStripSeparator1"
        toolStripSeparator1.Size = New Size(161, 6)
        ' 
        ' cmiSaveAs
        ' 
        cmiSaveAs.Image = My.Resources.Resources.imageSave
        cmiSaveAs.Name = "cmiSaveAs"
        cmiSaveAs.ShortcutKeys = Keys.Control Or Keys.S
        cmiSaveAs.Size = New Size(164, 22)
        cmiSaveAs.Text = "Save As"
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Bottom
        btnClose.Font = New Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnClose.ForeColor = Color.Navy
        btnClose.Image = My.Resources.Resources.ImageOK
        btnClose.Location = New Point(258, 326)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(64, 64)
        btnClose.TabIndex = 1
        btnClose.TextAlign = ContentAlignment.MiddleRight
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' tbPostMessage
        ' 
        tbPostMessage.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        tbPostMessage.BorderStyle = BorderStyle.None
        tbPostMessage.ContextMenuStrip = contextmenuRTB
        tbPostMessage.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        tbPostMessage.Location = New Point(11, 300)
        tbPostMessage.Name = "tbPostMessage"
        tbPostMessage.ReadOnly = True
        tbPostMessage.ShortcutsEnabled = False
        tbPostMessage.Size = New Size(560, 18)
        tbPostMessage.TabIndex = 0
        tbPostMessage.TabStop = False
        tbPostMessage.Text = "POSTMESSAGE"
        tbPostMessage.TextAlign = HorizontalAlignment.Center
        ' 
        ' Help
        ' 
        AutoScaleMode = AutoScaleMode.None
        AutoValidate = AutoValidate.Disable
        ClientSize = New Size(584, 402)
        Controls.Add(rtbMessage)
        Controls.Add(btnClose)
        Controls.Add(tbPostMessage)
        Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        KeyPreview = True
        MinimumSize = New Size(450, 300)
        Name = "Help"
        SizeGripStyle = SizeGripStyle.Show
        StartPosition = FormStartPosition.CenterScreen
        Text = "Help & About"
        contextmenuRTB.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Private toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents cmiSaveAs As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiSelectAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents cmiCopy As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents contextmenuRTB As System.Windows.Forms.ContextMenuStrip
    Public WithEvents tbPostMessage As System.Windows.Forms.TextBox
    Public WithEvents btnClose As System.Windows.Forms.Button
    Public WithEvents rtbMessage As System.Windows.Forms.RichTextBox
End Class