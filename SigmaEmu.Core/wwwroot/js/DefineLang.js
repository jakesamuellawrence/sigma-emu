let keywords = ["lea", "load"]

blazorMonaco.editor.registerSigma16 = function () {
    monaco.languages.register({
        id: "Sigma16"
    });

    monaco.languages.setMonarchTokensProvider("Sigma16", {
        keywords,
        tokenizer: {
            root: [
                [/@?[a-zA-Z][\w$]*/, {
                    cases: {
                        '@keywords': 'keyword',
                        '@default': 'label'
                    }
                }],
                [/;.*/, 'comment'],
            ]
        }
    })
}
    