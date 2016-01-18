
namespace DomainObjects
{
    public class B2BProgrammer
    {
        private string _email;

        public B2BProgrammer(string Email)
        {
            _email = Email;
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

    }
}
