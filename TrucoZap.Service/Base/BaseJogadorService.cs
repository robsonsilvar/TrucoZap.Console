using System;
using System.Collections.Generic;
using System.Text;
using TrucoZap.Entidade;

namespace TrucoZap.Service.Base
{
    public class BaseJogadorService
    {
        protected int cartaValorMaximo = 40;
        public MaoJogadorEntidade MaoJogador;

        public BaseJogadorService(MaoJogadorEntidade maoJogador)
        {
            this.MaoJogador = maoJogador;
        }

        public void SacarCarta(CartaEntidade cartaSacada)
        {
            MaoJogador.CartasJogadas.Add(new CartaEntidade(cartaSacada.Valor));
            MaoJogador.CartasRestantes.Remove(cartaSacada);
        }

        public void ReceberCartas(MaoJogadorEntidade maoJogador)
        {
            this.MaoJogador = maoJogador;
        }
    }
}
