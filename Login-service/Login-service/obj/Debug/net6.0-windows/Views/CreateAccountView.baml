   M S B A M L   `   `   `  ����H  DLogin_Service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Login_service.ViewsLogin_service.Views  5      +    %Login_service.Views.CreateAccountView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -local!clr-namespace:Login_service.Views  5        � 	Resources  5
          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      � .+�5   
   �� $	��450��6   $	��580��6   $��0 0 0 0q�6*    �� Padding$ 25q�6;   $��Center=�5      $��Center=�5      ���#111111  BrushPrimary1#��[ 5      $��3q�5       �� CornerRadius$ 10��5      ._�5$      �  � IsSharedSizeScope$
 True��6    � RowDefinitions 5&      �� 5'      $
��auto �6$   �� 5(      $
��auto �6$   �� 5)      $
��auto �6$   �� 5*      $
��auto �6$   .+�5-      � $��0��6   .+�5.      �� -   5        $��\Logo\close.png��5.        imgClose#��[ 6M   5/      �� 51      $��1��6    
 title1#��[ 52      $��Register a user��53      �� 55      $��2��6    
 title2#��[ 56      $.��(Enter your details to create an account.��57      � 59      $��3��6   $
��0,20q�6$    5:      �� 5;      $
��auto �6(   �� 5<      $
��auto �6(   �� 5=      $
��auto �6(   �� 5>      $
��auto �6(   �� 5?      $
��auto �6(   �� 5@      $
��auto �6(   �� 5A      $
��auto �6(   �� 5B      $
��auto �6(   .+�5E      � $��0��6   $��Center=�6(   $	��0 5q�6E   .+�5F      ��  �� Orientation$ 
Horizontal=�6%   .+�5G      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�66   $��25��6B   $��25��6M   
���<��6Y   �� 5H      $�� ��6&   $
��10 0q�6.   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username��6<   
�������$	��270��5J   &   
������� �� 
CaretBrush
 �����	 �� SelectionBrush
	 �����5M   &   5N      5O      � 5Q      $��1��6   $��Center=�6(   $	��0 5q�6E   .+�5R      �� $ 
Horizontal=�6%   $��5q�6>   .+�5S        $ Email=�66   $��25��6C   $��25��6N   
���<��6Z   �� 5T      $�� ��6&   $
��10 0q�6.   $ E-mail��6<   
�������$	��270��5V   &   
�������
 �����
	 �����5Y   &   5Z      5[      � 5]      $��2��6   $��Center=�6(   $	��0 5q�6E   .+�5^      �� $ 
Horizontal=�6%   $��5q�6>   .+�5_        $ AccountDetails=�66   $��25��6L   $��25��6W   
���<��6c   �� 5`      $�� ��6&   $
��10 0q�6.   $ 
First name��6<   
�������$	��270��5b   &   
�������
 �����
	 �����5e   &   5f      5g      � 5i      $��3��6   $��Center=�6(   $	��0 5q�6E   .+�5j      �� $ 
Horizontal=�6%   $��5q�6>   .+�5k        $ AccountDetails=�66   $��25��6L   $��25��6W   
���<��6c   �� 5l      $�� ��6&   $
��10 0q�6.   $ 	Last name��6<   
�������$	��270��5n   &   
�������
 �����
	 �����5q   &   5r      5s      � 5u      $��4��6   $��Center=�6(   $	��0 5q�6E   .+�5v      �� $ 
Horizontal=�6%   $��5q�6>   .+�5w        $
 Lock=�66   $��25��6B   $��25��6M   
���<��6Y   G� 5x      $
��10 0q�6*   $ Password��68   
�������$	��270��5z   &   
�������
 G� 
CaretBrush

 ����� G� SelectionBrush
 �����5}   &   5~      5      � 5�      $��5��6   $��Center=�6(   $��0 5 0 10q�6E   .+�5�      �� $ 
Horizontal=�6%   $��5q�6>   .+�5�        $
 Lock=�66   $��25��6B   $��25��6M   
���<��6Y   G� 5�      $
��10 0q�6*   $ Confirm Password��68   
�������$	��270��5�   &   
�������

 �����
 �����5�   &   5�      5�      � 5�      $��6��6    � ColumnDefinitions 5�      �� 5�      $��* �6/   �� 5�      $��* �6/   .+�5�      �� $��0��6!   $��	50 10 0 0q�5�   !     Buttons#��[ 5�   !   $��Register��5�   !    �� 	IsDefault$
 True��5�   !   ��5�   !   �� *HomeCommand+5�   !   �� 5�      $��1��6!   $��	0 10 50 0q�5�   !   #��[ 5�   !   $��Go Back��5�   !   ��5�   !   �� *HomeCommand+5�   !   5�      �� 5�      $��7��6    $��0q�6-   $��Center=�5�      $��40��5�      
������� � DataContext 5�      �� *ErrorMessageViewModel+��5�      �� *	Message+y�5�      �� *
HasMessage+ �� 	Converter# [  5�      5�      5�      5�      5�      