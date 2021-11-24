using System;

namespace parser
{
    class RegularSentence : Sentence
    {
        public override string EndType => ".";

        public override void SetStyling() 
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
        }
    }
}