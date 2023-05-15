using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using RadiografiaEmpresarial.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadiografiaEmpresarial.Core.Services
{
    public class ExcelService : IExcelService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExcelService(IUnitOfWork unitOfWork)

        {
            _unitOfWork = unitOfWork;
        }

        public async Task<byte[]> ReporteOrganizacion()
        {
            var organizaciones = _unitOfWork.OrganizacionesRepository.GetAllAsNoTracking();
            //var libro = new ExcelPackage();

            using (var libro = new ExcelPackage())
            {
                var worksheet = libro.Workbook.Worksheets.Add("Organizaciones");
                worksheet.Cells["A1:D1"].Merge = true;
                worksheet.Cells["A1"].Value = "REPORTE ORGANIZACIÓN";
                worksheet.Cells["A1"].Style.Font.Name = "Calibri";
                worksheet.Cells["A1"].Style.Font.Size = 30;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1:D1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A1:D1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A1:D1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A1:D1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                List<string> listHeader = new List<string>()
                {
                    "A2","B2","C2","D2"
                };

                listHeader.ForEach(x =>
                {
                    worksheet.Cells[x].Style.Font.Bold = true;
                    worksheet.Cells[x].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[x].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[x].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[x].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[x].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    worksheet.Cells[x].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                });

                worksheet.Cells[listHeader[0]].Value = "Slug";
                worksheet.Cells[listHeader[1]].Value = "Identificacion";
                worksheet.Cells[listHeader[2]].Value = "Nombre";
                worksheet.Cells[listHeader[3]].Value = "Fecha de Creación";

                for (int i=0; i < organizaciones.Count; i++)
                {
                    worksheet.Cells[i + 3, 1].Value = organizaciones[i].Slug;
                    worksheet.Cells[i + 3, 2].Value = organizaciones[i].Identificacion;
                    worksheet.Cells[i + 3, 3].Value = organizaciones[i].Nombre;
                    worksheet.Cells[i + 3, 4].Value = organizaciones[i].CreatedAt;
                    worksheet.Cells[i + 3, 4].Style.Numberformat.Format = "dd-MM-yyyy HH:mm";
                }

                for(int i=1; i < 5; i++)
                {
                    worksheet.Column(i).AutoFit();
                }
                
                for(int i=0; i<organizaciones.Count; i++)
                {
                    for(int j=1; j<5; j++)
                    {
                        worksheet.Cells[i + 3, j].Style.Font.Size = 10;
                        worksheet.Cells[i + 3, j].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[i + 3, j].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[i + 3, j].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[i + 3, j].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    }
                }

                return await libro.GetAsByteArrayAsync();
            }

        }

        public async Task<byte[]> ReporteGrupoTrabajo()
        {
            var grupos = await _unitOfWork.GrupostrabajoRepository.GetAllComplet();
            //var libro = new ExcelPackage();

            using (var libro = new ExcelPackage())
            {
                var worksheet = libro.Workbook.Worksheets.Add("Grupos de Trabajo");
                worksheet.Cells["A1:I1"].Merge = true;
                worksheet.Cells["A1"].Value = "REPORTE GRUPOS DE TRABAJO";
                worksheet.Cells["A1"].Style.Font.Name = "Calibri";
                worksheet.Cells["A1"].Style.Font.Size = 30;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1:I1"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A1:I1"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A1:I1"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A1:I1"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                List<string> listHeader = new List<string>()
                {
                    "A2","B2","C2","D2","E2","F2","G2","H2","I2"
                };

                listHeader.ForEach(x =>
                {
                    worksheet.Cells[x].Style.Font.Bold = true;
                    worksheet.Cells[x].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[x].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[x].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[x].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[x].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    worksheet.Cells[x].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                });

                worksheet.Cells[listHeader[0]].Value = "Estado";
                worksheet.Cells[listHeader[1]].Value = "Organización";
                worksheet.Cells[listHeader[2]].Value = "Vínculo";
                worksheet.Cells[listHeader[3]].Value = "Supervisor";
                worksheet.Cells[listHeader[4]].Value = "Motivo Solicitud";
                worksheet.Cells[listHeader[5]].Value = "Motivo Respuesta";
                worksheet.Cells[listHeader[6]].Value = "Fecha de Creación";
                worksheet.Cells[listHeader[7]].Value = "Fecha de Actualización";
                worksheet.Cells[listHeader[8]].Value = "Fecha de Eliminación";

                for (int i = 0; i < grupos.Count; i++)
                {
                    worksheet.Cells[i + 3, 1].Value = grupos[i].IdEstadoNavigation.Nombre;
                    worksheet.Cells[i + 3, 2].Value = grupos[i].IdOrganizacionNavigation.Nombre;
                    worksheet.Cells[i + 3, 3].Value = grupos[i].IdVinculoNavigation.Nombre;
                    worksheet.Cells[i + 3, 4].Value = grupos[i].IdSupervisadorNavigation.Nombre;
                    worksheet.Cells[i + 3, 5].Value = grupos[i].MotivoSolicitud;
                    worksheet.Cells[i + 3, 6].Value = grupos[i].MotivoRespuesta;
                    worksheet.Cells[i + 3, 7].Value = grupos[i].CreatedAt;
                    worksheet.Cells[i + 3, 8].Value = grupos[i].UpdatedAt;
                    worksheet.Cells[i + 3, 9].Value = grupos[i].DeletedAt;
                    worksheet.Cells[i + 3, 7].Style.Numberformat.Format = "dd-MM-yyyy HH:mm";
                    worksheet.Cells[i + 3, 8].Style.Numberformat.Format = "dd-MM-yyyy HH:mm";
                    worksheet.Cells[i + 3, 9].Style.Numberformat.Format = "dd-MM-yyyy HH:mm";
                }

                for (int i = 1; i < 10; i++)
                {
                    worksheet.Column(i).AutoFit();
                }

                for (int i = 0; i < grupos.Count; i++)
                {
                    for (int j = 1; j < 10; j++)
                    {
                        worksheet.Cells[i + 3, j].Style.Font.Size = 10;
                        worksheet.Cells[i + 3, j].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[i + 3, j].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[i + 3, j].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        worksheet.Cells[i + 3, j].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    }
                }

                return await libro.GetAsByteArrayAsync();
            }

        }
    }
}
