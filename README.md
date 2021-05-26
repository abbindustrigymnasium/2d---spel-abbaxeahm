# Lumber Tycoon 2D

<img width="632" alt="LT2D" src="https://user-images.githubusercontent.com/69853455/119678829-256cbe00-be40-11eb-87fc-a0eec4dc8e3d.PNG">

## inledning

Spelet heter Lumber Tycoon 2D och är inspirerat av det populära roblox spelet Lumber Tycoon 2.
Spelet är byggt i spelmotorn Unity där man kan bygga många olika spel och applikationer snabbt och enkelt.
Spelet går ut på exakt samma sak som Lumber Tycoon 2 bara att spelet inte har lika många funktioner som Lumber Tycoon 2. 
Man ska fälla träd och sedan sälja det. För pengarna kan man köpa plantor som man kan plantera så man kan hugga fler träd. 
Man kan också köpa en motorsåg som gör att man fäller ner träd snabbare.

## Arbetsprocessen

Jag började med att spåna idéer och fastnade för att göra ett tycoon-spel dels för att jag tycker om sådana och dels för ingen verkade göra den typen av spel. Jag ville också använda mig av Unitys fysik och renderingsmotor och då blev ett Lumber Tycoon spel ett självklart val.
Tidigt hittade jag två bra assets en med terräng och en med animationer till karaktären vilket blev grunden i grafiken. Alla andra grafiska element behövde passa den stilen, medel upplöst pixel art. 
Terrängen är tile baserad alltså att terrängen består av ett rutnät där varje ruta har en textur t.ex gräs och jord. 
Med hjälp av detta system, tilemaps som ingår i Unity kan man enkelt och snabbt skapa ny varierad terräng.
Unity använder sig av C# som programmeringsspråk vilket är väldigt likt C++ som jag har programmerat i tidigare vilket gjorde det enkelt att programmera.
Men samtidigt behövde jag lära mig hur man använder Unitys funktioner i C# med tanke på att jag aldrig använt Unity förut.

Det som tog längst tid att programmera var träd huggnings och planterings funktionen. Programmet behövde ha koll på vilket träd man hugger eller vilka träd som är i närheten när man plantera. Det var klurigt men lösningen blev bra, funktion fungerar utan kända buggar.

## Resultat

Lumber Tycoon 2D blev ett bra spel relativt den tid vi fick. Spelet är helt funktionellt och innehåller inga kända buggar. Spelet har inget slut vilket gör att man kan spela det i en oändlighet men efter man har köpt motorsågen finns det inget direkt mål.
Min personliga favoritfunktion är att priset faller när du säljer trä. Många spel har den inbyggd men den är inte särskilt synlig och har inte stor påverkan. I detta spel faller priset med 5 % för varje träd man säljer vilket gör att man inte kan sälja att på samma gång för då skulle man sälja utan att gå med vinst. 

## Förbättringar

Om jag skulle utveckla spelet vidare så skulle jag göra om hugg funktionen. Jag skulle flytta stora delar av den till lokala scripts till varje träd och då kan varje träd ha en egen "health bar" och risken att blanda ihop träden med varandra är minimal. Dessutom skulle det bli enklare att lägga till nya trädarter.
Jag skulle också lägga till nya träd och yxor vilket gör att spelet mer varierat och roligare att spela.
