using MarkdownViewer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;

using Microsoft.AspNetCore.Hosting;
using System.Text.RegularExpressions;

namespace MarkdownViewer.Controllers
{
    
   
    public class HomeController : Controller
    {
        private IWebHostEnvironment _environment;
        private readonly ILogger<HomeController> _logger;
      

     
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment Environment)
        {
            _logger = logger;
            _environment = Environment;
          
        }

        public IActionResult Index()
        {
          
            string[] filePaths = Directory.GetFiles(Path.Combine(this._environment.WebRootPath, "Files/"));

            //Copy File names to Model collection.
            List<FileModel> files = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }

            return View(files);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        public FileResult DownloadFile(string fileName)
        {
            //Build the File Path.
            string path = Path.Combine(this._environment.WebRootPath, "Files/") + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }

        [HttpPost]
        public ActionResult ReadFile(string fileName)
        {
            //Build the File Path.
            string path = Path.Combine(this._environment.WebRootPath, "Files/") + fileName;

         
            string text = System.IO.File.ReadAllText(path);

            TempData["Message"] = text;
            return RedirectToAction("Index");

        }

    }
}
