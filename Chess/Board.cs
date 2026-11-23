using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Data;
using Models;

namespace Chess
{
    public class Board
    {
        public Figure[,] ChessBoard { get; private set; }

        private Arqa _Arqa = new Arqa(true);
        private Arqa _arqa = new Arqa(false);
        private Taguhi _Taguhi = new Taguhi(true);
        private Taguhi _taguhi = new Taguhi(false);
        private Navak _Navak = new Navak(true);
        private Navak _navak = new Navak(false);
        private Dzi _Dzi = new Dzi(true);
        private Dzi _dzi = new Dzi(false);
        private Pigh _Pigh = new Pigh(true);
        private Pigh _pigh = new Pigh(false);
        private Zinvor _Zinvor = new Zinvor(true);
        private Zinvor _zinvor = new Zinvor(false);


        private int _whiteArqaRow = 7;
        private int _whiteArqaCol = 4;
        private int _blackArqaRow = 0;
        private int _blackArqaCol = 4;

        

        public Board()
        {
            Initilize();
        }


        public void Initilize()
        {


            ChessBoard = new Figure[8, 8]
                     {
                         { _navak, _dzi, _pigh, _taguhi, _arqa, _pigh, _dzi, _navak },
                         { _zinvor, _zinvor, _zinvor, _zinvor, _zinvor, _zinvor, _zinvor, _zinvor },
                         { null, null, null, null, null, null, null, null },
                         { null, null, null, null, null, null, null, null },
                         { null, null, null, null, null, null, null, null },
                         { null, null, null, null, null, null, null, null },
                         { _Zinvor, _Zinvor, _Zinvor, _Zinvor, _Zinvor, _Zinvor, _Zinvor, _Zinvor },
                         { _Navak, _Dzi, _Pigh, _Taguhi, _Arqa, _Pigh, _Dzi, _Navak }
                     };

        }


        //public void PrintBoard()
        //{
        //    Console.WriteLine("   A B C D E F G H");
        //    Console.WriteLine("  ----------------");

        //    for (int i = 0; i < 8; i++)
        //    {
        //        Console.Write(8 - i + "|" + " ");
        //        for (int j = 0; j < 8; j++)
        //        {
        //            if (ChessBoard[i, j] != null)
        //                Console.Write(ChessBoard[i, j].SymbolName + " ");
        //            else
        //                Console.Write(". ");
        //        }

        //        Console.WriteLine("\n");
        //    }

        //}

