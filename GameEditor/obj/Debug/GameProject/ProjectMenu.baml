   M S B A M L   `   `   `  ����E  AGameEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:GameEditor.GameProjectGameEditor.GameProject  5   	   I)clr-namespace:GameEditor.GameProject.ViewGameEditor.GameProject.View  5   	   S.clr-namespace:GameEditor.GameProject.ViewModel GameEditor.GameProject.ViewModel  5   	   (    "GameEditor.GameProject.ProjectMenu   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:GameEditor.GameProject     5   	   :view)clr-namespace:GameEditor.GameProject.View     5   	   D	viewmodel.clr-namespace:GameEditor.GameProject.ViewModel     5   	     � 
ResizeMode$  NoResize=�5	       � WindowStartupLocation$ CenterScreen=�5
   	    � Title$ ProjectMenu��5   	   $	��500��6   $	��812��6*      ProjectMenuStyle#��[  5   	    � 	Resources 5       �� 
TargetType �� Property �� Value  Editor.Disabled.FontBrush �� 
TargetType J� Effect3  -System.Windows.Media.Effects.DropShadowEffect	   
BlurRadius
   ShadowDepth   Opacity �� Triggers P� Property P� Value  Editor.Window.GrayBrush4 ]� 
Conditions �� Property �� Value  Editor.FontBrush��%t  'd�       7  7  7  �� 5   
   " d�6   .�5      ��  � ��$ 32(�6)   �� 5       � ��$ Bahnschrift condensed)�6+   �� 5       � ��
 ���� 6+   �� 5       � ��
 ���� 6,   �� 5       � ��8   6+   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � �� 5      �� 5      " d�6&   .R�5      �� #��z��6$   ��6L   Z�  5        5   "   $	 2Q�63   $
 1Q�6B   $	 0.6Q�6R   5       5      P� 5       � {� .  . �5    "   �� 8   � ��6?   5!      P� 5"       �@d�	IsChecked$
 TrueY�6;   . �5#   "   ��  � ��
 �����6?   5$      ]� 5%       5&   "   �� 5'   &    �@J�IsMouseOver . 6G   �� 5(   &    �@d�	IsChecked$ FalseY�6E   ./�5*   "   �� 8   � ��6?   5+      5-      5/      50      51      .��52      �  � RowDefinitions 53   
   �� 54      $
��Auto �6   �� 55      $��1* �6   .+�58   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��Center=�6;   .+�59      d� -   5         d�Name$ openProjectButton��5:      $��OPEN PROJECT��59      $��0, 0, 25, 0q�62    d� 	IsChecked$
 TrueY�5:   M   d� 5;      -   5        $ createProjectButton��5<      $��CREATE PROJECT��5;      $��25, 0, 0, 0q�64   $ FalseY�5<   O   5=      �� 5?   
   $��5��6   $��Center=�6   $��Bottom=�69   �� 5A   
   -   5         ��Name$ WindowPanel��5A   V   $ 
Horizontal=�6   $
��Left=�6.   $��1��6I   .+�5B      1   +GameEditor.GameProject.View.OpenProjectView  -   5          Name$ openProjectView��5B   #   3   -GameEditor.GameProject.View.CreateProjectView  5C      -   5          Name$ createProjectView��5C   %   5D      5E      5F      