using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prolab3
{
    public class GraphUtils
    {

        public void CreateGraph(Liste<User> users, int tableSize)
        {
            Graph graph = new Graph(users.Count);

            Tablo followerLists = new Tablo(tableSize);
            Tablo followingLists = new Tablo(tableSize);
            int i = 0;
            foreach (User user in users)
            {
                followerLists.ekle(user.Username, user.TakipçiKullanıcıAdları);
                followingLists.ekle(user.Username, user.TakipEdilenKullanıcıAdları);
            }
            foreach (string user in followerLists.TabloYazdir())
            {
                if (user == null)
                {
                    break;
                }
                foreach (string followedUser in (Liste<string>)followerLists.Ara(user))
                {
                    if (followingLists.TabloYazdir().Contains(followedUser))
                    {
                        graph.ekleEdge(graph.GetVertexIndex(user), graph.GetVertexIndex(followedUser));
                    }
                }
            }
        }
       

       
    }
}
   
