using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeFit.Data;
using BeFit.Models;

namespace BeFit.Controllers
{
    public class ExerciseInSessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExerciseInSessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExerciseInSessions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ExercisesInSession.Include(e => e.ExerciseType).Include(e => e.TrainingSession);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ExerciseInSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseInSession = await _context.ExercisesInSession
                .Include(e => e.ExerciseType)
                .Include(e => e.TrainingSession)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exerciseInSession == null)
            {
                return NotFound();
            }

            return View(exerciseInSession);
        }

        // GET: ExerciseInSessions/Create
        public IActionResult Create()
        {
            ViewData["ExerciseTypeId"] = new SelectList(_context.ExerciseType, "Id", "Name");
            ViewData["TrainingSessionId"] = new SelectList(_context.TrainingSession, "Id", "UserId");
            return View();
        }

        // POST: ExerciseInSessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExerciseTypeId,TrainingSessionId,Load,Sets,Reps")] ExerciseInSession exerciseInSession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exerciseInSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExerciseTypeId"] = new SelectList(_context.ExerciseType, "Id", "Name", exerciseInSession.ExerciseTypeId);
            ViewData["TrainingSessionId"] = new SelectList(_context.TrainingSession, "Id", "UserId", exerciseInSession.TrainingSessionId);
            return View(exerciseInSession);
        }

        // GET: ExerciseInSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseInSession = await _context.ExercisesInSession.FindAsync(id);
            if (exerciseInSession == null)
            {
                return NotFound();
            }
            ViewData["ExerciseTypeId"] = new SelectList(_context.ExerciseType, "Id", "Name", exerciseInSession.ExerciseTypeId);
            ViewData["TrainingSessionId"] = new SelectList(_context.TrainingSession, "Id", "UserId", exerciseInSession.TrainingSessionId);
            return View(exerciseInSession);
        }

        // POST: ExerciseInSessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExerciseTypeId,TrainingSessionId,Load,Sets,Reps")] ExerciseInSession exerciseInSession)
        {
            if (id != exerciseInSession.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exerciseInSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseInSessionExists(exerciseInSession.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExerciseTypeId"] = new SelectList(_context.ExerciseType, "Id", "Name", exerciseInSession.ExerciseTypeId);
            ViewData["TrainingSessionId"] = new SelectList(_context.TrainingSession, "Id", "UserId", exerciseInSession.TrainingSessionId);
            return View(exerciseInSession);
        }

        // GET: ExerciseInSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseInSession = await _context.ExercisesInSession
                .Include(e => e.ExerciseType)
                .Include(e => e.TrainingSession)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exerciseInSession == null)
            {
                return NotFound();
            }

            return View(exerciseInSession);
        }

        // POST: ExerciseInSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exerciseInSession = await _context.ExercisesInSession.FindAsync(id);
            if (exerciseInSession != null)
            {
                _context.ExercisesInSession.Remove(exerciseInSession);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseInSessionExists(int id)
        {
            return _context.ExercisesInSession.Any(e => e.Id == id);
        }
    }
}
