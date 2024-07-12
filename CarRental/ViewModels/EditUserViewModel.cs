using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CarRental.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string DriversLicenseNumber { get; set; }


        public List<SelectListItem>? Countries { get; set; }
    }
}
