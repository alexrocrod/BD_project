Imports System.Data.SqlClient

Public Class FormLocais

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentLocal As Integer
    Dim adding As Boolean

    Private Sub BttnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnCancel.Click
        ListBox1.Enabled = True
        If ListBox1.Items.Count > 0 Then
            currentLocal = ListBox1.SelectedIndex
            If currentLocal < 0 Then currentLocal = 0
            ShowLocal()
        Else
            ClearFields()
            LockControls()
        End If
        ShowButtons()
    End Sub

    Private Sub BttnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnOK.Click
        Dim local_type As Integer
        If TabControl1.SelectedTab.Text = "Campus" Then
            local_type = 0
        End If
        If TabControl1.SelectedTab.Text = "Reitoria" Then
            local_type = 1
        End If
        If TabControl1.SelectedTab.Text = "Departamento" Then
            local_type = 2
        End If
        Try
            SaveLocal(local_type)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ListBox1.Enabled = True
        Dim idx As Integer = ListBox1.FindString(txtID.Text)
        ListBox1.SelectedIndex = idx
        ShowButtons()
    End Sub

    Private Sub BttnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnDelete.Click
        If ListBox1.SelectedIndex > -1 Then
            If TabControl1.SelectedTab.Text = "Campus" Then
                Try
                    RemoveCampus(CType(ListBox1.SelectedItem, Campus).ID)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
            If TabControl1.SelectedTab.Text = "Reitoria" Then
                Try
                    RemoveReitoria(CType(ListBox1.SelectedItem, Reitoria).ID)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
            If TabControl1.SelectedTab.Text = "Departamento" Then
                Try
                    RemoveDepartamento(CType(ListBox1.SelectedItem, Departamento).ID)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            If currentLocal = ListBox1.Items.Count Then currentLocal = ListBox1.Items.Count - 1
            If currentLocal = -1 Then
                ClearFields()
                MsgBox("Não há mais locais")
            Else
                ShowLocal()
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

    Private Function SaveLocal(ByVal local_type As Integer) As Boolean
        If local_type = 0 Then
            Dim camp As New Campus
            Try
                camp.Endereco = txtEnd.Text
                camp.Nome = txtNome.Text
                camp.ID = txtID.Text
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
            If adding Then
                SubmitCampus(camp)
                ListBox1.Items.Add(camp)
            Else
                UpdateCampus(camp)
                ListBox1.Items(currentLocal) = camp
            End If
            Return True
        End If
        If local_type = 1 Then
            Dim reit As New Reitoria
            Try
                reit.Endereco = txtEnd.Text
                reit.Nome = txtNome.Text
                reit.ID = txtID.Text
                reit.Univ = txtNomeUniv.Text
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
            If adding Then
                SubmitReitoria(reit)
                ListBox1.Items.Add(reit)
            Else
                UpdateReitoria(reit)
                ListBox1.Items(currentLocal) = reit
            End If
            Return True
        End If
        If local_type = 2 Then
            Dim dep As New Departamento
            Try
                dep.Endereco = txtEnd.Text
                dep.Nome = txtNome.Text
                dep.ID = txtID.Text
                dep.Telefone = txtTel.Text
                dep.Horario = txtHorario.Text
                dep.Bar = cBoxBar.Checked
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
            If adding Then
                SubmitDep(dep)
                ListBox1.Items.Add(dep)
            Else
                UpdateDep(dep)
                ListBox1.Items(currentLocal) = dep
            End If
            Return True
        End If
        Return True

    End Function

    Private Sub BttnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnEdit.Click
        currentLocal = ListBox1.SelectedIndex
        If currentLocal < 0 Then
            MsgBox("Por favor selecione um local para editar.")
            Exit Sub
        End If
        adding = False
        HideButtons()
        ListBox1.Enabled = False
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            currentLocal = ListBox1.SelectedIndex
            ShowLocal()
        End If
    End Sub

    Sub LockControls()
        txtID.ReadOnly = True
        txtEnd.ReadOnly = True
        txtNome.ReadOnly = True
        txtHorario.ReadOnly = True
        txtNomeUniv.ReadOnly = True
        txtTel.ReadOnly = True
        cBoxBar.Enabled = False
    End Sub

    Sub UnlockControls()
        txtID.ReadOnly = False
        txtEnd.ReadOnly = False
        txtNome.ReadOnly = False
        txtHorario.ReadOnly = False
        txtNomeUniv.ReadOnly = False
        txtTel.ReadOnly = False
        cBoxBar.Enabled = True
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
        txtID.Text = ""
        txtEnd.Text = ""
        txtNome.Text = ""
        txtHorario.Text = ""
        txtNomeUniv.Text = ""
        txtTel.Text = ""
        cBoxBar.Checked = False
    End Sub

    Sub ShowLocal()
        If ListBox1.Items.Count = 0 Or currentLocal < 0 Then Exit Sub
        ClearFields()
        Try
            ' Campus
            Dim campus As New Campus
            campus = CType(ListBox1.Items.Item(currentLocal), Campus)
            txtEnd.Text = campus.Endereco
            txtNome.Text = campus.Nome
            txtID.Text = campus.ID
            TabControl1.SelectTab(0)
        Catch ex As Exception
            Try
                ' Reitoria
                Dim reit As New Reitoria
                reit = CType(ListBox1.Items.Item(currentLocal), Reitoria)
                txtEnd.Text = reit.Endereco
                txtNome.Text = reit.Nome
                txtID.Text = reit.ID
                txtNomeUniv.Text = reit.Univ
                TabControl1.SelectTab(1)
            Catch ex1 As Exception
                Try
                    ' Departamento
                    Dim dep As New Departamento
                    dep = CType(ListBox1.Items.Item(currentLocal), Departamento)
                    txtEnd.Text = dep.Endereco
                    txtNome.Text = dep.Nome
                    txtID.Text = dep.ID
                    txtTel.Text = dep.Telefone
                    txtHorario.Text = dep.Horario
                    cBoxBar.Checked = dep.Bar
                    TabControl1.SelectTab(2)
                Catch ex2 As Exception
                    MsgBox("Erro ao imprimir os dados do local.")
                    Exit Sub
                End Try
            End Try
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
        '' Campus
        CMD.CommandText = "SELECT * FROM UNIV.Display_Campus"
        CN.Open()
        RDR = CMD.ExecuteReader
        While RDR.Read
            Dim C As New Campus With {
                .Nome = RDR.Item("Nome"),
                .ID = RDR.Item("ID"),
                .Endereco = RDR.Item("Endereço")
            }
            ListBox1.Items.Add(C)
        End While
        CN.Close()
        '' Reitoria
        CMD.CommandText = "SELECT * FROM UNIV.Display_Reit"
        CN.Open()
        RDR = CMD.ExecuteReader
        While RDR.Read
            Dim C As New Reitoria With {
                .Nome = RDR.Item("Nome"),
                .ID = RDR.Item("ID"),
                .Endereco = RDR.Item("Endereço"),
                .Univ = RDR.Item("Nome_univ")
            }
            ListBox1.Items.Add(C)
        End While
        CN.Close()
        '' Departamento
        CMD.CommandText = "SELECT * FROM UNIV.Display_Dep"
        CN.Open()
        RDR = CMD.ExecuteReader
        While RDR.Read
            Dim C As New Departamento With {
                .Nome = RDR.Item("Nome"),
                .ID = RDR.Item("ID"),
                .Endereco = RDR.Item("Endereço"),
                .Telefone = RDR.Item("Telefone"),
                .Horario = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Horario")), "", RDR.Item("Horario"))),
                .Bar = RDR.GetBoolean("Bar")
            }
            ListBox1.Items.Add(C)
        End While
        CN.Close()
        currentLocal = 0
        ShowLocal()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CN = FormMain.CN
        CMD = New SqlCommand
        CMD.Connection = CN

        LoadToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub SubmitCampus(ByVal C As Campus)
        CMD.CommandText = "EXEC Univ.Insert_Campus @ID, @Endereco, @Nome"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@ID", C.ID)
        CMD.Parameters.AddWithValue("@Endereco", C.Endereco)
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel submeter o campus." & vbCrLf & "ID e Nome tem de ser únicos.")
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub SubmitReitoria(ByVal C As Reitoria)
        CMD.CommandText = "EXEC Univ.Insert_Reit @ID, @Endereco, @Nome, @Nome_Univ"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@ID", C.ID)
        CMD.Parameters.AddWithValue("@Endereco", C.Endereco)
        CMD.Parameters.AddWithValue("@Nome_Univ", C.Univ)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel submeter a reitoria." & vbCrLf & "ID e Nome tem de ser únicos.")
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub SubmitDep(ByVal C As Departamento)
        CMD.CommandText = "EXEC Univ.Insert_Dep @ID, @Endereco, @Nome, @Telefone, @Horario, @Bar"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Endereco", C.Endereco)
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@ID", C.ID)
        If C.Bar = True Then
            CMD.Parameters.AddWithValue("@Bar", 1)
        Else
            CMD.Parameters.AddWithValue("@Bar", 0)
        End If
        CMD.Parameters.AddWithValue("@Telefone", C.Telefone)
        If C.Horario <> "" Then
            CMD.Parameters.AddWithValue("@Horario", C.Horario)
        Else
            CMD.Parameters.AddWithValue("@Horario", DBNull.Value)
        End If
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel submeter o departamento." & vbCrLf & "ID e Nome tem de ser únicos.")
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub UpdateCampus(ByVal C As Campus)
        CMD.CommandText = "EXEC Univ.Update_Campus @ID, @Endereco, @Nome"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@ID", C.ID)
        CMD.Parameters.AddWithValue("@Endereco", C.Endereco)
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel editar o campus." & vbCrLf & "ID e Nome tem de ser únicos.")
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub UpdateReitoria(ByVal C As Reitoria)
        CMD.CommandText = "EXEC Univ.Update_Reit @ID, @Endereco, @Nome, @Nome_Univ"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@ID", C.ID)
        CMD.Parameters.AddWithValue("@Endereco", C.Endereco)
        CMD.Parameters.AddWithValue("@Nome_Univ", C.Univ)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel editar a reitoria." & vbCrLf & "ID e Nome tem de ser únicos.")
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub UpdateDep(ByVal C As Departamento)
        CMD.CommandText = "EXEC Univ.Update_Dep @ID, @Endereco, @Nome, @Telefone, @Horario, @Bar"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Endereco", C.Endereco)
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@ID", C.ID)
        If C.Bar = True Then
            CMD.Parameters.AddWithValue("@Bar", 1)
        Else
            CMD.Parameters.AddWithValue("@Bar", 0)
        End If
        CMD.Parameters.AddWithValue("@Telefone", C.Telefone)
        If C.Horario <> "" Then
            CMD.Parameters.AddWithValue("@Horario", C.Horario)
        Else
            CMD.Parameters.AddWithValue("@Horario", DBNull.Value)
        End If
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel editar o departamento." & vbCrLf & "ID e Nome tem de ser únicos.")
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub RemoveCampus(ByVal ID As String)
        CMD.CommandText = "DELETE Univ.Campus WHERE ID=@ID "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@ID", ID)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel remover o campus.")
        Finally
            CN.Close()
        End Try
    End Sub

    Private Sub RemoveReitoria(ByVal ID As String)
        CMD.CommandText = "DELETE Univ.Reitoria WHERE ID=@ID "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@ID", ID)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel remover a reitoria.")
        Finally
            CN.Close()
        End Try

    End Sub

    Private Sub RemoveDepartamento(ByVal ID As String)
        CMD.CommandText = "DELETE Univ.Departamento WHERE ID=@ID "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@ID", ID)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel remover o departamento.")
        Finally
            CN.Close()
        End Try
    End Sub

End Class
