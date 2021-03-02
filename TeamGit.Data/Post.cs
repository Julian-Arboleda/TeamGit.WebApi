using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamGit.Data
{
    public class Post
    {
        /* [Display(Name = "Your Note")]*/
        [Key]
        [Required]
        public int PostId { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }

        public virtual List<string> ListOfComments { get; }
        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }

    }
}

