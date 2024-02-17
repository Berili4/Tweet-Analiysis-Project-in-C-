using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prolab3
{
    public class User
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int TakipçiSayısı {  get; set; }
        public int TakipEdilenSayısı { get; set; }


        public string Dil { get; set; }
        public string Bölge { get; set; }

        public Liste<String> Tweetler { get; set; }

       public Liste<String> TakipçiKullanıcıAdları { get; set; }

      public   Liste<String> TakipEdilenKullanıcıAdları { get; set; }
        public Liste<string> Interests { get; set; }
        public string MostCommonWord { get; internal set; }

        public User(string username)
        {
            Username = username;
            Interests = new Liste<string>();
        }




    }
}
