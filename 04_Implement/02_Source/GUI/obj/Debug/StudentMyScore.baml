   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5          GUI.StudentMyScore   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      localclr-namespace:GUI  5      datanamespace:GUI  5	      -   5          N� Title$  Student Score��5       � 	Resources 5         ScoreTemplate �� DataType?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  NameC  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffectD  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension   Duration �� Orientation��%�  &	        �� 5   
   $ MarkDTO��6-   .R�5        $ TrainsitionigContentSlide��62    6U     *SlideInFromLeft+$ 0:0:0.5X�.��5      �� ���#CFE6FF$ 
Horizontal=�6/   $��Center=�6H   $��0,0,0,0q�6e   .+�5      �� $��Center=�6   $��Center=�6:   $��5q�6^   $��35��6j   $	��170��6v   ���#305066$��14(�6�   $
��Bold"�6�   ��6�   �� *Subject.NameSubject+6�   �� 5      $��Center=�6   $��Right=�6:   $��35��6]   $	��103��6i   ���#305066$��14(�6�   ��6�   �� *FirstFifteenMinutesMark+6�   �� 5      $��Center=�6   $��Center=�6:   $��35��6^   $	��103��6j   ���#305066$��14(�6�   ��6�   �� *SecondFifteenMinutesMark+6�   �� 5      $��Center=�6   $
��Left=�6:   $��35��6\   $	��103��6h   ���#305066$��14(�6�   ��6�   �� *ThirdFifteenMinutesMark+6�   �� 5      $��Center=�6   $��Right=�6:   $��35��6]   $	��103��6i   ���#305066$��14(�6�   ��6�   �� *FirstFortyFiveMinutesMark+6�   �� 5      $��Center=�6   $��Center=�6:   $��35��6^   $	��103��6j   ���#305066$��14(�6�   ��6�   �� *SecondFortyFiveMinutesMark+6�   �� 5      $��Center=�6   $
��Left=�6:   $��35��6\   $	��103��6h   ���#305066$��14(�6�   ��6�   �� *ThirdFortyFiveMinutesMark+6�   �� 5      $��Center=�6   $��Center=�6:   $��35��6^   $	��103��6j   ���#305066$��14(�6�   ��6�   �� *SemesterScore+6�   �� 5      $��Center=�6   $��Center=�6:   $��35��6^   $	��103��6j   ���#305066$��14(�6�   ��6�   �� *AverageMark+6�   5      5      5      5      .��5        -   5        $ TrainsitionigContentSlide��5   *    6M     *Fadein+$ 0:0:0.5X�.��5   
   � .+�5       �� $��0,25,0,0q�6   $��Center=�6+   $ 
Horizontal=�6H   $	��Top=�6a   .+�5!      �� $��Center=�6   $��Center=�6<   $��0,0,0,0q�6^   $��14(�6o   $
��Bold"�6}   .��6�   
Subject:6�   �� 5"      -   5        $��chooseSubject��5"   '   $	��170��6   $��14(�6]   5#      �� 5$      $��Center=�6   $��Center=�6=   $��20,0,0,0q�6_   $��14(�6q   $
��Bold"�6   .��6�   Grade:6�   �� 5%      -   5        $��
chooseYear��5%   &   $��70��6   $��14(�68   5'      �� 5(      $��Center=�6   $��Center=�6=   $��20,0,0,0q�6_   $��14(�6q   $
��Bold"�6   .��6�   	Semester:6�   �� 5)      -   5        $��chooseSemester��5)   &   $��40��6   $��14(�6<   .@�5*      �� $��14(�6#    �� 
IsSelected . .��6C   I6F   �� 5+      $��14(�6#   .��61   II65   5,      5-      �� 5.      $��0,80,0,0q�6   �� 5/      $ 
Horizontal=�6   $	��Top=�62   .+�50      �� $��35,0,0,0q�6    �� CornerRadius$ 20��6-   $��40��6?   
��� ���._�51      �� ���#fff$
��Bold"�6.   $��Center=�6@   $��Center=�6b   $	��115��6�   $��14(�6�   .��6�   	Subject6�   52      �� 53      $��55,0,0,0q�6   $ 20��6-   
��� ���._�54      �� ���#fff$
��Bold"�6.   $��Center=�6@   $��Center=�6b   $	��260��6�   $��14(�6�   .��6�   
15 minutes6�   55      �� 56      $��43,0,0,0q�6   $ 20��6-   
��� ���._�57      �� ���#fff$
��Bold"�6.   $��Center=�6@   $��Center=�6b   $	��260��6�   $��14(�6�   .��6�   
45 minutes6�   58      �� 59      $��42,0,0,0q�6   $ 20��6-   
��� ���._�5:      �� ���#fff$
��Bold"�6.   $��Center=�6@   $��Center=�6b   $��75��6�   $��14(�6�   .��6�   
Semester6�   5;      �� 5<      $��30,0,0,0q�6   $ 20��6-   
��� ���._�5=      �� ���#fff$
��Bold"�6.   $��Center=�6@   $��Center=�6b   $��75��6�   $��14(�6�   .��6�   	Average6�   5>      5?      5@      �� 5A      -   5        $
��test��5A   *   $��	0,130,0,0q�6   #��[  66   5B      5C      5D      5E      