using PdfSharp.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;
using System.Linq;
using TPV.Components;

namespace TPV.Services
{
    public static class TicketPrinter
    {
        public static void PrintTicket(string filePath, ProductSelecter selector)
        {
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            var productos = selector.GetSelectedProducts(); 

            PdfDocument document = new PdfDocument();
            document.Info.Title = "Ticket de Compra";

            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            GlobalFontSettings.UseWindowsFontsUnderWindows = true;

            XFont titleFont = new XFont("Verdana", 18, XFontStyleEx.Bold);
            XFont headerFont = new XFont("Verdana", 12, XFontStyleEx.Bold);
            XFont contentFont = new XFont("Verdana", 12, XFontStyleEx.Regular);

            double margin = 40;
            double y = margin;

            gfx.DrawString("TICKET DE COMPRA", titleFont, XBrushes.DarkBlue,
                new XRect(margin, y, page.Width - 2 * margin, 30), XStringFormats.TopCenter);
            y += 40;

            gfx.DrawLine(XPens.Gray, margin, y, page.Width - margin, y);
            y += 10;

            gfx.DrawString("Producto", headerFont, XBrushes.Black, margin, y);
            gfx.DrawString("Cantidad", headerFont, XBrushes.Black, margin + 200, y);
            gfx.DrawString("Total (€)", headerFont, XBrushes.Black, margin + 300, y);
            y += 20;

            gfx.DrawLine(XPens.Gray, margin, y, page.Width - margin, y);
            y += 10;

            foreach (var p in productos)
            {
                gfx.DrawString(p.Name, contentFont, XBrushes.Black, margin, y);
                gfx.DrawString(p.Quantity.ToString(), contentFont, XBrushes.Black, margin + 200, y);
                gfx.DrawString(p.TotalPrice.ToString("C"), contentFont, XBrushes.Black, margin + 300, y);
                y += 20;
            }

            y += 10;
            gfx.DrawLine(XPens.DarkBlue, margin, y, page.Width - margin, y);
            y += 15;

            decimal total = productos.Sum(p => p.TotalPrice);
            gfx.DrawString($"TOTAL: {total:C}", new XFont("Verdana", 14, XFontStyleEx.Bold), XBrushes.DarkRed, margin, y);

            y += 40;
            gfx.DrawString("¡Gracias por su compra!", new XFont("Verdana", 12, XFontStyleEx.Italic), XBrushes.Gray,
                new XRect(margin, y, page.Width - 2 * margin, 20), XStringFormats.TopCenter);
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true 
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No se pudo abrir el ticket automáticamente: {ex.Message}");
            }
            document.Save(filePath);
        }
    }
}
