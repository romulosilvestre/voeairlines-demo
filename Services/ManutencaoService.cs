using System.Text;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.EntityFrameworkCore;
using VoeAirlines.Contexts;
using VoeAirlines.Entities;
using VoeAirlines.ViewModels;

namespace VoeAirlines.Services;

public class ManutencaoService{

    private readonly VoeAirlinesContext _context;
    StringBuilder builder = new StringBuilder();
    private readonly IConverter _converter;

    public ManutencaoService(VoeAirlinesContext context,IConverter converter)
    {
        _context = context;
        _converter = converter;
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
    public byte[]? GerarFichaManutencao(int id){
        var manutencao = _context.Manutencoes.Include(m=>m.Aeronave)
                                              .FirstOrDefault(m=>m.Id==id);
        if(manutencao!=null){
          var t ="preventiva";
          if(manutencao.Tipo == 0){
            t="corretiva";
          }
          //StringBuilder
         
          builder.Append($"<h1 style='text-align:center'>Ficha de Manutenção:{manutencao.Id.ToString().PadLeft(10,'0')}</h1>")
                 .Append($"<hr>")
                 .Append($"<p>Aeronave: {manutencao.Aeronave.Modelo} </p>")
                 .Append($"<p>Tipo Manutenção: {t}</p>")
                 .Append($"<p>Data: {manutencao.DataHora}</p>")
                 .Append($"<p>Observação: {manutencao.Observacao}</p>");
        
        var doc = new HtmlToPdfDocument()
        {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = builder.ToString(),
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
         };
        return _converter.Convert(doc);
        }
        return null;
    }
}