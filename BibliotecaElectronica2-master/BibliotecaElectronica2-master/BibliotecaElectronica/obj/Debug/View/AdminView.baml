   M S B A M L   `   `   `  ����P  LBibliotecaElectronica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:BibliotecaElectronica.ViewModelBibliotecaElectronica.ViewModel  5      G(clr-namespace:BibliotecaElectronica.ViewBibliotecaElectronica.View  5      Q-clr-namespace:BibliotecaElectronica.ViewModelBibliotecaElectronica.ViewModel  5      Q-clr-namespace:BibliotecaElectronica.UtilitiesBibliotecaElectronica.Utilities  5	      *    $BibliotecaElectronica.View.AdminView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?local-clr-namespace:BibliotecaElectronica.ViewModel     5      :views(clr-namespace:BibliotecaElectronica.View     5      =vms-clr-namespace:BibliotecaElectronica.ViewModel     5      >Menu-clr-namespace:BibliotecaElectronica.Utilities     5	      X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5
      .��5      �   � RowDefinitions  5   
   �� 5      $��30 �6   5      �� 5      $��* �6   5      .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $	��188 �6$   �� 5      .+�5      �� $��0��6   ��5       �� 5!       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 0,1&�6;   .��5"      �  � Color$ #efdaf7��6'    � Offset$ 0Q�67   � 5#      $ #efdaf7��6'   $ 1Q�67   5$      5&      5'      � 5*   
   $��1��6    5+      �� 5-      $	��188 �6$   �� 5.      .+�51      �� $��0��6   ��52      �� 53      $	 0,0&�6*   $	 0,1&�6;   .��54      � $ #efdaf7��6'   $ 0Q�67   � 55      $ #efdaf7��6'   $ 1Q�67   56      58      �� 5:      $��1��6   ��5;      �� 5<      $	 0,0&�6*   $	 0,1&�6;   .��5=      � $ white��6'   $ 0Q�65   � 5>      $ white��6'   $ 1Q�65   5?      5A      � 5C      $��0��6   .+�5D      ��  �� Orientation$ Vertical=�6   .+�5F      	� $��0,200,0,-20q�6"      BtnStyle#��[  67   $��Center=�6Y   
 � Tag$ #8228a6��5H      ��5G      �� *HomeClickButtonCommand+.��5J      �� $ 
Horizontal=�6%   .+�5K      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Home=�6+     menuButtonIcon#��[ 67   �� 5L      $��Acasă��6(     menuButtonText#��[ 65   5M      5N      	� 5R      $��
0,20,0,-20q�6"   #��[  66   $��Center=�6X   $ #8228a6��5T      ��5S      �� *CustomerClickButtonCommand+.��5U      �� $ 
Horizontal=�6%   .+�5V        $
 User=�6+   #��[ 67   �� 5W      $��
Contul meu��6(   #��[ 6:   5X      5Y      	� 5\      $��
0,20,0,-20q�6"   #��[  66   $��Center=�6X   $ #8228a6��5^      ��5]      �� *ProductsClickButtonCommand+.��5_      �� $ 
Horizontal=�6%   .+�5`        $
 Book=�6+   #��[ 67   �� 5a      $��Cărți��6(   #��[ 65   5b      5c      	� 5e      $��
0,20,0,-20q�6"   #��[  66   $��Center=�6X   $ #8228a6��5g      ��5f      �� *ListReadersClickButtonCommand+.��5h      �� $ 
Horizontal=�6%   .+�5i        $ 
BookReader=�6+   #��[ 6=   �� 5j      $��Cititori��6(   #��[ 68   5k      5l      	� 5n      $��
0,20,0,-20q�6"   #��[  66   $��Center=�6X   $ #8228a6��5p      ��5o      �� *" ListLibrariansClickButtonCommand+.��5q      �� $ 
Horizontal=�6%   .+�5r        $ UserTie=�6+   #��[ 6:   �� 5s      $��Bibliotecari��6(   #��[ 6<   5t      5u      5w      5x      � 5z      $��1��6   	 � 	Resources	 5{      
 �� DataType3   -BibliotecaElectronica.ViewModel.HomeViewModel)   #BibliotecaElectronica.View.HomeView7   1BibliotecaElectronica.ViewModel.CustomerViewModel-   'BibliotecaElectronica.View.CustomerView4   .BibliotecaElectronica.ViewModel.CartiViewModel*   $BibliotecaElectronica.View.CartiView;	   5BibliotecaElectronica.ViewModel.DetaliiCarteViewModel1
   +BibliotecaElectronica.View.DetaliiCarteView7   1BibliotecaElectronica.ViewModel.CititoriViewModel-   'BibliotecaElectronica.View.CititoriView;   5BibliotecaElectronica.ViewModel.BibliotecariViewModel1   +BibliotecaElectronica.View.BibliotecariView��%�  (��       5|   #   *, +)(�� 2     5   #   *, +)(�� d     5�   #   *, +)(�� �     5�   #   *,	 +)(�� �     5�   #   *, +)(�� �     5�   #   *, +)�� 5|      "
  6#   .R�5}        5~      �� 5      "
  6#   .R�5�        5�      �� 5�      "
  6#   .R�5�        5�      �� 5�      "
 	 6#   .R�5�      
  5�      �� 5�      "
  6#   .R�5�        5�      �� 5�      "
  6#   .R�5�        5�      5�      .+�5�      �� $��10q�6!   ��6-   �� *CurrentRightViewModel+5�      5�      5�      5�      