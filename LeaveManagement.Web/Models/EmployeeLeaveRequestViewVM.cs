using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Models
{
    public class EmployeeLeaveRequestViewVM
    {
        public EmployeeLeaveRequestViewVM(List<LeaveAllocationVM> leaveAllocations, List<LeaveRequestVM> leaveRequests)
        {
            this.LeaveAllocations = leaveAllocations;
            this.LeaveRequests = leaveRequests;
        }
        public List<LeaveAllocationVM> LeaveAllocations { get; set;}

        public List<LeaveRequestVM> LeaveRequests { get; set;}
    }
}
