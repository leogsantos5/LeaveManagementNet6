using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Web.Models
{
    public class LeaveRequestCreateVM : IValidatableObject
    {
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [ForeignKey("LeaveTypeId")]
        public SelectList? LeaveTypes { get; set; }


        [Display(Name = "Leave Type")]
        [Required]
        public int LeaveTypeId { get; set; }

        public DateTime DateRequested { get; set; }

        [Display(Name = "Request Comments")]
        public string? RequestComments { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate > EndDate)
            {
                yield return new ValidationResult("The Start Date must be before the End Date", new[] {nameof(StartDate), nameof(EndDate) });
            }

            if (RequestComments?.Length > 255)
            {
                yield return new ValidationResult("The comments should not surpass 255 characters", new[] { nameof(RequestComments) });
            }
        }

    }
}
