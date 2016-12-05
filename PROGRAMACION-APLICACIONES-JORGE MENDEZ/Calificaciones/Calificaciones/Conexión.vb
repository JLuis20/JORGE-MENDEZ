Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Conexión

    Public conexion As SqlConnection = New SqlConnection("Data Source = JORGE-PC;Initial Catalog=BECAS; Integrated Security=True")
    Private cmb As SqlCommandBuilder
    Public ds As DataSet = New DataSet()
    Public da As SqlDataAdapter
    Public comando As SqlCommand


    Public Sub Conectar()
        Try
            conexion.Open()
            MessageBox.Show("Conectado")
        Catch ex As Exception
            MessageBox.Show("Error al conectar")
        Finally
            conexion.Close()
        End Try
    End Sub

    Public Sub Consulta(ByVal sql As String, ByVal tabla As String)
        ds.Tables.Clear()
        da = New SqlDataAdapter(sql, conexion)
        cmb = New SqlCommandBuilder(da)
        da.Fill(ds, tabla)
    End Sub

    Function Insertar(ByVal sql)
        conexion.Open()
        comando = New SqlCommand(sql, conexion)
        Dim JL As Integer = comando.ExecuteNonQuery()
        If (JL> 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Function Eliminar(ByVal tabla, ByVal condicion)
        conexion.Open()
        Dim elimina As String = "delete from" + tabla + "where" + condicion
        comando = New SqlCommand(elimina, conexion)
        Dim j As Integer = comando.ExecuteNonQuery()
        conexion.Close()
        If (j > 0) Then
            Return True
        Else
            Return False
        End If

    End Function

    Function Actualizar(ByVal tabla, ByVal campos, ByVal condicion)
        conexion.Open()
        Dim Refrescar As String = "update" + tabla + "set" + campos + "where" + condicion
        comando = New SqlCommand(Refrescar, conexion)
        Dim i As Integer = comando.ExecuteNonQuery()
        conexion.Close()
        If (i > 0) Then
            Return True
        Else
            Return False

        End If
    End Function
End Class
