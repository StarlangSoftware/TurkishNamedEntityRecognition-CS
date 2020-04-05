using System.Collections.Generic;
using System.IO;
using Corpus;
using DataStructure;
using Dictionary.Dictionary;

namespace NamedEntityRecognition
{
    public class NERCorpus : Corpus.Corpus
    {
        /**
         * <summary>A constructor of {@link NERCorpus} which initializes the sentences of the corpus, the word list of
         * the corpus.</summary>
         */
        public NERCorpus()
        {
            sentences = new List<Sentence>();
            wordList = new CounterHashMap<Word>();
        }

        /**
         * <summary>A clone method for the {@link NERCorpus} class.</summary>
         *
         * <returns>A copy of the current {@link NERCorpus} class.</returns>
         */
        public new NERCorpus EmptyCopy()
        {
            return new NERCorpus();
        }

        /**
         * <summary>Another constructor of {@link NERCorpus} which takes a fileName of the corpus as an input, reads the
         * corpus from that file.</summary>
         *
         * <param name="fileName">Name of the corpus file.</param>
         */
        public NERCorpus(string fileName)
        {
            sentences = new List<Sentence>();
            var streamReader = new StreamReader(fileName);
            var line = streamReader.ReadLine();
            while (line != null)
            {
                AddSentence(new NamedEntitySentence(line));
                line = streamReader.ReadLine();
            }
        }

        /**
         * <summary>addSentence adds a new sentence to the sentences {@link ArrayList}</summary>
         * <param name="s">Sentence to be added.</param>
         */
        public void AddSentence(NamedEntitySentence s)
        {
            sentences.Add(s);
        }

        /**
         * <summary>WriteToFile writes the corpus in the format given above into the file with the given fileName.</summary>
         * <param name="fileName">Output file name.</param>
         */
        public new void WriteToFile(string fileName)
        {
            var writer = new StreamWriter(fileName);
            foreach (var sentence in sentences)
            {
                for (var i = 0; i < sentence.WordCount(); i++)
                {
                    var word = (NamedEntityWord) sentence.GetWord(i);
                    switch (word.GetNamedEntityType())
                    {
                        case NamedEntityType.LOCATION:
                            writer.Write(" <b_enamex TYPE=\"LOCATION\">" + word.GetName() + "<e_enamex>");
                            break;
                        case NamedEntityType.ORGANIZATION:
                            writer.Write(" <b_enamex TYPE=\"ORGANIZATION\">" + word.GetName() + "<e_enamex>");
                            break;
                        case NamedEntityType.PERSON:
                            writer.Write(" <b_enamex TYPE=\"PERSON\">" + word.GetName() + "<e_enamex>");
                            break;
                        case NamedEntityType.TIME:
                            writer.Write(" <b_enamex TYPE=\"TIME\">" + word.GetName() + "<e_enamex>");
                            break;
                        case NamedEntityType.MONEY:
                            writer.Write(" <b_enamex TYPE=\"MONEY\">" + word.GetName() + "<e_enamex>");
                            break;
                        default:
                            writer.Write(" " + word.GetName());
                            break;
                    }
                }

                writer.WriteLine();
            }

            writer.Close();
        }
    }
}