using System.ComponentModel.DataAnnotations;

namespace FeedbackFormApplication
{
    public class Feedback
    {
        [Required(ErrorMessage = "Please fill out your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please fill out your email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide your feedback.")]
        [StringLength(500, ErrorMessage = "Your comment is too long.")]
        public string Comment { get; set; }
    }
}