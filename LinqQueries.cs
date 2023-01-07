public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();
    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
            
        }
        
    }

    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }

    public IEnumerable<Book> LibrosDespuesDel2000()
    {
        //extension method
        //return librosCollection.Where(p=> p.PublishedDate.Year > 2000);

        //query expresion
        return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> LibrosConActionYmasDe250Paginas()
    {
        //query expresion
        //return from l in librosCollection where (l.PageCount > 250 && l.Title.Contains("Action")) select l;

        //extension method
        return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("Action"));   
    }

    public bool TodosLosLibrosTienenEstatus()
    {
        //Que todos cumplan la condicion
        return librosCollection.All(p=> p.Status != string.Empty);
    }

    public bool AlmenosUnLibroPublicadoEn2005()
    {
        //Que algunos cumplan la condicón
        return librosCollection.Any(p=> p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> LibrosConCategoriaPython()
    {     
        //extension method   
        return librosCollection.Where(p=> p.Categories.Contains("Python"));
    }

    public IEnumerable<Book> LibrosConCategoriaJavaOrberByAsc()
    {     
        //extension method   
        return librosCollection.Where(p=> p.Categories.Contains("Java")).OrderBy(q => q.Title);
    }

    public IEnumerable<Book> LibrosConMasDe450PaginasOrderByDesc()
    {     
        //extension method   
        return librosCollection.Where(p=> p.PageCount > 450).OrderByDescending(q => q.PageCount);
    }

    public IEnumerable<Book> Top3LibrosCategoriaJavaPublicadosMasReciente()
    {     
        //extension method   
        return librosCollection
            .Where(p=> p.Categories.Contains("Java"))                               
            .OrderByDescending(q => q.PublishedDate)
            .Take(3);
    }

    public IEnumerable<Book> TercerYCuartoLibroConMasDe400Paginas()
    {     
        //extension method   
        return librosCollection
            .Where(p=> p.PageCount > 400)
            .Take(4)
            .Skip(2);
    }

    public IEnumerable<Item> TresPrimeroLibrosDeLaColeccion()
    {
        return librosCollection
            .Take(3)
            .Select(p=> new Item(){
                Title = p.Title,
                PageCount = p.PageCount
            });
    }

    public int CountLibrosConPaginasEntre200y500()
    {
        return librosCollection           
            .Count(p=> p.PageCount >= 200 && p.PageCount <= 500);
    }

    public DateTime FechaDePublicacionMenos()
    {
        return librosCollection.Min(p=> p.PublishedDate);
    }

    public int MayorCantidadDePaginas()
    {
        return librosCollection.Max(p=> p.PageCount);
    }

    public double PromedioCaracteresTitulo()
    {
       return librosCollection.Average(p => p.Title.Length); 
    }

    public IEnumerable<IGrouping<int,Book>> LibrosDespuesDel2000AgrupadosPorAnno()
    {
        return librosCollection.Where(p=> p.PublishedDate.Year >= 2000)
            .GroupBy(p=> p.PublishedDate.Year);
    }

    public IEnumerable<IGrouping<string,Book>> LibrosDespuesDel2000AgrupadosPorCategoria()
    {
        return librosCollection.Where(p=> p.PublishedDate.Year >= 2000)
            .OrderBy(q=>q.PublishedDate)
            .GroupBy(p=> p.Categories[0]);
    }

    public ILookup<char,Book> DiccionarioDeLibrosPorLetra()
    {
        return librosCollection.ToLookup(p => p.Title[0], p=> p);
    }

    public IEnumerable<Book> LibrosDespues200ConMasDe500Paginas()
    {
        var librosDespues2005 = librosCollection.Where(p=>p.PublishedDate.Year > 2005);
        var libroMasDe500Pagns = librosCollection.Where(p=> p.PageCount > 500);

        return librosDespues2005.Join(libroMasDe500Pagns, p=> p.Title, q=> q.Title, (p,x)=> p);
    }


}