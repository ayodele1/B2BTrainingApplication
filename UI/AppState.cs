
namespace UI
{
    public interface AppState
    {
        void NextButtonClicked(string currentAnswerString);
        void PreviousButtonClicked(string currentAnswerString);
        void SubmitButtonClicked();
        void Initialize();
    }
}
