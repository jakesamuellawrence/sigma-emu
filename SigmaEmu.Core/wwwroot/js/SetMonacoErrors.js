blazorMonaco.editor.SetErrors = function (errors) {
    let markers = [];

    let editor = blazorMonaco.editors[0].editor;

    for (let error of errors) {
        markers.push({
            startLineNumber: error.startLine,
            endLineNumber: error.endLine,
            startColumn: error.startColumn,
            endColumn: error.endColumn,
            message: error.message,
            severity: monaco.MarkerSeverity.Error,
        });
    }

    monaco.editor.setModelMarkers(editor.getModel(), "owner", markers);
}