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
        [DisplayName("名（メイ)")]
        public string FNameHira { get; set; }

        [Required]
        [DisplayName("姓（セイ)")]
        public string LNameHira { get; set; }

        [Required]
        [DisplayName("メイ")]
        public string FNameKata { get; set; }

        [Required]
        [DisplayName("セイ")]
        public string LNameKata { get; set; }

        [DisplayName("電話番号")]
        public string Phone { get; set; }

        [DisplayName("携帯番号")]
        public string PhoneMobile { get; set; }

        [DisplayName("生年月日")]
        public DateTime? DateOfBirth { get; set; }

        
        [DisplayName("住所")]
        public string Address { get; set; }

        public IdentityUser User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public Customer(){ }

        public Customer(string fNameHira, string lNameHira, string fNameKata, string lNameKata, string phone, string phoneMobile, DateTime? dateOfBirth, string address, IdentityUser user, string userId)
        {
            FNameHira = fNameHira;
            LNameHira = lNameHira;
            FNameKata = fNameKata;
            LNameKata = lNameKata;
            Phone = phone;
            PhoneMobile = phoneMobile;
            DateOfBirth = dateOfBirth;
            Address = address;
            User = user;
            UserId = userId;
        }
    }
}
