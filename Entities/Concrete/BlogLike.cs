using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BlogLike : IEntity
    {
        public int BlogLikeId { get; set; }
        public int BlogId { get; set; } // Hangi bloga ait olduğunu belirtmek için
        public string UserId { get; set; } // Beğeniyi yapan kullanıcıyı belirtmek için
        public DateTime LikedDate { get; set; }
    }
}
