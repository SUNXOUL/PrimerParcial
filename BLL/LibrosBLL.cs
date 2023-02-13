using Microsoft.EntityFrameworkCore;
public class LibrosBLL
{
    public Contexto Context{get;set;}

    public LibrosBLL(Contexto contexto)
    {
        this.Context=contexto;
    }

    public bool Insertar(Libro libro)
    {
        Context.Add(libro);
        return Context.SaveChanges() > 0;
    }

    public bool Modificar(Libro libro)
    {
        Context.Entry(libro).State =EntityState.Modified;
        int cambios =Context.SaveChanges();
        Context.Entry(libro).State =EntityState.Detached;
        return cambios >0;
    }

    public bool Existe(int LibroId)
    {
        return Context.Libros.Any(o=> o.LibroId == LibroId);
    }

    public bool Guardar( Libro libro)
    {
        if(Existe(libro.LibroId))
        {
            return Modificar(libro);
        }
        else
        {
            return Insertar(libro);
        }
    }

    public Libro? Buscar(int LibroId)
    {
        return Context.Libros.Where(o=>o.LibroId==LibroId).AsNoTracking().SingleOrDefault();
    }

    public bool Eliminar(Libro libro)
    {
        Context.Entry(libro).State =EntityState.Deleted;
        int cambios =Context.SaveChanges();
        Context.Entry(libro).State =EntityState.Detached;
        Context.Database.ExecuteSql($"DELETE FROM Libros WHERE Libro.LibroId == {libro.LibroId}");
        return cambios>0;
    }
}