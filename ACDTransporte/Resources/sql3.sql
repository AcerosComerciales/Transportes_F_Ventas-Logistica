<xml>
   <sql>
      <titulo>DTRAN_Rutas.RUTASS_TodosAyuda</titulo>
      <descripcion></descripcion>
      <code>
			SELECT RUTAS_Id As Codigo
				,RUTAS_Nombre As Nombre
	                        ,Rut.UBIGO_CodOrigen
				,Rut.UBIGO_CodDestino
				,UOri.UBIGO_Descripcion As Origen
				,UDes.UBIGO_Descripcion As Destino
				
				,RUTAS_Km As KM
        ,RUTAS_ValorReferencial As ValorReferencial
			FROM Transportes.TRAN_Rutas As Rut
				Inner Join dbo.Ubigeos As UOri On UOri.UBIGO_Codigo = Rut.UBIGO_CodOrigen
				Inner Join dbo.Ubigeos As UDes On UDes.UBIGO_Codigo = Rut.UBIGO_CodDestino
			WHERE 
				{0}
			ORDER BY Nombre
      </code>
   </sql>

    <sql>
      <titulo>DTRAN_Rutas.RUTASS_TodossAyuda</titulo>
      <descripcion></descripcion>
      <code>
			SELECT RUTAS_Id As Codigo
				,RUTAS_Nombre As Nombre
				,Rut.UBIGO_CodOrigen
				,Rut.UBIGO_CodDestino
				,UOri.UBIGO_Descripcion As Origen
				,UDes.UBIGO_Descripcion As Destino
				
				,RUTAS_Km As KM
        ,RUTAS_ValorReferencial As ValorReferencial
			FROM Transportes.TRAN_Rutas As Rut
				Inner Join dbo.Ubigeos As UOri On UOri.UBIGO_Codigo = Rut.UBIGO_CodOrigen
				Inner Join dbo.Ubigeos As UDes On UDes.UBIGO_Codigo = Rut.UBIGO_CodDestino
			WHERE 
				{0}
			ORDER BY Nombre
      </code>
   </sql>

   <sql>
      <titulo>DGenerarGuias.getGuiaTransportista</titulo>
      <descripcion>Obtener la cabecera de la gui atransportista</descripcion>
      <code>
			Select m_tran_guiastransportista.* 
				, Tra.ENTID_RazonSocial As ENTID_Transportista
				, Cond.ENTID_RazonSocial As ENTID_Conductor
				, Cond.ENTID_NroDocumento As ENTID_CondRUC
				, Tra.ENTID_NroDocumento As ENTID_TranRUC
				, SalDist.UBIGO_Descripcion As SalidaDistrito
				, SalProv.UBIGO_Descripcion As SalidaProvincia
				, SalDep.UBIGO_Descripcion As SalidaDepartamento
				, LleDist.UBIGO_Descripcion As LlegadaDistrito
				, LleProv.UBIGO_Descripcion As LlegadaProvincia
				, LleDep.UBIGO_Descripcion As LlegadaDepartamento	
				, Doc.TIPOS_Descripcion As TipoComprobante
				, Right(m_tran_guiastransportista.GTRAN_NroComprobantePago, 10) As NumeroComprobante
				, Veh.VEHIC_Certificado
				, Ran.RANFL_Certificado
				, PCond.CONDU_Licencia
			 From Transportes.TRAN_GuiasTransportista As m_tran_guiastransportista 
				 Inner Join dbo.Entidades As Tra On Tra.ENTID_Codigo = m_tran_guiastransportista.ENTID_CodigoTransportista
				 Inner Join dbo.Entidades As Cond On Cond.ENTID_Codigo = m_tran_guiastransportista.ENTID_CodigoConductor
				 Inner Join [dbo].[Conductores] As PCond On PCond.ENTID_Codigo = ENTID_CodigoConductor
				 <!--Inner Join dbo.Ubigeos As SalDist On SalDist.UBIGO_Codigo = m_tran_guiastransportista.UBIGO_CodigoProveedor
				 Inner Join dbo.Ubigeos As SalProv On SalProv.UBIGO_Codigo = Left(m_tran_guiastransportista.UBIGO_CodigoProveedor, 2)
				 Inner Join dbo.Ubigeos As SalDep On SalDep.UBIGO_Codigo = Left(m_tran_guiastransportista.UBIGO_CodigoProveedor, 5)
				 Inner Join dbo.Ubigeos As LleDist On LleDist.UBIGO_Codigo = m_tran_guiastransportista.UBIGO_CodigoDestinatario 
				 Inner Join dbo.Ubigeos As LleProv On LleProv.UBIGO_Codigo = Left(m_tran_guiastransportista.UBIGO_CodigoDestinatario , 2)
				 Inner Join dbo.Ubigeos As LleDep On LleDep.UBIGO_Codigo = Left(m_tran_guiastransportista.UBIGO_CodigoDestinatario, 5)-->
        Inner Join dbo.Ubigeos As SalDist On SalDist.UBIGO_Codigo =CASE
        WHEN CHARINDEX('.',ISNULL(m_tran_guiastransportista.UBIGO_CodigoProveedor,m_tran_guiastransportista.UBIGO_CodigoRemitente) )>0 THEN
        ISNULL(m_tran_guiastransportista.UBIGO_CodigoProveedor,m_tran_guiastransportista.UBIGO_CodigoRemitente)
        else
        ISNULL(LEFT(m_tran_guiastransportista.UBIGO_CodigoProveedor ,2)+'.'+ SUBSTRING(m_tran_guiastransportista.UBIGO_CodigoProveedor,len(LEFT(m_tran_guiastransportista.UBIGO_CodigoProveedor ,3)),2)+'.'+RIGHT(m_tran_guiastransportista.UBIGO_CodigoProveedor,2),LEFT(m_tran_guiastransportista.UBIGO_CodigoRemitente ,2)+'.'+ SUBSTRING(m_tran_guiastransportista.UBIGO_CodigoRemitente,len(LEFT(m_tran_guiastransportista.UBIGO_CodigoRemitente ,3)),2)+'.'+RIGHT(m_tran_guiastransportista.UBIGO_CodigoRemitente,2))--ISNULL(Guia.UBIGO_CodigoProveedor,Guia.UBIGO_CodigoRemitente)
        end

        Inner Join dbo.Ubigeos As SalProv On SalProv.UBIGO_Codigo = ISNULL(Left(m_tran_guiastransportista.UBIGO_CodigoProveedor, 2),Left(m_tran_guiastransportista.UBIGO_CodigoRemitente, 2))
        Inner Join dbo.Ubigeos As SalDep On SalDep.UBIGO_Codigo = CASE
        WHEN CHARINDEX('.',ISNULL(m_tran_guiastransportista.UBIGO_CodigoProveedor,m_tran_guiastransportista.UBIGO_CodigoRemitente) )>0 THEN
        ISNULL(Left(m_tran_guiastransportista.UBIGO_CodigoProveedor, 5),Left(m_tran_guiastransportista.UBIGO_CodigoRemitente, 5))
        else
        ISNULL(LEFT(m_tran_guiastransportista.UBIGO_CodigoProveedor ,2)+'.'+ SUBSTRING(m_tran_guiastransportista.UBIGO_CodigoProveedor,len(LEFT(m_tran_guiastransportista.UBIGO_CodigoProveedor ,3)),2),LEFT(m_tran_guiastransportista.UBIGO_CodigoRemitente ,2)+'.'+ SUBSTRING(m_tran_guiastransportista.UBIGO_CodigoRemitente,len(LEFT(m_tran_guiastransportista.UBIGO_CodigoRemitente ,3)),2))
        end
        Inner Join dbo.Ubigeos As LleDist On LleDist.UBIGO_Codigo =CASE
        WHEN CHARINDEX('.',m_tran_guiastransportista.UBIGO_CodigoDestinatario )>0 THEN
        ISNULL(m_tran_guiastransportista.UBIGO_CodigoDestinatario ,m_tran_guiastransportista.UBIGO_CodigoRemitente)
        else
        LEFT(m_tran_guiastransportista.UBIGO_CodigoDestinatario ,2)+'.'+ SUBSTRING(m_tran_guiastransportista.UBIGO_CodigoDestinatario,len(LEFT(m_tran_guiastransportista.UBIGO_CodigoDestinatario ,3)),2)+'.'+RIGHT(m_tran_guiastransportista.UBIGO_CodigoDestinatario,2)--Guia.UBIGO_CodigoDestinatario
        end
        Inner Join dbo.Ubigeos As LleProv On LleProv.UBIGO_Codigo = Left(m_tran_guiastransportista.UBIGO_CodigoDestinatario , 2)
        Inner Join dbo.Ubigeos As LleDep On LleDep.UBIGO_Codigo = CASE
        WHEN CHARINDEX('.',m_tran_guiastransportista.UBIGO_CodigoDestinatario )>0 THEN
        Left(m_tran_guiastransportista.UBIGO_CodigoDestinatario, 5)
        else
        LEFT(m_tran_guiastransportista.UBIGO_CodigoDestinatario ,2)+'.'+ SUBSTRING(m_tran_guiastransportista.UBIGO_CodigoDestinatario,len(LEFT(m_tran_guiastransportista.UBIGO_CodigoDestinatario ,3)),2)
        end
        Inner Join Tipos As Doc On Doc.TIPOS_Codigo = ('CPD' + Left(m_tran_guiastransportista.GTRAN_NroComprobantePago, 2))
        Inner Join [Transportes].[TRAN_Vehiculos] As Veh On Veh.VEHIC_Id = m_tran_guiastransportista.VEHIC_Id
        Left Join [Transportes].[TRAN_VehiculosRanflas] As VRa On VRa.VEHIC_Id = Veh.VEHIC_Id And VRa.VEHRN_Estado = 'A'
        Left Join [Transportes].[TRAN_Ranflas] As Ran On Ran.RANFL_Id = Vra.RANFL_Id
        WHERE
        ISNULL(m_TRAN_GuiasTransportista.GTRAN_Codigo, '') = '{0}'
        AND Not ISNULL(m_TRAN_GuiasTransportista.GTRAN_Estado, '') = '{1}'
      </code>
   </sql>
   <sql>
      <titulo>DTRAN_Vehiculos.VEHISS_TodosAyuda</titulo>
      <descripcion>Obtener</descripcion>
      <code>
			SELECT  
				 m_Vehi.VEHIC_Id As Interno
				,TVehi.TIPOS_Descripcion As [T. Vehiculo]
				,TMar.TIPOS_Descripcion As Marca
				,m_Vehi.VEHIC_Codigo As Codigo
				,m_Vehi.VEHIC_Modelo As Modelo
				,m_Vehi.VEHIC_FecAdquisicion As Adquisicion
				,m_Vehi.VEHIC_Placa As Placa
				,m_Vehi.VEHIC_KmActual As [Kilometraje Actual]
				,m_Vehi.VEHIC_KmInicial As [Kilometraje Inicial]
				,m_Vehi.VEHIC_Certificado As Certificado
				,Ran.RANFL_Placa As [Placa Ranfla]
				,TMarR.TIPOS_Descripcion As [Marca Ranfla]
				,Ran.RANFL_Certificado As [Certificado Ranfla]
			 FROM Transportes.TRAN_Vehiculos As m_Vehi
				Inner Join Tipos As TVehi On TVehi.TIPOS_Codigo = m_Vehi.TIPOS_CodTipoVehiculo 
				Inner Join Tipos As TMar On TMar.TIPOS_Codigo = m_Vehi.TIPOS_CodMarca 
				Left Join [Transportes].[TRAN_VehiculosRanflas] As VRa On VRa.VEHIC_Id = m_Vehi.VEHIC_Id And VRa.VEHRN_Estado = 'A'
				Left Join [Transportes].[TRAN_Ranflas] As Ran On Ran.RANFL_Id = Vra.RANFL_Id	 
				Left Join Tipos As TMarR On TMarR.TIPOS_Codigo = Ran.TIPOS_CodMarca 
			 WHERE 
      </code>
   </sql>
   <sql>
      <titulo>DGenerarGuias.CargarGuia</titulo>
      <descripcion></descripcion>
      <code>
			Select IsNull(Guia.GTDET_Cantidad, 0.0) As Entregado, DDocs.DOCCD_Cantidad- IsNull(Guia.GTDET_Cantidad, 0.0) As Diferencia, DDocs.*
					, ARTIC_Descripcion, TIPOS_Descripcion As TIPOS_UnidadMedida
					, TIPOS_DescCorta As TIPOS_UnidadMedidaCorta
					--, Alm.ALMAC_Descripcion
				From Logistica.ABAS_DocsCompraDetalle As DDocs
					Left Join  (
									Select C.GTRAN_NroComprobantePago, D.ARTIC_Codigo, D.GTDET_Peso, Sum(D.GTDET_Cantidad) As GTDET_Cantidad 
										From Transportes.TRAN_GuiasTransportista As C
										Inner Join Transportes.TRAN_GuiasTransportistaDetalles As D On D.GTRAN_Codigo = C.GTRAN_Codigo
									Where C.GTRAN_NroComprobantePago = '{0}' And C.ENTID_Codigo = '{1}'
										And Not C.GTRAN_Estado = 'X'
									Group By C.GTRAN_NroComprobantePago, ARTIC_Codigo, GTDET_Peso
									) As Guia On Guia.GTRAN_NroComprobantePago = DDocs.DOCCO_Codigo And Guia.ARTIC_Codigo = DDocs.ARTIC_Codigo
					Inner Join Articulos As Art On Art.ARTIC_Codigo = DDocs.ARTIC_Codigo
					Inner Join Tipos As TUni On TUni.TIPOS_Codigo = Art.TIPOS_CodUnidadMedida
			 Where DDocs.DOCCO_Codigo = '{0}' And DDocs.ENTID_CodigoProveedor = '{1}'
			Order By DDocs.DOCCD_Item
      </code>
   </sql>
	<sql>
      <titulo>DGenerarGuias.getProveedor</titulo>
      <descripcion></descripcion>
      <code>
         Select 
				--Case When (Select Count(*) From [Logistica].[DIST_DocsTraslados] 
				--			Where DOCVE_Codigo = m_vent_docsventa.DOCCO_Codigo) > 0 Then Convert(Bit, 1) Else Convert(Bit, 0) End As Guias
				  m_vent_docsventa.* , Cli.ENTID_RazonSocial As ENTID_Proveedor
				, TDoc.TIPOS_Descripcion As TIPOS_TipoDocumento
				, TDoc.TIPOS_DescCorta As TIPOS_TipoDocCorta
				, TMon.TIPOS_DescCorta As TIPOS_TipoMoneda
				, TPag.TIPOS_DescCorta As TIPOS_TipoPago
			From Logistica.ABAS_DocsCompra As m_vent_docsventa
				Inner Join dbo.Entidades As Cli On Cli.ENTID_Codigo = m_vent_docsventa.ENTID_CodigoProveedor
				Inner Join dbo.Tipos As TDoc On TDoc.TIPOS_Codigo = m_vent_docsventa.TIPOS_CodTipoDocumento
				Inner Join dbo.Tipos As TMon On TMon.TIPOS_Codigo = m_vent_docsventa.TIPOS_CodTipoMoneda
				Inner Join dbo.Tipos As TPag On TPag.TIPOS_Codigo = m_vent_docsventa.TIPOS_CodTipoPago
      </code>
   </sql>
	<sql>
      <titulo>DGenerarGuias.getProveedor.where</titulo>
      <descripcion></descripcion>
      <code>
		And (Select Sum(IsNull(DetOrd.DOCCD_Cantidad, 0) - IsNull(Det.DDTRA_Cantidad, 0)) As Cantidad
				From Logistica.ABAS_DocsCompraDetalle As DetOrd
					Inner Join Logistica.ABAS_DocsCompra As Cab On Cab.DOCCO_Codigo = DetOrd.DOCCO_Codigo
					Left Join (
						Select ARTIC_Codigo, Sum(Det.GTDET_Cantidad) As DDTRA_Cantidad
							from Transportes.TRAN_GuiasTransportista As Ing
								Inner Join Transportes.TRAN_GuiasTransportistaDetalles As Det
									On Det.GTRAN_Codigo = Ing.GTRAN_Codigo
										And Not IsNull(GTDET_Estado, '') = 'X'
							Where Ing.GTRAN_NroComprobantePago = m_vent_docsventa.DOCCO_Codigo
								And Not Ing.GTRAN_Estado = 'X'
						Group By ARTIC_Codigo
					) As Det 
						On Det.ARTIC_Codigo = DetOrd.ARTIC_Codigo 
					Inner Join Articulos As Art
						On Art.ARTIC_Codigo = DetOrd.ARTIC_Codigo
					Inner Join Tipos As TUni
						On TUni.TIPOS_Codigo = Art.TIPOS_CodUnidadMedida
				Where DetOrd.DOCCO_Codigo = m_vent_docsventa.DOCCO_Codigo) > 0
      </code>
   </sql>
   <sql>
      <titulo>DTRAN_NeumaticosIncidencias.GetIncidencias</titulo>
      <descripcion></descripcion>
      <code>
			select 
				TDoc.TIPOS_DescCorta + ' ' + Doc.DOCUS_Serie + '-' + Right('0000000' + RTrim(Doc.DOCUS_Numero), 7) As Documento
				,Ent.ENTID_RazonSocial
				,TMon.TIPOS_DescCorta As TIPOS_TipoMoneda
				,TInc.TIPOS_Descripcion As TIPOS_TipoIncidencia
				,Inc.* 
			From Transportes.TRAN_NeumaticosIncidencias As Inc
				Left Join Transportes.TRAN_Documentos As Doc On Doc.DOCUS_Codigo = Inc.DOCUS_Codigo
				Left Join Tipos As TDoc On TDoc.TIPOS_Codigo = Doc.TIPOS_CodTipoDocumento
				Left Join Entidades As Ent On Ent.ENTID_Codigo = Doc.ENTID_Codigo
				Inner Join Tipos As TMon On TMon.TIPOS_Codigo = Inc.TIPOS_CodTipoMoneda
				Inner Join Tipos As TInc On TInc.TIPOS_Codigo = Inc.TIPOS_CodTipoIncidencia
			Where {0}
      </code>
   </sql>
	<sql>
      <titulo>DTRAN_VehiculosIncidencias.GetIncidencias</titulo>
      <descripcion></descripcion>
      <code>
			Select TDoc.TIPOS_DescCorta + ' ' + Doc.DOCUS_Serie + '-' + Right('0000000' + RTrim(Doc.DOCUS_Numero), 7) As Documento
					,Ent.ENTID_RazonSocial
					,TMon.TIPOS_DescCorta As TIPOS_TipoMoneda
					,TInc.TIPOS_Descripcion As TIPOS_TipoIncidencia
					,Inc.* 
			From Transportes.TRAN_VehiculosIncidencias As Inc
				Left Join Transportes.TRAN_Documentos As Doc On Doc.DOCUS_Codigo = Inc.DOCUS_Codigo
				Left Join Tipos As TDoc On TDoc.TIPOS_Codigo = Doc.TIPOS_CodTipoDocumento
				Left Join Entidades As Ent On Ent.ENTID_Codigo = Doc.ENTID_Codigo
				Inner Join Tipos As TMon On TMon.TIPOS_Codigo = Inc.TIPOS_CodTipoMoneda
				Inner Join Tipos As TInc On TInc.TIPOS_Codigo = Inc.TIPOS_CodTipoIncidencia
			Where {0}
      </code>
   </sql>
	<sql>
      <titulo>DTRAN_ViajesGastos.GetGastosViaje</titulo>
      <descripcion></descripcion>
      <code>
			Select TDoc.TIPOS_DescCorta + ' ' + Doc.DOCUS_Serie + '-' + Right('0000000' + RTrim(Doc.DOCUS_Numero), 7) As Documento
					,Ent.ENTID_RazonSocial
					,TMon.TIPOS_DescCorta As TIPOS_TipoMoneda
					,TInc.TIPOS_Descripcion As TIPOS_TipoGasto
					,Inc.* 
			From Transportes.TRAN_ViajesGastos As Inc
				Left Join Transportes.TRAN_Documentos As Doc On Doc.DOCUS_Codigo = Inc.DOCUS_Codigo
				Left Join Tipos As TDoc On TDoc.TIPOS_Codigo = Doc.TIPOS_CodTipoDocumento
				Left Join Entidades As Ent On Ent.ENTID_Codigo = Doc.ENTID_Codigo
				Inner Join Tipos As TMon On TMon.TIPOS_Codigo = Inc.TIPOS_CodTipoMoneda
				Inner Join Tipos As TInc On TInc.TIPOS_Codigo = Inc.TIPOS_CodTipoGasto
			Where {0}
      </code>
   </sql>
	<sql>
      <titulo>DTRAN_Viajes.getKmAnterior</titulo>
      <descripcion></descripcion>
      <code>
			Select IsNull(MAX(VIAVE_Kilometraje), 0) As Km From Transportes.TRAN_ViajesVehiculos As Veh
				Inner Join Transportes.TRAN_Viajes As V On V.VIAJE_Id = Veh.VIAJE_Id
			Where Veh.VEHIC_Id = {0} And Veh.VIAJE_Id &lt; {1} And Not V.VIAJE_Estado = 'X'
      </code>
   </sql>
	 <sql>
      <titulo>DTRAN_ViajesIngresos.GetIngresosViaje</titulo>
      <descripcion></descripcion>
      <code>
			Select TDoc.TIPOS_DescCorta + ' ' + Doc.DOCUS_Serie + '-' + Right('0000000' + RTrim(Doc.DOCUS_Numero), 7) As Documento
					,Ent.ENTID_RazonSocial
					,TMon.TIPOS_DescCorta As TIPOS_Moneda
					,Inc.* 
			From Transportes.TRAN_ViajesIngresos As Inc
				Left Join Transportes.TRAN_Documentos As Doc On Doc.DOCUS_Codigo = Inc.DOCUS_Codigo
				Left Join Tipos As TDoc On TDoc.TIPOS_Codigo = Doc.TIPOS_CodTipoDocumento
				Left Join Entidades As Ent On Ent.ENTID_Codigo = Doc.ENTID_Codigo
				Inner Join Tipos As TMon On TMon.TIPOS_Codigo = Inc.TIPOS_CodTipoMoneda
			Where {0}
      </code>
   </sql>
	 <sql>
      <titulo>DTRAN_Viajes.getCorrelativoXvehiculo</titulo>
      <descripcion></descripcion>
      <code>
			Select IsNull(MAX(VIAJE_IdxVehiculo), 0) from Transportes.TRAN_Viajes As V
				Inner Join Transportes.TRAN_VehiculosConductores As VC
					On VC.VHCON_Id = V.VHCON_Id
			Where VEHIC_Id = {0}
      </code>
   </sql>
	 <sql>
      <titulo>DTRAN_Viajes.getCorrelativoXvehiculoMin</titulo>
      <descripcion></descripcion>
      <code>
			Select IsNull(MIN(VIAJE_IdxVehiculo), 0) from Transportes.TRAN_Viajes As V
				Inner Join Transportes.TRAN_VehiculosConductores As VC
					On VC.VHCON_Id = V.VHCON_Id
			Where VEHIC_Id = {0}
      </code>
   </sql>
	<sql>
      <titulo>DTRAN_Viajes.getCorrelativoXConductor</titulo>
      <descripcion></descripcion>
      <code>
			Select IsNull(MAX(VIAJE_IdxConductor), 0) from Transportes.TRAN_Viajes As V
				Inner Join Transportes.TRAN_VehiculosConductores As VC
					On VC.VHCON_Id = V.VHCON_Id
			Where ENTID_Codigo = '{0}'
      </code>
   </sql>
	<sql>
      <titulo>DTRAN_Viajes.getCorrelativoXConductorMin</titulo>
      <descripcion></descripcion>
      <code>
			Select IsNull(MIN(VIAJE_IdxConductor), 0) from Transportes.TRAN_Viajes As V
				Inner Join Transportes.TRAN_VehiculosConductores As VC
					On VC.VHCON_Id = V.VHCON_Id
			Where ENTID_Codigo = '{0}'
				And Not VIAJE_Estado = 'X'
      </code>
   </sql>
	<sql>
      <titulo>DTRAN_VehiculosConductores.VHCOSS_TodosAyuda</titulo>
      <descripcion></descripcion>
      <code>
		SELECT 
			VCond.VHCON_Id As Interno
			,Vehi.VEHIC_Id As [Cod. Vehiculo]
			,Vehi.VEHIC_Placa As Placa
	                ,Vehi.VEHIC_Certificado
			,Vehi.VEHIC_CertificadoAdic
			,TMar.TIPOS_Descripcion As Marca
			,Vehi.VEHIC_Modelo As Modelo
			,Ent.ENTID_Nombres As Conductor
			,Cond.CONDU_Licencia As Licencia
			,Cond.CONDU_Sigla As Sigla
			,Ent.ENTID_Codigo As Codigo
		From Transportes.TRAN_VehiculosConductores As VCond
			Inner Join Transportes.TRAN_Vehiculos As Vehi On Vehi.VEHIC_Id = VCond.VEHIC_Id
			Inner Join dbo.Entidades As Ent On Ent.ENTID_Codigo = VCond.ENTID_Codigo
			Left Join dbo.Conductores As Cond On Cond.ENTID_Codigo = VCond.ENTID_Codigo
			Inner Join Tipos As TMar On TMar.TIPOS_Codigo = Vehi.TIPOS_CodMarca
		Where
			{0}
      </code>
   </sql>
	<sql>
      <titulo>DTRAN_Viajes.getLiquidados</titulo>
      <descripcion></descripcion>
      <code>
		Select m_tran_viajes.* , VCond.ENTID_Codigo As ENTID_Codigo
			, Vehi.VEHIC_Placa As VEHIC_Placa
			, Vehi.VEHIC_Placa As TIPOS_Marca
			, Vehi.VEHIC_Certificado As VEHIC_Certificado
			, Cond.ENTID_RazonSocial As ENTID_Nombres
			, VRan.VEHRN_FecAsignacion As VEHRN_FecAsignacion
			, Ran.RANFL_Placa As RANFL_Placa
		Into #Tmp
		From Transportes.TRAN_Viajes As m_tran_viajes 
		 Inner Join Transportes.TRAN_VehiculosConductores As VCond On VCond.VHCON_Id = m_tran_viajes.VHCON_Id
		 Inner Join Transportes.TRAN_Vehiculos As Vehi On Vehi.VEHIC_Id = VCond.VEHIC_Id
		 Inner Join dbo.Entidades As Cond On Cond.ENTID_Codigo = VCond.ENTID_Codigo
		 Inner Join Transportes.TRAN_VehiculosRanflas As VRan On VRan.VEHIC_Id = VCond.VEHIC_Id
		 Inner Join Transportes.TRAN_Ranflas As Ran On Ran.RANFL_Id = VRan.RANFL_Id 
		 WHERE  {0}

		Select * From #Tmp

		Select Fle.*, Ent.ENTID_RazonSocial, Ing.VINGR_Id From Transportes.TRAN_Fletes As Fle
			Inner Join Entidades As Ent On Ent.ENTID_Codigo = Fle.ENTID_Codigo
			Left Join Transportes.TRAN_ViajesIngresos As Ing On Ing.VIAJE_Id = Fle.VIAJE_Id And Ing.FLETE_Id = Fle.FLETE_Id
		Where Fle.VIAJE_Id In (Select VIAJE_Id From #Tmp)

		drop table #Tmp

      </code>
   </sql>
	<sql>
      <titulo>DTRAN_ViajesGuiasRemision.ObtenerGuias</titulo>
      <descripcion></descripcion>
      <code>
			Select 
				Gr.VIAJE_Id
				,GR.FLETE_Id
				,TDoc.TIPOS_DescCorta As TIPOS_TipoDocumento
				,Right(Left(GR.GTRAN_Codigo, 5), 3) As Serie
				,Right(GR.GTRAN_Codigo, 7) As Numero
				,Ent.ENTID_RazonSocial As Empresa
				,EFle.ENTID_RazonSocial As Flete
				,GR.VEGRE_Observacion
				,GR.ENTID_Codigo
				,GR.GTRAN_Codigo
				,Convert(Bit, 1) As Seleccion
			Into #Guias
			From Transportes.TRAN_ViajesGuiasRemision As GR
				Inner Join Tipos As TDoc On TDoc.TIPOS_Codigo = GR.TIPOS_CodTipoDocumento
				Inner Join Entidades As Ent On Ent.ENTID_Codigo = GR.ENTID_Codigo
				Inner Join Transportes.TRAN_Fletes As Fle On Fle.FLETE_Id = GR.FLETE_Id
				Inner Join Entidades As EFle On EFle.ENTID_Codigo = Fle.ENTID_Codigo
			Where Gr.FLETE_Id In ({0})

			Select Distinct Empresa, ENTID_Codigo From #Guias
			Select * From #Guias
      </code>
   </sql>
	<sql>
      <titulo>GetInventarios.Todos</titulo>
      <descripcion></descripcion>
      <code>
			Select 
				Right(TIPOS_Codigo, 3) As Codigo
				,TIPOS_Descripcion As Descripción
				,TIPOS_DescCorta As Sigla
				,TIPOS_Codigo As Interno
			From Tipos
			where TIPOS_Codigo Like 'AVI%'
      </code>
   </sql>
	<sql>
      <titulo>GetInventarios.Seleccionados</titulo>
      <descripcion></descripcion>
      <code>
			Select 
				Right(TIPOS_Codigo, 3) As Codigo
				,TIPOS_Descripcion As Descripción
				,TIPOS_DescCorta As Sigla
				,TIPOS_Codigo As Interno
			From Tipos
			where TIPOS_Codigo Like 'AVI%'
				And Not TIPOS_Codigo In ({0})
      </code>
   </sql>
	<sql>
      <titulo>Obtener</titulo>
      <descripcion></descripcion>
      <code>

      </code>
   </sql>
</xml>