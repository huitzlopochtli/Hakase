using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class Customer : BaseEntity
    {
        [Required]
        [DisplayName("名（メイ")]
        public string FNameHira { get; set; }

        [Required]
        [DisplayName("姓（セイ")]
        public string LNameHira { get; set; }

        [Required]
        [DisplayName("メイ")]
        public string FNameKata { get; set; }

        [Required]
        [DisplayName("セイ")]
        public string LNameKata { get; set; }

        [Required]
        [DisplayName("電話番号")]
        public string Phone { get; set; }

        [Required]
        [DisplayName("携帯番号")]
        public string PhoneMobile { get; set; }

        [Required]
        [DisplayName("生年月日")]
        public DateTime? DateOfBirth { get; set; }

        
        [DisplayName("住所")]
        public string Address { get; set; }

        public IdentityUser User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

    }
}
