using DomainObjects;

namespace Helpers
{
    public static class StatusMgr
    {
        private static B2BProgrammer _currentProgrammer = null;

        public static B2BProgrammer CurrentProgrammer
        {
            get { return _currentProgrammer; }
            set { _currentProgrammer = value; }
        }
    }
}
