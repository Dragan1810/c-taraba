   M S B A M L   `   `   `  ����D  @Domaci_10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Domaci_10	Domaci_10  5          Domaci_10.frmMehanicari   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Domaci_10     5      .��5	      � $��5q�6     � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� -   5         ��Name$ btnDodaj��5      $��2q�6>   $	��150��6I   $
��Left=�6U   .��6p   Dodaj5      �� 5      -   5        $ btnDodajJSON��5      $��2q�6F   $	��150��6Q   $
��Left=�6]   .��6x   JSON5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgProfesors��5      $��1��5      $��2q�5         AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserResizeRows .     CanUserResizeColumns .  	   GridLinesVisibility$	 
Horizontal=�5       
   HorizontalGridLinesBrush

 �������5"      ��  �� Path$ 
Mehanicari� �� SelectedItem 5#      �� $ CurrentMehanicar�   Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   SortMemberPath$	 Ime��6%      Header$	 Ime��6:      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6_      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *Ime+6i     5'      $ Prezime��6%   $ Prezime��6>   $ * 6k    .  6O   �� *	Prezime+6u   4  .System.Windows.Controls.DataGridTemplateColumn  5(      $  ��6)   $
 Auto 63      CellTemplate 5)      �� 5*      .R�5+      �� $ 
Horizontal=�6)   $��Right=�6B   .+�5,   "   �� $ btnEdit��6)   -   5        $��0q�5,   P   ��6[   �� .��6x   	Promeni5.   #   �� 50   "   $ 	btnDelete��6)   -   5        $��3 0 0 0q�50   T   ��6e   �� .��6�   	Obriši52   #   53      54      56      58      59      5;      