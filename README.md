# Parser

## Classes

### `Document`

The Document class parses a text and finds the different types of sentences in the text.

```c#
   Document d = new Document();
```

## Methods

### `Parse(string text)`
Takes a string as argument. It creates a tokenizer and a grammar and parses the passed string.
```c#
   d.Parse("I love parsers. Are they fun? Yes! They are fun.");
```

### `GetAllSentences()`
Returns all sentences.

### `GetAllRegularSentences()`
Returns all regular sentences.

### `GetAllQuestions()`
Returns all Questions

### `GetAllExclamations()`
Returns all Exclamations.

# PrettyPrinter

## Classes

### `PrettyPrinter`

PrettyPrinter prints out a document as a formatted list. 

```c#
   PrettyPrinter pp =  new PrettyPrinter(d);
```

### `PrettyPrinter`

## Methods
### `PrintAllSentences()`
Prints all sentences.

### `PrintAllRegularSentences()`
Prints all regular sentences.

### `PrintAllQuestions()`
Prints all Questions

### `PrintAllExclamations()`
Prints all Exclamations.

# Example
```c#
    Document d = new Document();
    d.Parse("I love parsers. Are they fun? Yes! They are fun.");

    PrettyPrinter pp =  new PrettyPrinter(d);
    pp.PrintAllSentences();
    pp.PrintAllRegularSentences();
    pp.PrintAllQuestions();
    pp.PrintAllExclamations();
```
### Output
![OutPut](img/prettyPrinter.JPG)

