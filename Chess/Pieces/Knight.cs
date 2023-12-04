using Chess.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Pieces
{
    public class Knight : Piece
    {
        public Knight(int column, int row, int colour) : base(column, row, colour)
        {
            if (colour == 0)
            {
                Image = Resources.White_Knight;
            }
            if (colour == 1)
            {
                Image = Resources.Black_Knight;
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
                        if (CheckRegion("--", targetColumn, targetRow, game_Manager.Pieces)) { return true; }
                    }
                    if (targetRow > this.Row) // -,+
                    {
                        if (CheckRegion("-+", targetColumn, targetRow, game_Manager.Pieces)) { return true; }
                    }
                }
                if (targetColumn > this.Column)
                {
                    if (targetRow < this.Row) // +,-
                    {
                        if (CheckRegion("+-", targetColumn, targetRow, game_Manager.Pieces)) { return true; }
                    }
                    if (targetRow > this.Row) // +,+
                    {
                        if (CheckRegion("++", targetColumn, targetRow, game_Manager.Pieces)) { return true; }
                    }
                }
            }
            return false;
        }

        private bool CheckRegion(string region, int targetColumn, int targetRow, Piece[,] pieces)
        {
            int checks = 0;
            int currentColumn = this.Column;
            int currentRow = this.Row;
            do
            {
                currentColumn = this.Column;
                currentRow = this.Row;
                // Check top or bottom
                if (checks == 0)
                {
                    
                    if (region == "--")
                    {
                        if (this.Row == 1) { checks++; continue; }
                        currentColumn--;
                        currentRow -= 2;
                    }
                    else if (region == "-+")
                    {
                        if (this.Row == 6) { checks++; continue; }
                        currentColumn--;
                        currentRow += 2;
                    }
                    else if (region == "+-")
                    {
                        if (this.Row == 1) { checks++; continue; }
                        currentColumn++;
                        currentRow -= 2;
                    }
                    else if (region == "++")
                    {
                        if (this.Row == 6) { checks++; continue; }
                        currentColumn++;
                        currentRow += 2;
                    }
                }
                // Checks left or right
                else if (checks == 1)
                {
                    if (region == "--")
                    {
                        currentColumn -= 2;
                        currentRow--;
                    }
                    else if (region == "-+")
                    {
                        currentColumn -= 2;
                        currentRow++;
                    }
                    else if (region == "+-")
                    {
                        currentColumn += 2;
                        currentRow--;
                    }
                    else if (region == "++")
                    {
                        currentColumn += 2;
                        currentRow++;
                    }
                }
                else if (checks == 3) { break; }

                Piece tempPiece = pieces[currentColumn, currentRow];
                if (tempPiece == null && currentRow == targetRow && currentColumn == targetColumn) // If it has gone over everything until the target and theryre empty and target is empty
                {
                    return true;
                }
                else if (tempPiece != null && tempPiece != this) // If theres a piece
                {
                    if (tempPiece.Colour == this.Colour)
                    {
                        checks++;
                        continue;
                    }
                    if (tempPiece.Row != targetRow ||
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
                checks++;
            } while (currentColumn != targetColumn && currentRow != targetRow);
            return false;

            List<string> possibleMovements = new List<string>();
            
        }

        /*
          Piece targetPiece = pieces[targetColumn, targetRow];

            int checkColumn1 = this.Column;
            int checkRow1 = this.Row;
            int checkColumn2 = this.Column;
            int checkRow2 = this.Row;

            if (region == "--")
            {
                checkColumn1--;
                checkRow1 -= 2;
                checkColumn2 -= 2;
                checkRow2--;
            }
            else if (region == "-+")
            {
                checkColumn1--;
                checkRow1 += 2;
                checkColumn2 -= 2;
                checkRow2++;
            }
            else if (region == "+-")
            {
                checkColumn1++;
                checkRow1 -= 2;
                checkColumn2 += 2;
                checkRow2--;
            }
            else if (region == "++")
            {
                checkColumn1++;
                checkRow1 += 2;
                checkColumn2 += 2;
                checkRow2++;
            }

            if (targetPiece != null && targetPiece != this) // If theres a piece
            {
                if (targetPiece.Colour == this.Colour) // And its the same colour
                {
                    if (targetPiece.Column == checkColumn1 && targetPiece.Row == checkRow1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (targetPiece.Row != targetRow ||
                    targetPiece.Column != targetColumn) // And its a different colour and its not the target piece
                {
                    return false;
                }
                else if (targetPiece.Colour != this.Colour &&
                targetPiece.Row == targetRow &&
                    targetPiece.Column == targetColumn) // Take the piece
                {
                    return true;
                }
            }
            return false
        */
    }
}
