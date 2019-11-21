using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Remotion.Linq.Parsing.Structure.ExpressionTreeProcessors;

namespace WebApplication1.Models
{
    public class UploadedImage : BaseEntity
    {
        public string ImageUrl { get; set; }
        public IEnumerable<ReformedImage> ReformedImages { get; set; }

        public IdentityUser User { get; set; }

        public string UserId { get; set; }

        public UploadedImage()
        {
            ReformedImages = new List<ReformedImage>();
        }

        public UploadedImage(string imageUrl, IEnumerable<ReformedImage> reformedImages)
        {
            ImageUrl = imageUrl;
            ReformedImages = reformedImages;
        }
    }
}
