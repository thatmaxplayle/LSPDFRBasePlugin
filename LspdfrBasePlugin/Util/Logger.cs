using Rage;
using System;
using System.IO;

namespace LspdfrBasePlugin.Util
{
    enum LogVerbosity
    {
        Trivial,
        TrivialDebug,
        Verbose,
        VerboseDebug,
        VeryVerbose,
        VeryVerboseDebug,
        ExtremelyVerbose,
        ExtremelyVerboseDebug
    }

    /// <summary>
    /// Provides functionality for displaying formatted log messages to the Rage console, as well as writing them to a separate, plugin-specific log file.
    /// </summary>
    internal class Logger
    {
        private static readonly string _consolePreface = $"[{Settings.PLUGIN_NAME}]: ";
        private static readonly string _logDirectory = $"{Directory.GetCurrentDirectory()}\\Plugins\\LSPDFR\\{Settings.PLUGIN_NAME}\\";
        private static readonly string _logFileName = $"{Settings.PLUGIN_NAME}.log";
        private static readonly string _logTimeStampFormat = $"[{DateTime.Now:M/d/yyyy H:m:s tt.fff}] ";

        /// <summary>
        /// Displays the given <paramref name="message"/> to the Rage console prefaced by plugin-specific formatting.
        /// </summary>
        /// <param name="message">The message to be displayed in the Rage console</param>
        /// <param name="verbosity">The verbosity of the message.  The more verbose, the more details provided.</param>
        internal static void DisplayToConsole(string message, LogVerbosity verbosity = LogVerbosity.Trivial)
        {
            switch(verbosity)
            {
                case LogVerbosity.Trivial:
                    Game.LogTrivial(_consolePreface + message);
                    break;
                case LogVerbosity.TrivialDebug:
                    Game.LogTrivialDebug(_consolePreface + message);
                    break;
                case LogVerbosity.Verbose:
                    Game.LogVerbose(_consolePreface + message);
                    break;
                case LogVerbosity.VerboseDebug:
                    Game.LogVerboseDebug(_consolePreface + message);
                    break;
                case LogVerbosity.VeryVerbose:
                    Game.LogVeryVerbose(_consolePreface + message);
                    break;
                case LogVerbosity.VeryVerboseDebug:
                    Game.LogVeryVerboseDebug(_consolePreface + message);
                    break;
                case LogVerbosity.ExtremelyVerbose:
                    Game.LogExtremelyVerbose(_consolePreface + message);
                    break;
                case LogVerbosity.ExtremelyVerboseDebug:
                    Game.LogExtremelyVerboseDebug(_consolePreface + message);
                    break;
            }

            if(Settings.EnablePluginLog)
            {
                AppendToLog(message);
            }
        }

        /// <summary>
        /// Creates a folder within \Plugins\LSPDFR with the same name as the plugin if it doesn't exist.  If a log file already exists, it is deleted.
        /// </summary>
        internal static void Setup()
        {
            if (!Directory.Exists(_logDirectory))
            {
                Directory.CreateDirectory(_logDirectory);
            }

            File.Delete(_logDirectory + _logFileName);
        }

        private static void AppendToLog(string message) => File.AppendAllText(_logDirectory + _logFileName, _logTimeStampFormat + message + Environment.NewLine);
    }
}
