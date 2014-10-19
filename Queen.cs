using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;

namespace eight_queens
{
    public class Queen
    {
        public Point location;
        public Brush color;

        public Queen(Point in_loc, Brush in_color)
        {
            // Store location of queen
            this.location = in_loc;

            // Set color of Queen;
            this.color = in_color;
        }
    }
}
