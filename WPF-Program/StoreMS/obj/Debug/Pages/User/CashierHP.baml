   M S B A M L   `   `   `  ����B  >StoreMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:WPFModernVerticalMenu.ControlsWPFModernVerticalMenu.Controls  5   	   !clr-namespace:StoreMSStoreMS  5   	       StoreMS.CashierHP   5   	   5ctls,clr-namespace:WPFModernVerticalMenu.Controls  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:StoreMS     5   	   -   5        $
��home��5        � Title$'  !Cashier | Store Management System��5	   	   $	��750��63   $
��1200��6@    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�6.   
������  � AllowsTransparency .  � 
ResizeMode$ NoResize=�5   	   $��Poppins)�6    � WindowState$ 	Maximized=�64   .��5      ��    PrimaryBackgroundColor#���   6    �� CornerRadius$ 18��5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� $��0��6     SecundaryBackgroundColor#���  5      $ 	18 0 0 18��5      ._�5      � -   5         �Name$ GridNav��5      $��60��6(   	 � RowDefinitions	 5      �� 5      $	��110 �6(   �� 5      $��* �6(   .+�5      � $��0��6   .+�5       �� $��	10,25,0,7q�5!      $��40��5"      $��40��6*   $
��Left=�5#      ��5$      �� 5%   "   
 �� ImageSource$%
 /Pages/Admin/Resources/Logo.png��6-    j� Stretch$ Uniform=�6[   5'      �� 5)      $��Store��6    $
��Bold"�5*       $��16(�5+       $��Center=�5,       $
��Left=�5-       $��
60 -10 0 0q�5.        J� RenderTransformOrigin$ 0.5,0&�64   �� 5/      $��
Management��6    $
��Bold"�50       $��16(�51       $��Center=�52       $��	60,22,0,0q�53       $ 0.5,0&�63   �� 54      $��System��6    $
��Bold"�55       $��16(�56       $��Center=�57       $��	60,54,0,0q�58       $ 0.5,0&�63   59      �� 5<      $��1��6!   $��	-1 0 0 20q�6.   .+�5=      �� -   5         ��Name$ btnPOS��5=   !     PopupButtonStyle#���  61   .��5>      -   'WPFModernVerticalMenu.Controls.MenuItem     	GroupName$ MenuItem��6,     PrimaryBlueColor   IndicatorBrush# �  6A     POS   Icon# �  6u      	IconWidth$ 16��6�      Text$ Point of Sale��6�   $��Center=�6�   5?      �� 5@      -   5        $ btnInventory��5@   !   #���  67   .��5A        $ MenuItem��6,   # �  6A     	Inventory# �  6u   $ 16��6�   $ 	Inventory��6�   $��Center=�6�   5B      �� 5C      -   5        $ 
btnAccount��5C   !   #���  65   .��5D        $ MenuItem��6,   # �  6A     AccountInfo# �  6u   $ 16��6�   $ Account Info��6�   $��Center=�6�   5E      5F      � 5J      -   5         �Name$ Popup��5J       � AllowsTransparency .  � HorizontalOffset$ 0��6G    � VerticalOffset$ 10��6\   .��5K      .   (WPFModernVerticalMenu.Controls.UserPopup  -   5          Name$ Header��5K   )     PrimaryTextColor#���  69   5L      5O      5P      � 5R      $��1��6   	 5S      �� 5T      $��50 �6$   �� 5U      $��* �6$   .+�5X      d� -   5         d�Name$ Tg_Btn��5X      $��1��6/   $��Center=�6?     iToggleButtonStyle#���  6Z   $
��Left=�6�   $��0q�6�   
������ $��
10,20,0,15q�6�   $��30��6�   $��30��6�    � Triggers 5Y      :� 5Z       :� RoutedEvent$ ToggleButton.Unchecked��6'   .[�5[      �� .��5\   "   �� -	   5         ��Name$ HideStackPanel��5\   -   .��5]   &   W�  �� 
TargetName$ GridNav��66    �� TargetProperty$ Width�6V    g� 	BeginTime$ 0:0:0X�6x    W� From$	 210X�6�   	  W� To$  60X�6�   ! g� Duration$! 0:0:0.5D�6�   5^   '   5_   #   5`      5a      :� 5b      $ ToggleButton.Checked��6'   .[�5c      �� .��5d   "   �� -
   5        $ ShowStackPanel��5d   -   .��5e   &   W� $ GridNav��66   $ Width�6V   $ 0:0:0X�6x   $ 60X�6�   $	  210X�6�   $! 0:0:0.5D�6�   5f   '   5g   #   5h      5i      5k      �� 5n      $��0��6   $��Right=�6*   $	��Top=�6F   $��0,5,10,0q�6^   $��30��6p   " �� Orientation$" 
Horizontal=�6|   $��RightToLeft=�6�   $��2��6�   .+�5o      �� -   5        $ btnClose��5o       	 IconButtonsStyle#��[	 6/    	
 close#��� 
 6Y   
# � Tag$# IsCloseButton��6�   �� 5p      -   5        $ 
btnRestore��5p      $	��5,0q�61   ��5q      �� 5r      $ �� 
TargetType"$ ��6$   % �� BasedOn#% [	 6A   .�5s   "   �� & �� Property& � ��  maximize' �� Value#' �  6<   ( �� Triggers( 5t   "   �� 5u   &   ) �� Binding) 62   �� * �� ElementName$
* home��+ �� Path$+ WindowState�, �� Value, 	Maximized6i   .a�5v   *   �� & � ��  restore#' �  6D   5w   '   5y      5{      �� 5|      -   5        $ btnMinimize��5|      #��� 	 62     minimize#���  6]   6�   5}       � 5�      -   5        $��
fContainer��5�      $��1��5�      $��20q�5�      -  � NavigationUIVisibility$- Hidden=�5�      5�      ��5�      �� 5�      $
 /background.png��6!   $
 None=�5�   !   . j� 
AlignmentX$. Center=�5�   !   / j� 
AlignmentY$/ Center=�5�   !   5�      5�      5�      5�      