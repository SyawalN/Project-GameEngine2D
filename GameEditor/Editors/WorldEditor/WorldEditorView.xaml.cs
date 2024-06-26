﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameEditor.GameProject.ViewModel;

namespace GameEditor.Editors
{
    /// <summary>
    /// Interaction logic for WorldEditorView.xaml
    /// </summary>
    public partial class WorldEditorView : UserControl
    {
        public WorldEditorView()
        {
            InitializeComponent();
            Loaded += OnWorldEditorViewLoaded;
        }

        private void OnWorldEditorViewLoaded(object sender, RoutedEventArgs e)
        {
            Loaded -= OnWorldEditorViewLoaded;
            Focus();
            ((INotifyCollectionChanged)Project.UndoRedo.UndoList).CollectionChanged += (s, e) => Focus();
        }

        private void OnClick_BtnPlay(object sender, RoutedEventArgs e)
        {
            if (GameInstance.Game == null) GameInstance.Game = new GameInstance();

            GamePlayView gamePlayWindow = new GamePlayView();
            GameInstance.Game.Project = Project.Current;
            GameInstance.Game.CurrentScene = Project.Current.Scenes.ToList().FirstOrDefault(x => x.IsActive == true);

            gamePlayWindow.Owner = Window.GetWindow(this);
            gamePlayWindow.DataContext = GameInstance.Game;
            gamePlayWindow.Width = 905;
            gamePlayWindow.Height = 381;
            gamePlayWindow.Show();

            IsEnabled = false;

            gamePlayWindow.Closed += (sender, args) =>
            {
                IsEnabled = true;
            };
        }

        private void OnClick_BtnReloadSceneView(object sender, RoutedEventArgs e)
        {
            SceneView.Renderer.InvalidateVisual();
        }
    }
}
