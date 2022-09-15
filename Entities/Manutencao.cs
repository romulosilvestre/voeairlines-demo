namespace VoeAirlines.Entities;
using VoeAirlines.Entities.Enums;


public class Manutencao
{
    public Manutencao(DateTime dataHora,TipoManutencao tipo,int aeronaveId, string? observacao=null )
    {

        DataHora = dataHora;
        Tipo = tipo;
        Observacao = observacao;
        AeronaveId = aeronaveId;
    }

    //Gera Construtor desses aqui
    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public string? Observacao { get; set; }
    public TipoManutencao Tipo{get;set;}
    public int AeronaveId { get; set; }
    //Não gera construtor
    public Aeronave Aeronave { get; set; } = null!;




}

