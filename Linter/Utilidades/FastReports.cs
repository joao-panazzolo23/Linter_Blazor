using Microsoft.EntityFrameworkCore;
using Linter.Models.Modelos;
using FastReport;
using Linter.Components.Relatorios;
using System.Runtime.CompilerServices;
using FastReport.Export.PdfSimple;
using Linter.Modelos.Entities;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.FluentUI.AspNetCore.Components.DesignTokens;

namespace Linter.Utilidades
{
    public class FastReports
    {
        public async Task<byte[]> GerarRelatorioMovimentacoes(IEnumerable<FinanceMovement> lstMovi, string nomeRelatorio)
        {

            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Relatorios", "Caixa", $"{nomeRelatorio}.frx");
            var diretorio = Path.GetDirectoryName(filepath);

            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);
            }

            var report = new Report();

            if (File.Exists(filepath))
            {
                report.Report.Load(filepath);
            }
            report.Dictionary.RegisterBusinessObject(lstMovi, "lstMovi", 10, true);
            //report.Report.SetParameterValue("ValorTotal", soma);
            report.Prepare();

            report.Report.Save(filepath);

            var pdfExport = new PDFSimpleExport();
            using (var ms = new MemoryStream())
            {
                pdfExport.Export(report, ms);
                ms.Flush();
                return ms.ToArray();
            }
        }

        public byte[] GerarListagemDeUsuarios(IEnumerable<Users> usuarios, string nomeRelatorio)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Relatorios", "Usuarios", $"{nomeRelatorio}.frx");
            var diretorio = Path.GetDirectoryName(filepath);

            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);
            }

            var report = new Report();

            if (File.Exists(filepath))
            {
                report.Report.Load(filepath);
            }
            report.Dictionary.RegisterBusinessObject(usuarios, "usuarios", 10, true);
            //report.Report.SetParameterValue("ValorTotal", soma);
            report.Prepare();

            report.Report.Save(filepath);

            var pdfExport = new PDFSimpleExport();
            using (var ms = new MemoryStream())
            {
                pdfExport.Export(report, ms);
                ms.Flush();
                return ms.ToArray();
            }
        }

        public async Task<byte[]> GerarRelatorioMovimentacoesPorID(IEnumerable<FinanceMovement> lstMovi, int id)
        {

            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Relatorios", "Caixa", $"RelatorioContasGerenciais.frx");
            var diretorio = Path.GetDirectoryName(filepath);

            if (!Directory.Exists(diretorio))
            {
                Directory.CreateDirectory(diretorio);
            }

            var report = new Report();

            if (File.Exists(filepath))
            {
                report.Report.Load(filepath);
            }
            report.Dictionary.RegisterBusinessObject(lstMovi, "lstMovi", 10, true);
            //report.Report.SetParameterValue("ValorTotal", soma);
            report.Prepare();

            report.Report.Save(filepath);

            var pdfExport = new PDFSimpleExport();
            using (var ms = new MemoryStream())
            {
                pdfExport.Export(report, ms);
                ms.Flush();
                return ms.ToArray();
            }
        }

    }

}
