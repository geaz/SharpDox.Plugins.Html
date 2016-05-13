using System;

namespace SharpDox.Plugins.Html.Steps
{
    internal abstract class StepBase
    {
        public event Action<string> OnStepMessage;
        public event Action<int> OnStepProgress;

        protected StepBase(StepRange stepRange)
        {
            StepRange = stepRange;
        }

        public abstract void RunStep();

        protected void ExecuteOnStepMessage(string message)
        {
            if (OnStepMessage != null)
            {
                OnStepMessage(message);
            }
        }

        protected void ExecuteOnStepProgress(int value)
        {
            if (OnStepProgress != null)
            {
                OnStepProgress(StepRange.GetProgressByStepProgress(value));
            }
        }

        public StepRange StepRange { private set; get; }
    }
}
