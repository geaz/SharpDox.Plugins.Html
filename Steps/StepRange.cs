namespace SharpDox.Plugins.Html.Steps
{
    internal class StepRange
    {
        public StepRange(int progressStart, int progressEnd)
        {
            ProgressStart = progressStart;
            ProgressEnd = progressEnd;
        }

        public int ProgressStart { get; private set; }
        public int ProgressEnd { get; private set; }
    }
}
