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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //campo privado e somente leitura
        private readonly ByteBankEntities _contextoBancoDeDados = new ByteBankEntities();
        private readonly ListBox lstAgencias;

        public MainWindow()
        {
            InitializeComponent();

            // a ListBox do .net não precisa de argumento
            lstAgencias = new ListBox();
            AtualizarControles();
        }

        //atualiza a lista
        private void AtualizarControles()
        {
            // definindo as dimensões da janela
            lstAgencias.Width = 270;
            lstAgencias.Height = 290;

            Canvas.SetTop(lstAgencias, 15);
            Canvas.SetLeft(lstAgencias, 15);

            //É um delegate - definindo comportamento
            lstAgencias.SelectionChanged += new SelectionChangedEventHandler(lstAgencias_SelectionChanged);

            //esse container vai conter varios elementos na nossa janela e vamos adicionar mais 1
            //estamos fazendo isso para adicionar um evento de clique na lista para atualizar os nossos detalhes
            container.Children.Add(lstAgencias);
            AtualizarListaDeAgencias();//ppppppppppwufhwiufhwkuwfhwfkhwefk
            btnEditar.Click += new RoutedEventHandler(btnEditar_Click);
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            //pegando a agencia atual
            var agenciaAtual = (Agencia)lstAgencias.SelectedItem;

            //cria a janela edição
            var janelaEdicao = new EdicaoAgencia(agenciaAtual);

            //é um comportamento que assim que é chamado a tela, não deixa sair dela enquando o usuario
            // não clicar nos botões que a tela mostra.
            var resultado = janelaEdicao.ShowDialog().Value;//retorna um bool que pode ser nulo

            if (resultado)
            {
                //Usuario clicou em OK
            }
            else
            {
                //Usuario clicou em Cancelar
            }
        }

        private void AtualizarListaDeAgencias()
        {
            //Limpa a lista 
            lstAgencias.Items.Clear();

            //pega as agencias, guarda numa lista e passando para variavel agencia
            var agencias = _contextoBancoDeDados.Agencias.ToList();
            foreach (var agencia in agencias)
                lstAgencias.Items.Add(agencia);
        }

        private void lstAgencias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var agenciaSelecionada = (Agencia)lstAgencias.SelectedItem;//foi feito um "cast" para converter de "objeto" para "agencia"

            txtNumero.Text = agenciaSelecionada.Numero;
            txtNome.Text = agenciaSelecionada.Nome;
            txtTelefone.Text = agenciaSelecionada.Telefone;
            txtEndereco.Text = agenciaSelecionada.Endereco;
            txtDescricao.Text = agenciaSelecionada.Descricao;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var confirmacao = 
                MessageBox.Show(
                    "Você deseja realmente excluir este item?",
                    "Confirmação",
                    MessageBoxButton.YesNo);
            if (confirmacao == MessageBoxResult.Yes)
            {
                //Excluir
            }
            else
            {
                //Não faz nada
            }
        }
    }
}
