using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamGit.Data
{
    public class Comment
    {
        [ForeignKey(nameof(Reply))]
        public int ReplyId { get; set; }
        public virtual Reply Reply { get; set; }
        [Key]
        public int CommentId { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual List<string> ListOfReplies {get;}
    }
}

