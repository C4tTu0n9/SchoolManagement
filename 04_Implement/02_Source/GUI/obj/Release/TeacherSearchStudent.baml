   M S B A M L   `   `   `  ���� >  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI      GUI.TeacherSearchStudent   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  localclr-namespace:GUI  datanamespace:GUI  -     N� Title$  Search Student�� � 	Resources    InformationOfAdminTemplate �� DataType?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  NameC  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffectD  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension   Duration �� Orientation��%*  &	        �� $ 	PeopleDTO��.R�  $ TrainsitionigContentSlide��   *SlideInFromLeft+$ 0:0:0.5X�.���� ���#CFE6FF$ 
Horizontal=�$��Center=�$��0,0,0,0q�.+��� $��Center=�$��Center=�$��35��$	��100�����#305066$��14(����� *Id+�� $��Center=�$
��Left=�$��35��$	��180�����#305066$��14(����� *Name+�� $��Center=�$��Center=�$��35��$	��180�����#305066$��14(����� *Gender+�� $��Center=�$��Center=�$��35��$��90�����#305066$��14(����� *	NameClass+.��  -   $ TrainsitionigContentSlide��   *Fadein+$ 0:0:0.5X�.��� .+��� $��0,80,0,0q�$��Center=�$ 
Horizontal=�$	��Top=�.+��� $��Center=�$��Center=�$��0,0,0,0q�$��14(�$
��Bold"�$��Class���� -    ��Name$ chooseClass��$	��100��$��14(��� $��Center=�$��Center=�$��20,0,0,0q�$��14(�$
��Bold"�$��Year:���� -   $ 
chooseYear��$	��130��$��14(��� $��	0,130,0,0q��� $ 
Horizontal=�$	��Top=�.+��� $��20,0,0,0q� �� CornerRadius$ 20��$��40��
��� ���._��� ���#fff$
��Bold"�$��Center=�$��Center=�$��75��$��14(�.��ID�� $��30,0,0,0q�$ 20��
��� ���._��� ���#fff$
��Bold"�$��Center=�$��Center=�$	��170��$��14(�.��	Full Name�� $��35,0,0,0q�$ 20��
��� ���._��� ���#fff$
��Bold"�$��Center=�$��Center=�$	��100��$��14(�.��Gender�� $��40,0,0,0q�$ 20��
��� ���._��� ���#fff$
��Bold"�$��Center=�$��Center=�$��85��$��14(�.��Class�� -   $��listviewStudent��$��0,182,445,0q�#��[  �� -   $��
searchUser��)  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 	Search...��$
��Left=�$��14(�$��39��$��
308,25,0,0q�
 �� TextWrapping$

 Wrap=�$	��Top=�$	��465���� $%��img/icons/manageuser_avatar.png��$	��100��$	��100��$��741,130,187,361q��� $��
Full name:��$
��Left=�$��596,257,0,0q�$	��Top=�$��17(�$
��Bold"�$	��140��$��34���� $��Date of birth:��$
��Left=�$��596,297,0,0q�$	��Top=�$��17(�$
��Bold"�$	��140���� $��Gender:��$
��Left=�$��596,425,0,0q�$	��Top=�$��17(�$
��Bold"�$	��140���� $��Email:��$
��Left=�$��596,339,0,0q�$	��Top=�$��17(�$
��Bold"�$	��140���� $��Phone number:��$
��Left=�$��596,467,0,0q�$	��Top=�$��17(�$
��Bold"�$	��140���� -    ��Name$ fullname_st_infor��$��Select student to view��$��0q�$
��Left=�$��741,257,0,0q�$	��Top=�$��17(�$	��255��$��34���� -   $ birthofday_st_infor��$��Select student to view��$��0q�$
��Left=�$��741,297,0,0q�$	��Top=�$��17(�$	��255��$��33���� -	   $ email_st_infor��$��Select student to view��$��0q�$
��Left=�$��741,341,0,0q�$	��Top=�$��17(�$	��255��$��31���� -
   $ gender_st_infor��$��Select student to view��$��0q�$
��Left=�$��741,427,0,0q�$	��Top=�$��17(�$	��255��$��31���� -   $ phone_st_infor��$��Select student to view��$��0q�$
��Left=�$��741,469,0,0q�$	��Top=�$��17(�$	��255��$��31���� -   $��btnViewScore��$��0q�$
��Left=�$��928,549,0,0q�$	��Top=�$��90��{�.  .���� $ 
Horizontal=�.+��� $��img/icons/viewscore.png��$��-2,0,0,0q�$��25��$��25���� $��2,0,0,0q�$��20���� $�Score���� $��Class:��$
��Left=�$��596,382,0,0q�$	��Top=�$��17(�$
��Bold"�$��88���� -   $ nameclass_st_infor��$��Select student to view��$��0q�$
��Left=�$��741,384,0,0q�$	��Top=�$��17(�$	��255��$��31���� $��School Year:��$
��Left=�$��596,505,0,0q�$	��Top=�$��17(�$
��Bold"�$	��140���� -   $ yearSchool_st_infor��$��Select student to view��$��0q�$
��Left=�$��742,505,0,0q�$	��Top=�$��17(�$	��254��$��33���� -   $��
btn_Search��$��Search��$
��Left=�$��
786,32,0,0q�$	��Top=�$��75��