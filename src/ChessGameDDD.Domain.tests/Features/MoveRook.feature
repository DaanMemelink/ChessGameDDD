Feature: Move a rook
	A rook piece making a move on the chess board.

@Rook
Scenario: Moving direction of a rook
	This scenario describes in which direction a rook can move.

	Given there is a board with a rook on 'd5'
	When I want to move the piece on 'd5'
	Then it can be moved to the following locations
		|   | a | b | c | d | e | f | g | h |
		| 1 | . | . | . | x | . | . | . | . |
		| 2 | . | . | . | x | . | . | . | . |
		| 3 | . | . | . | x | . | . | . | . |
		| 4 | . | . | . | x | . | . | . | . |
		| 5 | x | x | x | R | x | x | x | x |
		| 6 | . | . | . | x | . | . | . | . |
		| 7 | . | . | . | x | . | . | . | . |
		| 8 | . | . | . | x | . | . | . | . |

@Rook
Scenario: Moving direction with other pieces
	This scenario describes how a rook can move when there are other pieces in the moving directions

	Given there is a board with a rook on 'd5'
	And there is a pawn on 'd3'
	When I want to move the piece on 'd5'
	Then it can be moved to the following locations
		|   | a | b | c | d | e | f | g | h |
		| 1 | . | . | . | . | . | . | . | . |
		| 2 | . | . | . | . | . | . | . | . |
		| 3 | . | . | . | P | . | . | . | . |
		| 4 | . | . | . | x | . | . | . | . |
		| 5 | x | x | x | R | x | x | x | x |
		| 6 | . | . | . | x | . | . | . | . |
		| 7 | . | . | . | x | . | . | . | . |
		| 8 | . | . | . | x | . | . | . | . |
