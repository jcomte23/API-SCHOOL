using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_school.Models
{
    [Table("teachers")]
    public class Teacher
    {
        private string fullName = string.Empty;
        private string specialty = string.Empty;
        private string email = string.Empty;
        private string phone = string.Empty;


        [Key]
        [Column("id")]
        public int Id { get; set; }

        //-------

        [Required(ErrorMessage = "full name is required.")]
        [MinLength(5, ErrorMessage = "full name must be at least {1} characters.")]
        [MaxLength(125, ErrorMessage = "full name must be at most {1} characters.")]
        [Column("full_name")]
        public string FullName
        {
            get => fullName.ToLower();
            set => fullName = value.ToLower().Trim();
        }

        //-------

        [Required(ErrorMessage = "specialty is required.")]
        [MinLength(3, ErrorMessage = "specialty must be at least {1} characters.")]
        [MaxLength(125, ErrorMessage = "specialty must be at most {1} characters.")]
        [Column("specialty")]
        public string Specialty
        {
            get => specialty.ToLower();
            set => specialty = value.ToLower().Trim();
        }

        //-------

        [Required(ErrorMessage = "phone number is required.")]
        [MinLength(5, ErrorMessage = "phone number be at least {1} characters.")]
        [MaxLength(25, ErrorMessage = "phone number be at most {1} characters.")]
        [Phone(ErrorMessage = "the phone format is not valid, you can use this example format if you want => '### ### ## ##'")]
        [Column("phone")]
        public string Phone
        {
            get => phone.ToLower();
            set => phone = value.ToLower().Trim();
        }

        //-------

        [Required(ErrorMessage = "email is required.")]
        [EmailAddress(ErrorMessage = "invalid email format.")]
        [MinLength(5, ErrorMessage = "email must be at least {1} characters.")]
        [MaxLength(125, ErrorMessage = "email must be at most {1} characters.")]
        [Column("email")]
        public string Email
        {
            get => email.ToLower();
            set => email = value.ToLower().Trim();
        }

        //-------

        [Required(ErrorMessage = "years experience is required.")]
        [Range(1, 100, ErrorMessage = "years experience must be between {1} and {2}.")]
        [Column("years_experience")]
        public int YearsExperience { get; set; }
    }
}