   M S B A M L   `   `   `  ����P  LBibliotecaElectronica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:BibliotecaElectronica.ViewBibliotecaElectronica.View  5   	   S.clr-namespace:BibliotecaElectronica.Components BibliotecaElectronica.Components  5   	   *    $BibliotecaElectronica.View.LoginView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:BibliotecaElectronica.View     5   	   >view-clr-namespace BibliotecaElectronica.ViewModel     5   	   E
components.clr-namespace:BibliotecaElectronica.Components     5   	   $	��650��5
   	   $	��600��6     � 	Resources  5         UnderlineButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType��%�   &	        �� 5   
   " ��6-   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6$   #��z��5      #��z��5      #��z��5      $��	Underline{�5      $��Center=�5      5      5      5      5      .��5      � .+�5   
   �� .+�5       A� $	��220��6   $	��220��6"   
���2͚� J� Opacity$	 0.3Q�6B    �� Left$ 30��6P   
 �� Top$ 10��6a   A� 5!      $	��160��6   $	��160��6"   
�������$	 0.3Q�6;   $	 450��6I   $ 60��6[   A� 5"      $	��270��6   $	��270��6"   
����  �$	 0.3Q�6A   $	 150��6O   $	 400��6a   A� 5#      $	��120��6   $	��120��6"   
������$	 0.3Q�6D   $	 470��6R   $	 350��6d   A� 5$      $	��200��6   $	��200��6"   
�������$	 0.3Q�6A   $ 0��6O   $	 350��6_   5%      �� 5(   
    �� CornerRadius$ 15��6   
����������#cccccc$��1q�6L   	 �� Padding$	 30q�6`   $��Center=�5)      $��Center=�6(   $	��420��6E   ._�5*      �� .+�5,      �� $��	logo2.png��6   $	��300��6+   $	��150��67   $��Center=�6D   $��0,0,0,30q�6a   �� 5/      
 �� Orientation$
 
Horizontal=�6   $��Center=�66   $��0,0,0,15q�6S   .+�50      �� $��account1.png��6   $��50��62   $��50��6=   $��Center=�6I   $��5q�6d   �� 51      -   5         ��Name$ txtUsername��51      $	��280��63   $��35��6?   $��5q�6K   
����������#cccccc
 � Tag$ Username��52   0   
�������$��5q�6S   $��Calibri Light)�6_   $��18(�6z   ��51   V   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�52   �   53      �� 56      $
 
Horizontal=�6   $��Center=�66   $��0,0,0,15q�6S   .+�57      �� $��password1.png��6   $��50��63   $��50��6>   $��Center=�6J   $��5q�6e   :   4BibliotecaElectronica.Components.BindablePasswordBox  59      -   5          Name$ txtPassword��59   R   $��Center=�65   $	��290��6g   $��45��6s   ���#cccccc
�������$��5q�5:   �   $��Calibri Light)�6�   $��16(�6�      Password 6   �� *
Password+$ PropertyChanged=� �� Mode$ TwoWay=�6�   5;      �� 5>      $
 
Horizontal=�6   $��Center=�66   $��0,0,0,20q�6S   .+�5?      �� $��user.png��6   $��50��6.   $��50��69   $��Center=�6E   $��5q�6`   �� 5@      -   5         ��Name$ cmbRole��5@      $	��280��60   $��35��6<   $��5q�6H   
����������#cccccc �� SelectedIndex$ 0��5A   1   $��Calibri Light)�6C   $��18(�6^   ��6l   �� *Roles+$ PropertyChanged=� �� SelectedItem 5B      �� *SelectedRole+$ TwoWay=���6N   Z� 5C      5D      �� 5G      -   5         ��Name$ btnLogin��5G      $��Conectează-te!��6M   
����·�
�������$��20(�6�   $
��Bold"�6�   $��40��5H      $	��152��6!   $��Center=�6-   $��0,0,0,10q�6J    J� RenderTransformOrigin$	 0,0&�6\   $��Calibri Light)�6x   ��5G   +   �� *SignInCommand+5H   x   �� 5L      $%��Nu ai cont? Înregistrează-te!��6   
����·�
������ $��0q�6�   $��20(�6�   $
��Bold"�5M      $��0,10,0,0q�6'    � Cursor$
 Hand��69   #��[  6G   $��Calibri Light)�6u   ��5L   A   �� *CreateAccountCommand+5M   u   5N      5O      5P      5Q      