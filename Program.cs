using MusicStore;

List<Album> albumes = new List<Album>();
albumes.Add(new Album("Master of Puppets",       "Metallica",       1986, true));
albumes.Add(new Album("Thriller",                "Michael Jackson", 1982, false));
albumes.Add(new Album("...And Justice for All",  "Metallica",       1988, true));


Console.WriteLine("Todos los albunes: ");
foreach (Album a in albumes)
{
    Console.WriteLine(a.ToString());
}


Console.WriteLine("\nÁLBUMES DE METALLICA: ");
foreach (Album a in albumes)
{
    if (a.getArtista().Contains("Metallica"))
    {
        Console.WriteLine(a.ToString());
    }
}

Console.WriteLine("\nFECHA DE REGISTRO: ");
Console.WriteLine("Fecha actual: " + DateTime.Now.ToShortDateString());

string ruta = "albumes.txt";
GuardarAlbums(albumes, ruta);
Console.WriteLine($"\nÁlbumes guardados en '{ruta}'");

Console.WriteLine("\nalbunes insertados: ");

GestorBD gestor = new GestorBD();

foreach (Album a in albumes)
{
    gestor.Insertar(a);
    Console.WriteLine($"Insertado: {a}");
}

Console.WriteLine("\nleer los albunes: ");
List<Album> albumesBD = gestor.ObtenerTodos();
foreach (Album a in albumesBD)
{
    Console.WriteLine(a.ToString());
}
static void GuardarAlbums(List<Album> lista, string ruta)
{
    using StreamWriter sw = new StreamWriter(ruta);
    foreach (Album a in lista)
    { 
        sw.WriteLine($"{a.getTitulo()};{a.getArtista()};{a.getAnyo()};{a.isDisponible()}");
    }
}
