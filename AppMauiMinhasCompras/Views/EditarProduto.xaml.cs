using AppMauiMinhasCompras.Models;

namespace AppMauiMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
	public EditarProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto produto_anexado = BindingContext as Produto;
            //BindingContext é o elemento que fornece os dados que a tela irá usar
            //no caso acima o BindingContext pega o produto que está selecionado p/editar

            Produto p = new Produto
            {
                Id = produto_anexado.Id, //acesso ao que foi selecionado
                Descricao = txt_descricao.Text, 
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            await App.Db.Update(p);//atualiza o sqlite
            await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
            await Navigation.PopAsync();//retorna a página principal ao executar a tarefa
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}