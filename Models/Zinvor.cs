using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Zinvor : Figure
    {
        public Zinvor(bool col) : base(col)
        {
            NameSetter(col);
        }

        public override void NameSetter(bool col)
        {
            if (col)
                SymbolName = "Z";
            else
                SymbolName = "z";
        }

        public override bool FigureValidMove(int srow, int scol, int erow, int ecol)
        {
            if (Colour)
            {
                if ((scol == ecol || Math.Abs(scol - ecol) == 1) && srow - erow == 1)
                    return true;
                else if (srow == 6 && scol == ecol && srow - erow == 2)
                    return true;
            }
            else
            {
                if ((scol == ecol || Math.Abs(scol - ecol) == 1) && erow - srow == 1)
                    return true;
                else if (srow == 1 && scol == ecol && erow - srow == 2)
                    return true;
            }
            return false;
        }
    }

}
