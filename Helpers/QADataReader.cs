using System;
using System.IO;
using System.Linq;

namespace Helpers
{
    class QADataReader
    {
        string questionsFilePath;
        string answersFilePath;
        private void GetFilePaths(int exercisenumber)
        {
            questionsFilePath = string.Format(@"C:\Users\{0}\Documents\B2BTraining\Project{1}\Questions.txt", Environment.MachineName, exercisenumber);
            answersFilePath = string.Format(@"C:\Users\{0}\Documents\B2BTraining\Answers\{1}.txt", Environment.MachineName, exercisenumber);
        }

        /// <summary>
        /// Opens up a file and read a particular line of question
        /// </summary>
        /// <param name="exerciseNumber"></param>
        /// <param name="questionNumber"></param>
        /// <returns></returns>z
        public string ReadQuestionFromFile(int exerciseNumber, int questionNumber)
        {
            GetFilePaths(exerciseNumber);
            return ReadFromFile(questionNumber, questionsFilePath);
        }

        public string ReadCorrectAnswerFromFile(int exerciseNumber, int questionNumber)
        {
            GetFilePaths(exerciseNumber);
            return ReadFromFile(questionNumber, answersFilePath);
        }

        /// <summary>
        /// Get data from file by filepath
        /// </summary>
        /// <param name="questionNumber"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private string ReadFromFile(int questionNumber, string filepath)
        {
            try
            {
                int numberOfLines = File.ReadAllLines(filepath).Length;
                while (questionNumber <= numberOfLines && questionNumber > 0)
                {
                    return File.ReadLines(filepath).Skip(questionNumber - 1).Take(1).First();
                }
                return "";
            }
            catch (InvalidOperationException)
            {
                throw;
                //This means the end of the file has been reached.
                // return "";
            }
        }

    }
}
