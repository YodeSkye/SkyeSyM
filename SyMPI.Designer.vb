<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SyMPI
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        TxtBoxSearch = New TextBox()
        ChkBoxShowSystem = New CheckBox()
        LBProcesses = New ListBox()
        SuspendLayout()
        ' 
        ' TxtBoxSearch
        ' 
        TxtBoxSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TxtBoxSearch.BorderStyle = BorderStyle.FixedSingle
        TxtBoxSearch.Location = New Point(9, 10)
        TxtBoxSearch.Margin = New Padding(4)
        TxtBoxSearch.Name = "TxtBoxSearch"
        TxtBoxSearch.PlaceholderText = "Search Processes"
        TxtBoxSearch.Size = New Size(368, 29)
        TxtBoxSearch.TabIndex = 0
        ' 
        ' ChkBoxShowSystem
        ' 
        ChkBoxShowSystem.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        ChkBoxShowSystem.AutoSize = True
        ChkBoxShowSystem.Location = New Point(9, 340)
        ChkBoxShowSystem.Margin = New Padding(4)
        ChkBoxShowSystem.Name = "ChkBoxShowSystem"
        ChkBoxShowSystem.Size = New Size(195, 25)
        ChkBoxShowSystem.TabIndex = 4
        ChkBoxShowSystem.Text = "Show System Processes"
        ChkBoxShowSystem.UseVisualStyleBackColor = True
        ' 
        ' LBProcesses
        ' 
        LBProcesses.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        LBProcesses.DrawMode = DrawMode.OwnerDrawFixed
        LBProcesses.FormattingEnabled = True
        LBProcesses.IntegralHeight = False
        LBProcesses.ItemHeight = 22
        LBProcesses.Location = New Point(9, 48)
        LBProcesses.Margin = New Padding(4)
        LBProcesses.Name = "LBProcesses"
        LBProcesses.Size = New Size(368, 284)
        LBProcesses.TabIndex = 2
        ' 
        ' SyMPI
        ' 
        AutoScaleDimensions = New SizeF(9F, 21F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(386, 371)
        ControlBox = False
        Controls.Add(LBProcesses)
        Controls.Add(ChkBoxShowSystem)
        Controls.Add(TxtBoxSearch)
        DoubleBuffered = True
        Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.None
        KeyPreview = True
        Margin = New Padding(4)
        MinimumSize = New Size(386, 371)
        Name = "SyMPI"
        Opacity = 0.98R
        Padding = New Padding(5, 6, 5, 6)
        ShowInTaskbar = False
        StartPosition = FormStartPosition.Manual
        TopMost = True
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TxtBoxSearch As TextBox
    Friend WithEvents ChkBoxShowSystem As CheckBox
    Friend WithEvents LBProcesses As ListBox
End Class
