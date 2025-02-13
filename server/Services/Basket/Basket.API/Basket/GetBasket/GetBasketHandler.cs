

namespace Basket.API.Basket.GetBasket
{
    public record GetBasketQuery(string userName) : IQuery<GetbasketResult>;
    public record GetbasketResult(ShoppingCart Cart);
    public class GetBasketQueryHandler(IBasketRepository repository) : IQueryHandler<GetBasketQuery, GetbasketResult>
    {
        public async Task<GetbasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            var basket = await repository.GetBasketAsync(query.userName, cancellationToken);
            return new GetbasketResult(basket);
        }
    }
}
