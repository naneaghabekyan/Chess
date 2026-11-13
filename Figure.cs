using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    abstract public class Figure
    {
       public bool Colour {  get; set; }
       public string SymbolName { get; set; }
       abstract public void NameSetter(bool col);
       abstract public bool ValidMove(int srow,int scol,int erow, int ecol);

        public Figure(bool col)
        {
            Colour = col;
        }
    }
}
