   M S B A M L   `   `   `  ����P  LBibliotecaElectronica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:BibliotecaElectronica.ViewBibliotecaElectronica.View  5      (    "BibliotecaElectronica.View.TopView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:BibliotecaElectronica.View     5        � 	Resources  5
         TopCartiStyle �� 
TargetType �� Property �� Value��%�   &	        �� 5   
   " ��6&   .�5      ��  � ��
 �����6+   �� 5       � �� �#DDDDDD6,   �� 5       � ��$ 1q�60   �� 5       �@��CornerRadius$ 10��6-   �� 5       � ��$ 20q�6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $#��Top 3 cele mai citite cărți��6   $��24(�67   $
��Bold"�6E   $��Center=�6W   $��Center=�6t   $��20q�6�   �� 5   
   $��1��6   .��5       �� $��20q�67   ��6   �� *
TopBooks+ �� SelectedItem 5!      �� *SelectedBook+ �� Mode$ TwoWay=���5"      �� 5#      .R�5$      �  � Orientation$ 
Horizontal=�6$   5%      ��5(      �� 5)      .R�5*      �� #��[  6!   $	��400��6H   $	��200��6U   ._�5+      �� $��Center=�6)   $	��Top=�6F   .+�5,   "   �� $��0q�5-   F   
������ $	��300��5.   )   $	��200��66   ��5,   )   �� *DataContext.SelectBookCommand+ �� RelativeSource �� 	 �� AncestorType$	 UserControlL���5-   )   �� .��5/   &   �� $��Uniform=�6K   $	��250��6]   $	��150��6j   
 � Cursor$

 Hand��6v   ��6,   �� *BitmapImage+6v   50   #   �� 52   "   $
��Wrap=�6D   $��16(�53   ,   $
��Bold"�6:    �� TextAlignment$ Center=�6L   $��5q�6c   ��52   ,   �� *Title+53   c   �� 54   "   $
��Wrap=�6E   $��14(�6Y   $��Italic$�6g   $ Center=�6z   $��0,0,0,5q�6�   ��6,   �� *Author+6�   56      57      58      5:      5;      5<      5=      