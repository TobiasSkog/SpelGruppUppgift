namespace SpelGruppUppgift
{
  internal class Program
  {
    static void Main(string[] args)
    {

      //TEMA: Vilse i skogen
      //MÅL: Hitta ut ur skogen

      // Välkomnar användaren till spelet
      Console.WriteLine("Du är fast i stor mörk skog! Försök att ta dig ut innan tiden tar slut!");

      // Returnen från alla nivåer kommer vara spelarens highScore!
      // Startar spelet genom att anropa LevelOne()
      int highScore = LevelOne();
      // Spelet är slut och vi har fått tillbaka värdet på våran highScore

      // Informerar användaren att den vunnit och hur highScore
      Console.WriteLine($"Grattis! Du fick {highScore} poäng!");
    }

    // Metod för att verifiera användarens val
    // Tar 2st inputs
    // 1. är en string gameQuestion. Frågan vi vill ställa användaren
    // 2. är en int maxChoices. Max antal alternativ användaren kan välja mellan

    public static int GetUserChoice(string gameQuestion, int maxChoices)
    {
      // Skriver ut frågan till användaren
      Console.WriteLine(gameQuestion);
      // Skapar en oändligt loop för att verifiera användarens svar
      // så att vi kan få en godkänd int med TryParse
      do
      {
        // OM TryParse lyckas omvanlda det användaren skriver in
        // så skapar vi en ny int "userChocie"
        if (int.TryParse(Console.ReadLine(), out int userChoice))
        {
          // TryParse lyckades, kontrollerar så att valet är större än
          // 0 och mindre eller lika med maxChoices
          if (userChoice > 0 && userChoice <= maxChoices)
          {
            // userChoice uppfyllde kraven för ett godkänd värde
            // returnerar userChoice
            return userChoice;
          }

          // TryParse lyckades men userChoice vad mindre än 0 eller större än max antalet val
          // Informerar användaren om felet och loopen körs igen
          Console.WriteLine($"{userChoice} är inte ett giltigt val! Välj mellan (1 - {maxChoices}).");
        }
        else
        {
          // TryParse misslyckades, värdet kunde inte omvandlas till en integer
          // Informerar användaren om felet och loopen körs igen
          Console.WriteLine($"Ditt val måste vara ett heltal! Välj mellan (1 - {maxChoices}).");
        }
      } while (true);

    }

    // Metod som hanterar användarens score
    // Tar 2st inputs
    // 1. int scorePenalty = 0. Om vi ska ta bort poäng från användaren så anger vi det här, default värde på 0
    // 2. int userScore = 100. Nuvarande värdet för användaren, om vi skapar ett nytt spel har vi inget score och
    // använder oss av default värdet på 100
    public static int GetUserScore(int scorePenalty = 0, int userScore = 100)
    {
      // returnerar direkt userScore - scorePenalty
      return userScore - scorePenalty;
    }

    // Första nivån har en input på int userScore = 100
    // Detta är för att första gången vi skapar spelet behöver
    // vi inte tilldela ett värde, men om vi gör ett val som
    // tar oss tillbaka hit så kan vi då uppdatera med användarens
    // nuvarande userScore
    public static int LevelOne(int userScore = 100)
    {
      // Skapar en ny int userChoice som kommer få värdet från vår metod GetUserChoice
      // Denna variabel skickar vi sedan vidare till nästa nivå för att bestämma vad
      // vi ska göra baserat på användarens val här
      int userChoice;

      // Skriver ut beskrivningen för nivån
      Console.WriteLine("Du har kommit fram till en flod!");

      // Kallar metoden GetUserChoice med frågan av vad användaren vill göra, metoden returnerar sedan valet.
      userChoice = GetUserChoice("Vad vill du göra? \n(1): Försök gå över floden. \n(2): Gå vänster längst floden. \n(3): Gå höger längst floden.\n", 3);

      // Använder return för att skicka vidare userChoice och userScore så vi har det med oss genom hela spelets gång
      return LevelTwo(userChoice, userScore);
    }

    public static int LevelTwo(int userChoice, int userScore)
    {
      // Beroende på vad användaren valde på förra nivån så får den olika utskrifter
      // Väljer vilken typ av utskrift och handling vi ska ta med en switch baserat på input userChoice
      switch (userChoice)
      {
        case 1:
          // Skriver ut beskrivningen för nivån
          Console.WriteLine("Vattnet var så strömt att du fördes tillbaka till första nivån.");

          // Använder return för att skicka vidare userChoice och userScore så vi har det med oss genom hela spelets gång
          // Vi för in metoden GetUserScore(25, userScore) som input till LevelOne
          // GetUserScore vill ha 2 inputs, den första är penalty och den andra är nuvarande score
          // Detta alternativet tar anvädnaren tillbaka till första nivån, så vi ger ett straff på -25 poäng
          return LevelOne(GetUserScore(25, userScore));

        case 2:
          // Skriver ut beskrivningen för nivån
          Console.WriteLine("Efter timmar av vandring så komer du äntligen till en liten by! Efter kontakt med länsman har hen fått tag på dina föräldrar och skjuts kanske är på ingång.");

          // Kallar metoden GetUserChoice med frågan av vad användaren vill göra, metoden returnerar sedan valet.
          userChoice = GetUserChoice("Vad vill du göra? \n(1): Hoppas att dina päronen kommer och hämtar dig. \n(2): Ta den lokala bussen hem.", 2);

          // Använder return för att skicka vidare userChoice och userScore så vi har det med oss genom hela spelets gång
          // Vi för in metoden GetUserScore(10, userScore) som input till LevelOne
          // GetUserScore vill ha 2 inputs, den första är penalty och den andra är nuvarande score
          // Detta alternativet tar anvädnaren till nivå 3, och ett straff på -10 poäng
          return LevelThree(userChoice, GetUserScore(10, userScore));

        case 3:
          // Skriver ut beskrivningen för nivån
          Console.WriteLine("Du kommer ihåg att du bor ju bara några meter till höger från floden där du började leka! Du kom hem direkt!");

          // Använder return för att skicka vidare userChoice och userScore så vi har det med oss genom hela spelets gång
          // Vi för in metoden GetUserScore(0, userScore) som input till LevelOne
          // GetUserScore vill ha 2 inputs, den första är penalty och den andra är nuvarande score
          // Detta alternativet tar anvädnaren till nivå 3, och inget straff
          // Vi måste dock ge ett värde här, även om default scorePenalty = 0 och vi vill bara skicka vidare userScore
          // Om vi skickar in GetUserScore(userScore) så kommer vi ge en penalty på nuvarande userScore och ta bort det 
          // från userScore default värde på 100 i metoden GetUserScore
          // Så notera vikten med att ha med båda värdena här!
          return LevelThree(3, GetUserScore(0, userScore));

        default:
          // default kallas om userChoice var allt annat än 1, 2 eller 3.
          // Vi returnerar -2 som ett verktyg för att kunna debugga om ett fel
          // uppstod i nivå 2 för att lättare hitta det
          return -2;
      }
    }

    public static int LevelThree(int userChoice, int userScore)
    {
      switch (userChoice)
      {
        case 1:
          // Skriver ut beskrivningen för nivån
          Console.WriteLine("Dina föräldrar fick problem med bilen och står nu fast i ödemarken!");

          // Kallar metoden GetUserChoice med frågan av vad användaren vill göra, metoden returnerar sedan valet.
          userChoice = GetUserChoice("Vad vill du göra? \n(1): Gå hem. \n(2): Ta den lokala bussen hem.", 2);

          // Använder return för att skicka vidare userChoice och userScore så vi har det med oss genom hela spelets gång
          // Vi för in metoden GetUserScore(10, userScore) som input till LevelOne
          // GetUserScore vill ha 2 inputs, den första är penalty och den andra är nuvarande score
          // Detta alternativet tar anvädnaren till nivå 4, och ett straff på -10 poäng
          return LevelFour(userChoice, GetUserScore(10, userScore));

        case 2:
          // Använder return för att skicka vidare userChoice och userScore så vi har det med oss genom hela spelets gång
          // Vi för in metoden GetUserScore(10, userScore) som input till LevelOne
          // GetUserScore vill ha 2 inputs, den första är penalty och, och inget straff
          // Vi måste dock ge ett värde här, även om default scorePenalty = 0 och vi vill bara skicka vidare userScore
          // Om vi skickar in GetUserScore(userScore) så kommer vi ge en penalty på nuvarande userScore och ta bort det 
          // från userScore default värde på 100 i metoden GetUserScore
          // Så notera vikten med att ha med båda värdena här!
          return FinalLevel(userChoice, GetUserScore(0, userScore));

        default:
          // default kallas om userChoice var allt annat än 1 eller 2.
          // Vi returnerar -3 som ett verktyg för att kunna debugga om ett fel
          // uppstod i nivå 3 för att lättare hitta det
          return -3;
      }

    }

    public static int LevelFour(int userChoice, int userScore)
    {
      // Skriver ut beskrivningen för nivån
      Console.WriteLine("Du gick vilse på vägen hem! Du är fast i stor mörk skog... Igen");

      // Använder return för att skicka vidare userChoice och userScore så vi har det med oss genom hela spelets gång
      // Vi för in metoden GetUserScore(25, userScore) som input till LevelOne
      // GetUserScore vill ha 2 inputs, den första är penalty och den andra är nuvarande score
      // Detta alternativet tar anvädnaren tillbaka till första nivån, så vi ger ett straff på -25 poäng
      return LevelOne(GetUserScore(25, userScore));
    }

    public static int FinalLevel(int userChoice, int userScore)
    {
      // Skriver ut beskrivningen för nivån
      Console.WriteLine("Du är äntligen hemma!");

      // Spelet är slut! Returnerar användarens slutgiltiga poäng!
      return (userScore);
    }

  }
}