        public bool MoveValidation(int startcol, int startrow, int endcol, int endrow, bool playercol)
        {

            if (ChessBoard[startrow, startcol] != null
                && ChessBoard[startrow, startcol].Colour == playercol
                && ChessBoard[startrow, startcol].FigureValidMove(startrow, startcol, endrow, endcol)
                && RoadIsFree(startrow, startcol, endrow, endcol)
                )
            {
                if (ChessBoard[endrow, endcol] != null)
                {
                    if (ChessBoard[endrow, endcol].Colour == playercol)
                        return false;
                }

                Figure figure = ChessBoard[endrow, endcol];
                int oldKingRow = playercol ? _whiteArqaRow : _blackArqaRow;
                int oldKingCol = playercol ? _whiteArqaCol : _blackArqaCol;


                ChessBoard[endrow, endcol] = ChessBoard[startrow, startcol];
                ChessBoard[startrow, startcol] = null;


                if (ChessBoard[endrow, endcol] is Arqa)
                {
                    if (ChessBoard[endrow, endcol].Colour)
                    {
                        _whiteArqaRow = endrow;
                        _whiteArqaCol = endcol;
                    }
                    else
                    {
                        _blackArqaRow = endrow;
                        _blackArqaCol = endcol;
                    }

                }


                if (Shax(playercol))
                {
                    ChessBoard[startrow, startcol] = ChessBoard[endrow, endcol];
                    ChessBoard[endrow, endcol] = figure;

                    if (playercol)
                    {
                        _whiteArqaRow = oldKingRow;
                        _whiteArqaCol = oldKingCol;
                    }
                    else
                    {
                        _blackArqaRow = oldKingRow;
                        _blackArqaCol = oldKingCol;
                    }
 
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RoadIsFree(int srow, int scol, int erow, int ecol)
        {

            if (ChessBoard[srow, scol] is Dzi)
                return true;

            if (ChessBoard[srow, scol] is Zinvor)
            {
                if (scol == ecol && ChessBoard[erow, ecol] == null)
                    return true;
                else if (Math.Abs(ecol - scol) == 1 && ChessBoard[erow, ecol] != null)
                    return true;

                return false;
            }


            int sindex, eindex;



            if (srow == erow)
            {
                if (Math.Abs(ecol - scol) == 1)
                    return true;

                sindex = scol < ecol ? scol : ecol;
                eindex = scol < ecol ? ecol : scol;

                for (int i = sindex + 1; i < eindex; i++)
                {
                    if (ChessBoard[srow, i] != null) return false;
                }
                return true;
            }


            if (scol == ecol)
            {
                if (Math.Abs(erow - srow) == 1)
                    return true;

                sindex = srow < erow ? srow : erow;
                eindex = srow < erow ? erow : srow;

                for (int i = sindex + 1; i < eindex; i++)
                {
                    if (ChessBoard[i, scol] != null) return false;
                }
                return true;
            }

            if (Math.Abs(erow - srow) == Math.Abs(ecol - scol))
            {
                int rowSize = erow > srow ? 1 : -1;
                int colsize = ecol > scol ? 1 : -1;

                int row = srow + rowSize;
                int col = scol + colsize;

                while (row != erow && col != ecol)
                {
                    if (ChessBoard[row, col] != null)
                        return false;

                    row += rowSize;
                    col += colsize;
                }

                return true;
            }


            return false;
        }


        private bool HasLegalMove(bool playercol)
        {
            int oldKingRow = playercol ? _whiteArqaRow : _blackArqaRow;
            int oldKingCol = playercol ? _whiteArqaCol : _blackArqaCol;

            for (int srow = 0; srow < 8; srow++)
            {
                for (int scol = 0; scol < 8; scol++)
                {
                    if (ChessBoard[srow, scol] == null || ChessBoard[srow, scol].Colour != playercol)
                        continue;

                    for (int erow = 0; erow < 8; erow++)
                    {
                        for (int ecol = 0; ecol < 8; ecol++)
                        {
                            if (srow == erow && scol == ecol)
                                continue;

                            if (!ChessBoard[srow, scol].FigureValidMove(srow, scol, erow, ecol)
                                || !RoadIsFree(srow, scol, erow, ecol))
                                continue;

                            if (ChessBoard[erow, ecol] != null && ChessBoard[erow, ecol].Colour == playercol)
                                continue;

                            Figure figure = ChessBoard[erow, ecol];

                            ChessBoard[erow, ecol] = ChessBoard[srow, scol];
                            ChessBoard[srow, scol] = null;

                            if (ChessBoard[erow, ecol] is Arqa)
                            {
                                if (playercol)
                                {
                                    _whiteArqaRow = erow;
                                    _whiteArqaCol = ecol;
                                }
                                else
                                {
                                    _blackArqaRow = erow;
                                    _blackArqaCol = ecol;
                                }
                            }

                            bool stillShax = Shax(playercol);

                            ChessBoard[srow, scol] = ChessBoard[erow, ecol];
                            ChessBoard[erow, ecol] = figure;

                            if (playercol)
                            {
                                _whiteArqaRow = oldKingRow;
                                _whiteArqaCol = oldKingCol;
                            }
                            else
                            {
                                _blackArqaRow = oldKingRow;
                                _blackArqaCol = oldKingCol;
                            }

                            if (!stillShax)
                                return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool Shax(bool playercol)
        {
            int tempRow = playercol ? _whiteArqaRow : _blackArqaRow;
            int tempCol = playercol ? _whiteArqaCol : _blackArqaCol;


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (ChessBoard[i, j] != null && ChessBoard[i, j].Colour != playercol)
                    {
                        if (ChessBoard[i, j].FigureValidMove(i, j, tempRow, tempCol)
                            && RoadIsFree(i, j, tempRow, tempCol))
                        {
                            return true;
                        }

                    }
                }
            }
            return false;

        }




        public bool Mat(bool colour)
        {
            if (!HasLegalMove(colour) && Shax(colour))
                return true;
            return false;
        }

    }
}
