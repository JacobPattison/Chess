using Chess.Properties;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class Rook : Piece
    {
        public Rook(int column, int row, int colour) : base(column, row, colour)
        {
            if (colour == 0)
            {
                Image = Resources.White_Rook;
            }
            if (colour == 1)
            {
                Image = Resources.Black_Rook;
            }
        }
        override public bool Move(int targetColumn, int targetRow, Game_Manager game_Manager)
        {
            Piece targetPiece = game_Manager.Pieces[targetColumn, targetRow];
            if (game_Manager.SideToMove == this.Colour)
            {
                if (targetColumn == this.Column) // If its on the same column
                {
                    if (targetRow > this.Row) // And the piece is after itself
                    {
                        if (CheckColumn(true, targetColumn, targetRow, game_Manager.Pieces)) { return true; }
                    }

                    if (targetRow < this.Row) // And the piece is before itself
                    {
                        if (CheckColumn(false, targetColumn, targetRow, game_Manager.Pieces)) { return true; }

                    }
                }

                if (targetRow == this.Row)
                {
                    if (targetColumn > this.Column) // And the piece is after itself
                    {
                        if (CheckRow(true, targetColumn, targetRow, game_Manager.Pieces)) { return true; }
                    }
                    if (targetColumn < this.Column) // And the piece is before itself
                    {
                        if (CheckRow(false, targetColumn, targetRow, game_Manager.Pieces)) { return true; }
                    }
                }
            }
            return false;
        }

        private bool CheckColumn(bool isAfter, int targetColumn, int targetRow, Piece[,] pieces)
        {
            int currentRow = this.Row;
            do
            {
                if (isAfter) { currentRow++; }
                else { currentRow--; }

                Piece temp = pieces[this.Column, currentRow];
                if (temp == null && currentRow == targetRow) // If it has gone over everything until the target and theryre empty and target is empty
                {
                    return true;
                }
                else if (temp != null && temp != this) // If theres a piece
                {
                    if (temp.Colour == this.Colour) // And its the same colour
                    {
                        return false;
                    }
                    else if (temp.Row != targetRow ||
                        temp.Column != targetColumn) // And its a different colour and its not the target piece
                    {
                        return false;
                    }
                    else if (temp.Colour != this.Colour &&
                    temp.Row == targetRow &&
                        temp.Column == targetColumn) // Take the piece
                    {
                        return true;
                    }
                }
            } while (currentRow != targetRow);
            return false;
        }

        private bool CheckRow(bool isAfter, int targetColumn, int targetRow, Piece[,] pieces)
        {
            int currentColumn = this.Column;
            do
            {
                if (isAfter) { currentColumn++; }
                else { currentColumn--; }

                Piece temp = pieces[currentColumn, this.Row];
                if (temp == null && currentColumn == targetColumn) // If it has gone over everything until the target and theryre empty and target is empty
                {
                    return true;
                }
                else if (temp != null && temp != this) // If theres a piece
                {
                    if (temp.Colour == this.Colour) // And its the same colour
                    {
                        return false;
                    }
                    else if (temp.Row != targetRow ||
                        temp.Column != targetColumn) // And its a different colour and its not the target piece
                    {
                        return false;
                    }
                    else if (temp.Colour != this.Colour &&
                    temp.Row == targetRow &&
                        temp.Column == targetColumn) // Take the piece
                    {
                        return true;
                    }
                }
            } while (currentColumn != targetColumn);
            return false;
        }
    }
}
