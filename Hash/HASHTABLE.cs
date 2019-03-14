using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hash
{
    class HASHTABLE 
    {
        // BY T.ADAKOGLU
        public int Capasity { get; set; }
        LinkedList<ITEM>[] dictionary;
        internal LinkedList<ITEM>[] MYDICTIONARY
        {
            get { return dictionary; }
            set { MYDICTIONARY = value; }
        }

        private int count;    // The total number of entries in the hash table.
                              // The total number of collision bits set in the hashtable
        public int TotalCollisions=> CalcTotalCollisions();

        
        private int CalcTotalCollisions() 
        {
            int totalCols = 0;
            foreach (LinkedList<ITEM> ll in dictionary) //LINKEDLIST<ITEM>[]
            {            
                if (ll != null)
                {
                    if (ll.Count() > 1)
                    {
                        totalCols += ll.Count()-1;   // the first item in hash table that other guys have the same hash with must be excluded.  because others collide.
                    }                    
                }
            }
            return totalCols;
        }
        public HASHTABLE(int capasity)
        {
            this.Capasity = capasity;
            dictionary = new LinkedList<ITEM>[capasity]; // array initialization
           
        }        

        public void ADD(string StringToHash)
        {
            int hash = HASHCODE(StringToHash); // calc hash.
            int index = hash % Capasity; // reshape for array indexing
            ITEM item = new ITEM(StringToHash) { HashValue = hash }; // store string and its hash
            LinkedListNode <ITEM> node = new LinkedListNode<ITEM>(item); // encapsulate item as node
            

            if (dictionary[index] == null)
            {
                dictionary[index] = new LinkedList<ITEM>();
                (dictionary[index]).AddLast(node); // add node to list
            }
            else
                (dictionary[index]).AddLast(node); // add node to list  

            CalcItemsHashCollisions(); // Write all item's collision values.
            count++;
        }

        private void CalcItemsHashCollisions() // Calculate item's hash collisions value and the index in this collisions list to reach them easily later.
        {
           
            foreach (LinkedList<ITEM> item in dictionary) //LINKEDLIST<ITEM>[]
            {
                int totalCols = 0;
                if (item != null)
                {
                    //no collisions in this item
                    if (item.Count() == 1)
                    {
                        item.First.Value.Collisions = 0;
                    }
                    //there are collisions for this item
                    else if (item.Count() > 1)
                    {
                        totalCols += item.Count() - 1; // item's itself is excluded.
                        int index = 0;
                        //item COLLISION LINKED LIST(ALL VALUES WITH SAME HASH)
                        foreach (ITEM i in item) // collision list. we will set all item's collision's values as same in the same collision list
                        {                           
                            i.Collisions = totalCols;
                            i.IndexInCollisions = index;
                            index++;
                        }
                    }
                }
            }
            
        }

        public int HASHCODE(string StringToHash) // HASH FUNCTION - IMPORTANT ONE.
        {
            unchecked //uncontrolled casting, arithmetic overflow in casting is ignored
            {
                // 0 to 4294967295 unsigned integers(uint32), -2147483648 to +2147483647 signed integers(int32)
                // Choose large primes to avoid hashing collisions
                const int HashingBase = (int)2166136261; // will occur arithmetic overflow, we'll ignore.
                const int HashingMultiplier = 16777619;
                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ ((StringToHash?.GetHashCode()) ?? 0);
                hash = Math.Abs(hash);
                return hash;
            }           
        }
        
    }
}
