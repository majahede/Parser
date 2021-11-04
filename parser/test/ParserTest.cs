using System;
using Xunit;
namespace parser
{
  public class ParserTest
  {
    // Get all sentences
    [Fact]
    public void TC1()
    {
      Document d = new Document();
      d.Parse("a. b.");
      var sentences = d.GetAllSentences();
      Assert.Equal(2, sentences.Count);
    }

    // Get all regular sentences
    [Fact]
    public void TC2()
    {
      Document d = new Document();
      d.Parse("a! a. b. c. cc! a?");
      var sentences = d.GetAllRegularSentences();
      Assert.Equal(3, sentences.Count);
    }

    // Get all exclamations
    [Fact]
    public void TC3()
    {
      Document d = new Document();
      d.Parse("a! a. b. c. cc! a?");
      var sentences = d.GetAllExclamations();
      Assert.Equal(2, sentences.Count);
    }

    // Get all questions
    [Fact]
    public void TC4()
    {
      Document d = new Document();
      d.Parse("a! a. b. c. cc! a?");
      var sentences = d.GetAllQuestions();
      Assert.Single(sentences);
    }

    // Invalid sentence error if no words
    [Fact]
    public void TC5()
    {
      Document d = new Document();
      Assert.Throws<Exception>(() => d.Parse("a! . b."));
    }

    // Error No sentences
    [Fact]
    public void TC6()
    {
      Document d = new Document();
      Assert.Throws<Exception>(() => d.Parse(""));
    }

    // Error if empty string
    [Fact]
    public void TC7()
    {
      Document d = new Document();
      Assert.Throws<Exception>(() => d.Parse(" "));
    }

    // Correct number of words in first sentence
    [Fact]
    public void TC8()
    {
      Document d = new Document();
      d.Parse("a bb cc. b c!");
      Assert.Equal(3, d.GetAllSentences()[0].GetWords().Count);
    }

    // First sentence is an exclamation
    [Fact]
    public void TC9()
    {
      Document d = new Document();
      d.Parse("a ccc! a bb?");
      var sentences = d.GetAllSentences();
      Assert.Equal("!", sentences[0].EndType);
    }

    // Later sentence is a question
    [Fact]
    public void TC10()
    {
      Document d = new Document();
      d.Parse("a ccc! a bb?");
      var sentences = d.GetAllSentences();
      Assert.Equal("?", sentences[1].EndType);
    }

    // Correct endtype in sentence
    [Fact]
    public void TC11()
    {
      Document d = new Document();
      d.Parse("a ccc! a bb.");
      var sentences = d.GetAllSentences();
      Assert.Equal(".", sentences[1].EndType);
    }

    // Invalid sentence error if uknown symbol
    [Fact]
    public void TC12()
    {
      Document d = new Document();
      Assert.Throws<Exception>(() => d.Parse("a! bb. + b."));
    }

    // Correct letters in later word in later sentence
    [Fact]
    public void TC13()
    {
      Document d = new Document();
      d.Parse("a bC cc. b   Bc!");
      Assert.Equal("Bc", d.GetAllSentences()[1].GetWords()[1]);
    }
  }
}