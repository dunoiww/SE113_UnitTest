   M S B A M L   `   `   `  ����F  BPhongMachTu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:PhongMachTu.LoginPagesPhongMachTu.LoginPages  5      @    :PhongMachTu.Controllers.LoginPages.MainLoginPageController   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      0local$clr-namespace:PhongMachTu.LoginPages  5        N� Title$  MainLoginPage��5
      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   ���#6383FA._�5      �� $��/Resources/LoginImg.png��6   $��Uniform=�65   6I   5      � 5   
   $��1��6    � RowDefinitions 5      �� 5      $	��150 �6    �� 5      $	��150 �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5       $��* �6    .+�5#      �� $��0��6   $��/Resources/logo.png��5$      $��Center=�5%      $	��Top=�5&      $��0,0,0,0q�5'      $	��120��5(      $	��120��6!   �� 5*      $��1��6   $��Hello! Welcome Back��5+      $��Center=�5,      $��38(�5-      $��SemiBold"�5.      
���   �5/      �� 52      -   5         ��Name$ txtUserName��53      $��3��54      $��0,0,0,0q�55      $��60��56      $��15(�57      $	��550��58       !  MaterialDesignOutlinedTextBox#��[  59      $	��Top=�5:      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ UserName��5;      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .    
HelperText$ Enter your UserName��5=      .��5?      5@      �� 5A      $��5��6   $��	0,50,0,25q�5B      $
��Auto��5C      $	��550��5D      .+�5F      G� -   5         G�Name$ txtPassWord��5G       + 'MaterialDesignOutlinedRevealPasswordBox#��[ 5H      $ Password��5J      $��60��5K      $��15(�5L       . $ Enter your password��5N      {�5I      ��  �� ElementName$# RevealPasswordOutlinedEnabled��	 �� Path$	 	IsChecked�5O      5P      �� 5R      -   5        
 ��Name$
 btnLogin��5S      $��6��5R      $��Login��5T      $��0,25,0,0q�5U      ���#6788FF
�������$��50��5X      $	��150��6!   $��18(�5Y      $	��Top=�6$   6<   �� 5[      -   5        $
 	btnForgot��5\      $��7��5[      $��Forgot��5]      $��0,20,0,0q�5^      ���#6788FF
�������$��50��5a      $	��150��6!   $��18(�5b      $	��Top=�6#   $��Center=�5c      62   5d      5f      5g      