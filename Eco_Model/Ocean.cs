using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Eco_Model
{
    class Ocean
    {
        #region variables
        const int _MaxRows = 25;
        const int _MaxCols = 70;
        int DefaultNumIterations = 10000;
        int DefaultNumObstacles = 75;
        int DefaultNumPredators = 20;
        int DefaultNumPrey = 150;
        public int _numRows;
        public int _numCols;
        int _size;
        int _numPrey;
        int _numPredators;
        int _numObstacles;
        public char DefaultImage = '-';

        public Random _random = new Random();
        public Cell[,] _oceanCells = new Cell[_MaxRows, _MaxCols];
        #endregion

        #region Add (EmptyCells, Obstacle, Predator, Prey), GetEmptyCell.
        void AddEmptyCells()
        {
            for (int row = 0; row < _numRows; row++)
            {
                for (int col = 0; col < _numCols; col++)
                {
                    _oceanCells[row, col] = new Cell(new Coordinate(col, row));
                }
            }
        }

        public void AddObstacles()
        {
            Coordinate empty;
            for (int count = 0; count < _numObstacles; count++)
            {
                empty = getEmptyCellCoord();
                _oceanCells[empty.getY(), empty.getX()] = new Obstacle(empty);
            }
        }

        public void AddPreditors()
        {
            Coordinate empty;
            for (int count = 0; count < _numPredators; count++)
            {
                empty = getEmptyCellCoord();
                this._oceanCells[empty.getY(), empty.getX()] = new Predator(empty);
            }
        }

        public void AddPrey()
        {
            Coordinate empty;
            for (int count = 0; count < _numPrey; count++)
            {
                empty = getEmptyCellCoord();
                this._oceanCells[empty.getY(), empty.getX()] = new Prey(empty);
            }
        }

        Coordinate getEmptyCellCoord()
        {
            int x, y;
            do
            {
                x = _random.Next(0, _numCols - 1);
                y = _random.Next(0, _numRows - 1);
            }
            while (_oceanCells[y, x].getImage() != DefaultImage);
            return new Coordinate(x, y);
        }
        #endregion

        #region Initialize
        //Returns the number of preys
        public int getNumPrey()
        {
            return _numPrey;
        }

        //Set the number of preys
        public void setNumPrey(int aNumber)
        {
            _numPrey = aNumber;
        }

        //Returns the number of predators
        public int getNumPredators()
        {
            return _numPredators;
        }

        //Set the number of predators
        public void setNumPredators(int aNumber)
        {
            _numPredators = aNumber;
        }

        //Sets the values of obstacles, predators, prey by default on start programm
        public void Initialize()
        {
            _numRows = _MaxRows;
            _numCols = _MaxCols;
            _size = _numRows * _numCols;
            _numObstacles = DefaultNumObstacles;
            _numPredators = DefaultNumPredators;
            _numPrey = DefaultNumPrey;
            initCells();
        }

        // We ask the user for the number of obstacles, predators, prey and add to the ocean
        void initCells()
        {
            AddEmptyCells();
            Console.WriteLine("Enter number of obstacles (default =75):");
            _numObstacles = Convert.ToInt32(Console.ReadLine());
            if (_numObstacles == _size)
            {
                _numObstacles = _size;
                Console.WriteLine("Number NumObstacle accepted ={0}", _numObstacles);
            }

            Console.WriteLine("Enter number of predators (default=20:");
            _numPredators = Convert.ToInt32(Console.ReadLine());
            if (_numPredators == _size - _numObstacles)
            {
                _numPredators = _size - _numObstacles;
                Console.WriteLine("Number NumOPredators accepted ={0}", _numPredators);
            }

            Console.WriteLine("Enter number of prey (default=150:");
            _numPrey = Convert.ToInt32(Console.ReadLine());
            if (_numPrey == _size - _numObstacles - _numPredators)
            {
                _numPredators = _size - _numObstacles - _numPredators;
                Console.WriteLine("Number NumOPredators accepted ={0}", _numPrey);
            }

            AddObstacles();
            AddPreditors();
            AddPrey();

            displayCells();
            displayBorder();
            Cell._owner = this; // Ocean1 = this attaches the initialized ocean to all cells
        }
        #endregion

        #region Display UI
        // displays the maximum bounded area of ??the ocean. Initially this is only a horizontal border.
        void displayBorder()
        {
            for (int col = 0; col < _numCols; col++)
            {
                Console.Write("*");
            }
        }

        // Fill the array
        void displayCells()
        {
            for (int row = 0; row < _numRows; row++)
            {
                for (int col = 0; col < _numCols; col++)
                {
                    if (this._oceanCells[row, col] != null)
                    {
                        Console.SetCursorPosition(col, row);
                        this._oceanCells[row, col].display();
                    }
                    else
                    {
                    }
                }
            }
        }

        //updates the displayed iteration number, the number of obstacles, predators and prey
        void displayStats(int iteration)
        {
            Console.SetCursorPosition(0, _MaxRows + 2);
            Console.WriteLine("                                             ");
            Console.WriteLine("                                             ");
            Console.WriteLine("                                             ");
            Console.WriteLine("                                             ");
            Console.SetCursorPosition(0, _MaxRows + 2);
            Console.WriteLine("Iteration number {0}", iteration);
            Console.WriteLine("Obstacles: {0}", _numObstacles);
            Console.WriteLine("Predators: {0}", _numPredators);
            Console.WriteLine("Prey: {0}", _numPrey);
            displayBorder();
        }

        //STARTING THE MODELING PROCESS
        public void run()
        {
            int numiteration = DefaultNumIterations;
            Console.Write("\nEnter number of iterations (default max = 1000):");
            numiteration = Convert.ToInt32(Console.ReadLine());
            if (numiteration > 10000)
            {
                numiteration = 10000;
                Console.WriteLine("\n Number iteration = 10000 \nbegin run...\n");
            }

            int[] mas = new int[numiteration];

            for (int iteration = 0; iteration < numiteration; iteration++)
            {
                if (_numPredators > 0 && _numPrey > 0)
                {
                    for (int row = 0; row < _numRows; row++)
                    {
                        for (int col = 0; col < _numCols; col++)
                        {
                            this._oceanCells[row, col].Move();
                        }
                    }
                    displayStats(iteration);
                    displayCells();
                    displayBorder();
                    mas[iteration] = _numPredators;
                    Thread.Sleep(5000);

                }
            }
            Console.SetCursorPosition(0, _numRows + 7);
            Console.WriteLine("End of Simulation");

            Console.ReadLine();
        }
        #endregion
    }
}
