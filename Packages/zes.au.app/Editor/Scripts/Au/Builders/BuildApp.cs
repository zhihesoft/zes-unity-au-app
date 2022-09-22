using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Au.Builders
{
    internal class BuildApp : BuildTask
    {
        public override string name => throw new NotImplementedException();

        protected override void AfterBuild()
        {
        }

        protected override bool BeforeBuild()
        {
            return true;
        }

        protected override bool OnBuild()
        {
            return false;
        }
    }
}
