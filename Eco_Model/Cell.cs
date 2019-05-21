using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Model
{
    class Cell
    {
        public char DefaultPreyImage = 'o';
        public static Ocean _owner;
        public char DefaultImage = '-';
        public char _image;
        protected Coordinate _offset;

        public Cell(Coordinate aCoord)
        {
            _image = DefaultImage;
            _offset = aCoord;
        }
        

        //Getter
        public Coordinate getOffSet()
        {
            return _offset;
        }

        //Setter
        public void setOffSet(Coordinate anOffset)
        {
            _offset = anOffset;
        }

        //Get Image
        public char getImage()
        {
            return _image;
        }

        //Moves to neighboring cell using specific rules(depending on subclass)
        public virtual void Move() { }


        //Searches for an empty adjacent cell(north-south-west-east)
        public Coordinate getEmptyNeightborCoord()
        {
            return this.getNeighboringCellWithImage(DefaultImage).getOffSet();
        }

        //Searches for a neighboring cell with Prey cell(north-south-west-east)
        public Coordinate getPreyNeightborCoord()
        {
            return getNeighboringCellWithImage(DefaultPreyImage).getOffSet();
        }

        Cell getNeighboringCellWithImage(char imageFind)
        {
            Cell[] neightbor = new Cell[4];
            int count = 0;
            if (north().getImage() == imageFind) { neightbor[count++] = north(); }
            if (south().getImage() == imageFind) { neightbor[count++] = south(); }
            if (east().getImage() == imageFind) { neightbor[count++] = east(); }
            if (west().getImage() == imageFind) { neightbor[count++] = west(); }

            if (count == 0) { return this; }
            else { return neightbor[_owner._random.Next(0, count - 1)]; }
        }

        // Returns a cell with aCoord coordinates in cell array from Ocean1
        public Cell getCellAt(Coordinate aCoord)
        {
            return _owner._oceanCells[aCoord.getY(), aCoord.getX()];
        }


        // Places the aCell cell at a location with aCoord coordinates in the cell array of Ocean1
        public void assignCellAt(Coordinate aCoord, Cell aCell)
        {
            _owner._oceanCells[aCoord.getY(), aCoord.getX()] = aCell;
        }

        // returns the cell in the east -> <- | ^
        Cell east()
        {
            int xvalue;
            xvalue = (_offset.getX() + 1) % _owner._numCols;
            return _owner._oceanCells[_offset.getY(), xvalue];
        }

        
        Cell west()
        {
            int xvalue;
            xvalue = (_offset.getX() > 0) ? (_offset.getX() - 1) : (_owner._numCols - 1);
            return _owner._oceanCells[_offset.getY(), xvalue];
        }

        Cell south()
        {
            int yvalue;
            yvalue = (_offset.getY() + 1) % _owner._numRows;
            return _owner._oceanCells[yvalue, _offset.getX()];
        }

        Cell north()
        {
            int yvalue;
            yvalue = (_offset.getY() > 0) ? (_offset.getY() - 1) : (_owner._numRows - 1);
            return _owner._oceanCells[yvalue, _offset.getX()];
        }


        // methods of processing and display
        public virtual Cell reproduce(Coordinate anOffSet)
        {
            Cell temp = new Cell(anOffSet);
            return temp;
        }

        //Displays an image Cell
        public void display()
        {
            Console.WriteLine(_image);
        }
    }
}
