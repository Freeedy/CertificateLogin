using System.Collections.Generic;
using System.Security.Claims;

namespace SecurityManager.Models
{
    public  class TokenInput
    {
        public string Issuer { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Claim> Claims { get; set; }
    }
}
