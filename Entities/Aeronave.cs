namespace VoeAirlines.Entities;
using VoeAirlines.Entities.Enums;
public class Aeronave{
        public Aeronave(string fabricante, string modelo, string codigo,TipoAeronave tipo)
        {
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

        public ICollection<Manutencao> Manutencoes { get; set; }=null!;
        public ICollection<Voo> Voos { get; set; }=null!;





}

