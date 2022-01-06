using System.IO;

namespace LspdfrBasePlugin.Util
{
    /// <summary>
    /// Rage refers to files in the \Plugins folder, LSPDFR refers to files in the \Plugins\LSPDFR folder, and Game refers to files in the root GTA folder
    /// </summary>
    enum PluginType
    { 
        Rage,
        LSPDFR,
        Game
    }
    
    internal class DependencyChecker
    {
        /// <summary>
        /// Checks if a file with the given <paramref name="fileName"/> is found in the correct directory based on the specified <paramref name="pluginType"/>
        /// </summary>
        /// <param name="pluginType">PluginType.Rage checks \Plugins, PluginType.LSPDFR checks \Plugins\LSPDFR, and PluginType.Game checks the root GTA folder</param>
        /// <param name="fileName">The name (case-insensitive and without extension) of the file.</param>
        /// <param name="fileExtension">The file extension of the dependency being checked.  dll by default</param>
        internal static bool IsDependencyPresent(PluginType pluginType, string fileName, string fileExtension = "dll")
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            switch (pluginType)
            { 
                case PluginType.Rage:
                    currentDirectory += @"\Plugins";
                    break;
                case PluginType.LSPDFR:
                    currentDirectory += @"\Plugins\LSPDFR";
                    break;
            }

            return File.Exists($"{currentDirectory}\\{fileName}.{fileExtension}");
        }
    }
}
