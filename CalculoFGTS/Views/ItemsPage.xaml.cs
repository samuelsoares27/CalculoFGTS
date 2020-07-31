using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CalculoFGTS.Views;

namespace CalculoFGTS.Views
{
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage()
        {
            InitializeComponent();
            BOTAO.Clicked += CalcularImpostoRenda;
        }

        private void CalcularImpostoRenda(object sender, EventArgs args)
        {
            double valor = Convert.ToDouble(this.VALOR.Text.Replace("R$", ""));

            double valorTotal = (valor * 8) / 100;

            DisplayAlert("INFORMAÇÃO", "Valor de FGTS : R$" + valorTotal.ToString() + ",00", "OK");
        }
    }
}