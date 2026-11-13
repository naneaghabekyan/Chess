using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Dzi : Figure
    {
        public Dzi(bool col) : base(col)
        {
            NameSetter(col);
        }

        public override void NameSetter(bool col)
        {
            if (col)
                SymbolName = "D";
            else
                SymbolName = "d";
        }

        public override bool ValidMove(int srow, int scol, int erow, int ecol)
        {
            if (Math.Abs(erow - srow) == 2 && Math.Abs(ecol - scol) == 1)
                return true;
            else if (Math.Abs(erow - srow) == 1 && Math.Abs(ecol - scol) == 2)
                return true;
            return false;
        }
    }
}
