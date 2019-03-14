using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Hash
{
    class Program
    {
        //item is an linked list in the dictionary.
        //all terms with different HASHCODE will create a new different linked list(new item object).
        //terms with same HASHCODE will be added to the ONLY ONE linked list(same item object) altogether.
        static int hashtableSize = 50;
        static void Main(string[] args)
        {
            // BY T.ADAKOĞLU 
            LinkedList<int> lk = new LinkedList<int>();
            //Console.WriteLine(lk.Count);
            //try
            //{
                HASHTABLE MYHT = new HASHTABLE(hashtableSize);
                ///FILE OPERATIONS
                string address = "sozluk.txt";
                //FileStream stream = new FileStream(address, FileMode.Open);
                StreamReader sreader = new StreamReader(address);
                string StringToHash, line;
                while ( (line = sreader.ReadLine()) != null)
                {
                    StringToHash = "";
                    for (int j = 0; j < line.Count(); j++) 
                    StringToHash+= line[j];                   
                    MYHT.ADD(StringToHash);
                }
            //Console.WriteLine(MYHT.TotalCollisions);
            ///FILE OPERATIONS END
           
           
            Console.WriteLine("-------------------------------------------DEVELOPED BY TAYFUN ADAKOGLU--------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------HASH TABLE & HASHING------------------------------------------------------------");
            Console.WriteLine("*******************************************************************************************************************************");
            Console.WriteLine("*Term*\t\t*Collisions*\t*Index In Collisions Linked List*   *Collision Linked List Count*  *Hash*   *Hash % Capasity*");
            Console.WriteLine("_______________________________________________________________________________________________________________________________");

            #region MAIN-OPERATIONS
            string CalcSpace(string strToHash)
            {
                string strSpace = "";
                for (int i = 0; i < 20 - strToHash.Length; i++)
                    strSpace += " ";
                return strSpace;
            }
            string CalcSpaceWithNum(int num)
            {
                string strSpace = "";
                for (int i = 0; i < num; i++)
                    strSpace += " ";
                return strSpace;
            }
            foreach (LinkedList<ITEM> item in MYHT.MYDICTIONARY) //LINKEDLIST<ITEM>[]
            {
                if (item != null)
                {
                    if (item.Count() == 1)
                    {
                        //no collisions                        
                        string strToHash = item.First.Value.StringToHash;                        
                        Console.WriteLine(strToHash + CalcSpace(strToHash) + "There aren't any collisions for this item" + CalcSpaceWithNum(36) + item.First.Value.HashValue + CalcSpace(item.First.Value.HashValue.ToString()) + (item.First.Value.HashValue % hashtableSize));
                    }
                    else if(item.Count() > 1)
                    {                        
                        foreach (ITEM i in item) // collision list. we will set all item's collision's values as same in the same collision list
                        Console.WriteLine(i.StringToHash + CalcSpace(i.StringToHash) + i.Collisions + " \t\t\t " + i.IndexInCollisions + " \t\t\t\t\t " + (i.Collisions+1) + CalcSpaceWithNum(15) + i.HashValue +CalcSpace(i.HashValue.ToString()) + (item.First.Value.HashValue % hashtableSize));
                    }
                }

            }
            #endregion MAIN-OPERATIONS
            Console.WriteLine("_______________________________________________________________________________________________________________________________");
            Console.WriteLine("Best Regards");
            Console.WriteLine("T.Adakoğlu");
            Console.Read();
            //}
            //catch(Exception e)
            //{

            //    Console.WriteLine("ERROR :" + e.Message);//Print error
            //}
        }
      
    }
}
