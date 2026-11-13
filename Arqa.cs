using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Chess;

namespace Chess
{
    public class Arqa: Figure
    {
        public Arqa(bool col) : base(col) { NameSetter(col);  }
        public override void NameSetter(bool col)
        {
            if (col)
                SymbolName = "A";
            else
                SymbolName = "a";
        }
        public override bool ValidMove(int srow, int scol, int erow, int ecol)
        {
            if(Math.Abs(erow-srow) <= 1 && Math.Abs(ecol - scol) <= 1)
                return true;

            return false;
        }
    }
}

