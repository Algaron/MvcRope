#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcRope.Data;
using MvcRope.Models;

namespace MvcRope.Controllers
{
    public class RopesController : Controller
    {
        private readonly MvcRopeContext _context;

        public RopesController(MvcRopeContext context)
        {
            _context = context;
        }

        // GET: Ropes
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Rope.ToListAsync());
        //}
        public async Task<IActionResult> Index(string searchString)
        {
            var ropes = from m in _context.Rope
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                ropes = ropes.Where(r => r.Ropename!.Contains(searchString));
            }

            return View(await ropes.ToListAsync());
        }

        // GET: Ropes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rope = await _context.Rope
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rope == null)
            {
                return NotFound();
            }

            return View(rope);
        }

        // GET: Ropes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ropes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ropename,CreatedDate,AmountMade")] Rope rope)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rope);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rope);
        }

        // GET: Ropes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rope = await _context.Rope.FindAsync(id);
            if (rope == null)
            {
                return NotFound();
            }
            return View(rope);
        }

        // POST: Ropes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ropename,CreatedDate,AmountMade")] Rope rope)
        {
            if (id != rope.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rope);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RopeExists(rope.Id))
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
            return View(rope);
        }

        // GET: Ropes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rope = await _context.Rope
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rope == null)
            {
                return NotFound();
            }

            return View(rope);
        }

        // POST: Ropes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rope = await _context.Rope.FindAsync(id);
            _context.Rope.Remove(rope);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RopeExists(int id)
        {
            return _context.Rope.Any(e => e.Id == id);
        }
    }
}
