using VoeAirlines.Contexts;
using VoeAirlines.Entities;
using VoeAirlines.ViewModels;

namespace VoeAirlines.Services;

public class ManutencaoService{

   private readonly VoeAirlinesContext _context;

    public ManutencaoService(VoeAirlinesContext context)
    {
        _context = context;
    }

    public ListarManutencaoViewModel AdicionarManutencao(AdicionarManutencaoViewModel dados){
          var manutencao = new Manutencao(dados.DataHora,dados.Tipo,dados.AeronaveId,dados.Observacoes);

          //EntityFramework -
          _context.Add(manutencao);
          _context.SaveChanges();
          return new ListarManutencaoViewModel(manutencao.Id,manutencao.DataHora,manutencao.Tipo,manutencao.AeronaveId,manutencao.Observacao);
    } 
    public IEnumerable<ListarManutencaoViewModel> ListarManutencoes(int aeronaveId){

        return _context.Manutencoes.Where(m=>m.AeronaveId == aeronaveId)
                                   .Select(m=> new ListarManutencaoViewModel(
                                            m.Id,
                                            m.DataHora,                                            
                                            m.Tipo,                                           
                                            m.AeronaveId,
                                            m.Observacao
                                        
                                   ));

    }
}