using DomainObjects;

namespace Helpers
{
    public static class StatusMgr
    {
        private static B2BProgrammer _currentProgrammer = null;
        private static bool _isRetaking = false;

        public static bool isRetakingExercise
        {
            get { return _isRetaking; }
            set { _isRetaking = value; }
        }

        public static B2BProgrammer CurrentProgrammer
        {
            get { return _currentProgrammer; }
            set { _currentProgrammer = value; }
        }
    }
}
