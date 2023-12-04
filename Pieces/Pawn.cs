using Chess.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess.Pieces
{
    public class Pawn : Piece
    {
        private bool firstMove = true;
        public Pawn(int column, int row, int colour) : base(column, row, colour)
        {
            if (colour == 0)
            {
                Image = Resources.White_Pawn;
            }
            if (colour == 1)
            {
                Image = Resources.Black_Pawn;
            }
        }

        public override bool Move(int column, int row, Game_Manager game_manager)
        {
            Piece targetPiece = game_manager.Pieces[column, row];
            if (game_manager.SideToMove == this.Colour)
            {
                if (targetPiece != null)
                {
                    if (targetPiece.Colour == this.Colour)  // Checks if the place it wants to go has a piece of its own colour
                    { 
                        return false; 
                    }
                    if (this.Colour == 0)
                    {
                        if(targetPiece.Column == )

                        
                        int leftRow = game_manager.Pieces[this.Column - 1, this.Row - 1].Row;
                        int leftColumn = game_manager.Pieces[this.Column - 1, this.Row - 1].Column;
                        int rightRow = game_manager.Pieces[this.Column + 1, this.Row - 1].Row;
                        int rightColumn = game_manager.Pieces[this.Column + 1, this.Column - 1].Column;
                        if ((leftColumn == targetPiece.Column && leftRow == targetPiece.Row) || 
                            rightColumn == targetPiece.Column && rightRow == targetPiece.Row) // Checks if there is a piece of opposite colour it can take
                        {
                            return true;
                        }
                    }
                    if (this.Colour == 1)
                    {
                        int leftRow = game_manager.Pieces[column + 1, row + 1].Row;
                        int leftColumn = game_manager.Pieces[column + 1, row + 1].Column;
                        int rightRow = game_manager.Pieces[column - 1, row + 1].Row;
                        int rightColumn = game_manager.Pieces[column - 1, row + 1].Column;
                        if ((leftColumn == targetPiece.Column && leftRow == targetPiece.Row) ||
                            rightColumn == targetPiece.Column && rightRow == targetPiece.Row) // Checks if there is a piece of opposite colour it can take
                        {
                            return true;
                        }
                    }
                }
                if (this.Column != column) // Checks if its going to an illegal column
                {
                    return false; 
                }
                if (this.Colour == 0) // Is White
                {
                    if (this.Row - 1 == row || (this.Row - 2 == row && firstMove == true))  // Checks for the place infront of it and two infront if its the first move
                    { 
                        firstMove = false; // Revokes the two forward move
                        return true; 
                    }
                }
                if (this.Colour == 1) // Is Black
                {
                    if (this.Row + 1 == row || this.Row + 2 == row && firstMove == true) // Checks for the place infront of it and two infront if its the first move
                    { 
                        firstMove = false; // Revokes the two forward move
                        return true; 
                    }
                }
            }
            return false;
        }

    }
}
