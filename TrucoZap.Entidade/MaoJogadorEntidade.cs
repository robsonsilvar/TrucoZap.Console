using System;
using System.Collections.Generic;
using System.Text;

namespace TrucoZap.Entidade
{
    public class MaoJogadorEntidade
    {
        public List<CartaEntidade> CartasTotais = new List<CartaEntidade>();
        public List<CartaEntidade> CartasRestantes = new List<CartaEntidade>();
        public List<CartaEntidade> CartasJogadas = new List<CartaEntidade>();

        public MaoJogadorEntidade(List<CartaEntidade> cartas)
        {
            this.CartasRestantes = cartas;

            foreach (CartaEntidade carta in cartas)
            {
                CartasTotais.Add(carta);
            }
        }
    


    }
}
