   M S B A M L   `   `   `  ����D  @Domaci_10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Domaci_10	Domaci_10  5   	       Domaci_10.AutoAddEdit   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Domaci_10     5   	     � Title$  AutoAddEdit��5   	   $	��450��6   $	��800��6*   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6!   $��2q�61   $��Naziv: ��6<   �� 5   
   $��0��6   $��1��6   $��2q�6/   ��6:   ��  �� Path$ CurrentAuto.Naziv� �� Mode$ TwoWay=��� 5   
   $��1��6   $��0��6!   $��2q�61   $��
Godisnji: ��6<   �� 5   
   $��1��6   $��1��6   $��2q�6/   ��6:   �� $ CurrentAuto.Godiste�$ TwoWay=��� 5   
   $��2��6   $��0��6!   $��2q�61   $��Šifra: ��6<   �� 5   
   $��2��6   $��1��6   $��2q�6/   ��6:   �� $ CurrentAuto.Sifra�$ TwoWay=��� 5   
   $��3��6   $��0��6!   $��2q�61   $��Mehanicar: ��6<   �� 5    
   $��3��6   $��1��6    $��2q�60    �� DisplayMemberPath$	 Ime��5#      ��5!      �� *MehanicariFromDB+ �� SelectedItem 5"      �� *CurrentAuto.Mehanicar+$ TwoWay=�5#      �� 5%   
   -   5         ��Name$ btnSave��5%   9   $��5��6   $��0��6   $��2q�6.   .��6`   
Sačuvaj5'      �� 5)   
   -   5        $ 	btnCancel��5)   9   $��5��6   $��1��6   $��2q�6.   .��6d   
Odustani5+      5,      5.      