<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Me.bttnCursos = New System.Windows.Forms.Button()
        Me.bttnLocais = New System.Windows.Forms.Button()
        Me.bttnPessoas = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'bttnCursos
        '
        Me.bttnCursos.Location = New System.Drawing.Point(16, 202)
        Me.bttnCursos.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.bttnCursos.Name = "bttnCursos"
        Me.bttnCursos.Size = New System.Drawing.Size(226, 92)
        Me.bttnCursos.TabIndex = 1
        Me.bttnCursos.Text = "Cursos"
        Me.bttnCursos.UseVisualStyleBackColor = True
        '
        'bttnLocais
        '
        Me.bttnLocais.Location = New System.Drawing.Point(16, 106)
        Me.bttnLocais.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.bttnLocais.Name = "bttnLocais"
        Me.bttnLocais.Size = New System.Drawing.Size(226, 92)
        Me.bttnLocais.TabIndex = 2
        Me.bttnLocais.Text = "Locais"
        Me.bttnLocais.UseVisualStyleBackColor = True
        '
        'bttnPessoas
        '
        Me.bttnPessoas.Location = New System.Drawing.Point(16, 9)
        Me.bttnPessoas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.bttnPessoas.Name = "bttnPessoas"
        Me.bttnPessoas.Size = New System.Drawing.Size(226, 92)
        Me.bttnPessoas.TabIndex = 3
        Me.bttnPessoas.Text = "Pessoas"
        Me.bttnPessoas.UseVisualStyleBackColor = True
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(256, 308)
        Me.Controls.Add(Me.bttnPessoas)
        Me.Controls.Add(Me.bttnLocais)
        Me.Controls.Add(Me.bttnCursos)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "FormMain"
        Me.Text = "BD Universidade"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents bttnCursos As Button
    Friend WithEvents bttnLocais As Button
    Friend WithEvents bttnPessoas As Button
End Class
