using MauiFirebaseApp.Models;
using MauiFirebaseApp.Helper;

namespace MauiFirebaseApp.Views;

public partial class ListProductPage : ContentPage
{

	FirebaseHelper firebaseHelper = new FirebaseHelper();

	public ListProductPage()
	{
		InitializeComponent();
	}

	private async void LoadProduct()
	{
		var productos = await firebaseHelper.GetAllProductos();
		ProductsListView.ItemsSource = productos; 
	}


	private async void OnEditProductClicked(object sender, EventArgs e)
	{
		var button = sender as Button;
		var producto = button?.BindingContext as Producto;

		if (producto != null)
		{
			await Navigation.PushAsync(new EditProductPage(producto));
		}

	}



	private async void OnDeleteProductClicked(object sender, EventArgs e)
	{
		var button = sender as Button;
		var producto = button?.BindingContext as Producto;
		if (producto != null && !string.IsNullOrEmpty(producto.Id))
		{
			await firebaseHelper.DeleteProducto(producto.Id);
            await DisplayAlert("Exito", "Producto Eliminado", "OK");
			LoadProduct();
        }

		else
		{
			await DisplayAlert("Error", "No se pudo encontrar el Producto para eliminar.", "OK");
		}
    }



}