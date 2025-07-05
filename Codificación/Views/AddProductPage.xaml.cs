using MauiFirebaseApp.Models;
using MauiFirebaseApp.Helper;

namespace MauiFirebaseApp.Views;

public partial class AddProductPage : ContentPage
{

	   FirebaseHelper firebaseHelper = new FirebaseHelper();


	public AddProductPage()
	{
		InitializeComponent();
	}

	private async void OnAddProductClicked(object sender, EventArgs e)
	{
		var producto = new Producto
		{
			Nombre = NombreEntry.Text,
			Descripcion = DescripcionEntry.Text,
			Precio = decimal.Parse(PrecioEntry.Text)


		};

		await firebaseHelper.AddProducto(producto);
		await DisplayAlert("Exito", "Producto Agregado", "OK");
		await Navigation.PopAsync();
	}




}