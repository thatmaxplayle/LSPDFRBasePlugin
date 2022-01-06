using LspdfrBasePlugin.Util;
using Rage;
using System.Drawing;

namespace LspdfrBasePlugin
{
    /// <summary>
    /// Provides the ability to manipulate user-specified settings on an .ini file
    /// </summary>
    internal static class Settings
    {
        #region General Plugin Settings
        internal const string PLUGIN_NAME = "LSPDFRBasePlugin";

        // After your plugin is uploaded to the LSPDFR website, this number can be retrieved from the URL of your file's download page
        // Example where XXXXX is your file ID: https://www.lcpdfr.com/downloads/gta5mods/scripts/XXXXX-LSPDFRBasePlugin
        internal const int LSPDFR_FILE_ID = -1;
        #endregion

        #region .ini Specific Settings
        private static readonly InitializationFile _ini = new InitializationFile($"Plugins/LSPDFR/{PLUGIN_NAME}.ini");
        #endregion

        #region Settings Properties
        // Example
        internal static bool EnablePluginLog { get; private set; } = false;
        #endregion

        /// <summary>
        /// Loads the settings from an .ini file with the name provided in <see cref="PLUGIN_NAME"/>.
        /// </summary>
        internal static void Load()
        {
            if(!_ini.Exists())
            {
                Logger.DisplayToConsole($"\"{PLUGIN_NAME}.ini\" not found.");
                return;
            }

            Logger.DisplayToConsole($"Loading plugin settings.");
            
            ReadSettingsFromFile();
        }

        /// <summary>
        /// Reads the plugin's .ini file and assigns the values for each section/key into the associated property.
        /// </summary>
        private static void ReadSettingsFromFile()
        {
            // Example:
            EnablePluginLog = _ini.ReadBoolean("Features", nameof(EnablePluginLog), true);
        }

        /// <summary>
        /// Updates the <paramref name="value"/> of the <paramref name="key"/> within the specified <paramref name="section"/> of the plugin's .ini file.
        /// </summary>
        /// <param name="value">Can be of the following types: <see cref="Quaternion"/>, <see cref="Color"/>, <see cref="double"/>,
        /// <see cref="float"/>, <see cref="Rotator"/>, <see cref="byte"/>, <see cref="string"/>, <see cref="long"/>, <see cref="ulong"/>, 
        /// <see cref="short"/>, <see cref="ushort"/>, <see cref="int"/>, <see cref="uint"/>, <see cref="Vector2"/>, <see cref="Vector3"/>, 
        /// <see cref="Vector4"/>, <see cref="bool"/>, <see cref="decimal"/>, or <see cref="object"/></param>
        internal static bool Save<T>(string section, string key, T value)
        {
            if(!_ini.DoesSectionExist(section))
            {
                Logger.DisplayToConsole($"Section \"{section}\" was not found in the .ini file.");
                return false;
            }

            if (!_ini.DoesKeyExist(section, key))
            {
                Logger.DisplayToConsole($"Key \"{key}\" was not found in section \"{section}\".");
                return false;
            }

            switch (value)
            {
                case Quaternion quantValue:
                    _ini.Write(section, key, quantValue);
                    break;
                case Color colorValue:
                    _ini.Write(section, key, colorValue);
                    break;
                case double doubleValue:
                    _ini.Write(section, key, doubleValue);
                    break;
                case float floatValue:
                    _ini.Write(section, key, floatValue);
                    break;
                case Rotator rotatorValue:
                    _ini.Write(section, key, rotatorValue);
                    break;
                case byte byteValue:
                    _ini.Write(section, key, byteValue);
                    break;
                case string stringValue:
                    _ini.Write(section, key, stringValue);
                    break;
                case long longValue:
                    _ini.Write(section, key, longValue);
                    break;
                case ushort ushortValue:
                    _ini.Write(section, key, ushortValue);
                    break;
                case uint uintValue:
                    _ini.Write(section, key, uintValue);
                    break;
                case ulong ulongValue:
                    _ini.Write(section, key, ulongValue);
                    break;
                case Vector2 vector2Value:
                    _ini.Write(section, key, vector2Value);
                    break;
                case Vector3 vector3Value:
                    _ini.Write(section, key, vector3Value);
                    break;
                case Vector4 vector4Value:
                    _ini.Write(section, key, vector4Value);
                    break;
                case short shortValue:
                    _ini.Write(section, key, shortValue);
                    break;
                case int intValue:
                    _ini.Write(section, key, intValue);
                    break;
                case bool boolValue:
                    _ini.Write(section, key, boolValue);
                    break;
                case decimal decimalValue:
                    _ini.Write(section, key, decimalValue);
                    break;
                case object objectValue:
                    _ini.Write(section, key, objectValue);
                    break;
                default:
                    Logger.DisplayToConsole($"Invalid value type provided ({value.GetType()}) while trying to update setting.");
                    return false;
            }

            Logger.DisplayToConsole($"Setting ({section}/{key}) was updated with value \"{value}\".");
            return true;
        }
    }
}
