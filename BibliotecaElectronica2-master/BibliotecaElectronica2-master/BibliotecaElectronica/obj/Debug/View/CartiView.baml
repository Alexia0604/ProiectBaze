   M S B A M L   `   `   `  ����  BibliotecaElectronica*    $BibliotecaElectronica.View.CartiView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��10q�6K   .+�5      �� $	��400��6   $��30��6"   $��14(�6.   $��Center=�5      $��0,0,10,0q�61   ��5   <   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�5   1   �� 5      $��Search��6   $	��100��6&   $��30��62   $��14(�6>   ��6L   �� *SearchCommand+5      �� 5   
   $��1��6   .��5      �� $��10q�64   ��6   �� *Books+ �� SelectedItem 5   
   �� *SelectedBook+ �� Mode$ TwoWay=���5      �� 5      .R�5      � 5      ��5       �� 5!      .R�5"      �� 
�������$��1q�64    �� CornerRadius$ 5��6H   $��10q�6Y   $	��200��6e   $	��300��6q   ._�5#      �� $��Center=�6)   $��Center=�6F   $��5q�6a   .+�5$   "   �� $��0q�5&   )   $	��140��6>   $	��150��6J   
������ ��5$   )   �� *DataContext.SelectBookCommand+ �� RelativeSource ��  �� AncestorType$ ListBoxL���5%   )   �� .��5(   &   �� $	��140��6K   $	��150��6W    � Cursor$
 Hand��6d   ��6,   �� *BitmapImage+6d   5)   #   �� 5*   "   $
��Bold"�6C   $��14(�6U   	 �� TextAlignment$	 Center=�6c   $��0,5,0,0q�6z   ��6,   �� *Title+6z   �� 5+   "   $��Italic$�6D   $��12(�6W   $	 Center=�6e   ��6,   �� *Author+6e   5,      5-      5.      50      51      52      53      