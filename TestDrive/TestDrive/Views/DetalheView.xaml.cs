using TestDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {
        

        public Veiculo Veiculo { get; set; }

        public string TextoFreioABS
        {
            get
            {
                return string.Format("Freio ABS - R$ {0}", Veiculo.FREIO_ABS);
            }
        }
        public string TextoArCond
        {
            get
            {
                return string.Format("Ar Condicionado - R$ {0}", Veiculo.AR_CONDICIONADO);
            }
        }
        public string TextoBancos
        {
            get
            {
                return string.Format("Bancos de Couro - R$ {0}", Veiculo.BANCOS_COURO);
            }
        }
        public string TextoMultimidia
        {
            get
            {
                return string.Format("Multimídia - R${0}", Veiculo.MULTIMIDIA);
            }
        }
        public string TextoRodas
        {
            get
            {
                return string.Format("Rodas de Liga - R$ {0}", Veiculo.RODAS_LIGA);
            }
        }

        public bool TemFreioAbs
        {
            get
            {
                return Veiculo.temFreioAbs;
            }
            set
            {
                Veiculo.temFreioAbs = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
                if (Veiculo.temFreioAbs)
                    DisplayAlert("Freio ABS", "Adicionado", "Ok");
                else
                    DisplayAlert("Freio ABS", "Removido", "Ok");
            }
        }
        
        public bool TemArCond
        {
            get
            {
                return Veiculo.temArCond;
            }
            set
            {
                Veiculo.temArCond = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
                if (Veiculo.temArCond)
                    DisplayAlert("Ar Condicionado", "Adicionado", "Ok");
                else
                    DisplayAlert("Ar Condicionado", "Removido", "Ok");
            }
        }
        
        public bool TemBancos
        {
            get
            {
                return Veiculo.temBancos;
            }
            set
            {
                Veiculo.temBancos = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
                if (Veiculo.temBancos)
                    DisplayAlert("Bancos de Couro", "Adicionado", "Ok");
                else
                    DisplayAlert("Bancos de Couro", "Removido", "Ok");
            }
        }
        
        public bool TemMultimidia
        {
            get
            {
                return Veiculo.temMultimidia;
            }
            set
            {
                Veiculo.temMultimidia = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
                if (Veiculo.temMultimidia)
                    DisplayAlert("Multimídia", "Adicionado", "Ok");
                else
                    DisplayAlert("Multimídia", "Removido", "Ok");
            }
        }
        
        public bool TemRodas
        {
            get
            {
                return Veiculo.temRodas;
            }
            set
            {
                Veiculo.temRodas = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
                if (Veiculo.temRodas)
                    DisplayAlert("Rodas de Liga", "Adicionado", "Ok");
                else
                    DisplayAlert("Rodas de Liga", "Removido", "Ok");
            }
        }

        public string ValorTotal
        {
            get
            {
                return Veiculo.PrecoTotalFormatado;
            }
        }
        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Veiculo = veiculo;
            this.BindingContext = this;
        }

        private void buttonProximo_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(this.Veiculo));
        }
    }
}