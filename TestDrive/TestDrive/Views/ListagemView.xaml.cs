using Xamarin.Forms;
using TestDrive.Models;
using TestDrive.ViewModel;

namespace TestDrive.Views
{

    public partial class ListagemView : ContentPage
    {
        public ListagemView()
        {
            InitializeComponent();
            this.ViewModel = new ListagemViewModel();
            this.BindingContext = this.ViewModel;
        }

        ListagemViewModel ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = value; }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado",
                (msg) =>
                {
                    Navigation.PushAsync(new DetalheView(msg));
                });

            await this.ViewModel.GetVeiculos();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}