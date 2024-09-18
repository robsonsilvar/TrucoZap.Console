using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrucoZap.Entidade;
using TrucoZap.Service.Base;

namespace TrucoZap.Service
{
    public class Player1JogadorService : BaseJogadorService
    {

        public Player1JogadorService(MaoJogadorEntidade maoJogador) : base(maoJogador)
        {

        }

        public CartaEntidade Jogar(int valorCarta)
        {
            CartaEntidade cartaSacada = null;
            cartaSacada = MaoJogador.CartasRestantes.Where(c => c.Valor == valorCarta).FirstOrDefault();
            SacarCarta(cartaSacada);
            return cartaSacada;
        }


    }
}
