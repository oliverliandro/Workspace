// See https://aka.ms/new-console-template for more information
using Digi.Bank.Classes;
using Digi.Bank.Enums;
namespace Digi.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();

        static void Main()
        {
            TelaInicial();
        }

        static void TelaInicial()
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Seja bem vindo ao sistema do Digi Bank");
                Console.WriteLine("Escolha uma das Opções Abaixo:");
                Console.WriteLine();

                Console.WriteLine("1 - Listar Contas");
                Console.WriteLine("2 - Incluir Nova Conta");
                Console.WriteLine("3 - Consultar uma Conta");
                Console.WriteLine("4 - Efetuar um saque");
                Console.WriteLine("5 - Efetuar um depósito");
                Console.WriteLine("6 - Fazer tranferência");
                Console.WriteLine("0 - Finalizar o Sistema");
                Console.WriteLine();

                Console.Write("Opção Selecionada: ");
                int opcao = int.Parse(Console.ReadLine());

                Menu(opcao);
            } while (true);

        }

        static void Menu(int opcao)
        {
            switch (opcao)
            {
                case 1: ListarContas(); break;
                case 2: IncluirNovaConta(); break;
                case 3: ConsultarConta(); break;
                case 4: EfetuarSaque(); break;
                case 5: EfetuarDeposito(); break;
                case 6: FazerTranferencia(); break;
                case 0: FecharSistema(); break;
                default: TelaInicial(); break;
            }
        }

        static void FecharSistema()
        {
            Environment.Exit(0);
        }

        static void FazerTranferencia()
        {
            Conta contaOrigem = null;
            Conta ContaDestino = null;
            do
            {
                Console.Clear();
                Console.Write("Digite o Número da Conta de Origem..:");
                int numeroConta = int.Parse(Console.ReadLine());

                for (int i = 0; i < listaContas.Count; i++)
                {
                    if (numeroConta == i)
                        contaOrigem = listaContas[numeroConta];
                }

                if (contaOrigem == null)
                    Console.WriteLine("A conta Informada não foi licalizada, favor digitar uma conta válida!");

            } while (contaOrigem == null);

            do
            {
                Console.Clear();
                Console.Write("Digite o Número da Conta de Destino..:");
                int numeroConta = int.Parse(Console.ReadLine());

                for (int i = 0; i < listaContas.Count; i++)
                {
                    if (numeroConta == i)
                        ContaDestino = listaContas[numeroConta];
                }

                if (ContaDestino == null)
                    Console.WriteLine("A conta Informada não foi licalizada, favor digitar uma conta válida!");

            } while (ContaDestino == null);

            Console.Clear();
            Console.WriteLine("Dados da Conta Origem : ");
            Console.WriteLine(contaOrigem.ToString());

            Console.WriteLine("--------------------------------------------------------------");

            Console.WriteLine("Dados da Conta Destino : ");
            Console.WriteLine(ContaDestino.ToString());

            Console.Write("Digite o valor da Transferência: ");

            double valorTranferencia = double.Parse(Console.ReadLine());

            if (contaOrigem.Sacar(valorTranferencia))
            {
                ContaDestino.Depositar(valorTranferencia);

                Console.WriteLine("Tranferência, efetuada com sucesso!");

            }
            else
                Console.WriteLine("Não foi possível concluir a operação!");


            Console.Write("Dados da Conta Origem : ");
            Console.WriteLine(contaOrigem.ToString());

            Console.WriteLine("--------------------------------------------------------------");

            Console.Write("Dados da Conta Destino : ");
            Console.WriteLine(ContaDestino.ToString());


            Console.WriteLine("Aperte qualquer tecla, para retornar ao Menu Inicial: ");
            Console.ReadKey();

        }

        static void EfetuarDeposito()
        {
            Console.Clear();
            Console.Write("Digite o Número da Conta..:");
            int numeroConta = int.Parse(Console.ReadLine());

            Conta conta = null;
            for (int i = 0; i < listaContas.Count; i++)
            {
                if (numeroConta == i)
                    conta = listaContas[numeroConta];
            }

            if (conta != null)
            {
                Console.Clear();
                Console.WriteLine("Dados da Conta: ");
                Console.WriteLine(conta.ToString());

                Console.Write("Digite o Valor de Depósito:..:");
                double valorSaque = double.Parse(Console.ReadLine());
                Console.Clear();

                if (conta.Depositar(valorSaque))
                {
                    Console.WriteLine("Depósito Efetuado com sucesso");
                    Console.WriteLine($"Conta : {numeroConta}");
                    Console.WriteLine(conta.ToString());
                }

            }
            else
            {
                Console.WriteLine("Conta não localizada!");
            }

            Console.WriteLine("Aperte qualquer tecla, para retornar ao Menu Inicial: ");
            Console.ReadKey();
        }

        static void EfetuarSaque()
        {
            Console.Clear();
            Console.Write("Digite o Número da Conta..:");
            int numeroConta = int.Parse(Console.ReadLine());

            Conta conta = null;
            for (int i = 0; i < listaContas.Count; i++)
            {
                if (numeroConta == i)
                    conta = listaContas[numeroConta];
            }

            if (conta != null)
            {
                Console.Clear();
                Console.WriteLine("Dados da Conta: ");
                Console.WriteLine(conta.ToString());

                Console.Write("Digite o valor de Saque .. :");
                double valorSaque = double.Parse(Console.ReadLine());
                Console.Clear();
                if (conta.Sacar(valorSaque))
                {
                    Console.WriteLine("Saque Efetuado com sucesso");
                    Console.WriteLine($"Conta : {numeroConta}");
                    Console.WriteLine(conta.ToString());
                }
                else
                {
                    Console.WriteLine("Saldo Insuficiente!");
                }
            }
            else
            {
                Console.WriteLine("Conta não localizada!");
            }

            Console.WriteLine("Aperte qualquer tecla, para retornar ao Menu Inicial: ");
            Console.ReadKey();
        }

        static void ConsultarConta()
        {
            Console.Clear();
            Console.Write("Digite a conta que deseja Consultar: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Conta conta = null;
            Console.Clear();

            for (int i = 0; i < listaContas.Count; i++)
            {
                if (numeroConta == i)
                {

                    Console.WriteLine("#Conta: {0}", numeroConta);
                    conta = listaContas[numeroConta];
                    Console.WriteLine(conta.ToString());
                    Console.Write("Aperte qualquer tecla, para voltar ao Menu Inicial:");
                    Console.ReadKey();
                    return;
                }
            }

            Console.WriteLine("Conta Não Localizada.");
            Console.Write("Aperte qualquer tecla, para voltar ao Menu Inicial:");
            Console.ReadKey();
        }

        static void IncluirNovaConta()
        {
            Console.Clear();
            Console.Write("Digite o Tipo de Conta................: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Titular..............: ");
            string titular = Console.ReadLine();

            Console.Write("Digite O Saldo Inicial................: ");
            double saldoInicial = double.Parse(Console.ReadLine());

            Console.Write("Digite O Cheque especial Inicial......: ");
            double chequeEspecialInicial = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta((E_Tipo_Conta)tipoConta, titular, saldoInicial, chequeEspecialInicial);

            listaContas.Add(novaConta);

            Console.Clear();
            Console.WriteLine("Nova conta cadastrada com sucesso!");

            Console.WriteLine(novaConta.ToString());
            Console.Write("Aperte qualquer tecla, para voltar ao Menu Inicial:");
            Console.ReadKey();
        }

        static void ListarContas()
        {
            Console.Clear();
            if (listaContas.Count == 0)
                Console.WriteLine("Não existem contas cadastradas.");

            for (int i = 0; i < listaContas.Count; i++)
            {
                Console.WriteLine("#Conta: {0}", i);
                Conta conta = listaContas[i];
                Console.WriteLine(conta.ToString());
            }

            Console.Write("Aperte qualquer tecla, para voltar ao Menu Inicial:");
            Console.ReadKey();

        }
    }
}

