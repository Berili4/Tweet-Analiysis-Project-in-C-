using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prolab3
{
    public class Ilgialanlari
    {
        public Dictionary<string, Liste<User>> InterestAreas { get; set; }

        public Ilgialanlari()
        {
            InterestAreas = new Dictionary<string, Liste<User>>();
        }

        public void Hesapla(Liste<User> users)
        {
            foreach (User user in users)
            {
                foreach (string tweet in user.Tweetler)
                {
                    string[] tweets = tweet.Split(' ');
                    string mostCommonWord = tweets.OrderByDescending(word => word.Count()).First();
                    user.MostCommonWord = mostCommonWord;
                }
            }

            foreach (User user in users)
            {
                List<string> interestAreasList = user.Tweetler
                    .Select(word => word.Split(","))
                    .Select(words => words.First())
                    .Distinct()
                    .ToList();
                foreach (string interestArea in interestAreasList)
                {
                    Liste<User> usersForInterestArea;
                    if (!InterestAreas.ContainsKey(interestArea))
                    {
                        usersForInterestArea = new Liste<User>();
                        InterestAreas.Add(interestArea, usersForInterestArea);
                    }
                    else
                    {
                        usersForInterestArea = InterestAreas[interestArea];
                    }

                    usersForInterestArea.Add(user);
                }
            }
        }

        public void Yazdır()
        {
            foreach (KeyValuePair<string, Liste<User>> pair in InterestAreas)
            {
                Console.WriteLine("İlgi alanı: {0}, Kullanıcı sayısı: {1}", pair.Key, pair.Value.Count);
            }
        }

        public void HashTableUserTweet(Liste<User> users)
        {
            int tweetCount = 0;
            foreach (User user in users)
            {
                foreach (string tweet in user.Tweetler)
                {
                    tweetCount++;
                }
            }
            Tablo hashtableUserTweet = new Tablo(tweetCount);
            foreach (User user in users)
            {
                foreach (string tweet in user.Tweetler)
                {
                    string[] tweets = tweet.Split(' ');
                    string mostCommonWord = tweets.OrderByDescending(word => word.Count()).First();
                    hashtableUserTweet.ekle(mostCommonWord, user.Username);
                }
            }

        }

    }

}