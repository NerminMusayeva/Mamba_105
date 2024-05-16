using mamba_project.DAL;
using mamba_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mamba_project.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class OurTeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public OurTeamController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _context.OurTeams.ToListAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task< IActionResult> Create(OurTeam ourTeam)
        {
            if (!ModelState.IsValid)
            {
                return View(ourTeam);
            }
            string path = _webHostEnvironment.WebRootPath + @"\Upload\Team\";
            string fileName = Guid.NewGuid() + ourTeam.ImgFile.FileName;
            using(FileStream fileStream=new FileStream(path + fileName, FileMode.Create))
            {
                ourTeam.ImgFile.CopyTo(fileStream);
            }
            ourTeam.ImgUrl = fileName;

            await _context.AddAsync(ourTeam);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
