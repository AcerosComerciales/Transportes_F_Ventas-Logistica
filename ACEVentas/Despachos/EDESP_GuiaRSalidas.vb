Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class EDESP_GuiaRSalidas

#Region " Campos "
	
#End Region

#Region" Constructores "
   Public Sub New(ByVal x_guiar_codigo As String, ByVal x_saldp_id As Integer, ByVal x_vehic_id As Long)
      Me.New()
      m_guiar_codigo = x_guiar_codigo
      m_salid_id = x_saldp_id
      m_vehic_id = x_vehic_id
      Instanciar(ACFramework.ACEInstancia.Nuevo)
   End Sub
#End Region

#Region" Propiedades "
	
#End Region

#Region " Eventos "
	
#End Region

#Region " Metodos "
	
#End Region

End Class

