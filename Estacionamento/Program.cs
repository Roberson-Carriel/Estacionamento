﻿using Estacionamento.Services;

class Program
{
    static void Main()
    {
        var estacionamento = new EstacionamentoService();
        bool exibirMenu = true;

        while (exibirMenu)
        {
            Console.WriteLine("\n=== MENU ESTACIONAMENTO ===");
            Console.WriteLine("1 - Cadastrar veículo");
            Console.WriteLine("2 - Remover veículo");
            Console.WriteLine("3 - Listar veículos");
            Console.WriteLine("4 - Encerrar");
            Console.Write("Escolha uma opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    estacionamento.AdicionarVeiculo();
                    break;
                case "2":
                    estacionamento.RemoverVeiculo();
                    break;
                case "3":
                    estacionamento.ListarVeiculos();
                    break;
                case "4":
                    exibirMenu = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }

        Console.WriteLine("Programa encerrado!");
    }
}
