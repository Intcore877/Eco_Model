using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Model
{
    class Obstacle : Cell
    {
        char ObstacleImage = '#';

        public Obstacle(Coordinate aCoord)
            : base(aCoord)
        {
            _offset = aCoord;
            _image = ObstacleImage;
        }

        public Obstacle(Obstacle source)
            : base(source._offset)
        {
        }

        public override void Move()
        {
        }

        public override Cell reproduce(Coordinate anOffSet)
        {
            return new Obstacle(this);
        }

    }
}
