using ByteBank.Agencias.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ByteBank.Agencias
{
    //AgenciasListBox é o controle que será herdado do "ListBox" que é a classe do dot net
    public class AgenciasListBox : ListBox
    {
        private readonly MainWindow _janelaMae;

        // MainWindow é a janela criada por padrão em todos projetos WPfs
        public AgenciasListBox(MainWindow janelaMae)
        {
            // se "janelaMae" estiver null lance uma exception
            _janelaMae = janelaMae ?? throw new ArgumentNullException(nameof(janelaMae));
        }

        //metodo que muda objeto selecionado
        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);

            //atualize os campos da classe mãe
            // SelectedItem indica item selecionado
            var agenciaSelecionada = (Agencia)SelectedItem;//foi feito um "cast" para converter de "objeto" para "agencia"

            _janelaMae.txtNumero.Text = agenciaSelecionada.Numero;
            _janelaMae.txtNome.Text = agenciaSelecionada.Nome;
            _janelaMae.txtTelefone.Text = agenciaSelecionada.Telefone;
            _janelaMae.txtEndereco.Text = agenciaSelecionada.Endereco;
            _janelaMae.txtDescricao.Text = agenciaSelecionada.Descricao;
        }
    }
}
