using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using ASSIGNMENT.Models;

namespace ASSIGNMENT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment; // For file handling

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Lecture");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Approval() 
        { 
            return View();
        }

        public IActionResult Lecture()
        {
            return View();
        }

        public IActionResult Track()
        {
            return View();
        }

        public IActionResult Claim()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(Claims model)
        {
            if (ModelState.IsValid)
            {
                // Handle file upload
                if (model.SupportingDocument != null)
                {
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.SupportingDocument.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.SupportingDocument.CopyToAsync(stream);
                    }

                    // Optionally, you can pass the file path to the view to display or process it later
                    ViewBag.FilePath = "/uploads/" + uniqueFileName;
                }

                // Redirect to Track action after form submission
                return RedirectToAction("Track");
            }

            // If model state is invalid, return the form view with the current data
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
