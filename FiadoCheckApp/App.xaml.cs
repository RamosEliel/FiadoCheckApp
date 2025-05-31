namespace FiadoCheckApp;
using FiadoCheckApp.Views;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ConsultarEstadoMora());
        }
    }

