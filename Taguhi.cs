using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Taguhi : Figure
    {
        public Taguhi(bool col) : base(col)
        {
            NameSetter(col);
        }

        public override void NameSetter(bool col)
        {
            if (col)
                SymbolName = "T";
            else
                SymbolName = "t";
        }

        public override bool ValidMove(int srow, int scol, int erow, int ecol)
        {
            if (ecol == scol)
                return true;
            else if (erow == srow)
                return true;
            else if (Math.Abs(erow - srow) == Math.Abs(ecol - scol))
                return true;
            return false;
        }
    }
}
