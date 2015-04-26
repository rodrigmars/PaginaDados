using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaginaDados;
using PaginaDados.DTO;
using System.Collections.Generic;

namespace UnitTestPaginaDados
{
    [TestClass]
    public class UnitTest1
    {
        private int limite_registros { get; set; }

        public static IList<NotasDTO> notas { get; set; }

        [TestInitialize]
        public void Setup()
        {
            limite_registros = 49;
            
            notas = NotasData.CarregaNotas();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var sut = new Principal(limite_registros);

            sut.Pagina(notas);


        }
    }
}
