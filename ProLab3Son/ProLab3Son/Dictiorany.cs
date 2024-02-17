using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prolab3
{
    public class Dictiorany<TKey, TValue>
    {
        private Liste<KeyValuePair<TKey, TValue>> nesne;

        public Dictiorany()
        {
            nesne = new Liste<KeyValuePair<TKey, TValue>>();
        }

        public void Ekle(TKey key, TValue value)
        {
          
            nesne.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool ContainsKey(TKey key)
        {
            
            foreach (var ne in nesne)
            {
                if (EqualityComparer<TKey>.Default.Equals(ne.Key, key))
                {
                    return true;
                }
            }
            return false;
        }

        public TValue GetItem(TKey key)
        {
            foreach (var item in nesne)
            {
                if (EqualityComparer<TKey>.Default.Equals(item.Key, key))
                {
                    return item.Value;
                }
            }
            return default(TValue); 
        }

        public void sil(TKey key)
        {
            // Belirtilen anahtara sahip öğeyi sözlükten kaldırır.
            for (int i = 0; i < nesne.Count; i++)
            {
                if (EqualityComparer<TKey>.Default.Equals(nesne[i].Key, key))
                {
                    nesne.RemoveAt(i);
                    return;
                }
            }
            Console.WriteLine($"{key} anahtarına sahip öğe bulunamadı.");
        }

        public IEnumerable<KeyValuePair<TKey, TValue>> tumnesneler()
        {

            return nesne;
        }


    }
}
