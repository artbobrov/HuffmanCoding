using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;

using NDesk.Options;

namespace HuffmanCoding {

    internal class Program {

        static void ShowHelp(OptionSet p) {
            Console.WriteLine("Example usage:");
            Console.WriteLine("\tmono HuffmanCoding.exe -d PATHTOFILE");
            Console.WriteLine("\tmono HuffmanCoding.exe -c PATHTOFILE");
            Console.WriteLine("Tool to compress or decompress file using Huffman Code");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }

        public static void Main(string[] args) {
            bool showHelp = false;

            var watch = new Stopwatch();
            var p = new OptionSet() {
                {
                    "c|compress=", "Path to file to compress", delegate(string path) {
                        watch.Start();
                        var encoder = new HuffmanEncoder(path);
                        encoder.Encode();
                        watch.Stop();
                        Console.WriteLine($"Encoding time: {watch.ElapsedMilliseconds} Milliseconds");
                    }
                }, {
                    "d|decompress=", "Path to file to decompress", delegate(string path) {
                        watch.Start();
                        var decoder = new HuffmanDecoder(path);
                        decoder.Decode();
                        watch.Stop();
                        Console.WriteLine($"Decoding time: {watch.ElapsedMilliseconds} Milliseconds");
                    }
                }, {
                    "h|help", "Show this message and exit", v => showHelp = v != null
                },
            };

            List<string> extra;
            try {
                extra = p.Parse(args);
            }
            catch (OptionException e) {
                Console.Write("HuffmanCoding: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `HuffmanCoding --help' for more information.");
                return;
            }

            if (showHelp) {
                ShowHelp(p);
                return;
            }
        }

    }

}