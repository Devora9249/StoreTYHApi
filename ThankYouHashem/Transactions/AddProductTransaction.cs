using BooksApi.Data;
using ThankYouHashem.Data;
using ThankYouHashem.Dto;
using ThankYouHashem.Repository;

namespace ThankYouHashem.Transactions
{
    public class AddProductTransaction
    {
        private readonly ProductRepository _repository = new();
        StoreContext context = LibraryContextFactory.CreateContext();


        public int AddProductIfActiveExists(ProductDto dto)
        {
            using var transaction = context.Database.BeginTransaction();

            try
            {
                int activeCount = _repository.GetNonDeletedCount();

                //רק אם קיימים מוצרים פעילים — נוסיף מוצר חדש
                if (activeCount > 0)
                {
                    int newProductId = _repository.CreateProductByProc(dto);

                    transaction.Commit();
                    return newProductId;
                }
                else
                {
                    transaction.Rollback();
                    return -1;
                }
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

    }
}
