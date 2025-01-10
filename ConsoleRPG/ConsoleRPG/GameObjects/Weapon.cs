namespace Project1.GameObjects
{
    /// <summary>
    /// This class represents a Weapon the player can use against enemies in the game.
    /// </summary>
    public class Weapon
    {
        private string name;
        private int damage;

        /// <summary>
        /// Constructs an instance of the <see cref="Weapon"/> class.
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="damage">int</param>
        public Weapon(string name, int damage)
        {
            this.name = name;
            this.damage = damage;
        }

        /// <summary>
        /// Returns the name of the weapon.
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Returns the amount of damage the weapon can deal to an enemy.
        /// </summary>
        public int Damage { get { return damage; } }

        /// <summary>
        /// Upgrades the damage the weapon can do.
        /// </summary>
        /// <param name="points">Integer</param>
        public void Upgrade(int points)
        {
            damage += points;
        }
    }
}
