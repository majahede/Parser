
using System;

namespace parser
{
    class Exclamation : Sentence
    {
    public override string EndType => "!";

    public override void SetStyling() {
      Console.ForegroundColor = ConsoleColor.Green;
    }
  }
}