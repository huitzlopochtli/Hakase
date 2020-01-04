using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Required(ErrorMessage = "の名前が必要です。")]
        [DisplayName("素材の名前")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "画像のURLが必要です。")]
        [DisplayName("画像のURL")]
        public string ImageUrl { get; set; }

        // 995 x 665
        public string ImageThumbnailUrl1 { get; set; }
        // 400 x 400
        public string ImageThumbnailUrl2 { get; set; }
        // 200 x 200
        public string ImageThumbnailUrl3 { get; set; }
        // 40 x 40
        public string ImageThumbnailUrl4 { get; set; }


        public int Precedence { get; set; }

        public Type Type { get; set; }

        public IdentityUser User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public DateTime LastLoginDate { get; set; }

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

    public enum Type {
        Wall = 1,
        Floor = 2
    }
}
