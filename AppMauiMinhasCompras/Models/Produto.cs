using SQLite;  // só aparece caso foi instalado o plug-in

namespace AppMauiMinhasCompras.Models
{
    public class Produto 
    {
        string _descricao;//validação da inserção do produto
        double _quantidade;
        double _preco;

        [PrimaryKey, AutoIncrement] //anotation - vem do SQLite

        //propriedades do aplicativo
        public int Id { get; set; }        
        public string Descricao 
        { 
            get => _descricao;//retorna a descriçao
            set
            {
                if(value == null)//se o valor for igual a nulo, aparece a mensagem pra preencher
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
                if (value == 0)//se o valor for igual a nulo, aparece a mensagem pra preencher
                {
                    throw new Exception("Por favor, preencha a quantidade");
                }
                _quantidade = value;
            }

        }
        public double Preco 
        { 
            get =>_preco;
            set
            {
                if (value == 0)//se o valor for igual a nulo, aparece a mensagem pra preencher
                {
                    throw new Exception("Por favor, preencha o preço");
                }
                _preco = value;
            }
        }
        public double Total { get => Quantidade * Preco; }//expressão lambda - get retorna o total

    }
}
