   M S B A M L   `   `   `  ����F  BQuanLyDeThi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QuanLyDeThi.ViewsQuanLyDeThi.Views  5   	   5clr-namespace:QuanLyDeThi.ViewsQuanLyDeThi.Views  5   	   &     QuanLyDeThi.Views.QuestionWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:QuanLyDeThi.Views     5   	   .ucclr-namespace:QuanLyDeThi.Views     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   
      MaterialDesignBody#���   5
   
   $��Regular"�5   
   $��15(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
    � WindowStartupLocation$ CenterOwner=�5   	     
QuestionVM � DataContext# [ 5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ 	Đề thi��5   	   $	��540��6   $	��960��6%   .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      6   �� 5      $��45 �6   6*   �� 5      $��40 �6   6*   .+�5   
       QuanLyDeThi.Views.HeaderUC  $��0��6   6%   � 5   
   $��1��6    5      �� 5      $��75 �6    6.   �� 5       $��50 �6    6.   �� 5!      6"   .+�5#      � $��0��6    5$      �� 5%      6&   �� 5&      6&   .+�5(      � $��0��6   $��Stretch=�6$   $��Stretch=�6@    � ColumnDefinitions 5)      �� 5*      $	��240 �6+   69   �� 5+      6-   .+�5-      �� $��0��6!   $��20(�61   $��Center=�6?   Tên Đề thi :6h   �� 5.      ���#660000$��1q�63    �� CornerRadius$ 3��6G   	 �� Padding$	 1q�6X   $��1��6d   ���#E8E8E8$	��600��6�   $��8 3 0 3q�6�   $
��Left=�6�   ._�5/      �� $	��600��69   $��5 0 0 0q�6E   
 �� SelectionBrush

 �   ����	#00000000 �� 
CaretBrush �	#FF6C6C6C)  #MaterialDesignThemes.Wpf.HintAssist   Hint$  ��6�   .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Visible=�6�   $
��Left=�6�   $��Center=�6  $��1q�65  
������ ��6"   �� *Title+6J  50      52      � 53      $��1��6   $��Stretch=�6$   $��Stretch=�6@    54      �� 55      $	��240 �6+   69   �� 56      $	��64* �6+   69   �� 57      $
��293* �6+   .+�59      �� $��0��6!   $��20(�61   $��Center=�6?   $	��0,7q�6Z   Thiết lập thời gian :6~   �� 5:      ���#660000$��1q�63   $ 3��6G   $	 1q�6X   $��1��6d   ���#E8E8E8$	��600��6�   $��8 3 0 3q�6�   $
��Left=�6�   $��2��6�   ._�5;      �� -   5        $	��600��5;   l   $��5 0 0 0q�6x   

 �   ����	#00000000 �	#FF6C6C6C$  ��6�   $ Visible=�6�   $
��Left=�61  $��Center=�6L  $��1q�6h  
������ ��6P   �� *
AnswerTime+6}  5<      5=      5>      (  "MaterialDesignThemes.Wpf.ColorZone  5?         Mode$ 
PrimaryMid=�5@      $��1��5A      $��1q�6   $��Stretch=�6   $��Stretch=�6:   .��5B      � $��Center=�6   .+�5C        $ Standard=�6/      CornerRadius$ 2��6?   $��8 3 8 3q�6P   $��	16 0 20 0q�6c    K� ZIndex$ 1��6v   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth1=�6�   .��5D      �  5E      �� 5F   "   66   �� 5G   "   66   .+�5I      �� $��0��6%     MaterialDesignToolButton#���  65   .��5J   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�6:    J� Opacity$	 .56Q�6I   5K      �� 5L      $��1��6&   $��8 0 0 0q�66   $ Tìm kiếm��6�   $ Hidden=�6�   $��Center=�6�   $��0q�6  $	��440��6'  ��6G   �� *Search+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6'  5M      5N      �� 5P      $��Thêm Câu Hỏi��6<   $��5q�6S   $��	10 0 10 0q�6_   $	��110��6r   
����� ���6   �� *
AddCommand+6�   �� 5Q      $��Sửa��6=   $��5q�6L   $��	10 0 10 0q�6X   $	��110��6k   
���� ����6   �� *EditCommand+6�   �� 5R      $��Xóa��6?   $��5q�6N   $��10 0 5 0q�6Z   $	��110��6l   
���������6   �� *DeleteCommand+6�   5S      5T      #  MaterialDesignThemes.Wpf.Card  5U      $��2��6"   $��2q�6/   $��Stretch=�6:   .��5V      �� $
��Auto=�6   $��Hidden=�6B   .��5W      �� ��5X      �� *LstQuestion+ �� SelectedItem 6>   �� *SelectedItem+ �� View 5Y      �� 5Z      .P�5[   "   ��  �� Width$	 150��61   $��ID��6a    �� DisplayMemberBinding 6=   �� *Id+6a   �� 5\   "   $	 400��61   $��
Câu hỏi��6m    6>   �� *QuestionTitle+6m   �� 5]   "   $	 150��61   $��Người tạo��6o    6=   �� *User.DisplayName+6o   �� 5^   "   $	 120��61   $��Ngày tạo��6�    6=   �� *
CreateDate+ �� StringFormat$ 
dd/MM/yyyy��6�   �� 5_   "   $	 120��61   $��Ngày Sửa��6�    6=   �� *
ModifyDate+$ 
dd/MM/yyyy��6�   5`      5b      5c      5d      5e      � 5f   
   $��2��6   $��Center=�6   $��Center=�69   .+�5g      ��  $  MaterialDesignRaisedAccentButton#��[ 6   $	��160��6P    � ToolTip$ Hoàn Thành��6\   $��Hoàn Thành��6q   $��18(�6�   $
��Bold"�6�   
����+����6�   �� *CompleteCommand+5h      5i       	   QuanLyDeThi.Views.FooterUC	  5j   
   $��3��6   6%   5k      5l      