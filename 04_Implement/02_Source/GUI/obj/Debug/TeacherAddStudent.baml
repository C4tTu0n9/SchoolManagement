   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5          GUI.TeacherAddStudent   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      localclr-namespace:GUI  5        N� Title$  Add Student��5
      .��5      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TrainsitionigContentSlide��5   *   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6M   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *Fadein+   Duration$ 0:0:0.5X�.��5   
   � $��0,4,0,0q�6   .+�5      �� $%��img/icons/addstudent_avatar.png��6   $��60,150,718,0q�6=   $��Center=�6S   $	��Top=�6p   $	��250��6�   $	��250��6�   �� 5      $	��ID:��6   $
��Left=�6"   $��365,205,0,0q�6=   $	��Top=�6R   $��20(�6j   $
��Bold"�6x   $	��128��6�   $��34��6�   �� 5      $��Date of birth:��6   $
��Left=�6.   $��365,316,0,0q�6I   $	��Top=�6^   $��20(�6v   $
��Bold"�6�   �� 5      $��Gender:��6   $
��Left=�6'   $��365,396,0,0q�6B   $	��Top=�6W   $��20(�6o   $
��Bold"�6}   �� 5      $��Email:��6   $
��Left=�6&   $��365,356,0,0q�6A   $	��Top=�6V   $��20(�6n   $
��Bold"�6|   �� 5      $��Phone Number:��6   $
��Left=�6-   $��365,440,0,0q�6H   $	��Top=�6]   $��20(�6u   $
��Bold"�6�   �� 5      -   5        $��id_addstudent��5   q   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter ID here��6    �� CharacterCasing$ Upper=�6E   $��0q�6]   $
��Left=�6�   $��577,205,0,0q�6�   $	��Top=�6�   $��20(�6�   $	��285��6�   �� 5      -   5        $��birthofday_addstudent��5   Z   $ Enter BOD here��6   $��0q�6F   $
��Left=�6w   $��577,318,0,0q�6�   $	��Top=�6�   $��20(�6�   $	��285��6�   �� 5      -   5        $��email_addstudent��5   \   $ Enter email here��6   $��0q�6H   $
��Left=�6u   $��577,358,0,0q�6�   $	��Top=�6�   $��20(�6�   $	��285��6�   �� 5      -   5        $��gender_addstudent��5   y   $ Enter gender here��6   $��0q�6J   $
��Left=�6^   $��577,398,0,0q�6�   $	��Top=�6�   $��20(�6�   $	��285��6�   .@�5      ��  �� 
IsSelected . .��61   	(Empty)6:   �� 5      .��6   Male6%   �� 5      .��6   Female6'   5      �� 5      -   5        $��phone_addstudent��5   ~   $ Enter phone number here��6   $��0q�6O   $
��Left=�6c   $��577,442,0,0q�6�   $	��Top=�6�   $��20(�6�   $	��285��6�   �� 5      
��� ���$
��Left=�6&   $��55��6A   $��	0,536,0,0q�6M   $	��Top=�6`   $
��1028��6x   �� 5      -   5        $��btnDoneOfAddUser��5   !   $��0q�6   $
��Left=�69   $��948,545,0,0q�6T   $	��Top=�6i   $��70��6�   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5       �� $��img/icons/done_btn.png��6   $��-2,0,0,0q�6<   $��25��6N   $��25��6Z   6g   �� 5!      $��2,0,0,0q�6    $��20��61   �� 6>   $
�Done��6B   6Q   5"      5#      �� 5$      -   5         ��Name$ 	btnCancel��5$   !   $��0q�6   $
��Left=�64   $��868,545,0,0q�6O   $	��Top=�6d   $��75��6|   ���	#FFF32121���	#FFF32121.��5%      �� $ 
Horizontal=�6   .+�5&      �� $��img/icons/remove_btn.png��6   $��-2,0,0,0q�6>   $��25��6P   $��25��6\   �� 5'      $��2,0,0,0q�6    $��20��61   �� 6>   $�Cancel��6B   6S   5(      5)      �� 5*      $��Add student��6   $
��Left=�6+   $��
365,80,0,0q�6F   $	��Top=�6Z   $��36(�6r   $
��Bold"�6�   $	��232��6�   $��51��6�   �� 5+      $��to continue to system��6   $
��Left=�64   $	��Top=�6V   $
��Left=�6v   $��365,126,0,0q�6�   $	��Top=�6�   $��18(�6�   $	��198��6�   $��35��6�   �� 5,      $��Password��6   $
��Left=�6(   $��365,279,0,0q�6C   $	��Top=�6X   $��20(�6p   $
��Bold"�6~   G� 5-      -	   5        	 G�Name$	 password_addstudent��5-   c   $ Enter password here��6   $��0q�6O   $
��Left=�6�   $��577,279,0,0q�6�   $	��Top=�6�   $��20(�6�   $	��185��6�   $��37��6�   G� 5.      -
   5        $ 	 passwordconfirm_addstudent��5.   W   $ Confirm��6   $��0q�6C   $
��Left=�6{   $��797,279,0,0q�6�   $	��Top=�6�   $��20(�6�   $	��186��6�   $��37��6�   �� 5/      -   5        
 ��Name$
 
chooseYear��5/   H   $��15(�6   $��Center=�6%   $��712,167,166,387q�6{   $��33��6�   �� 50      $��Year:��6   $
��Left=�6$   $��631,166,0,0q�6?   $	��Top=�6T   $��20(�6l   $
��Bold"�6z   $��81��6�   $��34��6�   �� 51      $��
Full name:��6   $
��Left=�6)   $��365,245,0,0q�6D   $	��Top=�6Y   $��20(�6q   $
��Bold"�6   $	��128��6�   $��34��6�   �� 52      -   5         ��Name$ fname_addstudent��52   x   $ Enter full name here��6   $ Upper=�6L   $��0q�6d   $
��Left=�6�   $��577,245,0,0q�6�   $	��Top=�6�   $��20(�6�   $	��285��6�   54      55      56      