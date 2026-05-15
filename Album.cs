namespace MusicStore;

public class Album
{
    
    private string titulo;
    private string artista;
    private int anyo;
    private bool disponible;


    public Album(string titulo, string artista, int anyo, bool disponible)
    {
        this.titulo = titulo;
        this.artista = artista;
        this.anyo = anyo;
        this.disponible = disponible;
    }

    
    public string getTitulo()     => titulo;
    public string getArtista()    => artista;
    public int    getAnyo()       => anyo;
    public bool   isDisponible()  => disponible;

    
    public override string ToString()
    {
        return $"{titulo} - {artista} ({anyo})";
    }
}
