   M S B A M L   `   `   `  ����  BatteryAgent    BatteryAgent.wpfMain   5   	   W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      -   5          � Topmost  .  � Icon$ battery.ico��5   K    � Title$ wpfMain��5      |�.   J� Opacity$ 0Q�6'   $	��300��63   $	��300��6@    � WindowStyle$
 None=�6b    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�6�    � ShowInTaskbar .  ��6L   Z�  � 	Resources 5      ��%    5      	 � Triggers	 5      .��5	      � .+�5
      �� -   5        $��Critical��5
      $��critical.png��6   $
��Fill=�63   �� 5      -   5        $
��Safe��5      $��safe.png��6   $
��Fill=�6+   r� 5   
   -   5        $��media��5   "   
 r� Volume$
 1Q�6    r� Source$0 *C:\Users\Karan\AppData\Roaming\battery.mp3?�6/    r� UnloadedBehavior$ Manual=�6c    r� LoadedBehavior$ Manual=�6}   5      5      5      