   M S B A M L   `   `   `  ����B  >StoreMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:WPFModernVerticalMenu.ControlsWPFModernVerticalMenu.Controls  5   	   !clr-namespace:StoreMSStoreMS  5   	       StoreMS.AdminHP   5   	   5ctls,clr-namespace:WPFModernVerticalMenu.Controls  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:StoreMS     5   	   -   5        $
��home��5        � Title$%  Admin | Store Management System��5	   	   $	��750��61   $
��1200��6>    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�6.   
������  � AllowsTransparency .  � 
ResizeMode$ NoResize=�5   	   $��Poppins)�6    � WindowState$ 	Maximized=�64   .��5      ��    PrimaryBackgroundColor#���   6    �� CornerRadius$ 18��5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� $��0��6     SecundaryBackgroundColor#���  5      $ 	18 0 0 18��5      ._�5      � -   5         �Name$ GridNav��5      $��60��6(   	 � RowDefinitions	 5      �� 5      $	��110 �6(   �� 5      $��* �6(   .+�5      � $��0��6   .+�5       �� $��	10,25,0,7q�5!      $��40��5"      $��40��6*   $
��Left=�5#      ��5$      �� 5%   "   
 �� ImageSource$
 Resources/Logo.png��6-    j� Stretch$ Uniform=�6N   5'      �� 5)      $��Store��6    $
��Bold"�5*       $��16(�5+       $��Center=�5,       $
��Left=�5-       $��
60 -10 0 0q�5.        J� RenderTransformOrigin$ 0.5,0&�64   �� 5/      $��
Management��6    $
��Bold"�50       $��16(�51       $��Center=�52       $��	60,22,0,0q�53       $ 0.5,0&�63   �� 54      $��System��6    $
��Bold"�55       $��16(�56       $��Center=�57       $��	60,54,0,0q�58       $ 0.5,0&�63   59      �� 5<      $��1��6!   $��	-1 0 0 20q�6.   .+�5=      �� -   5         ��Name$ btnDashboard��5=   !     PopupButtonStyle#���  67   .��5>      -   'WPFModernVerticalMenu.Controls.MenuItem     	GroupName$ MenuItem��6,     TertiaryBackgroundColor   IndicatorBrush# �  6A     	Dashboard   Icon# �  6|      	IconWidth$ 16��6�      Text$ 	Dashboard��6�   $��Center=�6�   5?      �� 5@      -   5        $ btnUser��5@   !   #���  62   .��5A        $ MenuItem��6,   # �  6A    	 Users# �  6|   $ 16��6�   $ Users��6�   $��Center=�6�   5B      �� 5C      -   5        $ 
btnProduct��5C   !   #���  65   .��5D        $ MenuItem��6,   # �  6A     Products# �  6|   $ 16��6�   $ Products��6�   $��Center=�6�   5E      �� 5F      -   5        $ btnCategory��5F   !   #���  66   .��5G        $ MenuItem��6,   # �  6A     Category# �  6|   $ 16��6�   $ Product Categories��6�   $��Center=�6�   5H      �� 5I      -   5        $ btnCustomer��5I   !   #���  66   .��5J        $ MenuItem��6,   # �  6A     	Customers# �  6|   $ 16��6�   $ 	Customers��6�   $��Center=�6�   5K      �� 5L      -   5        $ btnGiftCard��5L   !   #���  66   .��5M        $ MenuItem��6,   # �  6A    	 GiftCard# � 	 6|   $ 16��6�   $ 
Gift Cards��6�   $��Center=�6�   5N      �� 5O      -	   5        $ btnTransaction��5O   !   #���  69   .��5P        $ MenuItem��6,   # �  6A    
 Transaction# � 
 6|   $ 16��6�   $ Transactions��6�   $��Center=�6�   5Q      �� 5R      -
   5        $ 	btnReport��5R   !   #���  64   .��5S        $ MenuItem��6,   # �  6A    
 Report# �  6|   $ 16��6�   $ Reports��6�   $��Center=�6�   5T      �� 5U      -   5        $ btnLogs��5U   !   #���  62   .��5V        $ MenuItem��6,   # �  6A     Log# �  6|   $ 16��6�   $
 Logs��6�   $��Center=�6�   5W      5X      � 5\      -   5         �Name$ Popup��5\       � AllowsTransparency .  � HorizontalOffset$ 0��6G    � VerticalOffset$ 10��6\   .��5]      .   (WPFModernVerticalMenu.Controls.UserPopup  -   5          Name$ Header��5]   )     PrimaryTextColor#���  69   5^      5a      5b      � 5d      $��1��6   	 5e      �� 5f      $��50 �6$   �� 5g      $��* �6$   .+�5j      d� -   5         d�Name$ Tg_Btn��5j      $��1��6/   $��Center=�6?     iToggleButtonStyle#���  6Z   $
��Left=�6�   $��0q�6�   
������ $��
10,20,0,15q�6�   $��30��6�   $��30��6�    � Triggers 5k      :� 5l       :� RoutedEvent$ ToggleButton.Unchecked��6'   .[�5m      �� .��5n   "   �� -   5         ��Name$ HideStackPanel��5n   -   .��5o   &   W�  �� 
TargetName$ GridNav��66    �� TargetProperty$ Width�6V    g� 	BeginTime$ 0:0:0X�6x    W� From$	 210X�6�   	  W� To$  60X�6�   ! g� Duration$! 0:0:0.5D�6�   5p   '   5q   #   5r      5s      :� 5t      $ ToggleButton.Checked��6'   .[�5u      �� .��5v   "   �� -   5        $ ShowStackPanel��5v   -   .��5w   &   W� $ GridNav��66   $ Width�6V   $ 0:0:0X�6x   $ 60X�6�   $	  210X�6�   $! 0:0:0.5D�6�   5x   '   5y   #   5z      5{      5}      �� 5�      $��0��6   $��Right=�6*   $	��Top=�6F   $��0,5,10,0q�6^   $��30��6p   " �� Orientation$" 
Horizontal=�6|   $��RightToLeft=�6�   $��2��6�   .+�5�      �� -   5        $ btnClose��5�        IconButtonsStyle#��[ 6/    	 close#���  6Y   
# � Tag$# IsCloseButton��6�   �� 5�      -   5        $ 
btnRestore��5�      $	��5,0q�61   ��5�      �� 5�      $ �� 
TargetType"$ ��6$   % �� BasedOn#% [ 6A   .�5�   "   �� & �� Property& � ��  maximize' �� Value#' �  6<   ( �� Triggers( 5�   "   �� 5�   &   ) �� Binding) 62   �� * �� ElementName$
* home��+ �� Path$+ WindowState�, �� Value, 	Maximized6i   .a�5�   *   �� & � ��  restore#' �  6D   5�   '   5�      5�      �� 5�      -   5        $ btnMinimize��5�      #���  62     minimize#���  6]   6�   5�       � 5�      -   5        $��
fContainer��5�      $��1��5�      $��20q�5�      -  � NavigationUIVisibility$- Hidden=�5�      5�      ��5�      �� 5�      $
 /background.png��6!   $
 None=�5�   !   . j� 
AlignmentX$. Center=�5�   !   / j� 
AlignmentY$/ Center=�5�   !   5�      5�      5�      5�      