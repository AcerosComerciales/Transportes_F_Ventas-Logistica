Imports ACBVentas
Imports ACEVentas
Imports ACFramework
Imports CrystalDecisions
Imports CrystalDecisions.CrystalReports.Engine

Imports C1.Win.C1FlexGrid


Public Class RReportView

   Sub New(ByVal dtDatos As CRGuiaTransportista)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      Try
         crvReporte.ReportSource = dtDatos
      Catch ex As Exception

      End Try
   End Sub

   Sub New(ByVal dtDatos As CRCotizacionAC)
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
      Try
         crvReporte.ReportSource = dtDatos
      Catch ex As Exception

      End Try
   End Sub

   Public Sub New(ByVal dtDatos As ReportDocument)

      ' This call is required by the designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      Try
         crvReporte.ReportSource = dtDatos
         crvReporte.Zoom(100)


      Catch ex As Exception

      End Try
   End Sub

   Private Sub ReportView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

   End Sub
End Class