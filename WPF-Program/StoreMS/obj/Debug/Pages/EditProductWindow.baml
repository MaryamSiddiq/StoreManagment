   M S B A M L   `   `   `  ����B  >StoreMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:WPFModernVerticalMenu.ControlsWPFModernVerticalMenu.Controls  5   	   !clr-namespace:StoreMSStoreMS  5   	   %    StoreMS.Pages.EditProductWindow   5   	   5ctls,clr-namespace:WPFModernVerticalMenu.Controls  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:StoreMS     5   	   -   5        $
��home��5        � WindowStartupLocation$  CenterScreen=�5	   	    � WindowStyle$
 None=�6.   
������  � AllowsTransparency .  � 
ResizeMode$ NoResize=�5   	   $��Poppins)�6    � Title$ Edit Product��5   	   $	��240��6   $	��400��6+   .��5      ��    SecundaryIconColor#���   6    �� CornerRadius$ 18��5      ._�5   
   � $��10q�6   .+�5      �� $��
New Price:��6   $
��Left=�6)   $	��Top=�6D   $��4,13,0,0q�6\   $��16(�5      �� 5      -   5         ��Name$ txtPrice��5      $
��Left=�6(   $	��Top=�6C   $	��239��6[   $��
140,14,0,0q�6g   $��16(�5      �� 5      $��New Quantity:��6   $
��Left=�6,   $	��Top=�6G   $��4,46,0,0q�6_   $��16(�5      �� 5      -   5        $ txtQuantity��5      $
��Left=�6+   $	��Top=�6F   $	��239��6^   $��
140,50,0,0q�6j   $��16(�5      �� 5      $��New Category:��6   $
��Left=�6,   $	��Top=�6G   $��4,86,0,0q�6_   $��16(�5      �� 5      -   5         ��Name$ 
CBCategory��5   '   $��0��6    �� SelectedIndex$ 0��6;   $��16(�5      
�������
�������$
��Left=�5!      $	��Top=�66   	 � Cursor$
	 Hand��5"      $	��239��5#      $��
140,88,0,0q�5$      $��Center=�5%      .@�5&      �� {�.  $��Select the Category��61   5'      �� 5(      $��New Description:��6   $
��Left=�6/   $	��Top=�6J   $��	4,126,0,0q�6b   $��16(�5)      �� 5*      -   5        $ txtDescription��5*      $
��Left=�6.   $	��Top=�6I   $	��239��6a   $��140,130,0,0q�6m   $��16(�5+      �� 5-      -   5        $��Save Changes��5-      $��Right=�6,   $	��Top=�6H   $��	0,170,0,0q�6`   $��30��6�   $	��122��6�   $��16(�5.      5/      50      51      