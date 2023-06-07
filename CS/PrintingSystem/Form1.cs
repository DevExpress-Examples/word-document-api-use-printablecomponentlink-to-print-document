using System;
using System.Windows.Forms;
using System.Drawing.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraPrintingLinks;

namespace RichEdit_PrintingSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region #printfromserver
        private void btn_PrintFromServer_Click(object sender, EventArgs e)
        {
            RichEditDocumentServer srv = new RichEditDocumentServer();
            srv.LoadDocument("Grimm.docx", DocumentFormat.OpenXml);
            // Insert a field displaying the current date/time into the document header.
            srv.BeginUpdate();
            SubDocument  _header = srv.Document.Sections[0].BeginUpdateHeader();
            _header.Fields.Create(_header.Range.Start,"DATE \\@ \"dddd, MMMM dd, yyyy  HH:mm:ss\" \\MERGEFORMAT");
            _header.Paragraphs[0].Alignment = ParagraphAlignment.Right;
            srv.Document.Sections[0].EndUpdateHeader(_header);
            // Specify page margins, orientation, etc.
            SetPrintOptions(srv);
            srv.EndUpdate();
            // Update fields
            srv.Document.UpdateAllFields();
            // Create a printable link to print a document.
            PrintViaLink(srv);
        }
        #endregion #printfromserver
        #region #setprintoptions
        private static void SetPrintOptions(IRichEditDocumentServer richedit)
        {
            foreach (Section _section in richedit.Document.Sections) {
                _section.Page.PaperKind = DevExpress.Drawing.Printing.DXPaperKind.A4;
                _section.Page.Landscape = false;
                _section.Margins.Left = 150f;
                _section.Margins.Right = 150f;
                _section.Margins.Top = 50f;
                _section.Margins.Bottom = 50f;
            }
        }
        #endregion #setprintoptions
        #region #printvialink
        private static void PrintViaLink(RichEditDocumentServer srv)
        {
            if (!srv.IsPrintingAvailable) return;
            using (PrintingSystemBase ps = new PrintingSystemBase())
            using (PrintableComponentLinkBase link = new PrintableComponentLinkBase(ps)) {
                link.Component = srv;
                // Disable warnings.
                ps.ShowMarginsWarning = false;
                ps.ShowPrintStatusDialog = false;
                // Find a printer containing 'PDF' in its name.
                string printerName = String.Empty;
                for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++) {
                    string pName = PrinterSettings.InstalledPrinters[i];
                    if (pName.Contains("PDF")) {
                        printerName = pName;
                        break;
                    }
                }

                //Run document creaion
                link.CreateDocument();

                // Print to the specified printer.
                PrintToolBase tool = new PrintToolBase(ps);
                tool.Print(printerName);
            }
        }
        #endregion #printvialink
    }
}
