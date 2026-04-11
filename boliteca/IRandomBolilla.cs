using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace boliteca
{
    public interface IRandomBolilla
    {
        int Next(int min, int max);
    }
}