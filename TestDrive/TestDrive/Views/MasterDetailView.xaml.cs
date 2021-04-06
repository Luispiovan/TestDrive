using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Views
{
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
    }
}