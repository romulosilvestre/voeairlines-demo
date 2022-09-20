using Microsoft.AspNetCore.Mvc;
using VoeAirlines.Services;
using VoeAirlines.ViewModels;

namespace VoeAirlines.Controllers;
[Route("api/aeronaves")]
[ApiController]
public class AeronaveController: ControllerBase{
    
    private readonly AeronaveService _aeronaveService;

    public AeronaveController(AeronaveService aeronaveService)
    {
        _aeronaveService = aeronaveService;
    }
    [HttpPost]
    public IActionResult AdicionarAeronave(AdicionarAeronaveViewModel dados){
       
       var aeronave = _aeronaveService.AdicionarAeronave(dados);
       return Ok(aeronave);

    }
    [HttpGet]
    public IActionResult ListarAeronaves(){
        return Ok(_aeronaveService.ListarAeronaves());
    }
}