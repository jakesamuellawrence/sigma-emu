namespace SigmaEmu.Core.Models;

public enum ProcessorRunningState
{
    Playing,
    PlayingFast,
    PlayingUnbounded,
    Stopped,
    Paused
}

public static class ProcessorRunningStateExtensions
{
    public static string ForDisplay(this ProcessorRunningState state)
    {
        switch (state)
        {
            case ProcessorRunningState.Playing:
            case ProcessorRunningState.PlayingFast:
            case ProcessorRunningState.PlayingUnbounded:
                return "Playing";
            case ProcessorRunningState.Stopped:
                return "Stopped";
            case ProcessorRunningState.Paused:
                return "Paused";
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
}