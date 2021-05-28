# Mastermind


## Original Request

Create a  application that is a simple version of Mastermind.  
The randomly generated answer should be four (4) digits in length, that representive a color, with each digit between the numbers 0 and 5.  
After the player enters a combination, a minus (0) black sign should be printed for every digit that is both correct and in the correct position. (1) white sign should be printed for every digit that is correct but in the wrong position. (2) Gray incorrect digits.  The player has ten (5) attempts to guess the number correctly before receiving a message that they have lost.

Publish the source code to Github and provide your Github profile. 

## Identified Requirements

- C# Console application
- Randomly generated code [1-6]{4}
- Player enters a guess:
  - Display "0" for each digit that is correct and in correct position
  - Display "1" for each digit that is correct but in wrong position
  - Display "2" for each incorrect digit
- After 5 incorrect guesses, the player loses
- At end of game, display message indicating whether they won or lost
