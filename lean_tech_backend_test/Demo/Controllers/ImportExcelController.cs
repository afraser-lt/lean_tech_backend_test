using Demo.Models;
using Demo.MyModels;
using Demo.Services.Interfaces;
using Google.Apis.Sheets.v4;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;


// see https://medium.com/@JayantTripathy/import-and-export-excel-file-in-asp-net-core-3-1-razor-page-2be75c1850ec for more references.

namespace Demo.Controllers
{
    public class ImportExcelController : Controller
    {
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "Demo";
        static readonly string SpreadSheetId = "1cjL5-OijhkhbbOylZmrKtYl5EpXoZnE2";
        static readonly string sheet = "Sheet1";
        public static SheetsService service;

        public IWebHostEnvironment _hostingEnvironment { get; }
        public IShipmentSerivice _shipmentSerivice { get; }

        public ImportExcelController(IWebHostEnvironment hostingEnvironment, IShipmentSerivice shipmentSerivice)
        {
            _hostingEnvironment = hostingEnvironment;
            this._shipmentSerivice = shipmentSerivice;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Import(ImportExcel importExcel)
        {
            var shipments = new List<Shipment>();

            string FilePath = string.Empty;
            FilePath = Path.GetTempFileName();
            var fileLocation = new FileInfo(FilePath);

            //!importExcel.File.FileName.EndsWith(".csv") ? fileLocation: null)
            using (ExcelPackage package = new ExcelPackage(fileLocation))
            {
                if (importExcel.File.FileName.EndsWith(".csv"))
                {
                    char csvDelimiter = ',';
                    var format = new ExcelTextFormat()
                    {
                        Delimiter = csvDelimiter,
                        Culture = CultureInfo.InvariantCulture,
                        TextQualifier = '"'
                    };

                    //create a WorkSheet
                    ExcelWorksheet worksheetCsv = package.Workbook.Worksheets.Add("Data");
                    worksheetCsv.Cells[1, 1].LoadFromText(importExcel.File.FileName, format);
                    var x = worksheetCsv.Cells[1, 1].Value.ToString();
                    //shipments = ReadCSV(worksheetCsv, FilePath, csvDelimiter);
                }
                else
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets["Data"];
                    int totalRows = workSheet.Dimension.Rows;
                    shipments = ReadXLS(workSheet);
                }
            }

            _shipmentSerivice.Import(shipments);
            return View("Index", importExcel);
        }

        public List<Shipment> ReadCSV(ExcelWorksheet workSheet, string FilePath, char delimeter)
        {
            try
            {
                var shipments = new List<Shipment>();

                ExcelTextFormat format = new ExcelTextFormat()
                {
                    Delimiter = delimeter
                };

                int totalRows = workSheet.Dimension.Rows;

                for (int i = 2; i <= totalRows; i++)
                {
                    shipments.Add(new Shipment()
                    {
                        CarrierId = workSheet.Cells[i, 1].Value?.ToString(),
                        Date = workSheet.Cells[i, 2].Value.ToString(),
                        OriginCountry = workSheet.Cells[i, 3].LoadFromText(FilePath, format).Value.ToString(),
                        OriginState = workSheet.Cells[i, 4].Value.ToString(),
                        OriginCity = workSheet.Cells[i, 5].Value.ToString(),
                        DestinationCountry = workSheet.Cells[i, 6].Value.ToString(),
                        DestinationState = workSheet.Cells[i, 7].Value.ToString(),
                        DestinationCity = workSheet.Cells[i, 8].Value.ToString(),
                        PickupDate = workSheet.Cells[i, 9].Value.ToString(),
                        DeliveryDate = workSheet.Cells[i, 10].Value.ToString(),
                        Status = workSheet.Cells[i, 11].Value.ToString(),
                        Rate = workSheet.Cells[i, 12].Value.ToString(),
                    });
                }

                return shipments;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public List<Shipment> ReadXLS(ExcelWorksheet workSheet)
        {
            try
            {
                var shipments = new List<Shipment>();
                int totalRows = workSheet.Dimension.Rows;

                for (int i = 2; i <= totalRows; i++)
                {
                    shipments.Add(new Shipment()
                    {
                        CarrierId = workSheet.Cells[i, 1].Value?.ToString(),
                        Date = workSheet.Cells[i, 2].Value?.ToString(),
                        OriginCountry = workSheet.Cells[i, 3].Value?.ToString(),
                        OriginState = workSheet.Cells[i, 4].Value?.ToString(),
                        OriginCity = workSheet.Cells[i, 5].Value?.ToString(),
                        DestinationCountry = workSheet.Cells[i, 6].Value?.ToString(),
                        DestinationState = workSheet.Cells[i, 7].Value?.ToString(),
                        DestinationCity = workSheet.Cells[i, 8].Value?.ToString(),
                        PickupDate = workSheet.Cells[i, 9].Value?.ToString(),
                        DeliveryDate = workSheet.Cells[i, 10].Value?.ToString(),
                        Status = workSheet.Cells[i, 11].Value?.ToString(),
                        Rate = workSheet.Cells[i, 12].Value?.ToString(),
                    });
                }

                return shipments;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        public ActionResult Import2()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "UploadExcel";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            StringBuilder sb = new StringBuilder();
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }
                    IRow headerRow = sheet.GetRow(0); //Get Header Row
                    int cellCount = headerRow.LastCellNum;
                    sb.Append("<table class='table table-bordered'><tr>");
                    for (int j = 0; j < cellCount; j++)
                    {
                        ICell cell = headerRow.GetCell(j);
                        if (cell == null || string.IsNullOrWhiteSpace(cell.ToString()))
                        {
                            continue;
                        }

                        sb.Append("<th>" + cell.ToString() + "</th>");
                    }
                    sb.Append("</tr>");
                    sb.AppendLine("<tr>");
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null)
                        {
                            continue;
                        }

                        if (row.Cells.All(d => d.CellType == CellType.Blank))
                        {
                            continue;
                        }

                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            if (row.GetCell(j) != null)
                            {
                                sb.Append("<td>" + row.GetCell(j).ToString() + "</td>");
                            }
                        }
                        sb.AppendLine("</tr>");
                    }
                    sb.Append("</table>");
                }
            }
            return this.Content(sb.ToString());
        }




    }
}
