using Xamarin.Forms;
using TestDrive.Models;
using TestDrive.ViewModel;
using System;

namespace TestDrive.Views
{

    public partial class ListagemView : ContentPage
    {
        readonly Usuario usuario;

        public ListagemView(Usuario usuario)
        {
            InitializeComponent();
            this.ViewModel = new ListagemViewModel();
            this.usuario = usuario;
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
            AssinarMensagens();

            await this.ViewModel.GetVeiculos();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado",
                (veiculo) =>
                {
                    Navigation.PushAsync(new DetalheView(veiculo, usuario));
                });

            MessagingCenter.Subscribe<Exception>(this, "FalhaListagem",
               (msg) =>
               {
                   DisplayAlert("Erro", "Ocorreu um erro ao obter a listagem de veículos","OK");
               });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarAssinatura();
        }

        private void CancelarAssinatura()
        {
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagem");
        }
    }
}