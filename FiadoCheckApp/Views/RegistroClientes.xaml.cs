using FiadoCheckApp.API;
using FiadoCheckApp.API.ResponseModels;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

namespace FiadoCheckApp.Views;

public partial class RegistroClientes : ContentPage, INotifyPropertyChanged
{
    private readonly HttpClient _client;
    private readonly RestService _restService;

    private string _mensaje;
    public string Mensaje
    {
        get => _mensaje;
        set
        {
            _mensaje = value;
            OnPropertyChanged();
        }
    }

    public RegistroClientes()
    {
        InitializeComponent();
        _client = new HttpClient();
        _restService = new RestService();
        BindingContext = this;
    }

    private async void OnRegistrarClienteClicked(object sender, EventArgs e)
    {
        var cliente = new ClientesResponse
        {
            nombreCliente = entryNombre.Text ?? "",
            direccion = entryDireccion.Text ?? "",
            telefono = entryTeléfono.Text ?? "",
            email = entryIdentificacion.Text ?? "", // Usa un campo real de email si lo tienes
            fechaRegistro = DateTime.Now
        };

        try
        {
            string jsonData = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync(Constants.BaseUrl + Constants.Clientes, content);

            if (response.IsSuccessStatusCode)
            {
                Mensaje = "Cliente registrado exitosamente.";
                await DisplayAlert("Éxito", Mensaje, "OK");

                // Limpiar campos
                entryNombre.Text = string.Empty;
                entryDireccion.Text = string.Empty;
                entryTeléfono.Text = string.Empty;
                entryIdentificacion.Text = string.Empty;
            }
            else
            {
                Mensaje = "Error al registrar el cliente.";
                await DisplayAlert("Error", Mensaje, "OK");
            }
        }
        catch (Exception ex)
        {
            Mensaje = $"Error de red: {ex.Message}";
            await DisplayAlert("Error", Mensaje, "OK");
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
    