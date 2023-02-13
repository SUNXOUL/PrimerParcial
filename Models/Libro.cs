using System.ComponentModel.DataAnnotations;

public class Libro
{
    [Key]
    public int LibroId {get;set;}

    public string Titulo{get;set;}
    public double Precio {get;set;}
}