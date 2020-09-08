using Demo.Models;
using Demo.MyModels;
using Demo.Services;
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
using System.Threading.Tasks;


// see https://medium.com/@JayantTripathy/import-and-export-excel-file-in-asp-net-core-3-1-razor-page-2be75c1850ec for more references.

namespace Demo.Controllers
{
    public class UploadToDriveController : Controller
    {
        public IWebHostEnvironment _hostingEnvironment { get; }
        public IShipmentSerivice _shipmentSerivice { get; }
        //public IGoogleDriveService _googleDriveService { get; }

        public UploadToDriveController(IWebHostEnvironment hostingEnvironment, IShipmentSerivice shipmentSerivice/*, IGoogleDriveService googleDriveService*/)
        {
            _hostingEnvironment = hostingEnvironment;
            this._shipmentSerivice = shipmentSerivice;
            //_googleDriveService = googleDriveService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(ImportExcel importExcel)
        {
            try
            {
                var driveService = new GoogleDriveFileRepository(_hostingEnvironment);
                await driveService.FileUploadInFolder(importExcel.File);
                return Ok();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
