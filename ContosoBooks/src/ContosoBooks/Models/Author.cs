using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Mvc;

namespace ContosoBooks.Models
{
    public class Author
    {
        [HiddenInput]
        public int AuthorID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
