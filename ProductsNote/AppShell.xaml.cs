namespace ProductsNote;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(Views.ProductPage), typeof(Views.ProductPage));
    }
}
