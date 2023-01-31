using System.ComponentModel.DataAnnotations;

namespace TextSplitter.Models
{
    public class TextViewModel
    {
        [Required(ErrorMessage = "The field is required!")]
        [MinLength(2)]
        [MaxLength(30)]
        public string Text { get; set; }

        public string SplitText { get; set; }
    }
}
