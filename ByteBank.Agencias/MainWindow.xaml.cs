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
        private readonly AgenciasListBox lstAgencias;

        public MainWindow()
        {
            InitializeComponent();
            
            // o this nesse momento é para criar a instancia
            lstAgencias = new AgenciasListBox(this);
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

            //esse container vai conter varios elementos na nossa janela e vamos adicionar mais 1
            //estamos fazendo isso para adicionar um evento de clique na lista para atualizar os nossos detalhes
            container.Children.Add(lstAgencias);

            //Limpa a lista 
            lstAgencias.Items.Clear();

            //pega as agencias, guarda numa lista e passando para variavel agencia
            var agencias = _contextoBancoDeDados.Agencias.ToList();
            foreach (var agencia in agencias)
                lstAgencias.Items.Add(agencia);
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
