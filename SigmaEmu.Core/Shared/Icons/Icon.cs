using Microsoft.AspNetCore.Components;

namespace Icons;

public class Icon : ComponentBase
{
    [Parameter] [EditorRequired] public string? Height { get; set; }
}