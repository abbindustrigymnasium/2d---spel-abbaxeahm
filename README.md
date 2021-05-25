# Lumber Tycoon 2D

## inledning

Spelet heter Lumber Tycoon 2D och är inspererat av det populära roblox spelet Lumber Tycoon 2.
Spelet är byggt i spelmotorn Unity som man kan bygga många olika spel och applicationer snabbt.
Spelet går ut på exakt samma sak som Lumber Tycoon 2 bara att spelet inte har lika många funktioner som Lumber Tycoon 2. 
Man ska fälla träd och sedan sälja det. För pengarna kan man köpa plantor som man kan plantera så man kan hugga fler träd. 
Man kan också köpa en motorsåg som gör att man fäller ner träder snabbare.

## Arbetsprossesen

Med tanke på att det projektet syfte var att skapa ett enkelt unity spel ensam behövde jag inte skriva ner en planering. 
Jag hade i början en bild över exakt hur det skulle se ut och hade planeringen klar i huvudet. Tidigt hittade jag två bra assets en med terräng och en med animationer till karraktären vilket blev grunden i grafiken. Alla andra grafiska element behövde passa den stilen, medel upplöst pixel art. 
Terrängen är tile baserad alltså att terrängen består av ett rutnät där varje ruta har en textur t.ex gräs och jord. 
Med hjälp av detta system, tilemaps som ingår i Unity kan man enkelt och snabbt skapa ny varierad terräng.
Unity använder sig av C# som programmeringsspråk vilket är väldigt likt C++ som jag har programmerat i tidigare vilket gjorde det enkelt att programmera.
Men samtidigt behövde jag lära mig hur man använder Unitys funktioner i C# med tanke på att jag anldrig använt Unity förut.

Det som tog längst tid att programmera var träd huggnings och planterings funktionen. Programmet behövde ha koll på vilket träd man hugger eller vilka träd som är i närheten när man plantera.

## Resutat

Som helhet blev spelet bra. Få funktioner som sammarbetar bra.  
Till exempel de små funktionerna, att priset ändras när du säljer och att priset ändras lite hela tiden gör att spelet blir betydligt mer intressant och lägger till en dynamisk svårighetsgrad.
Om jag skulle utveckla spelet vidare så skulla jag göra om hugg funktionen. Jag skulle flytta stora delar av den till lokala scripts till varje träd och då kan varje träd har en egen "health bar" och risken att blanda ihop träd med varndra är minimal
Jag skulle också lägga till nya träd och yxor vilket gör att spelet mer varierat och roligare att spela.
