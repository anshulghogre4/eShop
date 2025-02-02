
using Catalog.API.Products.UpdateProduct;

namespace Catalog.API.Products.DeleteProduct
{   public record DeleteProductCommand(Guid Id) :ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);

    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
        }
    }


    internal class DeleteProductCommandHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand cmd, CancellationToken cancellationToken)
        {
           /* logger.LogInformation("DeleteProductCommandHandler.Handle called with {@Command}", cmd);*/
            session.Delete<Product>(cmd.Id);
            await session.SaveChangesAsync(cancellationToken);

            return new DeleteProductResult(true);

        }
    }
}
