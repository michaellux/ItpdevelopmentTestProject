using ItpdevelopmentTestProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using MimeDetective;

namespace ItpdevelopmentTestProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        ItpdevelopmentTestProjectContext db;
        public HomeController(ILogger<HomeController> logger, ItpdevelopmentTestProjectContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Tasks.Include(task => task.TaskComments));
        }

        [HttpGet]
        public FileResult DownLoadFile(Guid id)
        {
            TaskComment? taskComment = db.TaskComments.FirstOrDefault(item => item.Id == id);

            byte[] fileContent = taskComment.Content;
            FileType fileType = MimeTypes.GetFileType(() => fileContent);

            return File(fileContent, fileType.Mime);
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
    }
}