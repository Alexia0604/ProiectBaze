   M S B A M L   `   `   `  ����P  LBibliotecaElectronica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:BibliotecaElectronica.ViewBibliotecaElectronica.View  5      Q-clr-namespace:BibliotecaElectronica.ViewModelBibliotecaElectronica.ViewModel  5      .    (BibliotecaElectronica.View.ReturnariView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:BibliotecaElectronica.View     5      =vms-clr-namespace:BibliotecaElectronica.ViewModel     5      X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      $	��600��5
   3      
Page_Style#��[  5        � 	Resources  5         BooleanToVisibilityConverter��%   &	       �� 5   
   6'   5      .��5      � $��10q�6   .+�5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     CanUserAddRows .     
IsReadOnly .    CanUserReorderColumns .     CanUserResizeColumns .  $��	0,50,0,50q�5      ��5      �� *CartiReturnate+ �� SelectedItem 5      �� *SelectedItem+   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Cititor��6*   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 80 6;   
   CellTemplate
 5      �� 5      .R�5      �� $
��Wrap=�5       $��Center=�5        �� Padding$ 5q�5       ��5   (   �� *Value.Cititor+5       5       5"        5#      $ 
ID Cititor��6*   $	 95 6>   
 5$      �� 5%      .R�5&      �� $
��Wrap=�5'   !   $��Center=�5(   !   $ 5q�5)   !   ��5&   (   �� *Value.IDCititor+5)   !   5*      5,        5-      $ Titlul cărții��6)   $	 * 6@   
 5.      �� 5/      .R�50      �� $
��Wrap=�51      $ 5q�53      ��50   (   �� *	Key.Title+53      54      56        57      $ Data solicitării��6)   $	 * 6C   
 58      �� 59      .R�5:      �� $
��Wrap=�5;      $ 5q�5=      ��5:   (   �� *" Value.DataCerereReturnareAfisata+5=      5>      5@        5C      $ Acțiuni��6)      
IsReadOnly . $	 * 6L   
 5D      �� 5E      .R�5F      ��  �� Orientation$ 
Horizontal=�6)   .+�5G   "   �� $	��5,0q�5I   !   $��40��6.   $��30��69   
���"�"�
������ ��5G   )   �� *%#DataContext.AprobaSolicitareCommand+ �� RelativeSource ��  �� AncestorType$ UserControlL���5H   !   �� y�5L   )   �� *Value.IsButtonVisible+ �� 	Converter# [ .��5M   &   �� $	��✓��60   $��20(�69   
��� � �$��Center=�6[   $��Center=�6x   5N   #   �� 5P   "   $	��5,0q�5R   %   $��40��62   $��30��6=   
���  ��
������ ��5P   )   �� *'%DataContext.RespingeSolicitareCommand+ �� $ UserControlL���5Q   %   �� y�5U   )   �� *Value.IsButtonVisible+# [ .��5V   &   �� $	��✗��60   $��20(�69   
���  ��$��Center=�6Y   $��Center=�6v   5W   #   5X      5Y      5[      5b      5e      5f      