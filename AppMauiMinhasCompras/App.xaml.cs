using AppMauiMinhasCompras.Helpers;

namespace AppMauiMinhasCompras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db; //_db campo

        public static SQLiteDatabaseHelper Db //DB leitura
        {
            get
            {
                if(_db == null) //se tem objeto dentro do campo db
                {
                    string path = Path.Combine(//variavel path - prove informações do ambiente - nome do arquivo
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");

                    _db = new SQLiteDatabaseHelper(path);
                }
                return _db;//se não houver, instancia e retorna no campo db
            }

        }
       
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            //definindo a pagina inicial -> listaproduto e que haverá dentro desta páginas de navegação 
            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}
