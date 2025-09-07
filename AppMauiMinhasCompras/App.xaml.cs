using AppMauiMinhasCompras.Helpers;

namespace AppMauiMinhasCompras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelper _db; //campo estático, membro privado

        public static SQLiteDatabaseHelper Db //para chegar ao campo estático _db,
                                              //criou-se a uma propriedade pública Db somente leitura
        {
            get
            {
                if (_db == null) //se tem objeto dentro do campo db
                {
                    string path = Path.Combine(//variavel path - prove informações do ambiente - nome do arquivo
                        Environment.GetFolderPath(//pega informações da pasta
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


        protected override Window CreateWindow(IActivationState activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Width = 400;
            window.Height = 600;

            return window;
        }
    }
}
