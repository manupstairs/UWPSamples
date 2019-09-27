using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Printing;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Printing;

namespace PrintingSample
{
    public class PrintHelper
    {
        /// <summary>
        /// PrintDocument is used to prepare the pages for printing.
        /// Prepare the pages to print in the handlers for the Paginate, GetPreviewPage, and AddPages events.
        /// </summary>
        private readonly PrintDocument printDocument;

        /// <summary>
        /// Marker interface for document source
        /// </summary>
        private readonly IPrintDocumentSource printDocumentSource;

        private UIElement PrintContent { get; set; }

        public PrintHelper()
        {
            printDocument = new PrintDocument();
            printDocumentSource = printDocument.DocumentSource;
            //printDocument.Paginate += PrintDocument_Paginate;
            printDocument.GetPreviewPage += PrintDocument_GetPreviewPage;
            printDocument.AddPages += PrintDocument_AddPages;

            PrintManager printMan = PrintManager.GetForCurrentView();
            printMan.PrintTaskRequested += PrintMan_PrintTaskRequested;
        }

        //private void PrintDocument_Paginate(object sender, PaginateEventArgs e)
        //{
        //    PrintDocument printDoc = (PrintDocument)sender;

        //    //Report the number of preview pages created
        //    printDoc.SetPreviewPageCount(1, PreviewPageCountType.Intermediate);
        //}

        private void PrintMan_PrintTaskRequested(PrintManager sender, PrintTaskRequestedEventArgs args)
        {
            PrintTask printTask = null;
            printTask = args.Request.CreatePrintTask("1", sourceRequested =>
            {
                sourceRequested.SetSource(printDocumentSource);
            });
        }

        private void PrintDocument_AddPages(object sender, AddPagesEventArgs e)
        {
            PrintDocument printDoc = (PrintDocument)sender;
            printDoc.AddPage(PrintContent);
            printDoc.AddPagesComplete();
        }

        private void PrintDocument_GetPreviewPage(object sender, GetPreviewPageEventArgs e)
        {
            PrintDocument printDoc = (PrintDocument)sender;
            printDoc.SetPreviewPage(e.PageNumber, PrintContent);
        }

        public async Task ShowPrintUIAsync()
        {
            if (PrintManager.IsSupported())
            {
                await PrintManager.ShowPrintUIAsync();
            }
        }

        public virtual void PreparePrintContent(UIElement printContent)
        {
            PrintContent = printContent;
        }
    }
}
