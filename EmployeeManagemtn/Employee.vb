Imports System.Data.SqlClient


Public Class Employee
    Dim Con As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\SHAFEK\DOCUMENTS\EMPLOYEEVBDB.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
    Private Sub Pop()
        Con.Open()
        Dim sql = "select * from EmployeeTb1"
        Dim adap As SqlDataAdapter
        adap = New SqlDataAdapter(sql, Con)
        Dim buider As SqlCommandBuilder
        buider = New SqlCommandBuilder(adap)
        Dim ds As DataSet
        ds = New DataSet
        adap.Fill(ds)

        Emptap.DataSource = ds.Tables(0)
        Con.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Con.Open()
        Dim Query As String
        Query = "insert into EmployeeTb1 values('" & Ename.Text & "','" & Eaddr.Text & "','" & Epos.SelectedItem.ToString() & "','" & Ephone.Text & "','" & Essn.Text & "','" & Egen.SelectedItem.ToString() & "','" & salary.Text & "')"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(Query, Con)
        cmd.ExecuteNonQuery()
        MsgBox("Employee Added")

        Con.Close()
        Pop()
        Clear()

    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Emptap.CellContentClick

    End Sub

    Private Sub Employee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Pop()
    End Sub

    Private Sub Ename_TextChanged(sender As Object, e As EventArgs) Handles Ename.TextChanged

    End Sub
    Dim key = 0

    Private Sub Clear()
        Ename.Clear()
        Ename.Text = ""
        Eaddr.Text = ""
        Epos.Text = ""
        Ephone.Text = ""
        Essn.Text = ""
        Egen.Text = ""
        salary.Text = ""
        key = 0

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If key = 0 Then
            MsgBox("Select The Employee to delete")
        Else
            Try
                Con.Open()
                Dim Query As String
                Query = "Delete from EmployeeTb1 where ID = " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(Query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Employee Deleted successfully ")
                Con.Close()
                Pop()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If


    End Sub

    Private Sub Emptap_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Emptap.CellMouseClick
        Dim row As DataGridViewRow = Emptap.Rows(e.RowIndex)
        key = Convert.ToInt32(row.Cells(0).Value.ToString())
        Ename.Text = row.Cells(1).Value.ToString()
        Eaddr.Text = row.Cells(2).Value.ToString()
        Epos.Text = row.Cells(3).Value.ToString()
        Ephone.Text = row.Cells(4).Value.ToString()
        Essn.Text = row.Cells(5).Value.ToString()
        Egen.Text = row.Cells(6).Value.ToString()
        salary.Text = row.Cells(7).Value.ToString




    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Ename.Text = "" Or Ephone.Text = "" Or Epos.Text = "" Then
            MsgBox("ERORR : Missing information ")
        Else
            Con.Open()
            Dim Query As String
            Query = "Update  EmployeeTb1 set Name='" & Ename.Text & "', Address='" & Eaddr.Text & "', PosItion='" & Epos.SelectedItem.ToString() & "', Phone='" & Ephone.Text & "', SSN='" & Essn.Text & "',Gender='" & Egen.SelectedItem.ToString() & "',Salary='" & salary.Text & "' where ID=" & key & ""
            Dim cmd As New SqlCommand(Query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Employee Updated")

            Con.Close()
            Pop()
            Clear()


        End If




    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Dim main = New MainForm
        main.Show()

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class