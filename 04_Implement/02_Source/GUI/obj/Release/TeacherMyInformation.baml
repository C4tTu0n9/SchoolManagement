   M S B A M L   `   `   `  ���� >  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI      GUI.TeacherMyInformation   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  localclr-namespace:GUI  -     N� Title$  Teacher Information��.��?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -     Name$ TrainsitionigContentSlide��C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *Fadein+   Duration$ 0:0:0.5X�.��� $��0,4,0,0q�.+��� $"��img/icons/teacher_avatar.png��$��114,150,664,0q�$��Center=�$	��Top=�$	��250��$	��250���� $	��ID:��$
��Left=�$��422,206,0,0q�$	��Top=�$��20(�$
��Bold"�$	��128��$��34���� $��Date of birth:��$
��Left=�$��422,246,0,0q�$	��Top=�$��20(�$
��Bold"��� $��Gender:��$
��Left=�$��422,330,0,0q�$	��Top=�$��20(�$
��Bold"��� $��Email:��$
��Left=�$��422,288,0,0q�$	��Top=�$��20(�$
��Bold"��� $��Phone Number:��$
��Left=�$��422,372,0,0q�$	��Top=�$��20(�$
��Bold"��� -   $��id_tc_infor�� �� CharacterCasing$ Upper=�$��0q� �� 
IsReadOnly . $��leonguyentetc��$
��Left=�$��634,206,0,0q�$	��Top=�$��20(��� -   $��birthofday_tc_infor��$��0q� . $��
16.08.1998��$
��Left=�$��634,246,0,0q�$	��Top=�$��20(��� -   $��email_tc_infor��$��0q� . $"��1612556@teacher.hcmus.edu.vn��$
��Left=�$��634,290,0,0q�$	��Top=�$��20(��� -   $��gender_tc_infor��{�.  $��0q� �� 
IsReadOnly .  �� Text$
 MALE��$	��100��$
��Left=�$��634,332,0,0q�$	��Top=�$��20(�.@���  �� 
IsSelected . .��	(Empty)�� .��Male�� .��Female�� -   $��phone_tc_infor��$��0q� . $��
0399029922��$
��Left=�$��634,374,0,0q�$	��Top=�$��20(��� 
��� ���$
��Left=�$��55��$��	0,536,0,0q�$	��Top=�$
��1028���� -   $��btnEdit��$��0q�$
��Left=�$��948,545,0,0q�$	��Top=�$��70��.���� 	 �� Orientation$	 
Horizontal=�.+��� $��img/icons/edit_btn.png��$��-2,0,0,0q�$��25��$��25���� $��2,0,0,0q�$��20���� $
�Edit���� -	   
 ��Name$
 	btnCancel��$y�	Collapsed=�$��0q�$
��Left=�$��868,545,0,0q�$	��Top=�$��75�����	#FFF32121���	#FFF32121.���� $	 
Horizontal=�.+��� $��img/icons/remove_btn.png��$��-2,0,0,0q�$��25��$��25���� $��2,0,0,0q�$��20���� $�Cancel���� -
   $��btnDoneOfEdit��$��0q�$
��Left=�$��948,545,0,0q�$	��Top=�$��70��$y�	Collapsed=�.���� $	 
Horizontal=�.+��� $��img/icons/done_btn.png��$��-2,0,0,0q�$��25��$��25���� $��2,0,0,0q�$��20���� $
�Done���� $	��I'm��$
��Left=�$��422,128,0,0q�$	��Top=�$��36(�$
��Bold"�$��72��$��54���� -    ��Name$ fullname_tc_infor��$ Upper=�$��0q� . $��
LEO NGUYEN��$
��Left=�$��494,128,0,0q�$	��Top=�$��36(�$
��Bold"�$��54��