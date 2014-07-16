using System;
using System.Collections.Generic;

namespace DocumentsReestr
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using DomainModel;

    using iTextSharp.text;
    using iTextSharp.text.pdf;

    using RCO.PopUpButtons;

    using ReestrFacade;
    using ReestrFacade.Utils;

    using ReestrModel.Extentions;

    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = User.Identity;
            if (!Page.IsPostBack)
            {
                LoadDocuments();
            }
        }

        private void LoadDocuments()
        {
            IList<DocumentModel> list = DocumentFacade.LoadDocuments();
            gvDocuments.DataSource = list;
            gvDocuments.DataBind();
        }

        protected void pbtnAdd_AfterChildClose(object sender, RCO.PopUpButtons.PopUpItems e)
        {
            gvDocuments.PageIndex = 0;
            SearchDocuments();
        }

        protected void gvDocuments_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            const string ExpiredCss = "expired_item";
            const string ExecutionTodayCss = "execution_today";
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var pbtnEditDoc = e.Row.FindControl("pbtnEditDoc") as PopUpButton;
                if (pbtnEditDoc != null)
                {
                    var doc = e.Row.DataItem as DocumentModel;
                    if (doc != null)
                    {
                        pbtnEditDoc.PostParams.Add(new paramItem("docId", doc.DocumentId.ToString()));
                    }
                    if (doc.IsExpired()) e.Row.CssClass = ExpiredCss;
                    if (doc.IsExecutionToday()) e.Row.CssClass = ExecutionTodayCss;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvDocuments.PageIndex = 0;
            this.SearchDocuments();
        }

        private void SearchDocuments()
        {
            try
            {
                var docs = this.LoadFilteredDocuments();

                this.gvDocuments.DataSource = docs;
                this.gvDocuments.DataBind();
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }

        private IList<DocumentModel> LoadFilteredDocuments()
        {
            Nullable<DateTime> from = null;
            Nullable<DateTime> to = null;
            if (!string.IsNullOrEmpty(this.txtFromDateAdmission.Text))
            {
                @from = ParserUtils.ParseDateTime(this.txtFromDateAdmission.Text);
            }

            if (!string.IsNullOrEmpty(this.txtToDateAdmission.Text))
            {
                to = ParserUtils.ParseDateTime(this.txtToDateAdmission.Text);
            }

            var docs = DocumentFacade.SearchDocuments(
                @from,
                to,
                this.idSender.Value,
                this.idDocName.Value,
                this.IsExecuteToday(),
                this.IsExpired());
            return docs;
        }

        private bool IsExecuteToday()
        {
            return rbtnPeriodFilter.SelectedIndex == 1;
        }

        private bool IsExpired()
        {
            return rbtnPeriodFilter.SelectedIndex == 2;
        }

        protected void gvDocuments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDocuments.PageIndex = e.NewPageIndex;
            this.SearchDocuments();
        }

        protected void pbtnEditDoc_AfterChildClose(object sender, PopUpItems e)
        {
            this.SearchDocuments();
        }

        protected void ibtnWord_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                var docs = this.LoadFilteredDocuments();
                if (!docs.Any()) return;
                var mimeWord="application/msword";
                string fileName = "resilt.doc";

                var str = new StringBuilder();
                
                str.AppendLine("<table style='border: 1px solid black; padding: 1ex;'>");
                str.AppendLine("<tr>");
                str.AppendLine("<td>номер документа</td>");
                str.AppendLine("<td>название</td>");
                str.AppendLine("<td>дата приема</td>");
                str.AppendLine("<td>срок исполнения</td>");
                str.AppendLine("<td>контрольный срок исполнения</td>");
                str.AppendLine("<td>отправитель</td>");
                str.AppendLine("</tr>");
                foreach (var doc in docs)
                {
                    str.AppendLine("<tr>");
                    str.AppendLine(string.Format("<td>{0}</td>", doc.DocNumber));
                    str.AppendLine(string.Format("<td>{0}</td>", doc.NameCalculated));
                    str.AppendLine(string.Format("<td>{0}</td>", doc.DateAdmission));
                    str.AppendLine(string.Format("<td>{0}</td>", doc.TermExecutionCalculated));
                    str.AppendLine(string.Format("<td>{0}</td>", doc.ControlTermExecutionModel));
                    str.AppendLine(string.Format("<td>{0}</td>", doc.DocSender.SenderName));
                    str.AppendLine("</tr>");
                }
                
                str.AppendLine("</table>");
                UploadReport(str, Response, mimeWord, fileName);

            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }

        }

        private static void UploadReport(StringBuilder results, HttpResponse response, string mime, string fileName)
        {
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            
            response.ContentEncoding = Encoding.GetEncoding(1251);
            response.ContentType = mime;
            response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            response.Write(results.ToString());
            response.OutputStream.Flush();
            response.OutputStream.Close();
            response.End();
            
        }

        protected void ibtnCsv_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            try
            {
                var docs = this.LoadFilteredDocuments();
                if (!docs.Any()) return;
                var mimeCsv = "text/csv";
                string fileName = "resilt.csv";
                var str = new StringBuilder();

                
                str.AppendLine("номер документа;название;дата приема;срок исполнения;контрольный срок исполнения;отправитель");
                
                
                foreach (var doc in docs)
                {
                    str.AppendLine(string.Format("{0};{1};{2};{3};{4};{5}", doc.DateAdmission, doc.NameCalculated, doc.DocNumber, doc.TermExecutionCalculated, doc.ControlTermExecutionModel, doc.DocSender.SenderName));
                    
                }
                
                UploadReport(str, Response, mimeCsv, fileName);

            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }

        protected void ibtnPdf_OnClick(object sender, ImageClickEventArgs e)
        {
            try
            {
                var docs = this.LoadFilteredDocuments();
                if (!docs.Any()) return;
                

                string cyrFont = Server.MapPath("~/Binaries/arial.ttf");
                BaseFont baseFont = BaseFont.CreateFont(cyrFont, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);


                Document pdfDoc = new Document(PageSize.A4.Rotate(), 5f, 5f, 5f, 5f);
                MemoryStream memoryStream = new MemoryStream();
                var writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                pdfDoc.Open();

                const int ReportColumns = 6;

                PdfPTable table = new PdfPTable(ReportColumns);
                table.WidthPercentage = 100f;

                var cell1 = new PdfPCell(new Phrase("номер документа", font));
                var cell2 = new PdfPCell(new Phrase("название", font));
                var cell3 = new PdfPCell(new Phrase("дата приема", font));
                var cell4 = new PdfPCell(new Phrase("срок исполнения", font));
                var cell5 = new PdfPCell(new Phrase("контрольный срок исполнения", font));
                var cell6 = new PdfPCell(new Phrase("отправитель", font));

                var row = new PdfPRow(new []{cell1, cell2, cell3, cell4, cell5, cell6});
                table.Rows.Add(row);


                foreach (var doc in docs) 
                {
                    var c1 = new PdfPCell(new Phrase(doc.DateAdmission.ToShortDateString(), font));
                    var c2 = new PdfPCell(new Phrase(doc.NameCalculated, font));
                    var c3 = new PdfPCell(new Phrase(doc.DocNumber.ToString(), font));
                    var c4 = new PdfPCell(new Phrase(doc.TermExecutionCalculated.ToString(), font));
                    var c5 = new PdfPCell(new Phrase(doc.ControlTermExecutionModel.ToShortDateString(), font));
                    var c6 = new PdfPCell(new Phrase(doc.DocSender.SenderName, font));

                    var rowd = new PdfPRow(new[] { c1, c2, c3, c4, c5, c6 });
                    table.Rows.Add(rowd);
                    

                }

                pdfDoc.Add(table);
                
                writer.CloseStream = false;
                pdfDoc.Close();


                writer.Close();
                
                memoryStream.Position = 0;
                memoryStream.Close();

                DownloadAsPDF(memoryStream, Response);
                

                

            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }
        private static void DownloadAsPDF(MemoryStream ms, HttpResponse response)
        {
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.ContentType = "application/pdf";
            response.AppendHeader("Content-Disposition", "attachment;filename=result.pdf");
            response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            response.OutputStream.Flush();
            response.OutputStream.Close();
            response.End();
            ms.Close();
        }
    }


}