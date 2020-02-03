using LeituraDocFiscal2Info;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;

namespace zAppLeituraTest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var scanner = new MobileBarcodeScanner
            {
                TopText = "Aponte para o QR Code do documento fiscal",
            };

            var result = await scanner.Scan(new MobileBarcodeScanningOptions
            {
                PossibleFormats = new List<ZXing.BarcodeFormat>
                        {
                            ZXing.BarcodeFormat.QR_CODE
                        }
            });

            var docINfo = result.Text.Read();

            info.IsVisible = true;

            lbAccesskey.Text = docINfo.AccessKey;
            lbCompany.Text = docINfo.Company;
            lbTotal.Text = docINfo.TotalPresentation;
            lbUfCode.Text = docINfo.InfoFromAccessKey.UfCode;
            lbYear.Text = docINfo.InfoFromAccessKey.Year.ToString();
            lbMonth.Text = docINfo.InfoFromAccessKey.Month.ToString();
            lbCnpj.Text = docINfo.InfoFromAccessKey.CnpjCompany;
            lbDocModel.Text = docINfo.InfoFromAccessKey.DocModel;
            lbDocSerie.Text = docINfo.InfoFromAccessKey.DocSerie;
            lbDocNumber.Text = docINfo.InfoFromAccessKey.DocNumber;
        }
    }
}
