   M S B A M L   `   `   `  ���� >  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI      GUI.AdminCreateUser   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  localclr-namespace:GUI    N� Title$  Create User��.��?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -     Name$ TrainsitionigContentSlide��C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *Fadein+   Duration$ 0:0:0.5X�.��� $��0,4,0,0q�.+��� $"��img/icons/adduser_avatar.png��$��60,150,718,0q�$��Center=�$	��Top=�$	��250��$	��250���� $	��ID:��$
��Left=�$��365,205,0,0q�$	��Top=�$��20(�$
��Bold"�$	��128��$��34���� $��Date of birth:��$
��Left=�$��365,320,0,0q�$	��Top=�$��20(�$
��Bold"��� $��Gender:��$
��Left=�$��365,400,0,0q�$	��Top=�$��20(�$
��Bold"��� $��Email:��$
��Left=�$��365,360,0,0q�$	��Top=�$��20(�$
��Bold"��� $��Phone Number:��$
��Left=�$��365,444,0,0q�$	��Top=�$��20(�$
��Bold"��� -   $��
id_adduser��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter ID here�� �� CharacterCasing$ Upper=�$��0q�$
��Left=�$��577,205,0,0q�$	��Top=�$��20(�$	��285���� -   $��birthofday_adduser��$ Enter BOD here��$��0q�$
��Left=�$��577,322,0,0q�$	��Top=�$��20(�$	��285���� -   $��email_adduser��$ Enter email here��$��0q�$
��Left=�$��577,362,0,0q�$	��Top=�$��20(�$	��285���� -   $��gender_adduser��$ Enter gender here��$��0q�$
��Left=�$��577,402,0,0q�$	��Top=�$��20(�$	��285��.@���  �� 
IsSelected . .��	(Empty)�� .��Male�� .��Female�� -   $��phone_adduser��$ Enter phone number here��$��0q�$
��Left=�$��577,446,0,0q�$	��Top=�$��20(�$	��285���� 
��� ���$
��Left=�$��55��$��	0,536,0,0q�$	��Top=�$
��1028���� -   $��btnDoneOfAddUser��$��0q�$
��Left=�$��948,545,0,0q�$	��Top=�$��70��.����  �� Orientation$ 
Horizontal=�.+��� $��img/icons/done_btn.png��$��-2,0,0,0q�$��25��$��25���� $��2,0,0,0q�$��20���� $
�Done���� -    ��Name$ 	btnCancel��$��0q�$
��Left=�$��868,545,0,0q�$	��Top=�$��75�����	#FFF32121���	#FFF32121.���� $ 
Horizontal=�.+��� $��img/icons/remove_btn.png��$��-2,0,0,0q�$��25��$��25���� $��2,0,0,0q�$��20���� $�Cancel���� $��Create user��$
��Left=�$��
365,80,0,0q�$	��Top=�$��36(�$
��Bold"�$	��198��$��51���� $��to continue to system��$
��Left=�$	��Top=�$
��Left=�$��365,126,0,0q�$	��Top=�$��18(�$	��198��$��35���� $��Password��$
��Left=�$��365,280,0,0q�$	��Top=�$��20(�$
��Bold"�G� -	   	 G�Name$	 password_adduser��$ Enter password here��$��0q�$
��Left=�$��577,280,0,0q�$	��Top=�$��20(�$	��185��$��37��G� -
   $	 passwordconfirm_adduser��$ Confirm��$��0q�$
��Left=�$��797,280,0,0q�$	��Top=�$��20(�$	��186��$��37���� -   
 ��Name$
 
chooseYear��$��15(�$��Center=�$��712,167,166,387q�$��33���� $��Year:��$
��Left=�$��631,166,0,0q�$	��Top=�$��20(�$
��Bold"�$��81��$��34���� $��
Full name:��$
��Left=�$��365,240,0,0q�$	��Top=�$��20(�$
��Bold"�$	��128��$��34���� -    ��Name$ fname_adduser��$ Enter full name here��$ Upper=�$��0q�$
��Left=�$��577,240,0,0q�$	��Top=�$��20(�$	��285��