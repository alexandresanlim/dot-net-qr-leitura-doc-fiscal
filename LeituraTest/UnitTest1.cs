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
            var qrCodeReturn = "http://www.fazenda.pr.gov.br/nfce/qrcode/?p=41200228159436000147650020000335711000535715|2|1|1|70FF42E07E7C0C49481FC98E07A30E37B3478051";

            UrlInfo.Read(qrCodeReturn);
        }
    }
}
