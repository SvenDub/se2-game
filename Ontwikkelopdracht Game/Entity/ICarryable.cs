namespace Ontwikkelopdracht_Game.Entity
{
    public interface ICarryable
    {
        int Weight { get; }
        void PickUp();
    }
}