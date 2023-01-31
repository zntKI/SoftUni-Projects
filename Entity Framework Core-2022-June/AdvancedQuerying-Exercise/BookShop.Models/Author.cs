namespace BookShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Author
    {
        public Author()
        {
            this.Books = new HashSet<Book>();
        }

        public int AuthorId { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string FirstName { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}