namespace ASPNET.Domain.Commons.Interface
{
    public interface IOrder : IEntity<Guid>
    {
        public Guid UserId { get; }
        public Guid ProductId { get; }
        public int Quantity { get; }
        public decimal TotalPrice { get; }
    }
}
