using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    public class ITEM
    {
        public string StringToHash { get; set; } // String to hash
        public int HashValue { get; set; } // Store hash code; Same strings must produce the same hash, however different strings can have same hash.
        public int Collisions { get; set; } = 0; // number of other items that collide to that item.
        public int IndexInCollisions { get; set; } = 0; // we will use this to get the item in collision linked list
        public ITEM(string StringToHash)
        {
            this.StringToHash = StringToHash;           
        }
    }
}
