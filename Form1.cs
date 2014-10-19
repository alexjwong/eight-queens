using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace eight_queens
{
    public partial class Form1 : Form
    {       
        // List to hold all BoardCells (BoardCells contain queens)
        private List<BoardCell> Cells = new List<BoardCell>();

        // Init cellColor (as a brush color)
        Brush cellColor;

        // Init hints boolean
        private bool hints = false;

        // Cell height and width are constant 50
        const int CELLHEIGHT = 50;
        const int CELLWIDTH = 50;

        // Board is located at 100,100
        const int BOARDPOSITION = 100;

        public Form1()
        {
            InitializeComponent();

            // Initialize the board
            for (int row = 0; row < 8; row++)         // Create 8 rows (0-7)
            {
                for (int col = 0; col < 8; col++)     // Create 8 columns (0-7)
                {
                    // Set cell color depending on row and column
                    if (row % 2 == 1)   // if row is odd
                    {
                        if (col % 2 == 1)   // and col is odd
                        {
                            cellColor = Brushes.White;
                        }
                        else cellColor = Brushes.Black;
                    }
                    else // row is even
                    {
                        if (col % 2 == 1)   // and col is odd
                        {
                            cellColor = Brushes.Black;
                        }
                        else cellColor = Brushes.White;
                    }

                    // Rectangle(xcoord,ycoord,width,height)
                    Rectangle cellRect = new Rectangle(BOARDPOSITION + row * CELLWIDTH,BOARDPOSITION + col * CELLHEIGHT, CELLWIDTH, CELLHEIGHT);

                    // Create a new cell with Rect, row, col, and cell color
                    BoardCell cell = new BoardCell(cellRect, row, col, cellColor);

                    // Add it to the list of all cells
                    this.Cells.Add(cell);
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Graphics object g
            Graphics g = e.Graphics;

            // Draw each cell in Cells
            foreach (BoardCell c in this.Cells)
            {
                // Fill before draw to preserve border lines
                if (hints)
                {
                    if (!c.isSafe())
                    {
                        g.FillRectangle(Brushes.Red, c.cellRect);
                    }
                    else g.FillRectangle(c.cellColor, c.cellRect);
                }
                else g.FillRectangle(c.cellColor, c.cellRect);

                g.DrawRectangle(Pens.Black, c.cellRect);

                // Set font - this size makes it look centered
                Font drawFont = new Font("Arial", 33, FontStyle.Bold);

                // If there is a queen associated with the cell, draw it
                if (c.hasQueen())
                {
                    if (hints)      // with hints it's always black
                    {
                        g.DrawString("Q", drawFont, Brushes.Black, new Point(c.X, c.Y));
                    }
                    else            // Else render normally (color stored in BoardCell)
                    {
                        g.DrawString("Q", drawFont, c.q.color, new Point(c.X, c.Y));
                    }
                }
            }

            // Update the label
            label1.Text = String.Format("You have {0} queens on the board.", BoardCell.QueenCount);

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Check if click happened in any boundary for a BoardCell
                foreach (BoardCell c in Cells)
                {
                    if ( (e.X > c.X) && (e.X < c.X+50) && (e.Y > c.Y) && (e.Y < c.Y+50) )
                    {
                        if (c.isSafe())
                        {
                            if (!c.hasQueen())      // No queen there
                            {
                                c.addQueen();
                                
                                // If you just added a queen, check to see if it was the eighth
                                if (BoardCell.QueenCount == 8)
                                {
                                    // Pop up message box
                                    MessageBox.Show("You did it!");
                                }
                            }
                        }
                        else
                        {
                            System.Media.SystemSounds.Beep.Play();
                        }
                    }
                }
                this.Invalidate();
            }

            if (e.Button == MouseButtons.Right)
            {
                // Check if click happened in any boundary for a BoardCell
                foreach (BoardCell c in Cells)
                {
                    if ((e.X > c.X) && (e.X < c.X + 50) && (e.Y > c.Y) && (e.Y < c.Y + 50))
                    {
                        if (c.hasQueen())
                        {
                            // Remove the queen if there is one there
                            c.removeQueen();
                        }
                    }
                }
                this.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Clear list of queens
            foreach (BoardCell c in Cells)
            {
                c.removeQueen();
            }

            this.Invalidate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            hints = !hints;
            this.Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
