   M S B A M L   `   `   `  ����  BibliotecaElectronica(    "BibliotecaElectronica.View.TopView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5	         TopCartiStyle �� 
TargetType �� Property �� Value��%�   &	        �� 5
   
   " ��6&   .�5      ��  � ��
 �����6+   �� 5       � �� �#DDDDDD6,   �� 5       � ��$ 1q�60   �� 5       �@��CornerRadius$ 10��6-   �� 5       � ��$ 20q�6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��1��6   .��5      �� $��1��6    �� Orientation$ Vertical=�6&   .+�5      �� $#��Top 3 cele mai citite cărți��6   $��24(�6?   $
��Bold"�6M   $��Center=�5      $��20q�65   ���#6136876A   �� 5       $��20q�6;   ��6   �� *
TopBooks+ �� SelectedItem 5!      �� *SelectedBook+ �� Mode$ TwoWay=���5"      �� 5#      .R�5$      �  � Orientation$ 
Horizontal=�6(   5%      ��5(      �� 5)      .R�5*      �� #��[  6%   $	��400��6L   $	��200��6Y   ._�5+   "   � .+�5?   &   �� $��Center=�61   $	��Top=�6N   .+�5@   *   �� $��0q�5A   6   
������ $	��300��5B      $	��200��6&   ��5@   1   �� *DataContext.SelectBookCommand+	 �� RelativeSource	 �� 
 �� AncestorType$
 UserControlL���5A      �� .��5C   .   �� $��Uniform=�6S   $	��250��6e   $	��150��6r    � Cursor$
 Hand��6~   ��64   �� *BitmapImage+6~   5D   +   �� 5F   *   $
��Wrap=�6K   $��16(�5G      $
��Bold"�6*    �� TextAlignment$ Center=�6<   $��5q�6S   ��5F   4   �� *Title+5G   S   �� 5H   *   $
��Wrap=�6L   $��14(�6`   $��Italic$�5I      $ Center=�6/   $��0,0,0,5q�6F   ��5H   4   �� *Author+5I   F   5J   '   5K   #   5L      5M      5P      �� 5S      $&�� Top 3 cele mai apreciate cărți��6   $��24(�6B   $
��Bold"�6P   $��Center=�5T      $��20q�65   �� 5V      $��20q�6@   ��6   �� *TopRatedBooks+ 5W      �� *SelectedBook+$ TwoWay=���5X      �� 5Y      .R�5Z      � $ 
Horizontal=�6(   5[      ��5^      �� 5_      .R�5`      �� #��[  6%   $	��400��6L   $	��200��6Y   ._�5a   "   �� $��Center=�6-   $	��Top=�6J   .+�5b   &   �� $��0q�5c   F   
������ $	��300��5d   )   $	��200��66   ��5b   -   �� *DataContext.SelectBookCommand+	 �� $
 UserControlL���5c   )   �� .��5e   *   �� $��Uniform=�6O   $	��250��6a   $	��150��6n   $
 Hand��6z   ��60   �� *BitmapImage+6z   5f   '   �� 5h   &   $
��Wrap=�6H   $��16(�5i   ,   $
��Bold"�6:   $ Center=�6L   $��5q�6c   ��5h   0   �� *Title+5i   c   �� 5j   &   $
��Wrap=�6I   $��14(�6]   $��Italic$�5k   ,   $ Center=�6?   $��0,0,0,5q�6V   ��5j   0   �� *Author+5k   V   5n   #   5o      5p      5r      5s      5t      5u      5v      