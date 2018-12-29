namespace Caldast.AlgoLife.Recursion
{
    public class CoinGame
    {
        private int _coins;
        private Player _p1;
        private Player _p2;
        private Player _start;
        private int[] _p1Score = new int[1];
        private int[] _p2Score = new int[1];
        public CoinGame(int coins, Player p1, Player p2)
        {
            _coins = coins;
            _p1 = p1;
            _p2 = p2;
        }

        public void Play(Player p)
        {
            _start = p;
            PlayU(p, _coins);          
        }

        public void PlayU(Player p, int rem)
        {
            if (rem >= 0)
            {
                if (rem == 0)
                {
                    if (p == _p1)
                        _p1Score[0]++;

                    if (p == _p2)
                        _p2Score[0]++;

                    return;
                }

                Player next = GetNext(p);

                PlayU(next, rem - 1);
                PlayU(next, rem - 2);
                PlayU(next, rem - 4);
            }
        }

        public Player GetNext(Player p)
        {
            if (_start != null)
            {
                Player temp = _start;
                _start = null;
                return temp;
            }
                
            else
            {
                _start = null;
                return p == _p1 ? _p2 : _p1;
            }
        }
        
    }

    public class Player
    {
        public string Name { get; set; }
       

        public Player(string name)
        {
            Name = name;
           
        }
    }
}
