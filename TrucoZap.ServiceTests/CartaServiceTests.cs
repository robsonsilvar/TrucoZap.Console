using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrucoZap.Service;
using System;
using System.Collections.Generic;
using System.Text;
using TrucoZap.Entidade;

namespace TrucoZap.Service.Tests
{
    [TestClass()]
    public class CartaServiceTests
    {
        [TestMethod()]
        public void IsManilhaTest_DeveSerFalse()
        {
            CartaService cartaServ = new CartaService();

            CartaEntidade cartaEscolhida = new CartaEntidade(18);
            cartaEscolhida.Nome = "5";

            CartaEntidade cartaViradaDaManilha = new CartaEntidade(13);
            cartaViradaDaManilha.Nome = "3";

            Assert.IsFalse( cartaServ.IsManilha(cartaEscolhida, cartaViradaDaManilha));
        }

        [TestMethod()]
        public void IsManilhaTest_DeveSerTrue()
        {
            CartaService cartaServ = new CartaService();

            CartaEntidade cartaEscolhida = new CartaEntidade(18);
            cartaEscolhida.Nome = "4";

            CartaEntidade cartaViradaDaManilha = new CartaEntidade(13);
            cartaViradaDaManilha.Nome = "3";

            Assert.IsTrue(cartaServ.IsManilha(cartaEscolhida, cartaViradaDaManilha));
        }

        [TestMethod()]
        public void ObterManilhaTest()
        {
            CartaService cartaServ = new CartaService();           

            CartaEntidade cartaViradaDaManilha = new CartaEntidade(13);
            cartaViradaDaManilha.Nome = "4";

            char manilha = cartaServ.ObterManilha(cartaViradaDaManilha);

            Assert.IsTrue(manilha != ' ');
        }
    }
}