   M S B A M L   `   `   `  ����P  LBibliotecaElectronica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:BibliotecaElectronica.ViewBibliotecaElectronica.View  5      Q-clr-namespace:BibliotecaElectronica.ViewModelBibliotecaElectronica.ViewModel  5      +    %BibliotecaElectronica.View.OrdersView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:BibliotecaElectronica.View     5      =vms-clr-namespace:BibliotecaElectronica.ViewModel     5      $	��600��5
   3      
Page_Style#��[  5        � 	Resources  5         BooleanToVisibilityConverter��%   &	       �� 5   
   6'   5      .��5      ��  �� Padding$ 0q�6   
������  �� CornerRadius$ 8��62   ���#E0E0E0$��0q�6Y   ._�5   
   �� $
��Auto=�6   .��5      �� $��0q�6?   ��6   �� *CartiImprumutate+ �� SelectedItem 5      �� *SelectedItem+ �� Mode$ TwoWay=���5      �� 5      .R�5      �� $��5q�6!   $	��590��6,   $ 10q�68   
�������$ 5��6X   ���#efdaf7$��1q�6   ._�5      � $��0,0,0,0q�6#    � ColumnDefinitions 5   "   �� 5   &   $	��200 �67   �� 5   &   $��* �67   �� 5   &   $	��200 �67   .+�5!   "   �� $��0��6(   $��0,0,10,0q�6[   $	��150��6m   $	��200��6y   $
��Left=�6�   ��68   �� *Key.BitmapImage+6�   �� 5#   "   $��1��6-   $��2��6=   $��Center=�6Q   .+�5$   &   �� .+�5%   *   ��  �� Orientation$ 
Horizontal=�65   .+�5&   .   �� $��Titlu:��64   $
��Bold"�6E   �� 5'   .   $��Center=�68   $��16(�5)   ,   $��Calibri)�5*   ,   $��Italic$�5+   ,   ���#5E3B76��5(   ,   �� *	Key.Title+5,   ,   5-   +   �� 5/   *   $ 
Horizontal=�65   .+�50   .   �� $��Autor:��64   $
��Bold"�6E   �� 51   .   $��Center=�68   $��14(�53   -   $��Calibri)�54   -   ���#7D3C98��52   -   �� *
Key.Author+55   -   56   +   �� 58   *   $ 
Horizontal=�65   .+�59   .   �� $��Stare:��64   $
��Bold"�6E   �� 5:   .   $��Center=�68   $��Calibri)�5;   -   $��14(�5<   -   ���#7D3C98��5>   ,   �� *Value.Stare+ �� UpdateSourceTrigger$ PropertyChanged=�$ TwoWay=�5?   +   �� 5@   *   $ 
Horizontal=�65   .+�5A   .   �� $��Data împrumut:��64   $
��Bold"�5B   (   �� 5C   .   $��Center=�68   $��Calibri)�5D   ,   $��14(�5E   ,   ���#7D3C98��5G   ,   �� *Value.DataImprumut+ �� StringFormat$ {0:dd.MM.yyyy}��$ PropertyChanged=�$ TwoWay=�5H   +   �� 5J   *   $ 
Horizontal=�65   .+�5K   .   �� $��Termen limită:��64   $
��Bold"�5L   (   �� 5M   .   $��Center=�68   $��Calibri)�5N   ,   $��14(�5O   ,   ���#7D3C98��5Q   ,   �� *Value.DataLimita+$ {0:dd.MM.yyyy}��$ PropertyChanged=�$ TwoWay=�5R   +   �� 5T   *   $ 
Horizontal=�65   .+�5U   .   �� $��Data returnare:��64   $
��Bold"�5V   (   �� 5W   .   $��Center=�68   $��Calibri)�5X   ,   $��14(�5Y   ,   ���#7D3C98��5[   ,   �� *Value.DataReturnareAfisata+$ PropertyChanged=�$ TwoWay=�5\   +   5]   '   5^   #   �� 5_   "   $��2��6-   $��2��6=   .+�5`   &   �� $��Returnează!��6-   
������ ���#42adf5
����ح�$��5,150,10,10q�5g   -   $	��120��5h   -   $��30��5i   -   ��5a   -   �� *$"DataContext.ReturneazaCarteCommand+	 �� RelativeSource	 �� 
 �� AncestorType$
 UserControlL���5b   -   �� y�5c   -   �� *Value.IsImprumutActiv+ �� 	Converter# [ $ PropertyChanged=�$ TwoWay=�5i   -   �� 5k   &   $ ��Prelungește termenul aici��6-   
������ ���#ad4ef5���#d8bbfc$��0,0,0,0q�5r   .   $	��200��5s   .   $��30��5t   .   ��5l   .   �� *&$DataContext.PrelungesteTermenCommand+	 �� $
 UserControlL���5m   .   �� y�5n   .   �� *Value.IsImprumutActiv+# [ $ PropertyChanged=�$ TwoWay=�5t   .   � 5v   &   $��PrelungirePopup��6,   $	��250��5w   ,   $��Center=�5y   ,   ��5x   ,   �� *Value.IsPopupOpen+$ TwoWay=�.��5z   *   �� 
����������#d8bbfc$��1q�5|   1   $ 20q�5}   1   ._�5~   .   �� .+�5   2   �� $��Introduceți noua dată:��6<   $
��Bold"�5�   <   $��0,0,0,10q�5�   <   (  "System.Windows.Controls.DatePicker  5�   2      SelectedDate 6=   �� *DataContext.NouaData+	 �� $
 UserControlL�$ TwoWay=��� 5�   2   $ 
Horizontal=�6=   $��Right=�6V   $��0,10,0,0q�6r   .+�5�   6   �� $��	Confirmă��6=   $��0,0,10,0q�5�   =   $	��100��5�   =   ���#ad4ef5
�������$
��Bold"�5�   =   ��5�   >   �� ��5�   =   �� *'%DataContext.ConfirmaPrelungireCommand+	 �� $
 UserControlL�5�   =   �� 5�   6   $��	Anulează��6=   $	��100��5�   =   
�������
���������5�   >   �� ��5�   =   �� *'%DataContext.AnuleazaPrelungireCommand+	 �� $
 UserControlL�5�   =   5�   3   5�   /   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      