namespace DefaultNamespace.Runner
{
    public static class Store
    {
        private const string BEST_SCORE_KEY = "bestScore";
        private const string DIFFICULTY_LEVEL_KEY = "difficultyLevel";
        private const string SOUND_KEY = "soundLevel";

        public static IntEntry BestScore { get; } = new IntEntry(BEST_SCORE_KEY);
        public static DifficultyLevelEntry DifficultyLevel { get; } = new DifficultyLevelEntry(DIFFICULTY_LEVEL_KEY);
        public static IntEntry Sound { get; } = new IntEntry(SOUND_KEY);
    }
}