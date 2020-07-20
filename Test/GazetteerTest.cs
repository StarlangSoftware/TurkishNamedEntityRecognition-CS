using NamedEntityRecognition;
using NUnit.Framework;

namespace Test
{
    public class GazetteerTest
    {
        [Test]
        public void TestContains() {
            var gazetteer = new Gazetteer("location", "gazetteer-location.txt");
            Assert.True(gazetteer.Contains("bağdat"));
            Assert.True(gazetteer.Contains("BAĞDAT"));
            Assert.True(gazetteer.Contains("belçika"));
            Assert.True(gazetteer.Contains("BELÇİKA"));
            Assert.True(gazetteer.Contains("körfez"));
            Assert.True(gazetteer.Contains("KÖRFEZ"));
            Assert.True(gazetteer.Contains("küba"));
            Assert.True(gazetteer.Contains("KÜBA"));
            Assert.True(gazetteer.Contains("varşova"));
            Assert.True(gazetteer.Contains("VARŞOVA"));
            Assert.True(gazetteer.Contains("krallık"));
            Assert.True(gazetteer.Contains("KRALLIK"));
            Assert.True(gazetteer.Contains("berlin"));
            Assert.True(gazetteer.Contains("BERLİN"));
        }
    }
}