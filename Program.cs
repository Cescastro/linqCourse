
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
//Console.WriteLine($"Algun libro publicado en 2005? - {queries.AlmenosUnLibroPublicadoEn2005()}");

//Libros de Python
//ImprimirValores(queries.LibrosConCategoriaPython());

//libros de java ordenados por titulo asc
//ImprimirValores(queries.LibrosConCategoriaJavaOrberByAsc());

//libros con mas de 250 paginas ordenados descendentemente
//ImprimirValores(queries.LibrosConMasDe450PaginasOrderByDesc());


//Top 3 de libros categoria java publicados recientemente
//ImprimirValores(queries.Top3LibrosCategoriaJavaPublicadosMasReciente());

// tercer y cuarto libro con mas de 400 pagias
//ImprimirValores(queries.TercerYCuartoLibroConMasDe400Paginas());

// 3 primero libros filtrados por select
//ImprimirValoresItem(queries.TresPrimeroLibrosDeLaColeccion());

// cantidad de libros paginas entre 200 y 500
Console.WriteLine($"La cantidad de libros que tienen entre 200 y 500 son? - {queries.CountLibrosConPaginasEntre200y500()}");


void ImprimirValores(IEnumerable<Book> listadeLibros)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo","N. Paginas","Fecha publicacion");

    foreach (var item in listadeLibros)
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.ToShortDateString());
    }
}

void ImprimirValoresItem(IEnumerable<Item> listadeItems)
{
    foreach (var item in listadeItems)
    {
        Console.WriteLine("{0,-60} {1, 15}",item.Title,item.PageCount);
    }
}
