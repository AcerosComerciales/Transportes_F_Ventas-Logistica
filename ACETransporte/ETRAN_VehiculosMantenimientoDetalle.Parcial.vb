Imports System
Imports System.Data
Imports System.Data.Common
Imports System.Collections.Generic
Imports System.Xml
Imports ACFramework

Partial Public Class ETRAN_VehiculosMantenimientoDetalle

#Region " Campos "
	
	Private m_vehic_id As Long
	Private m_vman_item As Long
	Private m_vmdet_item As Short
	Private m_pieza_id As Long
	Private m_tipos_codtiporepuesto As String
	Private m_vmdet_cantidad As Short
	Private m_vmdet_responsable As String
	Private m_vmdet_procedimiento As String
	Private m_vmdet_estado As String
	Private m_docus_codigo As String
	Private m_entid_codigo As String
	Private m_dcdet_item As Short
	Private m_vmdet_usrcrea As String
	Private m_vmdet_feccrea As Date
	Private m_vmdet_usrmod As String
    Private m_vmdet_fecmod As Date
    'Espacio solo para mostrar datos 
    Private m_vehic_placa As String
    Private m_vman_observaciones As String
    Private m_entid_razonsocial As String

    Private m_dcdet_precio As Decimal
    Private m_dcdet_descuento As Decimal
    Private m_dcdet_importe As Decimal
    Private m_dcdet_subimporte As Decimal

    '

    Private m_nuevo As Boolean
	Private m_modificado As Boolean
	Private m_eliminado As Boolean

	Private m_hash As Hashtable
#End Region

#Region" Constructores "
	
	Public Sub New()

		Try
			Dim _obj As Object = ACETransporte.My.Resources.xmlTRAN_VehiculosMantenimientoDetalle
			Dim _xml As New XmlDocument
			_xml.LoadXml(_obj)
			If IsNothing(m_hash) Then
				m_hash = New Hashtable()
				Dim cPlantilla As XmlNodeList = _xml.GetElementsByTagName("Tabla")
				Dim cCampos As XmlNodeList = CType(cPlantilla(0), XmlElement).GetElementsByTagName("Campos")
				Dim Campo As XmlNodeList = CType(cCampos(0), XmlElement).GetElementsByTagName("CCampo")
				For Each Item As XmlElement In Campo
					m_hash.Add(Item.InnerText.ToString(), New CCampo(Item.GetAttribute("xmlns"), IIf(Item.GetAttribute("Identity") = "1", True, False), IIf(Item.GetAttribute("ForeignKey") = "1", True, False), IIf(Item.GetAttribute("PrimaryKey") = "1", True, False)))
				Next
			End If
		Catch ex As Exception
			Throw ex
		End Try
	End Sub

#End Region

