Imports System.Data.SqlClient

Public Class FormMain
    Public CN As SqlConnection

    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Mudar conexão aqui:
        CN = New SqlConnection("Data Source = XXX,XXXX;Initial Catalog = XXXX; uid = XXXX; password = ")
    End Sub

    Private Sub bttnPessoas_Click(sender As Object, e As EventArgs) Handles bttnPessoas.Click
        Dim oForm As New Form1
        oForm.Show()
    End Sub

    Private Sub bttnLocais_Click(sender As Object, e As EventArgs) Handles bttnLocais.Click
        Dim oForm As New FormLocais
        oForm.Show()
    End Sub

    Private Sub bttnCursos_Click(sender As Object, e As EventArgs) Handles bttnCursos.Click
        Dim oForm As New FormCursos
        oForm.Show()
    End Sub
End Class
