//ID, CODIGO, MODELO
//não precisa do fabricante.
using VoeAirlines.Entities.Enums;
public class ListarAeronaveViewModel{
    public ListarAeronaveViewModel(int id,string modelo,TipoAeronave tipo)
    {
        Id = id;
        Modelo = modelo;
        Tipo = tipo;
    }

    public int Id { get; set; }
    public string Modelo { get; set; }    
    public TipoAeronave Tipo { get; set; }

     


}