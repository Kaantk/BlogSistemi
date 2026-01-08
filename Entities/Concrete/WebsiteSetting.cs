using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class WebsiteSetting : IEntity
    {
        public int WebsiteSettingId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
