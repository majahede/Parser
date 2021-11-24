using System;


namespace parser
{
    class Question : Sentence
    {
        public override string EndType => "?";
    

        public override void SetStyling() 
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }
}