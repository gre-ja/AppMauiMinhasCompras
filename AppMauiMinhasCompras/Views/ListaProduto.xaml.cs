using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AppMauiMinhasCompras.Models;

namespace AppMauiMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
	ObservableCollection<Produto>lista = new ObservableCollection<Produto>();
	//observablecollection tem tudo que a list generica tem, maior integração com interface grafica
	public ListaProduto()
	{
		InitializeComponent();

		lst_produtos.ItemsSource = lista;//listview e observablecollection unidas
	}

	protected async override void OnAppearing()
	//onappearing sempre chamado quando uma tela aparece, neste caso recarregar dados
	//vai no sqlite buscar na lista o produto e abastecer na observablecollection
	{
		try
		{
			lista.Clear();//correção da duplicação de dados ao inserir

			List<Produto> tmp = await App.Db.GetAll();//-- busca no SQLite a lista produto
			//lista criada de produto tmp/temporária pois não é possivel converter uma lista generica pra uma complexa diretamente

			tmp.ForEach(i => lista.Add(i));//-- observablecollection é abastecida

		}catch (Exception ex)
        {
			await DisplayAlert("Ops", ex.Message, "OK");

		}
	}
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Navigation.PushAsync(new Views.NovoProduto());//navegação de telas

		}catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "OK");
		}
    }
	private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)//método busca
	{
		try
		{
			string q = e.NewTextValue;//variavel q pega o valor digitado no placeholder

			lista.Clear();
			  
			List<Produto> tmp = await App.Db.Search(q);//-- busca no SQLite a lista produto
            //lista criada de produto tmp/temporária pois não é possivel converter implicitamente uma
			//lista generica pra uma observablecollection
            tmp.ForEach(i => lista.Add(i));//-- observablecollection é abastecida

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }

    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)//evento botão somar
    {
		double soma = lista.Sum(i => i.Total);//variavel acessa a coleção e soma todos os items pelo valor do total

		string msg = $"O total é {soma:C}";//variavel string, mensagem do total

		DisplayAlert("Total dos Produtos", msg, "OK");
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)//evento remover
    {
		try
		{
			MenuItem selecionado = sender as MenuItem;//converte a seleção(botão direito) para menuitem acessando o con

			Produto p = selecionado.BindingContext as Produto;//pega o dado que foi selecionado da listview
			bool confirm = await DisplayAlert("Tem certeza?", $"Remover {p.Descricao}?", "Sim", "Não");
			//valor booleano - dado que tem dois valores: true ou false 
			//no caso acima foi usado junto ao DisplayAlert como forma de confirmar sim ou não a exclusão

			if (confirm)
			{
				await App.Db.Delete(p.Id);
				lista.Remove(p);
			}

		}catch (Exception ex)
		{
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)//evento seleção
    {
		try 
		{
			Produto p = e.SelectedItem as Produto; //variavel produto = dado selecionado converto para produto p/editar
			Navigation.PushAsync(new Views.EditarProduto//vai pra tela de edição
			{
				BindingContext = p,//atualiza dado editado
			});

        }catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}//try e catch é o mecanismo que lida com possiveis "erros/exceções", com isso o programa não trava/fecha
//dentro do try é colocado o código que possivelmente pode gerar "erro"
//se houver erro no try, o código vai pro catch onde está a mensagem de "erro" e que este seja solucionado

//listview é um controle que serve pra mostrar lista de dados na tela