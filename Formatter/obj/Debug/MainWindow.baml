   M S B A M L   `   `   `  ����D  @Formatter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Formatter	Formatter  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       JSON_Formatter.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Formatter     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	     � Title$  JSON Formatter��5	   	   $	��600��6    $
��1000��6-    � WindowStartupLocation$ CenterScreen=�6:    � 
ResizeMode$ NoResize=�6_   .��5
      � $��	0,0,-6,-1q�6K    +� FocusedElement 6   ��  �� ElementName$ richTextBox�� � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   �� 5      $��0* �6   .+�5   
   �� -   5         ��Name$ btFormat��5      $��Format��6#   $
��Left=�64   $��
618,10,0,0q�6O   $	��Top=�6c   $��65��6{   $��30��6�   6�   �� 5   
   -   5        $ btRemoveWhiteSpace��5      $��Remove white space��6-   $
��Left=�6J   $��
780,10,0,0q�6e   $	��Top=�6y   $	��125��6�   $��30��6�   6�   �� 5   
   -   5        $ btClear��5      $��Clear��6"   $
��Left=�62   $��
910,10,0,0q�6M   $	��Top=�6a   $��65��6y   $��30��6�   6�   �� 5   
   -   5        $ btPaste��5      $��Paste��6"   $
��Left=�62   $��30��6M   $��
478,10,0,0q�6Y   $	��Top=�6m   $��65��6�   6�   �� 5   
   -   5        $ btCopy��5      $
��Copy��6!   $
��Left=�60   $��30��6K   $��
548,10,0,0q�6W   $	��Top=�6k   $��65��6�   6�   �� 5   
   -   5         ��Name$ richTextBox��5       �� 
AcceptsTab . $
��Left=�6=   $	��480��6X   $��
395,76,0,0q�6e   $	��Top=�6y   $	��580��6�   	 �� 
LineHeight$	 1��6�   $��Lucida Console)�6�   . �5      /� 5      �� 5   
   -   5        $ btSelectAll��5      $��
Select All��6&   $
��Left=�6;   $��
395,10,0,0q�6V   $	��Top=�6j   $��78��6�   $��30��6�   6�   R� 5   
   -   5        
 R�Name$
 treeJsonView��5      $
��Left=�6)   $	��480��6D   $��	10,76,0,0q�6Q   $	��Top=�6d   $	��380��6|   $��13.333(�6�   �� 5   
   -	   5         ��Name$ label_input��5      $��JSON input:��6%   $
��Left=�6;   $��
395,45,0,0q�6V   $	��Top=�6j   $	��104��6�   $
��Bold"�6�   $��13.333(�6�   �� 5   
   -
   5        $ 
label_tree��5      $��JSON viewer:��6$   $
��Left=�6;   $��	10,45,0,0q�6V   $	��Top=�6i   $��13.333(�6�   $
��Bold"�6�   �� 5   
   -   5        $ btHighlight��5      $��	Highlight��6&   $
��Left=�6:   $��
688,10,0,0q�6U   $	��Top=�6i   $��87��6�   $��30��6�   
���   �6�   �� 5   
   -   5        $ 
btViewJson��5      $��	View JSON��6%   $
��Left=�69   $��	10,10,0,0q�6T   $	��Top=�6g   $	��109��6   $��30��6�   6�   5      5      