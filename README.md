![Logo_FINKI_UKIM](https://github.com/eroolls4/Chess/assets/105580067/d9c47cf2-55c5-40c5-ae18-1c1590f03607)
# Chess Game - Visual Programming Project,FCSE SKOPJE.

This project is a .NET-based chess game that allows two players to play a game of chess with all the rules of modern chess. The project is divided into two main parts:

- **Backend**: Implements the entire game logic.
- **Frontend**: User interface built as a WPF (Windows Presentation Foundation) application.

Authors:
- **Eroll Sakipi**
- **Drin Kadriu**

Mentors:
- **Prof. Dr. Dejan Gjorgjevikj**
- **MSc Stefan Andonov**

## Note

**Please note that this README is just a short resume of the project. For detailed information, download the full documentation from the repository.*

## Table of Contents

- [Backend](#backend)
  - [Moves](#moves)
  - [Pieces](#pieces)
  - [Game Logic](#game-logic)
- [Frontend](#frontend)
  - [User Interface Components](#user-interface-components)
  - [XAML Files](#xaml-files)
- [Game Rules](#game-rules)
- [How to Run the Project](#how-to-run-the-project)

## Backend

The backend contains the core logic for the chess game, including move validation, piece movements, game state management, and rule enforcement. It is organized into several folders and files as follows:

### Moves

- **Castle.cs**: Handles the logic for castling moves.
- **DoublePawn.cs**: Implements logic for double pawn moves.
- **EnPassant.cs**: Contains logic for the En Passant move.
- **Moves.cs**: The base class for all move types.
- **NormalMove.cs**: Implements the logic for regular moves.
- **PawnPromotion.cs**: Handles pawn promotion logic.

### Pieces

- **Bishop.cs**: Defines the behavior of the Bishop piece.
- **King.cs**: Defines the behavior of the King piece.
- **Knight.cs**: Defines the behavior of the Knight piece.
- **Pawn.cs**: Defines the behavior of the Pawn piece.
- **Piece.cs**: Base class for all chess pieces.
- **Queen.cs**: Defines the behavior of the Queen piece.
- **Rook.cs**: Defines the behavior of the Rook piece.

### Game Logic

- **Board.cs**: Represents the chess board and manages piece placement.
- **Direction.cs**: Utility class for defining movement directions.
- **END_GAME_REASONS.cs**: Enumerates possible reasons for game termination.
- **GameState.cs**: Maintains the current state of the game.
- **MOVE_TYPE.cs**: Enumerates different types of moves.
- **PIECE_TYPE.cs**: Enumerates different types of chess pieces.
- **Player.cs**: Represents a player in the game.
- **Position.cs**: Utility class for managing positions on the board.
- **Result.cs**: Stores the result of a game.

## Frontend

The frontend is built using WPF, providing a graphical interface for the players. It includes various XAML files and their corresponding C# code-behind files to manage the UI.

### User Interface Components

- **Assets**: Folder containing game assets such as images and icons.
- **App.xaml & App.xaml.cs**: Entry point of the WPF application.
- **AssemblyInfo.cs**: Contains assembly-level attributes.
- **ChessCursors.cs**: Manages custom cursors for the game.
- **GameOverMenu.xaml & GameOverMenu.xaml.cs**: UI for the game-over screen.
- **Images.cs**: Manages the images used in the UI.
- **MainWindow.xaml & MainWindow.xaml.cs**: The main window of the application where the game is played.
- **OPTION.cs**: Manages game options.
- **PauseMenu.xaml & PauseMenu.xaml.cs**: UI for the pause menu.
- **PromotionMenu.xaml & PromotionMenu.xaml.cs**: UI for pawn promotion.

## Game Rules

This game implements all the standard rules of modern chess, including:

- Piece movements
- Castling
- En Passant
- Pawn promotion
- Check and checkmate
- Stalemate
- Draw conditions (e.g., threefold repetition, fifty-move rule)

## How to Run the Project

To run the project, follow these steps:

1. Clone the repository: `git clone https://github.com/eroolls4/Chess`
2. Open the solution file in Visual Studio.
3. Build the solution to restore dependencies and compile the project.
4. Run the project using Visual Studio.




