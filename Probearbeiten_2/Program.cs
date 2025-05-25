using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Probearbeiten_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Bitte den Pfad zur CSV-Datei eingeben: ");
            string csvPath = Console.ReadLine();

            if (!File.Exists(csvPath))
            {
                Console.WriteLine("Die angegebene Datei existiert nicht.");
                return;
            }

            try
            {
                List<string[]> rows = new List<string[]>();

                // CSV-Datei einlesen
                foreach (var line in File.ReadLines(csvPath))
                {
                    // Trennen der CSV-Zeilen anhand von Kommas (kann angepasst werden)
                    string[] columns = line.Split(',');
                    rows.Add(columns);
                }

                if (rows.Count == 0)
                {
                    Console.WriteLine("Die Datei ist leer.");
                    return;
                }

                // Bestimme die maximale Breite jeder Spalte
                int columnCount = rows.Max(r => r.Length);
                int[] columnWidths = new int[columnCount];

                foreach (var row in rows)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        columnWidths[i] = Math.Max(columnWidths[i], row[i].Length);
                    }
                }

                // Ausgabe der formatierten Tabelle
                foreach (var row in rows)
                {
                    for (int i = 0; i < columnCount; i++)
                    {
                        string value = i < row.Length ? row[i] : "";
                        Console.Write(value.PadRight(columnWidths[i]));
                        if (i < columnCount - 1)
                            Console.Write(" | ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Verarbeiten der Datei: {ex.Message}");
            }
        }
    }
}
