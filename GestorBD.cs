using MySql.Data.MySqlClient;

namespace ProyectoExamen;

public class GestorBD
{
    private string connectionString;
    private MySqlConnection connection;

    
    public GestorBD()
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        builder.Server   = "localhost";
        builder.UserID   = "root";
        builder.Password = "";
        builder.Database = "musicstore";

        connectionString = builder.ToString();
        connection = new MySqlConnection(connectionString);
    }

    
    public void Insertar(Album p)
    {
        connection.Open();

        string sql = "INSERT INTO album (titulo, artista, anyo, disponible) " +
                     "VALUES (@titulo, @artista, @anyo, @disponible)";

        MySqlCommand cmd = new MySqlCommand(sql, connection);
        cmd.Parameters.AddWithValue("@titulo",     p.getTitulo());
        cmd.Parameters.AddWithValue("@artista",    p.getArtista());
        cmd.Parameters.AddWithValue("@anyo",       p.getAnyo());
        cmd.Parameters.AddWithValue("@disponible", p.isDisponible());

        cmd.ExecuteNonQuery();
        connection.Close();
    }

 
    public List<Album> ObtenerTodos()
    {
        List<Album> lista = new List<Album>();
        connection.Open();

        string sql = "SELECT * FROM album";
        MySqlCommand    cmd    = new MySqlCommand(sql, connection);
        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            string titulo     = reader.GetString("titulo");
            string artista    = reader.GetString("artista");
            int    anyo       = reader.GetInt32("anyo");
            bool   disponible = reader.GetBoolean("disponible");

            lista.Add(new Album(titulo, artista, anyo, disponible));
        }      
        reader.Close();
        connection.Close();
        return lista;
    }
}
