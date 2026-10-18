namespace NorthWind.Sales.Backend.Repositories.Repositories;

internal class QueriesRepository(INorthWindSalesQueriesDataContext context) : IQueriesRepository
{
    public async Task<decimal?> GetCustomerCurrentBalance(string customerId)
    {
        var queryable = context.Customers.Where(c => c.Id == customerId).Select(c => new { c.CurrentBalance });
        var result = await context.FirstOrDefaultAync(queryable);
        return result?.CurrentBalance;
    }
    public async Task<IEnumerable<ProductUnitsInStock>> GetProductsUnitsInStock(IEnumerable<int> productIds)
    {
        var queryable = context.Products.Where(p => productIds.Contains(p.Id)).Select(p => new ProductUnitsInStock(p.Id, p.UnitsInStock));
        return await context.ToListAsync(queryable);
    }
}
