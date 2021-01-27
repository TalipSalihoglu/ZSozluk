using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZSözlük.Models.ViewModel
{
    public class EditUserViewModel
    {
        [Required]
        public string Id{ get; set; }
        public IFormFile Photo{ get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        public string Link_insta { get; set; }
        public string Link_facebook { get; set; }
        public string Link_twitter { get; set; }

    }
}
