   M S B A M L   `   `   `  ����P  LBibliotecaElectronica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:BibliotecaElectronicaBibliotecaElectronica  5   	   Q-clr-namespace:BibliotecaElectronica.ViewModelBibliotecaElectronica.ViewModel  5   	   a5clr-namespace:BibliotecaElectronica.View.UserControls'BibliotecaElectronica.View.UserControls  5   	   3    -BibliotecaElectronica.View.CreateAccountView2   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:BibliotecaElectronica     5   	   C	viewmodel-clr-namespace:BibliotecaElectronica.ViewModel     5   	   MuserControl5clr-namespace:BibliotecaElectronica.View.UserControls     5   	   $	��650��5
   
   $	��600��6     � 	Resources  5         UnderlineButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType��%�   &	        �� 5   
   " ��6-   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6$   #��z��5   	   #��z��5   	   #��z��5   	   $��	Underline{�5   	   $��Center=�5   	   5      5      5      5      .��5      � .+�5   
   �� .+�5      A� $	��220��6   $	��220��6"   
���2͚� J� Opacity$	 0.3Q�6B    �� Left$ 30��6P   
 �� Top$ 10��6a   A� 5      $	��160��6   $	��160��6"   
�������$	 0.3Q�6;   $	 450��6I   $ 60��6[   A� 5       $	��270��6   $	��270��6"   
����  �$	 0.3Q�6A   $	 150��6O   $	 400��6a   A� 5!      $	��120��6   $	��120��6"   
������$	 0.3Q�6D   $	 470��6R   $	 350��6d   A� 5"      $	��200��6   $	��200��6"   
�������$	 0.3Q�6A   $ 0��6O   $	 350��6_   5#      �� 5&   
    �� CornerRadius$ 15��6   
����������#cccccc$��1q�6L   	 �� Padding$	 30q�6`   $��Center=�5'      $��Center=�6)   $	��420��6F   ._�5(      �� .+�5)      �� $��	logo2.png��6   $	��300��6+   $	��150��67   $��Center=�6D   $��0,0,0,30q�6a   � 5*      .+�5+      �� -   5        
 ��Name$
 txtUsername��5+      $	��330��63   $��40��6?   $��Center=�6K   $��Center=�6m   $��16(�5,      $��5q�6#   
�������$��Light"�6B   
������ ��6n   �� *	Username2+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5.      -   5         ��Name$ 	btnClear1��5.      $��40��61   $��X��6=   $��10q�6I   $��30��6U   $��Right=�6`   
�������
������ $��0q�5/   G   $��16(�6[    � Cursor$ Arrow��6z   $��Username��6�   ��6i   Z� ��6�   �� *ClearTextBoxCommand+6�   50      � 53       � ColumnDefinitions 54      �� 55      $	��55* �6+   �� 56      $
��124* �6+   .+�58      �� -   5        $
 txtPassword��58      $	��330��63   $��40��6?   $��Center=�6�   $��Center=�6�   
�������$��16(�59   )   $��5q�68   $��Light"�6D   
������ $��2��6�   $��	14,0,14,0q�6�   ��58   L   �� *	Password2+$ PropertyChanged=�59   �   �� 5;      -   5        $ 	btnClear2��5;      $��40��61   $��X��6=   $��208,10,0,10q�6I   $��30��6^   $
��Left=�6i   
�������
������ $��0q�5<   G   $��16(�6[   $ Arrow��6z   $��Password��6�   $��1��6�   ��6i   Z� ��6�   �� *ClearTextBoxCommand+6�   5=      � 5@       5A      �� 5B      $	��55* �6+   �� 5C      $
��124* �6+   .+�5E      �� -   5        $
 txtPassword2��5E      $	��330��64   $��40��6@   $��Center=�6�   $��Center=�6�   
�������$��16(�5F   0   $��5q�6?   $��Light"�6K   
������ $��2��6�   $��	14,0,14,0q�6�   ��5E   M   �� *	Password3+$ PropertyChanged=�5F   �   �� 5H      -   5        $ 	btnClear3��5H      $��40��61   $��X��6=   $��208,10,0,10q�6I   $��30��6^   $
��Left=�6i   
�������
������ $��0q�5I   N   $��16(�6b   $ Arrow��6�   $��Password��6�   $��1��6�   ��6p   Z� ��6�   �� *ClearTextBoxCommand+6�   5J      ]� 5K      .+�5L      �� -   5        $ btnBack��5L      $
��Left=�6.   $	��140��6D   $��Înapoi��6P   
����·�
������ $��0q�6�   $��20(�6�   $
��Bold"�5M      $��
15,10,0,10q�6$   $
 Hand��68   #��[  6F   $��Calibri Light)�6�   ��6t   �� *BackToCreateAccountCommand+6�   �� 5N      -   5        $ btnRegister��5N      $��Right=�62   $	��125��6I   $��Înregistrează-te��6U   
����·�
������ $��0q�6�   $��20(�6�   $
��Bold"�5O      $��0,10,0,0q�6#   $
 Hand��65   #��[  6C   $��Calibri Light)�6�   ��6r   �� *RegisterCommand+6�   5P      5R      5S      5T      5U      