# Lab 1: SQL SchoolNET

<aside>
**Skapa en databas**

Skapa en enkel databas som lagrar följande. Databasen behöver inte ha någon avancerad arkitektur.

- [ ]  Elever
- [ ]  Klasser som eleverna kan tillhöra
- [ ]  Kurser
- [ ]  Betyg som en viss elev fått i en viss kurs (lagra som siffror)
- [ ]  Personal som kan tillhöra olika kategorier (ex. lärare, administratör, rektor)
</aside>

<aside>
**Skapa grunden till applikation**

- [ ]  Skapa ett nytt console-program i C#
- [ ]  Skapa en enkel navigation i programmet som gör att användaren kan välja mellan funktionerna nedan. Här räcker det med en enkel case-sats och att användaren matar in en siffra för att navigera till en viss funktion.
- [ ]  När en funktion körts ska användaren kunna klicka enter och komma tillbaka till huvudmenyn igen.
</aside>

<aside>
**Skapa funktionaliteten**

Du ska skapa följande funktioner som användaren kan navigera till i applikationen. Alla dessa funktioner ska lösas genom ren SQL och inte med någon ORM.

1. **Hämta alla elever**
    
    Användaren får välja om de vill se eleverna sorterade på för- eller efternamn och om det ska vara stigande eller fallande sortering.
    
2. **Hämta alla elever i en viss klass**
    
    Användaren ska först få se en lista med alla klasser som finns, sedan får användaren välja en av klasserna och då skrivs alla elever i den klassen ut.
    
    Extra utmaning: låt användaren även få välja sortering på eleverna som i punkten ovan.
    
3. **Lägga till ny personal**
    
    Användaren ska ha möjlighet att mata in uppgifter om en ny anställd och den datan sparas då ner i databasen.
    
4. **Hämta personal**
    
    Användaren får välja om denna vill se alla anställda, eller bara inom en av kategorierna så som ex lärare.
    
5. **Hämta alla betyg som satts den senaste månaden**
    
    Här får användaren se en lista med alla betyg som satts senaste månaden där elevens namn, kursens namn och betyget framgår.
    
6. **Snittbetyg per kurs**
    
    Hämta en lista med alla kurser och det snittbetyg som eleverna fått på den kursen samt det högsta och lägsta betyget som någon fått i kursen.
    
    Här får användaren se en lista med alla kurser i databasen, snittbetyget samt det högsta och lägsta betyget för varje kurs.
    
    Tips: Det kan vara svårt att göra detta med betyg i form av bokstäver så du kan välja att lagra betygen som siffror i stället.
    
7. **Lägga till nya elever**
    
    Användaren får möjlighet att mata in uppgifter om en ny elev och den datan sparas då ner i databasen.
