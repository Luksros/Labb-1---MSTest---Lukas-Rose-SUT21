Labb 1 – MSUnit
Lukas Rose - SUT21

1. Loginfunktionen

Det jag tänker kan gå fel här är valideringen. Det kan vara viktigt att testa så att lösenordet är skiftlägeskänsligt, så att man måste vara noggrann när man skriver in det. Detta kan testas genom att göra ett test där man ger loginmetoden rätt inmatning och förvänta sig att få True returnerat, och sedan ett till test där man skriver in samma användarnamn men gör fel med kapitaliseringen av bokstäverna i lösenordet, och förväntar sig False i return. Jag vill också testa så att man inte kan råka matcha fel lösenord och användarnamn och ändå komma in. Då kan jag som test mata in ett användarnamn och ett lösenord som jag vet finns, men som inte matchar, och förvänta mig false som respons. 
   Användarnamn brukar inte behöva vara skiftlägeskänsliga, och för att testa det kan jag göra ett test där jag matar in all info helt rätt och förvänta mig true i retur, och ett till test med samma logininfo fast med fel kapitalisering i användarnamnet, och förvänta mig true där också. 

När jag skapade mitt första test insåg jag att MSTest absolut inte gillar att jobba med Console-funktioner, vilket gjorde att test misslyckades om och om igen även fast logiken i själva testet var helt rätt. När jag kommenterade ut allt som hade med Console att göra gick det fint. Problemet jag ställdes inför nu var att jag behövde flytta ut all den logiken till metoden som i programmet kallar på UserCheck-metoden, vilket skulle introducera massa if-satser jag redan använt i UserCheck. Hade dessa metoderna utvecklas på ett testdrivet sätt hade detta nog inte skett. 

När jag testade att skriva användarnamn utan att tänka på skiftläge insåg jag att våran logik inte tillät detta, så det fixade jag lite snabbt genom att lägga till en IgnoreCase, och sedan funkade det.


2. Intern överföring

Här bör man dels testa så att kontot man för över ifrån har rätt saldo efter överföringen, och testa samma sak mot det mottagande kontot. Här blir jag tvungen att modifiera koden lite, då metoden innehåller väldigt mycket kod, som även kräver input från användaren. För att göra testmiljön så kontrollerad som möjligt vill jag undvika detta. Dessutom så går det lätt att bryta ut logiken för själva överföringen från resten av metoden, som egentligen bara samlar in vilka konton som ska användas och vilket belopp som ska föras över, vilket jag ändå vill ha bestämt sedan innan i testmetoden.

En sak som slog mig när jag lade logiken för själva överföringen i en egen metod är att regleringen för valt belopp låg kvar i den andra metoden (alltså att man inte ska kunna välja negativt belopp eller övertrassera sitt konto etc.), vilket gjorde den nya metoden väldigt osäker. Därav fick jag lägga till lite logik för att förhindra felanvändning av metoden, och sen testa den logiken. 

Här hjälpte mina tester mig att hitta ett ganska grovt fel: i slutet av en överföring mellan två konton så körs metoden CurrencyConverter, som justerar överfört belopp beroende på kontonas valuta. Dock returnerade metoden 0 som belopp ifall kontona hade samma valuta, vilket jag ändrade till att returnera det inmatade beloppet. Dock så uppstod detta felet aldrig under körning av programmet, utan bara under testning, vilket förbryllar mig.


3. Ränteuträkning

Till sist väljer jag att testa metoden för ränteuträkning, CalcInterest. Det här valet beror mest på att metoden är enkel att testa, då det är en av få återstående metoder där jag inte behöver göra omfattande ändringar i kodflödet för att kunna testa, då nästan allt annat använder sig av Console-metoder på flera ställen. Här vill jag först och främst testa så att jag får förväntade resultat från uträkningen, med några enkla exempel. Det kan också vara bra att testa vad som händer när man använder sig av max- och minvärden på variabler, vilket lär vara att programmet kastar ett exception. Jag vill inte att räknaren ska tillåta ett negativt slutvärde, då detta inte skulle vara realistiskt, så jag vill skapa ett test som kollar så att resultat är större än 0. 

Alla test funkade väldigt bra här, men det där med negativa värden gav ju ett misslyckat försök först. Jag valde att lägga till en if-sats i CalcInterest-metoden som gör negativa värden positiva, då man rimligtvis aldrig menar att skriva in ett negativt värde i en sådan ränteuträkning på ett sparkonto eller ett lån. 
