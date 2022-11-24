Imports System.Data.SqlClient

Public Class Form1

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentPessoa As Integer
    Dim currentCurso As Integer
    Dim adding As Boolean

    Private Sub BttnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnCancel.Click
        ListBox1.Enabled = True
        ListBox2.Enabled = True
        If ListBox1.Items.Count > 0 Then
            currentPessoa = ListBox1.SelectedIndex
            If currentPessoa < 0 Then currentPessoa = 0
            ShowContact()
        Else
            ClearFields()
            LockControls()
        End If
        ShowButtons()
    End Sub

    Private Sub BttnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnOK.Click
        Dim pessoa_type As Integer
        If TabControl1.SelectedTab.Text = "Funcionário" Then
            pessoa_type = 0
        End If
        If TabControl1.SelectedTab.Text = "Docente" Then
            pessoa_type = 1
        End If
        If TabControl1.SelectedTab.Text = "Investigador" Then
            pessoa_type = 2
        End If
        If TabControl1.SelectedTab.Text = "Aluno" Then
            pessoa_type = 3
        End If
        Try
            SavePessoa(pessoa_type)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ListBox1.Enabled = True
        ListBox2.Enabled = True
        Dim idx As Integer = ListBox1.FindString(txtCC.Text)
        ListBox1.SelectedIndex = idx
        ShowButtons()
    End Sub

    Private Sub BttnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnDelete.Click
        If ListBox1.SelectedIndex > -1 Then
            If TabControl1.SelectedTab.Text = "Funcionário" Then
                Try
                    RemoveFunc(CType(ListBox1.SelectedItem, Funcionario).CC)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
            If TabControl1.SelectedTab.Text = "Docente" Then
                Try
                    RemoveDocente(CType(ListBox1.SelectedItem, Docente).CC)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
            If TabControl1.SelectedTab.Text = "Investigador" Then
                Try
                    RemoveInv(CType(ListBox1.SelectedItem, Investigador).CC)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
            If TabControl1.SelectedTab.Text = "Aluno" Then
                Try
                    RemoveAluno(CType(ListBox1.SelectedItem, Aluno).CC)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            If currentPessoa = ListBox1.Items.Count Then currentPessoa = ListBox1.Items.Count - 1
            If currentPessoa = -1 Then
                ClearFields()
                MsgBox("Não há mais pessoas")
            Else
                ShowContact()
            End If
        End If
    End Sub

    Private Sub BttnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttnAdd.Click
        adding = True
        ListBox2.Items.Clear()
        ClearFields()
        HideButtons()
        ListBox1.Enabled = False
    End Sub

    Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Not bttnOK.Visible Then
            e.Handled = True
        End If
    End Sub

    Private Function SavePessoa(ByVal pessoa_type As Integer) As Boolean
        If pessoa_type = 0 Then
            Dim func As New Funcionario
            Try
                func.NIF = txtNIF.Text
                func.CC = txtCC.Text
                func.Nome = txtNome.Text
                func.Numero = txtNumFunc.Text
                func.Funcao = txtFuncao.Text
                func.ID_Trab = txtID_Trab.Text
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
            If adding Then
                SubmitFuncionario(func)
            Else
                UpdateFunc(func)
            End If
            ShowContact()
            Return True
        End If
        If pessoa_type = 1 Then
            Dim doc As New Docente
            Try
                doc.NIF = txtNIF.Text
                doc.Nome = txtNome.Text
                doc.CC = txtCC.Text
                doc.Telefone = txtTel_Doc.Text
                doc.ID_Dep = txtID_Dep_Doc.Text
                doc.Ref_Proj = txtRef_Proj_Doc.Text
                doc.Cod_Curso = txtCodCurso.Text
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
            If adding Then
                SubmitDocente(doc)
            Else
                UpdateDocente(doc)
            End If
            ShowContact()
            Return True
        End If
        If pessoa_type = 2 Then
            Dim inv As New Investigador
            Try
                inv.NIF = txtNIF.Text
                inv.Nome = txtNome.Text
                inv.CC = txtCC.Text
                inv.Telefone = txtTel_Inv.Text
                inv.ID_Dep = txtID_Dep_Inv.Text
                inv.Ref_Proj = txt_Ref_Proj_Inv.Text
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
            If adding Then
                SubmitInv(inv)
                ListBox1.Items.Add(inv)
            Else
                UpdateInv(inv)
                ListBox1.Items(currentPessoa) = inv
            End If
            ShowContact()
            Return True
        End If
        If pessoa_type = 3 Then
            Dim aluno As New Aluno
            Dim curso As New Curso_Aluno
            Try
                aluno.NIF = txtNIF.Text
                aluno.Nome = txtNome.Text
                aluno.CC = txtCC.Text
                aluno.Numero = txtNum_Aluno.Text
                aluno.N_Matri = txtNMatri.Text
                aluno.Ref_Proj = txtRef_Proj_Aluno.Text
                aluno.Ano = txtAno_Aluno.Text
                If adding Then
                    curso.Numero = txtNum_Aluno.Text
                    curso.Cod_Curso = txtFreqCod.Text
                    curso.DataI = txtFreqI.Text
                    curso.DataE = txtFreqE.Text
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
            If adding Then
                SubmitAluno(aluno, curso)
                ListBox1.Items.Add(aluno)
                ListBox2.Items.Add(curso)
            Else
                UpdateAluno(aluno)
                ListBox1.Items(currentPessoa) = aluno
            End If
            ShowContact()
            Return True
        End If

        Return True

    End Function

    Private Sub BttnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttnEdit.Click
        currentPessoa = ListBox1.SelectedIndex
        If currentPessoa < 0 Then
            MsgBox("Por favor selecione uma pessoa para editar.")
            Exit Sub
        End If
        adding = False
        HideButtons()
        ListBox1.Enabled = False
        ListBox2.Enabled = False
        txtCC.ReadOnly = True
        txtNIF.ReadOnly = True
        txtFreqI.ReadOnly = True
        txtFreqE.ReadOnly = True
        txtFreqCod.ReadOnly = True
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            ListBox2.Items.Clear()
            currentPessoa = ListBox1.SelectedIndex
            ShowContact()
        End If
    End Sub

    ' Helper routines
    Sub LockControls()
        txtCC.ReadOnly = True
        txtNIF.ReadOnly = True
        txtNome.ReadOnly = True
        txtNum_Aluno.ReadOnly = True
        txtNMatri.ReadOnly = True
        txtRef_Proj_Aluno.ReadOnly = True
        txtAno_Aluno.ReadOnly = True
        txtFuncao.ReadOnly = True
        txtID_Dep_Doc.ReadOnly = True
        txtID_Dep_Inv.ReadOnly = True
        txtID_Trab.ReadOnly = True
        txtNumFunc.ReadOnly = True
        txtRef_Proj_Doc.ReadOnly = True
        txtTel_Doc.ReadOnly = True
        txtTel_Inv.ReadOnly = True
        txt_Ref_Proj_Inv.ReadOnly = True
        txtEndTrab.ReadOnly = True
        txtNomeTrab.ReadOnly = True
        txtFreqCurso.ReadOnly = True
        txtFreqE.ReadOnly = True
        txtFreqI.ReadOnly = True
        txtFreqTipo.ReadOnly = True
        txtFreqCod.ReadOnly = True
        txtTipoCurso.ReadOnly = True
        txtCodCurso.ReadOnly = True
    End Sub

    Sub UnlockControls()
        txtCC.ReadOnly = False
        txtNIF.ReadOnly = False
        txtNome.ReadOnly = False
        txtNum_Aluno.ReadOnly = False
        txtNMatri.ReadOnly = False
        txtRef_Proj_Aluno.ReadOnly = False
        txtAno_Aluno.ReadOnly = False
        txtFuncao.ReadOnly = False
        txtID_Dep_Doc.ReadOnly = False
        txtID_Dep_Inv.ReadOnly = False
        txtID_Trab.ReadOnly = False
        txtNumFunc.ReadOnly = False
        txtRef_Proj_Doc.ReadOnly = False
        txtTel_Doc.ReadOnly = False
        txtTel_Inv.ReadOnly = False
        txt_Ref_Proj_Inv.ReadOnly = False
        txtCursoDirector.ReadOnly = True
        txtEndTrab.ReadOnly = True
        txtNomeTrab.ReadOnly = True
        txtFreqCurso.ReadOnly = True
        txtFreqE.ReadOnly = False
        txtFreqI.ReadOnly = False
        txtFreqTipo.ReadOnly = True
        txtFreqCod.ReadOnly = False
        txtTipoCurso.ReadOnly = True
        txtCodCurso.ReadOnly = False
    End Sub

    Sub ShowButtons()
        LockControls()
        bttnAdd.Visible = True
        bttnDelete.Visible = True
        bttnEdit.Visible = True
        bttnOK.Visible = False
        bttnCancel.Visible = False
        bttnCurso.Visible = True
        bttnEditCurso.Visible = True
        bttnRemCurso.Visible = True
    End Sub

    Sub ClearFields()
        txtCC.Text = ""
        txtNIF.Text = ""
        txtNome.Text = ""
        txtNum_Aluno.Text = ""
        txtNMatri.Text = ""
        txtRef_Proj_Aluno.Text = ""
        txtAno_Aluno.Text = ""
        txtFuncao.Text = ""
        txtID_Dep_Doc.Text = ""
        txtID_Dep_Inv.Text = ""
        txtID_Trab.Text = ""
        txtNumFunc.Text = ""
        txtRef_Proj_Doc.Text = ""
        txtTel_Doc.Text = ""
        txtTel_Inv.Text = ""
        txt_Ref_Proj_Inv.Text = ""
        txtCursoDirector.Text = ""
        txtEndTrab.Text = ""
        txtNomeTrab.Text = ""
        txtTipoCurso.Text = ""
        txtCodCurso.Text = 0
        txtFreqCurso.Text = ""
        txtFreqE.Text = ""
        txtFreqI.Text = ""
        txtFreqTipo.Text = ""
        txtFreqCod.Text = ""
    End Sub

    Sub ClearCurso()
        txtFreqCurso.Text = ""
        txtFreqE.Text = ""
        txtFreqI.Text = ""
        txtFreqTipo.Text = ""
        txtFreqCod.Text = ""
    End Sub

    Sub UnlockCurso()
        txtFreqCod.ReadOnly = False
        txtFreqE.ReadOnly = False
        txtFreqI.ReadOnly = False
    End Sub

    Sub LockCurso()
        txtFreqCod.ReadOnly = True
        txtFreqE.ReadOnly = True
        txtFreqI.ReadOnly = True
    End Sub

    Sub HideButtons_Curso()
        UnlockCurso()
        bttnAdd.Visible = False
        bttnEdit.Visible = False
        bttnDelete.Visible = False
        bttnConf.Visible = True
        bttnCancelCurso.Visible = True
        bttnCurso.Visible = False
        bttnEditCurso.Visible = False
        bttnRemCurso.Visible = False
    End Sub

    Sub ShowButtons_Curso()
        LockCurso()
        bttnAdd.Visible = True
        bttnEdit.Visible = True
        bttnDelete.Visible = True
        bttnConf.Visible = False
        bttnCancelCurso.Visible = False
        bttnCurso.Visible = True
        bttnEditCurso.Visible = True
        bttnRemCurso.Visible = True
    End Sub

    Sub ShowContact()
        If ListBox1.Items.Count = 0 Or currentPessoa < 0 Then Exit Sub
        ClearFields()
        Try
            ' Funcionario
            Dim func As New Funcionario
            func = CType(ListBox1.Items.Item(currentPessoa), Funcionario)
            txtNIF.Text = func.NIF
            txtNome.Text = func.Nome
            txtCC.Text = func.CC
            txtNumFunc.Text = func.Numero
            txtFuncao.Text = func.Funcao
            txtID_Trab.Text = func.ID_Trab
            txtEndTrab.Text = func.Endereco
            txtNomeTrab.Text = func.NomeTrab
            TabControl1.SelectTab(0)
        Catch ex As Exception
            Try
                ' Docente
                Dim doc As New Docente
                doc = CType(ListBox1.Items.Item(currentPessoa), Docente)
                txtNIF.Text = doc.NIF
                txtNome.Text = doc.Nome
                txtCC.Text = doc.CC
                txtTel_Doc.Text = doc.Telefone
                txtID_Dep_Doc.Text = doc.ID_Dep
                txtRef_Proj_Doc.Text = doc.Ref_Proj
                txtCursoDirector.Text = doc.Curso
                txtTipoCurso.Text = doc.Tipo
                txtCodCurso.Text = doc.Cod_Curso
                TabControl1.SelectTab(1)
            Catch ex1 As Exception
                Try
                    ' Investigador
                    Dim inv As New Investigador
                    inv = CType(ListBox1.Items.Item(currentPessoa), Investigador)
                    txtNIF.Text = inv.NIF
                    txtNome.Text = inv.Nome
                    txtCC.Text = inv.CC
                    txtTel_Inv.Text = inv.Telefone
                    txtID_Dep_Inv.Text = inv.ID_Dep
                    txt_Ref_Proj_Inv.Text = inv.Ref_Proj
                    TabControl1.SelectTab(2)
                Catch ex2 As Exception
                    Try
                        ' Aluno
                        Dim aluno As New Aluno
                        aluno = CType(ListBox1.Items.Item(currentPessoa), Aluno)
                        txtNIF.Text = aluno.NIF
                        txtNome.Text = aluno.Nome
                        txtCC.Text = aluno.CC
                        txtNum_Aluno.Text = aluno.Numero
                        txtNMatri.Text = aluno.N_Matri
                        txtRef_Proj_Aluno.Text = aluno.Ref_Proj
                        txtAno_Aluno.Text = aluno.Ano
                        TabControl1.SelectTab(3)
                        Load_Cursos(aluno.Numero)
                    Catch ex3 As Exception
                        MsgBox("Erro ao imprimir os dados da pessoa.")
                        Exit Sub
                    End Try
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
        bttnCurso.Visible = False
        bttnEditCurso.Visible = False
        bttnRemCurso.Visible = False
    End Sub

    Private Sub LoadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadToolStripMenuItem.Click
        '' Aluno
        CMD.CommandText = "SELECT * FROM UNIV.DISPLAY_ALN"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox1.Items.Clear()
        While RDR.Read
            Dim C As New Aluno With {
                .Nome = RDR.Item("Nome"),
                .CC = RDR.Item("CC"),
                .NIF = RDR.Item("NIF"),
                .Numero = Convert.ToInt32(RDR.Item("Numero")),
                .Ano = Convert.ToInt32(RDR.Item("Ano")),
                .N_Matri = Convert.ToInt32(RDR.Item("N_MATRICULAS")),
                .Ref_Proj = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("REF_PROJETO")), "", RDR.Item("REF_PROJETO")))
                }
            ListBox1.Items.Add(C)
        End While
        CN.Close()
        '' Funcionario
        CMD.CommandText = "SELECT * FROM UNIV.DISPLAY_FUNC"
        CN.Open()
        RDR = CMD.ExecuteReader
        While RDR.Read
            Dim C As New Funcionario With {
                .Nome = RDR.Item("Nome"),
                .CC = RDR.Item("CC"),
                .NIF = RDR.Item("NIF"),
                .Numero = Convert.ToInt32(RDR.Item("Numero")),
                .Funcao = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Funcao")), "", RDR.Item("Funcao"))),
                .ID_Trab = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("ID_Trab")), "", RDR.Item("ID_Trab"))),
                .Endereco = RDR.Item("Endereço"),
                .NomeTrab = RDR.Item("NOME_TRAB")
            }
            ListBox1.Items.Add(C)
        End While
        CN.Close()
        '' Docente
        CMD.CommandText = "SELECT * FROM UNIV.DISPLAY_DOC"
        CN.Open()
        RDR = CMD.ExecuteReader
        While RDR.Read
            Dim C As New Docente With {
                .Nome = RDR.Item("Nome"),
                .CC = RDR.Item("CC"),
                .NIF = RDR.Item("NIF"),
                .Telefone = RDR.Item("Telefone"),
                .ID_Dep = RDR.Item("ID_Dep"),
                .Ref_Proj = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("REF_PROJETO")), "", RDR.Item("REF_PROJETO"))),
                .Curso = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Nome_Curso")), "", RDR.Item("Nome_Curso"))),
                .Tipo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Tipo")), "", RDR.Item("Tipo"))),
                .Cod_Curso = Convert.ToInt32(IIf(RDR.IsDBNull(RDR.GetOrdinal("Codigo")), 0, RDR.Item("Codigo")))
            }
            ListBox1.Items.Add(C)
        End While
        CN.Close()
        '' Investigador
        CMD.CommandText = "SELECT * FROM UNIV.DISPLAY_INV"
        CN.Open()
        RDR = CMD.ExecuteReader
        While RDR.Read
            Dim C As New Investigador With {
                .Nome = RDR.Item("Nome"),
                .CC = RDR.Item("CC"),
                .NIF = RDR.Item("NIF"),
                .Telefone = RDR.Item("Telefone"),
                .ID_Dep = RDR.Item("ID_Dep"),
                .Ref_Proj = RDR.Item("REF_PROJETO")
            }
            ListBox1.Items.Add(C)
        End While
        CN.Close()
        currentPessoa = 0
        ShowContact()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub Load_Cursos(ByVal numero As Integer)
        CMD.CommandText = "SELECT * FROM UNIV.DISPLAY_CURSO_ALN(@numero)"

        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@numero", numero)

        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox2.Items.Clear()
        While RDR.Read
            Dim C As New Curso_Aluno With {
                .Numero = numero,
                .Curso = RDR.Item("Nome"),
                .Tipo = RDR.Item("Tipo"),
                .DataI = Date.Parse(RDR.Item("Data_Inicio")),
                .DataE = IIf(RDR.IsDBNull(RDR.GetOrdinal("Data_Fim")), "", RDR.Item("Data_Fim")),
                .Cod_Curso = RDR.Item("Codigo")
            }
            ListBox2.Items.Add(C)
        End While
        CN.Close()
        currentCurso = 0
        ShowCurso()
    End Sub
    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        If ListBox2.SelectedIndex > -1 Then
            currentCurso = ListBox2.SelectedIndex
            ShowCurso()
        End If
    End Sub

    Private Sub ShowCurso()
        If ListBox2.Items.Count = 0 Or currentCurso < 0 Then Exit Sub
        ClearCurso()
        Try
            Dim curso As New Curso_Aluno
            curso = CType(ListBox2.Items.Item(currentCurso), Curso_Aluno)
            txtFreqCurso.Text = curso.Curso
            txtFreqTipo.Text = curso.Tipo
            txtFreqI.Text = curso.DataI
            txtFreqE.Text = curso.DataE
            txtFreqCod.Text = curso.Cod_Curso
        Catch ex As Exception
            MsgBox("Erro ao imprimir os dados do curso")
        End Try
        ShowButtons_Curso()
    End Sub

    Private Sub ButtonAddC_Click(sender As Object, e As EventArgs) Handles bttnCurso.Click
        HideButtons_Curso()
        ClearCurso()
        adding = True
    End Sub

    Private Sub ButtonEditC_Click(sender As Object, e As EventArgs) Handles bttnEditCurso.Click
        currentCurso = ListBox2.SelectedIndex
        If currentCurso < 0 Then
            MsgBox("Por favor selecione o curso para editar.")
            Exit Sub
        End If
        adding = False
        ListBox2.Enabled = False
        HideButtons_Curso()
        txtFreqCod.ReadOnly = True
    End Sub

    Private Sub ButtonRemC_Click(sender As Object, e As EventArgs) Handles bttnRemCurso.Click
        If ListBox2.SelectedIndex > -1 And TabControl1.SelectedTab.Text = "Aluno" Then
            Try
                Dim Numero As Integer = CType(ListBox2.SelectedItem, Curso_Aluno).Numero
                Dim Cod_Curso As Integer = CType(ListBox2.SelectedItem, Curso_Aluno).Cod_Curso

                CMD.CommandText = "DELETE FROM UNIV.Pert_Curso WHERE CODIGO_CURSO=@Cod_Curso AND CODIGO_ALUNO=@Numero"

                CMD.Parameters.Clear()
                CMD.Parameters.AddWithValue("@Numero", Numero)
                CMD.Parameters.AddWithValue("@Cod_Curso", Cod_Curso)

                CN.Open()
                Try
                    CMD.ExecuteNonQuery()
                Catch ex As Exception
                    Throw New Exception("Impossivel remover o curso dos dados do aluno. ")
                Finally
                    CN.Close()
                End Try
                CN.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
            If currentCurso = ListBox2.Items.Count Then currentCurso = ListBox2.Items.Count - 1
            If currentCurso = -1 Then
                ClearFields()
                MsgBox("Não há mais cursos registados para este aluno.")
            Else
                ShowCurso()
            End If
        End If
    End Sub

    Private Sub bttnConf_Click(sender As Object, e As EventArgs) Handles bttnConf.Click
        Dim curso As New Curso_Aluno
        Try
            curso.Numero = txtNum_Aluno.Text
            curso.Cod_Curso = txtFreqCod.Text
            curso.DataE = txtFreqE.Text
            curso.DataI = txtFreqI.Text
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        If adding = True Then
            AddCurso(curso)
        Else
            EditCurso(curso)
        End If


        ListBox2.Enabled = True
        Load_Cursos(curso.Numero)
        ShowButtons_Curso()
    End Sub

    Private Sub ButtonCanc_Click(sender As Object, e As EventArgs) Handles bttnCancelCurso.Click
        ClearCurso()
        ShowCurso()
        ShowButtons_Curso()
        ListBox2.Enabled = True
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CN = FormMain.CN
        CMD = New SqlCommand
        CMD.Connection = CN

        LoadToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub AddCurso(ByVal C As Curso_Aluno)
        CMD.CommandText = "EXEC UNIV.Insert_Aln_Curso @numero, @cod, @data_inic, @data_fim"

        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@numero", C.Numero)
        CMD.Parameters.AddWithValue("@cod", C.Cod_Curso)
        If C.DataI <> "" Then
            CMD.Parameters.AddWithValue("@data_inic", Date.Parse(C.DataI))
        Else
            CMD.Parameters.AddWithValue("@data_inic", Date.Parse(Date.Now.ToShortDateString))
        End If

        If C.DataE <> "" Then
            CMD.Parameters.AddWithValue("@data_fim", Date.Parse(C.DataE))
        Else
            CMD.Parameters.AddWithValue("@data_fim", DBNull.Value)
        End If

        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel registar curso nos dados do aluno. " & vbCrLf & "Curso tem que existir.")
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub EditCurso(ByVal C As Curso_Aluno)
        CMD.CommandText = "EXEC UNIV.Update_Aln_Curso @numero, @cod, @data_inic, @data_fim"

        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@numero", C.Numero)
        CMD.Parameters.AddWithValue("@cod", C.Cod_Curso)
        If C.DataI <> "" Then
            CMD.Parameters.AddWithValue("@data_inic", Date.Parse(C.DataI))
        Else
            CMD.Parameters.AddWithValue("@data_inic", Date.Parse(Date.Now.ToShortDateString))
        End If

        If C.DataE <> "" Then
            CMD.Parameters.AddWithValue("@data_fim", Date.Parse(C.DataE))
        Else
            CMD.Parameters.AddWithValue("@data_fim", DBNull.Value)
        End If

        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel editar curso nos dados do aluno. ")
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub SubmitFuncionario(ByVal C As Funcionario)
        CMD.CommandText = "EXEC UNIV.Insert_Func @CC, @NIF, @Nome, @Numero, @Funcao, @ID_Trab"
        
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@CC", C.CC)
        CMD.Parameters.AddWithValue("@NIF", C.NIF)
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@Numero", C.Numero)
        If C.Funcao <> "" Then
            CMD.Parameters.AddWithValue("@Funcao", C.Funcao)
        Else
            CMD.Parameters.AddWithValue("@Funcao", DBNull.Value)
        End If
        If C.ID_Trab <> "" Then
            CMD.Parameters.AddWithValue("@ID_Trab", C.ID_Trab)
        Else
            CMD.Parameters.AddWithValue("@ID_Trab", DBNull.Value)
        End If

        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel submeter o funcionário." & vbCrLf & "CC, NIF e Número tem de ser únicos." & vbCrLf & "O ID tem de ser de um local de trabalho existente.")
        Finally
            CN.Close()
        End Try
        CN.Close()

        Dim RDR As SqlDataReader
        CMD.CommandText = "SELECT * FROM UNIV.DISPLAY_FUNC WHERE CC=@CC"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@CC", C.CC)
        CN.Open()
        RDR = CMD.ExecuteReader
        While RDR.Read
            Dim A As New Funcionario With {
                .Nome = RDR.Item("Nome"),
                .CC = RDR.Item("CC"),
                .NIF = RDR.Item("NIF"),
                .Numero = Convert.ToInt32(RDR.Item("Numero")),
                .Funcao = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Funcao")), "", RDR.Item("Funcao"))),
                .ID_Trab = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("ID_Trab")), "", RDR.Item("ID_Trab"))),
                .Endereco = RDR.Item("Endereço"),
                .NomeTrab = RDR.Item("NOME_TRAB")
            }
            ListBox1.Items.Add(A)
        End While
        CN.Close()
    End Sub

    Private Sub SubmitAluno(ByVal C As Aluno, ByVal curso As Curso_Aluno)
        CMD.CommandText = "EXEC UNIV.Insert_Aln @CC, @NIF, @Nome, @Numero, @Ano, @N_matriculas, @Ref_Projeto, @Cod_Curso, @DataI,  @DataE"

        CMD.Parameters.Clear()
        If C.Ref_Proj <> "" Then
            CMD.Parameters.AddWithValue("@Ref_Projeto", C.Ref_Proj)
        Else
            CMD.Parameters.AddWithValue("@Ref_Projeto", DBNull.Value)
        End If
        CMD.Parameters.AddWithValue("@CC", C.CC)
        CMD.Parameters.AddWithValue("@NIF", C.NIF)
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@Numero", C.Numero)
        CMD.Parameters.AddWithValue("@Ano", C.Ano)
        CMD.Parameters.AddWithValue("@N_matriculas", C.N_Matri)
        CMD.Parameters.AddWithValue("@Cod_Curso", curso.Cod_Curso)
        If curso.DataI <> "" Then
            CMD.Parameters.AddWithValue("@DataI", Date.Parse(curso.DataI))
        Else
            CMD.Parameters.AddWithValue("@DataI", Date.Parse(Date.Now.ToShortDateString))
        End If
        If curso.DataE <> "" Then
            CMD.Parameters.AddWithValue("@DataE", Date.Parse(curso.DataE))
        Else
            CMD.Parameters.AddWithValue("@DataE", DBNull.Value)
        End If
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel submeter o aluno." & vbCrLf & "CC, NIF e Número tem de ser únicos." & vbCrLf & "O codigo tem de ser de um curso existente.")
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub SubmitDocente(ByVal C As Docente)
        CMD.CommandText = "SELECT CC_Diretor, Pessoa.Nome FROM UNIV.Curso JOIN UNIV.Pessoa ON CC_DIRETOR=CC WHERE Codigo=@Cod_Curso"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Cod_Curso", C.Cod_Curso)

        Dim RDR As SqlDataReader
        Dim CC_ant As String = ""
        Dim Nome_ant As String = ""
        CN.Open()
        CMD.ExecuteNonQuery()
        RDR = CMD.ExecuteReader
        While RDR.Read
            CC_ant = RDR.Item("CC_Diretor")
            Nome_ant = RDR.Item("Nome")
        End While
        CN.Close()

        CMD.CommandText = "EXEC UNIV.Insert_Doc @CC, @NIF, @Nome, @Telefone, @ID_Dep, @Ref_Projeto, @Cod_Curso"

        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@CC", C.CC)
        CMD.Parameters.AddWithValue("@NIF", C.NIF)
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@Telefone", C.Telefone)
        CMD.Parameters.AddWithValue("@ID_Dep", C.ID_Dep)
        If C.Ref_Proj <> "" Then
            CMD.Parameters.AddWithValue("@Ref_Projeto", C.Ref_Proj)
        Else
            CMD.Parameters.AddWithValue("@Ref_Projeto", DBNull.Value)
        End If
        CMD.Parameters.AddWithValue("@Cod_Curso", C.Cod_Curso)

        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel submeter o docente." & vbCrLf & "CC, NIF e Telefone tem de ser únicos." & vbCrLf & "O codigo tem de ser de um curso existente ou 0." & vbCrLf & "O ID tem de ser de um departamento existente.")
        Finally
            CN.Close()
        End Try
        CN.Close()
        ListBox1.Items.Add(C)


        If C.Cod_Curso <> 0 Then

            Dim idx_at As Integer = ListBox1.FindString(C.ToString)
            ListBox1.Items.RemoveAt(idx_at)

            Dim idx_ant As Integer = ListBox1.FindString("Doc.:   " & Nome_ant & "   " & CC_ant)
            ListBox1.Items.RemoveAt(idx_ant)

            CMD.CommandText = "SELECT * FROM UNIV.DISPLAY_DOC WHERE CC=@CC_ant OR CC=@CC_at"
            CMD.Parameters.AddWithValue("@CC_ant", CC_ant)
            CMD.Parameters.AddWithValue("@CC_at", C.CC)
            CN.Open()
            RDR = CMD.ExecuteReader
            While RDR.Read
                Dim A As New Docente With {
                .Nome = RDR.Item("Nome"),
                .CC = RDR.Item("CC"),
                .NIF = RDR.Item("NIF"),
                .Telefone = RDR.Item("Telefone"),
                .ID_Dep = RDR.Item("ID_Dep"),
                .Ref_Proj = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("REF_PROJETO")), "", RDR.Item("REF_PROJETO"))),
                .Curso = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Nome_Curso")), "", RDR.Item("Nome_Curso"))),
                .Tipo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Tipo")), "", RDR.Item("Tipo"))),
                .Cod_Curso = Convert.ToInt32(IIf(RDR.IsDBNull(RDR.GetOrdinal("Codigo")), 0, RDR.Item("Codigo")))
            }
                ListBox1.Items.Add(A)
            End While
            CN.Close()
        End If

    End Sub

    Private Sub SubmitInv(ByVal C As Investigador)
        CMD.CommandText = "EXEC UNIV.Insert_Inv @CC, @NIF, @Nome, @Telefone, @ID_Dep, @Ref_Projeto"

        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@CC", C.CC)
        CMD.Parameters.AddWithValue("@NIF", C.NIF)
        CMD.Parameters.AddWithValue("@Telefone", C.Telefone)
        CMD.Parameters.AddWithValue("@ID_Dep", C.ID_Dep)
        CMD.Parameters.AddWithValue("@Ref_Projeto", C.Ref_Proj)

        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel submeter o investigador." & vbCrLf & "CC, NIF e Telefone tem de ser únicos." & vbCrLf & "Necessário indicar referência de projeto/grupo de investigação." & vbCrLf & "O ID tem de ser de um departamento existente.")
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub UpdateDocente(ByVal C As Docente)
        CMD.CommandText = "SELECT CC_Diretor, Pessoa.Nome FROM UNIV.Curso JOIN UNIV.Pessoa ON CC_DIRETOR=CC WHERE Codigo=@Cod_Curso"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Cod_Curso", C.Cod_Curso)

        Dim RDR As SqlDataReader
        Dim CC_ant As String = ""
        Dim Nome_ant As String = ""
        Dim Cod_curso_ant As Integer = C.Cod_Curso
        CN.Open()
        CMD.ExecuteNonQuery()
        RDR = CMD.ExecuteReader
        While RDR.Read
            CC_ant = RDR.Item("CC_Diretor")
            Nome_ant = RDR.Item("Nome")
        End While
        CN.Close()

        CMD.CommandText = "EXEC UNIV.Update_Doc @CC, @NIF, @Nome, @Telefone, @ID_Dep, @Ref_Projeto, @Cod_Curso"

        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@CC", C.CC)
        CMD.Parameters.AddWithValue("@NIF", C.NIF)
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@Telefone", C.Telefone)
        CMD.Parameters.AddWithValue("@ID_Dep", C.ID_Dep)
        If C.Ref_Proj <> "" Then
            CMD.Parameters.AddWithValue("@Ref_Projeto", C.Ref_Proj)
        Else
            CMD.Parameters.AddWithValue("@Ref_Projeto", DBNull.Value)
        End If
        CMD.Parameters.AddWithValue("@Cod_Curso", C.Cod_Curso)

        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel editar o docente." & vbCrLf & "Telefone tem de ser único." & vbCrLf & "O codigo tem de ser de um curso existente ou 0." & vbCrLf & "O ID tem de ser de um departamento existente.")
        Finally
            CN.Close()
        End Try
        CN.Close()

        If C.Cod_Curso <> 0 Then
            Dim idx_ant As Integer = ListBox1.FindString("Doc.:   " & Nome_ant & "   " & CC_ant)
            ListBox1.Items.RemoveAt(idx_ant)
        End If

        If C.Cod_Curso <> 0 And CC_ant <> C.CC Then
            Dim idx_at As Integer = ListBox1.FindString(C.ToString)
            ListBox1.Items.RemoveAt(idx_at)
        End If

        If C.Cod_Curso = 0 Then
            Dim idx_at As Integer = ListBox1.SelectedIndex
            ListBox1.Items.RemoveAt(idx_at)
        End If

        CMD.CommandText = "SELECT * FROM UNIV.DISPLAY_DOC WHERE CC=@CC_ant OR CC=@CC_at"
        CMD.Parameters.Clear()
        If CC_ant = "" Then
            CMD.Parameters.AddWithValue("@CC_ant", DBNull.Value)
        Else
            CMD.Parameters.AddWithValue("@CC_ant", CC_ant)
        End If
        CMD.Parameters.AddWithValue("@CC_at", C.CC)
        CN.Open()
        RDR = CMD.ExecuteReader
        While RDR.Read
            Dim A As New Docente With {
                .Nome = RDR.Item("Nome"),
                .CC = RDR.Item("CC"),
                .NIF = RDR.Item("NIF"),
                .Telefone = RDR.Item("Telefone"),
                .ID_Dep = RDR.Item("ID_Dep"),
                .Ref_Proj = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("REF_PROJETO")), "", RDR.Item("REF_PROJETO"))),
                .Curso = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Nome_Curso")), "", RDR.Item("Nome_Curso"))),
                .Tipo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Tipo")), "", RDR.Item("Tipo"))),
                .Cod_Curso = Convert.ToInt32(IIf(RDR.IsDBNull(RDR.GetOrdinal("Codigo")), 0, RDR.Item("Codigo")))
            }
            ListBox1.Items.Add(A)
        End While
        CN.Close()
    End Sub

    Private Sub UpdateInv(ByVal C As Investigador)
        CMD.CommandText = "EXEC UNIV.Update_Inv @CC, @NIF, @Nome, @Telefone, @ID_Dep, @Ref_Projeto"

        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@CC", C.CC)
        CMD.Parameters.AddWithValue("@NIF", C.NIF)
        CMD.Parameters.AddWithValue("@Telefone", C.Telefone)
        CMD.Parameters.AddWithValue("@ID_Dep", C.ID_Dep)
        CMD.Parameters.AddWithValue("@Ref_Projeto", C.Ref_Proj)

        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel editar o investigador." & vbCrLf & "CC, NIF e Telefone tem de ser únicos." & vbCrLf & "Necessário indicar referência de projeto/grupo de investigação." & vbCrLf & "O ID tem de ser de um departamento existente.")
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub UpdateAluno(ByVal C As Aluno)
        CMD.CommandText = "EXEC UNIV.Update_Aln @CC, @NIF, @Nome, @Numero, @Ano, @N_matriculas, @Ref_Projeto"

        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@CC", C.CC)
        CMD.Parameters.AddWithValue("@NIF", C.NIF)
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@Numero", C.Numero)
        CMD.Parameters.AddWithValue("@Ano", C.Ano)
        CMD.Parameters.AddWithValue("@N_matriculas", C.N_Matri)
        If C.Ref_Proj <> "" Then
            CMD.Parameters.AddWithValue("@Ref_Projeto", C.Ref_Proj)
        Else
            CMD.Parameters.AddWithValue("@Ref_Projeto", DBNull.Value)
        End If

        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel editar o aluno." & vbCrLf & "CC, NIF e Número tem de ser únicos." & vbCrLf & "O codigo tem de ser de um curso existente.")
        Finally
            CN.Close()
        End Try
    End Sub
    Private Sub UpdateFunc(ByVal C As Funcionario)
        CMD.CommandText = "EXEC UNIV.Update_Func @CC, @NIF, @Nome, @Numero, @Funcao, @ID_Trab"

        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@CC", C.CC)
        CMD.Parameters.AddWithValue("@NIF", C.NIF)
        CMD.Parameters.AddWithValue("@Nome", C.Nome)
        CMD.Parameters.AddWithValue("@Numero", C.Numero)
        If C.Funcao <> "" Then
            CMD.Parameters.AddWithValue("@Funcao", C.Funcao)
        Else
            CMD.Parameters.AddWithValue("@Funcao", DBNull.Value)
        End If
        If C.ID_Trab <> "" Then
            CMD.Parameters.AddWithValue("@ID_Trab", C.ID_Trab)
        Else
            CMD.Parameters.AddWithValue("@ID_Trab", DBNull.Value)
        End If

        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel editar o funcionário." & vbCrLf & "CC, NIF e Número tem de ser únicos." & vbCrLf & "O ID tem de ser de um local de trabalho existente.")
        Finally
            CN.Close()
        End Try

        Dim idx_at As Integer = ListBox1.FindString(C.ToString)
        ListBox1.Items.RemoveAt(idx_at)

        Dim RDR As SqlDataReader
        CMD.CommandText = "SELECT * FROM UNIV.DISPLAY_FUNC WHERE CC=@CC"
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@CC", C.CC)
        CN.Open()
        RDR = CMD.ExecuteReader
        While RDR.Read
            Dim A As New Funcionario With {
                .Nome = RDR.Item("Nome"),
                .CC = RDR.Item("CC"),
                .NIF = RDR.Item("NIF"),
                .Numero = Convert.ToInt32(RDR.Item("Numero")),
                .Funcao = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Funcao")), "", RDR.Item("Funcao"))),
                .ID_Trab = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("ID_Trab")), "", RDR.Item("ID_Trab"))),
                .Endereco = RDR.Item("Endereço"),
                .NomeTrab = RDR.Item("NOME_TRAB")
            }
            ListBox1.Items.Add(A)
        End While
        CN.Close()
    End Sub

    Private Sub RemoveAluno(ByVal CC As String)
        CMD.CommandText = "DELETE Univ.Aluno WHERE CC=@CC "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@CC", CC)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel eliminar o aluno.")
        Finally
            CN.Close()
        End Try
    End Sub
    Private Sub RemoveFunc(ByVal CC As String)
        CMD.CommandText = "DELETE Univ.Funcionario WHERE CC=@CC "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@CC", CC)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel eliminar o funcionário.")
        Finally
            CN.Close()
        End Try
    End Sub
    Private Sub RemoveDocente(ByVal CC As String)
        CMD.CommandText = "DELETE Univ.Docente WHERE CC=@CC "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@CC", CC)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel eliminar o docente.")
        Finally
            CN.Close()
        End Try
    End Sub
    Private Sub RemoveInv(ByVal CC As String)
        CMD.CommandText = "DELETE Univ.Investigador WHERE CC=@CC "
        CMD.Parameters.Clear()
        CMD.Parameters.AddWithValue("@CC", CC)
        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Impossivel eliminar o investigador.")
        Finally
            CN.Close()
        End Try
    End Sub

End Class
