   M S B A M L   `   `   `  ����C  ?Pet_Shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Pet_Shop.UserControlsPet_Shop.UserControls  5      &     Pet_Shop.UserControls.CustomerUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Pet_Shop.UserControls     5      -   5          >�Name$  
customerUC��5	       
  MainVM � DataContext# [  5      $
��auto��5
   #   .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��0��6    5      �� 5      6%   �� 5      6%   .+�5      ]� $��0��6   $
��Left=�6(   .+�5       �� -   5         ��Name$ textBoxSearch��5       $	��200��5!      $
��Left=�5"      ��5    1   �� *
SearchText+5"      �� 5#      -   5         ��Name$ buttonSearch��5#      $��Tìm kiếm��6/   $��Right=�5$      $��10,0,0,0q�5%      ��5#   B   �� *SearchCommand+5%      5'      ]� 5(      $��1��6   $��Right=�6)   .+�5)      �� -   5        $ 	buttonAdd��5)      $	��Add��6,   $��	10,0,20,0q�5*      $��26��6$   ��5)   :   �� *
AddCommand+5*   $   5,      5-      � 5/   
   $��1��6   $��5q�6   $��Stretch=�6(   .+�50      �� $
��Auto=�6   .��51      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridCustomers��51         AutoGenerateColumns .     CanUserAddRows .  ��66   �� *List+	 �� SelectedItem	 52      �� *SelectedItem+
 �� Mode$
 OneWayToSource=�   Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6-      Header$  Mã KH��68      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Z   �� *Id+4  .System.Windows.Controls.DataGridTemplateColumn  56      $ Tên khách hàng��61    . $	 150 6[      CellTemplate 57      �� 58   "   .R�59   &   ��  �� Orientation$ 
Horizontal=�61   .+�5:   *   �� $	��150��61   $��25��6=    �� CornerRadius$ 50��6I   $��0 0 10 0q�6[   ._�5;   .   �� $��Center=�6U   $��Center=�6p   ��68   �� *DisplayName+6p   5<   +   5=   '   5>   #   5@        5A      $	 200 6-   $ Địa chỉ��69    6J   �� *	Address+  5B      $	 100 6-   $ Số điện thoại��69    6P   �� *Phone+  5C      $	 120 61    .    HeaderTemplate 5D      �� 5E   "   .R�5F   &   �� $��Chức năng��60   6C   5G   #    5I      �� 5J   "   .R�5K   &   �� $ 
Horizontal=�61   # [  6J   .+�5L   *   �� $ editBtn��6@   $
��Edit��61   ��6Q   �� *EditCommand+��6q   ��  �� ElementName$ editBtn��5M   +   �� 5N   *   $ 	deleteBtn��6B   $��Delete��61   ��6V   �� *DeleteCommand+��6x   �� $ 	deleteBtn��5O   +   5P   '   5Q   #   5S      5U      5V      5W      5X      5Z      