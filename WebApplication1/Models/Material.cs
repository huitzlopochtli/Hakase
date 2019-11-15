using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication1.Models
{
    public class Material : BaseEntity
    {
        [Required(ErrorMessage = "")]
        public string Name { get; set; }
        [Required(ErrorMessage = "")]
        public string ImageUrl { get; set; }

        public IdentityUser User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public Material()
        {

        }

        public Material(string name, string imageUrl, string userId)
        {
            Name = name;
            ImageUrl = imageUrl;
            UserId = userId;
        }
    }
}
