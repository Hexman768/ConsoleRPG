using Project1.GameObjects;

namespace Project1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Write("Hello, this is a turn-based adventure, role-playing game.\n\n" +
                $"Each turn you will have the ability to move in any one of four directions.\n\n" +
                $"Each time you move, information will be shown regarding the tile you are on.\n\n" +
                $"You may have the choice to engage an enemy in combat if there happens to be one on the tile you move to.\n\n" +
                $"You will not be able to see which tiles have enemies.\n\n" +
                $"Each tile you move to may also contain an item that can restore some of your health, you can either use the item or move to another cell.\n\n");

            Console.Write("Please type in your player name: ");
            string playerName = Console.ReadLine();

            Weapon playerWeapon = new Weapon("Sword", 10);
            Player player = new Player(10, 2, playerName, 100, 1, playerWeapon, 1);

            // construct game board
            GameBoard board = new GameBoard(player);

            bool enemyPresent = false;
            bool itemPresent = false;

            // create main game loop
            bool running = true;
            while (running)
            {
                Random rand = new Random();
                int enemyChance = rand.Next(1, 101);

                int itemChance = rand.Next(1, 101);

                if (enemyChance > 50)
                {
                    enemyPresent = true;
                }
                else
                {
                    enemyPresent = false;
                }

                if (itemChance > 50)
                {
                    itemPresent = true;
                }
                else
                {
                    itemPresent = false;
                }

                Console.Clear();
                board.Render();

                // display player stats 
                Console.WriteLine($"{board.player.Name} - Health: {board.player.Health} - Level: {board.player.Level} - Weapon: {board.player.Weapon.Name} - Weapon Damage: {board.player.Weapon.Damage}");

                Console.WriteLine("-----------------------------------------------------");

                Console.WriteLine("Current Tile Information:");
                Console.Write("Enemy Present: ");
                if (enemyPresent)
                {
                    Console.Write("Yes");
                }
                else
                {
                    Console.Write("No");
                }

                Console.WriteLine();

                Console.Write("Item Present: ");
                if (itemPresent)
                {
                    Console.Write("Yes");
                }
                else
                {
                    Console.Write("No");
                }

                Console.WriteLine();

                // display player choices
                Console.WriteLine("Pick one of the following choices: ");
                Console.WriteLine("4: Move Left");
                Console.WriteLine("6: Move Right");
                Console.WriteLine("8: Move Up");
                Console.WriteLine("2: Move Down");
                Console.WriteLine("5: Exit Game");
                if (enemyPresent)
                {
                    Console.WriteLine("9: Fight Enemy");
                }
                if (itemPresent)
                {
                    Console.WriteLine("7: Use Item");
                }

                Console.Write("$: ");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 4:
                        board.MoveLeft();
                        break;
                    case 6:
                        board.MoveRight();
                        break;
                    case 8:
                        board.MoveUp();
                        break;
                    case 2:
                        board.MoveDown();
                        break;
                    case 5:
                        running = false;
                        break;
                    case 9:
                        if (enemyPresent)
                        {
                            int enemyHP = 10;
                            bool fighting = true;
                            while (fighting)
                            {
                                Console.Clear();
                                Console.WriteLine("The enemy has hit you for 2 points!");
                                board.player.Health -= 2;
                                Console.WriteLine();
                                Console.WriteLine($"Your Health: {board.player.Health}");
                                Console.WriteLine($"Your Damage: {board.player.Weapon.Damage}");
                                Console.WriteLine($"Enemy Health: {enemyHP}");
                                Console.WriteLine("Enemy Damage: 2");
                                Console.WriteLine("What would you like to do?");
                                Console.WriteLine("1. Hit enemy");
                                Console.WriteLine("2. Run Away");

                                int choice = int.Parse(Console.ReadLine());
                                switch (choice)
                                {
                                    case 1:
                                        Console.WriteLine($"You hit the enemy for {board.player.Weapon.Damage} points");
                                        enemyHP -= board.player.Weapon.Damage;
                                        if (enemyHP <= 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("You have beaten the enemy, you get to level up!");
                                            board.LevelUp();
                                            fighting = false;
                                        }
                                        break;
                                    case 2:
                                        fighting = false;
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice, you lose this turn!");
                        }
                        break;
                    case 7:
                        if (itemPresent)
                        {
                            board.player.Health = board.player.MaxHP;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice, you lose this turn!");
                        }
                        break;
                }
                board.CalculateNextBoard();
            }
        }
    }
}
