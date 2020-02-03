# LeituraDocFiscal2Info
Leia QrCode de NFC-e e transforme em dados.

## Suporte

| UF     |NFC-e|NF-e| CT-e|MDF-e
| -------------|:--------:| :--------:|:--------:| :--------:|
| PR |✔ | ✖ | ✖ | ✖ |

## Como funciona?
Quando o QRCode é lido, retorno uma URL para consulta, assim extraio os dados que retornaram da página HTML.

## Como Usar
```csharp
var qrCodeReturn = "http://www.fazenda.pr.gov.br/nfce/qrcode/?p=....";

DocFiscal.Read(qrCodeReturn);
```
### Resultado:
![alt text](https://imgur.com/jnFQDHL.jpg)

## Extra
Neste projeto tem um App em Xamarin com leitor de QRCode que pode ser usado para testar.
![alt text](https://imgur.com/undefined)

## Considerações Finais
Pq? Precisava pegar ao meno o valor e não encontrei nenhuma API (free) que fizesse isso.

Contribuições são bem vindas!

Lembre-se: Imposto é Roubo, use com moderação.
