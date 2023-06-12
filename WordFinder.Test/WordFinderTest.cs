namespace WordFinder.Test
{
    public class WordFinderTest
    {
        [Fact]
        public void TestFindWordsInMatrixWithMatches()
        {
            var matrix = new List<string>()
            {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };

            var patterns = new List<string>()
            {
                "cold",
                "wind",
                "snow",
                "chill"
            };

            var wordFinder = new WordFinder(matrix);
            var results = wordFinder.Find(patterns);

            Assert.Equal(3, results.Count());
        }

        [Fact]
        public void TestFindWordsInMatrixWithMatchesAndDuplicatedWordStream()
        {
            var matrix = new List<string>()
            {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };

            var patterns = new List<string>()
            {
                "cold",
                "cold",
                "wind",
                "snow",
                "chill"
            };


            var wordFinder = new WordFinder(matrix);
            var results = wordFinder.Find(patterns);

            Assert.Equal(3, results.Count());
        }

        [Fact]
        public void TestFindWordsInMatrixWithNoMatches()
        {
            var matrix = new List<string>()
            {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };

            var patterns = new List<string>()
            {                
                "codd",
                "wins",
                "snow",
                "chils"
            };

            var wordFinder = new WordFinder(matrix);
            var results = wordFinder.Find(patterns);

            Assert.Empty(results);
        }

        [Fact]
        public void TestIsValidMaxMatrixSizeGood()
        {
            var matrix = new List<string>()
            {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };

            var result = WordFinder.IsValidMaxMatrixSize(matrix);
            Assert.True(result);

        }

        [Fact]
        public void TestIsValidMaxMatrixSizeBad()
        {
            var matrix = new List<string>()
            {
                "abcdcasdfslksjieslfkwwdapskfwpwodkdospwlejgspdlqjqpdlfwjwpfosdjwpelgjspfofpsldkpwoepwoegsldk",
                "abcdcasdfslksjieslfkwwdapskfwpwodkdospwlejgspdlqjqpdlfwjwpfosdjwpelgjspfofpsldkpwoepwoegsldk",
                "abcdcasdfslksjieslfkwwdapskfwpwodkdospwlejgspdlqjqpdlfwjwpfosdjwpelgjspfofpsldkpwoepwoegsldk"
            };

            var result = WordFinder.IsValidMaxMatrixSize(matrix);
            Assert.False(result);

        }

        [Fact]
        public void TestIsValidMatrixRowsGood()
        {
            var matrix = new List<string>()
            {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };

            var result = WordFinder.IsValidMatrixRows(matrix);
            Assert.True(result);

        }

        [Fact]
        public void TestIsValidMatrixRowsBad()
        {
            var matrix = new List<string>()
            {
                "abcdc",
                "fgwiosdf",
                "chill",
                "pqnsdasd",
                "uvdxydd"
            };

            var result = WordFinder.IsValidMatrixRows(matrix);
            Assert.False(result);

        }

        [Fact]
        public void TestCreateInvertedMatrix()
        {
            var matrix = new List<string>()
            {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };

            var expectedInvertedMatrix = new List<string>()
            {
                "afcpu",
                "bghqv",
                "cwind",
                "dilsx",
                "coldy"
            };

            var actualInvertedMatrix = WordFinder.CreateInvertedMatrix(matrix);
            Assert.Equal(expectedInvertedMatrix, actualInvertedMatrix);

        }

    }
}