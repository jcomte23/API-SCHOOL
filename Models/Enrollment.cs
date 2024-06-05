using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using api_school.Models.Validations;

namespace api_school.Models
{
    [Table("enrollments")]
    public class Enrollment
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        //-------

        [Required(ErrorMessage = "date is required.")]
        [DataType(DataType.Date)]
        [Column("date")]
        public DateOnly Date { get; set; }

        //-------

        [Required(ErrorMessage = "student_id is required.")]
        [Column("student_id")]
        public int StudentId { get; set; }

        //-------

        [Required(ErrorMessage = "course_id is required.")]
        [Column("course_id")]
        public int CourseId { get; set; }

        //-------

        [Required(ErrorMessage = "status is required.")]
        [Column("status")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public StatusEnrollment Status { get; set; }

        //-------

        [ForeignKey("StudentId")]
        public Student? Student { get; set; }

        //-------

        [ForeignKey("CourseId")]
        public Course? Course { get; set; }
    }

    public enum StatusEnrollment
    {
        paid,
        pendingPayment,
        canceled
    }
}