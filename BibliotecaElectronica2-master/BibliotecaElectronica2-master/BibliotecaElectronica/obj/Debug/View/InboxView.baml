   M S B A M L   `   `   `  ����P  LBibliotecaElectronica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:BibliotecaElectronica.ViewBibliotecaElectronica.View  5      Q-clr-namespace:BibliotecaElectronica.ViewModelBibliotecaElectronica.ViewModel  5      Q-clr-namespace:BibliotecaElectronica.UtilitiesBibliotecaElectronica.Utilities  5      *    $BibliotecaElectronica.View.InboxView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:BibliotecaElectronica.View     5      =vms-clr-namespace:BibliotecaElectronica.ViewModel     5      C	utilities-clr-namespace:BibliotecaElectronica.Utilities     5      $	��600��5   3      
Page_Style#��[  5        � 	Resources  5         BooleanToVisibilityConverter@   :BibliotecaElectronica.Utilities.CountToVisibilityConverter  CountToVisibilityConverter��%:   &	       &	      �� 5   
   6'     5   
   6/   5      .��5      ��  �� Padding$ 0q�6   
������  �� CornerRadius$ 8��62   ���#E0E0E0$��0q�6Y   ._�5   
   � .+�5      �� $��Nu există mesaje!��6   $��20(�5   	   $
��Bold"�5   	   
�������$��Italic$�5   	   $��Center=�5   	   $��Center=�5   	   y�5   	   �� *Notificari.Count+ �� 	Converter# [ �� 5      $
��Auto=�6   .��5      �� .+�5       �� $��Nu exista notificari!��6   $��Center=�5"       $��Center=�6=   
�������$��16(�5#   2   $��10q�6@   y�5!       �� *
Notificari+# [  �� FallbackValue$ 	Collapsed��5#   @   �� 5$      $��0q�6=   ��6   �� *
Notificari+ �� SelectedItem 5%      �� *NotificareSelectata+ �� Mode$ TwoWay=���5&      �� 5'      .R�5(      �� $��5q�6%   $	��590��60   $ 10q�6<   
�������$ 5��6\   ���#efdaf7$��1q�6�   ._�5)   "   � $��0,0,0,0q�6'   .+�5*   &   �� $��10q�61   .+�5+   &   �� $
��Bold"�6G   
���   ���60   �� *Mesaj+6Y   �� 5,   &   
�������$��12(�6h   ��60   �� *DataTrimitereAfisata+6h   �� 5-   *   $��12(�6|   ��64   �� *Stare+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���5.   .   �� 5/   2    �� 
TargetType" ��68   .�50   6   �� 	 �� Property	 � ��
 �� Value

 �  ��6S    �� Triggers 51   6   �� 52   :    �� Binding 6F   �� *Stare+ �� Value	 Citit6`   .a�53   >   �� 	 � ��

 � � �6[   54   ;   56   3   58   +   59   '   � 5:   "   $��PopupDetaliiNotificare��6(   $	��500��5;   )   $��Center=�5=   )   ��5<   )   �� *IsPopupOpen+$ TwoWay=�.��5>   *   �� 
�������$ 20q�6D   ���#efdaf7$��1q�6h   ._�5?   .   �� .+�5@   2   �� $��Detalii mesaj��6<   $
��Bold"�6Q   ���#8428e0$��16(�6x   $��0,0,0,10q�6�   �� 5A   2   $��14(�6S   
���   �$
��Wrap=�6t   $��0,0,0,10q�6�   ��6<   �� *Mesaj+6�   �� 5B   2   $��Închide��69   $	��100��6K   
����������#5b0aab$��Right=�6   ��6�   �� *DataContext.ClosePopupCommand+ �� RelativeSource ��  �� AncestorType$ UserControlL�5C   /   5D   +   5E   '   5F   #   5G      5H      5K      5L      5M      5N      5O      5P      