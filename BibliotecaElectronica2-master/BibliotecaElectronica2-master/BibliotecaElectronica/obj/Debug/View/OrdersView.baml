   M S B A M L   `   `   `  ����P  LBibliotecaElectronica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:BibliotecaElectronica.ViewBibliotecaElectronica.View  5      Q-clr-namespace:BibliotecaElectronica.ViewModelBibliotecaElectronica.ViewModel  5      Q-clr-namespace:BibliotecaElectronica.UtilitiesBibliotecaElectronica.Utilities  5
      +    %BibliotecaElectronica.View.OrdersView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:BibliotecaElectronica.View     5      =vms-clr-namespace:BibliotecaElectronica.ViewModel     5      X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      =	utilities-clr-namespace:BibliotecaElectronica.Utilities  5
      $	��600��5   3      
Page_Style#��[  5        � 	Resources  5         BooleanToVisibilityConverter@   :BibliotecaElectronica.Utilities.CountToVisibilityConverter  CountToVisibilityConverter��%:   &	       &	      �� 5   
   6'     5   
   6/   5      .��5      ��  �� Padding$ 0q�6   
������  �� CornerRadius$ 8��62   ���#E0E0E0$��0q�6Y   ._�5   
   � .+�5      �� $��Nu există împrumuturi!��6   $��20(�5      $
��Bold"�5      
�������$��Italic$�5      $��Center=�5       $��Center=�5!      y�5"      �� *CartiImprumutate.Count+ �� 	Converter# [ �� 5$      $
��Auto=�6   .��5%      �� $��0q�6C   ��6   �� *CartiImprumutate+ �� SelectedItem 5&      �� *SelectedItem+ �� Mode$ TwoWay=���5(      �� 5)      .R�5*      �� $��5q�6%   $	��590��60   $ 10q�6<   
�������$ 5��6\   ���#efdaf7$��1q�6�   ._�5+   "   � $��0,0,0,0q�6'    � ColumnDefinitions 5,   &   �� 5-   *   $	��200 �6;   �� 5.   *   $��* �6;   �� 5/   *   $	��200 �6;   .+�52   &   �� $��0��6,   $��0,0,10,0q�6_   $	��150��6q   $	��200��6}   $
��Left=�6�   ��6<   �� *Key.BitmapImage+6�   �� 54   &   $��1��61   $��2��6A   $��Center=�6U   .+�55   *   �� .+�56   .   ��  �� Orientation$ 
Horizontal=�69   .+�57   2   �� $��Titlu:��68   $
��Bold"�6I   �� 58   2   $��Center=�6<   $��16(�5:   ,   $��Calibri)�5;   ,   $��Italic$�5<   ,   ���#5E3B76��59   ,   �� *	Key.Title+5=   ,   5>   /   �� 5@   .   $ 
Horizontal=�69   .+�5A   2   �� $��Autor:��68   $
��Bold"�6I   �� 5B   2   $��Center=�6<   $��14(�5D   -   $��Calibri)�5E   -   ���#7D3C98��5C   -   �� *
Key.Author+5F   -   5G   /   �� 5I   .   $ 
Horizontal=�69   .+�5J   2   �� $��Stare:��68   $
��Bold"�6I   �� 5K   2   $��Center=�6<   $��Calibri)�5L   -   $��14(�5M   -   ���#7D3C98��5O   ,   �� *Value.Stare+ �� UpdateSourceTrigger$ PropertyChanged=�$ TwoWay=�5P   /   �� 5Q   .   $ 
Horizontal=�69   .+�5R   2   �� $��Data împrumut:��68   $
��Bold"�5S   (   �� 5T   2   $��Center=�6<   $��Calibri)�5U   ,   $��14(�5V   ,   ���#7D3C98��5X   ,   �� *Value.DataImprumut+	 �� StringFormat$	 {0:dd.MM.yyyy}��$ PropertyChanged=�$ TwoWay=�5Y   /   �� 5[   .   $ 
Horizontal=�69   .+�5\   2   �� $��Termen limită:��68   $
��Bold"�5]   (   �� 5^   2   $��Center=�6<   $��Calibri)�5_   ,   $��14(�5`   ,   ���#7D3C98��5b   ,   �� *Value.DataLimita+$	 {0:dd.MM.yyyy}��$ PropertyChanged=�$ TwoWay=�5c   /   �� 5e   .   $ 
Horizontal=�69   .+�5f   2   �� $��Data returnare:��68   $
��Bold"�5g   (   �� 5h   2   $��Center=�6<   $��Calibri)�5i   ,   $��14(�5j   ,   ���#7D3C98��5l   ,   �� *Value.DataReturnareAfisata+$ PropertyChanged=�$ TwoWay=�5m   /   5n   +   5o   '   �� 5p   &   $��2��61   $��2��6A   .+�5q   *   �� $��Returnează!��61   
������ ���#42adf5
����ح�$��5,150,10,10q�5x   -   $	��120��5y   -   $��30��5z   -   ��5r   -   �� *$"DataContext.ReturneazaCarteCommand+
 �� RelativeSource
 ��  �� AncestorType$ UserControlL���5s   -   �� y�5t   -   �� *Value.IsImprumutActiv+# [ $ PropertyChanged=�$ TwoWay=�5z   -   �� 5|   *   $ ��Prelungește termenul aici��61   
������ ���#ad4ef5���#d8bbfc$��0,0,0,0q�5�   .   $	��200��5�   .   $��30��5�   .   ��5}   .   �� *&$DataContext.PrelungesteTermenCommand+
 �� $ UserControlL���5~   .   �� y�5   .   �� *Value.IsImprumutActiv+# [ $ PropertyChanged=�$ TwoWay=�5�   .   � 5�   *   $��PrelungirePopup��60   $	��250��5�   ,   $��Center=�5�   ,   ��5�   ,   �� *Value.IsPopupOpen+$ TwoWay=�.��5�   .   �� 
����������#d8bbfc$��1q�5�   1   $ 20q�5�   1   ._�5�   2   �� .+�5�   6   �� $��Introduceți noua dată:��6@   $
��Bold"�5�   <   $��0,0,0,10q�5�   <   (  "System.Windows.Controls.DatePicker  5�   6      SelectedDate 6A   �� *DataContext.NouaData+
 �� $ UserControlL�$ TwoWay=��� 5�   6   $ 
Horizontal=�6A   $��Right=�6Z   $��0,10,0,0q�6v   .+�5�   :   �� $��	Confirmă��6A   $��0,0,10,0q�5�   =   $	��100��5�   =   ���#ad4ef5
�������$
��Bold"�5�   =   ��5�   >   �� ��5�   =   �� *'%DataContext.ConfirmaPrelungireCommand+
 �� $ UserControlL�5�   =   �� 5�   :   $��	Anulează��6A   $	��100��5�   =   
�������
���������5�   >   �� ��5�   =   �� *'%DataContext.AnuleazaPrelungireCommand+
 �� $ UserControlL�5�   =   5�   7   5�   3   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      