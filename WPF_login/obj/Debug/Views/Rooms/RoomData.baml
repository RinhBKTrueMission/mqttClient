   M S B A M L   `   `   `  ����D  @WPF_login, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WPF_login.Views.RoomsWPF_login.Views.Rooms  5      b ^Syncfusion.SfGauge.WPF, Version=20.1460.0.61, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89eGclr-namespace:Syncfusion.UI.Xaml.Gauges;assembly=Syncfusion.SfGauge.WpfSyncfusion.UI.Xaml.Gauges 5      h dSyncfusion.SfProgressBar.WPF, Version=20.1460.0.61, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89uRclr-namespace:Syncfusion.UI.Xaml.ProgressBar;assembly=Syncfusion.SfProgressBar.WpfSyncfusion.UI.Xaml.ProgressBar 5      b ^Syncfusion.SfChart.WPF, Version=20.1460.0.61, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89eGclr-namespace:Syncfusion.UI.Xaml.Charts;assembly=Syncfusion.SfChart.WPFSyncfusion.UI.Xaml.Charts 5
      $    WPF_login.Views.Rooms.RoomData   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:WPF_login.Views.Rooms     5      YgaugeGclr-namespace:Syncfusion.UI.Xaml.Gauges;assembly=Syncfusion.SfGauge.Wpf     5      i
SyncfusionRclr-namespace:Syncfusion.UI.Xaml.ProgressBar;assembly=Syncfusion.SfProgressBar.Wpf     5      ^
syncfusionGclr-namespace:Syncfusion.UI.Xaml.Charts;assembly=Syncfusion.SfChart.WPF     5
        N� Title$  RoomData��5      .��5      ��  �� CornerRadius$ 5��6   ���#52B2BF._�5   
   �  � ColumnDefinitions 5      �� 5      �� 5      �� 5       � RowDefinitions 5      �� 5      �� 5      �� 5      .+�5      �� $��5q�6   
���   �$��0��63   $��0��6@   ._�5      �  5      �� 5      $��1* �6(   �� 5      $��6* �6(   .+�5       �� ���#016064$��0��62   $��0��6B   ._�5!      �� $��20 0 0 0q�6    
�������$
��Bold"�6E   $��Times New Roman)�6W   .��6t   Khả năng cháy6�   5"      �� 5#      
�������$��0��60   $��1��6@   ._�5$      � -   5         �Name$
 box1��5$       5%      �� 5&   "   $��3* �63   �� 5'   "   $��4* �63   .+�5)      �� $��0��6%   $��0��65   $��2q�6B   ._�5*   "   �� $��image/ai.png��6(   5+      �� 5,      $��1��6%   $��1��65   ._�5-   "   �� -   5         ��Name$ report��5-   (   $
��Bold"�68   $��Center=�6J   $��Times New Roman )�6e   $��20(�6�   6�   5.      5/      50      51      52      �� 53      $��5q�6   
���   �$��0��64   $��1��6A   ._�54      �  55      �� 56      $��1* �6(   �� 57      $��6* �6(   .+�59      �� ���#016064$��0��62   $��0��6B   ._�5:      �� $��20 0 0 0q�6    
�������$
��Bold"�6E   $��Times New Roman)�6W   .��6t   Nhiệt độ phòng6�   5;      �� 5<      
�������$��0��60   $��1��6@   ._�5B      /  )Syncfusion.UI.Xaml.Gauges.SfCircularGauge     Scales 5D   "   -  'Syncfusion.UI.Xaml.Gauges.CircularScale     
StartValue$ 0Q�66      EndValue$	 120Q�6E   	   Interval$	 10Q�6T   
   MinorTicksPerInterval$
 9��6b      LabelStroke �#5b5b5b   RangePosition$ Custom=�5E   &      TickPosition$ Custom=�6=      LabelPosition$ Custom=�6S      ShowRim .     LabelOffset$	 0.6Q�6z      MajorTickSettings 5F   &   0  *Syncfusion.UI.Xaml.Gauges.MajorTickSetting  5G   *   +  %Syncfusion.UI.Xaml.Gauges.TickSetting   StartOffset$
 0.85Q�6A      	EndOffset$
 0.65Q�6T      StrokeThickness$ 1Q�6e      Stroke
 �   �6y      MinorTickSettings 5I   &   0  *Syncfusion.UI.Xaml.Gauges.MinorTickSetting  5J   *   $
 0.85Q�6A   $
 0.75Q�6T   $ 1Q�6e   
 �   �6y      Ranges 5M   *   -  'Syncfusion.UI.Xaml.Gauges.CircularRange     OuterStartOffset$
 0.85Q�6>      OuterEndOffset$
 0.85Q�6V      InnerStartOffset$
 0.65Q�5N         InnerEndOffset$
 0.65Q�6+      
StartValue$	 -50Q�6A      EndValue$	 -10Q�6R      Stroke �#4f91fa6a     5O   *   $
 0.85Q�6>   $
 0.85Q�6V   $
 0.65Q�5P      $
 0.65Q�6   $	 -10Q�6/   $ 5Q�6@    �#28bce46M     5Q   *   $
 0.85Q�6>   $
 0.85Q�6V   $
 0.65Q�5R      $
 0.65Q�6*   $ 5Q�6@   $ 20Q�6O    �#0bbe536]     5S   *   $
 0.85Q�6>   $
 0.85Q�6V   $
 0.65Q�5T      $
 0.65Q�6*   $ 20Q�6@   $ 30Q�6P    �#d4d4596^     5U   *   $
 0.85Q�6>   $
 0.85Q�6V   $
 0.65Q�5V      $
 0.65Q�6*   $ 30Q�6@   $ 60Q�6P    �#ff32336^      Pointers 5Z   *   /  )Syncfusion.UI.Xaml.Gauges.CircularPointer      EnableAnimation  . !   NeedleLengthFactor$
! 0.77Q�6|   "   NeedlePointerStroke" �#f7ab9c##   NeedlePointerStrokeThickness$# 12Q�6�   $   TailLengthFactor$
$ 0.15Q�6�   %   TailFill% �#f7ab9c&   KnobRadiusFactor$
& 0.08Q�6  '   
KnobStroke' �#eff2f1(   KnobStrokeThickness$( 5Q�6.  )   KnobFill) �#e8e8e8*   NeedlePointerType$* Triangle=�6Y  +   Value+ 6W   �� *sum.nhiet_do.value+6Y  5\   #   ,   Annotations, 5`   "   /  )Syncfusion.UI.Xaml.Gauges.GaugeAnnotation  -   Angle$- 90Q�68   .   Offset$	. 0.5Q�6C   ��5a   &   �� 5b   *   ���#6f6d6d$��2q�6G   ���#babab2$ 3��6p   ._�5c   .   �� -   5        / ��Name$
/ text��5c   8   ���#403f3d$��14(�6�   $
��Bold"�6�   $��	10,1,10,1q�6�   ��6F   �� *sum.nhiet_do.value+6�   5d   +   5f   #     5g   "   $- 90Q�68   $	. 0.3Q�6C   ��5h   &   �� 5i   *   $��12(�64   $��	Temp. °C��6B   ���#9b9b9b$��SemiBold"�6g   5k   #   5n      5q      5r      5s      �� 5t      $��5q�6   
���   �$��0��65   $��2��6B   ._�5u      �  5v      �� 5w      $��1* �6(   �� 5x      $��6* �6(   .+�5z      �� ���#016064$��0��62   $��0��6B   ._�5{      �� $��20 0 0 0q�6    
�������$
��Bold"�6E   $��Times New Roman)�6W   .��6t   
Độ ẩm6{   5|      �� 5}      
�������$��0��61   $��1��6A   ._�5�      :	  4Syncfusion.UI.Xaml.ProgressBar.SfCircularProgressBar	  4
  .Syncfusion.UI.Xaml.ProgressBar.ProgressBarBase0 
  Progress0 6<   �� *sum.do_am.value+1 	  ProgressContent1 5�      �� 5�   "   .+�5�   &   �� 2 �� TextAlignment$2 Center=�6f   ��60   �� *sum.do_am.value+3 �� StringFormat$
3 {0}%��6f   �� 5�   &   $	��Hum��60   5�   #   5�      5�      5�      5�      �� 5�      $��5q�6   
���   �$��1��65   $��2��6B   ._�5�      �  5�      �� 5�      $��1* �6(   �� 5�      $��6* �6(   .+�5�      �� ���#016064$��0��62   $��0��6B   ._�5�      �� $��20 0 0 0q�6    
�������$
��Bold"�6E   $��Times New Roman)�6W   .��6t   Gas6y   5�      �� 5�      
�������$��0��60   $��1��6@   ._�5�      �� $��82(�6$   $��20 0 0 0q�62   ���#50C75D�� 5�       �6$   �� *sum.gas.value+ �� 5�   !   $��50(�6%   $
�.ppm��63   5�      5�      5�      5�      �� 5�      $��5q�6   
���   �$��1��65   $��0��6B   $��2��6R   ._�5�      �  5�      �� 5�      $��1* �6(   �� 5�      $��6* �6(   .+�5�      �� ���#016064$��0��62   $��0��6B   ._�5�      �� $��20 0 0 0q�6    
�������$
��Bold"�6E   $��Times New Roman)�6W   .��6t   (&Biểu đồ nhiệt độ, độ ẩm6�   5�      �� 5�      
�������$��0��60   $��1��6@   ._�5�      '  !Syncfusion.UI.Xaml.Charts.SfChart  $��0,0,10,0q�6-   )  #Syncfusion.UI.Xaml.Charts.ChartBase4   Legend4 5�      +  %Syncfusion.UI.Xaml.Charts.ChartLegend  5�   "   5   Series.5 5�      2  ,Syncfusion.UI.Xaml.Charts.StackingLineSeries  /  )Syncfusion.UI.Xaml.Charts.ChartSeriesBase6   ShowTooltip6 . 7   Label$7 Nhiệt độ��6q   8   XBindingPath$
8 Time��6�   ,  &Syncfusion.UI.Xaml.Charts.XyDataSeries9   YBindingPath$9 value��6�   :   Interior: �#C75052$��0,0,18,0q�6�   ;   ItemsSource; 6<   �� *
nhiet_do+6�     5�      6 . $7 
Độ ẩm��6m   $
8 Time��6|   $9 value��6�   : �#505FC7$��0,0,18,0q�6�   ; 6<   �� *do_am+6�   5�      5�      5�      5�      �� 5�      $��5q�6   
���   �$��2��64   $��0��6A   $��2��6Q   ._�5�      �  5�      �� 5�      $��1* �6(   �� 5�      $��6* �6(   .+�5�      �� ���#016064$��0��62   $��0��6B   ._�5�      �� $��20 0 0 0q�6    
�������$
��Bold"�6E   $��Times New Roman)�6W   .��6t   .,Biểu đồ nồng độ khói và khí gas6�   5�      �� 5�      
�������$��0��60   $��1��6@   ._�5�        $��0,0,10,0q�6-   4 5�        5�   "   .5 5�        6 . $7 Khói��6m   $
8 Time��6|   $9 value��6�   : �#C3C750$��0,0,10,0q�6�   ; 6<   �� *khoi+6�     5�      6 . $	7 Gas��6k   $
8 Time��6w   $9 value��6�   : �#50C75D$��0,0,10,0q�6�   ; 6<   �� *gas+6�   5�      5�      5�      5�      �� 5�      $��5q�6   
���   �$��2��64   $��2��6A   ._�5�      �  5�      �� 5�      $��1* �6(   �� 5�      $��6* �6(   .+�5�      �� ���#016064$��0��62   $��0��6B   ._�5�      �� $��20 0 0 0q�6    
�������$
��Bold"�6E   $��Times New Roman)�6W   .��6t   Khói6z   5�      �� 5�      
�������$��0��60   $��1��6@   ._�5�      �� $��82(�6$   $��20 0 0 0q�62   ���#C3C750�� 5�       -   5        < ��Name$< txt_khoi��5�   $   �66   �� *sum.khoi.value+ �� 5�   !   $��50(�6%   $
�.ppm��63   5�      5�      5�      5�      5�      5�      5�      