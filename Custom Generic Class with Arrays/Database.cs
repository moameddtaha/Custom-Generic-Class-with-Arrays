using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Generic_Class_with_Arrays
{
    public class Database<TKey, TValue>
    {
        private TKey[] keys;
        private TValue[] values;
        private int count;

        public Database()
        {
            keys = new TKey[4];
            values = new TValue[4];
            count = 0;
        }
        public Database(TKey[] keys, TValue[] values, int count)
        {
            this.keys = keys;
            this.values = values;
            this.count = count;
        }

        public void Add(TKey key, TValue value)
        {
            if (count == keys.Length)
            {
                Array.Resize(ref keys, keys.Length * 2);
                Array.Resize(ref values, values.Length * 2);
            }
            keys[count] = key;
            values[count] = value;
            count++;
        }

        public bool Remove(TKey key)
        {
            int index = Array.IndexOf(keys, key);
            if(index == -1) return false;

            for (int i = index; i < count - 1; i++)
            {
                keys[i] = keys[i + 1];
                values[i] = values[i + 1];
            }
            count--;

            if (count < keys.Length / 4)
            {
                Array.Resize(ref keys, keys.Length / 2);
                Array.Resize(ref values, values.Length / 2);
            }

            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            int index = Array.IndexOf(keys, key);
            if (index == -1)
            {
                value = default;
                return false;
            }
            value = values[index];
            return true;
        }

        public int Count
        {
            get { return count; }
        }
    }
}
