   M S B A M L   `   `   `  ����A  =Tetris, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TetrisTetris  5   	       Tetris.Help   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Tetris     5   	     � Title$
  Help��5   	   $	��490��6   $	��450��6#   $	��485��6/   $	��450��6?   .��5	      � 
�������$
��auto��6   $
��auto��6+    � RowDefinitions 5
   
   �� 5      $
��auto �6   6-   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   �� $��0��6   $��5,5,5,5q�6!   $��45��62   $��Center=�6>   $��Center=�6[   
��� ���$��35(�6�   TETRIS6�   �� 5   
   $��1��6   $��5,5,5,5q�6!   $��45��62   $��Center=�6>   $��Stretch=�6[   DB1. After choosing button 'No' at Gamestart window, the app closes.�� 6�   0.After choosing button 'Yes' - the game starts.6�   �� 5   
   $��2��6   $��5,5,5,5q�6!   $	��150��62   $��Center=�6?   $��Stretch=�6\   2. Game management:�� 6�   Push button:�� 6�   " 'Left' - to move tetromino left;�� 6�   $"'Right' - to move tetromino right;�� 5      'Up' - to rotate tetromino;�� 6+   -+'Down' - to accelerate tetromino's falling;�� 6c   'P' - to pause the game.�� 6�   31If it was already paused, the game will continue;�� 5   ?   'Space' - to restar the game;6j   �� 5   
   $��3��6   $��5,5,5,5q�6!   $��20��62   $��Center=�6>   $��Stretch=�6[   VT3. User scores 100 points for creating full horizontal line of blocks (tetrominoes).6�   �� 5   
   $��4��6   $��5,5,5,5q�6!   $��40��62   $��Center=�6>   $��Stretch=�6[   TR4. Every 100 scored points level up current level.Tetrominoes falling faster every�� 6�   	new level6�   �� 5   
   $��5��6   $��5,5,5,5q�6!   $��45��62   $��Center=�6>   $��Stretch=�6[   US5. When tetromino can't suit the board ( the bord size is 10 x 20), player lose and�� 6�   the game ends.5      �� 5   
   $��6��6   $��5,5,5,5q�6!   $��Center=�62   $��Bottom=�6O   OM6. When the game is over, GameEnd window whith player's results (gained score�� 6�   and level) is shown.5      5%      5&      