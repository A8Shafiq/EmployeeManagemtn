Imports System.Data.SqlClient

Public Class attendance
    Dim Con As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\SHAFEK\DOCUMENTS\EMPLOYEEVBDB.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
    Dim key = 0
    Private Sub Clear()
        Id.Clear()
        Id.Text = ""
        DateTimePicker1.Text = ""
        key = 0
    End Sub

    Private Sub Pop()
        Con.Open()
        Dim sql = "select * from attendance"
        Dim adap As SqlDataAdapter
        adap = New SqlDataAdapter(sql, Con)
        Dim buider As SqlCommandBuilder
        buider = New SqlCommandBuilder(adap)
        Dim ds As DataSet
        ds = New DataSet
        adap.Fill(ds)

        atT.DataSource = ds.Tables(0)
        Con.Close()
    End Sub

    Private Sub attendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Pop()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Con.Open()
        Dim Query As String = String.Empty
        Query &= "INSERT INTO attendance (Date, empID)  VALUES('" & DateTimePicker2.Value & "','" & Id.Text & "')"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(Query, Con)
        cmd.ExecuteNonQuery()
        MsgBox("proccess Added")

        Con.Close()
        Pop()
        Clear()
    End Sub

  
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Id.Text = "" Or DateTimePicker2.Text = "" Then
            MsgBox("ERORR : Missing information ")
        Else
            Con.Open()
            Dim Query As String
            Query = "Update  attendance set Date='" & DateTimePicker2.Value & "', empID='" & Id.Text & "' where Id=" & key & ""
            Dim cmd As New SqlCommand(Query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Employee Updated")

            Con.Close()
            Pop()
            Clear()


        End If
    End Sub
    Private Sub Emptap_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles atT.CellMouseClick
        Dim row As DataGridViewRow = atT.Rows(e.RowIndex)
        key = Convert.ToInt32(row.Cells(0).Value.ToString())
        Id.Text = row.Cells(2).Value.ToString()
        DateTimePicker2.Text = row.Cells(1).Value.ToString()
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If key = 0 Then
            MsgBox("Select The Employee to delete")
        Else
            Try
                Con.Open()
                Dim Query As String
                Query = "Delete from attendance where Id = " & key & ""
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Dim main = New MainForm
        main.Show()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Application.Exit()
    End Sub

End Class