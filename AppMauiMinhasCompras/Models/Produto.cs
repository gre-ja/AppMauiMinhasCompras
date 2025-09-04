using SQLite;  // só aparece caso foi instalado o plug-in

namespace AppMauiMinhasCompras.Models
{
    public class Produto 
    {
        string _descricao;
        double _quantidade;
        double _preco;

        [PrimaryKey, AutoIncrement] //anotation - vem do SQLite

        //propriedades do aplicativo
        public int Id { get; set; }        
        public string Descricao 
        { 
            get => _descricao;
            set
            {
                if(value == null)
                {
                    throw new Exception("Por favor, preencha a descrição");
                }
                _descricao = value;
            }
        }
        public double Quantidade 
        { 
            get => _quantidade;
            set
            {
                if(value == 0)
                {
                    throw new Exception("Por favor, preencha a quantidade");
                }
            }
        }
        public double Preco 
        { 
            get => _preco; 
            set
            {
                if(value == 0)
                {
                    throw new Exception("Por favor, preencha o preço");
                }
            } 
        }
        public double Total { get => Quantidade * Preco; }

    }
}
