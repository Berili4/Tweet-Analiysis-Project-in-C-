using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace prolab3
{
    public class Tablo
    {
        class Node
        {
            public object key { get; set; }
            public object value { get; set; }
            public Node next;
            public Node()
            {
                next = null;
            }
            public Node(object key, object value)
            {
                this.key = key;
                this.value = value;
                this.next = null;
            }
        }

        public int Tablesize;
        Node[] dizi;
        public Tablo(int Tablesize)
        {
            this.Tablesize = Tablesize;
            dizi = new Node[Tablesize];
            for (int i = 0; i < Tablesize; i++)
            {
                dizi[i] = new Node();
            }
        }
         int Hash(int key) 
         {
             return key % Tablesize;
         }
        int Hash(string key) 
        {

           
            if(key==null)
            {
                return 0;
            }
            int indis = 0;
            foreach (char c in key)
            {
                indis = (indis * 31 + c) % Tablesize;
            }

            return indis;
        }

        public void ekle(int key, object value) 
        {
            Node eleman = new Node(key, value);
            int indis = Hash(key);
            Node temp = dizi[indis];

            while (temp.next != null)
            {
                temp = temp.next; 
            }
            temp.next = eleman; 
            Console.WriteLine(key+" numaralı "+"kullanıcı adı "+value + " hashtable'a eklendi");
        }
       
        public void ekle(string key, object value) 
        {
            Node eleman = new Node(key, value);
            int indis = Hash(key);
            Node temp = dizi[indis];

            while (temp.next != null)
            {
                temp = temp.next; 
            }
            temp.next = eleman; 
            Console.WriteLine("Key:"+key+" Değer:"+value);
        }

        public void kullanicisayisi()
        {
            int sayac = 0;
            for (int i = 0; i < Tablesize; i++)
            {
                Node temp = dizi[i];
                while (temp.next != null)
                {
                    temp = temp.next;
                    sayac++;
                }
            }
        }

        public void kullanicibul(object key)
        {
            bool sonuc = false;
            for (int i = 0; i < Tablesize; i++)
            {
                Node temp = dizi[i];
                if (temp.key == key)
                {
                    sonuc = true;
                }
            }
        }

        public void ekle(string key, Liste<string> value)
         {
            int i = 0;
            foreach (string item in value.ToList())
            {
                if (i == value.Count)
                {
                    break;
                }
                Node eleman = new Node(key,item);
                int indis = Hash(key);
                Node temp = dizi[indis];
                while (temp.next != null)
                {
                    temp = temp.next; 
                }
                temp.next = eleman;
                Console.WriteLine(key + " kişisinin takipçilerine " + item + " kişisi eklendi.");
            }
        }
        public IEnumerable<string> TabloYazdir()
        {
            foreach (Node node in dizi)
            {
                Node currentNode = node; 
                while (currentNode != null)
                {
                    yield return (string)currentNode.key;
                    currentNode = currentNode.next;
                }
            }
        }
        public Liste<string> Ara(string key)
        {
            int indis = Hash(key);
            Node temp = dizi[indis];
            while (temp != null)
            {
                if (temp.key == key)
                {
                    return (Liste<string>)temp.value;
                }
                temp = temp.next;
            }
            return null;
        }
    }
    
}
