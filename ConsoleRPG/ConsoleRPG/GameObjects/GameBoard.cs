using System.Drawing;

namespace Project1.GameObjects
{
    public class GameBoard
    {
        private int rows;
        private int cols;
        private List<List<BaseCell>> cells;
        private BaseCell previousCell;

        public Player player;

        /// <summary>
        /// Constructs a new instance of the GameBoard with the given 
        /// row and column values.
        /// </summary>
        /// <param name="rows">int</param>
        /// <param name="cols">int</param>
        public GameBoard(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;

            cells = new List<List<BaseCell>>();
        }

        /// <summary>
        /// Constructs a hard-coded instance of the <see cref="GameBoard"/>, 
        /// mostly for development purposes.
        /// 
        /// Map:
        /// ....................
        /// ....................
        /// ..........P.........
        /// ..##................
        /// .####...............
        /// ..###...............
        /// ...###............~~
        /// .................~~~
        /// ................~~~~
        /// ...............~~~~~
        /// 
        /// Size: 10x20
        /// veg cells:   (2-3, 3), (1-4, 4), (2-4, 5), 
        ///              (3-5, 6)
        /// water cells: (18-19, 6), (17-19, 7), (16-19, 8),
        ///              (15-19, 9)
        /// Player:      (10, 2)
        /// Enemy:       (5, 1)
        /// </summary>
        public GameBoard(Player player)
        {
            this.player = player;
            previousCell = new BaseCell(player.X, player.Y);

            rows = 10;
            cols = 20;

            cells = new List<List<BaseCell>>();

            // construct vegetation tiles
            List<Point> vegTiles = new List<Point>();
            vegTiles.Add(new Point(2, 3));
            vegTiles.Add(new Point(3, 3));
            vegTiles.Add(new Point(1, 4));
            vegTiles.Add(new Point(2, 4));
            vegTiles.Add(new Point(3, 4));
            vegTiles.Add(new Point(4, 4));
            vegTiles.Add(new Point(2, 5));
            vegTiles.Add(new Point(3, 5));
            vegTiles.Add(new Point(4, 5));
            vegTiles.Add(new Point(3, 6));
            vegTiles.Add(new Point(4, 6));
            vegTiles.Add(new Point(5, 6));

            // construct water tiles
            List<Point> waterTiles = new List<Point>();
            waterTiles.Add(new Point(18, 6));
            waterTiles.Add(new Point(19, 6));
            waterTiles.Add(new Point(17, 7));
            waterTiles.Add(new Point(18, 7));
            waterTiles.Add(new Point(19, 7));
            waterTiles.Add(new Point(16, 8));
            waterTiles.Add(new Point(17, 8));
            waterTiles.Add(new Point(18, 8));
            waterTiles.Add(new Point(19, 8));
            waterTiles.Add(new Point(15, 9));
            waterTiles.Add(new Point(16, 9));
            waterTiles.Add(new Point(17, 9));
            waterTiles.Add(new Point(18, 9));
            waterTiles.Add(new Point(19, 9));

            // create game board full of regular cells
            for (int i = 0; i < rows; i++)
            {
                List<BaseCell> row = new List<BaseCell>();
                bool skip = false;
                for (int j = 0; j < cols; j++)
                {
                    // check for vegetation tiles
                    foreach(Point p in vegTiles)
                    {
                        if (p.X == j && p.Y == i)
                        {
                            row.Add(new VegetationCell(j, i));
                            skip = true;
                        }
                    }
                    foreach (Point p in waterTiles)
                    {
                        if (p.X == j && p.Y == i)
                        {
                            row.Add(new WaterCell(j, i));
                            skip = true;
                        }
                    }
                    if (i == player.Y && j == player.X)
                    {
                        row.Add(player);
                        skip = true;
                    }
                    if (!skip)
                    {
                        row.Add(new BaseCell(j, i));
                    }
                    skip = false;
                }
                cells.Add(row);
            }
        }

        public void MoveLeft()
        {
            player.X -= 1;
        }

        public void MoveRight()
        {
            player.X += 1;
        }

        public void MoveUp()
        {
            player.Y -= 1;
        }

        public void MoveDown()
        {
            player.Y += 1;
        }

        public void CalculateNextBoard()
        {
            // copy list of previous cells
            List<List<BaseCell>> newCells = cells;

            // set spot where player was at back to its original state 
            newCells[previousCell.Y][previousCell.X] = previousCell;

            // save current state of cell located at player's new coords 
            previousCell = newCells[player.Y][player.X];

            // set player in new coords 
            newCells[player.Y][player.X] = player;

            // set current cells to new generation of cells 
            cells = newCells;
        }

        public void LevelUp()
        {
            player.Level += 1;
            Console.WriteLine($"You are now Level {player.Level}!");
            Console.WriteLine();
            Console.WriteLine("Which attribute would you like to improve?");
            Console.WriteLine("1: Health");
            Console.WriteLine("2: Damage");
            Console.Write("$: ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                player.MaxHP += 10;
            }
            else if (choice == 2)
            {
                player.Weapon.Upgrade(2);
            }
            else
            {
                Console.WriteLine("Invalid Choice!");
                LevelUp();
            }
        }

        /// <summary>
        /// Renders the game board to the console screen.
        /// </summary>
        public void Render()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (cells[i][j] is WaterCell)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else if (cells[i][j] is VegetationCell)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else if (cells[i][j] is Player)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.Write(cells.ToArray()[i][j].GetDisplay());
                }
                Console.Write("\n");
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
