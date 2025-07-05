using MauiFirebaseApp.Models;
using MauiFirebaseApp.Helper;

namespace MauiFirebaseApp.Views;

public partial class SearchProductPage : ContentPage
{

	FirebaseHelper firebaseHelper = new FirebaseHelper();

	public SearchProductPage()
	{
		InitializeComponent();
	}

	private async void OnSearchProductClicked(object sender, EventArgs e)
	{
		string searchTermn = SearchEntry.Text;
		var productos = await firebaseHelper.GetAllProductos();
		var filteredProductos = productos.Where(p => p.Nombre.Contains(searchTermn, StringComparison.OrdinalIgnoreCase)).ToList();

		ResultListView.ItemsSource = filteredProductos;
	}
}