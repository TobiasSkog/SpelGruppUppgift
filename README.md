# SpelGruppUppgift
# Deltagare: Yarub Adnan, Peter Molen, Tobias Skog, Carl Fransson, Patrik Petterson

# **BESKRIVNING**

I den här övningen ska ni tillsammans i er grupp skapa ett spel som har olika avslut beroende på vad användaren väljer. Det ska bli som ett berättelse som ni ska själva bygga ihop inom gruppen.  

## **Instruktioner:**
1- Skapa ett nytt projekt (Console App) för ditt spel.
2- Välj ett tema för spelet. Till exempel, "Hitta vägen ut ur grottan." Här vill jag att ni ägnar lite tid med att diskutera inom gruppen vilket tema för berättelsen ni vill ha.
3- Skapa 5-8 olika metoder i din C#-kod. Varje metod representerar en nivå i spelet.
4- Varje nivå ska ha en uppgift, en utmaning eller ett val som spelaren måste lösa. Vilken typ det blir bestämmer ni själva utifrån temat. Man kanske har en kombination av dem tre.
5- Låt spelaren göra val vid varje nivå. Använd en int-variabel för att spara spelarens val när du anropar metoden.
6- Skicka värdet av spelarens val till nästa nivås metod som en parameter. Till exempel, om spelaren väljer 1 i nivå 1, skicka detta val till nivå 2:s metod.
7- Använd if-satser eller switch-case i varje nivå för att hantera olika val baserat på användarens tidigare val. Om användaren valde 1 i nivå 1, låt dem få se olika val än om de valde 2.

# OBS: Det värdet som skickas från nivå 1 till nivå två används bara för att visa olika val till användaren. Användaren ska fortfarande få välja själv vad man vill göra i varje nivå.

8- Upprepa steg 6 och 7 för varje nivå för att skapa en följd av händelser som påverkas av spelarens tidigare val.
9- Skapa en enda metod kallad "Ending" som tar en in-parameter baserat på den sista nivån som spelaren körde. Använd switch-case i "Ending" för att hantera olika slutalternativ baserat på spelarens val i den sista nivån.
