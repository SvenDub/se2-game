namespace Ontwikkelopdracht_Game.Entity
{
    public abstract class Character : MoveableObject
    {
        public int Cooldown { get; set; }
        public int BaseCooldown { get; set; }

        public abstract void Fire();
    }
}
