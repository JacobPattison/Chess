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
                        if (targetPiece.Column == this.Column && targetPiece.Row == this.Row - 1)
                        {
                            return false;
                        }
                        if((targetPiece.Column == this.Column - 1 && targetPiece.Row == this.Row - 1)
                            || (targetPiece.Column == this.Column + 1 && targetPiece.Row == this.Row - 1)) // Checks if it can take a piece
                        {
                            return true;
                        }
                    }
                    if (this.Colour == 1)
                    {
                        if (targetPiece.Column == this.Column && targetPiece.Row == this.Row + 1)
                        {
                            return false;
                        }
                        if ((targetPiece.Column == this.Column - 1 && targetPiece.Row == this.Row + 1)
                            || (targetPiece.Column == this.Column + 1 && targetPiece.Row == this.Row + 1)) // Checks if it can take a piece
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
