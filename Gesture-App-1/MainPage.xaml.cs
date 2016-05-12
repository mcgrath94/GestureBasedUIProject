using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Gesture_App_1;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Gesture_App_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
            private ObservableCollection<RecipeItem> RecipeItems;
            public bool launchedNormal = true;

            public MainPage()
            {
                this.InitializeComponent();
                RecipeItems = new ObservableCollection<RecipeItem>();
            }

            private void HamburgerButton_Click(object sender, RoutedEventArgs e)
            {
                MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
            }

            private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (Breakfast.IsSelected)
                {
                    RecipeManager.GetRecipe("Breakfast", RecipeItems);
                    TitleTextBlock.Text = "Breakfast";
                }
                else if (Dinner.IsSelected)
                {
                    RecipeManager.GetRecipe("Dinner", RecipeItems);
                    TitleTextBlock.Text = "Dinner";
                }
            }

            private void Page_Loaded(object sender, RoutedEventArgs e)
            {
                //if (launchedNormal == true)
                //{
                    Breakfast.IsSelected = true;
                //}
            }

            public void BreakfastVoice()
            {
                //launchedNormal = false;  do not need this as it goes to breakfast recipes automatically anyway
                RecipeManager.GetRecipe("Breakfast", RecipeItems);
                TitleTextBlock.Text = "Breakfast";
            }
            public void DinnerVoice()
            {
                launchedNormal = false;
                RecipeManager.GetRecipe("Dinner", RecipeItems);
                TitleTextBlock.Text = "Dinner";
            }


        }
    }

