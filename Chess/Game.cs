using Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Game_Manager
    {
        public int SideToMove { get; set; }
        public bool WhiteQueenCastle { get; set; }
        public bool WhiteKingCastle { get; set; }
        public bool BlackQueenCastle { get; set; }
        public bool BlackKingCastle { get; set; }
        public string EnPassantTargetSquare { get; set; }
        public int HalfMoveCount { get; set; }
        public int FullMoveCount { get; set; }
        public Piece[,] Pieces { get; set; }
        public Game_Manager()
        {
            SideToMove = 0;
            WhiteQueenCastle = true; 
            WhiteKingCastle = true; 
            BlackQueenCastle = true; 
            BlackKingCastle = true;
            EnPassantTargetSquare = "-";
            HalfMoveCount = 0;
            FullMoveCount = 0;
            Pieces = new Piece[8,8];
        }

        public Game_Manager(char sideToMove, bool whiteQueenCastle, bool whiteKingCastle, bool blackQueenCastle, bool blackKingCastle, string enPassantTargetSquare, int halfMoveCount, int fullMoveCount)
        {
            SideToMove = sideToMove;
            WhiteQueenCastle = whiteQueenCastle;
            WhiteKingCastle = whiteKingCastle;
            BlackQueenCastle = blackQueenCastle;
            BlackKingCastle = blackKingCastle;
            EnPassantTargetSquare = enPassantTargetSquare;
            HalfMoveCount = halfMoveCount;
            FullMoveCount = fullMoveCount;
        }

        public Piece[,] CreatePieces()
        {
            
            Piece[,] pieces = new Piece[8,8];
            
            pieces[0,7] = new Rook(0, 7, 0);
            pieces[1,7] = new Knight(1, 7, 0);
            pieces[2,7] = new Bishop(2, 7, 0);
            pieces[3,7] = new Queen(3, 7, 0);
            pieces[4,7] = new King(4, 7, 0);
            pieces[5,7] = new Bishop(5, 7, 0);
            pieces[6,7] = new Knight(6, 7, 0);
            pieces[7,7] = new Rook(7, 7, 0);
            for(int pawn = 0; pawn < 8; pawn++)
            {
                pieces[pawn, 6] = new Pawn(pawn, 6, 0);
            }

            pieces[3, 4] = new God(3, 4, 0); 

            pieces[0, 0] = new Rook(0, 0, 1);
            pieces[1, 0] = new Knight(1, 0, 1);
            pieces[2, 0] = new Bishop(2, 0, 1);
            pieces[3, 0] = new Queen(3, 0, 1);
            pieces[4, 0] = new King(4, 0, 1);
            pieces[5, 0] = new Bishop(5, 0, 1);
            pieces[6, 0] = new Knight(6, 0, 1);
            pieces[7, 0] = new Rook(7, 0, 1);
            for (int pawn = 0; pawn < 8; pawn++)
            {
                pieces[pawn, 1] = new Pawn(pawn, 1, 1);
            }
            /*
            pieces[0, 0] = new Knight(0, 0, 0);
            pieces[7, 7] = new Knight(7, 7, 0);
            pieces[6, 6] = new Knight(6, 6, 0);
            */

            return pieces;
        }
    }
}
