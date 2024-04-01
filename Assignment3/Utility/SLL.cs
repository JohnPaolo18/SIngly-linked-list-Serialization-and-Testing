using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    [Serializable]
    public class SLL : ILinkedListADT
    {
        private Node head; //head of the list, initially null
        private int count; //keeps track of the size of the list

        public SLL() //This sets up an empty list
        {
            head = null;
            count = 0;
        }

        //Checks if the list is empty
        public bool IsEmpty()
        {
            return count == 0;
        }

        //This method resets the list back to being empty, resetting the count to 0
        public void Clear()
        {
            head = null;
            count = 0;
        }
        //This puts a new item at the start of the list. if there are other items, this one goes in front of all of them
        public void AddFirst(User value)
        {
            Node newNode = new Node(value);
            newNode.Next = head;
            head = newNode;
            count++;
        }

        // Adds a node with the specified data to the end of the list.
        public void AddLast(User value)
        {
            if (IsEmpty()) //if list is empty
            {
                AddFirst(value); //Just add at the beginning
                return;
            }
            Node current = head; //Start at the beginning of the list
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = new Node(value); //Create a new node at the end of the list
            count++; //Increase item count by 1
        }
        //This adds a new item at a specific spot in the list. You tell it where to go, and it puts the item there.
        public void Add(User value, int index)
        {
            if (index < 0 || index > count)// if index is out of range
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                AddFirst(value);
                return;
            }
            if (index == count)
            {
                AddLast(value);
                return;
            }
            Node newNode = new Node(value); //Creates a new node
            Node current = head;
            for (int i = 0; i < count; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next; //Insert new node to the correct spot
            current.Next = newNode; //make the previous node point to the new node
            count++;
        }

        //These methods remove elements from the list, which involves adjusting the 
        //Next references of the surrounding nodes and decrementing the count.
        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new CannotRemoveException("Cannot remove an element from an empty list");
            }
            head = head.Next; //Set the start of the list to the 2nd node, removing the 1st
            count--; //Decrease item count by 1
        }

        //Remove the last item from the list
        public void RemoveLast()
        {
            if (IsEmpty())
            {
                throw new CannotRemoveException("Cannot remove an element from an empty list");
            }
            if (count == 1)
            {
                head = null;
            }
            else
            {
                Node current = head;
                while (current.Next.Next != null)//find the 2nd to last node
                {
                    current = current.Next;
                }
                current.Next = null; //Remove last node by setting 2nd to last node point to null
            }
            count--;
        }

        //This removes an item from a specific spot.
        //If you ask to remove an item from a place that doesn't exist,
        //it'll let you know that's not possible.
        public void Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                RemoveFirst();
                return;
            }
            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            count--;
        }

        //Get the value of a specific index
        public User GetValue(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        //This tells you where in the list an item is.
        //If the item isn't in the list, it returns -1, meaning "not found."
        public int IndexOf(User value)
        {
            int index = 0;
            Node current = head;
            while (current.Next != null)
            {
                if (current.Data.Equals(value))
                {
                    return index;
                }
                index++;
                current = current.Next;
            }
            return -1;
        }
        //This checks if a specific item is in the list. If it is, it says "true."
        //If not, it says "false."
        public bool Contains(User value)
        {
            Node current = head;
            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        // Counts the number of items in the list.
        public int Count()
        {
            return count;
        }

        //Changes the item at a specific spot to a new one.
        public void Replace (User value, int index)
        {
            if(index <0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }
            Node current = head;
            for (int i = 0;i < index; i++)
            {
                current = current.Next;
            }
            current.Data = value;
        }

        //Additional functionality
        //Turning the list around so the last item is now first and the first item is last
        public void Reverse()
        {
            Node prev = null;
            Node current = head;
            Node next = null;

            while (current != null)
            {
                //Save next
                next = current.Next;

                //Reverse current nodes pointer
                current.Next = prev;

                //Move pointers one position ahead
                prev = current;
                current = next;
            }
            head = prev; //set the last node to head
        }

    }
}
