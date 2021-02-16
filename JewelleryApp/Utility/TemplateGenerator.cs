using JewelleryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryApp.Utility
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString(PriceReport report)
        {
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Gold Price (per gram)</th>
                                        <th>Weight(gram)</th>
                                        <th>Discount</th>
                                        <th>Total</th>
                                    </tr>");

            sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", report.price, report.weight, report.discount, report.total);
            sb.Append(@"
                                </table>
                            </body>
                        </html>");
            return sb.ToString();
        }
    }
}
