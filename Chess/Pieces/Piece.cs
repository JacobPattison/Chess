using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    abstract public class Piece
    {
        public Image Image { get; set; }
        public int Row {  get; set; }
        public int Column { get; set; }

        // 0 = White, 1 = Black
        public int Colour { get; set; }
        public Piece(int column, int row, int colour)
        {
            Column = column;
            Row = row;
            Colour = colour;
        }

        public abstract bool Move(int column, int row, Game_Manager game_Manager);


    }
}
