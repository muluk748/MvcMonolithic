using Solid_AntiPattern.Frameworks;
using Solid_AntiPattern.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid_AntiPattern.Clients
{
    public class A : IService
    {
        public A(Service1 service1, Service2 service2)
        {
            Service1 = service1;
            Service2 = service2;

        }
        public Service1 Service1 { get; set; }
        public Service2 Service2 { get; set; }
    }
}
