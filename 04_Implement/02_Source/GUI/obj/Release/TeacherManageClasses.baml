   M S B A M L   `   `   `  ���� >  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI      GUI.TeacherManageClasses   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  localclr-namespace:GUI  datanamespace:GUI  -     N� Title$  Manage Classes�� � 	Resources    InformationOfAdminTemplate �� DataType?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  NameC  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffectD  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension   Duration �� Orientation��%�  &	        �� $ 	PeopleDTO��.R�  $ TrainsitionigContentSlide��   *SlideInFromLeft+$ 0:0:0.5X�.���� ���#CFE6FF$ 
Horizontal=�$��Center=�$��0,0,0,0q�.+��� $��Center=�$��Center=�$��35��$	��100�����#305066$��14(����� *Id+�� $��Center=�$
��Left=�$��35��$	��210�����#305066$��14(����� *Name+�� $��Center=�$��Center=�$��35��$��90�����#305066$��14(����� *Status+.��  -   $ TrainsitionigContentSlide��   *Fadein+$ 0:0:0.5X�.��� .+��� -   $��comboboxLeft��$��20,93,697,0q�$��Center=�$ 
Horizontal=�$	��Top=�$	��311��$��40��.+��� $��Center=�$��Center=�$��0,0,0,0q�$��14(�$
��Bold"�$��Class:���� -    ��Name$ chooseClass��$	��100��$��14(��� $��Center=�$��Center=�$��20,0,0,0q�$��14(�$
��Bold"�$��Status:���� -   $ chooseStatus��$��70��$��14(�.@��� $��14(�$	��All���� $��14(� �� 
IsSelected . $��Active���� $��14(�$��Deactive���� -   $��comboboxRight��$��610,93,86,0q�$��Center=�$ 
Horizontal=�$	��Top=�$	��332��$��40��.+��� $��Center=�$��Center=�$��0,0,0,0q�$��14(�$
��Bold"�$��Class:���� -   $ chooseClass2��$	��100��$��14(��� $��Center=�$��Center=�$��20,0,0,0q�$��14(�$
��Bold"�$��Status:���� -   $ chooseStatus2��$��70��$��14(�.@��� $��14(�$	��All���� $��14(� . $��Active���� $��14(�$��Deactive���� $��0,182,595,0q��� $ 
Horizontal=�$	��Top=�.+��� $��20,0,0,0q�	 �� CornerRadius$	 20��$��40��
��� ���._��� ���#fff$
��Bold"�$��Center=�$��Center=�$��75��$��14(�.��ID�� $��20,0,0,0q�$	 20��
��� ���._��� ���#fff$
��Bold"�$��Center=�$��Center=�$	��180��$��14(�.��	Full Name�� $��35,0,0,0q�$	 20��
��� ����� $��	-10,0,0,0q�$	 20��
��� ���._��� ���#fff$
��Bold"�$��Center=�$��Center=�$��85��$��14(�.��Status�� -	   $��listviewUser��$��0,232,595,0q�#��[  �� $��592,182,0,0q��� $ 
Horizontal=�$	��Top=�.+��� $��20,0,0,0q�$	 20��$��40��
��� ���._��� ���#fff$
��Bold"�$��Center=�$��Center=�$��75��$��14(�.��ID�� $��20,0,0,0q�$	 20��
��� ���._��� ���#fff$
��Bold"�$��Center=�$��Center=�$	��180��$��14(�.��	Full Name�� $��35,0,0,0q�$	 20��
��� ����� $��	-10,0,0,0q�$	 20��
��� ���._��� ���#fff$
��Bold"�$��Center=�$��Center=�$��85��$��14(�.��Status�� -
   $��listviewUser2��$��592,232,0,0q�#��[  �� -   $��searchUser1��)  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 	Search...��$
��Left=�$��14(�$��39��$��	20,49,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��307���� -    ��Name$ btn_Search1��$��Search��$
��Left=�$��
332,56,0,0q�$	��Top=�$��75���� -   $ btn_ltr��$��>>��$
��Left=�$��472,334,0,0q�$	��Top=�$��76���� -   $ btn_rtl��$��>>��$
��Left=�$��472,406,0,0q�$	��Top=�$��76�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� �� ��  �� Angle$	 180Q�T� �� -   $��controlLeft��$ 
Horizontal=�.+��� $��14(�$��Max: ��$
��Left=�$��
20,138,0,0q�$	��Top=�$
��Bold"����#039866�� -    ��Name$ lbl_Max1��$��14(�$��0��$
��Left=�$��	5,138,0,0q�$	��Top=�$��30�����#039866�� $��14(�$��	Current: ��$
��Left=�$��
20,138,0,0q�$	��Top=�$
��Bold"�
���  ���� -   $��lbl_Current1��$��14(�$��0��$
��Left=�$��	5,138,0,0q�$	��Top=�$��30��
���  ���� -   $��controlRight��$ 
Horizontal=�.+��� $��14(�$��Max: ��$
��Left=�$��610,138,0,0q�$	��Top=�$
��Bold"����#039866�� -   $ lbl_Max2��$��14(�$��0��$
��Left=�$��	5,138,0,0q�$	��Top=�$��30�����#039866�� $��14(�$��	Current: ��$
��Left=�$��
15,138,0,0q�$	��Top=�$
��Bold"�
���  ���� -   $ lbl_Current2��$��14(�$��0��$
��Left=�$��	5,138,0,0q�$	��Top=�$��30��
���  ���� -    ��Name$ searchUser2��$
 	Search...��$
��Left=�$��14(�$��39��$��
610,49,0,0q�$
 Wrap=�$	��Top=�$	��307���� -   $ btn_Search2��$��Search��$
��Left=�$��
922,56,0,0q�$	��Top=�$��75���� $��0,10,0,0q�   Flag �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value �� 
TargetType �� Path �� RelativeSource��%-  &	       �� " 	� P�  �@d�	IsChecked$ FalseY�. ���  �@J�Opacity$	 0.5Q�.���  � ��$ 2q���  � �� �� " 	�.R��� $��0q����#f1c40f$	 5��._��� $��14(�$
��Bold"����#fff$��Center=�$��Center=����� $ Content� �� *TemplatedParent+.+��� $��0,0,0,0q�$��Center=�$��Center=�.@�A�  A� Columns$ 2��$��338,0q�$	��351��.+�	� -    	�Name$ rb_add�� d� 	IsChecked$
 TrueY�$��Add student��#��[ $��34��$��	10,0,18,0q�	� -   $ rb_trans��$��Transfer Student��#��[ $��34��$��	22,0,11,0q