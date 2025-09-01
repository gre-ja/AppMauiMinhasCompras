using AppMauiMinhasCompras.Models;//definir models
using SQLite;

//SQLite não é banco de dados - não é seguro, serve p/app simples, é mais um API - similar arquivo de texto
//a partir do pacote nuget que foi instalado, permite usar instruções sql

namespace AppMauiMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn; //campo leitura, conexão assincrona - armazena a conexão com SQLite
        public SQLiteDatabaseHelper(string path) //path - nome do arquivo de texto
        { 
            _conn = new SQLiteAsyncConnection(path); //conn irá receber uma conexão com o path
            _conn.CreateTableAsync<Produto>().Wait();//instrução tabela produto, irá criar a tabela quando
                                                     //executar o app, caso não haja
        }
        public Task<int> Insert(Produto p) //p é o parametro
                                           //task usado quando retorna valor
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p) 
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";
                            //definir a inserção de dados na tabela - diretiva sql
            return _conn.QueryAsync<Produto>(//queryasync - onde será colocado/tabela
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id//parametros tem que ser em ordem
                );
        }

        public Task<int> Delete(int id) //para deletar apenas o id
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);//expressão lambda
        }      //seleciona a tabela,método delete -> todos itens=>onde item.id é igual id

        public Task<List<Produto>> GetAll() 
        {
            return _conn.Table<Produto>().ToListAsync();
        }
        
        public Task<List<Produto>> Search(string q) //q parametro de busca na tabela 
        {
            string sql = "SELECT * FROM Produto WHERE Descricao LIKE '%" + q + "%'";
                        //selecionar na tabela produto onde é similar ao que for colocado pra busca

            return _conn.QueryAsync<Produto>(sql);
        }

    }
}
