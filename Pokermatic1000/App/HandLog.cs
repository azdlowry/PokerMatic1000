namespace Pokermatic1000.App
{
    internal class HandLog
    {
        public Card OurCard { get; set; }

        public Card OpponentCard { get; set; }

        public int OpponentBets { get; set; }

        public bool WePostedBlind { get; set; }

        public bool WeReceiveButton { get; set; }

        public bool OpponentCalled { get; set; }

        public bool OpponentFolded { get; set; }

        public override string ToString()
        {
            return string.Format("OurCard({0}) OpponentCard({1}) OpponentBets({2}) WePostedBlind({3}) WeReceiveButton({4}) OpponentCalled({5}) OpponentFolded({6})",
                OurCard,
                OpponentCard,
                OpponentBets,
                WePostedBlind,
                WeReceiveButton,
                OpponentCalled,
                OpponentFolded);
        }
    }
}