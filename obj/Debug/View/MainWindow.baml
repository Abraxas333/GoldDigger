   M S B A M L   `   `   `  ����E  AGoldDigger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GoldDigger
GoldDigger  5   	       GoldDigger.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:GoldDigger     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��900��6)    � WindowStartupLocation$ CenterScreen=�5	   	   ���#F3F4F6$��Segoe UI)�5
      ���#333 � 	Resources 5         PrimaryAccentBrush �� Color  SecondaryAccentBrush  HeaderForegroundBrush  
HoverBrush  DGCHeaderStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value  DGStyle&   System.Windows.Controls.DataGrid)  #System.Windows.Controls.DataGridRow �� Triggers P� Property	 P� Value  PrimaryButtonStyle3  -System.Windows.Media.Effects.DropShadowEffect
   
BlurRadius   ShadowDepth   Color �� 
TargetType �� CornerRadius��%�  &	        &	 !     &	 B     &	 c     &	 �     7   7  &	 �    7  7  7  &	 z    7   7   �� 5   
   $ #2196F3��65   �� 5   
   $ #BBDEFB��67   �� 5   
   $ #FFFFFF��68   �� 5   
   $ #E3F2FD��6-   �� 5   
   "  6'   .�5      ��  � ��$ 40��6'   �� 5       � ��8   6+   �� 5       � ��8  6+   �� 5       � ��$ 14(�6)   �� 5       � ��$ Segoe UI SemiBold)�6+   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$	 5,0q�6(   5      �� 5    
   "  6    .�5!      ��  �@ ColumnHeaderStyle8   62   �� 5"       � ��
 �����6+   �� 5#       �@ GridLinesVisibility$ 
Horizontal=�64   �� 5$       �@ RowBackground8  6.   �� 5%        �@ AlternatingRowBackground
 �����69   �� 5&       � �� �#D0D0D06,   �� 5'       � ��$ 1q�60   �� 5(       �@ RowStyle 5)      �� 5*      "  6   .�5+      ��  � ��$ 4q�64   �� 5,       � ��$ 13(�65   �� 5-       � ��$ Segoe UI)�67    5.      P� 50       �@J�IsMouseOver	 . . �51   "   ��  � ��8  6?   52      54      56      57      �� 5:   
   " ��6+   .�5;      ��  � ��8   6+   �� 5<       � ��
 �����6+   �� 5=       � ��$ 14(�6)   �� 5>       � ��$ Segoe UI SemiBold)�6+   �� 5?       � ��$
 10,5q�6(   �� 5@       � ��$ 0q�60   �� 5A       �@�Cursor$
 Hand��6'   �� 5B       � ��$ Center=�64   �� 5C       � ��$ Center=�62   �� 5D       � ��8  6,   �� 5E       �@J�Effect 5F        5G      $
 10Q�6'   $ 1Q�67   $ 	#FFB0B0B0��6G   5I      �� 5J       � �� 5K      �� 5L      " ��6&   .R�5M      �� #��z��6!   $ 5��5N   !   #��z��5O   !   #��z��5P   !   ._�5Q      �� $��Center=�6/   $��Center=�6L   5R      5S      5U       5V      P� 5X       �@J�IsMouseOver	 . . �5Y      ��  � �� �#1976D263   5Z      P� 5[       � ��	 . . �5\      ��  � �� �#1565C063   5]      5_      5`      .��5g   
     -   5          Name$ CustomerGrid��5h       �� AlternationCount$ 2��5j      $��3��5k         CanUserAddRows .    CanUserDeleteRows .    HeadersVisibility$	 All=�5q      #��[ 5r         SelectionUnit$ FullRow=�5s         SelectionMode$ Single=�5t         AutoGenerateColumns .  ��5i      ��    Columns 5x   
   0  *System.Windows.Controls.DataGridTextColumn  5y      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6!      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *Id+6D     5z      $ Surname��6!    62   �� *	Surname+  5{      $ Lastname��6!    63   �� *
Lastname+  5|      $
 City��6!    6/   �� *City+  5}      $ Street��6!    61   �� *Street+  5~      $ No��6!    6-   �� *No+  5      $	 PLZ��6!    6.   �� *PLZ+  5�      $ Email��6!    60   �� *Email+5�      5�      