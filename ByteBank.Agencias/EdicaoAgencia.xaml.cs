using ByteBank.Agencias.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for EdicaoAgencia.xaml
    /// </summary>
    public partial class EdicaoAgencia : Window
    {
        private readonly Agencia _agencia;
        /// </summary>
        public EdicaoAgencia(Agencia agencia)
        {
            InitializeComponent();

            //se alguem chamar esse argumento passando um valor nulo, mostre uma exception
            _agencia = agencia ?? throw new ArgumentNullException(nameof(agencia));

            AtualizarCamposDeTexto();
            AtualizarControles();
        }

        //atualizando campos de texto
        private void AtualizarCamposDeTexto()
        {
            txtNumero.Text = _agencia.Numero;
            txtNome.Text = _agencia.Nome;
            txtTelefone.Text = _agencia.Telefone;
            txtEndereco.Text = _agencia.Endereco;
            txtDescricao.Text = _agencia.Descricao;
        }

        private void AtualizarControles()
        {
            //metodo anonimo é um metodo que não possui nome
            //criamos variáveis que armazenam o código do 
            //delegates por meio de métodos anônimos, para casos pontuais de 
            //código que seria usado em apenas um lugar.
            //                                  sintaxe lambda       
            RoutedEventHandler dialogResultTrue = (o, e) => DialogResult = true; //operador de expressão lambda

            RoutedEventHandler dialogResultFalse = (o, e) => DialogResult = false;

            var okEventHandler = dialogResultTrue + Fechar;
            var cancelarEventHandler = dialogResultFalse + Fechar;

            btnOk.Click += okEventHandler;
            btnCancelar.Click += cancelarEventHandler;

            txtNome.TextChanged += ConstruirDelegateValidacaoCampoNulo(txtNome);
            txtDescricao.TextChanged += ConstruirDelegateValidacaoCampoNulo(txtDescricao);
            txtEndereco.TextChanged += ConstruirDelegateValidacaoCampoNulo(txtEndereco);
            txtNumero.TextChanged += ConstruirDelegateValidacaoCampoNulo(txtNumero);
            txtTelefone.TextChanged += ConstruirDelegateValidacaoCampoNulo(txtTelefone);

        }

        //metodo que retorna um delegate 
        //constroi delegates
        private TextChangedEventHandler ConstruirDelegateValidacaoCampoNulo(TextBox txt)
        {
            return (o, e) =>
            {
                var textoEstaVazio = String.IsNullOrEmpty(txt.Text);

                //usando ternario 
                txt.Background = textoEstaVazio ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.White);

            };
        }

   
 
        private void btnOk_Click(Object sender, EventArgs e) =>
            DialogResult = true;
         
        private void btnCancelar_Click(Object sender, EventArgs e) =>
            DialogResult = false;

        // Contravariância (covariance )
        private void Fechar(Object sender, EventArgs e) =>
            Close();
        
    }
}
