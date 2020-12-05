using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DataGenerator
{
    public class Program
    {
        private static string pathFid = @"C:\Study\Tests\Tests\TestProject1\TestProject1\Data\fid.txt";
        private static string pathData = @"C:\Study\Tests\Tests\TestProject1\TestProject1\Data\";

        private static int Fid
        {
            get
            {
                var sr = new StreamReader(pathFid);
                var v = sr.ReadToEnd();
                sr.Close();
                return int.Parse(v);
            }
            set
            {
                var sw = new StreamWriter(pathFid, false);
                sw.Write(value);
                sw.Close();
            }
        }

        static void Main(string[] args)
        {
            var data = Console.ReadLine()?.Split();
            if (data == null) return;
            var count = Convert.ToInt32(data[0]);
            var filename = pathData + data[1] + ".xml";
            string format = "xml";
            GenerateForGroups(count, filename, format);
        }

        static void GenerateForGroups(int count, string filename, string format)
        {
            var groups = new List<string>();
            for (var i = 0; i < count; i++)
            {
                groups.Add($"fid-{Fid}");
                Fid++;
            }

            using var writer = new StreamWriter(filename);
            if (format == "xml")
            {
                WriteGroupsToXmlFile(groups, writer);
            }
            else
            {
                Console.Out.Write("Unrecognized format" + format);
            }

            writer.Close();
        }

        static void WriteGroupsToXmlFile(List<string> groups, TextWriter writer)
        {
            new XmlSerializer(typeof(List<string>)).Serialize(writer, groups);
        }
    }
}