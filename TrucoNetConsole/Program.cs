using System;
using System.Collections.Generic;
using System.Linq;
using TrucoZap.Entidade;
using TrucoZap.Entidade.Enumeradores;
using TrucoZap.Service;

namespace TrucoNetConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("TrucoZap Início...");          

            JogoService jogoService = new JogoService();            

            while (jogoService.IniciarProximaRodada())
            {
                if (jogoService.NumRodada > 1)
                {
                    TipoJogadorEnum? vencedorRodada = jogoService.ObterVencedorRodadaAnterior();
                    if (vencedorRodada != null)
                    {
                        Console.WriteLine($"Fim de rodada");
                        Console.WriteLine($"{vencedorRodada.ToString()} venceu a rodada");
                        Console.WriteLine($"*** Pontuação total");
                        Console.WriteLine($"Você: {jogoService.Placar.PontosPlayer1}");
                        Console.WriteLine($"Robô: {jogoService.Placar.PontosRobo}");
                        Console.ReadLine();                        
                        Console.Clear();
                    }
                }

                TipoJogadorEnum? vencedor = jogoService.ObterVencedorGeral();
                if (vencedor != null)
                {
                    string jogadorVencedor = vencedor == TipoJogadorEnum.Robo ? "Robô" : "Você";
                    Console.WriteLine($"Fim de jogo.");
                    Console.WriteLine($"{jogadorVencedor} venceu o jogo");
                }

                Console.WriteLine($"Carta pra manilha: {jogoService.CartavaViradaPraManilha.Nome}");

                while (jogoService.IniciarProximaSubRodada())
                {
                    string cartasPlayer1 = "";
                    string cartasRobo = "";
                    int qtde = 1;

                    foreach (CartaEntidade carta in jogoService.MaoRobo.CartasTotais)
                    {
                        cartasRobo += $" {carta.Nome}";
                        CartaEntidade cartaJaJogada = jogoService.MaoRobo.CartasJogadas.Where(c => c.Valor == carta.Valor).FirstOrDefault();
                        if (cartaJaJogada != null)
                        {
                            cartasRobo += "*";
                        }
                        cartasRobo += ",";
                    }
                    Console.WriteLine();
                    //Console.WriteLine($"[Debug]Cartas do Robo: {cartasRobo}");

                    foreach (CartaEntidade carta in jogoService.MaoPlayer1.CartasTotais)
                    {
                        cartasPlayer1 += $" ({qtde}) {carta.Nome}";
                        CartaEntidade cartaJaJogada = jogoService.MaoPlayer1.CartasJogadas.Where(c => c.Valor == carta.Valor).FirstOrDefault();
                        if (cartaJaJogada != null)
                        {
                            cartasPlayer1 += "*";
                        }
                        cartasPlayer1 += ",";
                        qtde++;
                    }
                    Console.WriteLine($"Suas cartas: {cartasPlayer1}");
                    Console.WriteLine("Faça sua jogada...");
                    int indiceEscolhaPlayer1 = -1;
                    string inputUser = Console.ReadLine();
                    while (inputUser != "1" && inputUser != "2" && inputUser != "3")
                    {
                        inputUser = Console.ReadLine();                       
                    }
                    indiceEscolhaPlayer1 = int.Parse(inputUser) - 1;

                    CartaEntidade cartaEscolhidaJogador = jogoService.MaoPlayer1.CartasTotais[indiceEscolhaPlayer1];
                    CartaEntidade jogadaPlayer1 = jogoService.JogarPlayer1(cartaEscolhidaJogador.Valor);
                    Console.WriteLine($"Sua Jogada:{jogadaPlayer1.Nome}"); 

                    CartaEntidade jogadaRobo = jogoService.JogarRobo();
                    Console.WriteLine($"Jogada Robo:{jogadaRobo.Nome}");

                    TipoJogadorEnum venceuSub = jogoService.ProcessarSubRodada();

                    Console.WriteLine($"A carta do {venceuSub.ToString()} é maior");
                }

                Console.ReadLine();
                Console.Clear();
            }

            Console.WriteLine($"Fim de jogo");         
            Console.WriteLine($"*** Pontuação total");
            Console.WriteLine($"Você: {jogoService.Placar.PontosPlayer1}");
            Console.WriteLine($"Robô: {jogoService.Placar.PontosRobo}");
            Console.ReadLine();
          
        }
    }
}
