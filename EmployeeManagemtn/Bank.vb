Imports System.Data.SqlClient


Public Class Bank
    Dim Con As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\SHAFEK\DOCUMENTS\EMPLOYEEVBDB.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
    Private Sub Pop()
        Con.Open()
        Dim sql = "select * from bank"
        Dim adap As SqlDataAdapter
        adap = New SqlDataAdapter(sql, Con)
        Dim buider As SqlCommandBuilder
        buider = New SqlCommandBuilder(adap)
        Dim ds As DataSet
        ds = New DataSet
        adap.Fill(ds)

        atttap.DataSource = ds.Tables(0)
        Con.Close()
    End Sub

    Private Sub Bank_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Pop()
    End Sub

    Private Sub Eaddr_TextChanged(sender As Object, e As EventArgs) Handles Banount.TextChanged, TextBox1.TextChanged

    End Sub

    Private Sub Ename_TextChanged(sender As Object, e As EventArgs) Handles Bname.TextChanged, TextBox2.TextChanged

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint, Panel2.Paint

    End Sub
    Dim key = 0
    Private Sub Clear()
        Bname.Clear()
        Banount.Text = ""
        Bpro.Text = ""
        DateTimePicker1.Text = ""
        key = 0

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button7.Click
        Con.Open()
        Dim Query As String = String.Empty

        Query &= "INSERT INTO bank (BankName, Amount, Tybe,Date ) VALUES('" & TextBox2.Text & "','" & TextBox1.Text & "','" & ComboBox1.SelectedItem.ToString() & "','" & DateTimePicker2.Value & "')"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(Query, Con)
        cmd.ExecuteNonQuery()
        MsgBox("proccess Added")

        Con.Close()
        Pop()
        Clear()
    End Sub
    Private Sub Emptap_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles atttap.CellMouseClick
        Dim row As DataGridViewRow = atttap.Rows(e.RowIndex)
        key = Convert.ToInt32(row.Cells(0).Value.ToString())
        TextBox2.Text = row.Cells(1).Value.ToString()
        TextBox1.Text = row.Cells(2).Value.ToString()
        ComboBox1.Text = row.Cells(3).Value.ToString()
        DateTimePicker2.Text = row.Cells(4).Value.ToString()



    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click, Button6.Click
        If TextBox2.Text = "" Or TextBox1.Text = "" Then
            MsgBox("ERORR : Missing information ")
        Else
            Con.Open()
            Dim Query As String
            Query = "Update  bank set BankName='" & TextBox2.Text & "', Amount='" & TextBox1.Text & "', Tybe='" & ComboBox1.SelectedItem.ToString() & "', Date='" & DateTimePicker2.Value & "' where ID=" & key & ""
            Dim cmd As New SqlCommand(Query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("process  Updated")

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click, Button5.Click
        If key = 0 Then
            MsgBox("Select The process to delete")
        Else
            Try
                Con.Open()
                Dim Query As String
                Query = "Delete from bank where id = " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(Query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("process Deleted successfully ")
                Con.Close()
                Pop()
                Clear()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If


    End Sub

    Private Sub banktap_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles banktap.CellContentClick, atttap.CellContentClick
        Dim row As DataGridViewRow = banktap.Rows(e.RowIndex)
        key = Convert.ToInt32(row.Cells(0).Value.ToString())
        Bname.Text = row.Cells(1).Value.ToString()
        Banount.Text = row.Cells(2).Value.ToString()
        Bpro.Text = row.Cells(3).Value.ToString()
        DateTimePicker1.Value = row.Cells(4).Value.ToString()



    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click, Label9.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click, Label7.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click, Label6.Click

    End Sub

    Private Sub Bpro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Bpro.SelectedIndexChanged, ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click, Label5.Click

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged, DateTimePicker2.ValueChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

    End Sub
End Class