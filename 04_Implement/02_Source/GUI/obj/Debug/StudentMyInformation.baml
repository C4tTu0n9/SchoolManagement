   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5          GUI.StudentMyInformation   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      localclr-namespace:GUI  5      -   5          N� Title$  Student Information��5
      .��5      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TrainsitionigContentSlide��5   *   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6M   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *Fadein+   Duration$ 0:0:0.5X�.��5   
   � $��0,4,0,0q�6   .+�5      �� $"��img/icons/student_avatar.png��6   $��114,150,664,0q�6:   $��Center=�6Q   $	��Top=�6n   $	��250��6�   $	��250��6�   �� 5      $	��ID:��6   $
��Left=�6#   $��422,206,0,0q�6>   $	��Top=�6S   $��20(�6k   $
��Bold"�6y   $	��128��6�   $��34��6�   �� 5      $��Date of birth:��6   $
��Left=�6.   $��422,246,0,0q�6I   $	��Top=�6^   $��20(�6v   $
��Bold"�6�   �� 5      $��Gender:��6   $
��Left=�6'   $��422,330,0,0q�6B   $	��Top=�6W   $��20(�6o   $
��Bold"�6}   �� 5      $��Email:��6   $
��Left=�6&   $��422,288,0,0q�6A   $	��Top=�6V   $��20(�6n   $
��Bold"�6|   �� 5      $��Phone Number:��6   $
��Left=�6-   $��422,372,0,0q�6H   $	��Top=�6]   $��20(�6u   $
��Bold"�6�   �� 5      -   5        $��id_st_infor��5   i    �� CharacterCasing$ Upper=�6   $��0q�6.    �� 
IsReadOnly . $��leonguyentest��6T   $
��Left=�6|   $��634,206,0,0q�6�   $	��Top=�6�   $��20(�6�   �� 5      -   5        $��birthofday_st_infor��5   N   $��0q�6    . $��
16.08.1998��6<   $
��Left=�6i   $��634,246,0,0q�6�   $	��Top=�6�   $��20(�6�   �� 5      -   5        $��email_st_infor��5   `   $��0q�6    . $"��1612556@student.hcmus.edu.vn��6<   $
��Left=�6w   $��634,290,0,0q�6�   $	��Top=�6�   $��20(�6�   �� 5      -   5        $��gender_st_infor��5   w   {�.  $��0q�6)    �� 
IsReadOnly .  �� Text$
 MALE��6O   $
��Left=�6\   $��634,332,0,0q�6�   $	��Top=�6�   $	��100��6�   $��20(�6�   .@�5      ��  �� 
IsSelected . .��61   	(Empty)6:   �� 5      .��6   Male6%   �� 5      .��6   Female6'   5      �� 5      -   5        $��phone_st_infor��5   j   $��0q�6    . $��
0399029922��6<   $
��Left=�6O   $��634,374,0,0q�6�   $	��Top=�6�   $��20(�6�   �� 5      
��� ���$
��Left=�6&   $��55��6A   $��	0,536,0,0q�6M   $	��Top=�6`   $
��1028��6x   �� 5      -   5        $��btnEdit��5   !   $��0q�6   $
��Left=�60   $��948,545,0,0q�6K   $	��Top=�6`   $��70��6x   .��5      �� 	 �� Orientation$	 
Horizontal=�6   .+�5      �� $��img/icons/edit_btn.png��6   $��-2,0,0,0q�6<   $��25��6N   $��25��6Z   6g   �� 5       $��2,0,0,0q�6    $��20��61   �� 6>   $
�Edit��6B   6Q   5!      5"      �� 5$      -	   5        $��btnDoneOfEdit��5$   !   $��0q�6   $
��Left=�66   $��948,545,0,0q�6Q   $	��Top=�6f   $��70��6~   $y�	Collapsed=�6�   .��5%      �� $	 
Horizontal=�6   .+�5&      �� $��img/icons/done_btn.png��6   $��-2,0,0,0q�6<   $��25��6N   $��25��6Z   6g   �� 5'      $��2,0,0,0q�6    $��20��61   �� 6>   $
�Done��6B   6Q   5(      5)      �� 5*      $	��I'm��6   $
��Left=�6#   $��422,128,0,0q�6>   $	��Top=�6S   $��36(�6k   $
��Bold"�6y   $��72��6�   $��54��6�   �� 5+      -
   5        
 ��Name$
 fullname_st_infor��5+   f   $ Upper=�6   $��0q�6.    . $��
LEO NGUYEN��6T   $
��Left=�6�   $��494,128,0,0q�6�   $	��Top=�6�   $��36(�6�   $
��Bold"�6�   $��54��6�   �� 5,      -   5         ��Name$ 	btnCancel��5,   8   $y�	Collapsed=�6   $��0q�6,   $
��Left=�6K   $��868,545,0,0q�6f   $	��Top=�6{   $��75��6�   ���	#FFF32121���	#FFF32121.��5-      �� $	 
Horizontal=�6   .+�5.      �� $��img/icons/remove_btn.png��6   $��-2,0,0,0q�6>   $��25��6P   $��25��6\   �� 5/      $��2,0,0,0q�6    $��20��61   �� 6>   $�Cancel��6B   6S   50      51      53      54      55      