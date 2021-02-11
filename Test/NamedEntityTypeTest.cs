using NamedEntityRecognition;
using NUnit.Framework;

namespace Test
{
    public class NamedEntityTypeTest
    {
        [Test]
        public void TestNamedEntityType()
        {
            Assert.AreEqual(NamedEntityTypeStatic.GetNamedEntityType("person"), NamedEntityType.PERSON);
            Assert.AreEqual(NamedEntityTypeStatic.GetNamedEntityType("Time"), NamedEntityType.TIME);
            Assert.AreEqual(NamedEntityTypeStatic.GetNamedEntityType("location"), NamedEntityType.LOCATION);
        }
    }
}