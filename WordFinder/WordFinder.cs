using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WordFinder.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WordFinder
{
    public class WordFinder
    {
        private const int MaxMatrixSize = 64;
        private const char WordSeparator = ',';
        public string UnifiedString { get; set; }

        public WordFinder(IEnumerable<string> matrix)
        {
            var invertedMatrix = CreateInvertedMatrix(matrix);
            var horizontalString = string.Join(WordSeparator, matrix);
            var verticalString = string.Join(WordSeparator, invertedMatrix);

            this.UnifiedString = string.Join(WordSeparator, new string[2] { horizontalString, verticalString });
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            wordstream = wordstream.Distinct();
            var results = new List<FindResult>();

            foreach (var pattern in wordstream)
            {
                var result = new FindResult() { Match = pattern, Count = 0 };
                int a = 0;
                while ((a = this.UnifiedString.IndexOf(pattern, a)) != -1)
                {
                    a += pattern.Length;
                    result.Count++;
                }
                results.Add(result);
            }

            return results
                .Where(result => result.Count > 0)
                .OrderBy(result => result.Count)
                .Take(10)
                .Select(result => result.Match);
        }

        public static bool IsValidMatrixRows(IEnumerable<string> matrix)
        {
            var matrixSize = matrix.First().Length;
            var notEqualRow = matrix.Where(x => x.Length != matrixSize);

            return !notEqualRow.Any();
        }

        public static bool IsValidMaxMatrixSize(IEnumerable<string> matrix)
        {
            var matrixSize = matrix.First().Length;

            return !(matrixSize > MaxMatrixSize || matrix.Count() > MaxMatrixSize);

        }

        public static IEnumerable<string> CreateInvertedMatrix(IEnumerable<string> matrix)
        {
            List<char[]> verticalArrays = new List<char[]>();
            var matrixSize = matrix.First().Length;

            for (int x = 0; x < matrixSize; x++)
            {
                var row = new char[matrixSize];
                for (int y = 0; y < matrixSize; y++)
                {
                    row[y] = matrix.ElementAt(y)[x];
                }
                verticalArrays.Add(row);
            }
            var verticalStream = verticalArrays.Select(x => new string(x));

            return verticalStream;
        }
    }

}
