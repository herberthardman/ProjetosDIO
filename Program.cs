using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaDeContas = new List<Conta>();
        static void Main(string[] args)
        {
           string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario) 
                {
                    case "1":
                        listarContas();
                        break;
                    case "2":
                        inserirConta();
                        break;
                    case "3":
                        transferir();
                        break;
                    case "4":
                        sacar();
                        break;
                    case "5":
                        depositar();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();                     
                }
                opcaoUsuario = obterOpcaoUsuario();
            }
            //Console.WriteLine("Programa finalizado, obrigado!");
            Console.ReadLine();
        }

        private static void transferir()
        {
            Console.WriteLine("Digite o número da conta de ORIGEM");
            int nrContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de DESTINO");
            int nrContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor para transferência");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaDeContas[nrContaOrigem].transferir(valorTransferencia, listaDeContas[nrContaDestino]);

        }

        private static void depositar()
        {
            Console.WriteLine("Digite o número da conta");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor para depósito");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaDeContas[numeroConta].sacar(valorDeposito);
        }

        private static void sacar()
        {
            Console.WriteLine("Digite o número da conta");
            int numeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor para saque");
            double valorSaque = double.Parse(Console.ReadLine());

            listaDeContas[numeroConta].sacar(valorSaque);

        }

        private static void listarContas()
        {
            Console.WriteLine("Lista de contas cadastradas");
            Console.WriteLine();

            if (listaDeContas.Count == 0)
            {
                Console.WriteLine("Lista de contas está vazia");
            }
            // poderia se utilizado o for, mas preferir foreach para testar
            int i = 0;
            foreach (Conta conta in listaDeContas)
            {
                Console.WriteLine("#{0} - ", i);
                Console.WriteLine(conta.ToString());
                i++;
            }
        }

        private static void inserirConta()
        {
           Console.WriteLine("Cadastrar nova Conta");

           Console.WriteLine("Digite 1 para Conta pessoa física ou 2 para Conta pessoa juridica");
           int TipoConta = int.Parse(Console.ReadLine());

           Console.WriteLine("Digite o nome do Cliente da conta");
           string nome = Console.ReadLine();

           Console.WriteLine("Digite o saldo inicial da conta");
           double saldoInicial = double.Parse(Console.ReadLine());

           Console.WriteLine("Digite o valor do crédito");
           double creditoConta = double.Parse(Console.ReadLine());

           Conta novaConta = new Conta(saldoInicial, creditoConta, nome, (TipoConta)TipoConta);

           listaDeContas.Add(novaConta);

        }

        private static string obterOpcaoUsuario()
        {
                Console.WriteLine();
                Console.WriteLine("Herbert Bank SE ao seu dispor!");
                Console.WriteLine("Informe a opção desejada");

                Console.WriteLine("1 - Listar Contas");
                Console.WriteLine("2 - Inserir nova Conta");
                Console.WriteLine("3 - Transferir");
                Console.WriteLine("4 - Sacar");
                Console.WriteLine("5 - Depositar");
                Console.WriteLine("6 - Limpar Tela");
                Console.WriteLine("X - Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine();
                Console.WriteLine();

                return opcaoUsuario;                
        }

    }
}
