   M S B A M L   `   `   `  ����B  >StoreMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:WPFModernVerticalMenu.ControlsWPFModernVerticalMenu.Controls  5   	   !clr-namespace:StoreMSStoreMS  5   	       StoreMS.UserHP   5   	   5ctls,clr-namespace:WPFModernVerticalMenu.Controls  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:StoreMS     5   	   -   5        $
��home��5        � Title$  User Home Page��5	   	   $	��650��6    $
��1000��6-    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�6.   
������  � AllowsTransparency .  � 
ResizeMode$ NoResize=�5   	   $��Poppins)�6   .��5      ��    PrimaryBackgroundColor#���   6    �� CornerRadius$ 18��5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� $��0��6     TertiaryBackgroundColor#���  5      $ 	18 0 0 18��5      ._�5      � -   5         �Name$ GridNav��5      $��60��6(    � RowDefinitions 5      �� 5      $	��110 �6(   �� 5      $��* �6(   .+�5      � $��0��6   .+�5       �� $��	10,25,0,7q�5!      $��40��5"      $��40��6*   $
��Left=�5#      ��5$      �� 5%   "   	 �� ImageSource$%	 /Pages/Admin/Resources/Logo.png��6-   
 j� Stretch$
 Uniform=�6[   5'      �� 5)      $��Store��6      PrimaryTextColor#���  5*       $
��Bold"�5+       $��16(�5,       $��Center=�5-       $
��Left=�5.       $��
60 -10 0 0q�5/        J� RenderTransformOrigin$ 0.5,0&�64   �� 50      $��
Management��6    #���  51       $
��Bold"�52       $��16(�53       $��Center=�54       $��	60,22,0,0q�55       $ 0.5,0&�63   �� 56      $��System��6    #���  57       $
��Bold"�58       $��16(�59       $��Center=�5:       $��	60,54,0,0q�5;       $ 0.5,0&�63   5<      �� 5?      $��1��6!   $��	-1 0 0 20q�6.   .+�5@      �� -   5         ��Name$ btnBorrowBook��5@   !     PopupButtonStyle#���  68   .��5A      -   'WPFModernVerticalMenu.Controls.MenuItem     	GroupName$ MenuItem��6,     PrimaryBlueColor   IndicatorBrush# �  6A     students   Icon# �  6u      	IconWidth$ 16��6�      Text$ Borrow Books��6�   $��Center=�6�   5B      �� 5C      -   5        $ btnRequestBook��5C   !   #���  69   .��5D        $ MenuItem��6,   # �  6A     advisors# �  6u   $ 16��6�   $ Request Book��6�   $��Center=�6�   5E      �� 5F      -   5        $ btnReviewBook��5F   !   #���  68   .��5G        $ MenuItem��6,   # �  6A     projects# �  6u   $ 16��6�   $ Review Book��6�   $��Center=�6�   5H      �� 5I      -   5        $ btnLists��5I   !   #���  63   .��5J        $ MenuItem��6,   # �  6A    
 groups# �  6u   $ 16��6�   $ Lists��6�   $��Center=�6�   5K      �� 5L      -   5        $ 	btnReport��5L   !   #���  64   .��5M        $ MenuItem��6,   # �  6A    
	 Report# � 	 6u   $ 16��6�   $ Reports��6�   $��Center=�6�   5N      5O      � 5S      -   5         �Name$ Popup��5S       � AllowsTransparency .  � HorizontalOffset$ 0��6G    � VerticalOffset$ 10��6\   .��5T      .   (WPFModernVerticalMenu.Controls.UserPopup  -	   5          Name$ Header��5T   )   #���  69   5U      5X      5Y      � 5[      $��1��6    5\      �� 5]      $��50 �6$   �� 5^      $��* �6$   .+�5a      d� -
   5         d�Name$ Tg_Btn��5a      $��1��6/   $��Center=�6?    
 iToggleButtonStyle#��� 
 6Z   $
��Left=�6�   $��0q�6�   
������ $��
10,20,0,15q�6�   $��30��6�   $��30��6�    � Triggers 5b      :� 5c       :� RoutedEvent$ ToggleButton.Unchecked��6'   .[�5d      �� .��5e   "   �� -   5         ��Name$ HideStackPanel��5e   -   .��5f   &   W�  �� 
TargetName$ GridNav��66    �� TargetProperty$ Width�6V    g� 	BeginTime$ 0:0:0X�6x    W� From$	 210X�6�   	 W� To$ 60X�6�     g� Duration$  0:0:0.5D�6�   5g   '   5h   #   5i      5j      :� 5k      $ ToggleButton.Checked��6'   .[�5l      �� .��5m   "   �� -   5        $ ShowStackPanel��5m   -   .��5n   &   W� $ GridNav��66   $ Width�6V   $ 0:0:0X�6x   $ 60X�6�   $	 210X�6�   $  0:0:0.5D�6�   5o   '   5p   #   5q      5r      5t      �� 5w      $��0��6   $��Right=�6*   $	��Top=�6F   $��0,5,10,0q�6^   $��30��6p   ! �� Orientation$! 
Horizontal=�6|   $��RightToLeft=�6�   $��2��6�   .+�5x      �� -   5        $ btnClose��5x        IconButtonsStyle#��[ 6/    	 close#���  6Y   
" � Tag$" IsCloseButton��6�   �� 5y      -   5        $ 
btnRestore��5y      $	��5,0q�61   ��5z      �� 5{      # �� 
TargetType"# ��6$   $ �� BasedOn#$ [ 6A   .�5|   "   �� % �� Property% � ��  maximize& �� Value#& �  6<   ' �� Triggers' 5}   "   �� 5~   &   ( �� Binding( 62   �� ) �� ElementName$
) home��* �� Path$* WindowState�+ �� Value+ 	Maximized6i   .a�5   *   �� % � ��  restore#& �  6D   5�   '   5�      5�      �� 5�      -   5        $ btnMinimize��5�      #���  62     minimize#���  6]   6�   5�       � 5�      -   5        $��
fContainer��5�      $��1��5�      $��20q�5�      ,  � NavigationUIVisibility$, Hidden=�5�      5�      ��5�      �� 5�      $	 /background.png��6!   $

 None=�5�   !   - j� 
AlignmentX$- Center=�5�   !   . j� 
AlignmentY$. Center=�5�   !   5�      5�      5�      5�      