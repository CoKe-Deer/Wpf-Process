   M S B A M L   `   `   `  ���� G  CDaTaTemplae1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:DaTaTemplae1DaTaTemplae1      DaTaTemplae1.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ,localclr-namespace:DaTaTemplae1     -   $��My_Name_Is_CoKe_Deer��  � Title$$  CoKe_Deer的WPF进程管理器��$��646.083��$��611.166�� � Icon$ Only.ico�����	#FF040404 � WindowStyle$
 None=� � AllowsTransparency . 
������  � 	Resources  �� 
TargetType   	btnStyle1 �� Property �� Value �� 
TargetType	 �Name
 �� Triggers P� Property P� Value �� 
TargetName �� 
StartPoint �� EndPoint � Color � Offset  imga ��Name ��Name ��Name 
 Prname ��Name �� TextAlignment  	Proceprth  ProcePid  MainWindowTitle  btnTemplate1��%  &	        '�� �     &	 N    &	 �    &	 ;    &	 �    &	 �    &	     �� " ��.���  � �� �� " ��.R�� $	 grid1��
������ .+��� #��z��$��Center=�$��Center=���. 
 P�  �@J�IsMouseOver . . ��� $ grid1�� � ��
 �  ���� " �����  � ��$ 30����  � �� �� $ 0.5,0&�$ 0.5,1 &�.��� $ White��$ 0Q�� $ 	AliceBlue��$ 1Q��� .R��� $	 iea��-   $
��Auto��$
��Auto��.+��� $
 img1��$��32��$��32������ *	ImgPath+�� $
 oioi��$
��Auto��$
��Auto���� .R��� $ 	ProceName��-   $ Center=����� *coke+���� *ProcessNamea+�� .R��� $
 Prth��-   $ Center=����� *coke+���� *PrTH+�� .R��� $	 Pid��$ Center=����� *coke+���� *PDid+�� .R��� $ Tiele��$ Center=����� *coke+���� *Tiele1+�� " ��.R�� $	 grid1��
������ #��z��#��z��.+��� #��z��$��Center=�$��Center=���. 
 P�  �@J�IsMouseOver . . ��� $ grid1�� � ��
 ��ح�.��� .+��� $��0�� �� Orientation$ 
Horizontal=�$��RightToLeft=�.+��� -   #��[  $��X��
�������$��20(�$
��Left=�$	��Top=�$��23��$��23��$��5,3,5,0q��� -   #��[ $	��口��
�������$��20(�$
��Left=�$	��Top=�$��23��$��23��$��5,2,5,0q��� -   #��[ $	��一��
�������$��20(�$
��Left=�$	��Top=�$��23��$��23��$��5,2,5,0q��� -    ��Name$ listViewProcess��$��5,28,5,5q����� 
 � Tag �� *PDid+ � ContextMenu �� -	   $��cm�� �� 	StaysOpen . .@�m� -
   $
��Kill��$
��Kill�� m� Icon �� -   $
 img1��$��32��$��32������ *	ImgPath+m� -   $
��Moke��$��进程模块�� �� -   $
 img2��$��32��$��32������ *	ImgPath+m� -   $
��Liul��$��进程流量�� �� -   $
 img3��$��32��$��32������ *	ImgPath+m� -   $	��ser��$��服务列表�� �� -   $
 img4��$��32��$��32������ *	ImgPath+ �� View �� -   	GridView1��.P���  �� Width$
 Auto��$��图标�� �� CellTemplate# [ �� $
 Auto��$��进程名字��# [ �� $
 Auto��$	��PID��# [ �� $	 130��$��进程简介��# [ �� $
 Auto��$��进程路径��# [ ����   �� ImageSource$  /1.png��