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

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="Sigma16Parser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.11.1")]
[System.CLSCompliant(false)]
public interface ISigma16Listener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="Sigma16Parser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProgram([NotNull] Sigma16Parser.ProgramContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Sigma16Parser.program"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProgram([NotNull] Sigma16Parser.ProgramContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Sigma16Parser.instruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInstruction([NotNull] Sigma16Parser.InstructionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Sigma16Parser.instruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInstruction([NotNull] Sigma16Parser.InstructionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Sigma16Parser.rrr_instruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRrr_instruction([NotNull] Sigma16Parser.Rrr_instructionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Sigma16Parser.rrr_instruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRrr_instruction([NotNull] Sigma16Parser.Rrr_instructionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Sigma16Parser.rx_instruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRx_instruction([NotNull] Sigma16Parser.Rx_instructionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Sigma16Parser.rx_instruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRx_instruction([NotNull] Sigma16Parser.Rx_instructionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Sigma16Parser.data_instruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterData_instruction([NotNull] Sigma16Parser.Data_instructionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Sigma16Parser.data_instruction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitData_instruction([NotNull] Sigma16Parser.Data_instructionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Sigma16Parser.label_def"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLabel_def([NotNull] Sigma16Parser.Label_defContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Sigma16Parser.label_def"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLabel_def([NotNull] Sigma16Parser.Label_defContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Sigma16Parser.x"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterX([NotNull] Sigma16Parser.XContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Sigma16Parser.x"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitX([NotNull] Sigma16Parser.XContext context);
}
