using EPN_Parser.EpnApi;
using EPN_Parser.EpnApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EPN_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser parser = new Parser();
            var x = parser.GetTopProduct();
        }
    }
}
