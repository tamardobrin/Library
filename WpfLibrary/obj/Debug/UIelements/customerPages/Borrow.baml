   M S B A M L   `   `   `  ????E  AWpfLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WpfLibrary.UIelementsWpfLibrary.UIelements  5      B >BookLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null2&clr-namespace:BookLib;assembly=BookLibBookLib 6@   "    WpfLibrary.UIelements.Borrow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:WpfLibrary.UIelements     5      9local1&clr-namespace:BookLib;assembly=BookLib     6@     ? DataContext  5	      ??    Locator ?? Source# [   ?? Path$ filterViewModel?.??5      ? -   5         ?Name$
 grid??5       ? ColumnDefinitions 5   
   ?? 5      $
??227* ?6   6.   ?? 5      $
??350* ?6   6.   ?? 5      $
??223* ?6   6.    ? RowDefinitions 5   
   ?? 5      $	??43* ?6   6+   ?? 5      $
??407* ?6   6,   .+?5   
   ?? $??Show All??6   $??1??6$   $??0??61   $??50??6A   $	??100??6M   $??Bottom=?6Y   $??	0,0,0,100q?6t   ??6?   ?? *ShowAllCommand+?? 5   
   $??Your Shopping chart:??6   $??2??61   $??25(?6A   $
??Bold"?6O   $??1??6a   $??Center=?6n   
???????6?   ?? 5   
   $??1??6   $??2??6   $??50??6.   $	??200??6:   $??End Shop??6F   $??Bottom=?6Y   ??6t   ?? *EndShopCommand+6?   ?? 5   
   -   5         ??Name$ lv??5   ?   
?????? $	??500??6,   
???   ?$
??Bold"?6L   $??1??6^   $??30(?6k   $??Center=?6y   $??Center=?6?   $??1??6?   ??6?   ?? *CurrentList+ ?? Mode$ TwoWay=? ?? SelectedItem 6   ?? *SelectedItem+	 ?? View	 5      ?? 5      .P?5      ?? $
??Name??6%   
 ?? Width$	
 200??64    ?? DisplayMemberBinding 6@   ?? *Name+?? 5      $??Price??6%   $	
 100??64    6@   ?? *Price+5      5      ?? 5    
   -   5        $
 sclv??5       $	??500??6G   $	??200??6T   $??2??6`   $??1??6p    ?? DisplayMemberPath$
 Name??6}   
?????? 
???????$??20(?6?   $
??Bold"?6?   ??6!   ?? *ShoppingChart+ ?? SelectedIndex 6?   ?? *IndexToDelete+6  ?? 5"   
   $??Filter by genres:??6   $??20(?6,   
???????$
??Bold"?6M   $??1??6_   $
??Left=?6m   $	??Top=?6?   $??0,50,0,0q?6?   ?? 5#   
   -   5         ??Name$ 	cmbGenres??5#      $??1??6&   $??Right=?63   $	??Top=?6P   $	??120??6h   $??0,50,0,0q?6?    6t   ?? *SelectedCategory+ 6?   ?? *SelectedIndexCategory+$ TwoWay=?6?   ?? 5$   
   $??Filter by author:??6   
???????$??20(?6?   $
??Bold"?6M   $??1??6_   $
??Left=?6l   $	??Top=?6?   $??	0,100,0,0q?6?   ?? 5%   
   -   5        $ 	cmbAuthor??5%      $??1??6&   $??Right=?63   $	??Top=?6O   $	??120??6g   $??	0,100,0,0q?6s    6?   ?? *SelectedAutor+ 6?   ?? *SelectedIndexAutor+$ TwoWay=???6?   ?? *
AutorsList+?? 5&   
   $??Filter by price:??6   
???????$??20(?6>   $
??Bold"?6L   $??1??6^   $
??Left=?6k   $	??Top=?6?   $??	0,150,0,0q?6?   ?? 5'   
   -   5        $ cmbPrice??5'      $??Right=?6%   $??1??6A   $	??Top=?6O   $	??120??6g   $??	0,150,0,0q?6s    6?   ?? *PriceCmbSelection+ 6?   ?? *SelectedIndexPrice+$ TwoWay=?.@?5(      ?? $??sort by low to high??6   6;   5)      ??5,   
   ?? 5-       ?? ImageSource$" /Images/borrowbackground.jpg??6   5/      50      