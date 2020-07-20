using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace NamedEntityRecognition
{
    public class Gazetteer
    {
        private readonly HashSet<string> _data;
        private readonly string _name;

        /**
         * <summary>A constructor for a specific gazetteer. The constructor takes name of the gazetteer and file name of the
         * gazetteer as input, reads the gazetteer from the input file.</summary>
         * <param name="name">Name of the gazetteer. This name will be used in programming to separate different gazetteers.</param>
         * <param name="fileName">File name of the gazetteer data.</param>
         */
        public Gazetteer(string name, string fileName)
        {
            this._name = name;
            _data = new HashSet<string>();
            var assembly = typeof(Gazetteer).Assembly;
            var gazetteerStream = assembly.GetManifestResourceStream("NamedEntityRecognition." + fileName);
            var streamReader = new StreamReader(gazetteerStream);
            var line = streamReader.ReadLine();
            while (line != null)
            {
                _data.Add(line.ToLower(new CultureInfo("tr")));
                line = streamReader.ReadLine();
            }
        }

        /**
         * <summary>Accessor method for the name of the gazetteer.</summary>
         * <returns>Name of the gazetteer.</returns>
         */
        public string GetName()
        {
            return _name;
        }

        /**
         * <summary>The most important method in {@link Gazetteer} class. Checks if the given word exists in the gazetteer. The check
         * is done in lowercase form.</summary>
         * <param name="word">Word to be search in Gazetteer.</param>
         * <returns>True if the word is in the Gazetteer, False otherwise.</returns>
         */
        public bool Contains(string word)
        {
            var wordLowercase = word.ToLower(new CultureInfo("tr"));
            return _data.Contains(wordLowercase);
        }
    }
}