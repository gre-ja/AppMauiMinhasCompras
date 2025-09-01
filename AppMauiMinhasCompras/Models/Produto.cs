using SQLite;  // só aparece caso foi instalado o plug-in

namespace AppMauiMinhasCompras.Models
{
    public class Produto 
    {
        [PrimaryKey, AutoIncrement] //anotation - vem do SQLite

        //propriedades do aplicativo
        public int Id { get; set; }        
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
        public double Total { get => Quantidade * Preco; }

    }
}
