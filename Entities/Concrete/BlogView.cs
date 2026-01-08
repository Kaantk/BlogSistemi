using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BlogView : IEntity
    {
        public int BlogViewId { get; set; }
        public int BlogId { get; set; } // Hangi bloga ait olduğunu belirtmek için
        public string IPAddress { get; set; } // Kullanıcının IP adresi
        public DateTime ViewedDate { get; set; }
    }
}
