using Chess.Properties;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(int column, int row, int colour) : base(column, row, colour)
        {
            if (colour == 0)
            {
                Image = Resources.White_Bishop;
            }
            if (colour == 1)
            {
                Image = Resources.Black_Bishop;
            }
        }

        override public bool Move(int targetColumn, int targetRow, Game_Manager game_Manager)
        {
            Piece targetPiece = game_Manager.Pieces[targetColumn, targetRow];
            if (game_Manager.SideToMove == this.Colour)
            {
                if (targetColumn < this.Column)
                {
                    if (targetRow < this.Row) // -,-
                    {
                        if(CheckRegion('-', '-', targetColumn, targetRow, game_Manager.Pieces)){ return true; }
                    }
                    if (targetRow > this.Row) // -,+
                    {
                        if (CheckRegion('-', '+', targetColumn, targetRow, game_Manager.Pieces)) { return true; }
                    }
                }
                if (targetColumn > this.Column)
                {
                    if (targetRow < this.Row) // +,-
                    {
                        if (CheckRegion('+', '-', targetColumn, targetRow, game_Manager.Pieces)) { return true; }
                    }
                    if (targetRow > this.Row) // +,+
                    {
                        if (CheckRegion('+', '+', targetColumn, targetRow, game_Manager.Pieces)) { return true; }
                    }
                }
            }
            return false;
        }
        
        private bool CheckRegion(char columnRegion, char rowRegion, int targetColumn, int targetRow, Piece[,] pieces)
        {
            int currentColumn = this.Column;
            int currentRow = this.Row;
            do
            {
                // Checks the regions
                if(columnRegion == '+') { currentColumn++; }
                else if (columnRegion == '-') { currentColumn--; }
                
                if(rowRegion == '+') { currentRow++; }
                else if (rowRegion == '-') { currentRow--; }
                
                // 
                Piece tempPiece = pieces[currentColumn, currentRow];
                if (tempPiece == null && currentRow == targetRow && currentColumn == targetColumn) // If it has gone over everything until the target and theryre empty and target is empty
                {
                    return true;
                }
                else if (tempPiece != null && tempPiece != this) // If theres a piece
                {
                    if (tempPiece.Colour == this.Colour) // And its the same colour
                    {
                        return false;
                    }
                    else if (tempPiece.Row != targetRow ||
                        tempPiece.Column != targetColumn) // And its a different colour and its not the target piece
                    {
                        return false;
                    }
                    else if (tempPiece.Colour != this.Colour &&
                    tempPiece.Row == targetRow &&
                        tempPiece.Column == targetColumn) // Take the piece
                    {
                        return true;
                    }
                }
            } while (currentColumn != targetColumn && currentRow != targetRow);
            return false;
        }
        
    }
}
