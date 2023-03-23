using Day6Bonus.Models;
using Day6Bonus.Models.Helpers;
using Day6Bonus.Models.View_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Day6Bonus.Controllers
{
    public class TicketController : Controller
    {
        private readonly ImageFilters  _ImageFilter;
        private readonly ILogger<TicketController> _Logger;
        public TicketController(IOptionsMonitor<ImageFilters> imageFilters, ILogger<TicketController> logger)
        {
            _ImageFilter = imageFilters.CurrentValue;
            _Logger = logger;
        }
        public IActionResult Index()
        {
            _Logger.LogInformation(_ImageFilter.ToString());
            return View();
        }

        #region Validation
        public IActionResult TitleValidation(string title)
        {
            if(Ticket.GetTickets().Any(e => e.Title == title)) {
                return Json($"{title} is taken");
            }
            return Json(true);
        }

        #endregion

        [HttpPost]
        public IActionResult Add(TicketVM tvm)
        {
            if(tvm.Image is null)
            {
                ModelState.AddModelError("", "Image is not found");
                return View("index");
            }


            if(tvm.Image.Length > _ImageFilter.MaxSize)
            {
                ModelState.AddModelError("", "Maximum size was reached");

                //modelstate doesnot work when using redirectToAction
                return RedirectToAction(nameof(Index));
            }

            string sentExtension = Path.GetExtension(tvm.Image.FileName).ToLower();

            if (!_ImageFilter.AllowedExtensions.Contains(sentExtension))
            {
                ModelState.AddModelError("", "Unsupported Extension");
                //modelstate doesnot work when using redirectToAction

                return RedirectToAction(nameof(Index));
            }


            string newName = Guid.NewGuid().ToString() + sentExtension;
            string FullPath = _ImageFilter.FolderPath + newName;


            using (var stream = System.IO.File.Create(FullPath))
            {
                tvm.Image.CopyTo(stream);
            } ;


            Ticket.GetTickets().Add(new Ticket { Title = tvm.Title, Image_url = newName });

            var allticket = Ticket.GetTickets();

            return RedirectToAction(nameof(Index));
        }
    }
}
