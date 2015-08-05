namespace BowlingGame_csharp
{
    public class Roll
    {
        public RollState State { get; protected set; }
        public int Pins { get; protected set; }

        public void KnockDown(int pins)
        {
            Pins = pins;
            State = RollState.Played;
        }
    }
}