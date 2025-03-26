using Buildingblocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Categories, string Description, string ImageFile, double Price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Create Product Entity from command data
            var product = new Product
            {
                Name = command.Name,
                Categories = command.Categories,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            //TODO
            // Save Product to Database

            // Return Product Id
            return new CreateProductResult(product.Id);
        }
    }
}
