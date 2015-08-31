
namespace lDoran
{
    class Bank
    {
        private string id;
        private string name;

        public Bank() { }

        public Bank(string id, string name)
        {
            this.id = ParseId(id);
            this.name = name;
        }

        public string Id
        {
            set
            {
                id = ParseId(value);
            }
            get
            {
                return id;
            }
        }

        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }

        private string ParseId(string id)
        {
            return id.Substring(0, 4);
        }
    }
}
