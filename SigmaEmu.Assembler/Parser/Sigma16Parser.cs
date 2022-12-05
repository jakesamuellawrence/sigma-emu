//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.11.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from .\Sigma16.g4 by ANTLR 4.11.1

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
		RRR_COMMAND=1, RX_COMMAND=2, REG=3, ADD=4, SUB=5, MUL=6, DIV=7, TRAP=8, 
		LEA=9, LOAD=10, STORE=11, NUM=12, LABEL=13, COMMA=14, LBRACK=15, RBRACK=16, 
		SPACE=17, EOL=18, COMMENT=19;
	public const int
		RULE_program = 0, RULE_instruction = 1, RULE_rrr_instruction = 2, RULE_rx_instruction = 3;
	public static readonly string[] ruleNames = {
		"program", "instruction", "rrr_instruction", "rx_instruction"
	};

	private static readonly string[] _LiteralNames = {
		null, null, null, null, "'add'", "'sub'", "'mul'", "'div'", "'trap'", 
		"'lea'", "'load'", "'store'", null, null, "','", "'['", "']'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "RRR_COMMAND", "RX_COMMAND", "REG", "ADD", "SUB", "MUL", "DIV", 
		"TRAP", "LEA", "LOAD", "STORE", "NUM", "LABEL", "COMMA", "LBRACK", "RBRACK", 
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
			State = 11;
			ErrorHandler.Sync(this);
			_la = TokenStream.LA(1);
			while (_la==RRR_COMMAND || _la==RX_COMMAND) {
				{
				{
				State = 8;
				instruction();
				}
				}
				State = 13;
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
			State = 16;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case RRR_COMMAND:
				EnterOuterAlt(_localctx, 1);
				{
				State = 14;
				rrr_instruction();
				}
				break;
			case RX_COMMAND:
				EnterOuterAlt(_localctx, 2);
				{
				State = 15;
				rx_instruction();
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
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 18;
			Match(RRR_COMMAND);
			State = 19;
			_localctx.destinationReg = Match(REG);
			State = 20;
			Match(COMMA);
			State = 21;
			_localctx.firstOperand = Match(REG);
			State = 22;
			Match(COMMA);
			State = 23;
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
		public IToken reg;
		public IToken label;
		public IToken offsetReg;
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode RX_COMMAND() { return GetToken(Sigma16Parser.RX_COMMAND, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode COMMA() { return GetToken(Sigma16Parser.COMMA, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LBRACK() { return GetToken(Sigma16Parser.LBRACK, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode RBRACK() { return GetToken(Sigma16Parser.RBRACK, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode[] REG() { return GetTokens(Sigma16Parser.REG); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode REG(int i) {
			return GetToken(Sigma16Parser.REG, i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode LABEL() { return GetToken(Sigma16Parser.LABEL, 0); }
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
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 25;
			Match(RX_COMMAND);
			State = 26;
			_localctx.reg = Match(REG);
			State = 27;
			Match(COMMA);
			State = 28;
			_localctx.label = Match(LABEL);
			State = 29;
			Match(LBRACK);
			State = 30;
			_localctx.offsetReg = Match(REG);
			State = 31;
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

	private static int[] _serializedATN = {
		4,1,19,34,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,1,0,5,0,10,8,0,10,0,12,0,13,
		9,0,1,1,1,1,3,1,17,8,1,1,2,1,2,1,2,1,2,1,2,1,2,1,2,1,3,1,3,1,3,1,3,1,3,
		1,3,1,3,1,3,1,3,0,0,4,0,2,4,6,0,0,31,0,11,1,0,0,0,2,16,1,0,0,0,4,18,1,
		0,0,0,6,25,1,0,0,0,8,10,3,2,1,0,9,8,1,0,0,0,10,13,1,0,0,0,11,9,1,0,0,0,
		11,12,1,0,0,0,12,1,1,0,0,0,13,11,1,0,0,0,14,17,3,4,2,0,15,17,3,6,3,0,16,
		14,1,0,0,0,16,15,1,0,0,0,17,3,1,0,0,0,18,19,5,1,0,0,19,20,5,3,0,0,20,21,
		5,14,0,0,21,22,5,3,0,0,22,23,5,14,0,0,23,24,5,3,0,0,24,5,1,0,0,0,25,26,
		5,2,0,0,26,27,5,3,0,0,27,28,5,14,0,0,28,29,5,13,0,0,29,30,5,15,0,0,30,
		31,5,3,0,0,31,32,5,16,0,0,32,7,1,0,0,0,2,11,16
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
