//using Microsoft.EntityFrameworkCore;
//using ThankYouHashem.Data;

//namespace BooksApi.Data
//{
//    public class StoreContextFactory
//    {
//        private const string ConnectionString = "Server=localhost,1433;Database=216224360TYH;User Id=sa;Password=YourStrong@Pass123;TrustServerCertificate=True;";
//        //private const string ConnectionString = "Server=Srv2\\pupils;DataBase=215967852TYH;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;";
//        public static StoreContext CreateContext()
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
//            optionsBuilder.UseSqlServer(ConnectionString);
//            return new StoreContext(optionsBuilder.Options);
//        }
//    }
//}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ThankYouHashem.Data
{
    public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();

            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=216224360TYH;User Id=sa;Password=YourStrong@Pass123;TrustServerCertificate=True;"
            );

            return new StoreContext(optionsBuilder.Options);
        }
    }
}



