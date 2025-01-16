
namespace Catalog.API.Products.DeleteProduct
{   public record DeleteProductCommand(Guid Id) :ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);

    internal class DeleteProductCommandHandler(IDocumentSession session, ILogger<DeleteProductCommandHandler> logger) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand cmd, CancellationToken cancellationToken)
        {
            logger.LogInformation("DeleteProductCommandHandler.Handle called with {@Command}", cmd);
            session.Delete<Product>(cmd.Id);
            await session.SaveChangesAsync(cancellationToken);

            return new DeleteProductResult(true);

        }
    }
}
