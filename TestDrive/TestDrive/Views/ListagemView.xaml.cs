using System.Collections.Generic;
using Xamarin.Forms;
using TestDrive.Models;

namespace TestDrive.Views
{

    public partial class ListagemView : ContentPage
    {

        public ListagemView()
        {
            InitializeComponent();
        }

        private void listViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item;
            Navigation.PushAsync(new DetalheView(veiculo));
        }
    }
}