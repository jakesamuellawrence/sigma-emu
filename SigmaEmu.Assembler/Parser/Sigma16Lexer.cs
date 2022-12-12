//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from .\Parser\Sigma16.g4 by ANTLR 4.11.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public partial class Sigma16Lexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, REG=2, RRR_COMMAND=3, RX_COMMAND=4, X_COMMAND=5, ADD=6, SUB=7, 
		MUL=8, DIV=9, CMPLT=10, CMPEQ=11, CMPGT=12, INV=13, AND=14, OR=15, XOR=16, 
		SHIFTL=17, SHIFTR=18, TRAP=19, LEA=20, LOAD=21, STORE=22, JUMP=23, COMMA=24, 
		LBRACK=25, RBRACK=26, NUM=27, LABEL=28, SPACE=29, EOL=30, COMMENT=31;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "REG", "RRR_COMMAND", "RX_COMMAND", "X_COMMAND", "ADD", "SUB", 
		"MUL", "DIV", "CMPLT", "CMPEQ", "CMPGT", "INV", "AND", "OR", "XOR", "SHIFTL", 
		"SHIFTR", "TRAP", "LEA", "LOAD", "STORE", "JUMP", "COMMA", "LBRACK", "RBRACK", 
		"NUM", "LABEL", "SPACE", "EOL", "COMMENT", "LETTER", "DIGIT"
	};


	public Sigma16Lexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public Sigma16Lexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'data'", null, null, null, null, "'add'", "'sub'", "'mul'", "'div'", 
		"'cmplt'", "'cmpeq'", "'cmpgt'", "'inv'", "'and'", "'or'", "'xor'", "'shiftl'", 
		"'shiftr'", "'trap'", "'lea'", "'load'", "'store'", "'jump'", "','", "'['", 
		"']'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, "REG", "RRR_COMMAND", "RX_COMMAND", "X_COMMAND", "ADD", "SUB", 
		"MUL", "DIV", "CMPLT", "CMPEQ", "CMPGT", "INV", "AND", "OR", "XOR", "SHIFTL", 
		"SHIFTR", "TRAP", "LEA", "LOAD", "STORE", "JUMP", "COMMA", "LBRACK", "RBRACK", 
		"NUM", "LABEL", "SPACE", "EOL", "COMMENT"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Sigma16.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static Sigma16Lexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,31,275,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,2,30,7,30,2,31,7,31,2,32,7,32,1,0,1,0,1,0,1,0,1,0,1,1,1,
		1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
		1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
		1,1,1,3,1,111,8,1,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,
		1,2,3,2,127,8,2,1,3,1,3,1,3,3,3,132,8,3,1,4,1,4,1,5,1,5,1,5,1,5,1,6,1,
		6,1,6,1,6,1,7,1,7,1,7,1,7,1,8,1,8,1,8,1,8,1,9,1,9,1,9,1,9,1,9,1,9,1,10,
		1,10,1,10,1,10,1,10,1,10,1,11,1,11,1,11,1,11,1,11,1,11,1,12,1,12,1,12,
		1,12,1,13,1,13,1,13,1,13,1,14,1,14,1,14,1,15,1,15,1,15,1,15,1,16,1,16,
		1,16,1,16,1,16,1,16,1,16,1,17,1,17,1,17,1,17,1,17,1,17,1,17,1,18,1,18,
		1,18,1,18,1,18,1,19,1,19,1,19,1,19,1,20,1,20,1,20,1,20,1,20,1,21,1,21,
		1,21,1,21,1,21,1,21,1,22,1,22,1,22,1,22,1,22,1,23,1,23,1,24,1,24,1,25,
		1,25,1,26,4,26,231,8,26,11,26,12,26,232,1,27,1,27,1,27,1,27,5,27,239,8,
		27,10,27,12,27,242,9,27,1,28,4,28,245,8,28,11,28,12,28,246,1,28,1,28,1,
		29,3,29,252,8,29,1,29,1,29,1,29,1,29,1,30,1,30,5,30,260,8,30,10,30,12,
		30,263,9,30,1,30,3,30,266,8,30,1,30,1,30,1,30,1,30,1,31,1,31,1,32,1,32,
		0,0,33,1,1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,21,11,23,12,25,13,
		27,14,29,15,31,16,33,17,35,18,37,19,39,20,41,21,43,22,45,23,47,24,49,25,
		51,26,53,27,55,28,57,29,59,30,61,31,63,0,65,0,1,0,4,1,0,95,95,2,0,9,9,
		32,32,2,0,10,10,13,13,2,0,65,90,97,122,310,0,1,1,0,0,0,0,3,1,0,0,0,0,5,
		1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,
		0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,
		1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,0,35,1,0,0,0,0,37,1,0,0,
		0,0,39,1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,0,0,47,1,0,0,0,0,49,
		1,0,0,0,0,51,1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,0,0,57,1,0,0,0,0,59,1,0,0,
		0,0,61,1,0,0,0,1,67,1,0,0,0,3,110,1,0,0,0,5,126,1,0,0,0,7,131,1,0,0,0,
		9,133,1,0,0,0,11,135,1,0,0,0,13,139,1,0,0,0,15,143,1,0,0,0,17,147,1,0,
		0,0,19,151,1,0,0,0,21,157,1,0,0,0,23,163,1,0,0,0,25,169,1,0,0,0,27,173,
		1,0,0,0,29,177,1,0,0,0,31,180,1,0,0,0,33,184,1,0,0,0,35,191,1,0,0,0,37,
		198,1,0,0,0,39,203,1,0,0,0,41,207,1,0,0,0,43,212,1,0,0,0,45,218,1,0,0,
		0,47,223,1,0,0,0,49,225,1,0,0,0,51,227,1,0,0,0,53,230,1,0,0,0,55,234,1,
		0,0,0,57,244,1,0,0,0,59,251,1,0,0,0,61,257,1,0,0,0,63,271,1,0,0,0,65,273,
		1,0,0,0,67,68,5,100,0,0,68,69,5,97,0,0,69,70,5,116,0,0,70,71,5,97,0,0,
		71,2,1,0,0,0,72,73,5,82,0,0,73,111,5,48,0,0,74,75,5,82,0,0,75,111,5,49,
		0,0,76,77,5,82,0,0,77,111,5,50,0,0,78,79,5,82,0,0,79,111,5,51,0,0,80,81,
		5,82,0,0,81,111,5,52,0,0,82,83,5,82,0,0,83,111,5,53,0,0,84,85,5,82,0,0,
		85,111,5,54,0,0,86,87,5,82,0,0,87,111,5,55,0,0,88,89,5,82,0,0,89,111,5,
		56,0,0,90,91,5,82,0,0,91,111,5,57,0,0,92,93,5,82,0,0,93,94,5,49,0,0,94,
		111,5,48,0,0,95,96,5,82,0,0,96,97,5,49,0,0,97,111,5,49,0,0,98,99,5,82,
		0,0,99,100,5,49,0,0,100,111,5,50,0,0,101,102,5,82,0,0,102,103,5,49,0,0,
		103,111,5,51,0,0,104,105,5,82,0,0,105,106,5,49,0,0,106,111,5,52,0,0,107,
		108,5,82,0,0,108,109,5,49,0,0,109,111,5,53,0,0,110,72,1,0,0,0,110,74,1,
		0,0,0,110,76,1,0,0,0,110,78,1,0,0,0,110,80,1,0,0,0,110,82,1,0,0,0,110,
		84,1,0,0,0,110,86,1,0,0,0,110,88,1,0,0,0,110,90,1,0,0,0,110,92,1,0,0,0,
		110,95,1,0,0,0,110,98,1,0,0,0,110,101,1,0,0,0,110,104,1,0,0,0,110,107,
		1,0,0,0,111,4,1,0,0,0,112,127,3,11,5,0,113,127,3,13,6,0,114,127,3,15,7,
		0,115,127,3,17,8,0,116,127,3,19,9,0,117,127,3,21,10,0,118,127,3,23,11,
		0,119,127,3,25,12,0,120,127,3,27,13,0,121,127,3,29,14,0,122,127,3,31,15,
		0,123,127,3,33,16,0,124,127,3,35,17,0,125,127,3,37,18,0,126,112,1,0,0,
		0,126,113,1,0,0,0,126,114,1,0,0,0,126,115,1,0,0,0,126,116,1,0,0,0,126,
		117,1,0,0,0,126,118,1,0,0,0,126,119,1,0,0,0,126,120,1,0,0,0,126,121,1,
		0,0,0,126,122,1,0,0,0,126,123,1,0,0,0,126,124,1,0,0,0,126,125,1,0,0,0,
		127,6,1,0,0,0,128,132,3,39,19,0,129,132,3,41,20,0,130,132,3,43,21,0,131,
		128,1,0,0,0,131,129,1,0,0,0,131,130,1,0,0,0,132,8,1,0,0,0,133,134,3,45,
		22,0,134,10,1,0,0,0,135,136,5,97,0,0,136,137,5,100,0,0,137,138,5,100,0,
		0,138,12,1,0,0,0,139,140,5,115,0,0,140,141,5,117,0,0,141,142,5,98,0,0,
		142,14,1,0,0,0,143,144,5,109,0,0,144,145,5,117,0,0,145,146,5,108,0,0,146,
		16,1,0,0,0,147,148,5,100,0,0,148,149,5,105,0,0,149,150,5,118,0,0,150,18,
		1,0,0,0,151,152,5,99,0,0,152,153,5,109,0,0,153,154,5,112,0,0,154,155,5,
		108,0,0,155,156,5,116,0,0,156,20,1,0,0,0,157,158,5,99,0,0,158,159,5,109,
		0,0,159,160,5,112,0,0,160,161,5,101,0,0,161,162,5,113,0,0,162,22,1,0,0,
		0,163,164,5,99,0,0,164,165,5,109,0,0,165,166,5,112,0,0,166,167,5,103,0,
		0,167,168,5,116,0,0,168,24,1,0,0,0,169,170,5,105,0,0,170,171,5,110,0,0,
		171,172,5,118,0,0,172,26,1,0,0,0,173,174,5,97,0,0,174,175,5,110,0,0,175,
		176,5,100,0,0,176,28,1,0,0,0,177,178,5,111,0,0,178,179,5,114,0,0,179,30,
		1,0,0,0,180,181,5,120,0,0,181,182,5,111,0,0,182,183,5,114,0,0,183,32,1,
		0,0,0,184,185,5,115,0,0,185,186,5,104,0,0,186,187,5,105,0,0,187,188,5,
		102,0,0,188,189,5,116,0,0,189,190,5,108,0,0,190,34,1,0,0,0,191,192,5,115,
		0,0,192,193,5,104,0,0,193,194,5,105,0,0,194,195,5,102,0,0,195,196,5,116,
		0,0,196,197,5,114,0,0,197,36,1,0,0,0,198,199,5,116,0,0,199,200,5,114,0,
		0,200,201,5,97,0,0,201,202,5,112,0,0,202,38,1,0,0,0,203,204,5,108,0,0,
		204,205,5,101,0,0,205,206,5,97,0,0,206,40,1,0,0,0,207,208,5,108,0,0,208,
		209,5,111,0,0,209,210,5,97,0,0,210,211,5,100,0,0,211,42,1,0,0,0,212,213,
		5,115,0,0,213,214,5,116,0,0,214,215,5,111,0,0,215,216,5,114,0,0,216,217,
		5,101,0,0,217,44,1,0,0,0,218,219,5,106,0,0,219,220,5,117,0,0,220,221,5,
		109,0,0,221,222,5,112,0,0,222,46,1,0,0,0,223,224,5,44,0,0,224,48,1,0,0,
		0,225,226,5,91,0,0,226,50,1,0,0,0,227,228,5,93,0,0,228,52,1,0,0,0,229,
		231,3,65,32,0,230,229,1,0,0,0,231,232,1,0,0,0,232,230,1,0,0,0,232,233,
		1,0,0,0,233,54,1,0,0,0,234,240,3,63,31,0,235,239,3,63,31,0,236,239,7,0,
		0,0,237,239,3,65,32,0,238,235,1,0,0,0,238,236,1,0,0,0,238,237,1,0,0,0,
		239,242,1,0,0,0,240,238,1,0,0,0,240,241,1,0,0,0,241,56,1,0,0,0,242,240,
		1,0,0,0,243,245,7,1,0,0,244,243,1,0,0,0,245,246,1,0,0,0,246,244,1,0,0,
		0,246,247,1,0,0,0,247,248,1,0,0,0,248,249,6,28,0,0,249,58,1,0,0,0,250,
		252,5,13,0,0,251,250,1,0,0,0,251,252,1,0,0,0,252,253,1,0,0,0,253,254,5,
		10,0,0,254,255,1,0,0,0,255,256,6,29,0,0,256,60,1,0,0,0,257,261,5,59,0,
		0,258,260,8,2,0,0,259,258,1,0,0,0,260,263,1,0,0,0,261,259,1,0,0,0,261,
		262,1,0,0,0,262,265,1,0,0,0,263,261,1,0,0,0,264,266,5,13,0,0,265,264,1,
		0,0,0,265,266,1,0,0,0,266,267,1,0,0,0,267,268,5,10,0,0,268,269,1,0,0,0,
		269,270,6,30,0,0,270,62,1,0,0,0,271,272,7,3,0,0,272,64,1,0,0,0,273,274,
		2,48,57,0,274,66,1,0,0,0,11,0,110,126,131,232,238,240,246,251,261,265,
		1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
