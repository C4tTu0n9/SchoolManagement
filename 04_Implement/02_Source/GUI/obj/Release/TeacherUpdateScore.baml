   M S B A M L   `   `   `  ���� >  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI      GUI.TeacherUpdateScore   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  localclr-namespace:GUI  datanamespace:GUI  -     N� Title$  Update Score�� � 	Resources    InformationOfAdminTemplate �� DataType?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  NameC  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffectD  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension   Duration �� Orientation��%C  &	        �� $ MarkDTO��.R�  $ TrainsitionigContentSlide��   *SlideInFromLeft+$ 0:0:0.5X�.���� ���#CFE6FF$ 
Horizontal=�$��Center=�$��0,0,0,0q�.+��� $��Center=�$��Center=�$��35��$	��100�����#305066$��14(����� *	IDStudent+�� $��Center=�$
��Left=�$��35��$	��180�����#305066$��14(����� *NameStudent+�� $��Center=�$��Center=�$��35��$	��180�����#305066$��14(����� *Subject.NameSubject+�� $��Center=�$��Center=�$��35��$��90�����#305066$��14(����� *	NameClass+.��  -   $ TrainsitionigContentSlide��   *Fadein+$ 0:0:0.5X�.��� .+��� $��0,80,0,0q�$��Center=�$ 
Horizontal=�$	��Top=�.+��� $��Center=�$��Center=�$��0,0,0,0q�$��14(�$
��Bold"�$��Subject:���� -    ��Name$ chooseSubject��$	��170��$��14(��� $��Center=�$��Center=�$��20,0,0,0q�$��14(�$
��Bold"�$��Class:���� -   $ chooseClass��$��70��$��14(��� $��Center=�$��Center=�$��20,0,0,0q�$��14(�$
��Bold"�.��	Semester:�� -   $��chooseSemester��$��40��$��14(�.@��� $��14(� �� 
IsSelected . .��I�� $��14(�.��II�� $��	0,130,0,0q��� $ 
Horizontal=�$	��Top=�.+��� $��20,0,0,0q�	 �� CornerRadius$	 20��$��40��
��� ���._��� ���#fff$
��Bold"�$��Center=�$��Center=�$��75��$��14(�.��ID�� $��30,0,0,0q�$	 20��
��� ���._��� ���#fff$
��Bold"�$��Center=�$��Center=�$	��170��$��14(�.��	Full Name�� $��35,0,0,0q�$	 20��
��� ���._��� ���#fff$
��Bold"�$��Center=�$��Center=�$	��100��$��14(�.��	Subject�� $��40,0,0,0q�$	 20��
��� ���._��� ���#fff$
��Bold"�$��Center=�$��Center=�$��85��$��14(�.��Class�� -   $��listviewUser��$��0,182,445,0q�#��[  �� -   $��
searchUser��)  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 	Search...��$
��Left=�$��14(�$��39��$��
308,25,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��465���� $��Subject:��$
��Left=�$��600,182,0,0q�$	��Top=�$��17(�$
��Bold"�$	��140���� -    ��Name$ subject_st_infor��$ 
 Select student to continue��$��0q� �� 
IsReadOnly . $
��Left=�$��745,182,0,0q�$	��Top=�$��17(�$	��255���� $��
Full name:��$
��Left=�$��600,222,0,0q�$	��Top=�$��17(�$
��Bold"�$	��140��$��34���� $
��ID: ��$
��Left=�$��600,262,0,0q�$	��Top=�$��17(�$
��Bold"�$	��140���� $��45 minutes:��$
��Left=�$��600,390,0,0q�$	��Top=�$��17(�$
��Bold"�$	��140���� $��Class:��$
��Left=�$��600,304,0,0q�$	��Top=�$��17(�$
��Bold"�$	��140���� $��	Semester:��$
��Left=�$��600,432,0,0q�$	��Top=�$��17(�$
��Bold"�$	��140���� -	   $ fullname_st_infor��$ 
 Select student to continue�� �� CharacterCasing$ Upper=�$��0q� . $
��Left=�$��745,222,0,0q�$	��Top=�$��17(�$	��255���� -
   $ id_st_infor��$ 
 Select student to continue��$��0q� . $
��Left=�$��745,262,0,0q�$	��Top=�$��17(�$	��255���� -   $ class_st_infor��$ 
 Select student to continue��$��0q� . $
��Left=�$��745,306,0,0q�$	��Top=�$��17(�$	��255���� -   $ semester_st_infor��$
 final��$��Center=�$��0q� . $
��Left=�$��745,434,0,0q�$	��Top=�$��17(�$��51���� -   $��btnEdit��$��0q�$
��Left=�$��910,491,0,0q�$	��Top=�$��90��{�.  .���� $ 
Horizontal=�.+��� $��img/icons/edit_btn.png��$��-2,0,0,0q�$��25��$��25���� $��2,0,0,0q�$��20���� $
�Edit���� -   $��btnDoneOfEdit��$��0q�$
��Left=�$��910,491,0,0q�$	��Top=�$��90��$y�	Collapsed=�.���� $ 
Horizontal=�.+��� $��img/icons/done_btn.png��$��-2,0,0,0q�$��25��$��25���� $��2,0,0,0q�$��20���� $
�Done���� $��15 mintues:��$
��Left=�$��600,347,0,0q�$	��Top=�$��17(�$
��Bold"��� -   $ m15st_st_infor�� . $
 st��$��0q�$��Center=�$
��Left=�$��745,347,0,0q�$	��Top=�$��17(�$��54���� -   $ m15nd_st_infor�� . $
 nd��$��0q�$��Center=�$
��Left=�$��804,347,0,0q�$	��Top=�$��17(�$��54���� -   $ m15rd_st_infor�� . $
 rd��$��0q�$��Center=�$
��Left=�$��863,348,0,0q�$	��Top=�$��17(�$��54���� -   $ m45st_st_infor�� . $
 st��$��0q�$��Center=�$
��Left=�$��745,391,0,0q�$	��Top=�$��17(�$��54���� -   $ m45nd_st_infor�� . $
 nd��$��0q�$��Center=�$
��Left=�$��804,391,0,0q�$	��Top=�$��17(�$��54���� -   $ m45rd_st_infor�� . $
 rd��$��0q�$��Center=�$
��Left=�$��863,392,0,0q�$	��Top=�$��17(�$��54���� -    ��Name$ 
btn_Search��$��Search��$
��Left=�$��
786,32,0,0q�$	��Top=�$��75���� -   $ 	btnCancel��$y�	Collapsed=�$��0q�$
��Left=�$��815,491,0,0q�$	��Top=�$��90�����	#FFF32121���	#FFF32121.���� $ 
Horizontal=�.+��� $��img/icons/remove_btn.png��$��-2,0,0,0q�$��25��$��25���� $��2,0,0,0q�$��20���� $�Cancel��