   M S B A M L   `   `   `  ����E  AGameEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:GameEditor.EditorsGameEditor.Editors  5      ;"clr-namespace:GameEditor.UtilitiesGameEditor.Utilities  5      =#clr-namespace:GameEditor.ComponentsGameEditor.Components  5      +    %GameEditor.Editors.SpriteRendererView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:GameEditor.Editors     5      3util"clr-namespace:GameEditor.Utilities     5      4comp#clr-namespace:GameEditor.Components     5        � 	Resources  5         None  Solid Color � RowDefinitions � ColumnDefinitions  LightTextBlockStyle 	 Image � ToolTip �� Property �� Value �� 
TargetType  Spacing �� BasedOn  DropdownButton  FocusVisual �� 
StartPoint	 �� EndPoint  Editor.Window.GrayColor5
 � Color � Offset  Editor.Window.GrayColor4 	 Editor.Window.GrayColor6 
 Editor.Window.GrayColor2  Editor.FontBrush �� 
TargetType � 	Resources  Key  Editor.Window.GrayColor3  Editor.Window.GrayColor1 ��Name J� SnapsToDevicePixels �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName # Editor.Selected.BackgroundBrush   Button.Selected.OpacityBrush  Button.Pressed.OpacityBrush  Editor.Disabled.FontBrush # Button.Disabled.BackgroundBrush  Button.Disabled.BorderBrush��%�  &	        &	      7  &	 B    7  &	 �    7  &	 �    7  7  7  7 	 7 
 7  7  7  7  7  7  7  7  7  7  7  7  7  7  �� 5   
   5      �� 5   
   .R�5      �  5      �� 5      �� 5       5      �� 5      �� 5      .+�5      �� $��1��6   $��0��6)   $��Color��69   8��  $	��0,5q�6s   �� 5      $��1��6   $��1��6'   $	��0,5q�6R   ��67   �� *	ColorName+6R   5      5      �� 5   
   .R�5      �  5      �� 5       �� 5!       5#      �� 5$      �� 5%      .+�5'      �� $��1��6   $��0��6)   $��Choose an image��69   8��  $	��0,5q�6}   �� 5(      -   5        $��1��5(      $��1��6&   $��Center=�5)      $��60��66   $	��0,5q�6A   ��5(   6   Z� .��5*      �� $��CharacterEllipsis=�6;   $��NoWrap=�6\   $��Center=�5+       ��5*       �� *	ImagePath+ 5+   ;   �� *	ImagePath+��5,      �� 5-      .�5.   "   ��  �@^�InitialShowDelay$	 400��6T   5/      51      52      53      54      �� 56   
   " ��6   8   .�57      ��  � ��$	 0,5q�6'   58      �� 59   
   " ��6   .�5:      ��  � ��$ 90��6&   �� 5;       � ��$ 25��6'   �� 5<       � ��$ 12(�6)   �� 5=       �@�FocusVisualStyle8   61   �� 5>       � �� 5?      �� 5@      $	 0,0&�6*   $		 0,1&�6;   .��5A      � 8
  $ 0Q�6Y   � 5B      8
  $ 1Q�6Y   5C      5E      �� 5F       � �� 5G      �� 5H      $	 0,0&�6*   $		 0,1&�6;   .��5I      � 8
  $ 0Q�6Y   � 5J      8
  $ 1Q�6Y   5K      5M      �� 5N       � ��8  6+   �� 5O       � ��$	 0,1q�60   �� 5P       � ��$ Center=�64   �� 5Q       � ��$ Center=�62   �� 5R       � �� 5S      �� 5T      " ��6&    5U      ���� 5V      $	 0,0&�62   $		 0,1&�6C    Button.Selected.OpacityBrush .��5W   "   � $
 White��6/   $ 0Q�6=   � 5X   "   $
 	LightGray��6/   $ 1Q�6A   5Y      �� 5Z      $	 0,0&�62   $		 0,1&�6C   Button.Pressed.OpacityBrush .��5[   "   � $
 White��6/   $ 1Q�6=   � 5\   "   $
 	LightGray��6/   $ 0Q�6A   5]      �� 5^      $	 0,0&�62   $		 0,1&�6C   #Button.Disabled.BackgroundBrush .��5_   "   � 8
  $ 0Q�6a   � 5`   "   8
  $ 1Q�6a   5a      �� 5b      $	 0,0&�62   $		 0,1&�6C   Button.Disabled.BorderBrush .��5c   "   � 8
  $ 0Q�6a   � 5d   "   8
 	 $ 1Q�6a   5e      5f      .R�5g      � .+�5h      �� $ border��6%   #��z��65   #��z��6a   #��z��6�    . $ 3��5i   @   �� 5j      $ borderSelected��6%    . $ 3��6X   $��0q�6i   
������ 6}   �� 5k      $ contentPresenter��6/   |�.  #��z��6[   #��z��6�   ��. # z 6�   #��z��6  5l       5m      P� 5n       �@��IsDefaulted . . �5o   "   �� $ borderSelected��6?   8 
  � ��6[   �� 5p   "   $ borderSelected��6@   8   �@J�OpacityMask6\   5q      P� 5r       �@J�IsMouseOver . . �5s   "   �� $ contentPresenter��6K    � ��
 �����6i   �� 5t   "   $ borderSelected��6?   8   � ��6[   �� 5u   "   $ borderSelected��6@   8   �@J�OpacityMask6\   5v      P� 5w       � �� . . �5x   "   �� $ contentPresenter��6K    � ��
 �����6i   �� 5y   "   $ borderSelected��6?   8   � ��6[   �� 5z   "   $ borderSelected��6@   8   �@J�OpacityMask6\   5{      P� 5|       � {� .  . �5}   "   �� $ contentPresenter��6K   8   � ��6i   �� 5~   "   $ border��6?   8   � ��6S   �� 5   "   $ border��6@   8   � ��6T   5�      5�      5�      5�      5�      .��5�      � $��5,10,5,5q�6   $	��Top=�6    5�   
   �� 5�      �� 5�       5�   
   �� 5�      �� 5�      �� 5�      .+�5�   
   �� $��Sprite Renderer��6   $
��Bold"�6+   #��[ 6=   �� 5�   
   $��0��6   $��1��6$   $��Center=�61   $��Render Type��6L   #��[ 6_   �� 5�   
   -   5        $��Btn_RenderType��5�      #��[ 6E   $��1��5�      $��1��6   $��Right=�6.   $	��0,5q�6J   ��5�   '   �� *	PaintMode+ � ContextMenu 5�      �� 5�      5�      �� 5�   
   -   5         ��Name$ 	ExtraMenu��5�   v   $��2��6   $��2��6&   #��[  6N   ��6:   �� 6v   5�      5�      