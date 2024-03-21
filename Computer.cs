namespace TokenRing
{
    public class Computer
    {
        public string IpAddress { get; set; }

        public string Buffer { get; set; }

        public bool HasToken { get { return (Buffer != string.Empty); } }

        public Computer(string ipAddress)
        {
            Buffer = string.Empty;
            IpAddress = ipAddress;
        }

        public void CleanToken(Jeton jeton)
        {
            jeton.Data = string.Empty;
        }

        public override string? ToString()
        {
            return $"({IpAddress}) -> {(!string.IsNullOrEmpty(Buffer) ? Buffer : "null")}";
        }

    }
}
