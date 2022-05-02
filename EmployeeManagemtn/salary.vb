Imports System.Data.SqlClient



Public Class salary
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shafek\Documents\EmployeeVBdb.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub fetchemployeedata()
        If id.Text = "" Then
            MsgBox("Enter The employee ID")
        Else
            Con.Open()

            Dim sqll = "select * from attendance Where empID=" & id.Text & " "
            Dim adapp As SqlDataAdapter
            adapp = New SqlDataAdapter(sqll, Con)
            Dim buider As SqlCommandBuilder
            buider = New SqlCommandBuilder(adapp)
            Dim ds As DataSet
            ds = New DataSet
            adapp.Fill(ds)
            atT.DataSource = ds.Tables(0)

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
                Emppos.Text = dr(3).ToString
                TextBox1.Text = dr(7).ToString

                EmpName.Visible = True
                Emppos.Visible = True


            Next

            Con.Close()

        End If

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        Dim main = New MainForm
        main.Show()

    End Sub

    Private Sub salary_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        fetchemployeedata()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class