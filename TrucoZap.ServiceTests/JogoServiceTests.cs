using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrucoZap.Service;
using System;
using System.Collections.Generic;
using System.Text;
using TrucoZap.Entidade;

namespace TrucoZap.Service.Tests
{
    [TestClass()]
    public class JogoServiceTests
    {
        JogoService jogoService = new JogoService();

        public JogoServiceTests()
        {

        }


        [TestMethod()]
        public void JogoServiceTest()
        {

        }

        [TestMethod()]
        public void ProcessarSubRodada2Test()
        {
            jogoService.IniciarProximaRodada();
            jogoService.IniciarProximaSubRodada();
            CartaEntidade jogadaPlayer1;
            bool jogadaSucesso = false;
            int xOk = 0;
            while (!jogadaSucesso)
            {
                for (int x = 40; x >= 1; x--)
                {
                    try
                    {
                        jogadaPlayer1 = jogoService.JogarPlayer1(x);
                        jogadaSucesso = true;
                        xOk = x;
                        jogoService.JogarRobo();
                        break;
                    }
                    catch (Exception e)
                    {

                    }
                }
            }

            jogoService.ProcessarSubRodada();

            jogadaSucesso = false;
            while (!jogadaSucesso)
            {
                for (int x = xOk - 1; x >= 1; x--)
                {
                    try
                    {
                        jogadaPlayer1 = jogoService.JogarPlayer1(x);
                        jogadaSucesso = true;
                        xOk = x;
                        jogoService.JogarRobo();
                        break;
                    }
                    catch (Exception e)
                    {

                    }
                }
            }

            //sub2
            jogoService.ProcessarSubRodada();

            if (jogoService.ObterVencedorRodadaAtual() != null)
            {
                Assert.IsFalse(jogoService.IniciarProximaSubRodada());               
            }
            else
            {
                Assert.IsTrue(jogoService.IniciarProximaSubRodada());
            }

        }

        [TestMethod()]
        public void ProcessarSubRodada()
        {
            jogoService.IniciarProximaRodada();
            jogoService.IniciarProximaSubRodada();
            CartaEntidade jogadaPlayer1;
            bool jogadaSucesso = false;
            int xOk = 0;
            while (!jogadaSucesso)
            {
                for (int x = 40; x >= 1; x--)
                {
                    try
                    {
                        jogadaPlayer1 = jogoService.JogarPlayer1(x);
                        jogadaSucesso = true;
                        xOk = x;
                        jogoService.JogarRobo();
                        break;
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            CartaEntidade manilha = jogoService.CartavaViradaPraManilha;
            jogoService.ProcessarSubRodada();

           

        }


    }
}