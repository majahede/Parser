using tokenizer;

namespace parser
{
    class SentenceFactory
    {
        public Sentence GetSentenceType(TokenMatch endType) {
            return endType.Token switch
            {
              "DOT" => new RegularSentence(),
              "EXCLAMATIONMARK" => new Exclamation(),
              "QUESTIONMARK" => new Question(),
              _ => null,
            };
        }
    }
}