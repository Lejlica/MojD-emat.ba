using FIT_Api_Example.Data;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Modul1.ViewModels;
using FIT_Api_Example.Modul2.Models;
using Microsoft.AspNetCore.Mvc;
using ReportApp;
using System.Data;

using AspNetCore.Reporting;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection.PortableExecutable;
using Azure.Core;
using ServiceStack.Web;
using Microsoft.AspNetCore.StaticFiles;
using AspNetCore.ReportingServices.ReportProcessing.ReportObjectModel;
using System.Security.Cryptography;

namespace FIT_Api_Example.Modul2.Controllers
{
   
    [ApiController]
    [Route("[controller]/[action]")]
    public class Report1Controller : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public Report1Controller(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        
        public static List<ReportSadrzaj> getModeratori(ApplicationDbContext db)
        {
            List<ReportSadrzaj> podaci = db.Moderator.Select(s => new ReportSadrzaj
            {
                Ime = s.Ime,
                Prezime=s.Prezime,
                Telefon=s.Telefon,
                Email=s.email

            }).ToList();

            return podaci;
        }
        [HttpGet]
        public ActionResult Index()
        {
            LocalReport _localReport = new LocalReport("Reporti/Report1.rdlc");
            List<ReportSadrzaj> podaci = getModeratori(_dbContext);
            //DataSet ds = new DataSet();
            _localReport.AddDataSource("DataSet1", podaci);

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            //parameters.Add("ReportSastavio", HttpContext.LogiraniKorisnik().ImePrezime);
           
            //ReportResult result = _localReport.Execute(RenderType.ExcelOpenXml, parameters: parameters);
            //return File(result.MainStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");


            ReportResult result = _localReport.Execute(RenderType.Pdf, 1);

            return File(result.MainStream, "application/pdf");

        }

        //[HttpGet("DownloadFile")]
        //public async Task<ActionResult> DownloadFile()
        //{
        //    // ... code for validation and get the file
        //    var filePath = Path.Combine("Reporti/Report1.rdlc");
        //    var provider = new FileExtensionContentTypeProvider();
        //    if (!provider.TryGetContentType(filePath, out var contentType))
        //    {
        //        contentType = "application/msword";
        //    }

        //    var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
        //    return File(bytes, contentType, Path.GetFileName(filePath));


        //}
    }


}

