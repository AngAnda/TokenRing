namespace TokenRing
{
    internal class TokenRingNetwork
    {
        private readonly List<Computer> _computers;

        private readonly Queue<Jeton> _jetons;

        private readonly Random _random;

        public TokenRingNetwork()
        {
            _random = new Random();
            _computers = new List<Computer>();
            _jetons = new Queue<Jeton>();
            InitializeComputers();
            InitializeJetons();
        }

        private void InitializeComputers()
        {
            for (int i = 0; i < 10; i++)
            {
                _computers.Add(new Computer($"192.168.1.{i + 1}"));
            }
        }

        private void InitializeJetons()
        {


            int indexSource;
            int indexDestination;

            for (int i = 0; i < 10; i++)
            {
                do
                {
                    indexSource = _random.Next(0, _computers.Count);
                    indexDestination = _random.Next(0, _computers.Count);
                } while (indexSource == indexDestination);
                _jetons.Enqueue(new Jeton(_computers[indexSource].IpAddress, _computers[indexDestination].IpAddress, $"Iteration no. {i}"));
            }
        }

        public void DisplayNetwork()
        {
            Console.WriteLine("\nNetwork status:");
            for (int i = 0; i < _computers.Count; i++)
            {
                Console.WriteLine($"C{i} {_computers[i].ToString()}");
            }
        }

        public void Start()
        {
            Jeton currentJeton;
            int indexCurrentComputer;

            while (_jetons.Count() > 0)
            {
                currentJeton = _jetons.Dequeue();
                DisplayNetwork();
                Console.WriteLine(currentJeton.ToString());
                indexCurrentComputer = _computers.Select((value, index) => new { value, index }).First(x => x.value.IpAddress == currentJeton.SourceIpAddress).index;
                // se selecteaza indexul computerului care are adresa IP sursa a jetonului curent

                for (int i = 0; i < _computers.Count; i++)
                {
                    if (_computers[indexCurrentComputer].IpAddress == currentJeton.DestionationIpAddress)
                    {
                        Console.WriteLine($"C{indexCurrentComputer}: Got token");
                        _computers[indexCurrentComputer].Buffer = currentJeton.Data;
                        _computers[indexCurrentComputer].CleanToken(currentJeton);
                    }
                    Console.WriteLine($"C{indexCurrentComputer}: Move token");

                    indexCurrentComputer = (indexCurrentComputer + 1) % _computers.Count;
                }
                Console.WriteLine($"C{indexCurrentComputer}: Reached destination");

            }
        }

    }
}
