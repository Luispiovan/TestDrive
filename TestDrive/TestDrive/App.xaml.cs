using TestDrive.Views;
using Xamarin.Forms;

namespace TestDrive
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<Usuario>(this, "SucessoLogin",
                (usuario) =>
                {
                    MainPage = new NavigationPage(new ListagemView());
                });
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
