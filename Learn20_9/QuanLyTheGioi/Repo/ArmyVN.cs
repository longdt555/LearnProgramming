using QuanLyTheGioi.AbtractRepo;

namespace QuanLyTheGioi.Repo
{
    public class ArmyVn : ArmyAbstract
    {
        public override string SayUnit(int unit)
        {
            if (unit == 12)
            {
                return "Trung đội giỏi";
            }

            return "Trung đội bình thường";
        }

        public override string SayTimeSleep()
        {
            return "21h";
        }

        public override string SayTimeExercise()
        {
            return "6h";
        }
        
    }
}
