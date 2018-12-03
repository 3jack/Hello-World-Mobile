using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;


namespace HelloWorld
{
    public class UserSettings
    {
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
  

        public static string access_token
        {
            get => AppSettings.GetValueOrDefault(nameof(access_token), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(access_token), value);
        }

        public static string token_type
        {
            get => AppSettings.GetValueOrDefault(nameof(token_type), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(token_type), value);
        }

        public static string username
        {
            get => AppSettings.GetValueOrDefault(nameof(username), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(username), value);
        }

        public static string role
        {
            get => AppSettings.GetValueOrDefault(nameof(role), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(role), value);
        }

        public static void ClearAllData()
        {
            AppSettings.Clear();
        }

    }
}
