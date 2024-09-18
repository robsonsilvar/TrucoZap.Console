using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrucoZap.Entidade;

namespace TrucoZap.Service
{
    public class BaralhoService
    {
        private int cartaValorMaximo = 40;
        private List<CartaEntidade> cartasJaSelecionadas = new List<CartaEntidade>();
        private CartaService cartaService;
        private List<CartaEntidade> _cartasDadas = new List<CartaEntidade>();
        public BaralhoService(CartaService cartaService)
        {
            this.cartaService = cartaService;
        }
        public MaoJogadorEntidade DarCartas()
        {           
            List<CartaEntidade> cartas = new List<CartaEntidade>();
            int totalCartas = 0;
            while (totalCartas < 3)
            {
                Random rand = new Random();
                int valorCarta = rand.Next(cartaValorMaximo + 1);
                while (cartasJaSelecionadas.Where(c => c.Valor == valorCarta).FirstOrDefault() != null || valorCarta == 0)
                {
                    valorCarta = rand.Next(cartaValorMaximo + 1);
                }
                CartaEntidade cartaEscolhida = new CartaEntidade(valorCarta);
                cartasJaSelecionadas.Add(cartaEscolhida);
                cartas.Add(cartaEscolhida);               
                totalCartas++;
            }
            cartaService.DefinirNomes(cartas);
            _cartasDadas.AddRange(cartas);
            return new MaoJogadorEntidade(cartas);
        }

        public CartaEntidade VirarCartaPraManilha()
        {
            Random rand = new Random();
            int valorCarta = rand.Next(cartaValorMaximo + 1);
            while (_cartasDadas.Where(c => c.Valor == valorCarta).FirstOrDefault() != null || valorCarta == 0)
            {
                valorCarta = rand.Next(cartaValorMaximo + 1);
            }
            CartaEntidade cartaManilha = new CartaEntidade(valorCarta);
            cartaService.DefinirNome(cartaManilha);
            return cartaManilha;
        }

    }
}
