using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                CarregarContas();
            }
            catch (Exception)
            {
                Console.WriteLine("CATCH NO METODO MAIN");
            }

            

            Console.WriteLine("Execução finalizada, tecle ENTER para sair");
            Console.ReadLine();
        }

        private static void CarregarContas()
        {

            using(LeitorDeArquivo leitor = new LeitorDeArquivo("texte.txt"))
            {
                leitor.LerProximaLinha();
            }


            //----------------------------------------------------------------------------



            //LeitorDeArquivo leitor = null;

            //try
            //{
            //    leitor = new LeitorDeArquivo("contas.txt");
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();
            //    leitor.LerProximaLinha();

            //}
            //catch (IOException)
            //{
            //    Console.WriteLine("Exceção do tipo IOException capturada e tratada");
            //}
            //finally
            //{
            //    Console.WriteLine("EXECUTANDO O FINALLY");
            //    if(leitor != null)
            //    {
            //        leitor.Fechar();
            //    }
            //}
        }

        private static void TestaInnerException()
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(456, 456765);
                ContaCorrente conta2 = new ContaCorrente(456, 456766);
                conta1.Depositar(100);

                conta1.Sacar(10000);
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                Console.WriteLine("Informaçoes da INNER EXCEPTION (exceção interna)");

                // Console.WriteLine(e.InnerException.Message);
                //Console.WriteLine(e.InnerException.StackTrace);
            }
        }
    }
}
