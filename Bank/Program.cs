using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Bank
{
    class Program
    {
        static List<Conta> listConta = new List<Conta>();          
        static void Main(string[] args)
        {             

            string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = obterOpcaoUsuario();
            }
            
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
           

        }   //fim main

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:\n");

            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("C - Limpar Console");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarContas()
        {
            Console.WriteLine("\nListar Contas");
            if(listConta.Count == 0)
            {
                Console.WriteLine("Nenhuma Conta Cadastrada.");
                return;
            }

            for(int i = 0; i < listConta.Count; i++)
            {
                Conta conta = listConta[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }

        }

        private static void InserirConta()
        {
            Console.WriteLine("\nInserir Nova Conta");

            Console.Write("Digite 1 para Conta Fisica e 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Saldo Inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o Credito: ");
            double entraCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entraCredito,
                                        nome: entradaNome);
            listConta.Add(novaConta);

        }

        private static void Transferir()
        {
            Console.WriteLine("\nTransferência");

            Console.Write("Digite o Número da Conta de Origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o Número da Conta de Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o Valor a ser Transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());
            listConta[indiceContaOrigem].Transferir(valorTransferencia, listConta[indiceContaDestino]);
        }

        private static void Sacar()
        {
            Console.WriteLine("\nSaque");
            Console.Write("Digite o Número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Valor a ser Sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());
            listConta[indiceConta].Sacar(valorSaque);

        }

        private static void Depositar()
        {
            Console.WriteLine("\nDeposito");

            Console.Write("Digite o Número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Valor a ser Depositado: ");
            double valorDepositado = double.Parse(Console.ReadLine());
            listConta[indiceConta].Depositar(valorDepositado);
        }





    }//fim class
}
