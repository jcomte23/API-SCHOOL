using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api_school.Models.Validations;

namespace api_school.Models
{
    [Table("students")]
    public class Student
    {
        private string fullName = string.Empty;
        private string address = string.Empty;
        private string email = string.Empty;


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

        [Required(ErrorMessage = "birthdate is required.")]
        [DataType(DataType.Date)]
        [ValidatePreviousDate(ErrorMessage = "date cannot be in the future.")]
        [Column("birthdate")]
        public DateOnly Birthdate { get; set; }

        //-------

        [Required(ErrorMessage = "address is required.")]
        [MinLength(3, ErrorMessage = "address must be at least {1} characters.")]
        [MaxLength(125, ErrorMessage = "address must be at most {1} characters.")]
        [Column("address")]
        public string Address
        {
            get => address.ToLower();
            set => address = value.ToLower().Trim();
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
    }
}