using System;
using prolab3;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.Security.Policy;
using System.Collections.Generic;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;


namespace prolab3
{
    public class Program
    {
        [STAThread]
         public static void Main()
        {
            

            string file = AppDomain.CurrentDomain.BaseDirectory + "users.json";
            string json = File.ReadAllText(file);
            Liste<User> users = System.Text.Json.JsonSerializer.Deserialize<Liste<User>>(json);
            //Hashtable
            int id = 0;
            Tablo hashtable = new Tablo(users.Count);
            foreach (var item in users)
            {
                id++;
                hashtable.ekle(id, item.Username);
            }
           
           

            GraphUtils graphUtils = new GraphUtils();
            graphUtils.CreateGraph(users,users.Count);

            Ilgialanlari interestAreas = new Ilgialanlari();
            interestAreas.Hesapla(users);
            interestAreas.Yazdır();
            interestAreas.HashTableUserTweet(users);

            




        }

       
       

    }

    }


