using FiadoCheckApp.Views;
using FiadoCheckApp.API;
using FiadoCheckApp.API.ResponseModels;

namespace FiadoCheckApp
{
    public partial class LoginView : ContentPage
    {

    private readonly RestService _restService;
    Auth authService = new Auth();

    public LoginView()
    {
        InitializeComponent();
        _restService = new RestService();
    }

    private async void Login(object sender, EventArgs e)
    {
        Loader.IsVisible = true;

        try
        {
            if (string.IsNullOrEmpty(nombreUsuario.Text) || string.IsNullOrEmpty(Password.Text))
            {
                await DisplayAlert("Campos vacíos", "Por favor, rellene todos los campos", "OK");
                Loader.IsVisible = false;
                return;
            }

            UsuariosResponse result = await authService.AuthorizeAsync(nombreUsuario.Text, Password.Text);

            if (result != null && result.Message == "Login successful")
            {
                App.UserID = result.idUsuario;

                await Navigation.PushAsync(new ConsultarEstadoMora());
            }
            else
            {
                Extra.ShowToast("Nombre o contraseña incorrectos.");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error interno", ex.Message, "OK");
        }
        finally
        {
            Loader.IsVisible = false;
        }
    }

    private void OpenRegisterView(object sender, EventArgs e)
    {
        Navigation.PushAsync(new RegistroClientes());
    }

    protected override bool OnBackButtonPressed()
    {
        MainThread.BeginInvokeOnMainThread(async () =>
        {

            bool result = await DisplayAlert("Salir", "¿Deseas salir de la aplicación?", "Sí", "No");

            if (result)
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        });

            return true;
    }


    private async void OnLoginClicked(object sender, EventArgs e)
        {
             Application.Current.MainPage = new AppShell(); 
        }




}

}