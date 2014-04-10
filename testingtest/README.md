Testframework
=============

Aufgabe
-------

Auswertung von Unit Tests.

Verwendung
----------

./test.rb \<programm\> [args]

 * programm:  programmname (mit Pfadangabe!)
 * args: Kommandozeilenparameter, mit denen der Testmodus gestartet wird

Ein im Testmodus gestartetes Programm sollte Ausgaben in folgendem Format erzeugen:

     <id> 
     <expected> 
     §§§ 
     <got> 
     §§§ 
     [...]

 * id:       Name des Tests (zur Identifikation)
 * expected: String, der erwartet wird
 * got:      Ergebnis des Tests

Ausgabe
-------

     test:                                   // Testsektion (später vllt noch Profiling)
     > id1: ok                               // Test 1 erfolgreich
     > id2: fail!                            // Test 2 fehlgechlagen
     >  . asd                                // Zeile ok
     >  ! expected: 'asd', got: 'qwe'        // hier stimmt was nicht
     >  . asd                                // Zeile wieder ok
     > id3: fail!                            // Test 3 wieder fehlerhaft
     >  . asd
     >  . qwe
     >  ! expected: 'asd', got: '<nothing>'  // eine Zeile mehr erwartet als vom Test
                                             // erzeugt
