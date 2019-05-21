using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Model
{
    class Prey : Cell
    {
        protected int _timeToReproduce;

        public Prey(Coordinate aCoord) : base(aCoord)
        {
            _offset = aCoord;
            _image = DefaultPreyImage;
            _timeToReproduce = 6;
        }


        // Methods of display and execution
        // Moves if possible to an empty cell (north-south-west-east), reduces timeToReoproduce by 1
        public override void Move()
        {
            Coordinate toCoord;
            toCoord = getEmptyNeightborCoord();
            moveFrom(_offset, toCoord);
        }


        // Moves from the from coordinates to the coordinates of to in the cells array from Ocean1
        public void moveFrom(Coordinate from, Coordinate to)
        {
            Cell toCell;
            --_timeToReproduce;
            if (to != from)
            {
                toCell = getCellAt(to);
                setOffSet(to); // new coordinates are set in the cell where we are moving
                assignCellAt(to, this);
                if (_timeToReproduce <= 0)
                {
                    _timeToReproduce = 6;
                    assignCellAt(from, reproduce(from));
                }
                else
                {
                    assignCellAt(from, new Cell(from));
                }
            }
        }


        // Reproduces itself in a cell with anOffSet coordinates in the cells array from Ocean1
        public override Cell reproduce(Coordinate anOffSet)
        {
            Prey temp = new Prey(anOffSet);
            _owner.setNumPrey(_owner.getNumPrey() + 1);
            return (Cell)temp;
        }
    }
}
