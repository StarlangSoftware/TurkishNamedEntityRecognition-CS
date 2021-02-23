using NamedEntityRecognition;
using NUnit.Framework;


namespace Test
{
    public class SlotTest
    {
        [Test]
        public void TestSlot()
        {
            Slot slot1 = new Slot("B-depart_date.month_name");
            Assert.AreEqual(SlotType.B, slot1.GetType());
            Assert.AreEqual("depart_date.month_name", slot1.GetTag());
            Assert.AreEqual("B-depart_date.month_name", slot1.ToString());
            Slot slot2 = new Slot("O");
            Assert.AreEqual(SlotType.O, slot2.GetType());
            Assert.AreEqual("O", slot2.ToString());
            Slot slot3 = new Slot("I-round_trip");
            Assert.AreEqual(SlotType.I, slot3.GetType());
            Assert.AreEqual("round_trip", slot3.GetTag());
            Assert.AreEqual("I-round_trip", slot3.ToString());

        }
    }
}