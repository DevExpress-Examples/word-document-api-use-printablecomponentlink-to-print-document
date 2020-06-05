Imports System
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraRichEdit
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraPrintingLinks

Namespace RichEdit_PrintingSystem
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub
		#Region "#printfromserver"
		Private Sub btn_PrintFromServer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_PrintFromServer.Click
			If Not Me.btn_PrintFromServer.IsHandleCreated Then Return

			Dim srv As New RichEditDocumentServer()
			srv.LoadDocument("Grimm.docx", DocumentFormat.OpenXml)
			' Insert a field displaying the current date/time into the document header.
			srv.BeginUpdate()
			Dim _header As SubDocument = srv.Document.Sections(0).BeginUpdateHeader()
			_header.Fields.Create(_header.Range.Start,"DATE \@ ""dddd, MMMM dd, yyyy  HH:mm:ss"" \MERGEFORMAT")
			_header.Paragraphs(0).Alignment = ParagraphAlignment.Right
			srv.Document.Sections(0).EndUpdateHeader(_header)
			' Specify page margins, orientation, etc.
			SetPrintOptions(srv)
			srv.EndUpdate()
			' Display field values instead of code.
			srv.Options.MailMerge.ViewMergedData = True
			' Create a printable link to print a document.
			PrintViaLink(srv)
		End Sub
		#End Region ' #printfromserver
		#Region "#setprintoptions"
		Private Shared Sub SetPrintOptions(ByVal richedit As IRichEditDocumentServer)
			For Each _section As Section In richedit.Document.Sections
				_section.Page.PaperKind = System.Drawing.Printing.PaperKind.A4
				_section.Page.Landscape = False
				_section.Margins.Left = 150F
				_section.Margins.Right = 150F
				_section.Margins.Top = 50F
				_section.Margins.Bottom = 50F
				_section.PageNumbering.NumberingFormat = NumberingFormat.CardinalText
				_section.PageNumbering.FirstPageNumber = 0
			Next _section
		End Sub
		#End Region ' #setprintoptions
		#Region "#printvialink"
		Private Shared Sub PrintViaLink(ByVal srv As RichEditDocumentServer)
			If Not srv.IsPrintingAvailable Then
				Return
			End If
			Using ps As New PrintingSystemBase()
			Using link As New PrintableComponentLinkBase(ps)
				link.Component = srv
				' Disable warnings.
				ps.ShowMarginsWarning = False
				ps.ShowPrintStatusDialog = False
				' Find a printer containing 'Canon' in its name.
				Dim printerName As String = String.Empty
				For i As Integer = 0 To PrinterSettings.InstalledPrinters.Count - 1
					Dim pName As String = PrinterSettings.InstalledPrinters(i)
					If pName.Contains("PDF") Then
						printerName = pName
						Exit For
					End If
				Next i

				'Run document creaion
				link.CreateDocument()

				' Print to the specified printer.
				Dim tool As New PrintToolBase(ps)
				tool.Print(printerName)
			End Using
			End Using
		End Sub
		#End Region ' #printvialink
	End Class
End Namespace
