using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrucoZap.Entidade;
using TrucoZap.Service.Base;

namespace TrucoZap.Service
{
    public class RoboJogadorService : BaseJogadorService
    {
     
        public RoboJogadorService(MaoJogadorEntidade maoJogador) :base(maoJogador)
        {
            
        }

      
        public CartaEntidade Jogar()
        {
            Random rand = new Random();
            int tentativaValorCarta = rand.Next(cartaValorMaximo + 1);
            CartaEntidade cartaSacada = null;
            while (cartaSacada == null)
            {
                cartaSacada = MaoJogador.CartasRestantes.Where(c => c.Valor == tentativaValorCarta).FirstOrDefault();
                tentativaValorCarta = rand.Next(cartaValorMaximo + 1);
            }
            SacarCarta(cartaSacada);        
            return cartaSacada;

        }

      
    }
}
