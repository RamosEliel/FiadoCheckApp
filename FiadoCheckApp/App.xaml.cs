namespace FiadoCheckApp;
using FiadoCheckApp.Views;

    public partial class App : Application
    {

    public static int UserID { get; set; }
    public static int Userrol { get; set; }

    public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginView());
        }
    }

