   M S B A M L   `   `   `  ����G  CPractice17_2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Practice17_2Practice17_2  5   	       Practice17_2.GoodWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Practice17_2     5   	     � Title$  Товары��5   	   $	��300��6   $	��600��6%    � WindowStartupLocation$ CenterScreen=�5	   	    � 	Resources 5
       �� 
TargetType �� Property �� Value��%c  '��       '�� o     '�� �     �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ Center=�62   5      �� 5   
   " ��6   .�5      ��  � ��$ 5q�6'   �� 5       � ��$ 1��6,   5      �� 5   
   " ��6   .�5      ��  � ��$	 100��6)   �� 5       � ��$ 5q�6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5    
   �� 5!      $��1* �6   �� 5"      $��4* �6   .+�5$   
   �� $��Id��6   �� 5%   
   $��Код товара��6   $��1��6&   �� 5&   
   $��e-mail клиента��6   $��2��6*   �� 5'   
   $+��%Наименование товара��6   $��3��6/   $
��Wrap=�6<   �� 5)   
   {�.  ��6   �� *Id+6&   �� 5*   
   $��1��6(   ��6   �� *code+6(   �� 5+   
   -   5         ��Name$ cbEmails��5+      $��1��6%   $��2��65   $��5q�6B   6M   �� 5,   
   $��3��6,   	 �� TextWrapping$
	 Wrap=�69   ��6   �� *
goodName+69   �� 5.   
   $��Center=�6   
 �� Orientation$
 
Horizontal=�62   $��4��6K   $��1��6X   .+�5/      �� -   5         �� 	IsDefault . .��5/   <   OK6@   �� 50       �� IsCancel . .��6&   Отмена6.   51      52      53      