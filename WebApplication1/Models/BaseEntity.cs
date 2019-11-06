using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime? DateCreated { get; set; }

        public string UserCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public string UserModified { get; set; }
    }
}
