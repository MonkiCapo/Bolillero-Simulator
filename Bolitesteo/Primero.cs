using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using boliteca;

namespace Bolitesteo
{
    public class Primero : IRandomBolilla
    {
        public int Next(int min, int max)
        {
            return min; 
        }
    }

}