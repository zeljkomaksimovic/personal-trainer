   M S B A M L   `   `   `  ����R  Nzeljkonrt7514_diplomski, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:zeljkonrt7514_diplomskizeljkonrt7514_diplomski  5   	   (    "zeljkonrt7514_diplomski.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:zeljkonrt7514_diplomski     5   	   -   5          � Title$  Licni Trener��5   	   $	��700��6   $
��1100��6+    � WindowStyle$
 None=�68    � AllowsTransparency . ���	#FFFBFBFB � 
ResizeMode$ CanResizeWithGrip=�6�   .��5	      � -   5         �Name$ MainWindowGrid��5	      ��5
   
   �� 5       �� 
StartPoint$ 0.5,1&�6"    �� EndPoint$ 0.5,0&�65   .��5      �  � Color$ 	#FFC0AFCF��6   � 5      $ 	#FFF9F8FA��6    � Offset$ 0.844Q�61   5      .+�5   
   �� -   5        	 ��Name$	 	lblSingIn��5      $��SIGN IN��6#   $
��Left=�65   $��805,108,0,0q�6P   $	��Top=�6e   $9��3/zeljkonrt7514_diplomski;component/Font/#Lato Black)�6}   $��42��6�   $	��104��6�   $��24(�6�   ���	#FF51326A6�   �� 5   
   -   5        
 ��Name$
 txtPassword��5       �� TextWrapping$
 Wrap=�6'   $��Password��6;   $��733,327,117,346q�6K      TextBoxRegistrationPage#��[  6d   6�   �� 5   
   -   5        $
 txtUsername��5      $
 Wrap=�6'   $��Username��6;   $��733,282,117,0q�6K   #��[  6b   6�   �� 5   
   -   5         ��Name$ btnLogIn��5      $��Log In��6#   $��765,419,153,238q�64     LoginRegisterButton#��[ 6M   6z   �� 5   
   -   5        $ btnRegister��5      $��Sign Up��6&    �� Left$	 816��69   
 �� Top$	 512��6K   #��[ 6\   $��765,511,153,146q�6�    � Triggers 5      :� 5       :� RoutedEvent$ Button.Click��6   .[�5      ��   LogInAnimation#��[ 6'   6V   5      5      �� 5   
   -   5        $	 lblOr��5      $��OR��6   $
��Left=�6,   $��840,473,0,0q�6G   $	��Top=�6\   $9��3/zeljkonrt7514_diplomski;component/Font/#Lato Black)�6t   $��28��6�   $��35��6�   $��16(�6�   ���	#FF51326A6�   �� 5   
   -	   5        $	 	lblSingUp��5      $��SIGN UP��6#   $
��Left=�65   $��
184,31,0,0q�6P   $	��Top=�6d   $9��3/zeljkonrt7514_diplomski;component/Font/#Lato Black)�6|   $��42��6�   $	��104��6�   $��24(�6�   ���	#FF51326A J� Opacity$ 0Q�6�   �� 5   
   -
   5        $
 txtPasswordSingUp��5      $
 Wrap=�6-   $��Password��6A   $��115,152,735,0q�6Q   #��[  6h   $ 0Q�6�   �� 5   
   -   5        $
 txtUsernameSingUp��5      $
 Wrap=�6-   $��Username��6A   $��115,103,735,0q�6Q   #��[  6h   $ 0Q�6�   G� 5    
   -   5         G�Name$ pbPasswordSingUp��5       $��115,152,735,0q�60     PasswordBoxStyle#��[ 6G   $y�Hidden=�6q   6�   G� 5!   
   -   5        $ 
pbPassword��5!      $��733,327,117,346q�6*   #��[ 6C   $y�Hidden=�6m   6�   �� 5"   
   -   5        $
 txtImePrezime��5"      $
 Wrap=�6)   $��Ime i Prezime��6=   $��115,202,735,0q�6R   #��[  6i   $ 0Q�6�   �� 5#   
   -   5        $
 	txtVisina��5#      $
 Wrap=�6%   $��Visina��69   $��115,250,735,0q�6G   #��[  6^   $ 0Q�6�   �� 5$   
   -   5        $
 	txtTezina��5$      $
 Wrap=�6%   $��Tezina��69   $��115,298,735,0q�6G   #��[  6^   $ 0Q�6�   �� 5%   
   -   5        $
 	txtGodine��5%      $
 Wrap=�6%   $��Godine��69   $��115,350,735,0q�6G   #��[  6^   $ 0Q�6�   �� 5&   
   -   5         ��Name$ cbAktivnost��5&      $
��Left=�6(   $	��Top=�6C   $	��250��6[   $��115,399,0,0q�6g     ComboBoxStyle#��[ 6|   $ 0Q�6�   �� 5'   
   -   5         ��Name$ 
stackRbPol��5'      $
��Left=�6)   $��30��6D   $	��Top=�6P   $��87��6h   $��115,441,0,0q�6s   $ 0Q�6�   .+�5(      	� -   5         	�Name$ rbMusko��5(      $��Musko��6+   $	��Top=�6;     LoginRadioButton#��[ 6S   $
��Left=�6}   $��55��6�   	� 5)      -   5        $ rbZensko��5)      $��Zensko��6,   $
��Left=�6=   $	��Top=�6X   #��[ 6p   5*      �� 5+   
   -   5        $ stackRbKilaza��5+      $
��Left=�6,   $��35��6G   $	��Top=�6S   $��99��6k   $	 272��6v   $	 356��6�   $��266,441,0,0q�6�   $ 0Q�6�   .+�5,      	� -   5        $ 	rbPovecaj��5,      $��Povecam kilazu��6-   $
��Left=�6F   $	��Top=�6a   $��16��6y   $��	0,0,-18,0q�6�   $	��105��6�   #��[ 6�   	� 5-      -   5        $ rbSmanji��5-      $��Smanjim kilazu��6,   $
��Left=�6E   $	��Top=�6`   #��[ 6x   5.      �� 5/   
   -   5        $ 
