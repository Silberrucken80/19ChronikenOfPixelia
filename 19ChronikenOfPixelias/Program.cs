bool spielAktiv = true;

while (spielAktiv)
{
    // Variablen am Anfang richtig setzen
    int leben = 3;
    bool monsterBesiegt = false;
    bool zahlenschreckBesiegt = false;
    bool orakelwesenBesiegt = false;
    bool tempelGeschafft = false;

    // Einleitung
    Console.WriteLine("Du bist ein Bewohner von Lüxheim am südlichen Rand der Welt Pixelia.");
    Console.WriteLine("Du verbringst deine Tage mit Holz sammeln, Pilze suchen und dem alten Opa zuhören.");
    Console.WriteLine("Doch eines Nachts geschieht etwas Merkwürdiges:");
    Console.WriteLine("Ein seltsames Leuchten erscheint am Himmel, ein Stern fällt und schlägt in der Nähe des Dorfs ein.");
    Console.WriteLine("Seitdem träumst du jede Nacht von fremden Zeichen,");
    Console.WriteLine("flüsternden Stimme und einem leuchtenden Wesen, das deinen Namen kennt.");
    Console.WriteLine();

    Console.WriteLine("Gebe 1 ein, um das Abenteuer zu beginnen:");
    string eingabe = Console.ReadLine();

    while (eingabe != "1")
    {
        Console.WriteLine("Falsche Eingabe. Gebe 1 ein, um zu beginnen.");
        eingabe = Console.ReadLine();
    }
    Console.Clear();

    Console.WriteLine("Du gehst zum Dorfältesten. Er erzählt dir die Prophezeiung.");
    Console.WriteLine("Du bist der Auserwählte und musst den Pixelkern zurückbringen,");
    Console.WriteLine("damit das Gleichgewicht zwischen den Welten erhalten bleibt.");
    Console.WriteLine();

    Random zufall = new Random();
    string[] aktionen = { "angreifen", "ausweichen" };
    string richtigeAktion = aktionen[zufall.Next(0, 2)];
    Console.WriteLine("Du gehst in den Wald.");
    Console.WriteLine("Im Wald triffst du auf einen Schattenwolf!");

    // Kampf gegen Schattenwolf
    while (!monsterBesiegt && leben > 0)
    {
        Console.WriteLine("Willst du angreifen oder ausweichen?");
        string entscheidung = Console.ReadLine().ToLower();

        if (entscheidung == richtigeAktion)
        {
            Console.WriteLine("Du hast richtig reagiert! Der Schattenwolf ist besiegt.");
            monsterBesiegt = true;
        }
        else
        {
            leben--;
            if (leben > 0)
            {
                Console.WriteLine("Falsche Entscheidung! Du verlierst ein Leben.");
                Console.WriteLine($"Verbleibende Leben: {leben}");
            }
            else
            {
                Console.WriteLine("Du hast alle Leben verloren.");
                if (!NeustartFragen()) { spielAktiv = false; break; }
                else { Console.Clear(); continue; }
            }
        }
    }

    // Kampf gegen Zahlenschreck
    if (monsterBesiegt && leben > 0)
    {
        Console.WriteLine();
        Console.WriteLine("Ein Zahlenschreck erscheint! Errate eine Zahl zwischen 1 und 3.");

        bool richtigeZahlGefunden = false;
        int richtigeZahl = zufall.Next(1, 4);

        while (!richtigeZahlGefunden && leben > 0)
        {
            Console.WriteLine("Dein Tipp:");
            string eingabeZahl = Console.ReadLine();
            int tipp;

            if (int.TryParse(eingabeZahl, out tipp))
            {
                if (tipp == richtigeZahl)
                {
                    Console.WriteLine("Richtig! Du hast den Zahlenschreck besiegt.");
                    zahlenschreckBesiegt = true;
                    richtigeZahlGefunden = true;
                }
                else
                {
                    leben--;
                    if (leben > 0)
                    {
                        Console.WriteLine($"Falsch! Es war {richtigeZahl}. Verbleibende Leben: {leben}");
                        Console.WriteLine("Versuche es erneut:");
                    }
                }
            }
            else
            {
                leben--;
                Console.WriteLine($"Ungültige Eingabe! Leben verloren. Verbleibende Leben: {leben}");
            }
        }

        if (leben <= 0)
        {
            Console.WriteLine("Du hast alle Leben verloren.");
            if (!NeustartFragen()) { spielAktiv = false; break; }
            else { Console.Clear(); continue; }
        }
    }

    // Rätsel vom Orakelwesen
    if (zahlenschreckBesiegt && leben > 0)
    {
        Console.WriteLine();
        Console.WriteLine("Ein Orakelwesen stellt dir ein Rätsel:");
        Console.WriteLine("Was hat einen Hals, aber keinen Kopf?");

        bool richtigeAntwortGefunden = false;

        while (!richtigeAntwortGefunden && leben > 0)
        {
            string antwort = Console.ReadLine().ToLower();

            if (antwort == "flasche")
            {
                Console.WriteLine("Richtig! Du hast das Orakelwesen besiegt.");
                orakelwesenBesiegt = true;
                richtigeAntwortGefunden = true;
            }
            else
            {
                leben--;
                if (leben > 0)
                {
                    Console.WriteLine($"Falsche Antwort! Verbleibende Leben: {leben}");
                    Console.WriteLine("Versuche es erneut:");
                }
            }
        }

        if (leben <= 0)
        {
            Console.WriteLine("Du hast alle Leben verloren.");
            if (!NeustartFragen()) { spielAktiv = false; break; }
            else { Console.Clear(); continue; }
        }
    }

    // Tempel und Endrätsel
    if (orakelwesenBesiegt && leben > 0)
    {
        Console.WriteLine();
        Console.WriteLine("Du erreichst einen alten Tempel. Ein letztes Rätsel erwartet dich:");
        Console.WriteLine("Was hat vier Beine am Morgen, zwei am Mittag und drei am Abend?");

        bool richtigeAntwortGefunden = false;

        while (!richtigeAntwortGefunden && leben > 0)
        {
            string antwort1 = Console.ReadLine().ToLower();

            if (antwort1 == "mensch")
            {
                Console.WriteLine("Du hast den Pixelkern gefunden!");
                Console.WriteLine("Pixelia ist gerettet! Glückwunsch, du hast das Spiel gewonnen!");
                tempelGeschafft = true;
                spielAktiv = false;
                break;
            }
            else
            {
                leben--;
                if (leben > 0)
                {
                    Console.WriteLine($"Falsche Antwort! Verbleibende Leben: {leben}");
                    Console.WriteLine("Versuche es erneut:");
                }
                else
                {
                    Console.WriteLine("Der Tempel stürzt ein... GAME OVER");
                    if (!NeustartFragen()) { spielAktiv = false; break; }
                    else { Console.Clear(); continue; }
                }
            }
        }
    }
}

// Ende While-Schleife

// Methode für Neustart-Frage
static bool NeustartFragen()
{
    Console.WriteLine("Möchtest du neu starten? (j/n)");
    string neustart = Console.ReadLine().ToLower();
    return (neustart == "ja" || neustart == "j");
}


