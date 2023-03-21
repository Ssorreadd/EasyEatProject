namespace EasyEat.HelperClasses
{
    public static class User
    {
        public static string? Gender { get; set; }
        public static int Age { get; set; }
        public static double Weight { get; set; }
        public static double Height { get; set; }
        public static double NeededCalories { get; set; } = 0;
        public static double AllDayCalories { get; set; } = 0;
        public static string? WeightMode { get; set; }

        public static double Activity
        {
            get
            {
                return 1.55;
            }
            private set { Activity = value; }
        }


        public static void Clear()
        {
            Gender = null;
            Age = 0;
            Height = 0;
            NeededCalories = 0;
            AllDayCalories = 0;
            WeightMode = null;
        }
    }
}