using ClosedXML.Excel;
using EcoTrash.Data;
using EcoTrash.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection.Metadata;
using System.Text;

namespace EcoTrash.Controllers
{
    public class RelatoriosController : Controller
    {
        private readonly AppDbContext _context;

        public RelatoriosController(AppDbContext context)
        {
            _context = context;
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public IActionResult Index()
        {
            var dashboardData = new DashboardViewModel
            {
                TotalEmpresas = _context.Empresas.Count(e => e.Ativo),
                TotalPesagens = _context.Pesagens.Count(),
                TotalLocais = _context.Locais.Count(),
                PesagensPorMes = GetPesagensPorMes(),
                MateriaisMaisReciclados = GetMateriaisMaisReciclados()
            };

            return View(dashboardData);
        }

        
        public async Task<IActionResult> PesagensPdf(DateTime? dataInicio, DateTime? dataFim)
        {
            var pesagens = await GetPesagensFiltradas(dataInicio, dataFim);

            var model = new RelatorioPesagensViewModel
            {
                Pesagens = pesagens,
                DataInicio = dataInicio,
                DataFim = dataFim,
                TotalPeso = pesagens.Sum(p => p.Peso),
                Quantidade = pesagens.Count
            };

            var pdfBytes = GeneratePdfReport(model);
            return File(pdfBytes, "application/pdf", $"relatorio-pesagens-{DateTime.Now:yyyyMMdd}.pdf");
        }

        
        public async Task<IActionResult> PesagensExcel(DateTime? dataInicio, DateTime? dataFim)
        {
            var pesagens = await GetPesagensFiltradas(dataInicio, dataFim);

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Pesagens");

            
            worksheet.Cell(1, 1).Value = "Relatório de Pesagens - EcoTrash";
            worksheet.Cell(1, 1).Style.Font.Bold = true;
            worksheet.Cell(1, 1).Style.Font.FontSize = 16;

            worksheet.Cell(3, 1).Value = "Data/Hora";
            worksheet.Cell(3, 2).Value = "Tipo de Material";
            worksheet.Cell(3, 3).Value = "Peso (kg)";
            worksheet.Cell(3, 4).Value = "Localização";

            
            int row = 4;
            foreach (var pesagem in pesagens)
            {
                worksheet.Cell(row, 1).Value = pesagem.DataCadastro;
                worksheet.Cell(row, 2).Value = pesagem.TipoMaterial;
                worksheet.Cell(row, 3).Value = pesagem.Peso;
                worksheet.Cell(row, 4).Value = pesagem.Localizacao;
                row++;
            }


            worksheet.Cell(row + 1, 1).Value = "TOTAL:";
            worksheet.Cell(row + 1, 3).Value = pesagens.Sum(p => p.Peso);
            worksheet.Cell(row + 1, 1).Style.Font.Bold = true;
            worksheet.Cell(row + 1, 3).Style.Font.Bold = true;

            
            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                       $"relatorio-pesagens-{DateTime.Now:yyyyMMdd}.xlsx");
        }

        public async Task<IActionResult> EmpresasPdf()
        {
            var empresas = await _context.Empresas
                .Where(e => e.Ativo)
                .OrderBy(e => e.Nome)
                .ToListAsync();

            var pdfBytes = GenerateEmpresasPdfReport(empresas);
            return File(pdfBytes, "application/pdf", $"relatorio-empresas-{DateTime.Now:yyyyMMdd}.pdf");
        }

        
        public IActionResult Analitico()
        {
            var analytics = new AnalyticsViewModel
            {
                TotalPesoReciclado = _context.Pesagens.Sum(p => p.Peso),
                MediaPesoPorPesagem = _context.Pesagens.Average(p => p.Peso),
                TopMateriais = _context.Pesagens
                    .GroupBy(p => p.TipoMaterial)
                    .Select(g => new MaterialStats
                    {
                        Material = g.Key,
                        Total = g.Sum(p => p.Peso),
                        Quantidade = g.Count()
                    })
                    .OrderByDescending(m => m.Total)
                    .Take(10)
                    .ToList(),
                EvolucaoMensal = GetEvolucaoMensal()
            };

            return View(analytics);
        }

        
        private async Task<List<Pesagem>> GetPesagensFiltradas(DateTime? dataInicio, DateTime? dataFim)
        {
            var query = _context.Pesagens.AsQueryable();

            if (dataInicio.HasValue)
                query = query.Where(p => p.DataCadastro >= dataInicio.Value);

            if (dataFim.HasValue)
                query = query.Where(p => p.DataCadastro <= dataFim.Value.AddDays(1));

            return await query.OrderByDescending(p => p.DataCadastro).ToListAsync();
        }

