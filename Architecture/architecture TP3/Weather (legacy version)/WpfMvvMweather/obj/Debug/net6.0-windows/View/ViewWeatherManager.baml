   M S B A M L   `   `   `  ����I  EWpfMvvMweather, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WpfMvvMweather.ViewWpfMvvMweather.View  5   	   C&clr-namespace:WpfMvvMweather.ViewModelWpfMvvMweather.ViewModel  5   	   /clr-namespace:Ritege.HelpersRitege.Helpers  5   	   ,    &WpfMvvMweather.View.ViewWeatherManager   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WpfMvvMweather.View     5   	   <	ViewModel&clr-namespace:WpfMvvMweather.ViewModel     5   	   /helperclr-namespace:Ritege.Helpers     5   	     � Title$  ViewWeatherManager��5
   	   $	��450��6$   $	��800��61    � 	Resources 5          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��30,10q�6,   .+�5      �� $��Has Temperature��6L   $
��Left=�6f   $	��Top=�6�    d� 	IsChecked 6   �� * VMWeatherConfig.HasTemperature+6�   �� 5      $��Has Wind��6E   $
��Left=�6X   $	��Top=�6s    6   �� *VMWeatherConfig.HasWind+6s   �� 5      $��Has Precipitation��6N   $
��Left=�6j   $	��Top=�6�    6   �� *" VMWeatherConfig.HasPrecipitation+6�   �� 5      $��Has Pression��6I   $
��Left=�6`   $	��Top=�6|    6   �� *VMWeatherConfig.HasPression+6|   5      �� 5   
   $ 
Horizontal=�6   $��1��6.   .+�5      �� $��Start��6   $	��200��6C   $��50��6O   $��10q�6[   ��6%   �� *
StartCmd+6[   �� 5      $
��Stop��6   $	��200��6A   $��50��6M   $��10q�6Y   ��6$   �� *	StopCmd+6Y   5      �� 5   
   $ 
Horizontal=�6   $��2��6.   .+�5      �� $
��Auto=�6   $��Disabled=�6>   $	��110��6g   '   !Ritege.Helpers.AutoScrollBehavior   
AutoScroll$
 True��6t   .��5       �� $
��Auto��6@   ��6   �� *WeatherInfos+��5!      �� 5"       �� DataType,   &WpfMvvMweather.ViewModel.VMWeatherInfo"  6(   .R�5#      �� $ Vertical=�6)   .+�5$   "   �� $ 
Horizontal=�6-   y�6F   �� *.,DataContext.VMWeatherConfig.HasPrecipitation+ �� RelativeSource ��  �� Mode$ FindAncestor=�	 �� AncestorType"	 �
 �� 	Converter#
 [  .+�5%   &   �� $��Précipitation��60   �� 5&   &   $	��5,0q�6P   ��61   �� *Precipitation+6P   5'   #   �� 5(   "   $ 
Horizontal=�6-   y�6F   �� *%#DataContext.VMWeatherConfig.HasWind+ �� $ FindAncestor=�"	 �#
 [  .+�5)   &   �� $
��Wind��60   �� 5*   &   $	��5,0q�6G   ��61   �� *Wind+6G   5+   #   �� 5,   "   $ 
Horizontal=�6-   y�6F   �� *)'DataContext.VMWeatherConfig.HasPression+ �� $ FindAncestor=�"	 �#
 [  .+�5-   &   �� $��Pression��60   �� 5.   &   $	��5,0q�6K   ��61   �� *
Pression+6K   5/   #   �� 50   "   $ 
Horizontal=�6-   y�6F   �� *,*DataContext.VMWeatherConfig.HasTemperature+ �� $ FindAncestor=�"	 �#
 [  .+�51   &   �� $��Temperature��60   �� 52   &   $	��5,0q�6N   ��61   �� *Temperature+6N   53   #   54      56      58      59      5<      5=      5>      