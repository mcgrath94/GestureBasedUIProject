﻿using System;
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
using Windows.UI.Popups;
using Gesture_App_1;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Gesture_App_1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Frame rootFrame = new Frame();

        MessageDialog dialog = new MessageDialog("");

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
                if(launchedNormal == true)
                {
                    RecipeManager.GetAllRecipe(RecipeItems);
                    TitleTextBlock.Text = "All Recipes";
                }
               
            }

            public void BreakfastVoice()
            {
                launchedNormal = false;  
                RecipeManager.GetRecipe("Breakfast", RecipeItems);
                TitleTextBlock.Text = "Breakfast";
            }

            public void DinnerVoice()
            {
                launchedNormal = false;
                RecipeManager.GetRecipe("Dinner", RecipeItems);
                TitleTextBlock.Text = "Dinner";
            }

            public void difficultyRecipeVoice(string difficulty)
            {
            //testing
            launchedNormal = false;
            RecipeManager.GetDifficulty(difficulty, RecipeItems);
            TitleTextBlock.Text = "Chosen Recipes";
            }

            

        private void RecipeItemGrid_ItemClick(object sender, ItemClickEventArgs e)
        {
            var recipe = (RecipeItem)e.ClickedItem;

            ClickedItemTitle.Text = recipe.RecipeName;
            ClickedItemIngredients.Text = "Ingredients: " + recipe.Ingredients;
            ClickedItemDirections.Text = "Directions: " + recipe.Directions;
        }

        

    }
}

