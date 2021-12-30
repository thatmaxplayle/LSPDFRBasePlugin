using LSPD_First_Response.Mod.API;
using Rage;


/* 
 * LspdfrBasePlugin
 * Helper project for new developers by Max Playle (thatmaxplayle | LCPDFR.com) 
 * 
 * This is a working base project, which you can use to create your own plugins. By all means, you can of course clone this and make it your own. 
 * All I ask is that you credit me in the final release. 
 * 
 * My LCPDFR profile: 
 */

namespace LspdfrBasePlugin
{
    public class EntryPoint : Plugin
    {
        /// <summary>
        /// This method is called when LSPDFR is initially loaded. You should subscribe to the OnDutyStatusChanged event handler here, and process anything
        /// you need to do before you know that the plugin is definitely going to be loaded.
        /// </summary>
        public override void Finally()
        {
            // Add all registered console commands within the project. Passing no parameters to this method will register all console commands within the assembly.
            Game.AddConsoleCommands();

            // Subscribing this event handler will mean that the OnLSpdfrDutyStatusChanged method will be called when the player goes on or off duty.
            // We can handle important logic, such as registering callouts, in this section.
            Functions.OnOnDutyStateChanged += this.OnLspdfrDutyStatusChanged;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="onDuty"></param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void OnLspdfrDutyStatusChanged(bool onDuty)
        {
            if (onDuty)
            {
                Game.LogTrivial("The player has gone on duty.");
            }
            else
            {
                Game.LogTrivial("The player has gone off duty.");
            }
        }

        public override void Initialize()
        {
            
        }

    }
}
