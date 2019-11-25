using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("作成日")]
        public DateTime? DateCreated { get; set; }
        [DisplayName("作成者")]
        public string UserCreated { get; set; }
        [DisplayName("変更日")]
        public DateTime? DateModified { get; set; }
        [DisplayName("編集者")]
        public string UserModified { get; set; }
    }
}
