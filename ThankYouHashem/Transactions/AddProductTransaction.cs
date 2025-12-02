using ThankYouHashem.Data;
using ThankYouHashem.Dto;
using ThankYouHashem.Repository;

namespace ThankYouHashem.Transactions
{
    public class AddProductTransaction
    {
        private readonly StoreContext _context;
        private readonly ProductRepository _repository;

        public AddProductTransaction(StoreContext context, ProductRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        public int AddProductIfActiveExists(ProductDto dto)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                int activeCount = _repository.GetNonDeletedCount();

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
