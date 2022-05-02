Imports System.Data.SqlClient

Public Class store1
    Dim Con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\shafek\Documents\EmployeeVBdb.mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub Pop()
        Con.Open()
        Dim sql = "select * from store"
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
    Private Sub Emptap_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Emptap.CellMouseClick
        Dim row As DataGridViewRow = Emptap.Rows(e.RowIndex)
        key = Convert.ToInt32(row.Cells(0).Value.ToString())
        item.Text = row.Cells(1).Value.ToString()
        count.Text = row.Cells(2).Value.ToString()
        DateTimePicker1.Text = row.Cells(3).Value.ToString()



    End Sub

    Private Sub Emptap_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Emptap.CellContentClick

    End Sub

    Private Sub Bname_TextChanged(sender As Object, e As EventArgs) Handles item.TextChanged

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub store1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Pop()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Con.Open()
        Dim query As String = String.Empty
        query &= "INSERT INTO store (Name, Count, Date ) VALUES ('" & item.Text & "','" & count.Text & "','" & DateTimePicker1.Value.Date & "')"
        Dim cmd As SqlCommand
        cmd = New SqlCommand(Query, Con)
        cmd.ExecuteNonQuery()
        MsgBox("Item Added")

        Con.Close()
        Pop()
        Clear()
    End Sub
    Dim key = 0

    Private Sub Clear()
        item.Clear()
        item.Text = ""
        count.Text = ""
        DateTimePicker1.Text = ""
        key = 0

    End Sub
    Private Sub Banount_TextChanged(sender As Object, e As EventArgs) Handles count.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If item.Text = "" Or count.Text = "" Then
            MsgBox("ERORR : Missing information ")
        Else
            Con.Open()
            Dim Query As String = String.Empty

            Query &= "UPDATE  store set Name='" & item.Text & "', Count='" & count.Text & "', Date='" & DateTimePicker1.Value & "' where ID=" & key & ""
            Dim cmd As New SqlCommand(Query, Con)
            cmd.ExecuteNonQuery()
            MsgBox("Store Updated")

            Con.Close()
            Pop()
            Clear()





        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If key = 0 Then
            MsgBox("Select The item to delete")
        Else
            Try
                Con.Open()
                Dim Query As String
                Query = "Delete from store where Id = " & key & ""
                Dim cmd As SqlCommand
                cmd = New SqlCommand(Query, Con)
                cmd.ExecuteNonQuery()
                MsgBox("Item Deleted successfully ")
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