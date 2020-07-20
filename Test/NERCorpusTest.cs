using DataStructure;
using NamedEntityRecognition;
using NUnit.Framework;

namespace Test
{
    public class NERCorpusTest
    {
        [Test]
        public void TestNERCorpus()
        {
            CounterHashMap<NamedEntityType> counter = new CounterHashMap<NamedEntityType>();
            NERCorpus nerCorpus = new NERCorpus("../../../nerdata.txt");
            Assert.AreEqual(27556, nerCorpus.SentenceCount());
            Assert.AreEqual(492233, nerCorpus.NumberOfWords());
            for (int i = 0; i < nerCorpus.SentenceCount(); i++){
                NamedEntitySentence namedEntitySentence = (NamedEntitySentence) nerCorpus.GetSentence(i);
                for (int j = 0; j < namedEntitySentence.WordCount(); j++){
                    NamedEntityWord namedEntityWord = (NamedEntityWord) namedEntitySentence.GetWord(j);
                    counter.Put(namedEntityWord.GetNamedEntityType());
                }
            }
            Assert.AreEqual(438976, counter[NamedEntityType.NONE]);
            Assert.AreEqual(23878, counter[NamedEntityType.PERSON]);
            Assert.AreEqual(16931, counter[NamedEntityType.ORGANIZATION]);
            Assert.AreEqual(12448, counter[NamedEntityType.LOCATION]);
        }
    }
}