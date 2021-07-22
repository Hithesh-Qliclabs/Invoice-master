using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Invoice
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
        private object saveFileDialog;

        public MainWindow()
    {
      InitializeComponent();
    }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            this.IsEnabled = false;
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(print, "invoice");
            }      
            }
            finally
            {
            this.IsEnabled = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (PdfDocument document = new PdfDocument())
            {
                //Add a page to the document
                PdfPage page = document.Pages.Add();

                //Create PDF graphics for a page
                PdfGraphics graphics = page.Graphics;

                //Set the standard font
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

                //Draw the text
                graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

                //Save the document
                document.Save("Output.pdf");
            }
        }

        public BitmapSource CreateBitmap(FrameworkElement element)
        {
            int width = (int)Math.Ceiling(element.ActualWidth);
            int height = (int)Math.Ceiling(element.ActualHeight);

            width = width == 0 ? 1 : width;
            height = height == 0 ? 1 : height;

            // render element to image (WPF)  
            RenderTargetBitmap rtbmp = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Default);
            rtbmp.Render(element);
            return rtbmp;
        }

        private void btnPDFClick(object sender, RoutedEventArgs e)
        {
            ///////////////First Method//////////////////
            //// get stream to save to  
            //var dlg = new SaveFileDialog();
            //dlg.DefaultExt = ".pdf";
            //var dr = dlg.ShowDialog();
            //if (!dr.HasValue || !dr.Value)
            //{
            //    return;
            //}

            //// create document  
            //var pdf = new PdfDocument(PaperKind.Letter);
            //pdf.Clear();

            //var img = new WriteableBitmap(CreateBitmap(Context));
            //// if Silverlight, use below instead  
            //// var img = new WriteableBitmap(content, null);  

            //pdf.DrawImage(img, pdf.PageRectangle, ContentAlignment.TopLeft, Stretch.None);

            //// save document  
            //using (var stream = dlg.OpenFile())
            //{
            //    pdf.Save(stream);
            //}
            //MessageBox.Show(dlg.SafeFileName + " saved successfully!");


            ///////////////Second Method////////////////
            ////get the pdf file the user selected
            //OpenFileDialog openFileDialog = new OpenFileDialog
            //{
            //    DefaultExt = ".pdf",
            //    Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*"
            //};
            //bool? fileOpenResult = openFileDialog.ShowDialog();
            //if (fileOpenResult != true)
            //{
            //    return;
            //}

            ////show a printdialog to user where attributes can be changed
            //PrintDialog printDialog = new PrintDialog();
            //printDialog.PageRangeSelection = PageRangeSelection.AllPages;
            //printDialog.UserPageRangeEnabled = true;
            //bool? doPrint = printDialog.ShowDialog();
            //if (doPrint != true)
            //{
            //    return;
            //}

            ////open the pdf file
            //FixedDocument fixedDocument;
            //using (FileStream pdfFile = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
            //{
            //    Document document = new Document(pdfFile);
            //    RenderSettings renderSettings = new RenderSettings();
            //    ConvertToWpfOptions renderOptions = new ConvertToWpfOptions { ConvertToImages = false };
            //    renderSettings.RenderPurpose = RenderPurpose.Print;
            //    renderSettings.ColorSettings.TransformationMode = ColorTransformationMode.HighQuality;
            //    //convert the pdf with the rendersettings and options to a fixed-size document which can be printed
            //    fixedDocument = document.ConvertToWpf(renderSettings, renderOptions);
            //}
            //printDialog.PrintDocument(fixedDocument.DocumentPaginator, "Print");
        }

    }
}
