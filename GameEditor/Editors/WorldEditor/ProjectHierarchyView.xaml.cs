using GameEditor.Components;
using GameEditor.GameProject.ViewModel;
using GameEditor.Utilities;
using SkiaSharp;
using System;
using System.Collections.Generic;
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

namespace GameEditor.Editors
{
    /// <summary>
    /// Interaction logic for ProjectHierarchyView.xaml
    /// </summary>
    public partial class ProjectHierarchyView : UserControl
    {
        private static Expander currExpander;
        private static Expander prevExpander;

        public ProjectHierarchyView()
        {
            InitializeComponent();
        }

        private void OnClickBtn_AddGameObject(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var vm = btn.DataContext as Scene;
            vm.AddGameObjectCommand.Execute(new GameObject(vm) { Name = "Empty Game Object" });
        }

        private void OnSelectionChanged_ListBox_GameObject(object sender, SelectionChangedEventArgs e)
        {
            GameObjectView.Instance.DataContext = null;
            var listBox = sender as ListBox;
            if (e.AddedItems.Count > 0)
            {
                GameObjectView.Instance.DataContext = (sender as ListBox).SelectedItems[0];
                SceneView.Instance.ActiveScene.SelectedGameObject = (GameObject) (sender as ListBox).SelectedItem;
            }

            var newSelection = listBox.SelectedItems.Cast<GameObject>().ToList();
            var previousSelection = newSelection.Except(e.AddedItems.Cast<GameObject>()).Concat(e.RemovedItems.Cast<GameObject>()).ToList();

            Project.UndoRedo.Add(new UndoRedoAction(
                () => { // Undo action
                    listBox.UnselectAll();
                    previousSelection.ForEach(x => (listBox.ItemContainerGenerator.ContainerFromItem(x) as ListBoxItem).IsSelected = true);
                },
                () => { // Redo action
                    listBox.UnselectAll();
                    newSelection.ForEach(x => (listBox.ItemContainerGenerator.ContainerFromItem(x) as ListBoxItem).IsSelected = true);
                },
                "Selection changed"
                ));

            SceneView.Renderer.InvalidateVisual();
        }

        private void OnExpanded_Expander(object sender, RoutedEventArgs e)
        {
            var expander = sender as Expander;
            if (expander != null)
            {
                prevExpander = expander != currExpander ? currExpander : prevExpander;
                currExpander = expander;

                if (prevExpander != null)
                {
                    prevExpander.IsExpanded = false;
                    var prevScene = prevExpander.DataContext as Scene;
                    prevScene.IsActive = false;

                    SceneView.Instance.ActiveScene = currExpander.DataContext as Scene;
                    SceneView.Instance.ActiveScene.IsActive = true;
                }

                if (SceneView.Instance.ActiveScene != null)
                    SceneView.OnPropertyChanged_UpdateCanvas(SceneView.Instance.ActiveScene);
            }

            GameObjectView.Instance.DataContext = SceneView.Instance.ActiveScene.SelectedGameObject;
        }

        private void OnLoaded_Expander(object sender, RoutedEventArgs e)
        {
            var expander = sender as Expander;
            if (expander != null && expander.IsExpanded)
            {
                currExpander = expander;
                SceneView.Instance.ActiveScene = currExpander.DataContext as Scene;
            }
        }
    }
}