btnLogInSU��5/      $��Log In��6%   $��149,612,769,45q�66   #��[ 6N   $ 0Q�6{    50      :� 51      $ Button.Click��6   .[�52      ��   SingUpAnimation#��[ 6'   6W   53      55      �� 56   
   -   5        $ btnRegisterSingUp��56      $��Sign Up��6,   $	 816��6?   $	 512��6Q   #��[ 6b   $��149,520,769,137q�6�   $ 0Q�6�    57      :� 58      $ Button.Click��6   .[�59      �� #��[ 6'   6V   5:      5<      �� 5=   
   -   5        $	 lblOrSU��5=      $��OR��6!   $
��Left=�6.   $��226,574,0,0q�6I   $	��Top=�6^   $9��3/zeljkonrt7514_diplomski;component/Font/#Lato Black)�6v   $��28��6�   $��35��6�   $��16(�6�   ���	#FF51326A$ 0Q�6�   �� 5?   
   $
��Left=�6   $	��700��6,   $	��Top=�69   $
��1192��6Q   $��-48,0,-44,0q�6^   .+�5@      �� -   5         ��Name$ 
rectPomeri��5@      $
��Left=�6,   $	��701��6G   $	��Top=�6T   $	��602��6l   $ -1��6x   $ 48��6�   ��5A      �� 5B       �� ImageSource$ Image/startscreen_bg.jpg��6!   5D      �� 5E      -   5         ��Name$ tbLicniTrener��5E      $
��Wrap=�6/   $	 138��6C   $	 274��6U   $��74��6f   $	��452��6r   $��60(�6~   ���	#FFECECEC$3��-/zeljkonrt7514_diplomski;component/Font/#Lato)�6�   �� 5F      $	�LIC��6   �� 6#   $�	NI TRENER��6'   �� 6:   �� 6F   6M   �� 5G      -   5        $ tbLicniTrenerText��5G      $
��Wrap=�63   $����LICNI TRENER je  besplatan brojac kalorija koji umesto vas kalkulise i prati koliko ste hranljivih materija uneli u organizam.  Ova aplikacija ce vam pomoci da preuzmete kontrolu nad svojim treningom nudeci veliki izbor vezbackih rutina. ��6G   $	 114��6=  $	 350��6O  $��84��6`  $	��452��6l  $��14(�6x  ���	#FFECECEC$3��-/zeljkonrt7514_diplomski;component/Font/#Lato)�6�  �� 5H      -   5         ��Name$ imgLogo��5H      $
��Left=�6%   $	��139��6@   $	��Top=�6M   $	��152��6e   $��Image/menu_icon/logo.png��6q   $	 255��6�   $	 110��6�   5I       � 5J   
   -    5          �Name$ frmMain��5J        � NavigationUIVisibility$ Hidden=�6!   �� 5K   
   $
��Left=�6   $��19��60   $	��Top=�6<   $��68��6T    �� Orientation$ 
Horizontal=�6_   $��
1025,7,0,0q�6x   .+�5L      �� -!   5        $ btnTray��5L      $��Button��6&   $��0,0,0,0q�67     TabButtonStyle#��[ 6H   
 � Tag$ 2��6�   ��5M      �� 5N      $" Image/tab_icon/tray_icon.png��6!    j� Stretch$ Uniform=�6L   5P      �� 5Q      -"   5        $ btnMaximaze��5Q      $��Button��6*   $��5,0,0,0q�6;   #��[ 6L   $ 1��6�   ��5R      �� 5S      $&  Image/tab_icon/maximize_icon.png��6!   $ Uniform=�6P   5U      �� 5V      -#   5        $ btnExit��5V      $��Button��6&   $��5,0,0,0q�67   #��[ 6H   $ 0��6�   ��5W      �� 5X      $" Image/tab_icon/exit_icon.png��6!   $ Uniform=�6L   5Z      5[      G� 5\   
   -$   5        $ pbTest��5\      $
��Left=�6&   $	��Top=�6A   $	��180��6Y   $��410,505,0,0q�6e   $��49��6z   $y�Hidden=�6�   5]      5^      