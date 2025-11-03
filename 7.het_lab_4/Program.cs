using Microsoft.EntityFrameworkCore;

namespace _7.het_lab_4
{
    // DBFirst: adatbazis alapjan keszul el a kod
    // CodeFirst: kod alapjan keszul el az adatbazis

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public List<Book> Books { get; set; } = new();
    }
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }

    public class AppDbContext : DbContext //dbcontext: manage nuget packages -> Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.InMemory
    {
        // táblák:
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Book> Books => Set<Book>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("demo"); // adatbazis neve
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) // ha nem kovetjuk az id-s konvenciot (AuthorId = john.Id, Author = john)
        {
            modelBuilder.Entity<Book>( e =>
            e.HasOne(b => b.Author) // egy konyvnek egy szerzoje van
            .WithMany(a => a.Books) // egy szerzonak tobb konyve is lehet
            .HasForeignKey(b => b.AuthorId) // foreign key
            .IsRequired() // nem lehet null
            );
        }
    }
    

    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new AppDbContext();

            db.Database.EnsureCreated(); // ha nem letezik az adatbazis, akkor letrehozza

            if (!db.Authors.Any()) // van e mar adat az Authors tablaban (legalabb 1)
            {
                var john = new Author { Name = "John Doe" };
                var jane = new Author { Name = "Jane Smith" };
                var lukas = new Author { Name = "Lukas Brown" };
                var adam = new Author { Name = "Adam White" };

                john.Books.Add(new Book { Title = "C# Basics" });
                john.Books.Add(new Book { Title = "ASP.NET Core", AuthorId = john.Id, Author = john}); // AuthorId = john.Id, Author = john automatikusan kitoltodik (nem kell kiirni)
                jane.Books.Add(new Book { Title = "C beginner" });
                jane.Books.Add(new Book { Title = "Entity Framework Core" });
                jane.Books.Add(new Book { Title = "LINQ in Action" });
                lukas.Books.Add(new Book { Title = "Java Basics" });
                lukas.Books.Add(new Book { Title = "Spring Framework" });
                adam.Books.Add(new Book { Title = "Python for Data Science" });

                db.Authors.AddRange(john, jane, lukas, adam);
                db.SaveChanges(); // elmenti az adatokat az adatbazisba
            }

            var authors = db.Authors.Where(a => a.Books.Count() == 3); // akinek 3 konyve van
        }
    }
}
