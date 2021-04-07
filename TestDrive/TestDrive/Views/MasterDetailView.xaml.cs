using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Views
{
    [System.Obsolete]
    public partial class MasterDetailView : MasterDetailPage
    {
        private readonly Usuario usuario;

        public MasterDetailView(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.Master = new MasterView(usuario);
            this.Detail = new NavigationPage(new ListagemView(usuario));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Usuario>(this, "MeusAgendamentos",
                (usuario) =>
                {
                    this.Detail = new NavigationPage(new AgendamentosUsuarioView());
                    this.IsPresented = false;
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Usuario>(this, "MeusAgendamentos");
        }
    }
}