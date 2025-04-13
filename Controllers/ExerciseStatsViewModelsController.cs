using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeFit.Data;
using BeFit.Models.ViewModels;

namespace BeFit.Controllers
{
    public class ExerciseStatsViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExerciseStatsViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExerciseStatsViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExerciseStatsViewModel.ToListAsync());
        }

        // GET: ExerciseStatsViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseStatsViewModel = await _context.ExerciseStatsViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exerciseStatsViewModel == null)
            {
                return NotFound();
            }

            return View(exerciseStatsViewModel);
        }

        // GET: ExerciseStatsViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExerciseStatsViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ExerciseName,TotalReps,TotalSets,TotalLoad")] ExerciseStatsViewModel exerciseStatsViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exerciseStatsViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exerciseStatsViewModel);
        }

        // GET: ExerciseStatsViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseStatsViewModel = await _context.ExerciseStatsViewModel.FindAsync(id);
            if (exerciseStatsViewModel == null)
            {
                return NotFound();
            }
            return View(exerciseStatsViewModel);
        }

        // POST: ExerciseStatsViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ExerciseName,TotalReps,TotalSets,TotalLoad")] ExerciseStatsViewModel exerciseStatsViewModel)
        {
            if (id != exerciseStatsViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exerciseStatsViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExerciseStatsViewModelExists(exerciseStatsViewModel.Id))
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
            return View(exerciseStatsViewModel);
        }

        // GET: ExerciseStatsViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exerciseStatsViewModel = await _context.ExerciseStatsViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (exerciseStatsViewModel == null)
            {
                return NotFound();
            }

            return View(exerciseStatsViewModel);
        }

        // POST: ExerciseStatsViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exerciseStatsViewModel = await _context.ExerciseStatsViewModel.FindAsync(id);
            if (exerciseStatsViewModel != null)
            {
                _context.ExerciseStatsViewModel.Remove(exerciseStatsViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExerciseStatsViewModelExists(int id)
        {
            return _context.ExerciseStatsViewModel.Any(e => e.Id == id);
        }
    }
}
