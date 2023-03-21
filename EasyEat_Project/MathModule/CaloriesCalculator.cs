namespace MathModule
{
    public class CaloriesCalculator
    {
        public static double WomenLoss(double weight, double height, int age, double activityCoefficient)
        {
            double lessProcent = (100 - 17.5) / 100;// расчёт процента на сушке(костыль энжоер)
            double neededCalories = ((10 * weight + (6.25 * height) - 5 * age + 5) * activityCoefficient) * lessProcent;

            return neededCalories;
        }
        public static double MenLoss(double weight, double height, int age, double activityCoefficient)
        {
            double lessProcent = (100 - 17.5) / 100;// расчёт процента на сушке(костыль энжоер)
            double neededCalories = ((10 * weight + (6.25 * height) - 5 * age + 5) * activityCoefficient) * lessProcent;

            return neededCalories;
        }
        public static double WomenGain(double weight, double height, int age, double activityCoefficient)
        {
            double gainProcent = (100 + 17.5) / 100;// расчёт процента на массе(костыль энжоер) 
            double neededCalories = ((10 * weight + (6.25 * height) - 5 * age + 5) * activityCoefficient) * gainProcent;

            return neededCalories;
        }
        public static double MenGain(double weight, double height, int age, double activityCoefficient)
        {
            double gainProcent = (100 + 17.5) / 100;// расчёт процента на массе(костыль энжоер) 
            double neededCalories = ((10 * weight + (6.25 * height) - 5 * age + 5) * activityCoefficient) * gainProcent;

            return neededCalories;
        }
    }
}