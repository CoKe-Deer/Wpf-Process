   M S B A M L   `   `   `  ����   DaTaTemplae1    DaTaTemplae1.Service   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Service��$	��412��$	��546�� � WindowStyle$
 None=� � AllowsTransparency . 
������  � 	Resources    ServiceName1  DisplayName1  Status1  DevicesName1 �� 
TargetType  btnTemplate1 �Name �� Triggers P� Property P� Value	 �� 
TargetName
 �� Property �� Value �� 
TargetType  	btnStyle1 �� 
StartPoint �� EndPoint � Color � Offset��%�  &	        &	 &     &	 L     &	 m     &	 �     &	 E    '��     �� .R��� ���� *ServiceName+�� .R��� ���� *DisplayName+�� .R��� ���� *Status+�� .R��� ���� *DevicesName+�� " ��.R�� $ grid1��
������ #��z��#��z��.+��� #��z��$��Center=�$��Center=���.  P�  �@J�IsMouseOver . . ��� $	 grid1��
 � ��
 ��ح��� " ��.��� 
 � �� �� " ��.R�� $ grid1��
������ .+��� #��z��$��Center=�$��Center=���.  P�  �@J�IsMouseOver . . ��� $	 grid1��
 � ��
 �  ���� " ����� 
 � ��$ 30���� 
 � �� �� $ 0.5,0&�$ 0.5,1&�.��� $ White��$ 0Q�� $ 	AliceBlue��$ 1Q�.��� ���	#FF417A43.+��� $��0�� �� Orientation$ 
Horizontal=�$��RightToLeft=�.+��� -   #��[ $��X��
�������$��20(�$
��Left=�$	��Top=�$��23��$��23��$��5,3,5,0q��� -   #��[ $	��口��
�������$��20(�$
��Left=�$	��Top=�$��23��$��23��$��5,2,5,0q��� -   #��[ $	��一��
�������$��20(�$
��Left=�$	��Top=�$��23��$��23��$��5,2,5,0q��� -    ��Name$ ServiceList��$��5,28,5,5q�����  � ContextMenu �� -   $��cd�� �� 	StaysOpen . .@�m� -   $��sx��$��刷新驱动程序服务�� m� Icon �� -    ��Name$
 img1��$��32��$��32��$��	/Only.ico��m� -	   $	��sx1��$��刷新系统服务�� �� -
   $
 img2��$��32��$��32��$��	/Only.ico�� �� View �� -   	GridView1��.P���  �� Width$
 Auto��$��名称�� �� CellTemplate# [ �� $
 Auto��$��注册名称��# [  �� $
 Auto��$��服务状态��# [ 