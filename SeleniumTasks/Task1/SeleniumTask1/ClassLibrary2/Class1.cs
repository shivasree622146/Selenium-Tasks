using ChromeNunit;
using EdgeNunit;

namespace ClassLibrary2
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            ChromeTests chromeTests = new ChromeTests();
            chromeTests.Setup();
            chromeTests.ChromeTest();
            chromeTests.CloseChrome();
            EdgeTests edgeTests = new EdgeTests();
            edgeTests.Setup();
            edgeTests.EdgeTest();
            edgeTests.CloseEdge();
        }

    }
}