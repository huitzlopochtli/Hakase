using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ReformedImage :BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public UploadedImage UploadedImage { get; set; }
        [ForeignKey("UploadedImage")]
        public int UploadedImageId { get; set; }


        public ReformedImage()
        {
            
        }

        public ReformedImage(string imageUrl)
        {
            ImageUrl = imageUrl;
        }
    }
}
