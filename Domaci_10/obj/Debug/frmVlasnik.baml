   M S B A M L   `   `   `  ����D  @Domaci_10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Domaci_10	Domaci_10  5          Domaci_10.frmVlasnik   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Domaci_10     5      .��5	      � $��5q�6     � RowDefinitions  5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ btnDodaj��5      $��0��6:   $��2q�6G   $	��150��6R   $
��Left=�6^   .��6y   Dodaj5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgStudents��5      $��1��5      $��2q�5         AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserResizeRows .     CanUserResizeColumns .     GridLinesVisibility$ 
Horizontal=�5      	   HorizontalGridLinesBrush
	 �������5      �� 
 �� Path$
 Vlasnici� �� SelectedItem 5      �� $
 CurrentVlasnik�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       ,  &System.Windows.Controls.DataGridColumn   SortMemberPath$ 	FirstName��6%      Header$	 Ime��6@      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6e      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6M   �� *Ime+6o     5!      $ LastName��6%   $ Prezime��6?   $ * 6l    .  6P   �� *	Prezime+6v     5"      $ Index��6%   $ Broj indeksa��6<   $ * 6p    .  6R   �� *	RedniBroj+6z   4  .System.Windows.Controls.DataGridTemplateColumn  5#      $  ��6)   $
 Auto 63      CellTemplate 5$      �� 5%      .R�5&      ��  �� Orientation$ 
Horizontal=�6)   $��Right=�6B   .+�5'   "   �� $ btnEditSpecification��6)   -   5        $��0q�5'   j   ��6u   �� .��6�   	Promeni5)   #   �� 5+   "   $ btnDeleteSpecification��6)   -   5        $��3 0 0 0q�5+   n   ��6   �� .��6�   	Obriši5-   #   5.      5/      51      53      55      57      