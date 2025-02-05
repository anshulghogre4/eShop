

namespace Basket.API.Basket.GetBasket
{   
    public record GetBasketQuery(string userName): IQuery<GetbasketResult>;
    public record GetbasketResult(ShoppingCart Cart);
    public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetbasketResult>
    {
        public async Task<GetbasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
