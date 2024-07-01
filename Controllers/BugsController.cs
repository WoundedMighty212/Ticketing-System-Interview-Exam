//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ticketing_System_Interview_Exam.Data;
using Ticketing_System_Interview_Exam.Models;

namespace Ticketing_System_Interview_Exam.Controllers
{
    public class BugsController : Controller
    {
        private readonly Ticketing_System_Interview_ExamContext _context;

        public BugsController(Ticketing_System_Interview_ExamContext context)
        {
            _context = context;
        }

        // GET: Bugs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bug.ToListAsync());
        }
        // GET: Bugs filtered, still need to change code
        public async Task<IActionResult> RD_Index()
        {
            List<Bug> listOfBugs = _context.Bug.Where(j => j.Status.ToString() == "0"
            || j.Status.ToString() == "1").ToList();
            return View(listOfBugs);
        }
        // GET: Bugs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bug = await _context.Bug
                .FirstOrDefaultAsync(m => m.BugId == id);
            if (bug == null)
            {
                return NotFound();
            }

            return View(bug);
        }

        // GET: Bugs/Create
        public IActionResult Create()
        {
            ViewBag.Statuses = Enum.GetValues(typeof(BugStatus))
                           .Cast<BugStatus>()
                           .Select(s => new SelectListItem
                           {
                               Text = s.ToString(),
                               Value = ((int)s).ToString()
                           }).ToList();

            return View();
        }

        // POST: Bugs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BugId,Summary,Description,Status,CreatedByUserId")] Bug bug)
        {
            if (ModelState.IsValid)
            {
                bug.CreatedByUserId = 1;
                _context.Add(bug);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bug);
        }

        // GET: Bugs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bug = await _context.Bug.FindAsync(id);
            if (bug == null)
            {
                return NotFound();
            }

            ViewBag.Statuses = Enum.GetValues(typeof(BugStatus))
                          .Cast<BugStatus>()
                          .Select(s => new SelectListItem
                          {
                              Text = s.ToString(),
                              Value = ((int)s).ToString()
                          }).ToList();

            return View(bug);
        }
        BugStatus bugstatus;
        public async Task<IActionResult> Edit_RD(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bug = await _context.Bug.FindAsync(id);
            if (bug == null)
            {
                return NotFound();
            }

            switch (bug.Status)
            {
                case "0":
                    {
                        bugstatus = BugStatus.open;
                        break;
                    }
                case "1":
                    {
                        bugstatus = BugStatus.inprogress;
                        break;
                    }
                case "2":
                    {
                        bugstatus = BugStatus.resolved;
                        break;
                    }
                case "3":
                    {
                        bugstatus = BugStatus.closed;
                        break;
                    }
            }

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem($"{bugstatus}","0"));
            selectListItems.Add(new SelectListItem($"{BugStatus.resolved}", "1"));

            ViewBag.Statuses = selectListItems.ToList();
            bug.Status = "0";
            return View(bug);
        }

        // POST: Bugs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BugId,Summary,Description,Status,CreatedByUserId")] Bug bug)
        {
            if (id != bug.BugId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bug.CreatedByUserId = 1;
                    _context.Update(bug);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BugExists(bug.BugId))
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
            return View(bug);
        }

        // GET: Bugs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bug = await _context.Bug
                .FirstOrDefaultAsync(m => m.BugId == id);
            if (bug == null)
            {
                return NotFound();
            }

            return View(bug);
        }

        // POST: Bugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bug = await _context.Bug.FindAsync(id);
            if (bug != null)
            {
                _context.Bug.Remove(bug);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BugExists(int id)
        {
            return _context.Bug.Any(e => e.BugId == id);
        }
    }
}
