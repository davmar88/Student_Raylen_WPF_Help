using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raylen_WPF
{
	//reference: https://kalkicode.com/quicksort-singly-linked-list
	public class BookNameLinkedList2
    {
		public Node head;
		public Node tail;
		//Class constructors
		public BookNameLinkedList2()
		{
			this.head = null;
			this.tail = null;
		}
		//insert node at last of linke list
		public void insert(string value)
		{
			//Create a node
			Node node = new Node(value);
			if (this.head == null)
			{
				//When linked list empty add first node
				this.head = node;
				this.tail = node;
			}
			else
			{
				//Add new node at end of linked list
				this.tail.next = node;
				this.tail = node;
			}
		}
		//Display linked list nodes
		public void display()
		{
			if (this.head != null)
			{
				Console.Write("\n Linked List :");
				Node temp = this.head;
				while (temp != null)
				{
					Console.Write(" " + temp.data);
					temp = temp.next;
					if (temp == this.head)
					{
						//avoid loop
						return;
					}
				}
			}
			else
			{
				Console.WriteLine("Empty Linked List");
			}
		}
		//Find last node of linked list
		public Node last_node()
		{
			Node temp = this.head;
			while (temp != null && temp.next != null)
			{
				temp = temp.next;
			}
			return temp;
		}
		//Set of given last node position to its proper position
		public Node parition(Node first, Node last)
		{
			//Get first node of given linked list
			Node pivot = first;
			Node front = first;
			string temp = "";
			while (front != null && front != last)
			{
				//reference:https://stackoverflow.com/questions/40691259/how-to-sort-a-linked-list-in-alphabetical-order-using-java
				//the next assumes the list is already sorted
				//this only inserts the data to the linked list
				if (front.data.CompareTo(last.data)>=0)
				{
					pivot = first;
					//Swap node value
					temp = first.data;
					first.data = front.data;
					front.data = temp;
					//Visit to next node
					first = first.next;
				}
				//Visit to next node
				front = front.next;
			}
			//Change last node value to current node
			temp = first.data;
			first.data = last.data;
			last.data = temp;
			return pivot;
		}
		//Perform quick sort in given linked list
		public void quick_sort(Node first, Node last)
		{
			if (first == last)
			{
				return;
			}
			//Find pivot node
			Node pivot = parition(first, last);
			if (pivot != null && pivot.next != null)
			{
				quick_sort(pivot.next, last);
			}
			if (pivot != null && first != pivot)
			{
				quick_sort(first, pivot);
			}
		}
	}
}
