   M S B A M L   `   `   `  ����D  @Domaci_10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Domaci_10	Domaci_10  5   	       Domaci_10.ServisAddEdit   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Domaci_10     5   	     � Title$  ServisAddEdit��5   	   $	��450��6   $	��800��6,   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6!   $��2q�61   $��Datum servisa: ��6<   (  "System.Windows.Controls.DatePicker  5   
   $��0��6   $��1��6"   $��2q�62      SelectedDate 6=   ��  �� Path$ CurrentServis.Datum� �� Mode$ TwoWay=��� 5   
   $��1��6   $��0��6!   $��2q�61   $��	Vlasnik: ��6<   �� 5   
   $��1��6   $��1��6    $��2q�60    �� DisplayMemberPath$	 Ime��5      ��5      �� *VlasniciFromDB+ �� SelectedItem 5      �� *CurrentServis.Vlasnik+$ TwoWay=�5      �� 5   
   $��2��6   $��0��6!   $��2q�61   $��Vrsta: ��6<   �� 5    
   $��2��6   $��1��6    $��2q�60   $ Naziv��5#      ��5!      �� *VrsteFromDB+ 5"      �� *CurrentServis.Vrsta+$ TwoWay=�5#      &   System.Windows.Controls.DataGrid  5&   
   -   5          Name$ 
dgPredmets��5&      $��1��5'      $��3��6#   $��2q�5(      	   AutoGenerateColumns	 .  
   CanUserAddRows
 .     CanUserDeleteRows .     CanUserResizeRows .     CanUserResizeColumns .     GridLinesVisibility$ 
Horizontal=�5.         HorizontalGridLinesBrush
 �������50      �� $ Autos� 51      �� $ CurrentAuto�   Columns 53      4  .System.Windows.Controls.DataGridCheckBoxColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$  ��6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *
Selektovan+$ TwoWay=�6U   0  *System.Windows.Controls.DataGridTextColumn  55         SortMemberPath$ Naziv��6%   $ 
Naziv Auta��6<      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6j      
IsReadOnly .  6P   �� *Naziv+6t   57      �� 5:   
   -   5         ��Name$ btnSave��5:   9   $��5��6   $��0��6   $��2q�6.   .��6`   
Sačuvaj5<      �� 5>   
   -   5        $ 	btnCancel��5>   9   $��5��6   $��1��6   $��2q�6.   .��6d   
Odustani5@      5A      5C      