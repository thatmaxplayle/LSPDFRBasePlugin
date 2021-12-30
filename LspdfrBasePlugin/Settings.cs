using Rage;

namespace LspdfrBasePlugin
{
    /// <summary>
    /// Provides the ability to read and apply user-specified settings from an .ini file
    /// </summary>
    internal static class Settings
    {
        // Plugin-wide settings
        internal const string PLUGIN_NAME = "LSPDFRBasePlugin";

        // After your plugin is uploaded to the LSPDFR website, this number can be retrieved from the URL of your file's download page
        // Example where XXXXX is your file ID: https://www.lcpdfr.com/downloads/gta5mods/scripts/XXXXX-LSPDFRBasePlugin
        internal const int LSPDFR_FILE_ID = -1; 

        // .ini specific settings
        private static readonly InitializationFile _ini = new InitializationFile($"Plugins/LSPDFR/{PLUGIN_NAME}.ini");

        // Add settings properties below
        // Example: internal static bool EnableCoolFeature { get; private set; } = false;

        /// <summary>
        /// Loads the settings from an .ini file with the name provided in <see cref="PLUGIN_NAME"/>.
        /// </summary>
        internal static void Load()
        {
            if(!_ini.Exists())
            {
                Game.LogTrivial($"[{PLUGIN_NAME}]: Settings file not found.");
                return;
            }

            Game.LogTrivial($"[{PLUGIN_NAME}]: Loading plugin settings.");

            // Read from _ini into properties below
            // Example: EnableCoolFeature = _ini.ReadBoolean("Features", "EnableCoolFeature", false);
        }
    }
}
