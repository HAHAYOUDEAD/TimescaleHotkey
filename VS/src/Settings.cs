using ModSettings;

namespace TimeScaleHotkey
{
    internal static class Settings
    {
        public static void OnLoad()
        {
            Settings.options = new TimeScaleHotkeySettings();
            Settings.options.AddToModSettings("Timescale Hotkey");
            AddAnotherKey(options.addAnotherKey);
        }

        public static TimeScaleHotkeySettings options;

        internal static void AddAnotherKey(bool visible)
        {
            options.SetFieldVisible(nameof(options.key2), visible);
            options.SetFieldVisible(nameof(options.scale2), visible);
        }
    }

    internal class TimeScaleHotkeySettings : JsonModSettings
    {
        //[Section("Template")]

        [Name("Hotkey")]
        [Description("")]
        public KeyCode key = KeyCode.Mouse4;
        
        [Name("Scale")]
        [Description("1 = normal flow of time\n\n<1 = slow down\n\n>1 = speed up")]
        [Slider(0, 5, 51)]
        public float scale = 1.5f;

        [Name("Hold")]
        [Description("Hold or toggle")]
        public bool hold = false;


        [Name("Add another key")]
        [Description("In case you want one for slowdown and another for speedup")]
        public bool addAnotherKey = false;

        [Name("Second Hotkey")]
        [Description("")]
        public KeyCode key2 = KeyCode.None;

        [Name("Second Scale")]
        [Description("1 = normal flow of time\n\n<1 = slow down\n\n>1 = speed up")]
        [Slider(0, 5, 51)]
        public float scale2 = 1f;

        protected override void OnChange(FieldInfo field, object oldValue, object newValue)
        {
            if (field.Name == nameof(addAnotherKey)) Settings.AddAnotherKey((bool)newValue);
        }

        protected override void OnConfirm()
        {
            base.OnConfirm();
        }
    }
}
