using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Model
{
    class Predator : Prey
    {
        public char DefaultPredImage = '>';
        protected int _timeToFeed;


        // Resets the instance variable image
        public Predator(Coordinate aCoord)
            : base(aCoord)
        {
            _offset = aCoord;
            _image = DefaultPredImage;
            _timeToFeed = 6;
        }

        public override void Move()
        {
            Coordinate toCoord;
            if (--_timeToFeed <= 0)//predator dead
            {
                assignCellAt(_offset, new Cell(_offset));
                _owner.setNumPredators(_owner.getNumPredators() - 1);
            }
            else
            {
                toCoord = getPreyNeightborCoord();
                if (toCoord != _offset)
                {
                    _owner.setNumPrey(_owner.getNumPrey() - 1);
                    _timeToFeed = 6;//_timeToFeed = _timeToFeed
                    moveFrom(_offset, toCoord);
                }
                else  // if possible, moves to an empty cell (c-th-w-c) and --timeToReproduce
                {
                    //--_timeToReproduce;
                    base.Move();
                }
            }
        }


        // reproduces itself in a cell with anOffSet coordinates in the cell array from Ocean1
        public override Cell reproduce(Coordinate anOffSet)
        {
            Predator temp = new Predator(anOffSet);
            _owner.setNumPredators(_owner.getNumPredators() + 1);
            return (Cell)temp;
        }
    }
}
