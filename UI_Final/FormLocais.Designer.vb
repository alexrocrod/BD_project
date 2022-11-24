<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLocais
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.bttnOK = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.bttnEdit = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bttnCancel = New System.Windows.Forms.Button()
        Me.bttnAdd = New System.Windows.Forms.Button()
        Me.txtNomeUniv = New System.Windows.Forms.TextBox()
        Me.txtEnd = New System.Windows.Forms.TextBox()
        Me.bttnDelete = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabCampus = New System.Windows.Forms.TabPage()
        Me.TabReit = New System.Windows.Forms.TabPage()
        Me.TabDep = New System.Windows.Forms.TabPage()
        Me.cBoxBar = New System.Windows.Forms.CheckBox()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtHorario = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabReit.SuspendLayout()
        Me.TabDep.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(841, 25)
        Me.MenuStrip1.TabIndex = 29
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(39, 21)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'LoadToolStripMenuItem
        '
        Me.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem"
        Me.LoadToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.LoadToolStripMenuItem.Text = "Refresh"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(117, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'bttnOK
        '
        Me.bttnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bttnOK.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.bttnOK.Location = New System.Drawing.Point(635, 402)
        Me.bttnOK.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.bttnOK.Name = "bttnOK"
        Me.bttnOK.Size = New System.Drawing.Size(112, 37)
        Me.bttnOK.TabIndex = 108
        Me.bttnOK.Text = "OK"
        Me.bttnOK.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 14
        Me.ListBox1.Location = New System.Drawing.Point(13, 28)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(385, 354)
        Me.ListBox1.Sorted = True
        Me.ListBox1.TabIndex = 107
        '
        'bttnEdit
        '
        Me.bttnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bttnEdit.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.bttnEdit.Location = New System.Drawing.Point(546, 402)
        Me.bttnEdit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.bttnEdit.Name = "bttnEdit"
        Me.bttnEdit.Size = New System.Drawing.Size(112, 37)
        Me.bttnEdit.TabIndex = 105
        Me.bttnEdit.Text = "Edit"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label6.Location = New System.Drawing.Point(8, 24)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 3, 4, 1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(134, 18)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "Nome Universidade"
        Me.Label6.UseCompatibleTextRendering = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(416, 80)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 1, 4, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 18)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Endereço"
        '
        'bttnCancel
        '
        Me.bttnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bttnCancel.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.bttnCancel.Location = New System.Drawing.Point(450, 402)
        Me.bttnCancel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.bttnCancel.Name = "bttnCancel"
        Me.bttnCancel.Size = New System.Drawing.Size(112, 37)
        Me.bttnCancel.TabIndex = 106
        Me.bttnCancel.Text = "Cancel"
        Me.bttnCancel.Visible = False
        '
        'bttnAdd
        '
        Me.bttnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bttnAdd.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.bttnAdd.Location = New System.Drawing.Point(401, 402)
        Me.bttnAdd.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.bttnAdd.Name = "bttnAdd"
        Me.bttnAdd.Size = New System.Drawing.Size(112, 37)
        Me.bttnAdd.TabIndex = 104
        Me.bttnAdd.Text = "Add"
        '
        'txtNomeUniv
        '
        Me.txtNomeUniv.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNomeUniv.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtNomeUniv.Location = New System.Drawing.Point(8, 44)
        Me.txtNomeUniv.Margin = New System.Windows.Forms.Padding(4, 1, 4, 3)
        Me.txtNomeUniv.Name = "txtNomeUniv"
        Me.txtNomeUniv.ReadOnly = True
        Me.txtNomeUniv.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtNomeUniv.Size = New System.Drawing.Size(355, 22)
        Me.txtNomeUniv.TabIndex = 99
        '
        'txtEnd
        '
        Me.txtEnd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtEnd.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtEnd.Location = New System.Drawing.Point(416, 104)
        Me.txtEnd.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtEnd.Name = "txtEnd"
        Me.txtEnd.ReadOnly = True
        Me.txtEnd.Size = New System.Drawing.Size(380, 22)
        Me.txtEnd.TabIndex = 87
        '
        'bttnDelete
        '
        Me.bttnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bttnDelete.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.bttnDelete.Location = New System.Drawing.Point(684, 402)
        Me.bttnDelete.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.bttnDelete.Name = "bttnDelete"
        Me.bttnDelete.Size = New System.Drawing.Size(112, 37)
        Me.bttnDelete.TabIndex = 111
        Me.bttnDelete.Text = "Delete"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label11.Location = New System.Drawing.Point(710, 33)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 1, 4, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 18)
        Me.Label11.TabIndex = 114
        Me.Label11.Text = "ID"
        '
        'txtID
        '
        Me.txtID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtID.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtID.Location = New System.Drawing.Point(704, 57)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(87, 22)
        Me.txtID.TabIndex = 115
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabCampus)
        Me.TabControl1.Controls.Add(Me.TabReit)
        Me.TabControl1.Controls.Add(Me.TabDep)
        Me.TabControl1.Location = New System.Drawing.Point(416, 141)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(378, 241)
        Me.TabControl1.TabIndex = 116
        '
        'TabCampus
        '
        Me.TabCampus.Location = New System.Drawing.Point(4, 24)
        Me.TabCampus.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabCampus.Name = "TabCampus"
        Me.TabCampus.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabCampus.Size = New System.Drawing.Size(370, 213)
        Me.TabCampus.TabIndex = 0
        Me.TabCampus.Text = "Campus"
        Me.TabCampus.UseVisualStyleBackColor = True
        '
        'TabReit
        '
        Me.TabReit.Controls.Add(Me.txtNomeUniv)
        Me.TabReit.Controls.Add(Me.Label6)
        Me.TabReit.Location = New System.Drawing.Point(4, 24)
        Me.TabReit.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabReit.Name = "TabReit"
        Me.TabReit.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabReit.Size = New System.Drawing.Size(370, 213)
        Me.TabReit.TabIndex = 1
        Me.TabReit.Text = "Reitoria"
        Me.TabReit.UseVisualStyleBackColor = True
        '
        'TabDep
        '
        Me.TabDep.Controls.Add(Me.cBoxBar)
        Me.TabDep.Controls.Add(Me.txtTel)
        Me.TabDep.Controls.Add(Me.Label13)
        Me.TabDep.Controls.Add(Me.txtHorario)
        Me.TabDep.Controls.Add(Me.Label14)
        Me.TabDep.Location = New System.Drawing.Point(4, 24)
        Me.TabDep.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabDep.Name = "TabDep"
        Me.TabDep.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TabDep.Size = New System.Drawing.Size(370, 213)
        Me.TabDep.TabIndex = 2
        Me.TabDep.Text = "Departamento"
        Me.TabDep.UseVisualStyleBackColor = True
        '
        'cBoxBar
        '
        Me.cBoxBar.AutoSize = True
        Me.cBoxBar.Enabled = False
        Me.cBoxBar.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.cBoxBar.Location = New System.Drawing.Point(10, 117)
        Me.cBoxBar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cBoxBar.Name = "cBoxBar"
        Me.cBoxBar.Size = New System.Drawing.Size(59, 25)
        Me.cBoxBar.TabIndex = 119
        Me.cBoxBar.Text = "?Bar"
        Me.cBoxBar.UseVisualStyleBackColor = True
        '
        'txtTel
        '
        Me.txtTel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtTel.Location = New System.Drawing.Point(10, 26)
        Me.txtTel.Margin = New System.Windows.Forms.Padding(4, 1, 4, 3)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.ReadOnly = True
        Me.txtTel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTel.Size = New System.Drawing.Size(181, 22)
        Me.txtTel.TabIndex = 117
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label13.Location = New System.Drawing.Point(4, 6)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 3, 4, 1)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 18)
        Me.Label13.TabIndex = 116
        Me.Label13.Text = "Telefone"
        '
        'txtHorario
        '
        Me.txtHorario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHorario.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtHorario.Location = New System.Drawing.Point(10, 77)
        Me.txtHorario.Margin = New System.Windows.Forms.Padding(4, 1, 4, 3)
        Me.txtHorario.Name = "txtHorario"
        Me.txtHorario.ReadOnly = True
        Me.txtHorario.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHorario.Size = New System.Drawing.Size(344, 22)
        Me.txtHorario.TabIndex = 115
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label14.Location = New System.Drawing.Point(4, 57)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 3, 4, 1)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 18)
        Me.Label14.TabIndex = 114
        Me.Label14.Text = "Horário"
        '
        'txtNome
        '
        Me.txtNome.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNome.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txtNome.Location = New System.Drawing.Point(416, 57)
        Me.txtNome.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.ReadOnly = True
        Me.txtNome.Size = New System.Drawing.Size(273, 22)
        Me.txtNome.TabIndex = 118
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(416, 33)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 1, 4, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 18)
        Me.Label2.TabIndex = 117
        Me.Label2.Text = "Nome"
        '
        'FormLocais
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(841, 475)
        Me.Controls.Add(Me.txtNome)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.bttnOK)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.bttnEdit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bttnCancel)
        Me.Controls.Add(Me.bttnAdd)
        Me.Controls.Add(Me.txtEnd)
        Me.Controls.Add(Me.bttnDelete)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "FormLocais"
        Me.Text = "Locais"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabReit.ResumeLayout(False)
        Me.TabReit.PerformLayout()
        Me.TabDep.ResumeLayout(False)
        Me.TabDep.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents LoadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents bttnOK As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents bttnEdit As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bttnCancel As System.Windows.Forms.Button
    Friend WithEvents bttnAdd As System.Windows.Forms.Button
    Friend WithEvents txtNomeUniv As System.Windows.Forms.TextBox
    Friend WithEvents txtEnd As System.Windows.Forms.TextBox
    Private WithEvents bttnDelete As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabCampus As TabPage
    Friend WithEvents TabReit As TabPage
    Friend WithEvents TabDep As TabPage
    Friend WithEvents txtTel As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtHorario As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtNome As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cBoxBar As CheckBox
End Class
