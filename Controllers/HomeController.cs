using ItpdevelopmentTestProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using MimeDetective;
using Newtonsoft.Json;
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

        public IActionResult Index(string? id)
        {
            var routeValues = HttpContext.GetRouteData().Values;

            var allProjects = db.Projects.Include(project => project.Tasks);

            var filteredprojects = allProjects.Where(project => project.Id.ToString() == (id ?? project.Id.ToString()));

            var tasks = db.Tasks.Include(task => task.TaskComments);

            var tupleModel = new Tuple<IEnumerable<Project>, IEnumerable<Task>, IEnumerable<Project>>(allProjects, tasks, filteredprojects);

            ViewData["Id"] = id;

            return View(tupleModel);
        }


        public IActionResult FilterProjects(Guid? Id)
        {
            var projects = db.Projects
                .Where(project => project.Id == (Id ?? project.Id))
                .Include(project => project.Tasks);
            var tasks = db.Tasks.Include(task => task.TaskComments);

            var tupleModel = new Tuple<IEnumerable<Project>, IEnumerable<Task>>(projects, tasks);

            FormResult.CreateSuccessResult("Projects filtered");

            return RedirectToAction("Index", new {id = Id.ToString() });
        }

        public IActionResult FilterTasks(DateTime StartDate, DateTime? CancelDate)
        {
            var projects = db.Projects.Include(project => project.Tasks);
            var tasks = db.Tasks.Include(task => task.TaskComments)
                .Where(task => task.StartDate >= StartDate)
                .Where(task => task.CancelDate <= (CancelDate ?? DateTime.UtcNow));

            var tupleModel = new Tuple<IEnumerable<Project>, IEnumerable<Task>>(projects, tasks);

            return new OkResult();
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
            DateTime? CancelDate, string[]? TextContent)
        {
            IActionResult validationResult = Validate(StartDate, CancelDate);
            if (validationResult is not OkResult)
            {
                return validationResult;
            }

            List<byte[]>? FileContent = new();
            IFormFileCollection fileCollection = HttpContext.Request.Form.Files;
            foreach (var file in fileCollection)
            {
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        FileContent.Add(fileBytes);
                    }
                }
            }

            ItpdevelopmentTestProject.Models.Task.Create(db, Name, Project, StartDate, CancelDate, TextContent, FileContent);

            return FormResult.CreateSuccessResult("Task created.");
        }

        public IActionResult ProjectForm(string Name)
        {
            if (!ModelState.IsValid)
            {
                return FormResult.CreateErrorResult("Check project name");
            }

            Project.CreateAsync(db, Name);

            return FormResult.CreateSuccessResult("Project created.");
        }

        public async Task<IActionResult> TaskAsync(Guid? id)
        {
            if (id != null)
            {
                var projects = db.Projects.Include(project => project.Tasks);
                var tasks = db.Tasks.Include(task => task.TaskComments);

                ItpdevelopmentTestProject.Models.Task? task = await db.Tasks.Include(tasks => tasks.TaskComments).Include(tasks => tasks.Project).FirstOrDefaultAsync(p => p.Id == id);
                var tupleModel = new Tuple<IEnumerable<Project>, ItpdevelopmentTestProject.Models.Task?, IEnumerable<ItpdevelopmentTestProject.Models.Task?>>(projects, task, tasks);
                if (task != null) return View(tupleModel);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult EditTaskForm(Guid Id, string Name, string Project, DateTime StartDate,
            DateTime? CancelDate, string[]? TextContent)
        {


            if (StartDate > CancelDate)
            {
                return FormResult.CreateErrorResult("Start time and end time. Start time cannot be greater than End time");
            }
            if (string.IsNullOrEmpty(Name))
            {
                return FormResult.CreateErrorResult("Name is empty");
            }


            List<byte[]>? FileContent = new();
            IFormFileCollection fileCollection = HttpContext.Request.Form.Files;
            foreach (var file in fileCollection)
            {
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        FileContent.Add(fileBytes);
                    }
                }
            }
            try
            {
                ItpdevelopmentTestProject.Models.Task.Update(db, Id, Name, Project, StartDate, CancelDate, TextContent, FileContent);
                return FormResult.CreateSuccessResult("Task created.");
            }
            catch (Exception e)
            {
                return FormResult.CreateErrorResult($"Problem with save: {e.Message}");
            }


         
        }

        public IActionResult Validate(DateTime StartDate, DateTime? CancelDate)
        {
            if (!ModelState.IsValid)
            {
                var invalidValues = ModelState
                    .Values
                    .Where((value) => value.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid);
                string invalidFields = "";

                foreach (var invalidValue in ModelState)
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

            return new OkResult();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}