   M S B A M L   `   `   `  ����P  LBibliotecaElectronica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:BibliotecaElectronica.ViewBibliotecaElectronica.View  5      Q-clr-namespace:BibliotecaElectronica.ViewModelBibliotecaElectronica.ViewModel  5      Q-clr-namespace:BibliotecaElectronica.UtilitiesBibliotecaElectronica.Utilities  5      -    'BibliotecaElectronica.View.AddBooksView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:BibliotecaElectronica.View     5      =vms-clr-namespace:BibliotecaElectronica.ViewModel     5      C	utilities-clr-namespace:BibliotecaElectronica.Utilities     5        � 	Resources  5      ?   9BibliotecaElectronica.Utilities.ByteArrayToImageConverter   ByteArrayToImageConverter2   ,BibliotecaElectronica.Utilities.IntConverter  IntConverter��%:   &	        &	        5   
   6.     5   
   6!   5      .��5      � .+�5   
   �� $��0��6   $
��Auto=�6$   .��5      � $��20q�6   .+�5      ��  �� Padding$ 20q�6   
������� �� CornerRadius$ 10��69   ���#CCCC$��1q�6_   ._�5      �� .+�5      �� $��Titlu��6$   $��0,10,0,5q�61   $
��Bold"�6C   �� 5      $��0,0,0,10q�6^   $��5q�6p   $��14(�6|   ���#f9f7fc��6"   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $��Autor��6$   $��0,10,0,5q�61   $
��Bold"�6C   �� 5      $��0,0,0,10q�6_   $��5q�6q   $��14(�6}   ���#f9f7fc��6"   �� *Author+$ PropertyChanged=�6�   �� 5!      $��Anul Publicării��6$   $��0,10,0,5q�6;   $
��Bold"�6M   �� 5"      $��0,0,0,10q�6�   $��5q�6�   $��14(�6�   ���#f9f7fc��6"   �� *Year+ �� 	Converter# [ $ PropertyChanged=�6�   �� 5%      $
��ISBN��6$   $��0,10,0,5q�60   $
��Bold"�6B   �� 5&      $��0,0,0,10q�6]   $��5q�6o   $��14(�6{   ���#f9f7fc��6"   �� *ISBN+$ PropertyChanged=�6�   �� 5)      $��	Categorie��6$   $��0,10,0,5q�65   $
��Bold"�6G   �� 5*      $��0,0,0,10q�6a   $��5q�6s   $��14(�6   ���#f9f7fc��6"   �� *
Category+$ PropertyChanged=�6�   �� 5-      $��Editura��6$   $��0,10,0,5q�63   $
��Bold"�6E   �� 5.      $��0,0,0,10q�6b   $��5q�6t   $��14(�6�   ���#f9f7fc��6"   �� *	Publisher+$ PropertyChanged=�6�   �� 51      $��Număr Pagini��6$   $��0,10,0,5q�68   $
��Bold"�6J   �� 52      $��0,0,0,10q�6�   $��5q�6�   $��14(�6�   ���#f9f7fc��6"   �� *	PageCount+# [ $ PropertyChanged=�6�   �� 55      $��
Dimensiuni��6$   $��0,10,0,5q�66   $
��Bold"�6H   �� 56      $��0,0,0,10q�6c   $��5q�6u   $��14(�6�   ���#f9f7fc��6"   �� *
Dimensions+$ PropertyChanged=�6�   �� 5:      $��Număr Exemplare��6$   $��0,10,0,5q�6;   $
��Bold"�6M   �� 5;      $��0,0,0,10q�6�   $��5q�6�   $��14(�6�   ���#f9f7fc��6"   �� *Copies+# [ $ PropertyChanged=�6�   �� 5=       �� Orientation$ 
Horizontal=�6%   $��7��6>   $��5q�6K   .+�5>      �� $��Selectează poză��6%   ���#bd99ff��6?   �� *SelectImageCommand+6f   �� 5?      $	��100��6{   $	��100��6�   $��5q�6�   ��6$   �� *SelectedImage+# [  6�   5@      �� 5C      $��	Descriere��6$   $��0,10,0,5q�65   $
��Bold"�6G   �� 5D      $��0,0,0,10q�6d   $��5q�6v   $��14(�6�   $	��100��6�    �� TextWrapping$
 Wrap=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   ��6"   �� *Description+$ PropertyChanged=�6�   �� 5G      $��Adaugă cartea��6!   $��14(�5H   !   $
��10,5q�6/   $��Center=�5I   !   
������ ���#42adf5
����ح�$	��1.5q�5M       $	��125��5N   !   ��5G   9   �� *AddBookCommand+5V      5W      5X      5Y      5Z      5[      5\      