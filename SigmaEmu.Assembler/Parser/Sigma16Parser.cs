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
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public partial class Sigma16Parser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, REG=2, RRR_COMMAND=3, RX_COMMAND=4, ADD=5, SUB=6, MUL=7, DIV=8, 
		CMPLT=9, CMPEQ=10, CMPGT=11, INV=12, AND=13, OR=14, XOR=15, SHIFTL=16, 
		SHIFTR=17, TRAP=18, LEA=19, LOAD=20, STORE=21, COMMA=22, LBRACK=23, RBRACK=24, 
		NUM=25, LABEL=26, SPACE=27, EOL=28, COMMENT=29;
	public const int
		RULE_program = 0, RULE_instruction = 1, RULE_rrr_instruction = 2, RULE_rx_instruction = 3, 
		RULE_data_instruction = 4, RULE_label_def = 5, RULE_displacement = 6;
	public static readonly string[] ruleNames = {
		"program", "instruction", "rrr_instruction", "rx_instruction", "data_instruction", 
		"label_def", "displacement"
	};

	private static readonly string[] _LiteralNames = {
		null, "'data'", null, null, null, "'add'", "'sub'", "'mul'", "'div'", 
		"'cmplt'", "'cmpeq'", "'cmpgt'", "'inv'", "'and'", "'or'", "'xor'", "'shiftl'", 
		"'shiftr'", "'trap'", "'lea'", "'load'", "'store'", "','", "'['", "']'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, "REG", "RRR_COMMAND", "RX_COMMAND", "ADD", "SUB", "MUL", "DIV", 
		"CMPLT", "CMPEQ", "CMPGT", "INV", "AND", "OR", "XOR", "SHIFTL", "SHIFTR", 
		"TRAP", "LEA", "LOAD", "STORE", "COMMA", "LBRACK", "RBRACK", "NUM", "LABEL", 
		"SPACE", "EOL", "COMMENT"
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

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static Sigma16Parser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public Sigma16Parser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public Sigma16Parser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class ProgramContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public InstructionContext[] instruction() {
			return GetRuleContexts<InstructionContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public InstructionContext instruction(int i) {
			return GetRuleContext<InstructionContext>(i);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_program; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISigma16Listener typedListener = listener as ISigma16Listener;
			if (typedListener != null) typedListener.EnterProgram(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISigma16Listener typedListener = listener as ISigma16Listener;
			if (typedListener != null) typedListener.ExitProgram(this);
		}
	}

	[RuleVersion(0)]
	public ProgramContext program() {
		ProgramContext _localctx = new ProgramContext(Context, State);
		EnterRule(_localctx, 0, RULE_program);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 17;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (((_la) & ~0x3f) == 0 && ((1L << _la) & 67108890L) != 0) {
				{
				{
				State = 14;
				instruction();
				}
				}
				State = 19;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class InstructionContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public Rrr_instructionContext rrr_instruction() {
			return GetRuleContext<Rrr_instructionContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public Rx_instructionContext rx_instruction() {
			return GetRuleContext<Rx_instructionContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public Data_instructionContext data_instruction() {
			return GetRuleContext<Data_instructionContext>(0);
		}
		public InstructionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_instruction; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISigma16Listener typedListener = listener as ISigma16Listener;
			if (typedListener != null) typedListener.EnterInstruction(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISigma16Listener typedListener = listener as ISigma16Listener;
			if (typedListener != null) typedListener.ExitInstruction(this);
		}
	}

	[RuleVersion(0)]
	public InstructionContext instruction() {
		InstructionContext _localctx = new InstructionContext(Context, State);
		EnterRule(_localctx, 2, RULE_instruction);
		try {
			State = 23;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,1,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 20;
				rrr_instruction();
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 21;
				rx_instruction();
				}
				break;
			case 3:
				EnterOuterAlt(_localctx, 3);
				{
				State = 22;
				data_instruction();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Rrr_instructionContext : ParserRuleContext {
		public IToken destinationReg;
		public IToken firstOperand;
		public IToken secondOperand;
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode RRR_COMMAND() { return GetToken(Sigma16Parser.RRR_COMMAND, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] COMMA() { return GetTokens(Sigma16Parser.COMMA); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode COMMA(int i) {
			return GetToken(Sigma16Parser.COMMA, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] REG() { return GetTokens(Sigma16Parser.REG); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode REG(int i) {
			return GetToken(Sigma16Parser.REG, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public Label_defContext label_def() {
			return GetRuleContext<Label_defContext>(0);
		}
		public Rrr_instructionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_rrr_instruction; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISigma16Listener typedListener = listener as ISigma16Listener;
			if (typedListener != null) typedListener.EnterRrr_instruction(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISigma16Listener typedListener = listener as ISigma16Listener;
			if (typedListener != null) typedListener.ExitRrr_instruction(this);
		}
	}

	[RuleVersion(0)]
	public Rrr_instructionContext rrr_instruction() {
		Rrr_instructionContext _localctx = new Rrr_instructionContext(Context, State);
		EnterRule(_localctx, 4, RULE_rrr_instruction);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 26;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==LABEL) {
				{
				State = 25;
				label_def();
				}
			}

			State = 28;
			Match(RRR_COMMAND);
			State = 29;
			_localctx.destinationReg = Match(REG);
			State = 30;
			Match(COMMA);
			State = 31;
			_localctx.firstOperand = Match(REG);
			State = 32;
			Match(COMMA);
			State = 33;
			_localctx.secondOperand = Match(REG);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Rx_instructionContext : ParserRuleContext {
		public IToken destinationReg;
		public IToken offsetReg;
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode RX_COMMAND() { return GetToken(Sigma16Parser.RX_COMMAND, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode COMMA() { return GetToken(Sigma16Parser.COMMA, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public DisplacementContext displacement() {
			return GetRuleContext<DisplacementContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LBRACK() { return GetToken(Sigma16Parser.LBRACK, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode RBRACK() { return GetToken(Sigma16Parser.RBRACK, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] REG() { return GetTokens(Sigma16Parser.REG); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode REG(int i) {
			return GetToken(Sigma16Parser.REG, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public Label_defContext label_def() {
			return GetRuleContext<Label_defContext>(0);
		}
		public Rx_instructionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_rx_instruction; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISigma16Listener typedListener = listener as ISigma16Listener;
			if (typedListener != null) typedListener.EnterRx_instruction(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISigma16Listener typedListener = listener as ISigma16Listener;
			if (typedListener != null) typedListener.ExitRx_instruction(this);
		}
	}

	[RuleVersion(0)]
	public Rx_instructionContext rx_instruction() {
		Rx_instructionContext _localctx = new Rx_instructionContext(Context, State);
		EnterRule(_localctx, 6, RULE_rx_instruction);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 36;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==LABEL) {
				{
				State = 35;
				label_def();
				}
			}

			State = 38;
			Match(RX_COMMAND);
			State = 39;
			_localctx.destinationReg = Match(REG);
			State = 40;
			Match(COMMA);
			State = 41;
			displacement();
			State = 42;
			Match(LBRACK);
			State = 43;
			_localctx.offsetReg = Match(REG);
			State = 44;
			Match(RBRACK);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Data_instructionContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NUM() { return GetToken(Sigma16Parser.NUM, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public Label_defContext label_def() {
			return GetRuleContext<Label_defContext>(0);
		}
		public Data_instructionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_data_instruction; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISigma16Listener typedListener = listener as ISigma16Listener;
			if (typedListener != null) typedListener.EnterData_instruction(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISigma16Listener typedListener = listener as ISigma16Listener;
			if (typedListener != null) typedListener.ExitData_instruction(this);
		}
	}

	[RuleVersion(0)]
	public Data_instructionContext data_instruction() {
		Data_instructionContext _localctx = new Data_instructionContext(Context, State);
		EnterRule(_localctx, 8, RULE_data_instruction);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 47;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			if (_la==LABEL) {
				{
				State = 46;
				label_def();
				}
			}

			State = 49;
			Match(T__0);
			State = 50;
			Match(NUM);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Label_defContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LABEL() { return GetToken(Sigma16Parser.LABEL, 0); }
		public Label_defContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_label_def; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISigma16Listener typedListener = listener as ISigma16Listener;
			if (typedListener != null) typedListener.EnterLabel_def(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISigma16Listener typedListener = listener as ISigma16Listener;
			if (typedListener != null) typedListener.ExitLabel_def(this);
		}
	}

	[RuleVersion(0)]
	public Label_defContext label_def() {
		Label_defContext _localctx = new Label_defContext(Context, State);
		EnterRule(_localctx, 10, RULE_label_def);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 52;
			Match(LABEL);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DisplacementContext : ParserRuleContext {
		public IToken num;
		public IToken label;
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode NUM() { return GetToken(Sigma16Parser.NUM, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LABEL() { return GetToken(Sigma16Parser.LABEL, 0); }
		public DisplacementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_displacement; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			ISigma16Listener typedListener = listener as ISigma16Listener;
			if (typedListener != null) typedListener.EnterDisplacement(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			ISigma16Listener typedListener = listener as ISigma16Listener;
			if (typedListener != null) typedListener.ExitDisplacement(this);
		}
	}

	[RuleVersion(0)]
	public DisplacementContext displacement() {
		DisplacementContext _localctx = new DisplacementContext(Context, State);
		EnterRule(_localctx, 12, RULE_displacement);
		try {
			State = 56;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case NUM:
				EnterOuterAlt(_localctx, 1);
				{
				State = 54;
				_localctx.num = Match(NUM);
				}
				break;
			case LABEL:
				EnterOuterAlt(_localctx, 2);
				{
				State = 55;
				_localctx.label = Match(LABEL);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	private static int[] _serializedATN = {
		4,1,29,59,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,6,1,0,
		5,0,16,8,0,10,0,12,0,19,9,0,1,1,1,1,1,1,3,1,24,8,1,1,2,3,2,27,8,2,1,2,
		1,2,1,2,1,2,1,2,1,2,1,2,1,3,3,3,37,8,3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,3,
		1,4,3,4,48,8,4,1,4,1,4,1,4,1,5,1,5,1,6,1,6,3,6,57,8,6,1,6,0,0,7,0,2,4,
		6,8,10,12,0,0,58,0,17,1,0,0,0,2,23,1,0,0,0,4,26,1,0,0,0,6,36,1,0,0,0,8,
		47,1,0,0,0,10,52,1,0,0,0,12,56,1,0,0,0,14,16,3,2,1,0,15,14,1,0,0,0,16,
		19,1,0,0,0,17,15,1,0,0,0,17,18,1,0,0,0,18,1,1,0,0,0,19,17,1,0,0,0,20,24,
		3,4,2,0,21,24,3,6,3,0,22,24,3,8,4,0,23,20,1,0,0,0,23,21,1,0,0,0,23,22,
		1,0,0,0,24,3,1,0,0,0,25,27,3,10,5,0,26,25,1,0,0,0,26,27,1,0,0,0,27,28,
		1,0,0,0,28,29,5,3,0,0,29,30,5,2,0,0,30,31,5,22,0,0,31,32,5,2,0,0,32,33,
		5,22,0,0,33,34,5,2,0,0,34,5,1,0,0,0,35,37,3,10,5,0,36,35,1,0,0,0,36,37,
		1,0,0,0,37,38,1,0,0,0,38,39,5,4,0,0,39,40,5,2,0,0,40,41,5,22,0,0,41,42,
		3,12,6,0,42,43,5,23,0,0,43,44,5,2,0,0,44,45,5,24,0,0,45,7,1,0,0,0,46,48,
		3,10,5,0,47,46,1,0,0,0,47,48,1,0,0,0,48,49,1,0,0,0,49,50,5,1,0,0,50,51,
		5,25,0,0,51,9,1,0,0,0,52,53,5,26,0,0,53,11,1,0,0,0,54,57,5,25,0,0,55,57,
		5,26,0,0,56,54,1,0,0,0,56,55,1,0,0,0,57,13,1,0,0,0,6,17,23,26,36,47,56
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
