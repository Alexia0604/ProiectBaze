   M S B A M L   `   `   `  ����P  LBibliotecaElectronica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:BibliotecaElectronica.ViewBibliotecaElectronica.View  5      a5clr-namespace:BibliotecaElectronica.View.UserControls'BibliotecaElectronica.View.UserControls  5      Q-clr-namespace:BibliotecaElectronica.ViewModelBibliotecaElectronica.ViewModel  5	      2    ,BibliotecaElectronica.View.CreateAccountView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:BibliotecaElectronica.View     5      >view-clr-namespace BibliotecaElectronica.ViewModel     5      MuserControl5clr-namespace:BibliotecaElectronica.View.UserControls     5      C	viewmodel-clr-namespace:BibliotecaElectronica.ViewModel     5	        � 	Resources  5         UnderlineButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType��%�   &	        �� 5   
   " ��6-   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6$   #��z��5      #��z��5      #��z��5      $��	Underline{�5      $��Center=�5      5      5      5      5      .��5      � .+�5   
   �� .+�5      A� $	��220��6   $	��220��6"   
���2͚� J� Opacity$	 0.3Q�6B    �� Left$ 30��6P   
 �� Top$ 10��6a   A� 5      $	��160��6   $	��160��6"   
�������$	 0.3Q�6;   $	 450��6I   $ 60��6[   A� 5       $	��270��6   $	��270��6"   
����  �$	 0.3Q�6A   $	 150��6O   $	 400��6a   A� 5!      $	��120��6   $	��120��6"   
������$	 0.3Q�6D   $	 470��6R   $	 350��6d   A� 5"      $	��200��6   $	��200��6"   
�������$	 0.3Q�6A   $ 0��6O   $	 350��6_   5#      �� 5&   
   $��Center=�6    �� CornerRadius$ 15��6.   
����������#cccccc$��1q�6i   	 �� Padding$	 30q�6}   $��Center=�5'   
   $	��400��6%   ._�5(      �� .+�5)      �� $��	logo2.png��6   $	��300��6+   $	��150��67   $��Center=�6D   $��0,0,0,30q�6a   � 5*      .+�5+      �� -   5        
 ��Name$
 txtLastName��5+      $��5q�63   $	��330��6?   $��40��6K   $��Center=�6�   $��Center=�6�   $��16(�5,      $��Light"�6#   
�������
������ ��5+   W   �� *
LastName+ �� UpdateSourceTrigger$ PropertyChanged=�5,   �   �� 5.      -   5         ��Name$ 	btnClear1��5.      $��LastName��6Y   $��40��6u   $��X��6�   $��10q�6�   $��30��6�   $��Right=�6�   
�������
������ $��0q�5/   G   $��16(�6[   ��5.   1   �� *ClearTextBoxCommand+��5/   i   Z� 50      � 52      .+�53      �� -   5        $
 txtFirstName��53      $	��330��6s   $��40��6   $��Center=�6�   $��Center=�6�   $��16(�54      
�������$��5q�66   $��Light"�6B   
������ ��53   4   �� *	FirstName+$ PropertyChanged=�54   �   �� 56      -   5        $ 	btnClear2��56      $��	FirstName��6Y   $��40��6v   $��X��6�   $��10q�6�   $��30��6�   $��Right=�6�   
�������
������ $��0q�57   G   $��16(�6[   ��56   1   �� *ClearTextBoxCommand+��57   i   Z� 58      � 59      .+�5:      �� -   5        $
 txtEmail��5:      
�������$	��330��6~   $��40��6�   $��Center=�6�   $��Center=�6�   $��16(�5;      $��Light"�6$   
������ $��5q�6P   ��5:   0   �� *Email+$ PropertyChanged=�5;   y   �� 5=      -   5        $ 	btnClear3��5=      $��Email��6Y   $��40��6r   $��X��6~   $��10q�6�   $��30��6�   $��Right=�6�   
�������
������ $��0q�5>   J   $��16(�6^   ��5=   1   �� *ClearTextBoxCommand+��5>   l   Z� 5?      � 5@      .+�5A      �� -   5        $
 
txtAddress��5A      $��5q�62   $	��330��6>   $��40��6J   $��Center=�6V   $��Center=�6�   $��16(�5B      
�������$��Light"�66   
������ ��5A   x   �� *	Address+$ PropertyChanged=�5B   �   �� 5D      -   5        $ 	btnClear4��5D      $��Address��6Y   $��40��6t   $��X��6�   $��10q�6�   $��30��6�   $��Right=�6�   
�������
������ $��0q�5E   F   $��16(�6Z   ��5D   1   �� *ClearTextBoxCommand+��5E   h   Z� 5F      � 5G      .+�5H      �� -	   5        $
 txtPhone��5H      $��5q�60   $	��330��6x   $��40��6�   $��Center=�6�   $��Center=�6�   $��16(�5I      
�������$��Light"�65   
������ ��5H   <   �� *Phone+$ PropertyChanged=�5I   ~   �� 5K      -
   5        $ 	btnClear5��5K      $��Phone��6Y   $��40��6r   $��X��6~   $��10q�6�   $��30��6�   $��Right=�6�   
�������
������ $��0q�5L   F   $��16(�6Z   ��5K   1   �� *ClearTextBoxCommand+��5L   h   Z� 5M      ]� 5O      .+�5P      �� -   5        $ btnBack��5P      $
��Left=�6.   $	��140��6D   $��Înapoi��6P   
����·����	#FFF8F1F1$��0q�6�   $��20(�6�   $
��Bold"�5Q      $��
15,10,0,10q�6'    � Cursor$
 Hand��6;   #��[  6I   $��Calibri Light)�6�   ��6w   �� *BackToLoginCommand+6�   �� 5R      -   5        $ btnNext��5R      $��Right=�6.   $	��100��6E   $��Mai departe��6Q   
����·�
������ $��0q�6�   $��20(�6�   $
��Bold"�5S      $��0,10,0,0q�6(   $
 Hand��6:   #��[  6H   $��Calibri Light)�6�   ��6w   �� * ContinueCreatingAccountCommand+6�   5T      5U      5V      5W      5X      