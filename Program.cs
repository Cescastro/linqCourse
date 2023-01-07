
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
//Console.WriteLine($"La cantidad de libros que tienen entre 200 y 500 son? - {queries.CountLibrosConPaginasEntre200y500()}");

// Fecha de publicacion menor
//Console.WriteLine($"la fecha de publicacion mas antigua es  - {queries.FechaDePublicacionMenos()}");

// la mayor cantidad de pagians
//Console.WriteLine($"el libro con mayor cantidad de paginas tiene  - {queries.MayorCantidadDePaginas()}");

// el promedio de caracteres del titulo los libros
//Console.WriteLine($"el promedio de caracteres de los libros es  - {queries.PromedioCaracteresTitulo()}");

//libros publicados despues del 2000 agrupados por anno
//ImprimirGrupo(queries.LibrosDespuesDel2000AgrupadosPorAnno());

//libros publicados despues del 2000 agrupados por anno
//ImprimirGrupoPorCategoria(queries.LibrosDespuesDel2000AgrupadosPorCategoria());

//Diccionario de libros agrupado por primera letra del titulo

//var diccionarioLookup = queries.DiccionarioDeLibrosPorLetra();
//ImprimirDiccionario(diccionarioLookup, 'A');

//libros filtrados con join

ImprimirValores(queries.LibrosDespues200ConMasDe500Paginas());


void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
{
   Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
   foreach(var item in ListadeLibros[letra])
   {
         Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
   }
}

void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> ListadeLibros)
{
    foreach(var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
        }
    }
}

void ImprimirGrupoPorCategoria(IEnumerable<IGrouping<string,Book>> ListadeLibros)
{
    foreach(var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
        }
    }
}

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
