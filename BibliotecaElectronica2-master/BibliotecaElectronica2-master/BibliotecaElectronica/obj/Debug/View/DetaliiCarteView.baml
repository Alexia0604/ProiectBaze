   M S B A M L   `   `   `  ����P  LBibliotecaElectronica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:BibliotecaElectronica.ViewBibliotecaElectronica.View  5      Q-clr-namespace:BibliotecaElectronica.ViewModelBibliotecaElectronica.ViewModel  5      Q-clr-namespace:BibliotecaElectronica.UtilitiesBibliotecaElectronica.Utilities  5	      1    +BibliotecaElectronica.View.DetaliiCarteView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:BibliotecaElectronica.View     5      =vms-clr-namespace:BibliotecaElectronica.ViewModel     5      X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      =	utilities-clr-namespace:BibliotecaElectronica.Utilities  5	        � 	Resources  5      8   2BibliotecaElectronica.Utilities.StarColorConverter   StarColorConverter@   :BibliotecaElectronica.Utilities.PercentageToWidthConverter  PercentageToWidthConverter?   9BibliotecaElectronica.Utilities.TextToVisibilityConverter  TextToVisibilityConverter9   3BibliotecaElectronica.Utilities.StarReviewConverter  StarReviewConverter   BooleanToVisibilityConverterG   ABibliotecaElectronica.Utilities.ExemplareToButtonEnabledConverter % !ExemplareToButtonEnabledConverter��%�   &	        &	      &	 &     &	 9     &	 L     &	 _       5   
   6'     5   
   6/     5   
   6.     5   
   6(   �� 5   
   6'     5   
   66   5      .��5      �� $
��Auto=�6   .��5   
   �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    �� 5      $��30 �6     � ColumnDefinitions 5      �� 5      $��* �6#   �� 5       $��* �6   .+�5#      �� $��0��6   $��0��5$      $��2��5%       �� Orientation$ Vertical=�5&      .+�5'      �� $��16(�5(      $��Calibri)�5)      
����p����5'      �� *SelectedBook.Author+5*      �� 5+      $��18(�5,      $��Calibri italic)�5-      
���   ���5+      �� *SelectedBook.Title+5.      �� 5/      $ 
Horizontal=�6   .+�50      �� $	��200��51      $	��190��52      $	��Top=�53      $��	10,15,0,0q�54      $
��Left=�55      ��56      �� *SelectedBook.BitmapImage+57      �� 58       �� CornerRadius$ 10��6   
������ $	��100��6H   $	��120��6U   ._�59      �� $ Vertical=�6%   .+�5:      �� $��Center=�6m   $��Center=�6�   ��6+   �� *Stars+ �� UpdateSourceTrigger$ PropertyChanged=���5;   "   �� 5<   &   .R�5=   *   �� $	��★��64   $��20(�5>   1   ��5?   1   ��  �� 	Converter# [  5A   '   ��5C   "   �� 5D   &   .R�5E   *   �� $ 
Horizontal=�65   5F   '   5H      �� 5I      $ 
Horizontal=�6)   $��Center=�6B   $��5,0,0,0q�6_   .+�5J   "   �� $��14(�6,   ���#42adf5$��Center=�5K   {   ��6,   �� *AverageRating+ �� Mode$ TwoWay=�$ PropertyChanged=�6{   �� 5L   "   $��14(�6,   ���#42adf5$�� (��6O   $��Center=�6Y   �� 5M   "   $��14(�6,   ���#42adf5$��Center=�6�   ��6O   �� *TotalReviews+$ TwoWay=� �� StringFormat$  {0} recenzii��$ PropertyChanged=�6�   �� 5N   "   $��14(�6,   ���#42adf5$�� )��6O   $��Center=�6Y   5O      5P      5Q      5R      5T      �� 5U      $��0��6   $��1��6&   .+�5V      �� $��Împrumută!��6   
������ ���#ad4ef5$	��110��5Z      $��30��6%   $��	0,90,10,0q�61   ��5Y      �� *
BorrowBook+{�5[      `� 5\      	 `� 	Converter#	 [ 6'   .1�5]      �� 
 �� Path$
 SelectedBook.NrExemplare�6&   �� 5^      $
 IsButtonPressed�6&   5_      5a      �� 5b      $ 
Horizontal=�6!   .+�5c      �� $��Exemplare disponibile: ��6    $��	80,20,0,0q�5d      $��14(�5e      �� 5g      $��	0,20,0,10q�5h   !   $��14(�5i   !   ��5g       �� *SelectedBook.NrExemplare+$ PropertyChanged=�5i   !   5j      5l      �� 5n      $ Vertical=�6   $��1��60   $��2��6=   .+�5q      �� $��1��6   $��0��6*   $ Vertical=�6:   .+�5r      �� $��Specificații��6   $��20(�5s      $��Calibri bold)�5t      $��	20,20,0,0q�5u      � 5v       5w      �� 5x      $
��Auto �6/   �� 5y      $��10 �6/   �� 5z      $
��Auto �6/   �� 5{      $��10 �6/   �� 5|      $
��Auto �6/   �� 5}      $��10 �6/   �� 5~      $
��Auto �6/   �� 5      $��10 �6/   �� 5�      $
��Auto �6/    5�      �� 5�      $
��Auto �6,   �� 5�      $
��Auto �6,   .+�5�      �� $��
Dimensiune��6    $��0��65   $��0��6B   $��5,5,0,0q�6R   �� 5�      $��Număr pagini��6    $��0��67   $��2��6D   $��20,5,0,0q�6T   �� 5�      $��Editura��6    $��0��62   $��4��6?   $��20,5,0,0q�6O   �� 5�      $��Autor��6    $��0��60   $��6��6=   $��20,5,0,0q�6M   �� 5�      $
��ISBN��6    $��0��6/   $��8��6<   $��20,5,0,0q�6L   �� 5�      $��1��6M   $��0��6Z   $��10,5,0,0q�6j   ��6$   �� *SelectedBook.Dimensiune+6j   �� 5�      $��1��6K   $��2��6X   $��40,5,0,0q�6h   ��6$   �� *SelectedBook.NrPagini+6h   �� 5�      $��1��6J   $��4��6W   $��5q�6g   ��6$   �� *SelectedBook.Editura+6g   �� 5�      $��1��6I   $��6��6V   $��5q�6f   ��6$   �� *SelectedBook.Author+6f   �� 5�      $��1��6G   $��8��6T   $��5q�6d   ��6$   �� *SelectedBook.Isbn+6d   5�      �� 5�      $��	Descriere��6   $��20(�5�      $��	20,20,0,0q�5�      $��Calibri bold)�5�      �� 5�      $��14(�5�      $
��Wrap=�5�      $��
10,15,0,10q�5�      ��5�       �� *SelectedBook.Description+5�      5�      �� 5�      $��1��6   $��2��6*   .+�5�      �� $��Recenzii��6    $��20(�60   $��Calibri bold)�6>   $��	25,20,0,0q�6X   �� 5�      $ 
Horizontal=�6!   $��	10,10,0,0q�6:   .+�5�      �� $ 10��6!   ���#f7f7f7$	��100��6H   $	��130��6U   ._�5�      �� $ Vertical=�6)   .+�5�   "   �� $��24(�6,   $
��Bold"�6:   $��Center=�6�   ��6L   �� *AverageRating+$ PropertyChanged=�6�   �� 5�   "   $��Center=�6q   $��Center=�6�   ��6/   �� *Stars+$ PropertyChanged=���5�   &   �� 5�   *   .R�5�   .   �� $	��★��68   $��25(�5�   ,   ��5�   ,   �� # [  5�   +   ��5�   &   �� 5�   *   .R�5�   .   �� $ 
Horizontal=�69   5�   +   5�   #   �� 5�   "   $��16(�6,   $��Center=�6�   $��0,5,0,0q�6�   ��6:   �� *TotalReviews+$ PropertyChanged=�$  {0} recenzii��6�   5�      5�      �� 5�      $ Vertical=�6%   $��20q�6<   .+�5�      �� ��6+   �� *	Ratings+$ PropertyChanged=���5�   "   �� 5�   &   .R�5�   *   �� $ 
Horizontal=�65   $��Center=�6N   $	��0,5q�6i   .+�5�   .   �� $��14(�6�   $��70��6�   ��68   �� *Key+$ 
 {0} stele��$ PropertyChanged=�6�   � 5�   .   $��15��5�   -   $	��150��5�   -   $��0,0,10,0q�5�   -    � Value 5�   -   �� *Value+$ PropertyChanged=� � Maximum 5�   -   �� *DataContext.TotalRatings+ �� RelativeSource ��  �� AncestorType$ ItemsControlL�$ PropertyChanged=�5�   -   �� 5�   .   $��14(�6s   ��68   �� *Value+$ PropertyChanged=�6s   5�   +   5�   '   5�      5�      �� 5�      $	��0.5q�6!   
�������
������ $	��100��6c   $
��auto��6p   y�5�   !   �� *IsSectionVisible+# [ ._�5�      �� $ Vertical=�6)   .+�5�   "   �� $��Ți-a plăcut cartea?��6,   $��Center=�5�   ,   $
��Bold"�5�   -   $��15(�5�   ,   $��
20,10,20,5q�5�   ,   �� 5�   "   $%��Spune tuturor părerea ta aici.��6,   $��Center=�5�   ,   $��12(�5�   ,   $��	20,0,20,5q�5�   ,   �� 5�   "   $��Adaugă recenzie��6)   $��30��5�      $	��160��5�      $��	20,0,20,0q�5�      $��Center=�5�      $��Center=�5�      $��12(�5�      
������ ���#42adf5
����ح���5�      �� *OpenPopupCommand+5�      � 5�   "   -   5         �Name$ ReviewPopup��5�   (   $��Center=�6i   ��6=   �� *IsPopupOpen+$ TwoWay=�.��5�   &   �� 
�������
�������$��1q�6S    �� Padding$ 20q�6g   $ 5��6t   ._�5�   *   �� $ Vertical=�65   $	��300��6L   .+�5�   .   �� $��Adaugă o recenzie��68   $��16(�6Q   $
��Bold"�6_   $��0,0,0,10q�6q   � 5�   .   .+�5�   2   �� -   5         ��Name$ PlaceholderTextBlock��5�   <   $��Scrie recenzia ta aici...��5�   <   
�������$��5q�5�   <   $��Center=�5�   <    J� IsHitTestVisible .  y�5�   <   �� *	NewReview+# [ �� 5�   2   -   5         ��Name$ ReviewTextBox��5�   :    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�5�   6   $	��Top=�5�   6   $��5q�5�   6   ��5�   5   �� *	NewReview+$ PropertyChanged=�5�   :   5�   /   �� 5  .   $ 
Horizontal=�69   $��Center=�6R   $��0,0,0,10q�6o   .+�5  2   �� $��Center=�5  :   $��0,0,0,10q�5  :   ��5  :   �� *StarOptions+$ TwoWay=�$ PropertyChanged=� �� SelectedItem 5  :   �� *SelectedStars+$ TwoWay=�$ PropertyChanged=���5  6   �� 5  :   .R�5  >   �� $	��★��6E   $��20(�5  E   
������ 
������ ��5	  E   �� *DataContext.SelectStarCommand+ �� $ PopupL���5
  E   �� ��5  E   �� # [ $ PropertyChanged=�5  E   5  ;   ��5  6   �� 5  :   .R�5  >   �� $ 
Horizontal=�6I   5  ;   5  3   5  /   �� 5  .   $ 
Horizontal=�69   $��Right=�6R   .+�5  2   �� $��	Anulează��69   $	��100��6L   $��5q�6X   ��6c   �� *ClosePopupCommand+�� 5  2   $��Adaugă��69   $	��100��6J   $��5q�6V   ��6a   �� *SubmitReviewCommand+5  /   5  +   5  '   5  #   5      5!     5"     �� 5#     $��5q�6p   ��6   �� *
Recenzii+$ TwoWay=�$ PropertyChanged=� 5$     �� *SelectedReview+$ TwoWay=�$ PropertyChanged=���5%     �� 5&     .R�5'  "   �� $��0,0,0,10q�6-   .+�5(  &   �� $
��Bold"�5)  0   
�������$��14(�5+  0   $��0,0,0,0q�5,  0   ��5(  0   �� *NumeUtilizator+5,  0   �� 5.  &   ��63   �� *
StarsArray+��5/  *   �� 50  .   .R�51  2   �� $ 
Horizontal=�6=   52  /   ��54  *   �� 55  .   .R�56  .   �� $	��★��68   $��25(�57  :   ��58  ;   �� # [  5:  /   5<  '   �� 5>  &   $
��Wrap=�5?  (   $��12(�5@  (   $��10,0,0,5q�5A  (   ��5>  0   �� *
Comentariu+5A  (   �� 5C  &   $ 
Horizontal=�61   $��Right=�6J   .+�5D  *   �� $
��👍��61   $��0,0,5,0q�5H  1   ��5F  1   �� *DataContext.LikeCommand+ �� $ ListBoxL���5G  1   �� ��5I  1   Z� �� 5J  *   $��0,0,5,5q�5K  4   ��5J  4   �� *Like+$ PropertyChanged=�5K  4   �� 5L  *   $
��👎��61   ��5N  1   �� *DataContext.DislikeCommand+ �� $ ListBoxL���5O  1   �� ��5P  1   Z� �� 5Q  *   $��5,0,5,5q�5R  5   ��5Q  4   �� *	Dislike+$ PropertyChanged=�5R  5   5T  '   �� 5V  &   $��	30,10,0,0q�60   $	��500��6C   5W  #   5X     5Z     5\     5]     5q     5s     5t     