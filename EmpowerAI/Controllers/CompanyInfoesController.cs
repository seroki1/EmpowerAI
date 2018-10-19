using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpowerAI.Models;

namespace EmpowerAI.Controllers
{
    public class CompanyInfoesController : Controller
    {
        private readonly EmpowerAIContext _context;

        public CompanyInfoesController(EmpowerAIContext context)
        {
            _context = context;
        }

        // GET: CompanyInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyInfo.ToListAsync());
        }

        // GET: CompanyInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyInfo = await _context.CompanyInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyInfo == null)
            {
                return NotFound();
            }

            return View(companyInfo);
        }

        // GET: CompanyInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,Contact,Phone,BillAddress,BillAddress2,BillCity,BillState,BillZip")] CompanyInfo companyInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyInfo);
        }

        // GET: CompanyInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyInfo = await _context.CompanyInfo.FindAsync(id);
            if (companyInfo == null)
            {
                return NotFound();
            }
            return View(companyInfo);
        }

        // POST: CompanyInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,Contact,Phone,BillAddress,BillAddress2,BillCity,BillState,BillZip")] CompanyInfo companyInfo)
        {
            if (id != companyInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyInfoExists(companyInfo.Id))
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
            return View(companyInfo);
        }

        // GET: CompanyInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyInfo = await _context.CompanyInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyInfo == null)
            {
                return NotFound();
            }

            return View(companyInfo);
        }

        // POST: CompanyInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyInfo = await _context.CompanyInfo.FindAsync(id);
            _context.CompanyInfo.Remove(companyInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyInfoExists(int id)
        {
            return _context.CompanyInfo.Any(e => e.Id == id);
        }
    }
}
