using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveRequestRepository :IGenericRepository<LeaveRequest>
    {
        Task CancelLeaveRequest(int id);
        Task<bool> CreateLeaveRequest(LeaveRequestCreateVM requestCreateVM);

        Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails();

        Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id);

        Task<List<LeaveRequest>> GetAllAsync(string employeeId);

        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();

        Task ChangeApprovalStatus(int employeeId, bool approvalStatus);
    }
}
