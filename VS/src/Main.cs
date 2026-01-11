global using static TimeScaleHotkey.Utility;
using System.Reflection.Metadata.Ecma335;

namespace TimeScaleHotkey
{
    public class Main : MelonMod
    {
        public bool active = false;
        public bool active2 = false;

        public override void OnInitializeMelon()
        {
            Settings.OnLoad();
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(Settings.options.key))
            {
                if (InterfaceManager.DetermineIfOverlayIsActive()) return;

                if (Settings.options.hold)
                {
                    active = true;
                }
                else 
                {
                    active = !active;
                    active2 = false;
                }

                float scale = active ? Settings.options.scale : 1f;

                if (Time.timeScale != scale)
                {
                    if (Settings.options.addAnotherKey && active2 && scale == 1f) return;

                    Time.timeScale = (GameManager.m_GlobalTimeScale = scale);
                }
            }

            if (Settings.options.hold && Input.GetKeyUp(Settings.options.key))
            {
                if (active)
                {
                    active = false;
                    if (Settings.options.addAnotherKey && !active2) Time.timeScale = (GameManager.m_GlobalTimeScale = 1f);
                }
            }

            if (Settings.options.addAnotherKey)
            {
                if (Input.GetKeyDown(Settings.options.key2))
                {
                    if (InterfaceManager.DetermineIfOverlayIsActive()) return;

                    if (Settings.options.hold)
                    {
                        active2 = true;
                    }
                    else
                    {
                        active2 = !active2;
                        active = false;
                    }

                    float scale = active2 ? Settings.options.scale2 : 1f;

                    if (Time.timeScale != scale)
                    {
                        if (active && scale == 1f) return;

                        Time.timeScale = (GameManager.m_GlobalTimeScale = scale);
                    }
                }

                if (Settings.options.hold && Input.GetKeyUp(Settings.options.key2))
                {
                    if (active2)
                    {
                        active2 = false;
                        if (!active) Time.timeScale = (GameManager.m_GlobalTimeScale = 1f);
                    }
                }

            }
        }
    }
}




