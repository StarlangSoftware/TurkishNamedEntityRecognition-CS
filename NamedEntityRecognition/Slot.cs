namespace NamedEntityRecognition
{
    public class Slot
    {
        private SlotType type;
        private string tag;

        public Slot(SlotType type, string tag)
        {
            this.type = type;
            this.tag = tag;
        }

        public Slot(string slot)
        {
            if (slot == "O" || slot == "o")
            {
                type = SlotType.O;
                tag = null;
            }
            else
            {
                var type = slot.Substring(0, slot.IndexOf("-"));
                var tag = slot.Substring(slot.IndexOf("-") + 1);
                switch (type)
                {
                    case "B":
                        this.type = SlotType.B;
                        break;
                    case "I":
                        this.type = SlotType.I;
                        break;
                }

                this.tag = tag;
            }
        }

        public SlotType GetType()
        {
            return type;
        }

        public string GetTag()
        {
            return tag;
        }

        public override string ToString()
        {
            switch (type){
                case SlotType.O:
                    return "O";
                case SlotType.B:
                case SlotType.I:
                    return type + "-" + tag;
            }
            return "";
        }
    }
}