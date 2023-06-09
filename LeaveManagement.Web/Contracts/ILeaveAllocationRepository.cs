﻿using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task LeaveAllocation(int leaveTypeId);

        Task <bool> AllocationAlreadyExists(string employeeId, int leaveTypeId, int period);

        Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId);

        Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId);

        Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id);
    }
}
