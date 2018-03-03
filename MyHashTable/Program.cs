using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            MyHashTable ht = new MyHashTable();
            ht.add("Augie", 56);
            ht.add("Augie", 66);
            ht.add("Cindy", 60);
            ht.add("Josh", 16);
            //ht.add("Emily", 30);


            Console.WriteLine("Augie: Age = {0}", (int)ht.getValue("Augie"));
            Console.WriteLine("Cindy: Age = {0}", (int)ht.getValue("Cindy"));
            Console.WriteLine("Josh: Age = {0}", (int)ht.getValue("Josh"));
            Console.WriteLine("Emily: Age = {0}", (int)ht.getValue("Emily"));

            Console.ReadLine();
        }

    }

    class MyHashTable
    {
        // Todo:
        // Handle hash collisions
        // Check for duplicate keys
        // Handle hash table resizing - count members (adds)
        // Add interator interface

        protected MyHashTableEntry[] itemArray;


        public MyHashTable()
        {
            itemArray = new MyHashTableEntry[50];
        }

        protected int calculateIndex(object key)
        {
            int hashcode = key.GetHashCode();
            int index = hashcode % itemArray.Length;
            if (index < 0)
            {
                index = index * -1;
            }
            return index;
        }
        public int add(object key, object value)
        {
            MyHashTableEntry entry = new MyHashTableEntry();
            entry.key = key;
            entry.value = value;
            entry.next = null;
  

            int index = calculateIndex(key);
            if (itemArray[index] == null)
            {
                itemArray[index] = entry;
            }
            else
            {
                Console.WriteLine("Collision detected for {0}", entry.key);

            }
            
            return index;
        }
        
        public object getValue(object key)
        {
            int index = calculateIndex(key);
            if (itemArray[index] == null)
                return null;
            else
                return itemArray[index].value;
        }
    }

    class MyHashTableEntry
    {
        public object key;
        public object value;
        public MyHashTableEntry next;
    }
}
