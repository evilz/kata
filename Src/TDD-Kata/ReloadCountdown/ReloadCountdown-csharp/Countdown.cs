namespace ReloadCountdown
{
    public class Countdown
    {
        public uint CurrentValue { get; private set; }

        //true if the countdown has stopped. This is the initial state
        public bool Stopped
        {
            get
            {
                return CurrentValue <= 0;
            }
        }

        //set the countdown to seconds, therefore Stopped() will return false
        public void Start(uint second)
        {
            CurrentValue = second;
        }
   
        // decrease the countdown. If time reaches (or passes!) zero, Stopped() will return true again
        public void Decrease(uint second)
        {
            if (CurrentValue < second)
                CurrentValue = 0;
            else
                CurrentValue -= second;

        }
    }
}