#Region " Propiedades "
    'SOLO DE LECTURA OJO 
    Public Property VEHIC_Placa() As String
        Get
            Return m_vehic_placa
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_vehic_placa) Then
                If Not m_vehic_placa.Equals(value) Then
                    m_vehic_placa = value
                    OnVEHIC_PlacaChanged(m_vehic_placa, EventArgs.Empty)
                End If
            Else
                m_vehic_placa = value
                OnVEHIC_PlacaChanged(m_vehic_placa, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property VMAN_Observaciones() As String
        Get
            Return m_vman_observaciones
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_vman_observaciones) Then
                If Not m_vman_observaciones.Equals(value) Then
                    m_vman_observaciones = value
                    OnVMAN_ObservacionesChanged(m_vman_observaciones, EventArgs.Empty)
                End If
            Else
                m_vman_observaciones = value
                OnVMAN_ObservacionesChanged(m_vman_observaciones, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property DCDET_Precio() As Decimal
        Get
            Return m_dcdet_precio
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_dcdet_precio) Then
                If Not m_dcdet_precio.Equals(value) Then
                    m_dcdet_precio = value
                    OnVMAN_ObservacionesChanged(m_vman_observaciones, EventArgs.Empty)
                End If
            Else
                m_dcdet_precio = value
                OnVMAN_ObservacionesChanged(m_vman_observaciones, EventArgs.Empty)
            End If
        End Set
    End Property
    Public Property DCDET_Descuento() As Decimal
        Get
            Return m_dcdet_descuento
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_dcdet_descuento) Then
                If Not m_dcdet_descuento.Equals(value) Then
                    m_dcdet_descuento = value
                    OnVMAN_ObservacionesChanged(m_vman_observaciones, EventArgs.Empty)
                End If
            Else
                m_dcdet_descuento = value
                OnVMAN_ObservacionesChanged(m_vman_observaciones, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DCDET_Importe() As Decimal
        Get
            Return m_dcdet_importe
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_dcdet_importe) Then
                If Not m_dcdet_importe.Equals(value) Then
                    m_dcdet_importe = value
                    OnVMAN_ObservacionesChanged(m_dcdet_importe, EventArgs.Empty)
                End If
            Else
                m_dcdet_importe = value
                OnVMAN_ObservacionesChanged(m_vman_observaciones, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property DCDET_SubImporte() As Decimal
        Get
            Return m_dcdet_subimporte
        End Get
        Set(ByVal value As Decimal)
            If Not IsNothing(m_dcdet_subimporte) Then
                If Not m_dcdet_subimporte.Equals(value) Then
                    m_dcdet_subimporte = value
                    OnVMAN_ObservacionesChanged(m_dcdet_subimporte, EventArgs.Empty)
                End If
            Else
                m_dcdet_subimporte = value
                OnVMAN_ObservacionesChanged(m_vman_observaciones, EventArgs.Empty)
            End If
        End Set
    End Property


    '============================================================================



    Public Property ENTID_RazonSocial() As String
        Get
            Return m_entid_razonsocial
        End Get
        Set(ByVal value As String)
            If Not IsNothing(m_entid_razonsocial) Then
                If Not m_vman_observaciones.Equals(value) Then
                    m_entid_razonsocial = value
                    OnENTID_RazonSocialChanged(m_entid_razonsocial, EventArgs.Empty)
                End If
            Else
                m_entid_razonsocial = value
                OnENTID_RazonSocialChanged(m_entid_razonsocial, EventArgs.Empty)
            End If
        End Set
    End Property

    Public Property VEHIC_Id() As Long
		Get
			return m_vehic_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_vehic_id) Then
				If Not m_vehic_id.Equals(value) Then
					m_vehic_id = value
					OnVEHIC_IdChanged(m_vehic_id, EventArgs.Empty)
				End If
			Else
				m_vehic_id = value
				OnVEHIC_IdChanged(m_vehic_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VMAN_Item() As Long
		Get
			return m_vman_item
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_vman_item) Then
				If Not m_vman_item.Equals(value) Then
					m_vman_item = value
					OnVMAN_ItemChanged(m_vman_item, EventArgs.Empty)
				End If
			Else
				m_vman_item = value
				OnVMAN_ItemChanged(m_vman_item, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VMDET_Item() As Short
		Get
			return m_vmdet_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_vmdet_item) Then
				If Not m_vmdet_item.Equals(value) Then
					m_vmdet_item = value
					OnVMDET_ItemChanged(m_vmdet_item, EventArgs.Empty)
				End If
			Else
				m_vmdet_item = value
				OnVMDET_ItemChanged(m_vmdet_item, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property PIEZA_Id() As Long
		Get
			return m_pieza_id
		End Get
		Set(ByVal value As Long)
			If Not IsNothing(m_pieza_id) Then
				If Not m_pieza_id.Equals(value) Then
					m_pieza_id = value
					OnPIEZA_IdChanged(m_pieza_id, EventArgs.Empty)
				End If
			Else
				m_pieza_id = value
				OnPIEZA_IdChanged(m_pieza_id, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property TIPOS_CodTipoRepuesto() As String
		Get
			return m_tipos_codtiporepuesto
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_tipos_codtiporepuesto) Then
				If Not m_tipos_codtiporepuesto.Equals(value) Then
					m_tipos_codtiporepuesto = value
					OnTIPOS_CodTipoRepuestoChanged(m_tipos_codtiporepuesto, EventArgs.Empty)
				End If
			Else
				m_tipos_codtiporepuesto = value
				OnTIPOS_CodTipoRepuestoChanged(m_tipos_codtiporepuesto, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VMDET_Cantidad() As Short
		Get
			return m_vmdet_cantidad
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_vmdet_cantidad) Then
				If Not m_vmdet_cantidad.Equals(value) Then
					m_vmdet_cantidad = value
					OnVMDET_CantidadChanged(m_vmdet_cantidad, EventArgs.Empty)
				End If
			Else
				m_vmdet_cantidad = value
				OnVMDET_CantidadChanged(m_vmdet_cantidad, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VMDET_Responsable() As String
		Get
			return m_vmdet_responsable
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vmdet_responsable) Then
				If Not m_vmdet_responsable.Equals(value) Then
					m_vmdet_responsable = value
					OnVMDET_ResponsableChanged(m_vmdet_responsable, EventArgs.Empty)
				End If
			Else
				m_vmdet_responsable = value
				OnVMDET_ResponsableChanged(m_vmdet_responsable, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VMDET_Procedimiento() As String
		Get
			return m_vmdet_procedimiento
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vmdet_procedimiento) Then
				If Not m_vmdet_procedimiento.Equals(value) Then
					m_vmdet_procedimiento = value
					OnVMDET_ProcedimientoChanged(m_vmdet_procedimiento, EventArgs.Empty)
				End If
			Else
				m_vmdet_procedimiento = value
				OnVMDET_ProcedimientoChanged(m_vmdet_procedimiento, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VMDET_Estado() As String
		Get
			return m_vmdet_estado
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_vmdet_estado) Then
				If Not m_vmdet_estado.Equals(value) Then
					m_vmdet_estado = value
					OnVMDET_EstadoChanged(m_vmdet_estado, EventArgs.Empty)
				End If
			Else
				m_vmdet_estado = value
				OnVMDET_EstadoChanged(m_vmdet_estado, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DOCUS_Codigo() As String
		Get
			return m_docus_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_docus_codigo) Then
				If Not m_docus_codigo.Equals(value) Then
					m_docus_codigo = value
					OnDOCUS_CodigoChanged(m_docus_codigo, EventArgs.Empty)
				End If
			Else
				m_docus_codigo = value
				OnDOCUS_CodigoChanged(m_docus_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property ENTID_Codigo() As String
		Get
			return m_entid_codigo
		End Get
		Set(ByVal value As String)
			If Not IsNothing(m_entid_codigo) Then
				If Not m_entid_codigo.Equals(value) Then
					m_entid_codigo = value
					OnENTID_CodigoChanged(m_entid_codigo, EventArgs.Empty)
				End If
			Else
				m_entid_codigo = value
				OnENTID_CodigoChanged(m_entid_codigo, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property DCDET_Item() As Short
		Get
			return m_dcdet_item
		End Get
		Set(ByVal value As Short)
			If Not IsNothing(m_dcdet_item) Then
				If Not m_dcdet_item.Equals(value) Then
					m_dcdet_item = value
					OnDCDET_ItemChanged(m_dcdet_item, EventArgs.Empty)
				End If
			Else
				m_dcdet_item = value
				OnDCDET_ItemChanged(m_dcdet_item, EventArgs.Empty)
			End If
		End Set
	End Property

	Public Property VMDET_UsrCrea() As String
		Get
			return m_vmdet_usrcrea
		End Get
		Set(ByVal value As String)
			m_vmdet_usrcrea = value
		End Set
	End Property

	Public Property VMDET_FecCrea() As Date
		Get
			return m_vmdet_feccrea
		End Get
		Set(ByVal value As Date)
			m_vmdet_feccrea = value
		End Set
	End Property

	Public Property VMDET_UsrMod() As String
		Get
			return m_vmdet_usrmod
		End Get
		Set(ByVal value As String)
			m_vmdet_usrmod = value
		End Set
	End Property

	Public Property VMDET_FecMod() As Date
		Get
			return m_vmdet_fecmod
		End Get
		Set(ByVal value As Date)
			m_vmdet_fecmod = value
		End Set
	End Property

	#Region " Propiedades de Solo Lectura "

	Public ReadOnly Property Nuevo() As Boolean
		Get
			return m_nuevo
		End Get
	End Property

	Public ReadOnly Property Modificado() As Boolean
		Get
			return m_modificado
		End Get
	End Property

	Public ReadOnly Property Eliminado() As Boolean
		Get
			return m_eliminado
		End Get
	End Property

	Public ReadOnly Property Hash() As Hashtable
		Get
			return m_hash
		End Get
	End Property

	Public Shared ReadOnly Property Tabla() As String
		Get
			Return "TRAN_VehiculosMantenimientoDetalle"
		End Get
	End Property

	Public Shared ReadOnly Property Esquema() As String
		Get
			Return "Transportes"
		End Get
	End Property

#End Region

#End Region

#Region " Eventos "

    Public Event VEHIC_PlacaChanged As EventHandler
    Public Event VMAN_ObservacionesChanged As EventHandler
    Public Event ENTID_RazonSocialChanged As EventHandler
    Public Event DCDET_PrecioChanged As EventHandler
    Public Event DCDET_DescuentoChanged As EventHandler
    Public Event DCDET_ImporteChanged As EventHandler
    Public Event DCDET_SubImporteChanged As EventHandler
    Public Event VEHIC_IdChanged As EventHandler
	Public Event VMAN_ItemChanged As EventHandler
	Public Event VMDET_ItemChanged As EventHandler
    Public Event PIEZA_IdChanged As EventHandler
    Public Event PIEZA_CodigoChanged As EventHandler
    Public Event TIPOS_CodTipoRepuestoChanged As EventHandler
	Public Event VMDET_CantidadChanged As EventHandler
	Public Event VMDET_ResponsableChanged As EventHandler
	Public Event VMDET_ProcedimientoChanged As EventHandler
	Public Event VMDET_EstadoChanged As EventHandler
	Public Event DOCUS_CodigoChanged As EventHandler
	Public Event ENTID_CodigoChanged As EventHandler
    Public Event DCDET_ItemChanged As EventHandler

    Public Sub OnVEHIC_PlacaChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent VEHIC_PlacaChanged(sender, e)
    End Sub

    Public Sub OnVMAN_ObservacionesChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent VMAN_ObservacionesChanged(sender, e)
    End Sub
    Public Sub OnDCDET_PrecioChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DCDET_PrecioChanged(sender, e)
    End Sub
    Public Sub OnDCDET_DescuentoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DCDET_DescuentoChanged(sender, e)
    End Sub
    Public Sub OnDCDET_ImporteChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DCDET_ImporteChanged(sender, e)
    End Sub
    Public Sub OnDCDET_SubImporteChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent DCDET_SubImporteChanged(sender, e)
    End Sub


    Public Sub OnENTID_RazonSocialChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent ENTID_RazonSocialChanged(sender, e)
    End Sub
    Public Sub OnVEHIC_IdChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VEHIC_IdChanged(sender, e)
	End Sub

	Public Sub OnVMAN_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VMAN_ItemChanged(sender, e)
	End Sub

	Public Sub OnVMDET_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VMDET_ItemChanged(sender, e)
	End Sub

    Public Sub OnPIEZA_IdChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PIEZA_IdChanged(sender, e)
    End Sub
    Public Sub OnPIEZA_CodigoChanged(ByVal sender As Object, ByVal e As EventArgs)
        ActualizarInstancia()
        RaiseEvent PIEZA_CodigoChanged(sender, e)
    End Sub

    Public Sub OnTIPOS_CodTipoRepuestoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent TIPOS_CodTipoRepuestoChanged(sender, e)
	End Sub

	Public Sub OnVMDET_CantidadChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VMDET_CantidadChanged(sender, e)
	End Sub

	Public Sub OnVMDET_ResponsableChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VMDET_ResponsableChanged(sender, e)
	End Sub

	Public Sub OnVMDET_ProcedimientoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VMDET_ProcedimientoChanged(sender, e)
	End Sub

	Public Sub OnVMDET_EstadoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent VMDET_EstadoChanged(sender, e)
	End Sub

	Public Sub OnDOCUS_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DOCUS_CodigoChanged(sender, e)
	End Sub

	Public Sub OnENTID_CodigoChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent ENTID_CodigoChanged(sender, e)
	End Sub

	Public Sub OnDCDET_ItemChanged(ByVal sender As object, ByVal e As EventArgs)
		ActualizarInstancia()
		RaiseEvent DCDET_ItemChanged(sender, e)
	End Sub


#End Region

#Region " Metodos "
	
	Public Sub Instanciar(ByVal x_instancia As ACEInstancia)
		Select Case x_instancia
			Case ACEInstancia.Consulta
				m_nuevo = False
				m_modificado = False
				m_eliminado = False
			Case ACEInstancia.Nuevo
				m_nuevo = True
				m_modificado = False
				m_eliminado = False
			Case ACEInstancia.Modificado
				m_nuevo = False
				m_modificado = True
				m_eliminado = False
			Case ACEInstancia.Eliminado
				m_nuevo = False
				m_modificado = False
				m_eliminado = True
		End Select
	End Sub

	Public Sub ActualizarInstancia()
		If Not Nuevo Then
			If Not Eliminado Then
				Instanciar(ACEInstancia.Modificado)
			End If
		End If
	End Sub

#End Region

End Class

