using LeituraDocFiscal2Info.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeituraDocFiscal2Info
{
    public static class DocFiscal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">Retorno do QrCode Ex: "http://www.fazenda.pr.gov.br/nfce/qrcode/?p=...."</param>
        /// <returns>Informações da URL passada</returns>
        public static DocInfo Read(this string url)
        {
            if (url.Contains("pr.gov") && url.Contains("nfce"))
                return url.ReadNfcePr();

            else
                throw new ArgumentException("Não suportado!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">Retorno do QrCode Ex: "http://www.fazenda.pr.gov.br/nfce/qrcode/?p=...."</param>
        /// <returns>Informações da URL passada</returns>
        public static async Task<DocInfo> ReadAsync(this string url)
        {
            if (url.Contains("pr.gov") && url.Contains("nfce"))
                return await url.ReadNfcePrAsync();

            else
                throw new ArgumentException("Não suportado!");
        }

        private static DocInfo ReadNfcePr(this string url)
        {
            using (var client = new WebClient())
            {
                var result = client.DownloadString(url);
                return result.ToDocInfo();
            }
        }

        private static async Task<DocInfo> ReadNfcePrAsync(this string url)
        {
            using (var client = new WebClient())
            {
                var result = await client.DownloadStringTaskAsync(new Uri(url));
                return result.ToDocInfo();
            }
        }

        private static DocInfo ToDocInfo(this string urlResult)
        {
            return new DocInfo
            {
                Company = new Regex(@"<div id=""u20"" class=""txtTopo"">(.*?)</div>").Match(urlResult).Groups[1].Value,
                Total = new Regex(@"<span class=""totalNumb txtMax"">(.*?)</span>").Match(urlResult).Groups[1].Value,
                AccessKey = new Regex(@"<span class=""chave"">(.*?)</span>").Match(urlResult).Groups[1].Value.Replace(" ", ""),
                Html = urlResult
            };
        }
    }
}
