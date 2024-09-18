using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrucoZap.Service;
using System;
using System.Collections.Generic;
using System.Text;
using TrucoZap.Entidade;
using System.Linq;

namespace TrucoZap.Service.Tests
{
    [TestClass()]
    public class BaralhoServiceTests
    {
        BaralhoService _baralhoService = new BaralhoService(new CartaService());

        public BaralhoServiceTests()
        {

        }

        [TestMethod()]
        public void DarCartasTest()
        {
            _baralhoService.DarCartas();
            _baralhoService.DarCartas();
        }

        [TestMethod()]
        public void DefinirManilhaTest()
        {
            List<CartaEntidade> todasAsMaos = new List<CartaEntidade>();
            todasAsMaos.AddRange(_baralhoService.DarCartas().CartasTotais);
            todasAsMaos.AddRange(_baralhoService.DarCartas().CartasTotais);           
            CartaEntidade carta = _baralhoService.VirarCartaPraManilha();

            Assert.IsTrue(todasAsMaos.Where(c=> c.Valor == carta.Valor).Count() == 0);
        }
    }
}