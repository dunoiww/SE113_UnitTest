   M S B A M L   `   `   `  ����F  BPhongMachTu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:PhongMachTu.Pages.StatisticsPhongMachTu.Pages.Statistics  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5	      E    ?PhongMachTu.Controllers.Pages.Statistics.DoanhThuPageController   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      6local*clr-namespace:PhongMachTu.Pages.Statistics  5      >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5	        N� Title$  DoanhThuPage��5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��80 �6   �� 5      $��* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $	��150 �6#   �� 5      $��* �6#   .+�5      �� -   5         ��Name$ 
backButton��5      $��50,0,0,0q�5      $
��Left=�5      $��Center=�5         MaterialDesignIconButton#��[  5      
�������.��5       '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 	ArrowBack=�6*   
���   �6;   5!      �� 5"      $��Biểu đồ Doanh Thu��6   $��DemiBold"�5#      $��Center=�5$      $
��Left=�5%      $��1��5&      $��50,0,0,0q�5'      $��20(�5(      5)      � 5*   
   $��1��6   $��Center=�6    5+      �� 5,      $	��300 �6#   �� 5-      $	��300 �6#   �� 5.      $	��100 �6#   �� 5/      $��* �6#   .+�51      ��  �� Orientation$ 
Horizontal=�6   $��0��62   .+�52      �� $��Từ ngày: ��6   $��Center=�6-   $��0,0,10,0q�6H   (  "System.Windows.Controls.DatePicker  53      -   5          Name$ 	dtpTuNgay��53      $	��120��60   54      �� 55      $ 
Horizontal=�6   $��1��62   .+�56      �� $��Đến ngày: ��6   $��Center=�6.   $��0,0,10,0q�6I     57      -   5        $ 
dtpDenNgay��57      $	��120��61   58      �� 59      -   5        $ 
btnTimKiem��59      $��2��5:      $��Tìm kiếm��5;      5<      �� 5>      -   5        $ btnPDF��5>      $��3��5?      $��	100,0,0,0q�5@      $��
Xuất PDF��5A      
��� ���
��� E��5D      5F      #  LiveCharts.Wpf.CartesianChart  5G   
   -   5          Name$ chartDoanhThu��5G      $��2��5H      
�������&   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�5J      $��0 0 0 0q�5K      $	��500��5L      $
��1000��5M      	   Series	 5N      �� *SeriesCollection+
   AxisX
 5P        LiveCharts.Wpf.Axis     Title$ Tháng��6      Labels 6)   �� *Labels+   AxisY 5S        $ 	Doanh thu��6      LabelFormatter 6-   �� *
YFormatter+5U      5V      5W      