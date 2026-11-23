using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pigh : Figure
    {
        public Pigh(bool col) : base(col)
        {
            NameSetter(col);
        }
        public override void NameSetter(bool col)
        {
            if (col)
                SymbolName = "P";
            else
                SymbolName = "p";
        }

        public override bool FigureValidMove(int srow, int scol, int erow, int ecol)
        {
            if (Math.Abs(erow - srow) == Math.Abs(ecol - scol))
                return true;
            return false;
        }
    }
}
