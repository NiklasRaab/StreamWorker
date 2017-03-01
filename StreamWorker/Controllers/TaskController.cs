using System.Web.Mvc;
using Framework.Mvc.Controller;
using StreamWorker.Business.Repository;
using StreamWorker.ViewModels.Task;

namespace StreamWorker.Controllers
{
    public class TaskController : BaseController
    {
        public TaskController(ITaskRepository taskRepository)
        {
            TaskRepository = taskRepository;
        }

        private ITaskRepository TaskRepository { get; }

        public ActionResult Tasks()
        {
            var tasks = TaskRepository.All();
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[MultipleButton(Name = "action", Argument = "AddDescription")]
        public ActionResult AddDescription(CreateTaskViewModel viewModel)
        {
            viewModel.TimeLineEntryViewModels.Add(new DescriptionTimeLineEntryViewModel());
            return View("Create", viewModel);
        }

        [HttpPost]
        //[MultipleButton(Name = "action", Argument = "Save")]
        public ActionResult Create(CreateTaskViewModel viewModel)
        {
            return View("Tasks");
        }
    }
}