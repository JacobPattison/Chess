using Chess.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class King : Piece
    {
        public King(int column, int row, int colour) : base(column, row, colour)
        {
            if (colour == 0)
            {
                Image = Resources.White_King;
            }
            if (colour == 1)
            {
                Image = Resources.Black_King;
            }
        }

        override public bool Move(int targetColumn, int targetRow, Game_Manager game_Manager)
        {
            if (game_Manager.Pieces[targetColumn, targetRow] != null)
            {
                if (game_Manager.Pieces[targetColumn, targetRow].Colour == this.Colour)
                    return false;
            }
            if (targetColumn == this.Column + 1 || targetColumn == this.Column - 1 && targetRow == this.Row + 1 || targetRow == this.Row - 1)
                return true;

            return false;
        }
    }
}
