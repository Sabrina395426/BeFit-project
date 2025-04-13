using System;
using System.Linq;
using System.Threading.Tasks;
using BeFit.Data;
using BeFit.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeFit.Data;
using BeFit.Models;

namespace BeFit.Controllers
{
    [Authorize]
    public class TrainingSessionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TrainingSessionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TrainingSessions
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var sessions = await _context.TrainingSession
                .Where(s => s.UserId == userId)
                .ToListAsync();

            return View(sessions);
        }

        // GET: TrainingSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var session = await _context.TrainingSession
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (session == null || session.UserId != _userManager.GetUserId(User))
                return NotFound();

            return View(session);
        }

        // GET: TrainingSessions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingSessions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StartTime,EndTime")] TrainingSession session)
        {
            if (ModelState.IsValid)
            {
                session.UserId = _userManager.GetUserId(User);
                _context.Add(session);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(session);
        }

        // GET: TrainingSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var session = await _context.TrainingSession.FindAsync(id);
            if (session == null || session.UserId != _userManager.GetUserId(User))
                return NotFound();

            return View(session);
        }

        // POST: TrainingSessions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartTime,EndTime")] TrainingSession session)
        {
            var existing = await _context.TrainingSession.FindAsync(id);
            if (existing == null || existing.UserId != _userManager.GetUserId(User))
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    existing.StartTime = session.StartTime;
                    existing.EndTime = session.EndTime;
                    _context.Update(existing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingSessionExists(session.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(session);
        }

        // GET: TrainingSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var session = await _context.TrainingSession
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (session == null || session.UserId != _userManager.GetUserId(User))
                return NotFound();

            return View(session);
        }

        // POST: TrainingSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var session = await _context.TrainingSession.FindAsync(id);
            if (session != null && session.UserId == _userManager.GetUserId(User))
            {
                _context.TrainingSession.Remove(session);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingSessionExists(int id)
        {
            return _context.TrainingSession.Any(e => e.Id == id);
        }
    }
}
