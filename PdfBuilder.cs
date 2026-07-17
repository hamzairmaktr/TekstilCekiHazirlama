using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace TekstilCekiHazirlama
{
    public class DeliveryNoteDocument : IDocument
    {
        private readonly DeliveryNote _deliveryNote;
        private readonly AppSettings _settings;

        public DeliveryNoteDocument(DeliveryNote deliveryNote, AppSettings settings)
        {
            _deliveryNote = deliveryNote;
            _settings = settings;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(25);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Arial"));

                page.Header().Element(BuildHeader);
                page.Content().Element(BuildBody);
                page.Footer().AlignCenter().Text($"PDF Oluşturuldu: {DateTime.Now:dd.MM.yyyy HH:mm} \n2026 - Hamza Irmak").FontSize(8).FontColor(Colors.Grey.Darken2);
            });
        }

        private void BuildHeader(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().PaddingBottom(10).Row(row =>
                {
                    row.RelativeItem().Column(stack =>
                    {
                        stack.Item().Text(_settings.CompanyName).FontSize(14).SemiBold();
                        stack.Item().Text("KUMAŞ ÇEKİ LİSTESİ").FontSize(16).SemiBold().FontColor(Colors.Blue.Darken1);
                    });

                    row.ConstantItem(110).AlignRight().Column(stack =>
                    {
                        if (!string.IsNullOrWhiteSpace(_settings.LogoPath) && File.Exists(_settings.LogoPath))
                        {
                            stack.Item().AlignCenter().Width(100).Image(_settings.LogoPath).FitWidth();
                        }
                        stack.Item().Text(_settings.CompanyAddress).FontSize(8).LineHeight(1.2f);
                        stack.Item().Text(_settings.CompanyPhone).FontSize(8).LineHeight(1.2f);
                    });
                });

                column.Item().PaddingVertical(10).BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Row(row =>
                {
                    row.RelativeItem().Column(stack =>
                    {
                        stack.Item().Text("Belge No:").Bold();
                        stack.Item().Text(_deliveryNote.DocumentNo);
                    });
                    row.RelativeItem().Column(stack =>
                    {
                        stack.Item().Text("Tarih:").Bold();
                        stack.Item().Text(_deliveryNote.Date.ToString("dd.MM.yyyy"));
                    });
                });
            });
        }

        private void BuildBody(IContainer container)
        {
            container.Column(column =>
            {
                column.Item().PaddingVertical(10).Row(row =>
                {
                    row.RelativeItem().Column(left =>
                    {
                        left.Item().Text("Sayın:").Bold();
                        left.Item().Text(_deliveryNote.CustomerName);
                    });
                    row.RelativeItem(2).Column(right =>
                    {
                        right.Item().Text("Adres:").Bold();
                        right.Item().Text(_deliveryNote.Address);
                        right.Item().PaddingTop(4).Text("Telefon:").Bold();
                        right.Item().Text(_deliveryNote.Phone);
                    });
                });

                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(3);
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(2);
                        columns.RelativeColumn(2);
                    });

                    table.Header(header =>
                    {
                        header.Cell().Element(CellStyle).Text("Cinsi").SemiBold();
                        header.Cell().Element(CellStyle).AlignRight().Text("Adet").SemiBold();
                        header.Cell().Element(CellStyle).AlignRight().Text("KG").SemiBold();
                        header.Cell().Element(CellStyle).AlignRight().Text("Fiyatı").SemiBold();
                        header.Cell().Element(CellStyle).AlignRight().Text("Tutarı").SemiBold();
                    });

                    foreach (var item in _deliveryNote.Items)
                    {
                        table.Cell().Element(CellStyle).Text(item.ProductName);
                        table.Cell().Element(CellStyle).AlignRight().Text(item.RollCount.ToString());
                        table.Cell().Element(CellStyle).AlignRight().Text(item.Kg.ToString("N2"));
                        table.Cell().Element(CellStyle).AlignRight().Text(item.UnitPrice.ToString("N2"));
                        table.Cell().Element(CellStyle).AlignRight().Text(item.Amount.ToString("N2"));
                    }

                    table.Footer(footer =>
                    {
                        footer.Cell().Element(CellStyle).Text("Toplam").SemiBold();
                        footer.Cell().Element(CellStyle).AlignRight().Text(_deliveryNote.TotalRoll.ToString()).SemiBold();
                        footer.Cell().Element(CellStyle).AlignRight().Text(_deliveryNote.TotalKg.ToString("N2")).SemiBold();
                        footer.Cell().Element(CellStyle).Text(string.Empty);
                        footer.Cell().Element(CellStyle).AlignRight().Text(_deliveryNote.TotalAmount.ToString("N2")).SemiBold();
                    });
                });

                column.Item().PaddingTop(15).Row(row =>
                {
                    row.RelativeItem().Column(left =>
                    {
                        left.Item().Text("Teslim Alan").Bold();
                        left.Item().PaddingTop(25).Text("________________________");
                    });
                    row.RelativeItem().Column(right =>
                    {
                        right.Item().Text("Teslim Eden").Bold();
                        right.Item().PaddingTop(25).Text("________________________");
                    });
                });
            });
        }

        private IContainer CellStyle(IContainer container)
        {
            return container.Border(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Height(22).AlignMiddle();
        }
    }
}
