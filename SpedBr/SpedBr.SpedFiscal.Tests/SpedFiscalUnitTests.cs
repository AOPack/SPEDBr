using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpedBr.Common;
using System;

namespace SpedBr.SpedFiscal.Tests
{
    [TestClass]
    public class SpedFiscalUnitTests
    {
        [TestMethod]
        public void EscreverRegistro0000()
        {
            // SPED Fiscal
            var reg0000 = new SpedFiscal.Bloco0.Registro0000
            {
                CodVer = 1,
                CodFin = IndCodFinalidadeArquivo.RemessaArquivoOriginal,
                DtIni = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1),
                DtFin = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).GetLastDayOfCurrentMonth(),
                Nome = "EMPRESA ABC LTDA - ME",
                Cnpj = "01.234.567/0008-99",
                Uf = "GO",
                Ie = "0000000000",
                CodMun = "5204508", // Caldas Novas
                Im = "",
                // Suframa
                IndPerfil = IndPerfilArquivo.A,
                IndAtiv = IndTipoAtividade.Outros
            };

            var initialDate = reg0000.DtIni.ToNormalizedDDMMYYYYString();
            var finalDate = reg0000.DtFin.ToNormalizedDDMMYYYYString();

            var expectedResult = $"|0000|001|0|{initialDate}|{finalDate}|EMPRESA ABC LTDA - ME|01.234.567/000||GO|0000000000|5204508|||A|1|";
            var actualResult = reg0000.EscreverCampos(true);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
