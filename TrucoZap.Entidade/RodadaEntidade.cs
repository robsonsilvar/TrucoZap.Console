using System;
using System.Collections.Generic;
using System.Text;

namespace TrucoZap.Entidade
{
    public class RodadaEntidade
    {
        public PlacarEntidade Placar { get; set; }
        public Jogada JogadaJogador { get; set; }
        public Jogada JogadaMaquina { get; set; }
    }
}
