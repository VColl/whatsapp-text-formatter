Feature: GetTextFormatInfoFeature
	Testing the method GetTextFormatInfo of the class Text Formatter

Scenario Outline: Unformatted
	When I input the text <text>
	Then the property Text of the result should be <unformattedText>
	And the property Bolds of the result should be <bolds>
	And the property Italics of the result should be <italics>
	And the property StrikeThroughs of the result should be <strikeThroughs>

	Examples:
		| text                                         | unformattedText                              | bolds | italics | strikeThroughs |
		| The quick brown fox jumps over the lazy dog  | The quick brown fox jumps over the lazy dog  | {}    | {}      | {}             |
		| *The quick brown fox jumps over the lazy dog | *The quick brown fox jumps over the lazy dog | {}    | {}      | {}             |

Scenario Outline: Something Bold
	When I input the text <text>
	Then the property Text of the result should be <unformattedText>
	And the property Bolds of the result should be <bolds>
	And the property Italics of the result should be <italics>
	And the property StrikeThroughs of the result should be <strikeThroughs>

	Examples:
		| text                                            | unformattedText                             | bolds                | italics | strikeThroughs |
		| The quick brown *fox* jumps over the lazy dog   | The quick brown fox jumps over the lazy dog | {(16,20)}            | {}      | {}             |
		| The quick brown *fox* jumps over the lazy *dog* | The quick brown fox jumps over the lazy dog | {(16, 20), (42, 46)} | {}      | {}             |