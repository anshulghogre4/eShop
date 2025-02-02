﻿
namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Categaory) : IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);

    internal class GetProductByCategoryQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
          /*  logger.LogInformation("GetProductByCategoryQueryHandler called with {@Query}", query);*/
            var products = await session.Query<Product>().Where(p => p.Category.Contains(query.Categaory)).ToListAsync(cancellationToken);

            return new GetProductByCategoryResult(products);
        }
    }
}
