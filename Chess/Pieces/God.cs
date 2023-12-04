using Chess.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class God : Piece
    {
        public God(int column, int row, int colour) : base(column, row, colour)
        {
            Image = Resources.God;
        }

        override public bool Move(int column, int row, Game_Manager game_Manager)
        {
            return true;
        }
    }
}
