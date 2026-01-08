using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Blog : IEntity
    {
        public int BlogId { get; set; }
        public string Title { get; set; } 
        public string Content { get; set; }
        public string CoverImageUrl { get; set; }    
        public bool IsPublished { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UserId { get; set; } // Identity userId'sini alacak daha sonrasında User ile ilişkilendirilecek
        public int CategoryId { get; set; } 
    }
}
