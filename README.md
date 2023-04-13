# Word-Quest

A C# software with GUI that uses 3 string matching algorithms (BF, RK and KMP) for efficient word search.

Word-Search is a C# software with a graphical user interface that uses 3 string matching algorithms i.e. Brute-Force, Rabin-Karp and Knuth-Morris-Pratt to search for specific words or phrases in large volumes of text data. It finds the position of search word or sequence of words from given files and return file name, row number and column number. 4 different combinations of whole word and case match searching are also available. 

## Functionalities<br>
a) Program must find the position of search word or sequence of words from given files and return name of file, row number and column number.

b) Match whole word only [Unchecked]<br>
  -> Program should return Pakistan, adampak, abnopakis, and pak against ‘pak’ searched word because ‘pak’ is present in all of them. The length of return word and search word may differ.

c) Match whole word only [Checked]<br>
  -> Program should return only pak against ‘pak’ searched word. The length of return word and search word should be same.

d) Match case [Unchecked]<br>
  -> Program should return Bilal, bilaL, bIlaL against ‘bilal’. The upper and lower case should not be checked

e) Match case [Checked]<br>
  -> Program should only return bilal against bilal and BilaL against BilaL. The upper and lower case should be checked against each character.

## Use Cases<br>
This software can be used for analyzing large volumes of data such as resumes, medical records, financial documents and legal contracts.  

NOTE: Use Visual Studio to run this code.
