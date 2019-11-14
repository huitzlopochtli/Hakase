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
        [DisplayName("名前(ふり)")]
        public string NameHira { get; set; }

        [Required]
        [DisplayName("名前(カタ)")]
        public string NameKata { get; set; }
        [Required]
        [DisplayName("会社の名前(ふり)")]
        public string CompanyNameHira { get; set; }
        [Required]
        [DisplayName("会社の名前(カタ)")]
        public string CompanyNameKata { get; set; }
        [Required]
        [DisplayName("会社のメール")]
        public string CompanyEmail { get; set; }


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

        public Customer(string nameHira, string nameKata, string companyNameHira, string companyNameKata, string companyEmail, string phone, string phoneMobile, DateTime? dateOfBirth, string address, IdentityUser user, string userId)
        {
            NameHira = nameHira;
            NameKata = nameKata;
            CompanyNameHira = companyNameHira;
            CompanyNameKata = companyNameKata;
            CompanyEmail = companyEmail;
            Phone = phone;
            PhoneMobile = phoneMobile;
            DateOfBirth = dateOfBirth;
            Address = address;
            User = user;
            UserId = userId;
        }
    }
}
