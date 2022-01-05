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

        //metodo que dispara o evento
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            OnValidacao();
        }

        //foi alterado para protected para as classes filhas conseguirem enchegar o metodo
        //e foi colocado o virtual para as classas filhas poder sobrescrever o comportamento do metodo 
        protected virtual void OnValidacao()
        {
            if (_validacao != null)
            {
                //retorna uma lista de 2 ou mais delegates
                var listaValidacao = _validacao.GetInvocationList();
                var ehValido = _validacao(Text);

                foreach (ValidacaoEventHandler validacao in listaValidacao)
                {
                    if (!validacao(Text))//se o texto for alterado uma validação vai acontecer
                    {
                        ehValido = false;
                        break;
                    }
                }

                Background = ehValido ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.OrangeRed);
            }

        }
    }
}
