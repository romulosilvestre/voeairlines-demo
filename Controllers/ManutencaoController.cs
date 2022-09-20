using VoeAirlines.Services; //importando os serviços
using VoeAirlines.ViewModels; //importando os ViewModels
using Microsoft.AspNetCore.Mvc; //importando o AspNet Core - ControllerBase
namespace VoeAirlines.Controllers;
//Core?  - uma versão que pode ser utilizada Multiplataforma
//o consumo da API é pela rota
[Route("api/manutencoes")] 
//Lembrando que o AspNetCore é utilizado também para criar sites e sistemas web
[ApiController]
public class ManutencaoController:ControllerBase{  
     private readonly ManutencaoService _manutencaoService;
    public ManutencaoController(ManutencaoService manutencaoService)
    {
        _manutencaoService = manutencaoService;
    }    
    [HttpPost]
    public IActionResult AdicionarManutencao(AdicionarManutencaoViewModel dados){
        var manutencao = _manutencaoService.AdicionarManutencao(dados);
        //200 - tudo ok geralzão
        //201 - tudo ok adicionou
        return Ok(manutencao);
    }

    [HttpGet]
    public IActionResult ListarManutencoes(int aeronaveId){
        return Ok(_manutencaoService.ListarManutencoes(aeronaveId));
    }

    [HttpGet("{id}/ficha")]
    public IActionResult GerarFichaManutencao(int id){
        var conteudo = _manutencaoService.GerarFichaManutencao(id);
        if(conteudo != null)
           return File(conteudo,"application/pdf");

        return NotFound();
    }

}


