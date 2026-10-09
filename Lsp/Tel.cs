using Lsp.Frameworks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsp
{
    public class Tel: IContact
    {
        public string GetContact()
        {
            return "By Tel";
        }
    }
    public class Sms:IContact
    {
        public string GetContact()
        {
            return "By SMS";
        }
    }
    public class Email: IContact
    {
        public string GetContact()
        {
            return "By Email";
        }
    }
}
