using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Auth.Response
{
    public class UserForLoginResponseDto
    {
        public string AccessToken { get; set; }
        public DateTime Expiration {  get; set; }
    }
}
