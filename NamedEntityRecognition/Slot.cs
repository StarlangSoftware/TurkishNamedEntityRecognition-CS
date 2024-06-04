namespace NamedEntityRecognition
{
    public class Slot
    {
        private SlotType type;
        private string tag;
        
        /// <summary>
        /// Constructor for the Slot object. Slot object stores the information about more specific entities. The slot
        /// type represents the beginning, inside or outside the slot, whereas tag represents the entity tag of the
        /// slot.
        /// </summary>
        /// <param name="type">Type of the slot. B, I or O for beginning, inside, outside the slot respectively.</param>
        /// <param name="tag">Tag of the slot.</param>
        public Slot(SlotType type, string tag)
        {
            this.type = type;
            this.tag = tag;
        }

        /// <summary>
        /// Second constructor of the slot for a given slot string. A Slot string consists of slot type and slot tag
        /// separated with '-'. For example B-Person represents the beginning of a person. For outside tagging simple 'O' is
        /// used.
        /// </summary>
        /// <param name="slot">Input slot string.</param>
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

        /// <summary>
        /// Accessor for the type of the slot.
        /// </summary>
        /// <returns>Type of the slot.</returns>
        public SlotType GetType()
        {
            return type;
        }

        /// <summary>
        /// Accessor for the tag of the slot.
        /// </summary>
        /// <returns>Tag of the slot.</returns>
        public string GetTag()
        {
            return tag;
        }

        /// <summary>
        /// ToString method of the slot.
        /// </summary>
        /// <returns>Type and tag separated with '-'. If the type is outside, it returns 'O'.</returns>
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