using System.Collections.ObjectModel;
using FiadoCheckApp.API;
using FiadoCheckApp.API.ResponseModels;
using Newtonsoft.Json;

namespace FiadoCheckApp.Views;

public partial class ConsultarEstadoMora : ContentPage
{
    private readonly RestService _restService;

    public ConsultarEstadoMora()
	{	
		InitializeComponent();
		_restService = new RestService();

        this.Appearing += async (sender, e) =>
        {

            Loader.IsVisible = true;

            try
            {
                string response = await _restService.GetResource(Constants.BaseUrl + Constants.Deudas);

                List<DeudasResponse> Deudas = JsonConvert.DeserializeObject<List<DeudasResponse>>(response)!;

                ObservableCollection<DeudasResponse> DeudasCollection = new ObservableCollection<DeudasResponse>(Deudas);

                BindingContext = DeudasCollection;

                Loader.IsVisible = false;

                foreach (DeudasResponse table in DeudasCollection)
                {
                    switch (table.estadoDeuda)
                    {
                        case "Vencido":
                            table.color = Color.FromArgb("#FF0000");
                            break;
                        case "Pendiente":
                            table.color = Color.FromArgb("#FFFF00");
                            break;
                        case "Al dia":
                            table.color = Color.FromArgb("#008000");
                            break;
                    }
                  }
                }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }

        };
    }

}