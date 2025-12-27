Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic

Imports ACFramework
Imports DAConexion
Imports ACETransporte
Imports ACEVentas

Partial Public Class DTRAN_VehiculosConductores

#Region " Constructores "
	
#End Region

#Region " Procedimientos Almacenados "
   Public Function VHCOSS_Todos(ByRef listETRAN_VehiculosConductores As List(Of ETRAN_VehiculosConductores), ByVal x_opcion As Boolean, ByVal x_tipoentidad As EEntidades.TipoEntidad) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_opcion, x_tipoentidad), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New ETRAN_VehiculosConductores())
               While reader.Read()
                  Dim e_tran_vehiculosconductores As New ETRAN_VehiculosConductores()
                  _utilitarios.ACCargarEsquemas(reader, e_tran_vehiculosconductores)
                  e_tran_vehiculosconductores.Instanciar(ACEInstancia.Consulta)
                  listETRAN_VehiculosConductores.Add(e_tran_vehiculosconductores)
               End While
               Return True
            Else
               Return False
            End If
         End Using
      Catch ex As Exception
         Throw ex
      End Try
   End Function


    Public function BuscarConductorXNombre (ByRef listETRAN_VehiculosConductores As List(Of ETRAN_VehiculosConductores), ByVal x_vehic_id As Long, ByVal x_opcion As Boolean, ByVal x_estado As Boolean, ByVal x_tipoentidad As EEntidades.TipoEntidad,byval x_nombre As String ) As Boolean

         Try
         DAEnterprise.AsignarProcedure(getSelectForName(x_vehic_id, x_opcion, x_estado, x_tipoentidad,x_nombre), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New ETRAN_VehiculosConductores())
               While reader.Read()
                  Dim e_tran_vehiculosconductores As New ETRAN_VehiculosConductores()
                  _utilitarios.ACCargarEsquemas(reader, e_tran_vehiculosconductores)
                  e_tran_vehiculosconductores.Instanciar(ACEInstancia.Consulta)
                  listETRAN_VehiculosConductores.Add(e_tran_vehiculosconductores)
               End While
               Return True
            Else
               Return False
            End If
         End Using
      Catch ex As Exception
         Throw ex
      End Try


    End function


   Public Function VHCOSS_Todos(ByRef listETRAN_VehiculosConductores As List(Of ETRAN_VehiculosConductores), ByVal x_vehic_id As Long, ByVal x_opcion As Boolean, ByVal x_estado As Boolean, ByVal x_tipoentidad As EEntidades.TipoEntidad) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAll(x_vehic_id, x_opcion, x_estado, x_tipoentidad), CommandType.Text)
         Using reader As DbDataReader = DAEnterprise.ExecuteDataReader()
            If reader.HasRows Then
               Dim _utilitarios As New ACEsquemas(New ETRAN_VehiculosConductores())
               While reader.Read()
                  Dim e_tran_vehiculosconductores As New ETRAN_VehiculosConductores()
                  _utilitarios.ACCargarEsquemas(reader, e_tran_vehiculosconductores)
                  e_tran_vehiculosconductores.Instanciar(ACEInstancia.Consulta)
                  listETRAN_VehiculosConductores.Add(e_tran_vehiculosconductores)
               End While
               Return True
            Else
               Return False
            End If
         End Using
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function VHCOSS_TodosAyuda(ByRef dtETRAN_VehiculosConductores As DataTable, ByVal x_where As Hashtable) As Boolean
      Try
         DAEnterprise.AsignarProcedure(getSelectAyuda(x_where), CommandType.Text)
         dtETRAN_VehiculosConductores = DAEnterprise.ExecuteDataSet().Tables(0)
         Return dtETRAN_VehiculosConductores.Rows.Count > 0
      Catch ex As Exception
         Throw ex
      End Try
   End Function

#Region "Procedimientos Adicionales "
   Public Function getSelectAll(ByVal x_opcion As Boolean, ByVal x_tipoentidad As EEntidades.TipoEntidad) As String
      Dim sql As String
      Try
         sql = "select * from Entidades As Ent Inner Join EntidadesRoles As ETip On ETip.ENTID_Codigo = Ent.ENTID_Codigo And ETip.ROLES_Id = {0} Where {1} Ent.ENTID_Codigo In (Select ENTID_Codigo From Transportes.TRAN_VehiculosConductores Where VHCON_Estado In ('A'))"
         Return String.Format(sql, New Object() {x_tipoentidad.GetHashCode.ToString(), IIf(x_opcion, "", " Not ")})
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function getSelectAll(ByVal x_vehic_id As Long, ByVal x_opcion As Boolean, ByVal x_estado As Boolean, ByVal x_tipoentidad As EEntidades.TipoEntidad) As String
      Dim sql As String = ""
      Try
         sql = " Select * From Entidades As Ent Inner Join EntidadesRoles As ETip On ETip.ENTID_Codigo = Ent.ENTID_Codigo And ETip.ROLES_Id = {0} Inner Join Transportes.TRAN_VehiculosConductores As VCon On {1} VCon.ENTID_Codigo = Ent.ENTID_Codigo And VCon.VHCON_Estado {2} In ('A') Where VCon.VEHIC_Id = {3} "
         sql = String.Format(sql, New Object() {x_tipoentidad.GetHashCode.ToString(), IIf(x_opcion, "", " Not "), IIf(x_estado, "", " Not "), x_vehic_id.ToString()})
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
      Public Function getSelectForName(Byval x_vehic_id As Long , Byval x_opcion As Boolean , Byval x_estado As Boolean  , Byval x_tipoentidad As EEntidades.TipoEntidad,Byval x_Texto As String) As String 
        Dim sql As String = "" 
        Try
            sql = "Select * From Entidades As Ent Inner Join EntidadesRoles As ETip On ETip.ENTID_Codigo = Ent.ENTID_Codigo And ETip.ROLES_Id = {0} Inner Join Transportes.TRAN_VehiculosConductores As VCon On {1} VCon.ENTID_Codigo = Ent.ENTID_Codigo And VCon.VHCON_Estado {2} Not In ('A') Where VCon.VEHIC_Id = {3} and Ent.ENTID_Nombres like '%' + '{4}' + '%'"
            sql = String.Format(sql,New Object() {x_tipoentidad.GetHashCode.toString(), IIf(x_opcion,"","Not ") , IIf(x_estado, "" , "Not"), x_vehic_id.ToString() , x_Texto.ToString()})
            Return sql 
        Catch ex As Exception
            Throw ex 
        End Try



    End Function

   Public Function getSelectAyuda(ByVal x_where As Hashtable) As String
      Dim sql As String = ""
      Try
         App.Inicializar()
         Dim _where As New ACGenerador(Of ETRAN_VehiculosConductores)(m_formatofecha)
         sql = String.Format(App.Hash("DTRAN_VehiculosConductores.VHCOSS_TodosAyuda").ToString(), _where.getWhere(x_where, True))
         Return sql
      Catch ex As Exception
         Throw ex
      End Try
   End Function
#End Region
#End Region

End Class

