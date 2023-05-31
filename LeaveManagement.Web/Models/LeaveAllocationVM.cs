﻿using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveAllocationVM

    {
        public int Id { get; set; }

        [Display (Name = "Number Of Days")]
        [Required]
        [Range(1, 50, ErrorMessage = "Invalid number entered")]
        public int NumberOfDays { get; set; }

        [Display(Name = "Allocation Period")]
        [Required]
        public int Period { get; set; }

        public LeaveTypeVM? LeaveType { get; set; }

    }
}