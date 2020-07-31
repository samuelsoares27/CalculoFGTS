using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace CalculoFGTS
{
    internal class MascaraMoeda : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(args.NewTextValue))
            {
                bool ehCallback = false;
                string texto = args.NewTextValue;

                if (texto.Contains("R$"))
                {
                    var valorNovoEmDecimal = ConverterReaisParaDecimal(texto);
                    var valorAntigoEmDecimal = args.OldTextValue.Contains("R$") ? ConverterReaisParaDecimal(args.OldTextValue) : int.Parse(args.OldTextValue);
                    ehCallback = valorNovoEmDecimal == valorAntigoEmDecimal;

                    texto = valorNovoEmDecimal.ToString();
                }

                if (!ehCallback)
                {
                    if (!string.IsNullOrEmpty(texto))
                    {
                        var textoFormatadoEmReais = (Decimal.Parse(texto) / 100).ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
                        texto = textoFormatadoEmReais;
                    }

                    ((Entry)sender).Text = texto;
                }
            }
        }

        private static int ConverterReaisParaDecimal(string valor)
        {
            var valorConvertido = Decimal.Parse(valor.Replace("R$ ", "").Replace(",", "").Replace(".", ""),
                CultureInfo.GetCultureInfo("pt-BR"));
            return (int)valorConvertido;
        }
    }
}
