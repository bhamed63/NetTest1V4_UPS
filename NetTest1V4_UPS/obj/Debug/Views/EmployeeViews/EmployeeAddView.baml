   M S B A M L   `   `   `  ����I  ENetTest1V4_UPS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:NetTest1V4_UPS.Views.EmployeeViews"NetTest1V4_UPS.Views.EmployeeViews  5   	   M+clr-namespace:NetTest1V4_UPS.TypeConvertersNetTest1V4_UPS.TypeConverters  5   	   8    2NetTest1V4_UPS.Views.EmployeeViews.EmployeeAddView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Blocal0clr-namespace:NetTest1V4_UPS.Views.EmployeeViews     5   	   B
converters+clr-namespace:NetTest1V4_UPS.TypeConverters     5   	     � Title$  EmployeeAddView��5	   	   $	��250��6!   $	��400��6.    � 	Resources 5      ;   5NetTest1V4_UPS.TypeConverters.BooleanReverseConverter   myBooleanReverseConverter@   :NetTest1V4_UPS.TypeConverters.BooleanToVisibilityConverter " myBooleanToVisibilityConverter��%:   &	        &	        5   
   6-     5   
   62   5      .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $��* �6    �� 5      $
��auto �6     � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   .+�5       �� $��0��6   $��0��6%   $��5q�65   $��Name:��6@   $
��Left=�6M   �� 5!      $��0��6   $��1��6#   $��5q�63   $��Stretch=�6g   ��6>   �� *
Model.Name+ �� Mode$ TwoWay=�6g   �� 5#      $��1��6   $��0��6%   $��5q�65   $��Email:��6@   $
��Left=�6N   �� 5$      $��1��6   $��1��6#   $��5q�63   $��Stretch=�6h   ��6>   �� *Model.Email+$ TwoWay=�6h   �� 5&      $��2��6   $��0��6%   $��5q�65   $��Gender:��6@   $
��Left=�6O   �� 5'      $��2��6   $��1��6&    �� Orientation$ 
Horizontal=�66   .+�5(      	�  	� 	GroupName$ 
genderName��6   $
��Male��65   $��5q�6D    d� 	IsChecked 6O   �� *IsMale+$ TwoWay=�	� 5)      $ 
genderName��6   $��Female��65   $��5q�6F    6Q   �� *IsMale+$ TwoWay=� �� 	Converter# [  5*      �� 5,      $��3��6   $��0��6%   $��5q�65   $��State:��6@   $
��Left=�6N   �� 5-      $��3��6   $��1��6&   $ 
Horizontal=�66   .+�5.      	� $ 
statusName��6   $��Active��65   $��5q�6F    6Q   �� *
IsActive+$ TwoWay=�	� 5/      $ 
statusName��6   $��Inactive��65   $��5q�6H    6S   �� *
IsActive+$ TwoWay=�# [  50      �� 52      $��5��6   $��0��6&   $��2��66   $��5q�6J   $ 
Horizontal=�6U   $��Right=�6n   .+�53      �� $��Cancel��6;   $��25��6L   $��75��6X   $��5q�6c   ��6   �� *CancelCommand+6c   �� 54      $
��Save��69   $��25��6H   $��75��6T   $��5q�6_   ��6   �� *SaveCommand+6_   55      57      � 59   
   	 � IsIndeterminate	 . $	��150��5:   -   $��50��69   $��Center=�6E   $��Center=�6`   y�59      �� *IsBusy+# [ 5:   `   �� 5;   
   
 J� Opacity$	
 0.3Q�6   
�������y�5<      �� *IsBusy+# [ 6m   5>      5?      