        private List<PesagemMes> GetPesagensPorMes()
        {
            var seisMesesAtras = DateTime.Now.AddMonths(-6);

            return _context.Pesagens
                .Where(p => p.DataCadastro >= seisMesesAtras)
                .AsEnumerable()
                .GroupBy(p => new { p.DataCadastro.Year, p.DataCadastro.Month })
                .Select(g => new PesagemMes
                {
                    Mes = $"{g.Key.Month:00}/{g.Key.Year}",
                    TotalPeso = g.Sum(p => p.Peso),
                    Quantidade = g.Count()
                })
                .OrderBy(p => p.Mes)
                .ToList();
        }

        private List<MaterialStats> GetMateriaisMaisReciclados()
        {
            return _context.Pesagens
                .GroupBy(p => p.TipoMaterial)
                .Select(g => new MaterialStats
                {
                    Material = g.Key,
                    Total = g.Sum(p => p.Peso),
                    Quantidade = g.Count()
                })
                .OrderByDescending(m => m.Total)
                .Take(5)
                .ToList();
        }

        private List<EvolucaoMensal> GetEvolucaoMensal()
        {
            var umAnoAtras = DateTime.Now.AddYears(-1);

            return _context.Pesagens
                .Where(p => p.DataCadastro >= umAnoAtras)
                .AsEnumerable()
                .GroupBy(p => new { p.DataCadastro.Year, p.DataCadastro.Month })
                .Select(g => new EvolucaoMensal
                {
                    MesAno = $"{g.Key.Month:00}/{g.Key.Year}",
                    PesoTotal = g.Sum(p => p.Peso),
                    Quantidade = g.Count()
                })
                .OrderBy(e => e.MesAno)
                .ToList();
        }

        
        private byte[] GeneratePdfReport(RelatorioPesagensViewModel model)
        {
            var document = QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header()
                        .AlignCenter()
                        .Text("Relatório de Pesagens - EcoTrash")
                        .SemiBold().FontSize(18).FontColor(Colors.Blue.Darken3);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(column =>
                        {
                            column.Spacing(10);

                            
                            if (model.DataInicio.HasValue || model.DataFim.HasValue)
                            {
                                column.Item()
                                    .Background(Colors.Grey.Lighten3)
                                    .Padding(10)
                                    .Text(text =>
                                    {
                                        text.Span("Período: ").SemiBold();
                                        text.Span($"{model.DataInicio:dd/MM/yyyy} a {model.DataFim:dd/MM/yyyy}");
                                    });
                            }

                            
                            column.Item()
                                .Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn();
                                        columns.RelativeColumn();
                                    });

                                    table.Cell().Background(Colors.Blue.Lighten3).Padding(5).Text("Total de Pesagens").SemiBold();
                                    table.Cell().Background(Colors.Blue.Lighten3).Padding(5).Text("Peso Total (kg)").SemiBold();

                                    table.Cell().Padding(5).Text(model.Quantidade.ToString());
                                    table.Cell().Padding(5).Text(model.TotalPeso.ToString("F2"));
                                });

                            
                            column.Item()
                                .Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(2);
                                        columns.RelativeColumn(3);
                                        columns.RelativeColumn(2);
                                        columns.RelativeColumn(3);
                                    });

                                    
                                    table.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Data").SemiBold();
                                    table.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Material").SemiBold();
                                    table.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Peso (kg)").SemiBold();
                                    table.Cell().Background(Colors.Grey.Lighten2).Padding(5).Text("Localização").SemiBold();

                                    // Dados
                                    foreach (var pesagem in model.Pesagens)
                                    {
                                        table.Cell().Padding(5).Text(pesagem.DataCadastro.ToString("dd/MM/yyyy HH:mm"));
                                        table.Cell().Padding(5).Text(pesagem.TipoMaterial);
                                        table.Cell().Padding(5).Text(pesagem.Peso.ToString("F2"));
                                        table.Cell().Padding(5).Text(pesagem.Localizacao);
                                    }
                                });
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(text =>
                        {
                            text.Span("Emitido em: ");
                            text.Span(DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                        });
                });
            });

            return document.GeneratePdf();
        }

        private byte[] GenerateEmpresasPdfReport(List<Empresa> empresas)
        {
            var document = QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);

                    page.Header()
                        .AlignCenter()
                        .Text("Relatório de Empresas - EcoTrash")
                        .SemiBold().FontSize(18).FontColor(Colors.Green.Darken3);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(column =>
                        {
                            column.Spacing(10);

                            column.Item()
                                .Text($"Total de Empresas: {empresas.Count}")
                                .SemiBold();

                            column.Item()
                                .Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(3);
                                        columns.RelativeColumn(2);
                                        columns.RelativeColumn(2);
                                        columns.RelativeColumn(3);
                                    });

                                    
                                    table.Cell().Background(Colors.Green.Lighten3).Padding(5).Text("Empresa").SemiBold();
                                    table.Cell().Background(Colors.Green.Lighten3).Padding(5).Text("CNPJ").SemiBold();
                                    table.Cell().Background(Colors.Green.Lighten3).Padding(5).Text("Telefone").SemiBold();
                                    table.Cell().Background(Colors.Green.Lighten3).Padding(5).Text("Email").SemiBold();

                                    
                                    foreach (var empresa in empresas)
                                    {
                                        table.Cell().Padding(5).Text(empresa.Nome);
                                        table.Cell().Padding(5).Text(empresa.CNPJ);
                                        table.Cell().Padding(5).Text(empresa.Telefone ?? "-");
                                        table.Cell().Padding(5).Text(empresa.Email);
                                    }
                                });
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text($"Emitido em: {DateTime.Now:dd/MM/yyyy HH:mm}");
                });
            });

            return document.GeneratePdf();
        }
    }

    
    public class DashboardViewModel
    {
        public int TotalEmpresas { get; set; }
        public int TotalPesagens { get; set; }
        public int TotalLocais { get; set; }
        public List<PesagemMes> PesagensPorMes { get; set; } = new();
        public List<MaterialStats> MateriaisMaisReciclados { get; set; } = new();
    }

    public class RelatorioPesagensViewModel
    {
        public List<Pesagem> Pesagens { get; set; } = new();
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public double TotalPeso { get; set; }
        public int Quantidade { get; set; }
    }

    public class AnalyticsViewModel
    {
        public double TotalPesoReciclado { get; set; }
        public double MediaPesoPorPesagem { get; set; }
        public List<MaterialStats> TopMateriais { get; set; } = new();
        public List<EvolucaoMensal> EvolucaoMensal { get; set; } = new();
    }

    public class PesagemMes
    {
        public string Mes { get; set; } = string.Empty;
        public double TotalPeso { get; set; }
        public int Quantidade { get; set; }
    }

    public class MaterialStats
    {
        public string Material { get; set; } = string.Empty;
        public double Total { get; set; }
        public int Quantidade { get; set; }
    }

    public class EvolucaoMensal
    {
        public string MesAno { get; set; } = string.Empty;
        public double PesoTotal { get; set; }
        public int Quantidade { get; set; }
    }
}