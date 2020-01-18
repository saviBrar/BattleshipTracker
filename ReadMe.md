Battleship Tracker
This is a small API that tracks the state of the battleship.

The Task
The task is to implement a Battleship state tracking API for a single player that must support the following logic:
• Create a board
• Add a battleship to the board
• Take an “attack” at a given position, and report back whether the attack resulted in a hit or a miss.
The API should not support the entire game, just the state tracker. No graphical interface or persistence layer is required.


Built With
1. .Net Core 3.0 Web API
2. C#
3. NUnit
4. JSON

TDD development following SOLID principles. 

Assumptions
1. We are not creating the whole game. 
2. There would be a client which would consume the API
3. There is no persistence layer or client layer
4. There can be n number of ships available
5. The ship can be of n width but should not expand beyond the board
6. The board state is maintained in the URL with "LocalB" variable

Further Enhancements
1. The battleship health is not maintained at this point but going further another property needs to be introduced
2. The HasSunk property needs to be introduced to the Battleship Entity
3. Need to introduce new entity to maintain player information alongwith whether they have lost or won the game
4. Persisitence layer to be introduced to ensure all the information is persisted
5. Firing board can be introduced to maintain separately the information of hits and misses
6. GUI layer


