using Dictionary.Dictionary;

namespace NamedEntityRecognition
{
    public class NamedEntityWord : Word
    {
        private readonly NamedEntityType _namedEntityType;

        /**
         * <summary>A constructor of {@link NamedEntityWord} which takes name and nameEntityType as input and sets the corresponding attributes</summary>
         * <param name="name">Name of the word</param>
         * <param name="namedEntityType">{@link NamedEntityType} of the word</param>
         */
        public NamedEntityWord(string name, NamedEntityType namedEntityType) : base(name)
        {
            this._namedEntityType = namedEntityType;
        }

        /**
         * <summary>Accessor method for namedEntityType attribute.</summary>
         *
         * <returns>namedEntityType of the word.</returns>
         */
        public NamedEntityType GetNamedEntityType()
        {
            return _namedEntityType;
        }
    }
}