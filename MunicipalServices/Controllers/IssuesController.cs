using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MunicipalServices.Data;
using MunicipalServices.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace MunicipalServices.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IssueRepository _repo;  // repository field
        private readonly IWebHostEnvironment _env; // for uploads

        public IssuesController(IssueRepository repo, IWebHostEnvironment env)
        {
            _repo = repo;
            _env = env;
        }

        // GET: Issues
        public IActionResult Index()
        {
            var issues = _repo.GetAll();
            return View(issues);
        }

        // GET: Issues/Create
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(new[]
            {
                "Sanitation", "Roads", "Electricity", "Water", "Waste", "Other"
            });
            return View();
        }

        // POST: Issues/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Issue model, IFormFile? attachment, string? notifySms, string? notifyEmail)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(new[]
                {
                    "Sanitation", "Roads", "Electricity", "Water", "Waste", "Other"
                }, model?.Category);
                return View(model);
            }

            // handle attachment
            if (attachment != null && attachment.Length > 0)
            {
                var allowedExt = new[] { ".jpg", ".jpeg", ".png", ".pdf", ".doc", ".docx" };
                var ext = Path.GetExtension(attachment.FileName)?.ToLowerInvariant();

                if (string.IsNullOrEmpty(ext) || !allowedExt.Contains(ext))
                {
                    ModelState.AddModelError("AttachmentFileName", "Unsupported file type. Allowed: jpg, jpeg, png, pdf, doc, docx.");
                    ViewBag.Categories = new SelectList(new[]
                    {
                        "Sanitation", "Roads", "Electricity", "Water", "Waste", "Other"
                    }, model?.Category);
                    return View(model);
                }

                // Validate file size (max 5MB)
                if (attachment.Length > 5 * 1024 * 1024)
                {
                    ModelState.AddModelError("AttachmentFileName", "File size exceeds the 5MB limit.");
                    ViewBag.Categories = new SelectList(new[]
                    {
                        "Sanitation", "Roads", "Electricity", "Water", "Waste", "Other"
                    }, model?.Category);
                    return View(model);
                }

                // save into wwwroot/uploads
                var uploadsDir = Path.Combine(_env.WebRootPath, "uploads");
                if (!Directory.Exists(uploadsDir))
                    Directory.CreateDirectory(uploadsDir);

                var fileName = Guid.NewGuid().ToString() + ext;
                var savePath = Path.Combine(uploadsDir, fileName);
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await attachment.CopyToAsync(stream);
                }
                model.AttachmentFileName = fileName;
            }

            model.NotifyBySms = notifySms == "on";
            model.NotifyByEmail = notifyEmail == "on";
            model.Status = IssueStatus.Received;
            model.CreatedAt = DateTime.UtcNow;

            var added = _repo.Add(model);

            TempData["SuccessMessage"] = $"Your report was submitted. Reference: {added.ReferenceNumber}";
            return RedirectToAction("Confirmation", new { id = added.Id });
        }

        public IActionResult Confirmation(int id)
        {
            var issue = _repo.Get(id);
            if (issue == null) return NotFound();
            return View(issue);
        }

        public IActionResult Details(int id)
        {
            var issue = _repo.Get(id);
            if (issue == null) return NotFound();
            return View(issue);
        }
    }
}