let mnemonics = [
    "add", "sub", "mul", "div",
    "cmplt", "cmpeq", "cmpgt",
    "inv", "and", "or", "xor",
    "shiftl", "shiftr", "trap",
    "lea", "load", "store",
    "jumpf", "jumpt", "jal", "jump",
    "data"
];

let registers = [
    "R0", "R1", "R2", "R3",
    "R4", "R5", "R6", "R7",
    "R8", "R9", "R10", "R11",
    "R12", "R13", "R14", "R15",
];

let dataKeyword = ["data"];

blazorMonaco.editor.registerSigma16 = function () {
    
    monaco.languages.register({
        id: "Sigma16"
    });

    monaco.languages.setMonarchTokensProvider("Sigma16", {
        mnemonics,
        registers,
        dataKeyword,
        ignoreCase: true,
        tokenizer: {
            root: [
                [/[\[\]]/, 'string.value.json'],
                [/\$[0-9a-f]{4}/, 'string'],
                [/[0-9]+/, 'number'],
                [/@?[a-zA-Z][\w$]*/, {
                    cases: {
                        '@mnemonics': 'type',
                        '@registers': 'annotation',
                        '@default': 'variable',
                    }
                }],
                [/;.*/, 'comment'],
            ]
        }
    });

    monaco.languages.registerCompletionItemProvider("Sigma16", {
        provideCompletionItems: (model, position) => {
            let keywords = mnemonics.concat(registers);
            let suggestions = [
                ...keywords.map(keyword => {
                    return {
                        label: keyword,
                        kind: monaco.languages.CompletionItemKind.Keyword,
                        insertText: keyword,
                    };
                })
            ];

            return {suggestions: suggestions}
        },
    });
}