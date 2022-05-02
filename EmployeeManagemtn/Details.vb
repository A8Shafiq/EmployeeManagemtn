Imports System.Data.SqlClient

Public Class fetch
    Dim Con As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\SHAFEK\DOCUMENTS\EMPLOYEEVBDB.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
    Private Sub fetchemployeedata()
        If id.Text = "" Then
            MsgBox("Enter The employee ID")
        Else
            Con.Open()

            Dim query = "select * from EmployeeTb1 where ID=" & id.Text & " "
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, Con)
            Dim dt As DataTable
            dt = New DataTable
            Dim sda As SqlDataAdapter
            sda = New SqlDataAdapter(cmd)
            sda.Fill(dt)

            For Each dr As DataRow In dt.Rows
                EmpName.Text = dr(1).ToString
                Empaddr.Text = dr(2).ToString
                Emppos.Text = dr(3).ToString
                Empphone.Text = dr(4).ToString
                Empssn.Text = dr(6).ToString
                Empgend.Text = dr(5).ToString
                Empsalary.Text = dr(7).ToString

                EmpName.Visible = True
                Empaddr.Visible = True
                Emppos.Visible = True
                Empphone.Visible = True
                Empssn.Visible = True
                Empgend.Visible = True
                Empsalary.Visible = True

            Next

            Con.Close()

        End If

    End Sub
    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Empaddr.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles EmpName.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Empgend.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Empphone.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Dim main = New MainForm
        main.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        fetchemployeedata()
    End Sub
    Private Sub salary_Paint(sender As Object, e As PaintEventArgs)


    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class