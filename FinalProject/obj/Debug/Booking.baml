   M S B A M L   `   `   `  ����G  CFinalProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:FinalProjectFinalProject  5   	       FinalProject.Booking   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:FinalProject     5   	     � Title$  Booking��5   	   $	��400��6   $	��400��6&   
�������.��5	      �  � RowDefinitions 5
   
   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��15* �6   �� 5      $	��10* �6   .+�5   
   �� -   5         ��Name$ lblGreeting��5      $��0��6   $��Bottom=�62   $��50,5,5,5q�6T   $��	Hi, Name!��6g   �� 5   
   $��1��6   $��Bottom=�6   $��50,5,5,5q�6?   .��6S   Show Available:6d   �� 5   
   -   5         ��Name$ 
cboTickets��5       $��2��6   $	��300��64   $��30��6C    �� SelectedIndex$ 0��6R   �� 5   
   $��3��6   $��Bottom=�6   $��50,5,5,5q�6?   .��6S   	Quantity:6^   �� 5   
   -   5        $ cboQuantity��5       $��4��6   $��30��66   $��50,0,0,0q�6E   $
��Left=�6W   $��50��6r   $ 0��6�   �� 5    
   -   5         ��Name$ 
btnBooking��5       $��5��6   $	��200��62   $��30��6A   $��Segoe Print)�6P   ���	#FFD4DCCD.��6�   
Book it!6�   �� 5#   
   -   5        $ btnBackAccountInfo��5#      $��6��6   $	��200��6:   $��30��6I   
�������
������ .��5$      �� $��	underline{�6   Back to Account Information6R   5%      5'      5(      