   M S B A M L   `   `   `  ����F  BQuanLyDeThi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:QuanLyDeThi.ViewsQuanLyDeThi.Views  5   	   5clr-namespace:QuanLyDeThi.ViewsQuanLyDeThi.Views  5   	   $    QuanLyDeThi.Views.LessonWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:QuanLyDeThi.Views     5   	   .ucclr-namespace:QuanLyDeThi.Views     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   
      MaterialDesignBody#���   5
   
   $��Regular"�5   
   $��15(�5   
   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   
      TextRenderingMode$
 Auto=�5   
     MaterialDesignPaper#���  5   
     MaterialDesignFont#���  5   
    � WindowStartupLocation$ CenterOwner=�5   	     LessonVM � DataContext# [ 5   	    � 
ResizeMode$ NoResize=�5   	    � Title$ 	Đề thi��5   	   $	��540��6   $	��960��6%   .��5      �  � RowDefinitions 5   
   �� 5      $��80 �6   6*   �� 5      6   �� 5      $��40 �6   6*   .+�5   
       QuanLyDeThi.Views.HeaderUC  $��0��6   6%   � 5   
   $��1��6    5      �� 5      $��35 �6    6.   �� 5      $��50 �6    6.   �� 5       6"   .+�5"      �� $��0��6   $��Center=�6%   $��Center=�6B   $��25(�6]   
����  �$��Normal$�6}   Quản Lý Đề Thi6�   (  "MaterialDesignThemes.Wpf.ColorZone  5#         Mode$ 
PrimaryMid=�5$      $��1��5%      $��1q�6   $��Stretch=�6   $��Stretch=�6:   .��5&      � $��Center=�6   .+�5'        $ Standard=�6/      CornerRadius$ 2��6?   $��8 3 8 3q�6P   $��	16 0 20 0q�6c   	 K� ZIndex$	 1��6v   +  %MaterialDesignThemes.Wpf.ShadowAssist
   ShadowDepth$
 Depth1=�6�   .��5(      �  � ColumnDefinitions 5)      �� 5*   "   66   �� 5+   "   66   .+�5-      �� $��0��6%     MaterialDesignToolButton#���  65   .��5.   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�6:    J� Opacity$	 .56Q�6I   5/      �� 50      $��1��6&   $��8 0 0 0q�66   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm kiếm��6G   .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�6q   $��Center=�6�   $��0q�6�   $	��440��6�   51      52      �� 54      $��Thêm Đề Thi��6<   $��5q�6R   $��	10 0 10 0q�6^   $	��110��6q   
����� ���6   �� *
AddCommand+6�   �� 55      $��Sửa��6=   $��5q�6L   $��	10 0 10 0q�6X   $	��110��6k   
���� ����6   �� *EditCommand+6�   �� 56      $��Xóa��6?   $��5q�6N   $��10 0 5 0q�6Z   $	��110��6l   
���������6   �� *DeleteCommand+6�   57      58      #  MaterialDesignThemes.Wpf.Card  59      $��2��6"   $��2q�6/   $��Stretch=�6:   .��5:      �� $
��Auto=�6   $��Hidden=�6B   .��5;      �� ��5<      �� *	LstLesson+ �� SelectedItem 6<   �� *SelectedItem+ �� View 5=      �� 5>      .P�5?   "   ��  �� Width$	 150��61   $��ID��6a    �� DisplayMemberBinding 6=   �� *Id+6a   �� 5@   "   $	 400��61   $��
Nội dung��6j    6>   �� *
LessonName+6j   �� 5A   "   $	 150��61   $��Người tạo��6o    6=   �� *User.DisplayName+6o   �� 5B   "   $	 120��61   $��Ngày tạo��6�    6=   �� *
CreateDate+ �� StringFormat$ 
dd/MM/yyyy��6�   �� 5C   "   $	 120��61   $��Ngày Sửa��6�    6=   �� *
ModifyDate+$ 
dd/MM/yyyy��6�   5D      5F      5G      5H      5I       	   QuanLyDeThi.Views.FooterUC	  5J   
   $��2��6   6%   5K      5L      