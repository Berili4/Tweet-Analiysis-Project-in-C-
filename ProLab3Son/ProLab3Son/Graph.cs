using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prolab3
{

    public class Graph
    {
        public int sayac = 0;
        public int[][] AListe;
        

        public Graph(int maxVertices)
        {
            AListe = new int[maxVertices][];
        }

        public void ekleVertex()
        {
            AListe[sayac] = new int[0];
            sayac++;
        }

        public void ekleEdge(int kaynak, int yer)
        {
         
           
            if (AListe[kaynak] == null)
            {
                AListe[kaynak] = new int[1];
            }
            else
            {
                int[] newList = new int[AListe[kaynak].Length + 1];
                Array.Copy(AListe[kaynak], newList, AListe[kaynak].Length);
                AListe[kaynak] = newList;
            }

            
            AListe[kaynak][AListe[kaynak].Length - 1] = yer;

            
            if (AListe[yer] == null)
            {
                AListe[yer] = new int[1];
            }
            else
            {
                int[] newList = new int[AListe[yer].Length + 1];
                Array.Copy(AListe[yer], newList, AListe[yer].Length);
                AListe[yer] = newList;
            }
            AListe[yer][AListe[yer].Length - 1] = kaynak;
        }
        public int GetVertexIndex(string vertex)
        {
            for (int i = 0; i < sayac; i++)
            {
                if (AListe  [i] != null && AListe[i][0].Equals(vertex))
                {
                    return i;
                }
            }
            return 0;
        }
    }
    }

    