namespace ProductsNote.Views;

public partial class AllProductsPage : ContentPage
{
    public AllProductsPage()
    {
        InitializeComponent();

        BindingContext = new Models.AllProducts();
    }

    protected override void OnAppearing()
    {
        ((Models.AllProducts)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ProductPage));
    }

    private async void productsCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var product = (Models.Product)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(ProductPage)}?{nameof(ProductPage.ItemId)}={product.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}