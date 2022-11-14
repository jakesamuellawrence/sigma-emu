using Microsoft.AspNetCore.Components.Forms;

namespace SigmaEmu.Core.Models;

public class Source
{
    public List<string> Lines { get; }

    public Source(List<string> lines)
    {
        Lines = lines;
    }

    public static async Task<Source> FromFileAsync(IBrowserFile file)
    {
        var lines = new List<string>();
        var fileReader = new StreamReader(file.OpenReadStream());
        
        string? line;
        while ((line = await fileReader.ReadLineAsync()) != null)
        {
            lines.Add(line);
        }

        return new Source(lines);
    }
}