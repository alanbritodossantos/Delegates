using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ByteBank.Agencias
{
    //delegate
    public delegate bool ValidacaoEventHandler(string texto);

    public class ValidacaoTextBox : TextBox
    {
        private ValidacaoEventHandler _validacao;
        /*a palavra reservada event na criação de nosso campo.*/
        //delegate+evento
        public event ValidacaoEventHandler Validacao
        {
            add
            {
                //adicionando um comportamento
                _validacao += value;
                OnValidacao();
            }
            remove
            {
                //removendo um comportamento
                _validacao -= value;
            }
        }



        public ValidacaoTextBox()
        {
            TextChanged += ValidacaoTextBox_TextChanged;
        }

        private void ValidacaoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            OnValidacao();
        }

        private void OnValidacao()
        {
            if (_validacao != null)
            {
                var ehValido = _validacao(Text);
                Background = ehValido ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.OrangeRed);
            }

        }
    }
}
