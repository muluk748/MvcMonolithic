using Solid_AntiPattern.Services;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Solid_AntiPattern.Frameworks
{
    public interface IService
    {
        public Service1 Service1 {  get; set; }
        public Service2 Service2 { get; set; }

    }
}
