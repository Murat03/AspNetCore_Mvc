using System.ComponentModel.DataAnnotations;

namespace SignIn.Models
{
    public class Candidate
    {
        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Firstname is required")]
        public string FirstName { get; set;}
        [Required(ErrorMessage ="Lastname is required")]
        public string LastName { get; set;}
        public string FullName => $"{FirstName} {LastName?.ToUpper()}";
        public int Age { get; set; }
        public string SelectedCourse { get; set; }
        public DateTime ApplyAt { get; set; }

        public Candidate()
        {
            ApplyAt = DateTime.Now;
        }
    }
}