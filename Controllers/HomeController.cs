using ItpdevelopmentTestProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using MimeDetective;
using Newtonsoft.Json;
using System;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task = ItpdevelopmentTestProject.Models.Task;
using FormHelper;

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
            var projects = db.Projects.Include(project => project.Tasks);
            var tasks = db.Tasks.Include(task => task.TaskComments);

            var tupleModel = new Tuple<IEnumerable<Project>, IEnumerable<Task>>(projects, tasks);

            return View(tupleModel);
        }

        [HttpGet]
        public FileResult DownLoadFile(Guid id)
        {
            TaskComment? taskComment = db.TaskComments.FirstOrDefault(item => item.Id == id);

            byte[] fileContent = taskComment.Content;
            FileType fileType = MimeTypes.GetFileType(() => fileContent);

            return File(fileContent, fileType.Mime);
        }

        [HttpGet]
        public ContentResult GetProject(Guid id)
        {
            
            Project project = db.Projects.Include(project => project.Tasks)
                .ThenInclude(tasks => tasks.TaskComments).FirstOrDefault(item => item.Id == id);

            return new ContentResult() { Content = JsonConvert.SerializeObject(project,
                Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        }), ContentType = "application/json" }; ;
        }

        [HttpGet]
        public JsonResult GetTasksProject(Guid id)
        {
            var tasks = db.Projects.FirstOrDefault(item => item.Id == id).Tasks;
            
            return Json(tasks);
        }


        public IActionResult TaskForm(string Name, string Project, DateTime StartDate,
            DateTime? CancelDate, byte[]? TextContent, byte[]? FileContent)
        {
            if (!ModelState.IsValid)
            {
                var invalidValues = ModelState
                    .Values
                    .Where((value) => value.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid);
                string invalidFields = "";

                foreach(var invalidValue in ModelState)
                {
                    if (invalidValue.Value.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                    {
                        invalidFields += invalidValue.Key + ", ";
                    }
                }

                return FormResult.CreateErrorResult($"Check fields: {invalidFields}");
            }

            if (StartDate > CancelDate)
            {
                return FormResult.CreateErrorResult("Start time and end time. Start time cannot be greater than End time");
            }

            return FormResult.CreateSuccessResult("Task created.");
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