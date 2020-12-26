using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows;
using System.Collections.Specialized;
using BLL.BusinessModels;
using BLL.DataOperations;

namespace NewCourseWork
{
    public class FileManager
    {
        DbDataOperations db;
        public FileManager()
        {
            db = new DbDataOperations();
        }

        public FileManager(DbDataOperations db)
        {
           this.db = db;
        }
        public void CreateForm(Supply sup)
        {
            try
            {
                string FileName = "Заявка на поставку №"+sup.Id+".pdf";
                iTextSharp.text.Document doc = new iTextSharp.text.Document();
                PdfWriter.GetInstance(doc, new FileStream(FileName, FileMode.Create));

                doc.Open();

                BaseFont baseFont = BaseFont.CreateFont("C:/Windows/Fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                var arial_italic_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ariali.ttf");
                BaseFont ItalicBaseFont = BaseFont.CreateFont(arial_italic_path, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font ItalicFont= new iTextSharp.text.Font(ItalicBaseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

                Paragraph par = new Paragraph("Кому: "+db.getProviders().Where(i => i.Id == sup.ProviderId).Select(i => i.CompanyName).FirstOrDefault().ToString(), font);
                par.Alignment = Element.ALIGN_RIGHT;
                doc.Add(par);

                string Initials = db.getProviders().Where(i => i.Id == sup.ProviderId).Select(i => i.Initials).FirstOrDefault().ToString();
                string FamName = db.getProviders().Where(i => i.Id == sup.ProviderId).Select(i => i.FamilyName).FirstOrDefault().ToString();
                if (FamName[FamName.Length - 1] == 'н' || FamName[FamName.Length - 1] == 'в')
                {
                    FamName = FamName + "у";
                }
                string FulName = FamName + " " + Initials;

                par = new Paragraph("Директору " + FulName, font);
                par.Alignment = Element.ALIGN_RIGHT;
                doc.Add(par);

                par = new Paragraph("От ООО \"Sirius Smoke\"", font);
                par.Alignment = Element.ALIGN_RIGHT;
                doc.Add(par);

                string warehousename = db.getWarehouses().Where(i=>i.Id == sup.WarehouseId).Select(i => i.Address).FirstOrDefault().ToString();

                par = new Paragraph("г. Иваново, " + warehousename, font);
                par.Alignment = Element.ALIGN_RIGHT;
                doc.Add(par);

                par = new Paragraph("т. 8 (567) 63-87-69", font);
                par.Alignment = Element.ALIGN_RIGHT;
                doc.Add(par);

                par = new Paragraph(DateTime.Parse(sup.ApplicationDate.ToString()).ToShortDateString(), font);
                par.Alignment = Element.ALIGN_RIGHT;
                doc.Add(par);

                par = new Paragraph("ЗАЯВКА", font);
                par.Alignment = Element.ALIGN_CENTER;
                par.SetLeading(font.Size, 2);
                doc.Add(par);

                par = new Paragraph("на поставку товара", font);
                par.Alignment = Element.ALIGN_CENTER;
                doc.Add(par);

                par = new Paragraph(" ", font);
                doc.Add(par);

                string str = "Прошу зарезервировать и поставить до " + DateTime.Parse(sup.DeliveryDate.ToString()).ToShortDateString() + " следующие наименования товаров:";
                par = new Paragraph(str, font);
                doc.Add(par);

                PdfPTable table = new PdfPTable(4);
                table.SpacingBefore = 20;
                PdfPCell HeaderCell = new PdfPCell(new Phrase("Наименование", font));
                HeaderCell.HorizontalAlignment = 1;
                table.AddCell(HeaderCell);
                HeaderCell = new PdfPCell(new Phrase("Количество", font));
                HeaderCell.HorizontalAlignment = 1;
                table.AddCell(HeaderCell);
                HeaderCell = new PdfPCell(new Phrase("Цена единицы товара, р", font));
                HeaderCell.HorizontalAlignment = 1;
                table.AddCell(HeaderCell);
                HeaderCell = new PdfPCell(new Phrase("Общая стоимость, р", font));
                HeaderCell.HorizontalAlignment = 1;
                table.AddCell(HeaderCell);

                decimal TotalSum = 0 ;
                int TotalQuantity = 0;

                foreach (SupplyLine item in sup.Lines)
                {
                    PdfPCell BasicCell = new PdfPCell(new Phrase(item.CommodityName.ToString(), font));
                    BasicCell.HorizontalAlignment = 1;
                    table.AddCell(BasicCell);
                    BasicCell = new PdfPCell(new Phrase(item.Quantity.ToString() + " шт.", font));
                    BasicCell.HorizontalAlignment = 1;
                    table.AddCell(BasicCell);
                    BasicCell = new PdfPCell(new Phrase((item.Cost).ToString(), font));
                    BasicCell.HorizontalAlignment = 1;
                    table.AddCell(BasicCell);
                    BasicCell = new PdfPCell(new Phrase((item.Cost * item.Quantity).ToString(), font));
                    BasicCell.HorizontalAlignment = 1;
                    table.AddCell(BasicCell);
                    TotalQuantity += item.Quantity ;
                    TotalSum += item.Cost*item.Quantity;
                }
                HeaderCell = new PdfPCell(new Phrase("Итого", font));
                HeaderCell.HorizontalAlignment = 1;
                table.AddCell(HeaderCell);
                HeaderCell = new PdfPCell(new Phrase(TotalQuantity.ToString() + " шт.", font));
                HeaderCell.HorizontalAlignment = 1;
                table.AddCell(HeaderCell);
                HeaderCell = new PdfPCell(new Phrase("", font));
                HeaderCell.HorizontalAlignment = 1;
                table.AddCell(HeaderCell);
                HeaderCell = new PdfPCell(new Phrase(TotalSum.ToString(), font));
                HeaderCell.HorizontalAlignment = 1;
                table.AddCell(HeaderCell);
                table.WidthPercentage = 95;
                doc.Add(table);

                par = new Paragraph("Директор ООО \"Sirius Smoke\"", font);
                font.SetStyle ( iTextSharp.text.Font.ITALIC);
                par.Add(new Chunk("                 Воронов", ItalicFont));
                font.SetStyle(iTextSharp.text.Font.NORMAL);
                par.Add(new Chunk("                 Воронов И.С.", font));
                par.Alignment = Element.ALIGN_CENTER;
                par.SetLeading(font.Size, 2);
                doc.Add(par);
                doc.Close();
                MessageBox.Show("Файл заявки \"" + FileName + "\" создан");
            }
            catch (IOException ex)
            {
                MessageBox.Show("Возникла ошибка при записи страниц", ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка", ex.Message);
            }
        }
        public void Arrange(Supply sup)
        {
            try
            {
                string FileName = "Накладная №"+sup.Id+".pdf";
                iTextSharp.text.Document doc = new iTextSharp.text.Document();
                PdfWriter.GetInstance(doc, new FileStream(FileName, FileMode.Create));

                doc.Open();

                BaseFont baseFont = BaseFont.CreateFont("C:/Windows/Fonts/arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

                Paragraph par = new Paragraph("от "+DateTime.Parse(sup.ArrangementDate.ToString()).ToShortDateString(), font);
                par.Alignment = Element.ALIGN_RIGHT;
                doc.Add(par);

                font.Size = 24;
                par = new Paragraph("НАКЛАДНАЯ №"+sup.Id, font);
                par.Alignment = Element.ALIGN_CENTER;
                doc.Add(par);

                font.Size = iTextSharp.text.Font.DEFAULTSIZE;
                par = new Paragraph("Кому: ООО \"Sirius Smoke\"", font);
                par.SetLeading(font.Size, 2);
                par.Alignment = Element.ALIGN_LEFT;
                doc.Add(par);

                font.Size = iTextSharp.text.Font.DEFAULTSIZE;
                string provider = db.getProviders().Where(i => i.Id == sup.ProviderId).Select(i=>i.CompanyName).FirstOrDefault().ToString();
                par = new Paragraph("От кого: " + provider, font);
                par.SetLeading(font.Size, 2);
                par.Alignment = Element.ALIGN_LEFT;
                doc.Add(par);

                PdfPTable table = new PdfPTable(4);
                table.SpacingBefore = 20;
                PdfPCell HeaderCell = new PdfPCell(new Phrase("Наименование", font));
                HeaderCell.HorizontalAlignment = 1;
                table.AddCell(HeaderCell);
                HeaderCell = new PdfPCell(new Phrase("Количество", font));
                HeaderCell.HorizontalAlignment = 1;
                table.AddCell(HeaderCell);
                HeaderCell = new PdfPCell(new Phrase("Цена единицы товара, р", font));
                HeaderCell.HorizontalAlignment = 1;
                table.AddCell(HeaderCell);
                HeaderCell = new PdfPCell(new Phrase("Общая стоимость, р", font));
                HeaderCell.HorizontalAlignment = 1;
                table.AddCell(HeaderCell);

                decimal TotalSum = 0;
                int TotalQuantity = 0;

                foreach (SupplyLine item in sup.Lines)
                {
                    PdfPCell BasicCell = new PdfPCell(new Phrase(item.CommodityName.ToString(), font));
                    BasicCell.HorizontalAlignment = 1;
                    table.AddCell(BasicCell);
                    BasicCell = new PdfPCell(new Phrase(item.Quantity.ToString() + " шт.", font));
                    BasicCell.HorizontalAlignment = 1;
                    table.AddCell(BasicCell);
                    BasicCell = new PdfPCell(new Phrase((item.Cost/item.Quantity).ToString(), font));
                    BasicCell.HorizontalAlignment = 1;
                    table.AddCell(BasicCell);
                    BasicCell = new PdfPCell(new Phrase((item.Cost).ToString(), font));
                    BasicCell.HorizontalAlignment = 1;
                    table.AddCell(BasicCell);
                    TotalQuantity += item.Quantity;
                    TotalSum += item.Cost * item.Quantity;
                }
                HeaderCell = new PdfPCell(new Phrase("Итого", font));
                HeaderCell.HorizontalAlignment = 1;
                table.AddCell(HeaderCell);
                HeaderCell = new PdfPCell(new Phrase(TotalQuantity.ToString() + " шт.", font));
                HeaderCell.HorizontalAlignment = 1;
                table.AddCell(HeaderCell);
                HeaderCell = new PdfPCell(new Phrase("", font));
                HeaderCell.HorizontalAlignment = 1;
                table.AddCell(HeaderCell);
                HeaderCell = new PdfPCell(new Phrase(TotalSum.ToString(), font));
                HeaderCell.HorizontalAlignment = 1;
                table.AddCell(HeaderCell);
                table.WidthPercentage = 95;

                doc.Add(table);

                font.Size = iTextSharp.text.Font.DEFAULTSIZE;
                par = new Paragraph("Принял: ______________ ______________________", font);
                par.Alignment = Element.ALIGN_LEFT;
                par.SetLeading(font.Size, 2);
                doc.Add(par);

                font.Size = iTextSharp.text.Font.DEFAULTSIZE - 2;
                par = new Paragraph("                         подпись                                 Ф.И.О", font);
                par.Alignment = Element.ALIGN_LEFT;
                doc.Add(par);
                doc.Close();
                MessageBox.Show("Файл накладной \"" + FileName + "\" создан");
            }
            catch (IOException ex)
            {
                MessageBox.Show("Возникла ошибка при записи страниц", ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка", ex.Message);
            }
        }
    }
}
