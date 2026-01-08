using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsApproved { get; set; }
        public int BlogId { get; set; } // Hangi bloga ait olduğunu belirtmek için
        public int UserId { get; set; } // Yorum yapan kullanıcıyı belirtmek için
    }
}
