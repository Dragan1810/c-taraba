   M S B A M L   `   `   `  ����D  @Domaci_10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Domaci_10	Domaci_10  5          Domaci_10.frmServis   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Domaci_10     5      .��5	      � $��5q�6     � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6"   $��2��62    �� Orientation$ 
Horizontal=�6F   .+�5      �� -   5         ��Name$ btnDodaj��5      $��2q�6>   $	��150��6I   $
��Left=�6U   .��6p   Dodaj5      �� 5      -   5        $ btnIzvestaj��5      $��2q�6D   $	��150��6O   $
��Left=�6[   .��6v   
Izvestaj5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgPrijavas��5      $��0��5      $��1��6#   $��2q�5         AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserResizeRows .  	   CanUserResizeColumns	 .  
   GridLinesVisibility$
 
Horizontal=�5$         HorizontalGridLinesBrush
 �������5&      ��  �� Path$ Servisi� �� SelectedItem 5'      �� $ CurrentServis�   Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   SortMemberPath$ Datum��6%      Header$ Datum Servisa��6<      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6m      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6S   �� *Datum+6w     5+      $ Vlasnik.Ime��6%   $	 Ime��6B   $ * 6o    .  6O   �� *Vlasnik.Ime+6y     5,      $ Vlasnik.Prezime��6%   $ Prezime��6F   $ * 6{    .  6W   �� *Vlasnik.Prezime+6�     5-      $ Vrsta.Naziv��6%   $ Vrsta Servisa��6B   $ * 6y    .  6Y   �� *Vrsta.Naziv+6�   4  .System.Windows.Controls.DataGridTemplateColumn  5.      $  ��6)   $
 Auto 63      CellTemplate 5/      �� 50      .R�51      �� $ 
Horizontal=�6)   $��Right=�6B   .+�52   "   �� $ btnEdit��6)   -   5        $��0q�52   P   ��6[   �� .��6x   	Promeni54   #   �� 56   "   $ 	btnDelete��6)   -   5        $��3 0 0 0q�56   T   ��6e   �� .��6�   	Obriši58   #   59      5:      5<      5>        5@   
   -   5        $ 
dgPredmets��5@      $��1��5A      $��1��6#   $��2q�5B       .   .   .   .  	 .  $
 
Horizontal=�5H      
 �������5J      �� $ Autos� 5K      �� $ CurrentAuto� 5M        5N      $ Naziv��6%   $ 
Naziv Auta��6<   $ * 6j    .  6P   �� *Naziv+6t   5P      5Q      5S      