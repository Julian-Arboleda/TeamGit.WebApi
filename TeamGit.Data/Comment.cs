using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamGit.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual List<string> listOfReplies {get;}
    }
}

/*int Id
 string Text
 Guid Author (using user ID)
 (virtual list of Replies)
 (Foreign Key to Post via Id w/ virtual Post) 
*/