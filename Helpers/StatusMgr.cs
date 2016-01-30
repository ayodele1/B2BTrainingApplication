using DomainObjects;
using System.IO;
using System.Runtime.Serialization;

namespace Helpers
{
    public static class StatusMgr
    {
        private static B2BProgrammer _currentProgrammer = null;

        private static string _appDataFileName = "appData.xml"; //Save the file in the current directory as the .exe

        public static B2BProgrammer CurrentProgrammer
        {
            get { return _currentProgrammer; }
            set { _currentProgrammer = value; }
        }

        //public static void GetCurrentStateVariables(QAMgr QABot)
        //{
        //    AppStateInfo asi = new AppStateInfo(QABot.QuestionCount,QABot.ExerciseCount);
        //}

        public static void SaveCurrrentStateVariables(AppStateInfo asi)
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(AppStateInfo));

            using (FileStream fs = new FileStream(_appDataFileName, FileMode.Create))
            {
                dcs.WriteObject(fs, asi);
            }
        }

        public static AppStateInfo LoadSavedStateVariables()
        {
            if (File.Exists(_appDataFileName))
            {
                AppStateInfo loadedState;
                DataContractSerializer dcs = new DataContractSerializer(typeof(AppStateInfo));
                using (FileStream fs = new FileStream(_appDataFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    loadedState = (AppStateInfo)dcs.ReadObject(fs);
                }
                return loadedState;
            }
            return null;
        }
        //Just the the Git collaboration
    }
}
