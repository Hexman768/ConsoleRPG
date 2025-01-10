namespace Project1.GameObjects
{
    /// <summary>
    /// This class represents the player object.
    /// </summary>
    public class Player : BaseCell
    {
        private string name;
        private int health;
        private int level;
        private Weapon weapon;
        private int defense;
        private int maxHP;

        /// <summary>
        /// Constructs an instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="health">int</param>
        /// <param name="level">int</param>
        /// <param name="weapon">Object</param>
        public Player(int x, int y, string name, int health, int level, Weapon weapon, int defense) : base(x, y)
        {
            this.name = name;
            this.health = health;
            this.level = level;
            this.weapon = weapon;
            this.defense = defense;
            maxHP = health;
        }

        /// <summary>
        /// Returns the name of the player.
        /// </summary>
        public string Name { get { return name; } }

        /// <summary>
        /// Returns the player's remaining health.
        /// </summary>
        public int Health { get { return health; } set { health = value; } }

        /// <summary>
        /// Returns the player's current level.
        /// </summary>
        public int Level { get { return level; } set { level = value; } }

        /// <summary>
        /// Returns the player's weapon instance.
        /// </summary>
        public Weapon Weapon { get { return weapon; } }

        /// <summary>
        /// Represents the player's ability to deflect some damage.
        /// </summary>
        public int Defense { get { return defense; } set { defense = value; } }

        /// <summary>
        /// Represents the player's maximum possible amount of health.
        /// </summary>
        public int MaxHP { get { return maxHP; } set { maxHP = value; } }

        public override string GetDisplay()
        {
            return "P";
        }
    }
}
