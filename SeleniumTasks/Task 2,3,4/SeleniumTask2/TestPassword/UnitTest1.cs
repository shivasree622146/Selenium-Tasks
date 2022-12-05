namespace TestPassword
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Password()
        {
            Password1 password1 = new Password1();

            Assert.That(password1.IsValidPassword("11234532he7656"), Is.EqualTo(false));
            //Assert.That(Password1.IsValidPassword("hello123456745"), Is.EqualTo(false));

        }
       
       
    }
}