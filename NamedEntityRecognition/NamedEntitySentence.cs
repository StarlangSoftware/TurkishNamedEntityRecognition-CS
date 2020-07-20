using System.Collections.Generic;
using Corpus;
using Dictionary.Dictionary;

namespace NamedEntityRecognition
{
    public class NamedEntitySentence : Sentence
    {
        /**
         * <summary>Another constructor of {@link NamedEntitySentence}. It takes input a named entity annotated sentence in string
         * form, divides the sentence with respect to space and sets the tagged words with respect to their tags.</summary>
         * <param name="sentence">Named Entity annotated sentence in string form</param>
         */
        public NamedEntitySentence(string sentence)
        {
            NamedEntityType type = NamedEntityType.NONE;
            words = new List<Word>();
            string[] wordArray = sentence.Split(" ");
            foreach (var word in wordArray)
            {
                if (word != "")
                {
                    if (word != "<b_enamex")
                    {
                        string candidate;
                        if (word.StartsWith("TYPE=\""))
                        {
                            int typeIndexEnd = word.IndexOf('\"', 6);
                            if (typeIndexEnd != -1)
                            {
                                string entityType = word.Substring(6, typeIndexEnd - 6);
                                type = NamedEntityTypeStatic.GetNamedEntityType(entityType);
                            }

                            if (word.EndsWith("e_enamex>"))
                            {
                                candidate = word.Substring(word.IndexOf('>') + 1,
                                    word.IndexOf('<') - word.IndexOf('>') - 1);
                                if (candidate != "")
                                {
                                    words.Add(new NamedEntityWord(candidate, type));
                                }

                                type = NamedEntityType.NONE;
                            }
                            else
                            {
                                candidate = word.Substring(word.IndexOf('>') + 1);
                                if (candidate != "")
                                {
                                    words.Add(new NamedEntityWord(candidate, type));
                                }
                            }
                        }
                        else
                        {
                            if (word.EndsWith("e_enamex>"))
                            {
                                candidate = word.Substring(0, word.IndexOf('<'));
                                if (candidate != "")
                                {
                                    words.Add(new NamedEntityWord(candidate, type));
                                }

                                type = NamedEntityType.NONE;
                            }
                            else
                            {
                                if (word != "")
                                {
                                    words.Add(new NamedEntityWord(word, type));
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}