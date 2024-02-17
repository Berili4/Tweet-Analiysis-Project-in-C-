using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace prolab3
{
    public class LinkedList
    {
        public Node head;

        public LinkedList()
        {
            head = null;

        }

        public void sonaEkle(int data)
        {
            Node eleman = new Node(data);

            if (head == null)
            {
                head = eleman;
                Console.WriteLine("Liste olusutuldu ilk dügüm eklendi");
            }
            else
            {
                Node temp = head;

                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = eleman;
                Console.WriteLine("Sona eleman eklendi");
            }
        }
        public void basaEkle(int data)
        {
            Node eleman = new Node(data);

            if (head == null)
            {
                head = eleman;
                Console.WriteLine("List olusturuldu ilk eleman eklendi");

            }
            else
            {
                eleman.next = head;
                head = eleman;
                Console.WriteLine("Basa eleman eklendi");

            }
        }
        public void yazdir()
        {
            Node temp = head;

            if (head == null)
            {
                Console.WriteLine("Liste bos");
            }

            else
            {
                Console.WriteLine("bas -> ");

                while (temp.next != null)
                {
                    Console.WriteLine(temp.data + " -> ");
                    temp = temp.next;


                }
                Console.WriteLine(temp.data + " son");
            }
        }
        public void bastanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste Bos");
            }

            else
            {
                head.next = head;
                Console.WriteLine("Bastaki eleman silindi");

            }
        }
        public void sondanSil()
        {

            if (head == null)
            {
                Console.WriteLine("Liste Bos");
            }
            else if (head.next == null)
            {
                head = null;
                Console.WriteLine("Listede kalan son dugum de silimdi");
            }
            else
            {
                Node temp = head;
                Node temp2 = temp;
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp2.next = null;
                Console.WriteLine("Sondakki düğüm silindi");


            }
        }

    }
}