using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> Options) : base(Options){}

    public DbSet<Libro> Libros {get;set;}
}