   M S B A M L   `   `   `  ����J  FPasswordBoxMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null`Aclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVMPasswordBoxMVVM.Components  5      H DLogin_Service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Login_service.ViewsLogin_service.Views 5      #   Login_service.Views.LoginView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      Q	componentAclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVM  5      -local!clr-namespace:Login_service.Views  5      
������ .��5      � .+�5   
   �� $	��450��6   $	��580��6   $��0 0 0 0q�6*     �� Padding$  25q�6;   $��Center=�5      $��Center=�5      ���#111111   BrushPrimary1#��[  5      $��3q�5       �� CornerRadius$ 10��5      5      �� 5   
   -   5        $��\Logo\close.png��5        imgCloseLogin#��[ 6A   �� 5   
   $	��350��6   $	��350��6!   $��Center=�6.   $��Center=�6I   $��0 0 0 60q�6f   .+�5      �� $��20 40q�6   $	��300��6(   .+�5      �� $��
User Login��6   $��20q�6.   
������� �� TextAlignment$ Center=�6M   $��38(�6d   $��Lucida Console)�6r   �� 5       �� Orientation$ 
Horizontal=�6   $��10q�66   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 User=�6.   $��25��6:   $��25��6E   
���<��6Q   �� 5      $
��10 0q�6]   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter Username / Email��6k   
�������$	��250��6�   
������� �� 
CaretBrush
 ����� �� SelectionBrush
 �������6   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5      �� 5       $ 
Horizontal=�6   $��10q�66   .+�5!        $
 Lock=�6.   $��25��6:   $��25��6E   $��	0 0 10 0 q�6Q   
���<��6d   4   .PasswordBoxMVVM.Components.BindablePasswordBox  5"      $ ********��6R   
�������$	��250��6�   
�������	   Password	 64   �� *
Password+6�   5#      �� 5$      $��10q�6   $��Center=�6)   5&      � 5'      
 � ColumnDefinitions
 5(      �� 5)      $��* �6+   �� 5*      $��* �6+   .+�5-      � $��0��6   $��20 0 0 0q�6+   .+�5.      ��  �� 	IsDefault$
 True��6!     Buttons#��[ 50   !    � ToolTip$ Login��51   !   $��Login��52   !   ��5/   !   �� *LoginCommand+53      54      � 56      $��1��6   $��0 0 20 0q�6+   .+�57      �� #��[ 58   !   $ Register��59   !   $��Register��5:   !   ��57   !   �� *ViewRegisterCommand+5;      5<      5>      � 5?      $��50��6   $
��0 15q�6#   .+�5@      �� $��4��6    $��0,10,0,0q�6-   $��Center=�5A      
���<�� � DataContext 5B      �� *ErrorMessageViewModel+��5D      �� *	Message+y�5E      �� *
HasMessage+   BooleanToVisibilityConverter �� 	Converter# [ 5F      5H      5K      5N      5O      