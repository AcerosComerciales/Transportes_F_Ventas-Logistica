Imports DAConexion

Public Class DTRAN_ConfigVehicularPesosMedidas
#Region " Variables "
    Private m_formatofecha As String
    Public ReadOnly Property Tabla() As String
        Get
            Return "TRAN_ConfigVehicularPesosMedidas"
        End Get
    End Property
    Public ReadOnly Property Esquema() As String
        Get
            Return "Transportes"
        End Get
    End Property

#End Region
    
#Region " Constructores "
	
    Public Sub New()
        m_formatofecha = "yyyy-MM-dd HH:mm:ss.fff"
    End Sub

#End Region
#Region " Procedimientos Almacenados "
    
    Public Function getPesoBrutoMax(ByVal x_tipo As String) As Decimal
        Try
            DAEnterprise.AsignarProcedure(getSelectAll(x_tipo), CommandType.Text)
            Dim m_datos As DataTable = DAEnterprise.ExecuteDataSet().Tables(0)
            If m_datos.Rows.Count > 0 Then
                Return CType(m_datos.Rows(0)("CVEHIC_PesoBrutoMax"), Decimal)
            Else
                Return 0
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
#Region "Procedimientos Adicionales "
    Private Function getSelectAll(ByVal x_tipo As String) As String
        Dim sql As String = ""
        Try
            sql &= String.Format(" Select IsNull(CVEHIC_PesoBrutoMax, 0.0) As CVEHIC_PesoBrutoMax from [Transportes].[TRAN_ConfigVehicularPesosMedidas] ", vbNewLine)
            sql &= String.Format(" Where TIPOS_CodTipoCVehic = '{0}' {1}", x_tipo  ,vbNewLine)

            Return sql
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
#Region " Metodos "
	
    Private Function getDate() As String
        Dim x_datos As New DataTable()
        Try
            DAEnterprise.AsignarProcedure("select GetDate()", CommandType.Text)
            x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
            Dim _fecha As DateTime = x_datos.Rows(0)(0)
            Return "'" & _fecha.ToString(m_formatofecha) & "'"
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Function getDateTime() As DateTime
        Dim x_datos As New DataTable()
        Try
            DAEnterprise.AsignarProcedure("select GetDate()", CommandType.Text)
            x_datos = DAEnterprise.ExecuteDataSet().Tables(0)
            Dim _fecha As DateTime = x_datos.Rows(0)(0)
            Return _fecha
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region
End Class
