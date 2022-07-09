using iTextSharp.text;
using iTextSharp.text.pdf;
using KProject_MVC.Models;
using System.IO;

namespace KProject_MVC.Report
{
    public class PDFReport
    {
        int totalColumn = 5;
        Document document;
        PdfPTable pdfPTable;
        PdfPCell pdfPCell;
        Font fontStyle;
        MemoryStream ms = new MemoryStream();
        QuotationReportModel objQuotationReportModel = new QuotationReportModel();
        public byte[] PrepareQuotatioReport(QuotationReportModel quotationReportModel) 
        {
            objQuotationReportModel = quotationReportModel;

            document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            document.SetPageSize(PageSize.A4);
            document.SetMargins(20f, 20f, 20f, 20f);
            pdfPTable = new PdfPTable(totalColumn);
            pdfPTable.WidthPercentage = 100;
            pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;

            fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);

            PdfWriter oPdfWriter = PdfWriter.GetInstance(document, ms);
            _events e = new _events();
            oPdfWriter.PageEvent = e;
            document.Open();
            for (int i = 0; i < 5; i++)
            {
                Paragraph welcomeParagraph = new Paragraph("Hello, World!");

                document.Add(welcomeParagraph);
                document.NewPage();

            }
            //

            pdfPTable.SetWidths(new float[] { 20f, 200f, 100f,100f,100f });
            this.ReportHeader();
            this.ReportBody();
            pdfPTable.HeaderRows = 2;
            document.Add(pdfPTable);
            document.Close();
            return ms.ToArray();
        }

        private void ReportHeader()
        {
            fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);

            pdfPCell = new PdfPCell(new Phrase(objQuotationReportModel.FromCompanyName, fontStyle));
            pdfPCell.Colspan = 2;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPTable.AddCell(pdfPCell);
           
            pdfPCell = new PdfPCell(new Phrase(objQuotationReportModel.ToCompanyName, fontStyle));
            pdfPCell.Colspan = 3;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

        }

        private void ReportBody()
        {
            fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            pdfPCell = new PdfPCell(new Phrase("S.No", fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.GRAY;
            pdfPTable.AddCell(pdfPCell);
            
            fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            pdfPCell = new PdfPCell(new Phrase("Description", fontStyle));
          
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.BackgroundColor = BaseColor.GRAY;
            pdfPTable.AddCell(pdfPCell);

            fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            pdfPCell = new PdfPCell(new Phrase("Quantity", fontStyle));
            
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.BackgroundColor = BaseColor.GRAY;
            pdfPTable.AddCell(pdfPCell);

            fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            pdfPCell = new PdfPCell(new Phrase("Lump sum", fontStyle));
        
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.BackgroundColor = BaseColor.GRAY;
            pdfPTable.AddCell(pdfPCell);

            fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            pdfPCell = new PdfPCell(new Phrase("Remarks", fontStyle));
     
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.BackgroundColor = BaseColor.GRAY;
            pdfPTable.AddCell(pdfPCell);
            pdfPTable.CompleteRow();

            fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
           
            foreach (var item in objQuotationReportModel.PriceSummaryList)
            {
               
                pdfPCell = new PdfPCell(new Phrase(item.SerialNo.ToString(), fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfPTable.AddCell(pdfPCell);


                
                pdfPCell = new PdfPCell(new Phrase(item.Description, fontStyle));
          
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfPTable.AddCell(pdfPCell);

               
                pdfPCell = new PdfPCell(new Phrase(item.Quantity.ToString(), fontStyle));
        
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfPTable.AddCell(pdfPCell);
 
                pdfPCell = new PdfPCell(new Phrase(item.LumpSum.ToString(), fontStyle));
          
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfPTable.AddCell(pdfPCell); 

                pdfPCell = new PdfPCell(new Phrase(item.Remarks, fontStyle));
          
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                pdfPTable.AddCell(pdfPCell);
                pdfPTable.CompleteRow();
            }



        }
    }

    class _events : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, Document doc)
        {
            Paragraph footer = new Paragraph("THANK YOU", FontFactory.GetFont(FontFactory.TIMES, 10, iTextSharp.text.Font.NORMAL));
            footer.Alignment = Element.ALIGN_RIGHT;
            PdfPTable footerTbl = new PdfPTable(1);
            footerTbl.TotalWidth = 300;
            footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell cell = new PdfPCell(footer);
            cell.Border = 0;
            cell.PaddingLeft = 10;

            footerTbl.AddCell(cell);
            footerTbl.WriteSelectedRows(0, -1, 415, 30, writer.DirectContent);
        }
        //public override void OnEndPage(PdfWriter writer, Document document)
        //{
        //    PdfPTable table = new PdfPTable(1);
        //    //table.WidthPercentage = 100; //PdfPTable.writeselectedrows below didn't like this
        //    table.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin; //this centers [table]
        //    PdfPTable table2 = new PdfPTable(2);

        //    //logo
        //    PdfPCell cell2 = new PdfPCell(Image.GetInstance(@"D:\Dhiva\Project_Works\KProject_MVC\KProject_MVC\KProject_MVC\Images\header.jpg"));
        //    cell2.Colspan = 2;
        //    table2.AddCell(cell2);

        //    //title
        //    cell2 = new PdfPCell(new Phrase("\nTITLE", new Font(Font.NORMAL, 16, Font.BOLD | Font.UNDERLINE)));
        //    cell2.HorizontalAlignment = Element.ALIGN_CENTER;
        //    cell2.Colspan = 2;
        //    table2.AddCell(cell2);

        //    PdfPCell cell = new PdfPCell(table2);
        //    table.AddCell(cell);

        //    table.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.Height - 36, writer.DirectContent);
        //}
    }
}
