using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace apiOXXO.Controllers;


[Route("[controller]")]

public class NivelesController : ControllerBase
{
    [HttpGet("GetNivel/{nivel}")]
    public Niveles GetNiveles(int nivel)
    {
        Niveles resnivel = new Niveles();

        string ConnectionString = "Server=127.0.0.1;Port=3306;Database=reto_oxxo;Uid=root";

        MySqlConnection conexion = new MySqlConnection(ConnectionString);

        conexion.Open();

        MySqlCommand cmd = new MySqlCommand("SELECT liga_nivel FROM niveles WHERE nivel = @nivel", conexion);
        cmd.Parameters.AddWithValue("@nivel", nivel);

        cmd.Prepare();

        using (var reader = cmd.ExecuteReader())
        {
            if (reader.Read())
            {
            
                resnivel.liga_nivel = reader["liga_nivel"].ToString();
             
            }
        }

        return resnivel;
    }   
}