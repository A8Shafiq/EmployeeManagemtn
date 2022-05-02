Public Class login
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        UsLOG.Clear()
        PsLOG.Clear()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If UsLOG.Text = "" Or PsLOG.Text = "" Then
            MsgBox("Enter The User ID and Password")
        ElseIf UsLOG.Text = "amr" And PsLOG.Text = "01206867020" Then
            Dim main = New MainForm
            main.Show()
            Me.Hide()

        Else
            MsgBox("wrong username or password ")
        End If
    End Sub
End Class