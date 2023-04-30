using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr5_Tebenko_Andrew_309
{
    internal class Response
    {
        public Request Request { get; set; }
        public InfoAboutCity InfoAboutCity { get; set; }
        public int StatusCode { get; set; }
    }
}