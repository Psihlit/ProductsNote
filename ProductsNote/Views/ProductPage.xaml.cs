namespace ProductsNote.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class ProductPage : ContentPage
{

    public string ItemId
    {
        set { LoadNote(value); }
    }
    public ProductPage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    /*void CheckBox1_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        string shop1 = $"{(e.Value ? "Магнит" : "")}";
    }

    void CheckBox2_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        string shop2 = $"{(e.Value ? "Пятёрочка" : "")}";
    }

    void CheckBox3_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        string shop3 = $"{(e.Value ? "Лента" : "")}";
    }*/

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        TextEditor.Text = $"Название продукта - {NameEditor.Text}" + Environment.NewLine + $"Группа продукта - {GroupPicker.SelectedItem}" + Environment.NewLine + $"Цена продукта - {PriceEditor.Text} руб."; 
        if (BindingContext is Models.Product product)
            File.WriteAllText(product.Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Product product)
        {
            // Delete the file.
            if (File.Exists(product.Filename))
                File.Delete(product.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadNote(string fileName)
    {
        Models.Product productModel = new Models.Product();
        productModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            productModel.Date = File.GetCreationTime(fileName);
            productModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = productModel;
    }
}