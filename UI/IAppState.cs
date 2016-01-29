
using DomainObjects;
namespace UI
{
    public interface IAppState
    {
        void NextButtonClicked(string currentAnswerString);
        void PreviousButtonClicked(string currentAnswerString);
        void SubmitButtonClicked(string currentAnswerString);
        void InitializeNew();
        void InitializeLoad();
        //Dynamic Save
        void SaveAnswer(string currentAnswerString);
        AppStateInfo GetCurrentStateVariables();
    }
}
