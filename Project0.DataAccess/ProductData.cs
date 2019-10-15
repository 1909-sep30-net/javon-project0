using Project0.BusinessLogic;
using Project0.DataAccess.Entities;
using System.Linq;
using Serilog;

namespace Project0.DataAccess
{
    /// <summary>
    /// DataAccess static class for retrieving and updating the Product objects in the database.
    /// </summary>
    public class ProductData
    {
        /// <summary>
        /// Retrieves the product with the given id
        /// </summary>
        /// <param name="productId">The id of the product</param>
        /// <returns>The BusinessProduct with the given id</returns>
        public static BusinessProduct GetProductWithId(int productId)
        {
            Log.Information($"Called the Data Access method to get the product with product id {productId}");
            using var context = new TThreeTeasContext(SQLOptions.options);

            Product product = context.Product.Where(p => p.Id == productId).FirstOrDefault();
            if (product is null)
            {
                return null;
            }

            BusinessProduct bProduct = new BusinessProduct()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            return bProduct;
        }
    }
}
