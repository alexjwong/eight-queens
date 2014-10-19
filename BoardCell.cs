using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace eight_queens
{
    class BoardCell
    {
        // Coordinate of cell is a Point
        public Rectangle cellRect;

        // Variables for easy access of coordinates
        public int X;
        public int Y;

        // Variables to note the row+column of the cell
        public int rowNumber;
        public int colNumber;

        // Color of cell
        public Brush cellColor;

        // Queen
        public Queen q;

        // Total number of queens
        public static int QueenCount;

        // See if a row or column is taken
        public static bool[,] taken = new bool[8,8];

        public BoardCell(Rectangle in_rect, int in_row, int in_col, Brush in_color)
        {
            // Store rectangle representing this cell
            this.cellRect = in_rect;

            // Store actual coordinates for easier access
            this.X = in_rect.X;
            this.Y = in_rect.Y;

            // Store row + col numbers
            this.rowNumber = in_row;
            this.colNumber = in_col;
            
            // Store cell color
            this.cellColor = in_color;
        }

        public void addQueen()
        {
            // Color of queen depends on color of cell
            // Create a queen with correct color, and flag the row/column it takes
            if (this.cellColor == Brushes.Black)
            {
                this.q = new Queen(new Point(this.X,this.Y), Brushes.White);
                taken[this.rowNumber,this.colNumber] = true;
            }
            else
            {
                this.q = new Queen(new Point(this.X,this.Y), Brushes.Black);
                taken[this.rowNumber, this.colNumber] = true;
            }
            QueenCount++;
        }

        public void removeQueen()
        {
            if (this.q != null)
            {
                // Take it off of row flags first
                taken[this.rowNumber, this.colNumber] = false;

                // Set it to null object
                this.q = null;

                // Decrement queen counter
                QueenCount--;
            }
        }

        public bool hasQueen()
        {
            if (this.q != null)
            {
                return true;
            }
            else return false;
        }

        public bool isSafe()
        {
            // Check if theres an entry in the same row or column
            // Given row...
            for (int col = 0; col < 8; col++)
            {
                if (taken[this.rowNumber, col]) return false;
            }
            // Given col...
            for (int row = 0; row < 8; row++)
            {
                if (taken[row, this.colNumber]) return false;
            }


            // Check diagonals

            // If you have 2 queens
            // and deltaRow = abs(Q1row - Q2row)
            // and deltaCol = abs(Q1col - Q2col)
            // if deltaRow == deltaCol, the queens are on the same diagonal
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (taken[row,col])
                    {
                        // Compare our queen to each queen to see if its on the same diagonal
                        int drow = Math.Abs(row - this.rowNumber);
                        int dcol = Math.Abs(col - this.colNumber);

                        if (drow == dcol)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;       // If not in same row, column, or diagonal as any other queen
        }
    }
}
