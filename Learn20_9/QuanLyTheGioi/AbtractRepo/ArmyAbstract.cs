namespace QuanLyTheGioi.AbtractRepo
{
    public abstract class ArmyAbstract
    {
        // Quân đội
        public abstract string SayUnit(int unit);
        public abstract string SayTimeSleep();
        public abstract string SayTimeExercise();

        public string SayHello(string msg)
        {
            return $"{msg}";
        }
    }
}
