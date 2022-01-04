namespace LibraryDomain
{
    public class PatronAccount
    {
        private String _name;

        public PatronAccount(String name)
        {
            this._name = name;
            this.Balance = 0;
        }

        public decimal Balance { get; private set; }

        public void ChargeAccount(decimal amount)
        {
            this.Balance += amount;
        }
    }
}