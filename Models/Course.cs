using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_school.Models
{
    [Table("courses")]
    public class Course
    {
        private string name = string.Empty;
        private string description = string.Empty;
        private string schedule = string.Empty;
        private string duration = string.Empty;

        [Key]
        [Column("id")]
        public int Id { get; set; }

        //-------

        [Required(ErrorMessage = "name is required.")]
        [MinLength(3, ErrorMessage = "name must be at least {1} characters.")]
        [MaxLength(125, ErrorMessage = "name must be at most {1} characters.")]
        [Column("name")]
        public string Name
        {
            get => name.ToLower();
            set => name = value.ToLower().Trim();
        }

        //-------

        [Required(ErrorMessage = "description is required.")]
        [MinLength(10, ErrorMessage = "description must be at least {1} characters.")]
        [MaxLength(1000, ErrorMessage = "description must be at most {1} characters.")]
        [Column("description", TypeName = "Text")]
        public string Description
        {
            get => description.ToLower();
            set => description = value.ToLower().Trim();
        }

        //-------

        [Required(ErrorMessage = "teacher_id is required.")]
        [Column("teacher_id")]
        public int TeacherId { get; set; }

        //-------

        [Required(ErrorMessage = "schedule is required.")]
        [MinLength(3, ErrorMessage = "schedule must be at least {1} characters.")]
        [MaxLength(125, ErrorMessage = "schedule must be at most {1} characters.")]
        [Column("schedule")]
        public string Schedule
        {
            get => schedule.ToLower();
            set => schedule = value.ToLower().Trim();
        }

        //-------

        [Required(ErrorMessage = "duration is required.")]
        [MinLength(3, ErrorMessage = "duration must be at least {1} characters.")]
        [MaxLength(125, ErrorMessage = "duration must be at most {1} characters.")]
        [Column("duration")]
        public string Duration
        {
            get => duration.ToLower();
            set => duration = value.ToLower().Trim();
        }

        //-------

        [Required(ErrorMessage = "capacity is required.")]
        [Range(1, 1000, ErrorMessage = "capacity must be between {1} and {2}.")]
        [Column("capacity")]
        public int Capacity { get; set; }

        //-------

        [ForeignKey("TeacherId")]
        public Teacher? Teacher { get; set; }
    }
}