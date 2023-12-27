
namespace BorderControl.Models.Interfaces
{
    public interface IBuyer : INameable
    {
        void BuyFood();

        public int Food { get; }
    }
}
