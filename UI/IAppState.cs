
namespace UI
{
    public interface IAppState
    {
        void NextButtonClicked(string currentAnswerString);
        void PreviousButtonClicked(string currentAnswerString);
        void SubmitButtonClicked(string currentAnswerString);
        void Initialize();
    }
}
