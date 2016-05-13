namespace SharpDox.Plugins.Html.Steps
{
    internal class StepRange
    {
        public StepRange(int progressStart, int progressEnd)
        {
            ProgressStart = progressStart;
            ProgressEnd = progressEnd;
        }

        public int GetProgressByStepProgress(int stepProgress)
        {
            return (int)((((ProgressEnd - ProgressStart) / 100d) * stepProgress) + ProgressStart);
        }

        public int ProgressStart { get; private set; }
        public int ProgressEnd { get; private set; }
    }
}
