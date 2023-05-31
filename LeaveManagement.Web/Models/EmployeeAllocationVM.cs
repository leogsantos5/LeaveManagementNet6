using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Models
{
    public class EmployeeAllocationVM : EmployeeListVM // Employee allocationssssss, there acould be many Leave Allocations for one Employee
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
    }
}
