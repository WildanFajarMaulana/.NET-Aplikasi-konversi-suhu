Imports System.IO
Public Class Form1
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Validasi TextBox1 || value celcius dan TextBox3 || dir name file tidak boleh kosong
        If String.IsNullOrEmpty(TextBox1.Text) OrElse String.IsNullOrEmpty(TextBox3.Text) Then
            MessageBox.Show("Mohon isi teks pada kedua kotak teks sebelum membuat file.")
            Return
        End If

        ' Membuat file baru
        Dim writeFile As StreamWriter = File.CreateText(TextBox3.Text)

        ' Menulis isi file dari TextBox1
        Dim isiFile As String = TextBox1.Text
        writeFile.WriteLine(isiFile)

        ' Menutup file
        writeFile.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim readfile As String
        readfile = My.Computer.FileSystem.ReadAllText(TextBox2.Text)

        KonversiSuhu(readfile)




    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged


    End Sub


    Private Sub KonversiSuhu(ByVal suhuC As Double)
        ' Validasi suhuC harus lebih besar dari -273.15
        If suhuC < -273.15 Then
            MessageBox.Show("Suhu tidak valid.")
            Return
        End If

        ' Konversi suhu dari Celcius ke Fahrenheit
        Dim suhuF As Double = suhuC * 1.8 + 32

        ' Menampilkan hasil konversi
        MessageBox.Show(suhuC & " derajat Celcius sama dengan " & suhuF & " derajat Fahrenheit.")

        ' Loop untuk mengecek apakah suhuF dalam rentang 32-212 derajat Fahrenheit
        Dim i As Integer = 0
        While i < 3 AndAlso (suhuF < 32 OrElse suhuF > 212)
            MessageBox.Show("Perhatian! Suhu melebihi rentang normal.")
            suhuC = suhuC + 1
            suhuF = suhuC * 1.8 + 32
            i = i + 1
        End While

        ' Kondisi untuk mengecek apakah suhuF dalam rentang normal atau tidak
        If suhuF >= 32 AndAlso suhuF <= 212 Then
            MessageBox.Show("Suhu dalam rentang normal.")
        Else
            MessageBox.Show("Suhu masih di luar rentang normal setelah dilakukan koreksi.")
        End If
    End Sub
End Class
