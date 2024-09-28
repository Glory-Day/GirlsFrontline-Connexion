namespace Utility.Manager.Resource
{
    public static class AddressableLabelGroup
    {
        public static class AudioClip
        {
            public const string Background = "audio/background";
            public const string Effect     = "audio/effect";
            public const string Voice      = "audio/voice";
        }

        public static class GameObject
        {
            public const string EnemyCharacter = "object/character/enemy";
            public const string PlayerCharacter = "object/character/player";
            public const string Item = "object/item";
            public const string Weapon = "object/weapon";
            public const string Bullet = "object/weapon/bullet";
            public const string Grenade = "object/weapon/grenade";
        }

        public static class Text
        {
            public const string Data = "data";
        }

        public static class UI
        {
            public const string TransitionScreen = "ui/transition_screen";
            public const string OptionScreen = "ui/option_screen";
            public const string PauseScreen = "ui/pause_screen";
        }
    }
}
