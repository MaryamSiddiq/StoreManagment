   M S B A M L   `   `   `  ����B  >StoreMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:WPFModernVerticalMenu.ControlsWPFModernVerticalMenu.Controls  5   	   !clr-namespace:StoreMSStoreMS  5   	   (    "StoreMS.Pages.Admin.EditUserWindow   5   	   5ctls,clr-namespace:WPFModernVerticalMenu.Controls  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:StoreMS     5   	   -   5        $
��home��5        � WindowStartupLocation$  CenterScreen=�5	   	    � WindowStyle$
 None=�6.   
������  � AllowsTransparency .  � 
ResizeMode$ NoResize=�5   	   $��Poppins)�6    � Title$ 	Edit User��5   	   $	��160��6   $	��340��6(   .��5      ��    SecundaryIconColor#���   6    �� CornerRadius$ 18��5      ._�5   
   � $��10q�6    � RowDefinitions 5      �� 5      $	��57* �6    �� 5      $	��83* �6    .+�5      �� $��	New Name:��6   $
��Left=�6(   $	��Top=�6C   $��	10,13,0,0q�6[   $��16(�5      �� 5      -   5         ��Name$ 
txtNewName��5      $
��Left=�6*   $	��Top=�6E   $	��200��6]   $��
120,14,0,0q�6i   $��16(�5      �� 5      $��	New Role:��6   $
��Left=�6(   $	��Top=�6C   $��	10,46,0,0q�6[   $��16(�5      $��2��6"   �� 5      -   5         ��Name$ CBRole��5   '   $��0��6   	 �� SelectedIndex$	 0��67   $��16(�5      
�������
�������$
��Left=�5       $	��Top=�66   
 � Cursor$

 Hand��5!      $	��200��5"      $��
120,48,0,0q�5#      $��Center=�5$      $��2��6=   .@�5%      �� {�.  $��Select the Role��61   �� 5&      $��Admin��6   �� 5'      $��Cashier��6   5(      �� 5*      -   5         ��Name$ chkNewIsActive��5*      $��	Is Active��6/   $
��Left=�6C   $	��Top=�6^   $��	14,27,0,0q�6v   $	��306��6�   $��16(�5+      $��1��6%   �� 5-      -   5        $��Save Changes��5-      $��Right=�6,   $	��Top=�6H   $��0,52,0,0q�6`   $��30��6�   $	��122��6�   $��16(�5.      $��1��6#   5/      50      51      