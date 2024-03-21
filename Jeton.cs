namespace TokenRing
{
    public class Jeton
    {
        public string SourceIpAddress { get; set; }

        public string DestionationIpAddress { get; set; }

        public string Data { get; set; }

        public bool IsToken { get { return (Data == string.Empty); } }

        public Jeton(string sourceIpAddress, string destionationIpAddress, string data)
        {
            SourceIpAddress = sourceIpAddress;
            DestionationIpAddress = destionationIpAddress;
            Data = data;
        }

        public override string? ToString()
        {
            return $"Source: {SourceIpAddress}, Destination: {DestionationIpAddress}";
        }
    }
}
