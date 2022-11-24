Imports System.Data.SqlClient

Public Class FormCursos
    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentCurso As Integer
    Dim adding As Boolean

    Private Sub BttnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnCancel.Click
        ListBox1.Enabled = True
        If ListBox1.Items.Count > 0 Then
            currentCurso = ListBox1.SelectedIndex
            If currentCurso < 0 Then currentCurso = 0
            ShowCurso()
        Else
            ClearFields()
            LockControls()
        End If
        ShowButtons()
    End Sub

    Private Sub BttnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnOK.Click
        Try
            SaveCurso()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ListBox1.Enabled = True
        Dim idx As Integer = ListBox1.FindString(txtCodigo.Text)
        ListBox1.SelectedIndex = idx
        ShowButtons()
    End Sub

    Private Sub BttnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnDelete.Click
        If ListBox1.SelectedIndex > -1 Then
            Try
                RemoveCurso(CType(ListBox1.SelectedItem, Curso).Codigo)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            If currentCurso = ListBox1.Items.Count Then currentCurso = ListBox1.Items.Count - 1
            If currentCurso = -1 Then
                ClearFields()
                MsgBox("Não há mais cursos")
            Else
                ShowCurso()
            End If
        End If
    End Sub

    Private Sub BttnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttnAdd.Click
        adding = True
        ClearFields()
        HideButtons()
        ListBox1.Enabled = False
    End Sub

    Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Not bttnOK.Visible Then
            e.Handled = True
        End If
    End Sub

    Private Function SaveCurso() As Boolean
        Dim C As New Curso
        Try
            C.CC_Dir = txtCC_Dir.Text
            C.Nome = txtNome.Text
            C.Codigo = txtCodigo.Text
            C.Tipo = cboxTipo.Text
            C.ID_Dep = txtID_Dep.Text
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        If adding Then
            SubmitCurso(C)
            ListBox1.Items.Add(C)
        Else
            UpdateCurso(C)
            ListBox1.Items(currentCurso) = C
        End If
        Return True
    End Function

    Private Sub BttnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnEdit.Click
        currentCurso = ListBox1.SelectedIndex
        If currentCurso < 0 Then
            MsgBox("Por favor selecione um curso para editar")
            Exit Sub
        End If
        adding = False
        HideButtons()
        ListBox1.Enabled = False
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            currentCurso = ListBox1.SelectedIndex
            ShowCurso()
        End If
    End Sub

    ' Helper routines
    Sub LockControls()
        txtCodigo.ReadOnly = True
        txtCC_Dir.ReadOnly = True
        txtNome.ReadOnly = True
        txtID_Dep.ReadOnly = True
    End Sub

    Sub UnlockControls()
        txtCodigo.ReadOnly = False
        txtCC_Dir.ReadOnly = False
        txtNome.ReadOnly = False
        txtID_Dep.ReadOnly = False
    End Sub

    Sub ShowButtons()
        LockControls()
        bttnAdd.Visible = True
        bttnDelete.Visible = True
        bttnEdit.Visible = True
        bttnOK.Visible = False
        bttnCancel.Visible = False
    End Sub

    Sub ClearFields()
        txtCodigo.Text = ""
        txtCC_Dir.Text = ""
        txtNome.Text = ""
        txtID_Dep.Text = ""
        cboxTipo.SelectedItem = ""
    End Sub

    Sub ShowCurso()
        If ListBox1.Items.Count = 0 Or currentCurso < 0 Then Exit Sub
        ClearFields()
        Try
            Dim C As New Curso
            C = CType(ListBox1.Items.Item(currentCurso), Curso)
            txtCC_Dir.Text = C.CC_Dir
            txtNome.Text = C.Nome
            txtCodigo.Text = C.Codigo
            cboxTipo.SelectedItem = C.Tipo
            txtID_Dep.Text = C.ID_Dep
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Sub HideButtons()
        UnlockControls()
        bttnAdd.Visible = False
        bttnDelete.Visible = False
        bttnEdit.Visible = False
        bttnOK.Visible = True
        bttnCancel.Visible = True
    End Sub

    Private Sub LoadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadToolStripMenuItem.Click
        ListBox1.Items.Clear()
        Dim RDR As SqlDataReader
        CMD.CommandText = "SELECT * FROM UNIV.Display_Curso"
        CN.Open()
        RDR = CMD.ExecuteReader
        While RDR.Read
            Dim C As New Curso With {
                .Nome = RDR.Item("Nome"),
                .Codigo = CInt(RDR.Item("Codigo")),
                .Tipo = RDR.Item("Tipo"),
                .CC_Dir = RDR.Item("CC_Diretor"),
                .ID_Dep = RDR.Item("ID_Dep")
            }
            ListBox1.Items.Add(C)
        End While
        CN.Close()
        currentCurso = 0
        ShowCurso()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CN = FormMain.CN

        CMD = New SqlCommand
        CMD.Connection = CN

        LoadToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub SubmitCurso(ByVal C As Curso)
        CMD.CommandText = "EXEC Univ.Insert_Curso @Code, @CC_Dir, @Nome, @Tipo, @ID_Dep"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Code", C.Codigo)
        CMD.Parameters.AddWithValue("@CC_Dir", C.CC_Dir)
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@Tipo", C.Tipo)
        CMD.Parameters.AddWithValue("@ID_Dep", C.ID_Dep)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel submeter o curso. " & vbCrLf & "Código tem de ser único." & vbCrLf & "CC tem de ser de um docente (não diretor) existente." & vbCrLf & "Departamento tem de existir")
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub UpdateCurso(ByVal C As Curso)
        CMD.CommandText = "EXEC Univ.Update_Curso @Code, @CC_Dir, @Nome, @Tipo, @ID_Dep"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Code", C.Codigo)
        CMD.Parameters.AddWithValue("@CC_Dir", C.CC_Dir)
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@ID_Dep", C.ID_Dep)
        CMD.Parameters.AddWithValue("@Tipo", C.Tipo)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel editar o curso. " & vbCrLf & "Código não pode ser alterado." & vbCrLf & "CC tem de ser de um docente (não diretor) existente." & vbCrLf & "Departamento tem de existir")
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub RemoveCurso(ByVal Code As String)
        CMD.CommandText = "DELETE FROM Univ.Curso WHERE Codigo=@Code "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Code", Code)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel eliminar o curso.")
        Finally
            CN.Close()
        End Try
    End Sub

End Class
