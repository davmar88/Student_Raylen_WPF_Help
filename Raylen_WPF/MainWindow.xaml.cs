using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Raylen_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //reference: https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/
        //generate random numbers and chars
        private readonly Random randnum = new Random();
        private readonly Random randalpha = new Random();

        //reference: https://www.geeksforgeeks.org/linked-list-implementation-in-c-sharp/
        //linkedlist to keep the generated names
        LinkedList<String> booknameslist1 = new LinkedList<String>();
        //linkedlist to sort the generated names using computation power
        //this is basically the control when thinking about experimentation
        //booknameslist2 is a built linkedlist from scratch
        BookNameLinkedList2 booknameslist2 = new BookNameLinkedList2();
        //linkedlist for user's input
        LinkedList<String> booknameslist3 = new LinkedList<String>();

        /// <summary>
        /// Click event on replace Books radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void replaceBooksClick(object sender, RoutedEventArgs e)
        {
            //starting recursion method
            checkIfBookNameExists();
        }

        /// <summary>
        /// Recursion Method to check if the current concatenated value from
        /// generateNum() and 
        /// generateAlpha() exists
        /// </summary>
        private void checkIfBookNameExists()
        {
            if (booknameslist1.Count == 10)
            {
                //Now we sort the linklist alphabetically and
                //we add the sorted elements to 
                //booknameslist2
                booknameslist2.display();
                booknameslist2.quick_sort(booknameslist2.head, booknameslist2.last_node());
                booknameslist2.display();
            }
            if (booknameslist1.Count<11)
            {
                string bookname = generateNum()+" "+ generateAlpha(3,false);
                if (booknameslist1.Contains(bookname) == true)
                {
                    //do not add it to the list
                    
                    
                }
                else
                {
                    //add to the list
                    booknameslist1.AddLast(bookname);
                    booknameslist2.insert(bookname);
                }
                //we keep on calling this method until
                //the count satisfies the total names in booknameslist
                //this is called Recursion
                checkIfBookNameExists();
            }
            


        }
        //005.73 JAM
        private string generateNum()
        {
            string num;
            int rand  = randnum.Next(100, 999);
            num = rand.ToString();
            num = num.Insert(1, ".");
            num = "00" + num;
            
            return num;
        }

        private string generateAlpha(int size, bool lowerCase = false)
        {
            
            var builder = new StringBuilder(size);
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)randalpha.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToUpper() : builder.ToString();
        }

        
        private void checkNameOrder()
        {
            
        }

    }
}
