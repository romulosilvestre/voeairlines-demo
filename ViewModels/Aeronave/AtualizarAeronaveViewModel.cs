using VoeAirlines.Entities.Enums;


namespace VoeAirlines.ViewModels;
public class AtualizarAeronaveViewModel
{
    public AtualizarAeronaveViewModel(int id, string fabricante, string modelo, string codigo,TipoAeronave tipo)
    {
        Id = id;
        Fabricante = fabricante;
        Modelo = modelo;
        Codigo = codigo;
        Tipo = tipo;
    }

    public int Id { get; set; }
    public string Fabricante { get; set; }

    public string Modelo { get; set; }
    public string Codigo { get; set; }

    public TipoAeronave Tipo { get; set; }
}