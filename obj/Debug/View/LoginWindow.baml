   M S B A M L   `   `   `  ����E  AGoldDigger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:GoldDigger.ViewGoldDigger.View  5   	   !    GoldDigger.View.LoginWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:GoldDigger.View     5   	      BackgroundBrush#��[  5   	     � WindowStartupLocation$  CenterScreen=�5	   	   $��Segoe UI)�5
   	    � Title$ LoginWindow��5   	   $	��450��6   $	��800��6*   .��5      � $��20q�6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��0.5* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��1��6   $��18(�6$   $
��Bold"�62   $	��Top=�6E   $��Center=�6]   	Sign In5      �� 5   
   $��1��6   $��1��6"   $��0,0,0,29q�62   $��2��6D   .+�5       �� $��Username��6     	TextBrush#��[ 6(   $
��Left=�6P   �� 5!      -   5         ��Name$ 
UsernameTb��5!      $��30��6+   $	��150��67   $��Center=�6C   5"      �� 5#   
   $��2��6   $��1��6"   .+�5$      �� $��Password��6   #��[ 6(   $
��Left=�6P   G� 5%      -   5         G�Name$ 
PasswordTb��5%      $��30��6/   $	��150��6;   5&      �� 5'   
   $��3��6   $��1��6"   .+�5(      �� -   5         ��Name$ btnLogin��5(   %   $��Login��6   $��35��5)      $	��100��5*        PrimaryAccentBrush#��[ 5,      5-      �� 5.   
   $��4��6   $��1��6"   .+�5/      �� -   5        $��Close��5/      $	��100��50      $��35��6!     SecondaryAccentBrush#��[ 51      
�������$��14(�52   (   53      �� 55   
   $��4��6   $��1��6"   $��0,59,0,0q�62   $��2��6D   .+�56      �� -   5        $��Register��56      $��20(�6(   
����  �$��Center=�6H   $��Bottom=�6e    � Cursor$
 Hand��6�   6�   57      58      5:      