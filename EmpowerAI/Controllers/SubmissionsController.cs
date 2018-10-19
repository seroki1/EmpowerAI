using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpowerAI.Models;
using Microsoft.AspNetCore.Authorization;

namespace EmpowerAI.Controllers
{
    [Authorize]
    public class SubmissionsController : Controller
    {
        private readonly EmpowerAIContext _context;

        public SubmissionsController(EmpowerAIContext context)
        {
            _context = context;
        }

        // GET: Submissions
        public async Task<IActionResult> Index()
        {
            var empowerAIContext = _context.Submission.Include(s => s.CampaignDurationType).Include(s => s.Company).Include(s => s.Tier).Include(s => s.Tier2Objective).Include(s => s.User);
            return View(await empowerAIContext.ToListAsync());
        }

        // GET: Submissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submission = await _context.Submission
                .Include(s => s.CampaignDurationType)
                .Include(s => s.Company)
                .Include(s => s.Tier)
                .Include(s => s.Tier2Objective)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (submission == null)
            {
                return NotFound();
            }

            return View(submission);
        }

        // GET: Submissions/Create
        public IActionResult Create()
        {
            ViewData["CampaignDurationTypeId"] = new SelectList(_context.CampaignDurationType, "Id", "Type");
            ViewData["TierId"] = new SelectList(_context.Tier, "Id", "TierName");
            ViewData["Tier2ObjectiveId"] = new SelectList(_context.Tier2Objective, "Id", "Objective");
            
            return View();
        }

        // POST: Submissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,CompanyId,CampaignStartDate,CampaignDuration,TotalBudget,Tier1Objective,PreferredMediaApproach,TierId,Tier2ObjectiveId,IsBudgetFlexible,IsCampaignContinuous,IsCustomMarketSchedule,IsCustomMarketBudget,Remarks,Tier2ObjectiveGoal,Tier2ObjectiveBudgetFlexibility,CampaignDurationTypeId")] Submission submission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(submission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CampaignDurationTypeId"] = new SelectList(_context.CampaignDurationType, "Id", "Type", submission.CampaignDurationTypeId);
            ViewData["CompanyId"] = submission.Company.CompanyName;
            ViewData["TierId"] = new SelectList(_context.Tier, "Id", "TierName", submission.TierId);
            ViewData["Tier2ObjectiveId"] = new SelectList(_context.Tier2Objective, "Id", "Objective", submission.Tier2ObjectiveId);
            
            return View(submission);
        }

        // GET: Submissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submission = await _context.Submission.FindAsync(id);
            if (submission == null)
            {
                return NotFound();
            }
            ViewData["CampaignDurationTypeId"] = new SelectList(_context.CampaignDurationType, "Id", "Type", submission.CampaignDurationTypeId);
            ViewData["CompanyId"] = submission.Company.CompanyName;
            ViewData["TierId"] = submission.Tier.TierName;
            ViewData["Tier2ObjectiveId"] = new SelectList(_context.Tier2Objective, "Id", "Objective", submission.Tier2ObjectiveId);
            //ViewData["UserId"] = _context.User;
            return View(submission);
        }

        // POST: Submissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,CompanyId,CampaignStartDate,CampaignDuration,TotalBudget,Tier1Objective,PreferredMediaApproach,TierId,Tier2ObjectiveId,IsBudgetFlexible,IsCampaignContinuous,IsCustomMarketSchedule,IsCustomMarketBudget,Remarks,Tier2ObjectiveGoal,Tier2ObjectiveBudgetFlexibility,CampaignDurationTypeId,AuthorizationName,IsAuthorized")] Submission submission)
        {
            if (id != submission.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(submission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubmissionExists(submission.Id))
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
            ViewData["CampaignDurationTypeId"] = new SelectList(_context.CampaignDurationType, "Id", "Type", submission.CampaignDurationTypeId);
            ViewData["CompanyId"] = submission.Company.CompanyName;
            ViewData["TierId"] = new SelectList(_context.Tier, "Id", "TierName", submission.TierId);
            ViewData["Tier2ObjectiveId"] = new SelectList(_context.Tier2Objective, "Id", "Objective", submission.Tier2ObjectiveId);
            //ViewData["UserId"] = new SelectList(_context.User, "Id", "Email", submission.UserId);
            return View(submission);
        }

        // GET: Submissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var submission = await _context.Submission
                .Include(s => s.CampaignDurationType)
                .Include(s => s.Company)
                .Include(s => s.Tier)
                .Include(s => s.Tier2Objective)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (submission == null)
            {
                return NotFound();
            }

            return View(submission);
        }

        // POST: Submissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var submission = await _context.Submission.FindAsync(id);
            _context.Submission.Remove(submission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubmissionExists(int id)
        {
            return _context.Submission.Any(e => e.Id == id);
        }
    }
}
