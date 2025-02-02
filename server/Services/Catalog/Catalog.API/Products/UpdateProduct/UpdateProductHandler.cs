
using Catalog.API.Products.CreateProduct;

namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string? Description, string ImageFile, decimal? Price) : ICommand<UpdateProductResult>;
    public record UpdateProductResult(bool IsSuccess);

    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is null")
                .Length(2, 150).WithMessage("Name must be between 2 and 150 characters.");

            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
    public class UpdateProductCommandHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand cmd, CancellationToken cancellationToken)
        {
            /*logger.LogInformation("UpdateProductCommand.Handle called with {@Command}", cmd);*/

            var product = await session.LoadAsync<Product>(cmd.Id, cancellationToken);
            if (product == null)
            {
                throw new ProductNotFoundException(cmd.Id);
            }

            if (!string.IsNullOrEmpty(cmd.Name))
            {
                product.Name = cmd.Name;
            }

            if (!string.IsNullOrEmpty(cmd.ImageFile))
            {
                product.ImageFile = cmd.ImageFile;
            }

            if (cmd.Price.HasValue)
            {
                product.Price = cmd.Price;
            }

            if (!string.IsNullOrEmpty(cmd.Description))
            {
                product.Description = cmd.Description;
            }

            if (cmd.Category != null && cmd.Category.Any())
            {
                product.Category = cmd.Category;
            }

            session.Update(product);
            await session.SaveChangesAsync(cancellationToken);
            return new UpdateProductResult(true);
        }
    }
}
