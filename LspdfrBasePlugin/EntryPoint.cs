using LSPD_First_Response.Mod.API;
using LspdfrBasePlugin.Util;
using Rage;


/* 
 * LspdfrBasePlugin
 * Helper project for new developers by Max Playle (thatmaxplayle | LCPDFR.com) 
 * 
 * This is a working base project, which you can use to create your own plugins. By all means, you can of course clone this and make it your own. 
 * All I ask is that you credit me in the final release. 
 * 
 * My LCPDFR profile: https://www.lcpdfr.com/profile/403804-thatmaxplayle/
 */

/*
 * LspdfrBasePlugin
 * 
 * Copyright 2022 Max Playle (thatmaxplayle)
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal 
 * in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies 
 * of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

[assembly: Rage.Attributes.Plugin("LSPDFR Base Plugin", Author = "[YOUR NAME HERE]", Description = "[YOUR DESCRIPTION HERE]", PrefersSingleInstance = true)]

namespace LspdfrBasePlugin
{
    public class EntryPoint : Plugin
    {

        /// <summary>
        /// This method is called when LSPDFR is initially loaded. You should subscribe to the OnDutyStatusChanged event handler here, and process anything
        /// you need to do before you know that the plugin is definitely going to be loaded.
        /// </summary>
        public override void Initialize()
        {
            // Calling the method below will read and appply the settings specified in the plugin's .ini file.
            Settings.Load();

            /// If you'd like to have a plugin-specific log file that isn't cluttered with entries from other plugins, uncomment the code below.
            //if(Settings.EnablePluginLog)
            //{
            //    Logger.Setup();
            //}

            // Add all registered console commands within the project. Passing no parameters to this method will register all console commands within the assembly.
            Game.AddConsoleCommands();

            // Subscribing this event handler will mean that the OnLSpdfrDutyStatusChanged method will be called when the player goes on or off duty.
            // We can handle important logic, such as registering callouts, in this section.
            Functions.OnOnDutyStateChanged += OnLspdfrDutyStatusChanged;
        }


        /// <summary>
        /// This method is called when LSDPFR unloads. Note, this could be due to a crash - so it is not advisable to do any heavy operations here, or to sleep any GameFibers here.
        /// </summary>
        public override void Finally()
        {
            // Clean up everything you've created! 

            Logger.DisplayToConsole($"Plugin has cleaned up successfully.");
        }

        /// <summary>
        /// This method is called by <see cref="Initialize"/> when the player goes on/off Duty. The value of <paramref name="onDuty"/> depends on if they went on duty or off duty.
        /// </summary>
        /// <param name="onDuty">Whether the player (after the change) is now on duty or not.</param>
        private void OnLspdfrDutyStatusChanged(bool onDuty)
        {
            if (onDuty)
            {
                Logger.DisplayToConsole("The player has gone on duty.");
            }
            else
            {
                Logger.DisplayToConsole("The player has gone off duty.");
            }

            // =================================================================================================================================================
            // You may wish to perform a Version Check here. This is built right into BaseLspdfrPlugin. 
            // All you have to do is first, set LSPDFR_FILE_ID in Settings.cs. 
            // This is required for using the Version Checker, otherwise you'll get an error. Then, simply uncomment this line and write the logic you want
            // for when the plugin is out of date.

            //VersionCheck.CheckForUpdates();
            // =================================================================================================================================================


            // Register callouts here
        }


    }
}
