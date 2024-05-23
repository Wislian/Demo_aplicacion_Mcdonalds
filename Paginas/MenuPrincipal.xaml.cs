namespace TimeTravel.Paginas;

public partial class MenuPrincipal : ContentPage
{
    public MenuPrincipal()
    {
        InitializeComponent();
    }

    private async void OnPersonalizaClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Personaliza");
    }
}
