using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrucoZap.Entidade;

namespace TrucoZap.Service
{
    public class CartaService
    {
        public CartaService()
        {
            CartasFormatadaDict.Add(1, "4-Ouros");
            CartasFormatadaDict.Add(2, "4-Copas");
            CartasFormatadaDict.Add(3, "4-Espada");
            CartasFormatadaDict.Add(4, "4-Zap");

            CartasFormatadaDict.Add(5, "5-Ouros");
            CartasFormatadaDict.Add(6, "5-Copas");
            CartasFormatadaDict.Add(7, "5-Espada");
            CartasFormatadaDict.Add(8, "5-Zap");

            CartasFormatadaDict.Add(9, "6-Ouros");
            CartasFormatadaDict.Add(10, "6-Copas");
            CartasFormatadaDict.Add(11, "6-Espada");
            CartasFormatadaDict.Add(12, "6-Zap");

            CartasFormatadaDict.Add(13, "7-Ouros");
            CartasFormatadaDict.Add(14, "7-Espada");
            CartasFormatadaDict.Add(15, "7-Copas");
            CartasFormatadaDict.Add(16, "7-Zap");

            CartasFormatadaDict.Add(17, "Q-Ouros");
            CartasFormatadaDict.Add(18, "Q-Espada");
            CartasFormatadaDict.Add(19, "Q-Copas");
            CartasFormatadaDict.Add(20, "Q-Zap");

            CartasFormatadaDict.Add(21, "J-Ouros");
            CartasFormatadaDict.Add(22, "J-Espada");
            CartasFormatadaDict.Add(23, "J-Copas");
            CartasFormatadaDict.Add(24, "J-Zap");

            CartasFormatadaDict.Add(25, "K-Ouros");
            CartasFormatadaDict.Add(26, "K-Espada");
            CartasFormatadaDict.Add(27, "K-Copas");
            CartasFormatadaDict.Add(28, "K-Zap");

            CartasFormatadaDict.Add(29, "A-Ouros");
            CartasFormatadaDict.Add(30, "A-Espada");
            CartasFormatadaDict.Add(31, "A-Copas");
            CartasFormatadaDict.Add(32, "A-Zap");

            CartasFormatadaDict.Add(33, "2-Ouros");
            CartasFormatadaDict.Add(34, "2-Espada");
            CartasFormatadaDict.Add(35, "2-Copas");
            CartasFormatadaDict.Add(36, "2-Zap");

            CartasFormatadaDict.Add(37, "3-Ouros");
            CartasFormatadaDict.Add(38, "3-Espada");
            CartasFormatadaDict.Add(39, "3-Copas");
            CartasFormatadaDict.Add(40, "3-Zap");
        }

        public Dictionary<int, string> CartasFormatadaDict = new Dictionary<int, string>();

        public void DefinirNomes(List<CartaEntidade> cartas)
        {
            foreach (CartaEntidade carta in cartas)
            {
                DefinirNome(carta);
            }
        }

        public void DefinirNome(CartaEntidade carta)
        {
            carta.Nome = CartasFormatadaDict[carta.Valor];
        }

        public bool IsManilha(CartaEntidade cartaEscolhida, CartaEntidade cartaViradaPraManilha)
        {
            return ObterManilha(cartaViradaPraManilha) == cartaEscolhida.Nome[0];
        }

        public char ObterManilha(CartaEntidade cartaViradaPraManilha)
        {
            char cartaSimboloManilha = ' ';

            for (int x = 1; x <= CartasFormatadaDict.Count(); x++)
            {
                char cartaViradaSimbolo = ' ';
                //achei o indice da carta no dictCartas
                if (cartaViradaPraManilha.Nome[0] == CartasFormatadaDict[x][0])
                {
                    cartaViradaSimbolo = cartaViradaPraManilha.Nome[0];

                    for (int y = x + 1; y <= CartasFormatadaDict.Count(); y++)
                    {
                        //achou o prox simbolo depois da carta virada = manilha
                        if (CartasFormatadaDict[y][0] != cartaViradaSimbolo)
                        {
                            cartaSimboloManilha = CartasFormatadaDict[y][0];
                            break;
                        }
                    }
                    if (cartaSimboloManilha == ' ')
                    {
                        cartaSimboloManilha = CartasFormatadaDict[1][0];
                    }
                    break;
                }
            }

            return cartaSimboloManilha;
        }
    }
}
