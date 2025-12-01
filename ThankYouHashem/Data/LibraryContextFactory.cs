using Microsoft.EntityFrameworkCore;
using ThankYouHashem.Data;

namespace BooksApi.Data
{
    public class LibraryContextFactory
    {
        //private const string ConnectionString = "Server=DESKTOP-1VUANBN;DataBase=TYH;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;";
        private const string ConnectionString = "Server=Srv2\\pupils;DataBase=215967852TYH;Integrated Security=SSPI;Persist Security Info=False;TrustServerCertificate=True;";
        public static StoreContext CreateContext()
        {
            var optionsBuilder=new DbContextOptionsBuilder<StoreContext>();
            optionsBuilder.UseSqlServer(ConnectionString);
            return new StoreContext(optionsBuilder.Options);
        }
    }
}
