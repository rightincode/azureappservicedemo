using System;
using System.ComponentModel.DataAnnotations;

namespace AzureAppServiceDemoApi.Models
{
    public class Customer
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }

        public Int32 Status { get; set; }

    }
}