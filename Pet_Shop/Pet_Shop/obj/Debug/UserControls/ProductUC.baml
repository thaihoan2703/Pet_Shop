   M S B A M L   `   `   `  ����C  ?Pet_Shop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Pet_Shop.UserControlsPet_Shop.UserControls  5      =#clr-namespace:Pet_Shop.UserControlsPet_Shop.UserControls  5      %    Pet_Shop.UserControls.ProductUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Pet_Shop.UserControls     5      2uc#clr-namespace:Pet_Shop.UserControls     5         	ProductVM  � DataContext#  [  5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   5      � 5   
   $��1��6    5      �� 5      $
��auto �6    60   �� 5      $
��auto �6    60   �� 5      6"   .+�5      � $��0��6   $��5q�6    .+�5      � $��0 0 0 10q�6   .+�5      �� $��Tên SP��6    $��Center=�6.   6K   �� 5      -   5         ��Name$ txtDisplayName��5   *   $	��200��6   $��5 5 15 5q�6�   ��6B   �� *DisplayName+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5       $��Tên NSX��6    $��Center=�6/   6L   �� 5!      -   5         ��Name$ 
txtSuplier��5!   ,   $	��100��6   $��5 5 15 5q�6A    �� DisplayMemberPath$ DisplayName��6S    �� 
IsEditable . ��6s   �� *SuplierList+ �� SelectedItem 6�   �� *SelectedSuplier+ �� Mode$ TwoWay=�$ PropertyChanged=�6  �� 5"      $��BarCode��6    $��Center=�6/   6L   �� 5#      -   5        $ 
txtBarCode��5#   +   $	��100��6   $��5 5 15 5q�6~   ��6@   �� *	BarCode+$ PropertyChanged=�6~   5$      5%      � 5'      $��1��6   $��5q�6    .+�5(      � .+�5)      �� -   5        $��Thêm��5)   <   $��5q�6K   $	��100��6V   ��6   �� *
AddCommand+6y   �� 5*      $��Sửa��6=   $��5q�6L   $	��100��6W   ��6   �� *EditCommand+6e   �� 5+      $��Xóa��6?   $��5q�6N   $	��100��6Y   ��6   �� *DeleteCommand+6g   5,      5-      � 5/      $��2��6   $��5q�6    $��Stretch=�6+   .+�50      �� $
��Auto=�6   .��51      �� $	��780��6w   ��6   �� *List+ 6<   �� *SelectedItem+$ OneWayToSource=�	 �� View	 52      �� 53      .P�54   "   �� 
 �� Width$	
 100��61   $��Id��6=    �� DisplayMemberBinding 6I   �� *Id+6o   �� 55   "   $	
 200��61   $��Tên sản phẩm��6=    6S   �� *DisplayName+6�   �� 56   "   $	
 100��61   $��SL tồn��6=    6M   �� *	Inventory+6z   �� 58   "   $	
 100��61   $
��Giá��6=    6J   �� *InputInfoes.OutputPrice+6�   �� 59   "   $	
 170��61   $��Nhà cung cấp��6=    6U   �� *Suplier.DisplayName+6�   �� 5:   "   $	
 100��61   $��BarCode��6=    6N   �� *	BarCode+6y   5;      5=      5>      5?      5@      5A      5B      