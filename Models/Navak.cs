using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Navak : Figure
    {
        public Navak(bool col) : base(col)
        {
            NameSetter(col);
        }

        public override void NameSetter(bool col)
        {
            if (col)
                SymbolName = "N";
            else
                SymbolName = "n";
        }

        public override bool FigureValidMove(int srow, int scol, int erow, int ecol)
        {
            if (ecol == scol)
                return true;
            else if (erow == srow)
                return true;
            return false;
        }
    }
}
