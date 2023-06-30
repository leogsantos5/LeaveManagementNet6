using AutoMapper;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAcessor, UserManager<Employee> userManager, ILeaveAllocationRepository leaveAllocationRepository, IGenericRepository<LeaveRequest> genericRepository, IEmailSender emailSender) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.httpContextAcessor = httpContextAcessor;
            this.userManager = userManager;
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.genericRepository = genericRepository;
            this.emailSender = emailSender;
        }

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAcessor;
        private readonly UserManager<Employee> userManager;
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly IGenericRepository<LeaveRequest> genericRepository;
        private readonly IEmailSender emailSender;

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Cancelled = true;

            await genericRepository.UpdateAsync(leaveRequest);

            var user = await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);
            await emailSender.SendEmailAsync(user.Email, "Leave Request Created Successfully", "Your leave request from " + leaveRequest.StartDate + " to " + leaveRequest.EndDate + " has been submitted for approval");
        }

        public async Task<bool> CreateLeaveRequest(LeaveRequestCreateVM requestCreateVM)
        {
            var user = await userManager.GetUserAsync(httpContextAcessor?.HttpContext?.User);

            var leaveAllocation = await leaveAllocationRepository.GetEmployeeAllocation(user.Id, requestCreateVM.LeaveTypeId);

            if (leaveAllocation == null)
                return false;

            int daysRequested = (int)(requestCreateVM.EndDate!.Value - requestCreateVM.StartDate!.Value).TotalDays;

            if (daysRequested > leaveAllocation!.NumberOfDays) 
                return false;
            

            var leaveRequest = mapper.Map<LeaveRequest>(requestCreateVM);
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            await AddAsync(leaveRequest);

            await emailSender.SendEmailAsync(user.Email, "Leave Request Created Successfully", "Your leave request from " + leaveRequest.StartDate + " to " + leaveRequest.EndDate + " has been submitted for approval");

            return true;
        }

        public async Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails()
        {
            var user = await userManager.GetUserAsync(httpContextAcessor?.HttpContext?.User);

            var allocations = (await leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;
            var requests = mapper.Map<List<LeaveRequestVM>>(await GetAllAsync(user.Id));

            return new EmployeeLeaveRequestViewVM(allocations, requests);
        }

        public async Task<List<LeaveRequest>> GetAllAsync(string employeeId)
        {
            return await context.LeaveRequests.Where(lr => lr.RequestingEmployeeId == employeeId).ToListAsync();
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {
            var leaveRequests = await context.LeaveRequests.Include(lr => lr.LeaveType).ToListAsync(); 
            var totalRequests = leaveRequests.Count;
            var approvedRequests = leaveRequests.Count(lr => lr.Approved == true);
            var rejectedRequests = leaveRequests.Count(lr => lr.Approved == false);
            var pendingRequests = leaveRequests.Count(lr => lr.Approved == null);
            var adminLeaveRequestViewVMRequests = mapper.Map<List<LeaveRequestVM>>(leaveRequests);

            var adminLeaveRequestViewVM = new AdminLeaveRequestViewVM
            {
                TotalRequests = totalRequests,
                ApprovedRequests = approvedRequests,
                RejectedRequests = rejectedRequests,
                PendingRequests = pendingRequests,
                LeaveRequests = adminLeaveRequestViewVMRequests,
            };

            foreach(var leaveRequest in adminLeaveRequestViewVM.LeaveRequests)
                leaveRequest.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));

            return adminLeaveRequestViewVM;
        }

        public async Task ChangeApprovalStatus(int leaveRequestId, bool approvalStatus)
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Approved = approvalStatus;

            if (approvalStatus == true)
            {
                var allocation = await leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                int daysRequested = (int)(leaveRequest.EndDate -leaveRequest.StartDate).TotalDays;
                allocation.NumberOfDays -= daysRequested;
                await leaveAllocationRepository.UpdateAsync(allocation);
            }

            await UpdateAsync(leaveRequest);

            var approvalStatusStr = approvalStatus ? "Approved" : "Rejected";
            var user = await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId);
            await emailSender.SendEmailAsync(user.Email, "Leave Request Status Successfully Changed" + approvalStatusStr, "The leave request from " + leaveRequest.StartDate + " to " + leaveRequest.EndDate + " by " + user.Name + " has been " + approvalStatusStr);

        }

        public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id)
        {
            var leaveRequest = await context.LeaveRequests
                .Include(lr=>lr.LeaveType)
                .FirstOrDefaultAsync(lr=>lr.Id == id);
            if (leaveRequest == null)
                return null;
            var leaveRequestVM = mapper.Map<LeaveRequestVM>(leaveRequest);
            leaveRequestVM.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(leaveRequest?.RequestingEmployeeId));
            return leaveRequestVM;
        }
    }
}
