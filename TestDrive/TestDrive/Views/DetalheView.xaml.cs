using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {
        private const int FREIO_ABS = 800;
        private const int AR_CONDICIONADO = 1500;
        private const int BANCOS_COURO = 900;
        private const int MULTIMIDIA = 700;
        private const int RODAS_LIGA = 900;

        public Veiculo Veiculo { get; set; }

        public string TextoFreioABS { get
            {
                return string.Format("Freio ABS - R$ {0}", FREIO_ABS);
            } }
        public string TextoArCond { get
            {
                return string.Format("Ar Condicionado - R$ {0}", AR_CONDICIONADO);
            } }
        public string TextoBancos { get
            {
                return string.Format("Bancos de Couro - R$ {0}", BANCOS_COURO);
            } }
        public string TextoMultimidia { get
            {
                return string.Format("Multimídia - R${0}", MULTIMIDIA);
            } }
        public string TextoRodas { get
            {
                return string.Format("Rodas de Liga - R$ {0}", RODAS_LIGA);
            } }

        bool temFreioAbs;
        public bool TemFreioAbs { 
            get {
                return temFreioAbs;
            } 
            set { 
                temFreioAbs = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
                if (temFreioAbs)
                    DisplayAlert("Freio ABS", "Adicionados", "Ok");
                else
                    DisplayAlert("Freio ABS", "Removidos", "Ok");
            } 
        }
        bool temArCond;
        public bool TemArCond
        {
            get
            {
                return temArCond;
            }
            set
            {
                temArCond = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
                if (temArCond)
                    DisplayAlert("Ar Condicionado", "Adicionados", "Ok");
                else
                    DisplayAlert("Ar Condicionado", "Removidos", "Ok");
            }
        }
        bool temBancos;
        public bool TemBancos
        {
            get
            {
                return temBancos;
            }
            set
            {
                temBancos = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
                if (temBancos)
                    DisplayAlert("Bancos de Couro", "Adicionados", "Ok");
                else
                    DisplayAlert("Bancos de Couro", "Removidos", "Ok");
            }
        }
        bool temMultimidia;
        public bool TemMultimidia
        {
            get
            {
                return temMultimidia;
            }
            set
            {
                temMultimidia = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
                if (temMultimidia)
                    DisplayAlert("Multimídia", "Adicionados", "Ok");
                else
                    DisplayAlert("Multimídia", "Removidos", "Ok");
            }
        }
        bool temRodas;
        public bool TemRodas
        {
            get
            {
                return temRodas;
            }
            set
            {
                temRodas = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
                if (temRodas)
                    DisplayAlert("Rodas de Liga", "Adicionados", "Ok");
                else
                    DisplayAlert("Rodas de Liga", "Removidos", "Ok");
            }
        }

        public string ValorTotal
        {
            get
            {
                return string.Format("Valor Total: R$ {0}",
                    Veiculo.preco
                    + (TemFreioAbs ? FREIO_ABS : 0)
                    + (TemArCond ? AR_CONDICIONADO : 0)
                    + (TemBancos ? BANCOS_COURO : 0)
                    + (TemMultimidia ? MULTIMIDIA : 0)
                    + (TemRodas ? RODAS_LIGA : 0));
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