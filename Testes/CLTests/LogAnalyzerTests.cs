using LogAn;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {    
        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();
            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");
            Assert.False(result);
        }
    }
}
