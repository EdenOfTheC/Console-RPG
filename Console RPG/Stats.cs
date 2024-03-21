namespace Console_RPG
{
    //Structs are useful for storing simple plain data
    struct Stats
    {
        public int speed;
        public int strength;
        public int defense;
        public int specialAttack;
        public int specialDefense;

        public Stats(int speed, int strength, int defense, int specialAttack, int specialDefense)
        {
            this.speed = speed;
            this.strength = strength;
            this.defense = defense;
            this.specialAttack = specialAttack;
            this.specialDefense = specialDefense;
        }
    }
}
