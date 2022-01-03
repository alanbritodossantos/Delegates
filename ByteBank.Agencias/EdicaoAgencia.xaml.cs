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
            //manipulando eventos
            //usando metodos de manipulação da classe delegate
            //combinando dois delegates
            Delegate okEventHandler = (RoutedEventHandler)btnOk_Click + Fechar;
            Delegate cancelarEventHandler = (RoutedEventHandler)btnCancelar_Click + Fechar;

            //adicionando comportamento para o evento
            btnOk.Click += new RoutedEventHandler(Fechar);
            btnCancelar.Click += new RoutedEventHandler(Fechar);
        }

        private void btnOk_Click(Object sender, EventArgs e) =>
            DialogResult = true;
         
        private void btnCancelar_Click(Object sender, EventArgs e) =>
            DialogResult = false;
                   
        private void Fechar(Object sender, EventArgs e) =>
            Close();
        
    }
}
