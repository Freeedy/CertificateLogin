using System.Collections.Generic;

namespace SecurityManager.Models
{
    public  class TokenInput
    {
        public Customer Customer { get; set; }
        public string NameIdentifier { get; set; }
        public Dictionary<string, string> Claims { get; set; }
    }
}
