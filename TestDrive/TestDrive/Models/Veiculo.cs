using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class Veiculo
    {
        public const int FREIO_ABS = 800;
        public const int AR_CONDICIONADO = 1500;
        public const int BANCOS_COURO = 900;
        public const int MULTIMIDIA = 700;
        public const int RODAS_LIGA = 900;

        public string nome { get; set; }
        public decimal preco { get; set; }
        public string precoFormatado
        {
            get
            {
                return string.Format("R$ {0}", preco);
            }
        }

        public bool temFreioAbs { get; set; }
        public bool temArCond { get; set; }
        public bool temBancos { get; set; }
        public bool temMultimidia { get; set; }
        public bool temRodas { get; set; }

        public string PrecoTotalFormatado
        {
            get
            {
                return string.Format("Valor Total: R$ {0}",
                    this.preco + (temFreioAbs ? Veiculo.FREIO_ABS : 0) + (temArCond ? Veiculo.AR_CONDICIONADO : 0) + (temBancos ? Veiculo.BANCOS_COURO : 0) + (temMultimidia ? Veiculo.MULTIMIDIA : 0) + (temRodas ? Veiculo.RODAS_LIGA : 0));
            }
        }

    }
}
