# Alex Toapanta QuChallenge
Tech stack
- .Net Core 7 - console app
- xUnit

Running the project
- Clone the repo.
- Restore nugget packages for the solution.
- Enjoy ! 

Challenge Description

Presented with a character matrix and a large stream of words, your task is to create a Class
that searches the matrix to look for the words from the word stream. Words may appear
horizontally, from left to right, or vertically, from top to bottom. In the example below, the word
stream has four words and the matrix contains only three of those words ("chill", "cold" and
"wind"):

The search code must be implemented as a class with the following interface:
```
public class WordFinder
{
  public WordFinder(IEnumerable<string> matrix) 
  {
  ...
  }
  public IEnumerable<string> Find(IEnumerable<string> wordstream)
  { ...
  }
}
```
# Acceptance Criteria
The WordFinder constructor receives a set of strings which represents a character matrix. The
matrix size does not exceed 64x64, all strings contain the same number of characters. The
"Find" method should return the top 10 most repeated words from the word stream found in the
matrix. If no words are found, the "Find" method should return an empty set of strings. If any
word in the word stream is found more than once within the stream, the search results
should count it only once

# Personal way of solving the problem 
Given the condition that words can only be found from left to right and from top to bottom the only real challenge is to find matches in columns from top to botoom. 
To solve this issue I decided to write a method to invert the matrix, once I was able to create the inverted matrix I put together all the elements and separate them by using the reserved charater ( , ).

Finally we search for matches in one big strings that contains all the rows and columns together, we sort them via linq and process the answer.

I hope you find this creative as I did. 

Greetings 
Alex Toapanta

