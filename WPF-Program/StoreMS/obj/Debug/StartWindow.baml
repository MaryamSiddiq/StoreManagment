   M S B A M L   `   `   `  ����B  >StoreMS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:WPFModernVerticalMenu.ControlsWPFModernVerticalMenu.Controls  5   	   !clr-namespace:StoreMSStoreMS  5   	       StoreMS.StartWindow   5   	   5ctls,clr-namespace:WPFModernVerticalMenu.Controls  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:StoreMS     5   	   -   5        $
��home��5        � Title$  Store MS��5	   	   $	��650��6   $
��1000��6'    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$
 None=�6.   
������  � AllowsTransparency .  � 
ResizeMode$ NoResize=�5   	   $��Poppins)�6   .��5      ��    PrimaryBackgroundColor#���   6    �� CornerRadius$ 18��5      ._�5   
   �  � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      � $��1��6    � RowDefinitions 5      �� 5      $��40 �6$   �� 5      $��30 �6$   �� 5      $��* �6$   .+�5      �� $��0��6   $��Right=�6*   $	��Top=�6F   $��0,5,10,0q�6^   $��30��6p    �� Orientation$ 
Horizontal=�6|   $��RightToLeft=�6�   $��2��6�   .+�5      �� -   5        	 ��Name$	 btnClose��5        IconButtonsStyle#��[ 6/    	 close#���  6Y   

 � Tag$
 IsCloseButton��6�   �� 5       -   5        $	 
btnRestore��5       $	��5,0q�61   ��5!      �� 5"       �� 
TargetType" ��6$    �� BasedOn# [ 6A   .�5#   "   ��  �� Property � ��  maximize �� Value# �  6<    �� Triggers 5$   "   �� 5%   &    �� Binding 62   ��  �� ElementName$
 home�� �� Path$ WindowState� �� Value 	Maximized6i   .a�5&   *   ��  � ��  restore# �  6D   5'   '   5)      5+      �� 5,      -   5        $	 btnMinimize��5,      #���  62     minimize#���  6]   6�   5-      � 5/      $��1��6   .+�50      �� -   5         ��Name$ CBRole��50       �� SelectedIndex$ 0��51   %   $��16(�52   %   $��Right=�53   %   $��0,0,10,0q�54   %   $	��Top=�55   %   $	��135��6=   $��26��6I    � Cursor$
 Hand��6U   .@�56      �� {�.  $��Select the Role��69   �� 57      $��Admin��6'   �� 58      $��Cashier��6'   59      5:       � 5;      -   5        $��
fContainer��5<      $��2��5;      $��	0 -40 0 0q�5=        � NavigationUIVisibility$ Hidden=�5>      $	��700��5?      $	��500��5@      5B      ��5C      �� 5D       �� ImageSource$ /background.png��6!    j� Stretch$
 None=�5E   !    j� 
AlignmentX$ Center=�5F   !    j� 
AlignmentY$ Center=�5G   !   5J      5N      5O      5P      