using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MapGens;

namespace Levels
{
    class TestLevel : Level, ILevel
    {


        public TestLevel(byte dif) : base(new TestMap(), dif) { }


    }
}
