using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedPoint
{
    public class Fixed<T>
    {
        T cislo;
        public Fixed(int i)
        {
            cislo = new T(i);
        }

    }
}
