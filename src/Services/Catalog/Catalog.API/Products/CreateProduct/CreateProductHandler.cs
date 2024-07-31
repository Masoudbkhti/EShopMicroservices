
namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    :ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);


internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand,CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // Create product entity from command object
        var product = command.Adapt<Product>();
        
        //TODO
        // save to db
        session.Store(product);
        await session.SaveChangesAsync();
        // return result

        return new CreateProductResult(product.Id);
    }
}