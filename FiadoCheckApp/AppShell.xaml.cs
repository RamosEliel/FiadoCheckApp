using FiadoCheckApp.Views;

namespace FiadoCheckApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("RegistroClientes", typeof(RegistroClientes));
            Routing.RegisterRoute("LoginView", typeof(LoginView));
        }
    }
}
