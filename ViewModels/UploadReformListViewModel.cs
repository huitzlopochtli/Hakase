using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class UploadReformListViewModel
    {
        public IEnumerable<ReformedImage> ReformedImages { get; set; }

        public IEnumerable<UploadedImage> UploadedImages { get; set; }

        public UploadReformListViewModel(IEnumerable<ReformedImage> reformedImages, IEnumerable<UploadedImage> uploadedImages)
        {
            ReformedImages = reformedImages;
            UploadedImages = uploadedImages;
        }
    }
}
