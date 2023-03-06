using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raylen_WPF
{
	//reference: https://kalkicode.com/quicksort-singly-linked-list
	public class Node
    {
		//our booknames are all strings
		public string data;
		public Node next;
		public Node(string data)
		{
			//set node value
			this.data = data;
			this.next = null;
		}
	}
}
