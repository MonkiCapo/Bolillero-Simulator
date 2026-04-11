using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace boliteca
{
    public class RandomBolilla
    {
        private Random r = new Random();

        public int Next(int min, int max)
        {
            return r.Next(min, max);
        }
    }
}