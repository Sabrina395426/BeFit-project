using BeFit.Data;
using BeFit.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeFit.Controllers
{
    public class ExerciseTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExerciseTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExerciseType
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExerciseType.ToListAsync());
        }

        // GET: ExerciseType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExerciseType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description")] ExerciseType exerciseType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exerciseType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exerciseType);
        }
    }
}
