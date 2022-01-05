using Rage;
using Rage.Attributes;
using Rage.ConsoleCommands.AutoCompleters;

namespace LspdfrBasePlugin
{
    /// <summary>
    /// Provides the ability to define console commands for use in-game.
    /// </summary>
    internal class ConsoleCommands
    {
        /// <summary>
        /// Displays a log message when typing "ExampleCommand" into the in-game console.  The command uses a boolean auto completer which defaults to true.  Specifying false will not display the message.
        /// </summary>
        [ConsoleCommand("ExampleCommand")]
        internal static void Command_ExampleCommand([ConsoleCommandParameter(AutoCompleterType = typeof(ConsoleCommandAutoCompleterBoolean), Name = "ExampleCommand")] bool showMessage = true)
        {
            if (!showMessage)
            {
                return;
            }

            Game.LogTrivial($"[{Settings.PLUGIN_NAME}]: This message is displayed when you use ExampleCommand.");
        }
    }
}
