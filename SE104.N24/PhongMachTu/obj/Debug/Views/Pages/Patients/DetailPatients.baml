   M S B A M L   `   `   `  ����F  BPhongMachTu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:PhongMachTu.Pages.PatientsPhongMachTu.Pages.Patients  5      E    ?PhongMachTu.Controllers.Pages.Patients.DetailPatientsController   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :local(clr-namespace:PhongMachTu.Pages.Patients     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  DetailPatients��5
      .��5      � ���#F1F8FF � RowDefinitions 5   
   �� 5      $	��120 �6   �� 5      �� 5      $	��100 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��859* �6#   �� 5      $��58 �6#   �� 5      $
��294* �6#   .+�5      � $��0��6   .+�5      �� $��120,43,55,0q�5      $��DETAIL��5       $
��Sora)�5!      $��35(�5"      $��DemiBold"�5#      ���#2672E75%      �� 5&      -   5        $��45 0 0 0q�5&      $
��Left=�5(         MaterialDesignIconButton#��[  5)      
�������{�5+      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��5,      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowBack=�6.   
���   �6?   5-      5.      5/      � 52   
   $��1��6   .+�5>      �� $��
70 140 0 0q�6   $��Mã bệnh nhân��6,   $
��Sora)�6@   $��18(�6R   $��DemiBold"�6`   ���#9697956�   �� 5?      $��280 130 0 0q�6    �� CornerRadius$ 5��6*   $��1q�6;   ���#2672E7$��50��6e   $	��170��6q   $
��Left=�6}   $	��Top=�6�   ._�5@      �� -   5         ��Name$ txt_MaBN��5@       �� Padding$ 0 12 0 0q�6.   $��50��6A   $	��150��6M   $
��Sora)�6Y   $��20(�6k   $��DemiBold"�6y   ���#9697956�   5A      �� 5C      $��480 140 0 0q�6   $��	Họ tên��6-   $
��Sora)�6;   $��18(�6M   $��DemiBold"�6[   ���#9697956�   �� 5D      $��580 130 0 0q�6   $ 5��6*   $��1q�6;   ���#2672E7$��50��6e   $	��500��6q   $
��Left=�6}   $	��Top=�6�   ._�5E      �� -   5        	 ��Name$	 txt_FullName��5E      $��0 12 0 0q�60   $��50��6C   $	��480��6O   $
��Sora)�6[   $��20(�6m   $��DemiBold"�6{   ���#9697956�   5F      �� 5H      $��
70 240 0 0q�6   $��
Ngày sinh��6,   $
��Sora)�6=   $��18(�6O   $��DemiBold"�6]   ���#9697956�   �� 5I      $��280 230 0 0q�6   $ 5��6*   $��1q�6;   ���#2672E7$��50��6e   $	��220��6q   $
��Left=�6}   $	��Top=�6�   ._�5J      (  "System.Windows.Controls.DatePicker  -   5        
  Name$
 txt_Birthday��5J      $��0 0 0 0q�63   $��50��6E   $	��200��6Q   $
��Sora)�6]   $��20(�6o   $��DemiBold"�6}   ���#9697956�   5K      �� 5M      $��530 240 0 0q�6   $��Giới tính��6-   $
��Sora)�6>   $��18(�6P   $��DemiBold"�6^   ���#9697956�   �� 5N      $��650 230 0 0q�6   $ 5��6*   $��1q�6;   ���#2672E7$��50��6e   $	��220��6q   $
��Left=�6}   $	��Top=�6�   ._�5O      �� -   5        $	 txt_GioiTinh��5O      $��0 12 0 0q�60   $��50��6C   $	��200��6O   $
��Sora)�6[   $��20(�6m   $��DemiBold"�6{   ���#9697956�   5P      �� 5S      $��
70 340 0 0q�6   $��Thông tin liên lạc��6,   $
��Sora)�6F   $��18(�6X   $��DemiBold"�6f   ���#9697956�   �� 5T      $��280 330 0 0q�6   $ 5��6*   $��1q�6;   ���#2672E7$��50��6e   $	��800��6q   $
��Left=�6}   $	��Top=�6�   ._�5U      �� -   5        $	 txt_SDT��5U      $��0 12 0 0q�6+   $��50��6>   $	��790��6J   $
��Sora)�6V   $��20(�6h   $��DemiBold"�6v   ���#9697956�   5V      �� 5Y      $��
70 440 0 0q�6   $��Địa chỉ��6,   $
��Sora)�6;   $��18(�6M   $��DemiBold"�6[   ���#9697956�   �� 5Z      $��280 430 0 0q�6   $ 5��6*   $��1q�6;   ���#2672E7$��50��6e   $	��800��6q   $
��Left=�6}   $	��Top=�6�   ._�5[      �� -   5        $	 
txt_DiaChi��5[      $��0 12 0 0q�6.   $��50��6A   $	��790��6M   $
��Sora)�6Y   $��20(�6k   $��DemiBold"�6y   ���#9697956�   5\      5c      � 5h   
   $��3��6    5i      �� 5j      �� 5k      .+�5m      �� -   5        $��0��5n      $��Right=�5o      $��20q�5p      $
��Save��5r      $	��200��5s      $��50��5t      $��24(�5u      6!   �� 5v      -	   5        $��1��5w      $
��Left=�5x      $��20q�5y      $��Delete��5{      $	��200��5|      $��50��5}      $��24(�5~      6!   5      5�      5�      