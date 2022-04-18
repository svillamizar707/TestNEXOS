
namespace BooksApi.DataAcces
{
    using BooksApi.Entities;
    using Oracle.ManagedDataAccess.Client;
    using System.Configuration;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class BooksApiContext : DbContext
    {
        public BooksApiContext() : base(EntitiesApiConnection(), true)
        {
            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("NEXOSTEST");

            modelBuilder.Entity<Book>()
            .HasRequired(x => x.Author)
            .WithMany(x => x.Books)
            .HasForeignKey(x => x.AuthorId);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static OracleConnection EntitiesApiConnection()
        {
            var cs = ConfigurationManager.ConnectionStrings["EntitiesApi"];
            OracleConnection ora_con = new OracleConnection(cs.ConnectionString);

         
            return ora_con;
        }       


    }
}
