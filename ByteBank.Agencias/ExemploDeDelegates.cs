//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ByteBank.Agencias
//{
//    class ExemploDeDelegates 
//    {
//        //Definição do delegate
//        public delegate string ObterMensagemEspecifica();

//        static void Main1(String[] args)
//        {
//            Mensagem1();
//            Mensagem2();
//            Mensagem3();
//        }

//        static string MinhaMensagem1()
//        {
//            return "Mensagem1";
//        }

//        static void Mensagem1()
//        {
//            // metodo local funtion
//            //string MinhaMensagem() => "Mensagem 1";

//            //var mensagemCompleta = ObterMensagem(MinhaMensagem);
//            var mensagemCompleta = ObterMensagem(MinhaMensagem1);
//            Console.WriteLine(mensagemCompleta);
//        }

//        static void Mensagem2()
//        {
//            string MinhaMensagem() => "Mensagem 2";

//            var mensagemCompleta = ObterMensagem(MinhaMensagem);
//            Console.WriteLine(mensagemCompleta);
//        }

//        static void Mensagem3()
//        {
//            string MinhaMensagem() => "Mensagem 3";

//            var mensagemCompleta = ObterMensagem(MinhaMensagem);
//            Console.WriteLine(mensagemCompleta);
//        }

//        static string ObterMensagem(ObterMensagemEspecifica mensagemEspecifica)
//        {
//            string mensagem = string.Empty;
//            mensagem += "Início da mensagem \r\n\r\n";
//            mensagem += mensagemEspecifica();//delegate -- executa o metodo
//            mensagem += "\r\n\r\n";
//            mensagem += "Final da mensagem\r\n";
//            mensagem += "----------------\r\n";

//            return mensagem;
//        }
//    }
//}
