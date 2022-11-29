
LinqQueries queries = new LinqQueries();

//toda la coleccion
//ImprimirValores(queries.TodaLaColeccion());

//libros despues del 2000
//ImprimirValores(queries.LibrosDespuesDel2000());

//libros con mas de 250paginas y contiene la palabra action en el titulo
//ImprimirValores(queries.LibrosConActionYmasDe250Paginas());

//todos los libros tienen status
//Console.WriteLine($"Todos los librso tienen status? - {queries.TodosLosLibrosTienenEstatus()}");

//algun libro publicado en 2005
Console.WriteLine($"Algun libro publicado en 2005? - {queries.AlmenosUnLibroPublicadoEn2005()}");

void ImprimirValores(IEnumerable<Book> listadeLibros)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo","N. Paginas","Fecha publicacion");

    foreach (var item in listadeLibros)
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.ToShortDateString());
    }
}
