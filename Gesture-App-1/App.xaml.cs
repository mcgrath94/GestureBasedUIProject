﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Media.SpeechRecognition;
using Windows.Storage;
using Windows.UI.Popups;

namespace Gesture_App_1
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {


        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
                Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
                Microsoft.ApplicationInsights.WindowsCollectors.Session);
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e) 
        {

#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif
            
                Frame rootFrame = Window.Current.Content as Frame;

                // Do not repeat app initialization when the Window already has content,
                // just ensure that the window is active
                if (rootFrame == null)
                {
                    // Create a Frame to act as the navigation context and navigate to the first page
                    rootFrame = new Frame();

                    rootFrame.NavigationFailed += OnNavigationFailed;

                    if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                    {
                        //TODO: Load state from previously suspended application
                    }

                    // Place the frame in the current Window
                    Window.Current.Content = rootFrame;
                }

                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate();
            

            try
            {
                StorageFile vcd = await Package.Current.InstalledLocation.GetFileAsync(@"VCD.xml");
                await VoiceCommandDefinitionManager.InstallCommandDefinitionsFromStorageFileAsync(vcd);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Installing Voice Commands Failed: " +ex.Message);
            }

        }

        protected async override void OnActivated(IActivatedEventArgs args)
        {
            base.OnActivated(args);

                //taken from OnLaunched so app can be launched using cortana
                Frame rootFrame = Window.Current.Content as Frame;

                // Do not repeat app initialization when the Window already has content,
                // just ensure that the window is active
                if (rootFrame == null)
                {
                    // Create a Frame to act as the navigation context and navigate to the first page
                    rootFrame = new Frame();

                    rootFrame.NavigationFailed += OnNavigationFailed;

                    if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                    {
                        //TODO: Load state from previously suspended application
                    }

                    // Place the frame in the current Window
                    Window.Current.Content = rootFrame;
                }

                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage));
                }
                // Ensure the current window is active
                Window.Current.Activate();
            


            if (args.Kind == ActivationKind.VoiceCommand)
            {
                //VoiceCommandActivatedEventArgs command = args as VoiceCommandActivatedEventArgs;
                //SpeechRecognitionResult result = command.Result;

                var commandArgs = args as Windows.ApplicationModel.Activation.VoiceCommandActivatedEventArgs;
                var speechRecognitionResult = commandArgs.Result;
                string commandName = speechRecognitionResult.RulePath[0];
                string textSpoken = speechRecognitionResult.Text;

                //string commandName = result.RulePath[0];

                //testing the timetaken command
                string spokenDifficulty = "";
                try
                {
                    spokenDifficulty = speechRecognitionResult.SemanticInterpretation.Properties["difficulty"][0];
                }
                catch
                {
                    //
                }

                
                string difficulty = null;

                switch(spokenDifficulty)
                {
                    case "Easy":
                        difficulty = "Easy";
                        break;
                    case "Medium":
                        difficulty = "Medium";
                        break;
                    case "Hard":
                        difficulty = "Hard";
                        break;
                    default:
                        Debug.WriteLine("No matching command found");
                        break;
                }


                MessageDialog dialog = new MessageDialog("");
                MainPage page = rootFrame.Content as MainPage;
                if (page == null)
                {
                    return;
                }


                switch (commandName)
                {
                    case "openMainPage":
                        //show all recipes
                        rootFrame.Navigate(typeof(MainPage));
                        //dialog.Content = "This is the test - could be used to open dialog";
                        break;

                    case "openBreakfasts":
                        //go to breakfast recipes
                        page.BreakfastVoice();
                        break;

                    case "openDinners":
                        //go to dinner recipes 
                        page.DinnerVoice();
                        break;

                    case "showDifficulty":
                        //go to dinner recipes 
                        page.difficultyRecipeVoice(difficulty);
                        break;

                    case "showAbout":
                        //show about the app
                        dialog.Title = "How to use this app";
                        dialog.Content = "This app is a Cookbook app witch can be used with Cortana to show the user recipes. You can ask Cortana something like 'Listen show me breakfast recipes', 'Listen show me dinner ideas' or 'Listen show me hard recipes' ";
                        await dialog.ShowAsync();
                        break;

                    default:
                        Debug.WriteLine("No matching command found");
                        break;
                    
                }
                 
                
            }
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
