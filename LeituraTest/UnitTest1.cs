using LeituraDocFiscal2Info;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeituraTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var qrCodeReturn = "http://www.fazenda.pr.gov.br/nfce/qrcode/?p=....";

            DocFiscal.Read(qrCodeReturn);
        }
    }
}
