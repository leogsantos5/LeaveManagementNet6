using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class EmployeeListVM
    {
        public string Id { get; set; }

        [Display(Name= "Name")]
        public string Name { get; set; }

        [Display(Name = "Date Joined")]
        public string DateJoined { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}
