using Project0.BusinessLogic;
using Project0.DataAccess.Entities;
using System.Linq;

namespace Project0.DataAccess
{
    public class ProductData
    {
        public static BusinessProduct GetProductWithId(int pId)
        {
            using var context = new TThreeTeasContext(SQLOptions.options);

            Product product = context.Product.Where(p => p.Id == pId).FirstOrDefault();
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
