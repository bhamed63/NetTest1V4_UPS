   M S B A M L   `   `   `  ����I  ENetTest1V4_UPS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:NetTest1V4_UPS.Views.EmployeeViews"NetTest1V4_UPS.Views.EmployeeViews  5      M+clr-namespace:NetTest1V4_UPS.TypeConvertersNetTest1V4_UPS.TypeConverters  5      9    3NetTest1V4_UPS.Views.EmployeeViews.EmployeeListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:NetTest1V4_UPS.Views.EmployeeViews     5      B
converters+clr-namespace:NetTest1V4_UPS.TypeConverters     5        � 	Resources  5      @   :NetTest1V4_UPS.TypeConverters.BooleanToVisibilityConverter "  myBooleanToVisibilityConverter��%   &	          5   
   62   5      .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��0��6   $��5q�6%   $��Employees List��60   $��Center=�6F   $
��Bold"�6c   �� 5      $��1��6    �� Orientation$ 
Horizontal=�6&   .+�5      �� $��5q�6   $��Employee Name��6'   $
��Bold"�6<   �� 5      $��5q�6   $	��200��6U   ��6%   �� *NameSearchKeyWord+ �� Mode$ TwoWay=�6U   �� 5      $��Search��6;   $��25��6L   $	��125��6X   $��5q�6d   ��6   �� *SearchCommand+6d   5      &   System.Windows.Controls.DataGrid  5       $��2��6   $��5q�6$      
IsReadOnly .    AutoGenerateColumns .  ��5!      �� *	Employees+ �� SelectedItem 5"      �� *SelectedEmployee+$ TwoWay=�   Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 200 6P   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 67   �� *Name+6P     5%      $ Email��6)   $		 200 6R   
 68   �� *Email+6R     5&      $ Gender��6)   $		 200 6T   
 69   �� *Gender+6T     5'      $ Status��6)   $		 200 6T   
 69   �� *Status+6T   5)      �� 5+      $��3��6   $ 
Horizontal=�6&   $��Center=�6?   .+�5,      �� $��<��6=   $��25��6L   $��25��6X   $��5q�6c   ��6   �� *PrevPageCommand+6c   �� 5-      $��5q�6   $��25��6N   ��6%   �� *
PageNumber+$ TwoWay=�6N   �� 5.      $��>��6=   $��25��6L   $��25��6X   $��5q�6c   ��6   �� *NextPageCommand+6c   �� 5/      $��Total Items:��6   $��5q�60   $��Center=�6;   �� 50      $��Center=�68   ��6   �� *
TotalItems+68   51      �� 53      $��4��6   $ 
Horizontal=�6&   .+�55      �� $��Create��68   $��25��6I   $	��125��6U   $��5q�6a   ��6   �� *
AddCommand+6a   �� 56      $��Modify��6t   $��25��6�   $	��125��6�   $��5q�6�   ��6   �� *EditCommand+��69   �� *SelectedEmployee+$ TwoWay=�6�   �� 57      $��Remove��6v   $��25��6�   $	��125��6�   $��5q�6�   ��6   �� *DeleteCommand+��6;   �� *SelectedEmployee+$ TwoWay=�6�   �� 58      $��Export To CSV��6v   $��25��6�   $	��125��6�   $��5q�6�   ��6   �� *ExportCommand+��6;   �� *SelectedEmployee+$ TwoWay=�6�   5:      5;      � 5=   
    � IsIndeterminate . $	��150��5>   -   $��50��69   $��Center=�6E   $��Center=�6`   y�5=      �� *IsBusy+ �� 	Converter# [  5>   `   �� 5?   
    J� Opacity$	 0.3Q�6   
�������y�5@      �� *IsBusy+# [  6m   5A      5B      