   M S B A M L   `   `   `  ����E  AGameEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:GameEditor.UtilitiesGameEditor.Utilities  5      %    GameEditor.Utilities.LoggerView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:GameEditor.Utilities     5        � 	Resources  5	       �� 
TargetType �� Property �� Value   Editor.Window.GrayBrush4 �� 
TargetType ��Name J� SnapsToDevicePixels �� Triggers P� Property	 P� Value
 �� 
TargetName �� ElementName��%�  'd�       7   �� 5
   
   " d�6   .�5      ��  �@�FocusVisualStyle 61   Z� �� 5       � ��8   6,   �� 5       � ��$ 24��6&   �� 5       � ��$ 1q�60   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   -   5        �� 5       � �� 5      �� 5      " d�6&   .R�5      �� $ outerBorder��6!   #��z��66   #��z��6b    . ._�5      �� $ innerBorder��6%   #��z��6:   $��1q�6d   5       5      P� 5       �@J�IsMouseOver	 . . �5   "   �� $
 innerBorder��6@    5   )   �� *
Background+$ innerBorder�� � ��5      P� 5       �@d�	IsChecked$	 FalseY�6;   . �5   "   �� $
 innerBorder��6<    �@J�Opacity$	 0.5Q�6U   5       P� 5!       � {�	 .  . �5"   "   �� $
 innerBorder��6<    �@J�Opacity$	 0.2Q�6U   5#      5%      5'      5(      5)      .��5*      � .+�5+   
   �� -   5         ��Name$ scrollViewer��5,      $
��Auto=�5+      $
��Auto=�6:   $��0,32,0,0q�6_     Editor.Window.GrayBrush2#��[ 5,   -   .��5-      �� ��6   �� !  GameEditor.Utilities.Logger   FilteredMessages �� Source# Z ��5.      �� 5/      .R�50      �� 51      ��53      �� 54      .R�55      ]�  � ToolTip 6$   �� *
MetaData+��56      �� 57   "   " ]�6(   .�58   &   ��  � ��
 ���� 6C    �� Triggers 59   &   P� 5:   *    �@J�IsMouseOver	 . . �5;   .   ��  � �� # Editor.Selected.BackgroundBrush# [ 6K   5<   +   5>   #   .+�5@      �� $	��5,0q�6U   ��6(   �� *Time+ �� StringFormat$ hh:mm:ss����5A   "   �� 5B   &   " ��6,   .�5C   *   ��  � ��
 ����6G    5D   *   �� 5E   .   &   GameEditor.Utilities.MessageType   Warning �� Value# Z 6Z    �� Binding 6:   �� *MessageType+.a�5F   2   ��  � �� �	#ffffbb226O   5G   /   �� 5H   .      Error# Z 6Z    6:   �� *MessageType+.a�5I   2   ��  � �� �	#ffff44556O   5J   /   5L   '   5N      �� 5O      $
��Wrap=�6A     LightTextBlockStyle#��[ 6U   ��6(   �� *	Message+6U   5P      5Q      5S      5T      �� 5U   
   $��32��6   $	��Top=�6     Editor.Window.GrayBrush3#��[ 65   ._�5V      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $	��4,0q�6N   $��Center=�6[   .+�5W      �� -   5        $��Clear��5W      $	��1,0q�6)   |�.  6R   d� 5X      -   5         d�Name$ 
toggleInfo��5Y       d� 	IsChecked$
 TrueY�5X      $
��Info��60   $	��1,0q�6?   $! Toggle information messages��6L     Editor.GreenBrush#��[ 5Y   3   d� 5Z      -   5        $ toggleWarning��5[      $
 TrueY�5Z      $��Warning��60   $	��1,0q�6B   $ Toggle warning messages��6O     Editor.YellowBrush#��[ 5[   6   d� 5\      -   5        $ toggleError��5]      $
 TrueY�5\      $��Error��60   $	��1,0q�6@   $ Toggle error messages��6M     Editor.RedBrush#��[ 5]   4   5^      5_      5`      5a      