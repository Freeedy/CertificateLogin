using System.Collections.Generic;
using System.Security.Claims;

namespace SecurityManager.Models
{
    public  class TokenInput
    {
        public Customer Customer { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
