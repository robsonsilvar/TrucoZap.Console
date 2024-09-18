using System;
using System.Collections.Generic;
using System.Text;

namespace TrucoZap.Entidade
{
    /// <summary>
    /// 4,5,6,7,q,j,k,a,2,3
    /// </summary>
    public class CartaEntidade
    {
        //ate 40
        public int Valor { get; set; }
        public string Nome { get; set; }

        public CartaEntidade(int valor)
        {
            this.Valor = valor;
        }

       
       

    }
}
