   M S B A M L   `   `   `  ����P  LBibliotecaElectronica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:BibliotecaElectronica.ViewBibliotecaElectronica.View  5      a5clr-namespace:BibliotecaElectronica.View.UserControls'BibliotecaElectronica.View.UserControls  5      Q-clr-namespace:BibliotecaElectronica.ViewModelBibliotecaElectronica.ViewModel  5	      2    ,BibliotecaElectronica.View.CreateAccountView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:BibliotecaElectronica.View     5      >view-clr-namespace BibliotecaElectronica.ViewModel     5      MuserControl5clr-namespace:BibliotecaElectronica.View.UserControls     5      C	viewmodel-clr-namespace:BibliotecaElectronica.ViewModel     5	        � 	Resources  5         UnderlineButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType��%�   &	        �� 5   
   " ��6-   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6$   #��z��5      #��z��5      #��z��5      $��	Underline{�5      $��Center=�5      5      5      5      5      .��5      � .+�5!      �� $	��600��6   $	��700��6!   .+�5"      A� $	��220��6   $	��220��6&   
���2͚� J� Opacity$	 0.3Q�6F    �� Left$ 30��6T   
 �� Top$ 10��6e   A� 5#      $	��160��6   $	��160��6&   
�������$	 0.3Q�6?   $	 450��6M   $ 60��6_   A� 5$      $	��270��6   $	��270��6&   
����  �$	 0.3Q�6E   $	 150��6S   $	 400��6e   A� 5%      $	��120��6   $	��120��6&   
������$	 0.3Q�6H   $	 470��6V   $	 350��6h   A� 5&      $	��200��6   $	��200��6&   
�������$	 0.3Q�6E   $ 0��6S   $	 350��6c   5'      �� 5)   
   $��Center=�6    �� CornerRadius$ 15��6.   
����������#cccccc$��1q�6i   	 �� Padding$	 30q�6}   $��Center=�5*   
   $	��400��6%   ._�5+      �� .+�5,      �� $��	logo2.png��6   $	��300��6+   $	��150��67   $��Center=�6D   $��0,0,0,30q�6a   � 5-      .+�5.      �� -   5        
 ��Name$
 txtLastName��5.      $��5q�63   $	��330��6?   $��40��6K   $��Center=�6�   $��Center=�6�   $��16(�5/      $��Light"�6#   
�������
������ ��5.   W   �� *
LastName+ �� UpdateSourceTrigger$ PropertyChanged=�5/   �   �� 51      -   5         ��Name$ 	btnClear1��51      $��LastName��6Y   $��40��6u   $��X��6�   $��10q�6�   $��30��6�   $��Right=�6�   
�������
������ $��0q�52   G   $��16(�6[   ��51   1   �� *ClearTextBoxCommand+��52   i   Z� 53      � 55      .+�56      �� -   5        $
 txtFirstName��56      $	��330��6s   $��40��6   $��Center=�6�   $��Center=�6�   $��16(�57      
�������$��5q�66   $��Light"�6B   
������ ��56   4   �� *	FirstName+$ PropertyChanged=�57   �   �� 59      -   5        $ 	btnClear2��59      $��	FirstName��6Y   $��40��6v   $��X��6�   $��10q�6�   $��30��6�   $��Right=�6�   
�������
������ $��0q�5:   G   $��16(�6[   ��59   1   �� *ClearTextBoxCommand+��5:   i   Z� 5;      � 5=      .+�5>      �� -   5        $
 txtEmail��5>      
�������$	��330��6~   $��40��6�   $��Center=�6�   $��Center=�6�   $��16(�5?      $��Light"�6$   
������ $��5q�6P   ��5>   0   �� *Email+$ PropertyChanged=�5?   y   �� 5A      -   5        $ 	btnClear3��5A      $��Email��6Y   $��40��6r   $��X��6~   $��10q�6�   $��30��6�   $��Right=�6�   
�������
������ $��0q�5B   J   $��16(�6^   ��5A   1   �� *ClearTextBoxCommand+��5B   l   Z� 5C      � 5D      .+�5E      �� -   5        $
 
txtAddress��5E      $��5q�62   $	��330��6>   $��40��6J   $��Center=�6V   $��Center=�6�   $��16(�5F      
�������$��Light"�66   
������ ��5E   x   �� *	Address+$ PropertyChanged=�5F   �   �� 5H      -   5        $ 	btnClear4��5H      $��Address��6Y   $��40��6t   $��X��6�   $��10q�6�   $��30��6�   $��Right=�6�   
�������
������ $��0q�5I   F   $��16(�6Z   ��5H   1   �� *ClearTextBoxCommand+��5I   h   Z� 5J      � 5K      .+�5L      �� -	   5        $
 txtPhone��5L      $��5q�60   $	��330��6x   $��40��6�   $��Center=�6�   $��Center=�6�   $��16(�5M      
�������$��Light"�65   
������ ��5L   <   �� *Phone+$ PropertyChanged=�5M   ~   �� 5O      -
   5        $ 	btnClear5��5O      $��Phone��6Y   $��40��6r   $��X��6~   $��10q�6�   $��30��6�   $��Right=�6�   
�������
������ $��0q�5P   F   $��16(�6Z   ��5O   1   �� *ClearTextBoxCommand+��5P   h   Z� 5Q      �� 5S       �� Orientation$ 
Horizontal=�6   $
��Left=�66   $��Center=�6Q   .+�5T      �� -   5         ��Name$ 
BirthLabel��5T      $	��110��62   $��Data nașterii:��6>   $��Center=�6W   $��Bottom=�6t   $��16(�6�   
�������6�   �� 5U      -   5         ��Name$ DayComboBox��5U      $��Light"�64   $��16(�6I   
������� �� SelectedIndex$ 0��6�   $��35��6�   $��5q�6�   ��6j   �� *Days+$ PropertyChanged=� �� SelectedItem 6�   �� *Day+ �� Mode$ TwoWay=�6�   �� 5V      -   5        $ MonthComboBox��5V      $��16(�66   $��Light"�6D   
�������$ 0��6�   $	��105��6�   $��5q�6�   ��6k   �� *Months+$ PropertyChanged=� 6�   �� *Month+$ TwoWay=�6�   �� 5W      -   5        $ YearComboBox��5W      $��16(�65   $��Light"�6C   
�������$ 0��6�   $��60��6�   $��5q�6�   ��6i   �� *Years+$ PropertyChanged=� 6�   �� *Year+$ TwoWay=�6�   5X      ]� 5Z      .+�5[      �� -   5        $ btnBack��5[      $
��Left=�6.   $	��140��6D   $��Înapoi��6P   
����·����	#FFF8F1F1$��0q�6�   $��20(�6�   $
��Bold"�5\      $��
15,10,0,10q�6'    � Cursor$
 Hand��6;   #��[  6I   $��Calibri Light)�6�   ��6w   �� *BackToLoginCommand+6�   �� 5]      -   5        $ btnNext��5]      $��Right=�6.   $	��100��6E   $��Mai departe��6Q   
����·�
������ $��0q�6�   $��20(�6�   $
��Bold"�5^      $��0,10,0,0q�6(   $
 Hand��6:   #��[  6H   $��Calibri Light)�6�   ��6w   �� * ContinueCreatingAccountCommand+6�   5_      5`      5a      5b      5c      