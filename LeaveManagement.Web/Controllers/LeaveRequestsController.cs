using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using AutoMapper;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using LeaveManagement.Web.Constants;

namespace LeaveManagement.Web.Controllers
{
    [Authorize]
    public class LeaveRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILeaveRequestRepository leaveRequestRepository;

        public LeaveRequestsController(ApplicationDbContext context, ILeaveRequestRepository leaveRequestRepository)
        {
            _context = context;
            this.leaveRequestRepository = leaveRequestRepository;
        }

        [Authorize(Roles = Roles.Administrator)]
        // GET: LeaveRequests
        public async Task<IActionResult> Index()
        {
            var adminLeaveRequestViewVM = await leaveRequestRepository.GetAdminLeaveRequestList();
            return View(adminLeaveRequestViewVM);
        }

        public async Task<ActionResult> MyLeave()
        {
            var myLeaveVM = await leaveRequestRepository.GetMyLeaveDetails();
            return View(myLeaveVM);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]

        public async Task<IActionResult> ApproveRequest(int id, bool approved)
        {
            try
            {
                await leaveRequestRepository.ChangeApprovalStatus(id, approved);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "It didn´t work, perhaps you should think better about that leave request no?...");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: LeaveRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var leaveRequestViewVM = await leaveRequestRepository.GetLeaveRequestAsync(id);

            if (leaveRequestViewVM == null)
                return NotFound();

            return View(leaveRequestViewVM);
        }

        // GET: LeaveRequests/Create
        public IActionResult Create()
        {
            var leaveRequestVM = new LeaveRequestCreateVM
            {
                LeaveTypes = new SelectList(_context.LeaveTypes, "Id", "Name")
            };
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Name");
            return View(leaveRequestVM);
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateVM leaveRequestVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isValidRequest = await leaveRequestRepository.CreateLeaveRequest(leaveRequestVM);

                    if (isValidRequest)
                        return RedirectToAction(nameof(MyLeave));
                    ModelState.AddModelError(string.Empty, "You are exceeding your allocation days for this leave type, with this request");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "It didn´t work, perhaps you should think better about that leave request no?...");
            }
            leaveRequestVM.LeaveTypes = new SelectList(_context.LeaveTypes, "Id", "Name", leaveRequestVM.LeaveTypeId);
            return View(leaveRequestVM);
        }

        // GET: LeaveRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeaveRequests == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id", leaveRequest.LeaveTypeId);
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StartDate,EndDate,LeaveTypeId,DateRequested,RequestComments,Approved,Cancelled,RequestingEmployeeId,Id,DateCreated,DateModified")] LeaveRequest leaveRequest)
        {
            if (id != leaveRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveRequestExists(leaveRequest.Id))
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
            ViewData["LeaveTypeId"] = new SelectList(_context.LeaveTypes, "Id", "Id", leaveRequest.LeaveTypeId);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var leaveRequestViewVM = await leaveRequestRepository.GetLeaveRequestAsync(id);

            if (leaveRequestViewVM == null) // It is not really delete, its just updating the leave request to cancelled
            {
                return NotFound();
            }

            return View(leaveRequestViewVM);
        }

        // POST: LeaveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await leaveRequestRepository.CancelLeaveRequest(id);  // It is not really delete, its just updating the leave request to cancelled
            return RedirectToAction(nameof(MyLeave));
        }

        private bool LeaveRequestExists(int id)
        {
          return (_context.LeaveRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
