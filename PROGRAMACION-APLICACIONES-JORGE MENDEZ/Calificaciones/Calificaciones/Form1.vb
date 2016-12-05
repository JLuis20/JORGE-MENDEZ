Public Class Form1
    Dim conexion As Conexión = New Conexión()

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Cal1 As Integer
        Dim Cal2 As Integer
        Dim Cal3 As Integer
        Dim Cal4 As Integer
        Dim Cal5 As Integer
        Dim Cal6 As Integer
        Dim Promediar As Integer

        Cal1 = TextBox3.Text()
        Cal2 = TextBox4.Text()
        Cal3 = TextBox5.Text()
        Cal4 = TextBox6.Text()
        Cal5 = TextBox7.Text()
        Cal6 = TextBox8.Text()
        Promediar = (Cal1 + Cal2 + Cal3 + Cal4 + Cal5 + Cal6) / 6
        Promedio.Text = Promediar

        If Promediar = 8 Then
            MsgBox("El/La alumno (a)" & " " & Nombre.Text & " " & Apellidos.Text & " tiene un promedio de " & " " & Promediar & " " & " y se le otorgará la beca de:" & " Apoyo a tu transporte")

        ElseIf Promediar = 9 Then
            MsgBox("El/La alumno (a)" & " " & Nombre.Text & " " & Apellidos.Text & " tiene un promedio de " & " " & Promediar & " " & " y se le otorgó la beca de:" & " Manutención Campeche")

        ElseIf Promediar = 10 Then
            MsgBox("El/La alumno (a)" & " " & Nombre.Text & " " & Apellidos.Text & " tiene un promedio de " & " " & Promediar & " " & " y se le otorgó la beca de:" & " Fundación Pablo García")

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        Dim Agregar As String = "insert into ALUMNOS_BECARIOS values (" + Clave.Text + ",'" + Nombre.Text + "','" + Apellidos.Text + "','" + Promedio.Text + "')"
        If (conexion.Insertar(Agregar)) Then
            MessageBox.Show("Datos guardados correctamente")
            MostrarDatos()
        Else
            MessageBox.Show("Error al guardar datos")
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexion.Conectar()
        MostrarDatos()

    End Sub

    Public Sub MostrarDatos()
        conexion.Consulta("select * from ALUMNOS_BECARIOS", "ALUMNOS_BECARIOS")
        Datos.DataSource = conexion.ds.Tables("ALUMNOS_BECARIOS")

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim Cal1 As Integer
        Dim Cal2 As Integer
        Dim Cal3 As Integer
        Dim Cal4 As Integer
        Dim Cal5 As Integer
        Dim Cal6 As Integer
        Dim Promediar As Integer

        Cal1 = TextBox3.Text()
        Cal2 = TextBox4.Text()
        Cal3 = TextBox5.Text()
        Cal4 = TextBox6.Text()
        Cal5 = TextBox7.Text()
        Cal6 = TextBox8.Text()
        Promediar = (Cal1 + Cal2 + Cal3 + Cal4 + Cal5 + Cal6) / 6
        Promedio.Text = Promediar
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        If (conexion.Eliminar("datos", "Clave=" + Clave.Text)) Then
            MessageBox.Show("Datos eliminados correctamente")
            MostrarDatos()
        Else
            MessageBox.Show("Error al eliminar datos")
        End If


    End Sub

    Private Sub Datos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Datos.CellContentClick
        Dim Datitos As DataGridViewRow = Datos.Rows(e.RowIndex)
        Clave.Text = Datitos.Cells(0).Value.ToString()
        Nombre.Text = Datitos.Cells(1).Value.ToString()
        Apellidos.Text = Datitos.Cells(2).Value.ToString()
        Promedio.Text = Datitos.Cells(3).Value.ToString()



    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim actualización As String = "Nombre='" + Nombre.Text + "',Apellido='" + Apellidos.Text + "',promedio='" + Promedio.Text + "'"
        If (conexion.Actualizar("datos", actualización, "Clave" + Clave.Text)) Then
            MessageBox.Show("Datos actualizados correctamente")
            MostrarDatos()
        Else
            MessageBox.Show("Error al actualizar datos")
        End If
    End Sub
End Class
