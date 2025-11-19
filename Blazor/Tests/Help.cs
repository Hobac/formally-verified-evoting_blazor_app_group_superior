using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class Help
    {
        private static Random random = new Random();

        public static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int randomIndex = random.Next(0, n + 1);
                T value = list[randomIndex];
                list[randomIndex] = list[n];
                list[n] = value;
            }
        }
    }
}
