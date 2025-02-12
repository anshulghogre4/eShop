﻿





namespace Basket.API.Data
{
    public class BasketRepository(IDocumentSession session) : IBasketRepository
    {
        public Task<bool> DeleteBasketAsync(string userName, CancellationToken cancellationToken = default)
        {
            session.Delete(userName);
            return Task.FromResult(true);
        }

        public async Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken = default)
        {
            var basket = await session.LoadAsync<ShoppingCart>(userName, cancellationToken);

            return basket is null ? throw new BasketNotFoundException("Basket not found") : basket;
        }

        public async Task<ShoppingCart> StoreBasketAsync(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            session.Store(basket);
            await session.SaveChangesAsync(cancellationToken);
            return basket;
        }
    }
}
