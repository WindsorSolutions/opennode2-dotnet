/ * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  
  
 H E R E   1 . 0   N O D E   F L O W   S C H E M A  
  
 A R C H I V E D   B Y : 	 T K   C o n r a d  
 D A T E : 	 	 	 1 1 / 2 6 / 2 0 0 8  
  
 N O T E S :  
  
 T h i s   i s   b a s e d   u p o n   t h e   N o d e f l o w   d a t a b a s e   w e   c r e a t e d   f o r   N e b r a s k a   i n   J u l y   o f   2 0 0 7 .  
 I t   c o n t a i n s   t h e   s c h e m a   t a b l e s   F R S   2 . 3 ,   T i e r   I I ,   a n d   C A F O   f l o w s .   T h i s   p a r t i c u l a r  
 s c r i p t   w a s   g e n e r a t e d   u s i n g   S Q L   S e r v e r   M a n a g e m e n t   S t u d i o   b a s e d   u p o n   H E R E F L O W _ N E  
 o n   S Q L 1 .  
  
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * /  
  
 / * * * * * *   O b j e c t :     S c h e m a   [ s o u r c e ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 0 9   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . s c h e m a s   W H E R E   n a m e   =   N ' s o u r c e ' )  
 E X E C   s y s . s p _ e x e c u t e s q l   N ' C R E A T E   S C H E M A   [ s o u r c e ]   A U T H O R I Z A T I O N   [ d b o ] '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ X M L _ S t a g i n g _ T a b l e s ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 7   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ X M L _ S t a g i n g _ T a b l e s ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ X M L _ S t a g i n g _ T a b l e s ]  
  
 A S  
  
 S E L E C T  
 T A B L E _ S C H E M A  
 , T A B L E _ N A M E  
 , O R D I N A L _ P O S I T I O N  
 , C O L U M N _ N A M E  
 , D A T A _ T Y P E  
 , C H A R A C T E R _ M A X I M U M _ L E N G T H  
 , N U M E R I C _ P R E C I S I O N  
 , N U M E R I C _ S C A L E  
 , I S _ N U L L A B L E  
 F R O M   I N F O R M A T I O N _ S C H E M A . C O L U M N S  
 W H E R E  
 (  
 T A B L E _ N A M E   L I K E   ' ' C A F O % ' '  
 O R  
 T A B L E _ N A M E   L I K E   ' ' F R S % ' '  
 O R  
 T A B L E _ N A M E   L I K E   ' ' T 2 % ' '  
 )  
 A N D   T A B L E _ S C H E M A   =   ' ' D B O ' '  
 / *  
 O R D E R   B Y  
 T A B L E _ N A M E  
 , O R D I N A L _ P O S I T I O N  
 * / '  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ S U B M I S S I O N ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ S U B M I S S I O N ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ S U B M I S S I O N ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S u b m i s s i o n I d e n t i f i e r ]   [ v a r c h a r ] ( 3 6 )   N U L L ,  
 	 [ S u b m i s s i o n D a t e ]   [ v a r c h a r ] ( 2 5 )   N U L L ,  
 	 [ S u b m i s s i o n S t a t u s ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S u b m i s s i o n M e t h o d ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ S U B M I S S I O N ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ C A F O _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 9 : 5 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ F A C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ C A F O _ F A C ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F a c i l i t y S i t e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ F a c i l i t y A l t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ F a c i l i t y I n f o U R L ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ F a c i l i t y R e g i s t r y I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t a t e F a c i l i t y I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ F a c i l i t y ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ F R S _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 1 : 4 7   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ F A C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ F R S _ F A C ] (  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ F A C _ R E G _ I N D ]   [ v a r c h a r ] ( 2 0 )   N U L L ,  
 	 [ F A C _ S I T E N M ]   [ v a r c h a r ] ( 8 0 )   N O T   N U L L ,  
 	 [ F A C _ S I T E T Y P E _ N M ]   [ v a r c h a r ] ( 4 0 )   N U L L ,  
 	 [ F E D _ F A C ]   [ c h a r ] ( 1 )   N U L L ,  
 	 [ T R I B _ L A N D ]   [ c h a r ] ( 1 )   N U L L ,  
 	 [ T R I B _ L A N D _ N M ]   [ v a r c h a r ] ( 2 0 0 )   N U L L ,  
 	 [ C O N G _ D I S T _ N U M ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ L E G _ D I S T _ N U M ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ H U C _ C D ]   [ v a r c h a r ] ( 8 )   N U L L ,  
 	 [ L O C _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ S U P P L E M _ L O C ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ L O C A L _ N M ]   [ v a r c h a r ] ( 6 0 )   N U L L ,  
 	 [ C N T Y _ S T _ F I P S _ C D ]   [ v a r c h a r ] ( 5 )   N U L L ,  
 	 [ C N T Y _ N M ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ S T _ C D ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ S T _ N M ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ C O _ N M ]   [ v a r c h a r ] ( 4 4 )   N U L L ,  
 	 [ L O C _ Z I P _ C D ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
 	 [ L O C _ D E S C ]   [ v a r c h a r ] ( 2 5 6 )   N U L L ,  
 	 [ D A T A _ S R C _ N M ]   [ v a r c h a r ] ( 5 0 )   N O T   N U L L ,  
 	 [ R E P O R T E D _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
 	 [ S T _ F A C _ S Y S _ A C ]   [ v a r c h a r ] ( 2 0 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ F A C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     U s e r D e f i n e d F u n c t i o n   [ d b o ] . [ u d f s _ P a d L e a d i n g Z e r o e s ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ u d f s _ P a d L e a d i n g Z e r o e s ] ' )   A N D   t y p e   i n   ( N ' F N ' ,   N ' I F ' ,   N ' T F ' ,   N ' F S ' ,   N ' F T ' ) )  
 B E G I N  
 e x e c u t e   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 T K   C o n r a d  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 7 - 1 9  
 - -   D e s c r i p t i o n : 	 P a d s   a   c h a r a c t e r   s t r i n g   w i t h   l e a d i n g   z e r o s  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   F U N C T I O N   [ d b o ] . [ u d f s _ P a d L e a d i n g Z e r o e s ]    
 (  
 	 - -   A d d   t h e   p a r a m e t e r s   f o r   t h e   f u n c t i o n   h e r e  
 	 @ S t r i n g T o P a d   v a r c h a r ( 2 5 5 )  
 , 	 @ N u m b e r O f C h a r s 	 i n t  
 )  
 R E T U R N S   v a r c h a r ( 2 5 5 )  
 A S  
 B E G I N  
 	 - -   D e c l a r e   t h e   r e t u r n   v a r i a b l e   h e r e  
 	 D E C L A R E   @ R e s u l t   v a r c h a r ( 2 5 5 )  
  
 	 - -   A d d   t h e   T - S Q L   s t a t e m e n t s   t o   c o m p u t e   t h e   r e t u r n   v a l u e   h e r e  
  
 	 d e c l a r e   @ n I n t L e n 	 	 i n t  
 	 d e c l a r e   @ N u m b e r T o P a d 	 i n t  
  
 	 - -   R e m o v e   a n y   l e a d i n g   a n d   t r a i l i n g   s p a c e s   f r o m   t h e   s t r i n g   t o   b e   c o n v e r t e d  
  
 	 s e t   @ S t r i n g T o P a d   =   l t r i m ( r t r i m ( @ S t r i n g T o P a d ) )  
  
 	 s e t   @ n I n t L e n   =   l e n ( @ S t r i n g T o P a d )  
  
 	 i f   @ n I n t L e n   >   @ N u m b e r O f C h a r s  
 	 	 s e t   @ N u m b e r T o P a d   =   @ n I n t L e n  
 	 e l s e  
 	 	 s e t   @ N u m b e r T o P a d   =   @ N u m b e r O f C h a r s   -   @ n I n t L e n  
  
 	 S E L E C T   @ R e s u l t   =   r i g h t ( r e p l i c a t e ( ' ' 0 ' ' ,   @ N u m b e r T o P a d )   +   @ S t r i n g T o P a d ,   @ N u m b e r O f C h a r s )  
  
 	 - -   R e t u r n   t h e   r e s u l t   o f   t h e   f u n c t i o n  
 	 R E T U R N   @ R e s u l t  
  
 E N D  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ F R S _ F A C _ D E L ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 1 : 5 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ F A C _ D E L ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ F R S _ F A C _ D E L ] (  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ D E L E T I O N _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
 	 [ S T _ F A C _ S Y S _ A C ]   [ v a r c h a r ] ( 2 0 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ F R S _ F A C _ D E L ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ F A C _ I N D ]   A S C ,  
 	 [ D E L E T I O N _ D A T E ]   A S C ,  
 	 [ S T _ F A C _ S Y S _ A C ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ H E R E _ M a n i f e s t ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 2 : 4 9   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ H E R E _ M a n i f e s t ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ H E R E _ M a n i f e s t ] (  
 	 [ T r a n s a c t i o n I d ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ E n d p o i n t U R L ]   [ v a r c h a r ] ( 5 0 0 )   N O T   N U L L ,  
 	 [ D a t a E x c h a n g e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ I s F a c i l i t y S o u r c e I n d i c a t o r ]   [ c h a r ] ( 1 )   N O T   N U L L ,  
 	 [ S o u r c e S y s t e m N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F u l l R e p l a c e I n d i c a t o r ]   [ c h a r ] ( 1 )   N O T   N U L L ,  
 	 [ C r e a t e d D a t e ]   [ d a t e t i m e ]   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ H E R E _ M a n i f e s t ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ T r a n s a c t i o n I d ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ H E R E _ D o m a i n L i s t ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 2 : 4 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ H E R E _ D o m a i n L i s t ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ H E R E _ D o m a i n L i s t ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ D o m a i n L i s t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ O r i g i n a t i n g P a r t n e r N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ C h a n g e D a t e ]   [ d a t e t i m e ]   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ H E R E _ D o m a i n L i s t ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . i n d e x e s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ H E R E _ D o m a i n L i s t ] ' )   A N D   n a m e   =   N ' I X _ H E R E _ D o m a i n L i s t ' )  
 C R E A T E   U N I Q U E   N O N C L U S T E R E D   I N D E X   [ I X _ H E R E _ D o m a i n L i s t ]   O N   [ d b o ] . [ H E R E _ D o m a i n L i s t ]    
 (  
 	 [ D o m a i n L i s t N a m e ]   A S C ,  
 	 [ O r i g i n a t i n g P a r t n e r N a m e ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 / * * * * * *   O b j e c t :     U s e r D e f i n e d F u n c t i o n   [ d b o ] . [ u d f s _ H E R E _ C o n v e r t D e g r e e s D e c i m a l ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ u d f s _ H E R E _ C o n v e r t D e g r e e s D e c i m a l ] ' )   A N D   t y p e   i n   ( N ' F N ' ,   N ' I F ' ,   N ' T F ' ,   N ' F S ' ,   N ' F T ' ) )  
 B E G I N  
 e x e c u t e   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 C R E A T E   F U N C T I O N   [ d b o ] . [ u d f s _ H E R E _ C o n v e r t D e g r e e s D e c i m a l ]  
 (  
 @ D e g r e e s 	 V A R C H A R ( 4 )  
 , @ M i n u t e s 	 V A R C H A R ( 4 )  
 , @ S e c o n d s 	 V A R C H A R ( 4 )  
 , @ T e n t h S e c 	 V A R C H A R ( 4 )  
 , @ S i g n 	 V A R C H A R ( 1 )  
 )  
  
 R E T U R N S   D E C I M A L ( 1 0 , 6 )  
  
 A S  
 B E G I N  
  
 D E C L A R E   @ D e c i m a l D e g r e e s   D E C I M A L ( 1 0 , 6 )  
  
 I F   I S N U L L ( @ D e g r e e s ,   ' ' 0 ' ' )   =   0  
 	 S E T   @ D e c i m a l D e g r e e s   =   0  
 E L S E  
 	 B E G I N  
 	 	 S E T   @ D e g r e e s   =   A B S ( C O N V E R T ( I N T ,   @ D e g r e e s ) )  
 	 	 S E T   @ M i n u t e s   =   A B S ( C O N V E R T ( I N T ,   @ M i n u t e s ) )  
 	 	 S E T   @ S e c o n d s   =   A B S ( C O N V E R T ( I N T ,   @ S e c o n d s ) )  
 	 	 S E T   @ T e n t h S e c   =   A B S ( C O N V E R T ( I N T ,   @ T e n t h S e c ) )  
  
 	 	 S E T   @ D e c i m a l D e g r e e s   =  
 	 	 	 C O N V E R T ( D E C I M A L ( 1 0 , 6 ) ,   @ S i g n   +   @ D e g r e e s )   +    
 	 	 	 ( C O N V E R T ( D E C I M A L ( 1 0 , 6 ) ,   @ S i g n   +   @ M i n u t e s )   /   6 0 )   +    
 	 	 	 ( C O N V E R T ( D E C I M A L ( 1 0 , 6 ) ,   @ S i g n   +   @ S e c o n d s   +   ' ' . ' '   +   @ T e n t h S e c )   /   3 6 0 0 )  
 	 E N D  
  
 R E T U R N   @ D e c i m a l D e g r e e s  
  
 E N D  
  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ C A F O _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 3 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ C A F O _ F A C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ C A F O _ F A C ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F a c i l i t y S i t e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ F a c i l i t y A l t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ F a c i l i t y I n f o U R L ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ F a c i l i t y R e g i s t r y I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t a t e F a c i l i t y I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ F a c i l i t y ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ S U B M I S S I O N ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 9 : 3 8   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ S U B M I S S I O N ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ S U B M I S S I O N ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S u b m i s s i o n I d e n t i f i e r ]   [ v a r c h a r ] ( 3 6 )   N U L L ,  
 	 [ S u b m i s s i o n D a t e ]   [ v a r c h a r ] ( 2 5 )   N U L L ,  
 	 [ S u b m i s s i o n S t a t u s ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S u b m i s s i o n M e t h o d ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ S U B M I S S I O N ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ L o o k u p _ P R G A C R ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 2 : 5 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ L o o k u p _ P R G A C R ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ L o o k u p _ P R G A C R ] (  
 	 [ I d ]   [ i n t ]   I D E N T I T Y ( 1 , 1 )   N O T   N U L L ,  
 	 [ P R G A C R ]   [ v a r c h a r ] ( 5 0 )   N O T   N U L L ,  
 	 [ A C T I V E ]   [ b i t ]   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ L o o k u p _ P R G A C R ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ I d ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     U s e r D e f i n e d F u n c t i o n   [ d b o ] . [ u d f s _ D a t e O r T i m e X M L ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ u d f s _ D a t e O r T i m e X M L ] ' )   A N D   t y p e   i n   ( N ' F N ' ,   N ' I F ' ,   N ' T F ' ,   N ' F S ' ,   N ' F T ' ) )  
 B E G I N  
 e x e c u t e   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 T K   C o n r a d  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 6 - 2 2  
 - -   D e s c r i p t i o n : 	 C o n v e r t s   d a t e s   t o   X M L   f o r m a t   f o r   d a t e   o r   t i m e  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   F U N C T I O N   [ d b o ] . [ u d f s _ D a t e O r T i m e X M L ]    
 (  
 	 - -   A d d   t h e   p a r a m e t e r s   f o r   t h e   f u n c t i o n   h e r e  
 	 @ D a t e V a l u e   d a t e t i m e  
 	 , @ I s T i m e   b i t  
 )  
 R E T U R N S   v a r c h a r ( 2 5 )  
 A S  
 B E G I N  
 	 - -   D e c l a r e   t h e   r e t u r n   v a r i a b l e   h e r e  
 	 D E C L A R E   @ R e s u l t   v a r c h a r ( 2 5 )  
  
 	 - -   A d d   t h e   T - S Q L   s t a t e m e n t s   t o   c o m p u t e   t h e   r e t u r n   v a l u e   h e r e  
 	 S E L E C T   @ R e s u l t   =   C A S E  
 	 	 W H E N   @ I s T i m e   =   1  
 	 	 T H E N   S U B S T R I N G ( C O N V E R T ( V A R C H A R ,   @ D a t e V a l u e ,   1 2 6 ) , C H A R I N D E X ( ' ' T ' ' ,   C O N V E R T ( V A R C H A R ,   @ D a t e V a l u e ,   1 2 6 ) )   +   1 ,   L E N ( C O N V E R T ( V A R C H A R ,   @ D a t e V a l u e ,   1 2 6 ) ) )  
 	 	 E L S E   S U B S T R I N G ( C O N V E R T ( V A R C H A R ,   @ D a t e V a l u e ,   1 2 6 ) , 1 , C H A R I N D E X ( ' ' T ' ' ,   C O N V E R T ( V A R C H A R ,   @ D a t e V a l u e ,   1 2 6 ) )   -   1 )  
 	 E N D  
 	 - -   R e t u r n   t h e   r e s u l t   o f   t h e   f u n c t i o n  
 	 R E T U R N   @ R e s u l t  
  
 E N D  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ F A C _ G E O ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ F A C _ G E O ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ F A C _ G E O ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ F A C _ G E O . A _ M E A S U R E  
 ,   T 2 _ F A C _ G E O . B _ M E A S U R E  
 ,   T 2 _ F A C _ G E O . S R C _ M A P _ S C A L E _ N U M  
 ,   T 2 _ F A C _ G E O . H O R I Z _ A C C U R _ M E A S U R E _ V A L U E  
 ,   T 2 _ F A C _ G E O . H O R I Z _ A C C U R _ M E A S U R E _ U N I T C D  
 ,   T 2 _ F A C _ G E O . H O R I Z _ A C C U R _ M E A S U R E _ U N I T C D L I S T I D  
 ,   T 2 _ F A C _ G E O . H O R I Z _ A C C U R _ M E A S U R E _ U N I T _ N A M E  
 ,   T 2 _ F A C _ G E O . H O R I Z _ A C C U R _ P R E C _ T X T  
 ,   T 2 _ F A C _ G E O . H O R I Z _ A C C U R _ R E S U L T _ Q U A L _ C D  
 ,   T 2 _ F A C _ G E O . H O R I Z _ A C C U R _ R E S U L T _ Q U A L _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . H O R I Z _ A C C U R _ R E S U L T _ Q U A L _ N M  
 ,   T 2 _ F A C _ G E O . H O R I Z _ C O L L _ M E T H _ I D C O D E  
 ,   T 2 _ F A C _ G E O . H O R I Z _ C O L L _ M E T H _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . H O R I Z _ C O L L _ M E T H _ N A M E  
 ,   T 2 _ F A C _ G E O . H O R I Z _ C O L L _ M E T H _ D E S C  
 ,   T 2 _ F A C _ G E O . H O R I Z _ C O L L _ M E T H _ D E V I A T I O N S  
 ,   T 2 _ F A C _ G E O . R E F _ P O I N T _ C D  
 ,   T 2 _ F A C _ G E O . R E F _ P O I N T _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . R E F _ P O I N T _ N A M E  
 ,   T 2 _ F A C _ G E O . H O R I Z _ R E F _ D A T U M _ C D  
 ,   T 2 _ F A C _ G E O . H O R I Z _ R E F _ D A T U M _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . H O R I Z _ R E F _ D A T U M _ N M  
 ,   T 2 _ F A C _ G E O . D A T A _ C O L L _ D A T E  
 ,   T 2 _ F A C _ G E O . L O C _ C O M M E N T S  
 ,   T 2 _ F A C _ G E O . V E R T _ M E A S U R E _ V A L U E  
 ,   T 2 _ F A C _ G E O . V E R T _ M E A S U R E _ U N I T C D  
 ,   T 2 _ F A C _ G E O . V E R T _ M E A S U R E _ U N I T C D L I S T I D  
 ,   T 2 _ F A C _ G E O . V E R T _ M E A S U R E _ U N I T _ N A M E  
 ,   T 2 _ F A C _ G E O . V E R T _ M E A S U R E _ P R E C _ T X T  
 ,   T 2 _ F A C _ G E O . V E R T _ M E A S U R E _ R E S U L T _ Q U A L _ C D  
 ,   T 2 _ F A C _ G E O . V E R T _ M E A S U R E _ R E S U L T _ Q U A L _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . V E R T _ M E A S U R E _ R E S U L T _ Q U A L _ N A M E  
 ,   T 2 _ F A C _ G E O . V E R T _ C O L L _ M E T H _ I D C O D E  
 ,   T 2 _ F A C _ G E O . V E R T _ C O L L _ M E T H _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . V E R T _ C O L L _ M E T H _ N A M E  
 ,   T 2 _ F A C _ G E O . V E R T _ C O L L _ M E T H _ D E S C  
 ,   T 2 _ F A C _ G E O . V E R T _ C O L L _ M E T H _ D E V I A T I O N S  
 ,   T 2 _ F A C _ G E O . V E R T _ R E F _ D A T U M _ C D  
 ,   T 2 _ F A C _ G E O . V E R T _ R E F _ D A T U M _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . V E R T _ R E F _ D A T U M _ N M  
 ,   T 2 _ F A C _ G E O . V E R I F _ M E T H _ I D C O D E  
 ,   T 2 _ F A C _ G E O . V E R I F _ M E T H _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . V E R I F _ M E T H _ N A M E  
 ,   T 2 _ F A C _ G E O . V E R I F _ M E T H _ D E S C  
 ,   T 2 _ F A C _ G E O . V E R I F _ M E T H _ D E V I A T I O N S  
 ,   T 2 _ F A C _ G E O . C O O R D _ D A T A _ S R C _ C D  
 ,   T 2 _ F A C _ G E O . C O O R D _ D A T A _ S R C _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . C O O R D _ D A T A _ S R C _ N M  
 ,   T 2 _ F A C _ G E O . G E O _ T Y P E _ C D  
 ,   T 2 _ F A C _ G E O . G E O _ T Y P E _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . G E O _ T Y P E _ N M  
 F R O M   c m p . T 2 _ F A C _ G E O   I N N E R   J O I N   c m p . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ G E O . F K _ G U I D   =   T 2 _ F A C _ S I T E . P K _ G U I D )  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ F A C _ I N D _ E M A I L ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ F A C _ I N D _ E M A I L ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ F A C _ I N D _ E M A I L ]  
 A S  
 S E L E C T           c m p . T 2 _ F A C _ S I T E . F a c i l i t y S i t e I d e n t i f i e r ,   c m p . T 2 _ F A C _ I N D _ E M A I L . E l e c t r o n i c A d d r e s s T e x t ,   c m p . T 2 _ F A C _ I N D _ E M A I L . E l e c t r o n i c A d d r e s s T y p e N a m e  
 F R O M                   c m p . T 2 _ F A C _ I N D _ E M A I L   I N N E R   J O I N  
                                             c m p . T 2 _ F A C _ I N D   O N   c m p . T 2 _ F A C _ I N D . P K _ G U I D   =   c m p . T 2 _ F A C _ I N D _ E M A I L . F K _ G U I D   I N N E R   J O I N  
                                             c m p . T 2 _ F A C _ S I T E   O N   c m p . T 2 _ F A C _ S I T E . P K _ G U I D   =   c m p . T 2 _ F A C _ I N D . F K _ G U I D  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ F A C _ I N D _ P H O N E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ F A C _ I N D _ P H O N E ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ F A C _ I N D _ P H O N E ]  
 A S  
 S E L E C T           c m p . T 2 _ F A C _ S I T E . F a c i l i t y S i t e I d e n t i f i e r ,   c m p . T 2 _ F A C _ I N D _ P H O N E . T e l e p h o n e N u m b e r T e x t ,   c m p . T 2 _ F A C _ I N D _ P H O N E . T e l e p h o n e N u m b e r T y p e N a m e ,    
                                             c m p . T 2 _ F A C _ I N D _ P H O N E . T e l e p h o n e E x t e n s i o n N u m b e r T e x t  
 F R O M                   c m p . T 2 _ F A C _ I N D _ P H O N E   I N N E R   J O I N  
                                             c m p . T 2 _ F A C _ I N D   O N   c m p . T 2 _ F A C _ I N D . P K _ G U I D   =   c m p . T 2 _ F A C _ I N D _ P H O N E . F K _ G U I D   I N N E R   J O I N  
                                             c m p . T 2 _ F A C _ S I T E   O N   c m p . T 2 _ F A C _ S I T E . P K _ G U I D   =   c m p . T 2 _ F A C _ I N D . F K _ G U I D  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ F A C _ I N D _ T Y P E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ F A C _ I N D _ T Y P E ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ F A C _ I N D _ T Y P E ]  
 A S  
 S E L E C T           c m p . T 2 _ F A C _ S I T E . F a c i l i t y S i t e I d e n t i f i e r ,   c m p . T 2 _ F A C _ I N D _ T Y P E . C o n t a c t T y p e  
 F R O M                   c m p . T 2 _ F A C _ I N D _ T Y P E   I N N E R   J O I N  
                                             c m p . T 2 _ F A C _ I N D   O N   c m p . T 2 _ F A C _ I N D . P K _ G U I D   =   c m p . T 2 _ F A C _ I N D _ T Y P E . F K _ G U I D   I N N E R   J O I N  
                                             c m p . T 2 _ F A C _ S I T E   O N   c m p . T 2 _ F A C _ S I T E . P K _ G U I D   =   c m p . T 2 _ F A C _ I N D . F K _ G U I D  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ F A C _ N A I C S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 7   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ F A C _ N A I C S ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ F A C _ N A I C S ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ F A C _ N A I C S . N A I C S C o d e  
 ,   T 2 _ F A C _ N A I C S . N A I C S I n d u s t r y C o d e  
 ,   T 2 _ F A C _ N A I C S . N A I C S G r o u p C o d e  
 ,   T 2 _ F A C _ N A I C S . N A I C S S u b s e c t o r C o d e  
 ,   T 2 _ F A C _ N A I C S . N A I C S S e c t o r C o d e  
 F R O M   c m p . T 2 _ F A C _ N A I C S   I N N E R   J O I N   c m p . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ N A I C S . F K _ G U I D   =   T 2 _ F A C _ S I T E . P K _ G U I D ) '  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ F R S _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 6 : 2 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ F A C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ F R S _ F A C ] (  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ F A C _ R E G _ I N D ]   [ v a r c h a r ] ( 2 0 )   N U L L ,  
 	 [ F A C _ S I T E N M ]   [ v a r c h a r ] ( 8 0 )   N O T   N U L L ,  
 	 [ F A C _ S I T E T Y P E _ N M ]   [ v a r c h a r ] ( 4 0 )   N U L L ,  
 	 [ F E D _ F A C ]   [ c h a r ] ( 1 )   N U L L ,  
 	 [ T R I B _ L A N D ]   [ c h a r ] ( 1 )   N U L L ,  
 	 [ T R I B _ L A N D _ N M ]   [ v a r c h a r ] ( 2 0 0 )   N U L L ,  
 	 [ C O N G _ D I S T _ N U M ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ L E G _ D I S T _ N U M ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ H U C _ C D ]   [ v a r c h a r ] ( 8 )   N U L L ,  
 	 [ L O C _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ S U P P L E M _ L O C ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ L O C A L _ N M ]   [ v a r c h a r ] ( 6 0 )   N U L L ,  
 	 [ C N T Y _ S T _ F I P S _ C D ]   [ v a r c h a r ] ( 5 )   N U L L ,  
 	 [ C N T Y _ N M ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ S T _ C D ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ S T _ N M ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ C O _ N M ]   [ v a r c h a r ] ( 4 4 )   N U L L ,  
 	 [ L O C _ Z I P _ C D ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
 	 [ L O C _ D E S C ]   [ v a r c h a r ] ( 2 5 6 )   N U L L ,  
 	 [ D A T A _ S R C _ N M ]   [ v a r c h a r ] ( 5 0 )   N O T   N U L L ,  
 	 [ R E P O R T E D _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
 	 [ S T _ F A C _ S Y S _ A C ]   [ v a r c h a r ] ( 2 0 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ F A C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ F A C _ N P D E S _ I D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 7   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ F A C _ N P D E S _ I D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ F A C _ N P D E S _ I D ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ F A C _ N P D E S _ I D . N P D E S I d e n t i f i c a t i o n N u m b e r  
 F R O M   c m p . T 2 _ F A C _ N P D E S _ I D   I N N E R   J O I N   c m p . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ N P D E S _ I D . F K _ G U I D   =   T 2 _ F A C _ S I T E . P K _ G U I D ) '  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ F R S _ F A C _ D E L ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 6 : 2 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ F A C _ D E L ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ F R S _ F A C _ D E L ] (  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ D E L E T I O N _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
 	 [ S T _ F A C _ S Y S _ A C ]   [ v a r c h a r ] ( 2 0 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ F R S _ F A C _ D E L ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ D E L E T I O N _ D A T E ]   A S C ,  
 	 [ S T _ F A C _ I N D ]   A S C ,  
 	 [ S T _ F A C _ S Y S _ A C ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ F A C _ R C R A _ I D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 7   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ F A C _ R C R A _ I D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ F A C _ R C R A _ I D ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ F A C _ R C R A _ I D . R C R A I d e n t i f i c a t i o n N u m b e r  
 F R O M   c m p . T 2 _ F A C _ R C R A _ I D   I N N E R   J O I N   c m p . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ R C R A _ I D . F K _ G U I D   =   T 2 _ F A C _ S I T E . P K _ G U I D ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ F A C _ S I C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 8   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ F A C _ S I C ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ F A C _ S I C ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ F A C _ S I C . S I C C o d e  
 ,   T 2 _ F A C _ S I C . S I C P r i m a r y I n d i c a t o r  
 F R O M   c m p . T 2 _ F A C _ S I C   I N N E R   J O I N   c m p . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ S I C . F K _ G U I D   =   T 2 _ F A C _ S I T E . P K _ G U I D ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ F A C _ U I C _ I D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 8   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ F A C _ U I C _ I D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ F A C _ U I C _ I D ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ F A C _ U I C _ I D . U I C I d e n t i f i c a t i o n N u m b e r  
 F R O M   c m p . T 2 _ F A C _ U I C _ I D   I N N E R   J O I N   c m p . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ U I C _ I D . F K _ G U I D   =   T 2 _ F A C _ S I T E . P K _ G U I D ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ S U B M I S S I O N ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 9   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ S U B M I S S I O N ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ S U B M I S S I O N ]  
 A S  
 S E L E C T           c m p . T 2 _ F A C _ S I T E . F a c i l i t y S i t e I d e n t i f i e r ,   c m p . T 2 _ S U B M I S S I O N . S u b m i s s i o n D a t e ,   c m p . T 2 _ S U B M I S S I O N . S u b m i s s i o n S t a t u s ,    
                                             c m p . T 2 _ S U B M I S S I O N . S u b m i s s i o n M e t h o d  
 F R O M                   c m p . T 2 _ S U B M I S S I O N   I N N E R   J O I N  
                                             c m p . T 2 _ R E P O R T   O N   c m p . T 2 _ R E P O R T . F K _ G U I D   =   c m p . T 2 _ S U B M I S S I O N . P K _ G U I D   I N N E R   J O I N  
                                             c m p . T 2 _ F A C _ S I T E   O N   c m p . T 2 _ F A C _ S I T E . F K _ G U I D   =   c m p . T 2 _ R E P O R T . P K _ G U I D  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ C H E M _ I N V _ D T L S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ C H E M _ I N V _ D T L S ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ C H E M _ I N V _ D T L S ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ C H E M _ I N V _ D T L S . N u m b e r O f D a y s O n s i t e  
 ,   T 2 _ C H E M _ I N V _ D T L S . M a x i m u m D a i l y A m o u n t  
 ,   T 2 _ C H E M _ I N V _ D T L S . M a x i m u m C o d e  
 ,   T 2 _ C H E M _ I N V _ D T L S . A v e r a g e D a i l y A m o u n t  
 ,   T 2 _ C H E M _ I N V _ D T L S . A v e r a g e C o d e  
 F R O M   c m p . T 2 _ C H E M _ I N V _ D T L S   I N N E R   J O I N   c m p . T 2 _ C H E M _ I N V   O N   ( T 2 _ C H E M _ I N V _ D T L S . F K _ G U I D   =   T 2 _ C H E M _ I N V . P K _ G U I D )   I N N E R   J O I N   c m p . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ S I T E . P K _ G U I D   =   T 2 _ C H E M _ I N V . F K _ G U I D ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ C H E M _ I N V _ H A Z ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ C H E M _ I N V _ H A Z ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ C H E M _ I N V _ H A Z ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ C H E M _ I N V _ H A Z . H a z a r d T y p e  
 F R O M   c m p . T 2 _ C H E M _ I N V _ H A Z   I N N E R   J O I N   c m p . T 2 _ C H E M _ I N V   O N   ( T 2 _ C H E M _ I N V _ H A Z . F K _ G U I D   =   T 2 _ C H E M _ I N V . P K _ G U I D )   I N N E R   J O I N   c m p . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ S I T E . P K _ G U I D   =   T 2 _ C H E M _ I N V . F K _ G U I D ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ C H E M _ I N V _ H L T H ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ C H E M _ I N V _ H L T H ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ C H E M _ I N V _ H L T H ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ C H E M _ I N V _ H L T H . H e a l t h E f f e c t s  
 F R O M   c m p . T 2 _ C H E M _ I N V _ H L T H   I N N E R   J O I N   c m p . T 2 _ C H E M _ I N V   O N   ( T 2 _ C H E M _ I N V _ H L T H . F K _ G U I D   =   T 2 _ C H E M _ I N V . P K _ G U I D )   I N N E R   J O I N   c m p . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ S I T E . P K _ G U I D   =   T 2 _ C H E M _ I N V . F K _ G U I D ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ C H E M _ I N V _ P H Y S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ C H E M _ I N V _ P H Y S ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ C H E M _ I N V _ P H Y S ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ C H E M _ I N V _ P H Y S . C h e m i c a l P h y s i c a l S t a t e  
 F R O M   c m p . T 2 _ C H E M _ I N V _ P H Y S   I N N E R   J O I N   c m p . T 2 _ C H E M _ I N V   O N   ( T 2 _ C H E M _ I N V _ P H Y S . F K _ G U I D   =   T 2 _ C H E M _ I N V . P K _ G U I D )   I N N E R   J O I N   c m p . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ S I T E . P K _ G U I D   =   T 2 _ C H E M _ I N V . F K _ G U I D ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ C H E M _ L O C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ C H E M _ L O C ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ C H E M _ L O C ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ C H E M _ L O C . C o n f i d e n t i a l L o c a t i o n I n d i c a t o r  
 ,   T 2 _ C H E M _ L O C . S t o r a g e T y p e C o d e  
 ,   T 2 _ C H E M _ L O C . S t o r a g e T y p e D e s c r i p t i o n  
 ,   T 2 _ C H E M _ L O C . S t o r a g e L o c T e m p e r a t u r e C o d e  
 ,   T 2 _ C H E M _ L O C . S t o r a g e L o c T e m p e r a t u r e D e s c  
 ,   T 2 _ C H E M _ L O C . S t o r a g e L o c P r e s s u r e C o d e  
 ,   T 2 _ C H E M _ L O C . S t o r a g e L o c P r e s s u r e D e s c  
 ,   T 2 _ C H E M _ L O C . S t o r a g e L o c D e s c r i p t i o n  
 ,   T 2 _ C H E M _ L O C . M a x i m u m A m o u n t A t L o c a t i o n  
 ,   T 2 _ C H E M _ L O C . M e a s u r e m e n t U n i t  
 F R O M   c m p . T 2 _ C H E M _ L O C   I N N E R   J O I N   c m p . T 2 _ C H E M _ I N V   O N   ( T 2 _ C H E M _ L O C . F K _ G U I D   =   T 2 _ C H E M _ I N V . P K _ G U I D )   I N N E R   J O I N   c m p . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ S I T E . P K _ G U I D   =   T 2 _ C H E M _ I N V . F K _ G U I D ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ C H E M _ M I X ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ C H E M _ M I X ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ C H E M _ M I X ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ C H E M _ M I X . C A S N u m b e r  
 ,   T 2 _ C H E M _ M I X . C o m p o n e n t  
 ,   T 2 _ C H E M _ M I X . C o m p o n e n t P e r c e n t a g e  
 ,   T 2 _ C H E M _ M I X . W e i g h t O r V o l u m e  
 F R O M   c m p . T 2 _ C H E M _ M I X   I N N E R   J O I N   c m p . T 2 _ C H E M _ I N V   O N   ( T 2 _ C H E M _ M I X . F K _ G U I D   =   T 2 _ C H E M _ I N V . P K _ G U I D )   I N N E R   J O I N   c m p . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ S I T E . P K _ G U I D   =   T 2 _ C H E M _ I N V . F K _ G U I D ) '  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ C H A N G E D _ F A C I L I T I E S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 0 : 4 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C H A N G E D _ F A C I L I T I E S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ C H A N G E D _ F A C I L I T I E S ] (  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ F L O W _ T Y P E ]   [ v a r c h a r ] ( 5 0 )   N O T   N U L L ,  
 	 [ U P D A T E _ D A T E ]   [ d a t e t i m e ]   N O T   N U L L ,  
 	 [ I S _ D E L E T E D ]   [ b i t ]   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ C H G _ F A C ]   P R I M A R Y   K E Y   N O N C L U S T E R E D    
 (  
 	 [ S T _ F A C _ I N D ]   A S C ,  
 	 [ F L O W _ T Y P E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . i n d e x e s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C H A N G E D _ F A C I L I T I E S ] ' )   A N D   n a m e   =   N ' I X _ C H A N G E D _ F A C I L I T I E S _ U P D A T E _ D A T E ' )  
 C R E A T E   C L U S T E R E D   I N D E X   [ I X _ C H A N G E D _ F A C I L I T I E S _ U P D A T E _ D A T E ]   O N   [ d b o ] . [ C H A N G E D _ F A C I L I T I E S ]    
 (  
 	 [ U P D A T E _ D A T E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ H O R I Z _ C O L L _ M E T H ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 2 : 5 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ H O R I Z _ C O L L _ M E T H ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ H O R I Z _ C O L L _ M E T H ] (  
 	 [ C O L L E C T _ M E T H _ D E S C ]   [ v a r c h a r ] ( 6 0 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ H C M ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ C O L L E C T _ M E T H _ D E S C ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     U s e r D e f i n e d F u n c t i o n   [ d b o ] . [ u d f s _ F o r m a t V a r c h a r ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ u d f s _ F o r m a t V a r c h a r ] ' )   A N D   t y p e   i n   ( N ' F N ' ,   N ' I F ' ,   N ' T F ' ,   N ' F S ' ,   N ' F T ' ) )  
 B E G I N  
 e x e c u t e   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 T K   C o n r a d  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 6 - 2 1  
 - -   D e s c r i p t i o n : 	 S t r i p s   o u t   l e a d i n g   a n d   t r a i l i n g   s p a c e s   a n d   c o n v e r t s   a l l   e m p t y   s t r i n g s   t o   N U L L s  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   F U N C T I O N   [ d b o ] . [ u d f s _ F o r m a t V a r c h a r ]  
 (  
 	 - -   A d d   t h e   p a r a m e t e r s   f o r   t h e   f u n c t i o n   h e r e  
 	 @ I n p u t S t r   v a r c h a r ( 2 5 5 )  
 )  
 R E T U R N S   v a r c h a r ( 2 5 5 )  
 A S  
 B E G I N  
 	 - -   D e c l a r e   t h e   r e t u r n   v a r i a b l e   h e r e  
 	 D E C L A R E   @ R e s u l t   v a r c h a r ( 2 5 5 )  
  
 	 - -   A d d   t h e   T - S Q L   s t a t e m e n t s   t o   c o m p u t e   t h e   r e t u r n   v a l u e   h e r e  
 	 S E L E C T   @ R e s u l t   =   C A S E  
 	 	 W H E N   I S N U L L ( @ I n p u t S t r ,   ' ' ' ' )   =   ' ' ' '   T H E N   N U L L  
 	 	 E L S E   L T R I M ( R T R I M ( @ I n p u t S t r ) )  
 	 	 E N D  
  
 	 - -   R e t u r n   t h e   r e s u l t   o f   t h e   f u n c t i o n  
 	 R E T U R N   @ R e s u l t  
  
 E N D  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     U s e r D e f i n e d F u n c t i o n   [ d b o ] . [ u d f s _ Z i p P l u s ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ u d f s _ Z i p P l u s ] ' )   A N D   t y p e   i n   ( N ' F N ' ,   N ' I F ' ,   N ' T F ' ,   N ' F S ' ,   N ' F T ' ) )  
 B E G I N  
 e x e c u t e   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 T K   C o n r a d  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 6 - 2 1  
 - -   D e s c r i p t i o n : 	 T a k e s   t w o   p a r a m e t e r s ,   Z i p c o d e   a n d   Z i p p l u s .   R e t u r n s   c o r r e c t l y - f o r m a t t e d   z i p c o d e  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   F U N C T I O N   [ d b o ] . [ u d f s _ Z i p P l u s ]    
 (  
 	 - -   A d d   t h e   p a r a m e t e r s   f o r   t h e   f u n c t i o n   h e r e  
 	   @ Z i p c o d e   v a r c h a r ( 2 5 )   =   N U L L  
 	 , @ Z i p p l u s   v a r c h a r ( 2 5 )   =   N U L L  
 )  
 R E T U R N S   v a r c h a r ( 2 5 )  
 A S  
 B E G I N  
 	 - -   D e c l a r e   t h e   r e t u r n   v a r i a b l e   h e r e  
 	 D E C L A R E   @ R e s u l t   v a r c h a r ( 2 5 )  
  
 	 - -   A d d   t h e   T - S Q L   s t a t e m e n t s   t o   c o m p u t e   t h e   r e t u r n   v a l u e   h e r e  
 	 S E L E C T   @ R e s u l t   =   C A S E  
 	 	 W H E N   I S N U L L ( @ Z i p c o d e ,   ' ' ' ' )   =   ' ' ' '   T H E N   N U L L  
 	 	 W H E N   I S N U L L ( @ Z i p p l u s ,   ' ' ' ' )   =   ' ' ' '   T H E N   @ Z i p c o d e  
 	 	 E L S E   @ Z i p c o d e   +   ' ' - ' '   +   @ Z i p p l u s  
 	 E N D  
  
 	 - -   R e t u r n   t h e   r e s u l t   o f   t h e   f u n c t i o n  
 	 R E T U R N   @ R e s u l t  
  
 E N D  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ R E P O R T ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 1 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ R E P O R T ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ R E P O R T ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ R e p o r t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ R e p o r t D u e D a t e ]   [ v a r c h a r ] ( 2 5 )   N U L L ,  
 	 [ R e p o r t R e c e i v e d D a t e ]   [ v a r c h a r ] ( 2 5 )   N U L L ,  
 	 [ R e p o r t R e c i p i e n t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R e p o r t i n g P e r i o d S t a r t D a t e ]   [ v a r c h a r ] ( 2 5 )   N U L L ,  
 	 [ R e p o r t i n g P e r i o d E n d D a t e ]   [ v a r c h a r ] ( 2 5 )   N U L L ,  
 	 [ R e v i s i o n I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R e p l a c e d R e p o r t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R e p o r t C r e a t e B y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R e p o r t C r e a t e D a t e ]   [ v a r c h a r ] ( 2 5 )   N U L L ,  
 	 [ R e p o r t C r e a t e T i m e ]   [ v a r c h a r ] ( 2 5 )   N U L L ,  
 	 [ R e p o r t T y p e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ R E P O R T ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ C A F O _ A D D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 9 : 4 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ A D D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ C A F O _ A D D ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ L o c a t i o n A d d r e s s ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S u p p l e m e n t a l A d d r e s s ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L o c a l i t y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C o u n t y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t a t e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t a t e U S P S C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ A d d r e s s P o s t a l C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ L o c a t i o n A d d r e s s ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ C A F O _ A N I M A L ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 9 : 5 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ A N I M A L ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ C A F O _ A N I M A L ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ A n i m a l T y p e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ A n i m a l T y p e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ T o t a l N u m s E a c h L i v e s t o c k ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ O p e n C o u n t ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ H o u s e d U n d e r R o o f C o u n t ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ A n i m a l T y p e ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ C A F O _ G E O ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 0 : 0 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ G E O ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ C A F O _ G E O ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ L a t i t u d e ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
 	 [ L o n g i t u d e ]   [ v a r c h a r ] ( 1 1 )   N O T   N U L L ,  
 	 [ H o r i z A c c u r V a l u e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H o r i z A c c u r U n i t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H o r i z A c c u r U n i t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H o r i z A c c u r U n i t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P r e c T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R e s u l t Q u a l C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R e s u l t Q u a l C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R e s u l t Q u a l N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H o r i z M e t h o d I D C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H o r i z M e t h o d I D C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H o r i z M e t h o d N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H o r i z M e t h o d D e s c ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H o r i z M e t h o d D e v i a t i o n s ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H y d r o l o g i c U n i t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L o c a t i o n C o m m e n t s ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ G e o g r a p h i c L o c a t i o n ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ C A F O _ R E G _ D T L S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 0 : 3 9   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ R E G _ D T L S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ C A F O _ R E G _ D T L S ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ D i s c h r g F r o m P r o d A r e a ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ A u t h o r i z e d D i s c h a r g e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ U n a u t h o r i z e d D i s c h a r g e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P e r m i t t i n g A u t h R e p R e c D a t e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ I s A n i m a l F a c i l i t y T y p e C A F O ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e V a l u e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e U n i t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e U n i t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e U n i t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e P r e c ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e R e s u l t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e R e s u l t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e R e s u l t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e T r a n V a l u e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e T r a n U n i t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e T r a n U n i t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e T r a n U n i t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e T r a n P r e c ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e T r a n R e s u l t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e T r a n R e s u l t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e T r a n R e s u l t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e V a l u e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e U n i t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e U n i t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e U n i t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e P r e c ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e R e s u l t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e R e s u l t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e R e s u l t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e T r a n V a l u e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e T r a n U n i t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e T r a n U n i t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e T r a n U n i t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e T r a n P r e c ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e T r a n R e s u l t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e T r a n R e s u l t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e T r a n R e s u l t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ N M P D e v C e r t P l a n A p p r o v e d ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ T o t a l N u m A c r e s N M P I d e n t i f i e d ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ T o t a l N u m A c r e s U s e d L a n d A p p ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ R e g u l a t o r y D e t a i l s ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 0 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ S I T E ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ S I T E ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F a c i l i t y S i t e I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F a c i l i t y S i t e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F a c i l i t y S t a t u s ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L o c a t i o n A d d r e s s T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S u p p l e m e n t a l L o c a t i o n T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L o c a l i t y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t a t e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t a t e C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t a t e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ A d d r e s s P o s t a l C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C o u n t r y C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C o u n t r y C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C o u n t r y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C o u n t y C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C o u n t y C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C o u n t y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ T r i b a l C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ T r i b a l C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ T r i b a l N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ T r i b a l L a n d N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ T r i b a l L a n d I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L o c a t i o n D e s c r i p t i o n T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g F a c i l i t y S i t e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g A d d r e s s T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g S u p p l e m e n t a l A d d r e s s T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g A d d r e s s C i t y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g S t a t e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g S t a t e C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g S t a t e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g A d d r e s s P o s t a l C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g C o u n t r y C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g C o u n t r y C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g C o u n t r y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P a r e n t C o m p a n y N a m e N A I n d i c a t o r ]   [ v a r c h a r ] ( 1 )   N U L L ,  
 	 [ P a r e n t C o m p a n y N a m e T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P a r e n t D u n B r a d s t r e e t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ S I T E ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . i n d e x e s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ S I T E ] ' )   A N D   n a m e   =   N ' I X _ T 2 _ F A C _ S I T E _ F a c i l i t y S i t e I d e n t i f i e r ' )  
 C R E A T E   U N I Q U E   N O N C L U S T E R E D   I N D E X   [ I X _ T 2 _ F A C _ S I T E _ F a c i l i t y S i t e I d e n t i f i e r ]   O N   [ d b o ] . [ T 2 _ F A C _ S I T E ]    
 (  
 	 [ F a c i l i t y S i t e I d e n t i f i e r ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ F A C _ I N D _ T Y P E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 2 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ I N D _ T Y P E ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ T Y P E ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ C o n t a c t T y p e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ I N D _ T Y P E ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ F A C _ I N D _ P H O N E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 2 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ I N D _ P H O N E ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ P H O N E ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ T e l e p h o n e N u m b e r T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ T e l e p h o n e N u m b e r T y p e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ T e l e p h o n e E x t e n s i o n N u m b e r T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ I N D _ P H O N E ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ F A C _ I N D _ E M A I L ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 1 8   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ I N D _ E M A I L ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ E M A I L ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ E l e c t r o n i c A d d r e s s T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ E l e c t r o n i c A d d r e s s T y p e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ I N D _ E M A I L ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ F R S _ F A C _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 2 : 0 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ F A C _ I N D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ F R S _ F A C _ I N D ] (  
 	 [ S T _ R E C _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ A F F I L _ T Y P E ]   [ v a r c h a r ] ( 4 0 )   N U L L ,  
 	 [ A F F I L _ S T A R T _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ A F F I L _ E N D _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ E M A I L _ A D D ]   [ v a r c h a r ] ( 1 2 0 )   N U L L ,  
 	 [ T E L _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ P H _ E X T ]   [ v a r c h a r ] ( 5 )   N U L L ,  
 	 [ F A X _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ A L T _ T E L _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ I N D _ F U L L _ N M ]   [ v a r c h a r ] ( 7 0 )   N U L L ,  
 	 [ I N D _ T I T L E ]   [ v a r c h a r ] ( 4 0 )   N U L L ,  
 	 [ M A I L _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ S U P P L E M _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ M A I L _ A D D _ C I T Y _ N M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ C D ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ N M ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ M A I L _ A D D _ C O _ N M ]   [ v a r c h a r ] ( 4 4 )   N U L L ,  
 	 [ M A I L _ A D D _ Z I P _ C D ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C I N D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ R E C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ F R S _ F A C _ O R G ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 2 : 2 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ F A C _ O R G ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ F R S _ F A C _ O R G ] (  
 	 [ S T _ R E C _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ A F F I L _ T Y P E ]   [ v a r c h a r ] ( 4 0 )   N U L L ,  
 	 [ A F F I L _ S T A R T _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ A F F I L _ E N D _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ E M A I L _ A D D ]   [ v a r c h a r ] ( 1 2 0 )   N U L L ,  
 	 [ T E L _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ P H _ E X T ]   [ v a r c h a r ] ( 5 )   N U L L ,  
 	 [ F A X _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ A L T _ T E L _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ O R G _ F O R M A L _ N M ]   [ v a r c h a r ] ( 8 0 )   N U L L ,  
 	 [ O R G _ D U N S _ N U M ]   [ v a r c h a r ] ( 9 )   N U L L ,  
 	 [ O R G _ T Y P E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ E M P L O Y E R _ I N D ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
 	 [ S T _ B U S I N E S S _ I N D ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ U L T _ P A R E N T _ N M ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ U L T _ P A R E N T _ D U N S _ N U M ]   [ v a r c h a r ] ( 9 )   N U L L ,  
 	 [ M A I L _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ S U P P L E M _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ M A I L _ A D D _ C I T Y _ N M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ C D ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ N M ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ M A I L _ A D D _ C O _ N M ]   [ v a r c h a r ] ( 4 4 )   N U L L ,  
 	 [ M A I L _ A D D _ Z I P _ C D ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
   C O N S T R A I N T   [ P K _ F R S _ F A C O R G ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ R E C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ F R S _ F A C _ N A I C S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 2 : 0 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ F A C _ N A I C S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ F R S _ F A C _ N A I C S ] (  
 	 [ S T _ R E C _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ N A I C S _ C D ]   [ v a r c h a r ] ( 6 )   N O T   N U L L ,  
 	 [ N A I C S _ P R I M _ I N D ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C N A I C S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ R E C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ F R S _ A L T _ N M ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 0 : 5 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ A L T _ N M ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ F R S _ A L T _ N M ] (  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ A L T _ N M ]   [ v a r c h a r ] ( 8 0 )   N O T   N U L L ,  
 	 [ A L T _ N A M E _ T Y P E ]   [ v a r c h a r ] ( 2 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ F R S _ A L T _ N M ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ F A C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ F R S _ E I ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 0 : 5 8   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ E I ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ F R S _ E I ] (  
 	 [ S T _ E I _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ I N F _ S Y S _ A C ]   [ v a r c h a r ] ( 2 0 )   N U L L ,  
 	 [ I N F _ S Y S _ I N D ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ E N V _ I N T _ T Y P E ]   [ v a r c h a r ] ( 6 0 )   N U L L ,  
 	 [ F E D _ S T _ I N T ]   [ c h a r ] ( 1 )   N U L L ,  
 	 [ E N V _ I N T _ S T A R T _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ I N T _ S T A R T _ D A T E _ Q U A L ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ E N V _ I N T _ E N D _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ I N T _ E N D _ D A T E _ Q U A L ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
   C O N S T R A I N T   [ P K _ E I ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ E I _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ F R S _ A D D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 0 : 4 9   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ A D D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ F R S _ A D D ] (  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ A F F I L _ T Y P E ]   [ v a r c h a r ] ( 4 0 )   N U L L ,  
 	 [ M A I L _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ S U P P L E M _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ M A I L _ A D D _ C I T Y _ N M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ C D ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ N M ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ M A I L _ A D D _ C O _ N M ]   [ v a r c h a r ] ( 4 4 )   N U L L ,  
 	 [ M A I L _ A D D _ Z I P _ C D ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
   C O N S T R A I N T   [ P K _ M A I L _ A D D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ F A C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ F R S _ F A C _ S I C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 2 : 2 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ F A C _ S I C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ F R S _ F A C _ S I C ] (  
 	 [ S T _ R E C _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ S I C _ C D ]   [ v a r c h a r ] ( 4 )   N O T   N U L L ,  
 	 [ S I C _ P R I M _ I N D ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C S I C ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ R E C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ F R S _ G E O ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 2 : 3 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ G E O ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ F R S _ G E O ] (  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ L A T _ M E A S U R E ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
 	 [ L O N _ M E A S U R E ]   [ v a r c h a r ] ( 1 1 )   N O T   N U L L ,  
 	 [ H O R I Z _ A C C U R _ M E A S U R E ]   [ v a r c h a r ] ( 6 )   N U L L ,  
 	 [ H O R I Z _ C O L L _ M E T H ]   [ v a r c h a r ] ( 6 0 )   N U L L ,  
 	 [ H O R I Z _ R E F _ D A T U M _ N M ]   [ v a r c h a r ] ( 7 )   N U L L ,  
 	 [ S R C _ M A P _ S C A L E _ N U M ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ R E F _ P O I N T ]   [ v a r c h a r ] ( 6 0 )   N U L L ,  
 	 [ D A T A _ C O L L _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ G E O _ T Y P E _ N M ]   [ v a r c h a r ] ( 6 )   N U L L ,  
 	 [ L O C _ C O M M E N T S ]   [ v a r c h a r ] ( 1 5 0 )   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H ]   [ v a r c h a r ] ( 6 0 )   N U L L ,  
 	 [ V E R T _ M E A S U R E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ V E R T _ A C C U R _ M E A S U R E ]   [ v a r c h a r ] ( 8 )   N U L L ,  
 	 [ V E R T _ R E F _ D A T U M _ N M ]   [ v a r c h a r ] ( 1 7 )   N U L L ,  
 	 [ D A T A _ S R C _ N M ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ C O O R D _ D A T A _ S R C _ N M ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ S U B _ E N T _ I N D ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ S U B _ E N T _ T Y P E _ N M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
   C O N S T R A I N T   [ P K _ F R S _ G E O ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ F A C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 2 : 4 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ I t e m C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ I t e m T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ I t e m D e s c r i p t i o n T e x t ]   [ v a r c h a r ] ( 4 0 0 0 )   N U L L ,  
   C O N S T R A I N T   [ P K _ H E R E _ D o m a i n L i s t I t e m ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . i n d e x e s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ] ' )   A N D   n a m e   =   N ' I X _ H E R E _ D o m a i n L i s t I t e m ' )  
 C R E A T E   U N I Q U E   N O N C L U S T E R E D   I N D E X   [ I X _ H E R E _ D o m a i n L i s t I t e m ]   O N   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]    
 (  
 	 [ F K _ G U I D ]   A S C ,  
 	 [ I t e m C o d e ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ C A F O _ R E G _ D T L S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 5 : 1 7   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ C A F O _ R E G _ D T L S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ C A F O _ R E G _ D T L S ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ D i s c h r g F r o m P r o d A r e a ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ A u t h o r i z e d D i s c h a r g e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ U n a u t h o r i z e d D i s c h a r g e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P e r m i t t i n g A u t h R e p R e c D a t e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ I s A n i m a l F a c i l i t y T y p e C A F O ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e V a l u e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e U n i t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e U n i t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e U n i t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e P r e c ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e R e s u l t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e R e s u l t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e R e s u l t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e T r a n V a l u e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e T r a n U n i t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e T r a n U n i t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e T r a n U n i t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e T r a n P r e c ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e T r a n R e s u l t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e T r a n R e s u l t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L i q M a n u r e T r a n R e s u l t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e V a l u e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e U n i t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e U n i t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e U n i t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e P r e c ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e R e s u l t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e R e s u l t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e R e s u l t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e T r a n V a l u e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e T r a n U n i t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e T r a n U n i t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e T r a n U n i t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e T r a n P r e c ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e T r a n R e s u l t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e T r a n R e s u l t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S o l M a n u r e T r a n R e s u l t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ N M P D e v C e r t P l a n A p p r o v e d ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ T o t a l N u m A c r e s N M P I d e n t i f i e d ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ T o t a l N u m A c r e s U s e d L a n d A p p ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ R e g u l a t o r y D e t a i l s ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ C A F O _ A N I M A L ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 2 8   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ C A F O _ A N I M A L ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ C A F O _ A N I M A L ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ A n i m a l T y p e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ A n i m a l T y p e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ T o t a l N u m s E a c h L i v e s t o c k ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ O p e n C o u n t ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ H o u s e d U n d e r R o o f C o u n t ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ A n i m a l T y p e ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ C A F O _ A D D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 2 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ C A F O _ A D D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ C A F O _ A D D ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ L o c a t i o n A d d r e s s ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S u p p l e m e n t a l A d d r e s s ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L o c a l i t y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C o u n t y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t a t e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t a t e U S P S C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ A d d r e s s P o s t a l C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ L o c a t i o n A d d r e s s ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ C A F O _ G E O ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 4 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ C A F O _ G E O ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ C A F O _ G E O ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ L a t i t u d e ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
 	 [ L o n g i t u d e ]   [ v a r c h a r ] ( 1 1 )   N O T   N U L L ,  
 	 [ H o r i z A c c u r V a l u e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H o r i z A c c u r U n i t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H o r i z A c c u r U n i t C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H o r i z A c c u r U n i t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P r e c T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R e s u l t Q u a l C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R e s u l t Q u a l C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R e s u l t Q u a l N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H o r i z M e t h o d I D C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H o r i z M e t h o d I D C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H o r i z M e t h o d N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H o r i z M e t h o d D e s c ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H o r i z M e t h o d D e v i a t i o n s ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H y d r o l o g i c U n i t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L o c a t i o n C o m m e n t s ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ G e o g r a p h i c L o c a t i o n ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ C A F O _ P E R M I T ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 5 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ C A F O _ P E R M I T ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ C A F O _ P E R M I T ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ P e r m i t I d ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P e r m i t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ O t h e r P e r m i t I d ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P r o g r a m N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P e r m i t T y p e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P e r m i t T y p e C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P e r m i t T y p e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ P e r m i t ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ F R S _ E I _ O R G ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 1 : 2 9   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ E I _ O R G ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ F R S _ E I _ O R G ] (  
 	 [ S T _ R E C _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ E I _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ A F F I L _ T Y P E ]   [ v a r c h a r ] ( 4 0 )   N U L L ,  
 	 [ A F F I L _ S T A R T _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ A F F I L _ E N D _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ E M A I L _ A D D ]   [ v a r c h a r ] ( 1 2 0 )   N U L L ,  
 	 [ T E L _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ P H _ E X T ]   [ v a r c h a r ] ( 5 )   N U L L ,  
 	 [ F A X _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ A L T _ T E L _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ O R G _ F O R M A L _ N M ]   [ v a r c h a r ] ( 8 0 )   N U L L ,  
 	 [ O R G _ D U N S _ N U M ]   [ v a r c h a r ] ( 9 )   N U L L ,  
 	 [ O R G _ T Y P E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ E M P L O Y E R _ I N D ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
 	 [ S T _ B U S I N E S S _ I N D ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ U L T _ P A R E N T _ N M ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ U L T _ P A R E N T _ D U N S _ N U M ]   [ v a r c h a r ] ( 9 )   N U L L ,  
 	 [ M A I L _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ S U P P L E M _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ M A I L _ A D D _ C I T Y _ N M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ C D ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ N M ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ M A I L _ A D D _ C O _ N M ]   [ v a r c h a r ] ( 4 4 )   N U L L ,  
 	 [ M A I L _ A D D _ Z I P _ C D ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
   C O N S T R A I N T   [ P K _ E I O R G ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ R E C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ F R S _ E I _ N A I C S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 1 : 1 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ E I _ N A I C S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ F R S _ E I _ N A I C S ] (  
 	 [ S T _ R E C _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ E I _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ N A I C S _ C D ]   [ v a r c h a r ] ( 6 )   N O T   N U L L ,  
 	 [ N A I C S _ P R I M _ I N D ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ E I N A I C S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ R E C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ F R S _ E I _ S I C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 1 : 3 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ E I _ S I C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ F R S _ E I _ S I C ] (  
 	 [ S T _ R E C _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ E I _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S I C _ C D ]   [ v a r c h a r ] ( 4 )   N O T   N U L L ,  
 	 [ S I C _ P R I M _ I N D ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ E I S I C ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ R E C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ F R S _ E I _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 1 : 1 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ E I _ I N D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ F R S _ E I _ I N D ] (  
 	 [ S T _ R E C _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ E I _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ A F F I L _ T Y P E ]   [ v a r c h a r ] ( 4 0 )   N U L L ,  
 	 [ A F F I L _ S T A R T _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ A F F I L _ E N D _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ E M A I L _ A D D ]   [ v a r c h a r ] ( 1 2 0 )   N U L L ,  
 	 [ T E L _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ P H _ E X T ]   [ v a r c h a r ] ( 5 )   N U L L ,  
 	 [ F A X _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ A L T _ T E L _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ I N D _ F U L L _ N M ]   [ v a r c h a r ] ( 7 0 )   N U L L ,  
 	 [ I N D _ T I T L E ]   [ v a r c h a r ] ( 4 0 )   N U L L ,  
 	 [ M A I L _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ S U P P L E M _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ M A I L _ A D D _ C I T Y _ N M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ C D ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ N M ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ M A I L _ A D D _ C O _ N M ]   [ v a r c h a r ] ( 4 4 )   N U L L ,  
 	 [ M A I L _ A D D _ Z I P _ C D ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
   C O N S T R A I N T   [ P K _ E I I N D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ R E C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ R E P O R T ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 9 : 3 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ R E P O R T ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ R E P O R T ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ R e p o r t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ R e p o r t D u e D a t e ]   [ v a r c h a r ] ( 2 5 )   N U L L ,  
 	 [ R e p o r t R e c e i v e d D a t e ]   [ v a r c h a r ] ( 2 5 )   N U L L ,  
 	 [ R e p o r t R e c i p i e n t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R e p o r t i n g P e r i o d S t a r t D a t e ]   [ v a r c h a r ] ( 2 5 )   N U L L ,  
 	 [ R e p o r t i n g P e r i o d E n d D a t e ]   [ v a r c h a r ] ( 2 5 )   N U L L ,  
 	 [ R e v i s i o n I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R e p l a c e d R e p o r t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R e p o r t C r e a t e B y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R e p o r t C r e a t e D a t e ]   [ v a r c h a r ] ( 2 5 )   N U L L ,  
 	 [ R e p o r t C r e a t e T i m e ]   [ v a r c h a r ] ( 2 5 )   N U L L ,  
 	 [ R e p o r t T y p e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ R E P O R T ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 9 : 2 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ S I T E ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ F A C _ S I T E ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F a c i l i t y S i t e I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F a c i l i t y S i t e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F a c i l i t y S t a t u s ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L o c a t i o n A d d r e s s T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S u p p l e m e n t a l L o c a t i o n T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L o c a l i t y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t a t e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t a t e C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t a t e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ A d d r e s s P o s t a l C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C o u n t r y C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C o u n t r y C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C o u n t r y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C o u n t y C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C o u n t y C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C o u n t y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ T r i b a l C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ T r i b a l C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ T r i b a l N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ T r i b a l L a n d N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ T r i b a l L a n d I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L o c a t i o n D e s c r i p t i o n T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g F a c i l i t y S i t e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g A d d r e s s T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g S u p p l e m e n t a l A d d r e s s T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g A d d r e s s C i t y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g S t a t e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g S t a t e C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g S t a t e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g A d d r e s s P o s t a l C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g C o u n t r y C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g C o u n t r y C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g C o u n t r y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P a r e n t C o m p a n y N a m e N A I n d i c a t o r ]   [ v a r c h a r ] ( 1 )   N U L L ,  
 	 [ P a r e n t C o m p a n y N a m e T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P a r e n t D u n B r a d s t r e e t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ S I T E ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ C H E M _ I N V ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 1 9   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ C H E M _ I N V ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ C H E M _ I N V ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ C h e m i c a l I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ E H S I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ T r a d e S e c r e t I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ C A S N u m b e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C h e m S u b s t a n c e S y s t e m a t i c N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ E P A C h e m i c a l R e g i s t r y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ E P A C h e m i c a l I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C h e m i c a l N a m e C o n t e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ I N V ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ F A C _ R C R A _ I D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 5 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ R C R A _ I D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ F A C _ R C R A _ I D ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ R C R A I d e n t i f i c a t i o n N u m b e r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ R C R A _ I D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ F A C _ N A I C S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 4 9   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ N A I C S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ F A C _ N A I C S ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ N A I C S C o d e ]   [ v a r c h a r ] ( 6 )   N O T   N U L L ,  
 	 [ N A I C S I n d u s t r y C o d e ]   [ v a r c h a r ] ( 5 )   N U L L ,  
 	 [ N A I C S G r o u p C o d e ]   [ v a r c h a r ] ( 4 )   N U L L ,  
 	 [ N A I C S S u b s e c t o r C o d e ]   [ v a r c h a r ] ( 3 )   N U L L ,  
 	 [ N A I C S S e c t o r C o d e ]   [ v a r c h a r ] ( 2 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ N A I C S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ F A C _ D U N D B _ I D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 4 8   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ D U N D B _ I D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ F A C _ D U N D B _ I D ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F a c i l i t y D u n B r a d s t r e e t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ D U N D B _ I D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ F A C _ S I C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 5 9   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ S I C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ F A C _ S I C ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S I C C o d e ]   [ v a r c h a r ] ( 4 )   N O T   N U L L ,  
 	 [ S I C P r i m a r y I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C _ S I C ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ F A C _ U I C _ I D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 9 : 2 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ U I C _ I D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ F A C _ U I C _ I D ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ U I C I d e n t i f i c a t i o n N u m b e r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ U I C _ I D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ F A C _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 3 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ I N D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ F A C _ I N D ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ I n d i v i d u a l I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ I n d i v i d u a l T i t l e T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ N a m e P r e f i x T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ I n d i v i d u a l F u l l N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F i r s t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M i d d l e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L a s t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ N a m e S u f f i x T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g A d d r e s s T e x t ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ M a i l i n g S u p p l e m e n t a l A d d r e s s T e x t ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ M a i l i n g A d d r e s s C i t y N a m e ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ M a i l i n g S t a t e C o d e ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ M a i l i n g S t a t e C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g S t a t e N a m e ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ M a i l i n g A d d r e s s P o s t a l C o d e ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
 	 [ M a i l i n g C o u n t r y C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g C o u n t r y C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g C o u n t r y N a m e ]   [ v a r c h a r ] ( 4 4 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ I N D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ F A C _ N P D E S _ I D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 5 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ N P D E S _ I D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ F A C _ N P D E S _ I D ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ N P D E S I d e n t i f i c a t i o n N u m b e r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ N P D E S _ I D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ F A C _ G E O ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 2 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ G E O ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ F A C _ G E O ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ A _ M E A S U R E ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
 	 [ B _ M E A S U R E ]   [ v a r c h a r ] ( 1 1 )   N O T   N U L L ,  
 	 [ S R C _ M A P _ S C A L E _ N U M ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ A C C U R _ M E A S U R E _ V A L U E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ A C C U R _ M E A S U R E _ U N I T C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ A C C U R _ M E A S U R E _ U N I T C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ A C C U R _ M E A S U R E _ U N I T _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ A C C U R _ P R E C _ T X T ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ A C C U R _ R E S U L T _ Q U A L _ C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ A C C U R _ R E S U L T _ Q U A L _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ A C C U R _ R E S U L T _ Q U A L _ N M ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ C O L L _ M E T H _ I D C O D E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ C O L L _ M E T H _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ C O L L _ M E T H _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ C O L L _ M E T H _ D E S C ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ C O L L _ M E T H _ D E V I A T I O N S ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R E F _ P O I N T _ C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R E F _ P O I N T _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R E F _ P O I N T _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ R E F _ D A T U M _ C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ R E F _ D A T U M _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ R E F _ D A T U M _ N M ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ D A T A _ C O L L _ D A T E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L O C _ C O M M E N T S ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ M E A S U R E _ V A L U E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ M E A S U R E _ U N I T C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ M E A S U R E _ U N I T C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ M E A S U R E _ U N I T _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ M E A S U R E _ P R E C _ T X T ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ M E A S U R E _ R E S U L T _ Q U A L _ C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ M E A S U R E _ R E S U L T _ Q U A L _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ M E A S U R E _ R E S U L T _ Q U A L _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ I D C O D E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ D E S C ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ D E V I A T I O N S ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ R E F _ D A T U M _ C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ R E F _ D A T U M _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ R E F _ D A T U M _ N M ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R I F _ M E T H _ I D C O D E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R I F _ M E T H _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R I F _ M E T H _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R I F _ M E T H _ D E S C ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R I F _ M E T H _ D E V I A T I O N S ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C O O R D _ D A T A _ S R C _ C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C O O R D _ D A T A _ S R C _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C O O R D _ D A T A _ S R C _ N M ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ G E O _ T Y P E _ C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ G E O _ T Y P E _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ G E O _ T Y P E _ N M ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ G E O ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ C H E M _ I N V _ D T L S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 2 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ C H E M _ I N V _ D T L S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ C H E M _ I N V _ D T L S ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ N u m b e r O f D a y s O n s i t e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ M a x i m u m D a i l y A m o u n t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a x i m u m C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ A v e r a g e D a i l y A m o u n t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ A v e r a g e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ I N V _ D T L S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ C H E M _ I N V _ P H Y S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 3 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ C H E M _ I N V _ P H Y S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ C H E M _ I N V _ P H Y S ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ C h e m i c a l P h y s i c a l S t a t e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ I N V _ P H Y S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ C H E M _ I N V _ H L T H ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 3 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ C H E M _ I N V _ H L T H ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ C H E M _ I N V _ H L T H ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ H e a l t h E f f e c t s ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ I N V _ H L T H ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ C H E M _ I N V _ H A Z ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 2 7   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ C H E M _ I N V _ H A Z ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ C H E M _ I N V _ H A Z ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ H a z a r d T y p e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ I N V _ H A Z ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ C H E M _ M I X ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 4 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ C H E M _ M I X ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ C H E M _ M I X ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ C A S N u m b e r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ C o m p o n e n t ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ C o m p o n e n t P e r c e n t a g e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ W e i g h t O r V o l u m e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ M I X ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ C H E M _ L O C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 4 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ C H E M _ L O C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ C H E M _ L O C ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ C o n f i d e n t i a l L o c a t i o n I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ S t o r a g e T y p e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t o r a g e T y p e D e s c r i p t i o n ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t o r a g e L o c T e m p e r a t u r e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t o r a g e L o c T e m p e r a t u r e D e s c ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t o r a g e L o c P r e s s u r e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t o r a g e L o c P r e s s u r e D e s c ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t o r a g e L o c D e s c r i p t i o n ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a x i m u m A m o u n t A t L o c a t i o n ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M e a s u r e m e n t U n i t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ L O C ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ F R S _ E I _ O R G ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 6 : 0 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ E I _ O R G ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ F R S _ E I _ O R G ] (  
 	 [ S T _ R E C _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ E I _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ A F F I L _ T Y P E ]   [ v a r c h a r ] ( 4 0 )   N U L L ,  
 	 [ A F F I L _ S T A R T _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ A F F I L _ E N D _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ E M A I L _ A D D ]   [ v a r c h a r ] ( 1 2 0 )   N U L L ,  
 	 [ T E L _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ P H _ E X T ]   [ v a r c h a r ] ( 5 )   N U L L ,  
 	 [ F A X _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ A L T _ T E L _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ O R G _ F O R M A L _ N M ]   [ v a r c h a r ] ( 8 0 )   N U L L ,  
 	 [ O R G _ D U N S _ N U M ]   [ v a r c h a r ] ( 9 )   N U L L ,  
 	 [ O R G _ T Y P E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ E M P L O Y E R _ I N D ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
 	 [ S T _ B U S I N E S S _ I N D ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ U L T _ P A R E N T _ N M ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ U L T _ P A R E N T _ D U N S _ N U M ]   [ v a r c h a r ] ( 9 )   N U L L ,  
 	 [ M A I L _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ S U P P L E M _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ M A I L _ A D D _ C I T Y _ N M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ C D ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ N M ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ M A I L _ A D D _ C O _ N M ]   [ v a r c h a r ] ( 4 4 )   N U L L ,  
 	 [ M A I L _ A D D _ Z I P _ C D ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
   C O N S T R A I N T   [ P K _ E I O R G ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ R E C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ F R S _ E I _ N A I C S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 5 : 4 9   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ E I _ N A I C S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ F R S _ E I _ N A I C S ] (  
 	 [ S T _ R E C _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ E I _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ N A I C S _ C D ]   [ v a r c h a r ] ( 6 )   N O T   N U L L ,  
 	 [ N A I C S _ P R I M _ I N D ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ E I N A I C S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ R E C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ F R S _ E I _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 5 : 4 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ E I _ I N D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ F R S _ E I _ I N D ] (  
 	 [ S T _ R E C _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ E I _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ A F F I L _ T Y P E ]   [ v a r c h a r ] ( 4 0 )   N U L L ,  
 	 [ A F F I L _ S T A R T _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ A F F I L _ E N D _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ E M A I L _ A D D ]   [ v a r c h a r ] ( 1 2 0 )   N U L L ,  
 	 [ T E L _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ P H _ E X T ]   [ v a r c h a r ] ( 5 )   N U L L ,  
 	 [ F A X _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ A L T _ T E L _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ I N D _ F U L L _ N M ]   [ v a r c h a r ] ( 7 0 )   N U L L ,  
 	 [ I N D _ T I T L E ]   [ v a r c h a r ] ( 4 0 )   N U L L ,  
 	 [ M A I L _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ S U P P L E M _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ M A I L _ A D D _ C I T Y _ N M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ C D ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ N M ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ M A I L _ A D D _ C O _ N M ]   [ v a r c h a r ] ( 4 4 )   N U L L ,  
 	 [ M A I L _ A D D _ Z I P _ C D ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
   C O N S T R A I N T   [ P K _ E I I N D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ R E C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ F R S _ E I _ S I C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 6 : 0 8   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ E I _ S I C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ F R S _ E I _ S I C ] (  
 	 [ S T _ R E C _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ E I _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S I C _ C D ]   [ v a r c h a r ] ( 4 )   N O T   N U L L ,  
 	 [ S I C _ P R I M _ I N D ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ E I S I C ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ R E C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ F R S _ F A C _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 6 : 3 8   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ F A C _ I N D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ F R S _ F A C _ I N D ] (  
 	 [ S T _ R E C _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ A F F I L _ T Y P E ]   [ v a r c h a r ] ( 4 0 )   N U L L ,  
 	 [ A F F I L _ S T A R T _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ A F F I L _ E N D _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ E M A I L _ A D D ]   [ v a r c h a r ] ( 1 2 0 )   N U L L ,  
 	 [ T E L _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ P H _ E X T ]   [ v a r c h a r ] ( 5 )   N U L L ,  
 	 [ F A X _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ A L T _ T E L _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ I N D _ F U L L _ N M ]   [ v a r c h a r ] ( 7 0 )   N U L L ,  
 	 [ I N D _ T I T L E ]   [ v a r c h a r ] ( 4 0 )   N U L L ,  
 	 [ M A I L _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ S U P P L E M _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ M A I L _ A D D _ C I T Y _ N M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ C D ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ N M ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ M A I L _ A D D _ C O _ N M ]   [ v a r c h a r ] ( 4 4 )   N U L L ,  
 	 [ M A I L _ A D D _ Z I P _ C D ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C I N D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ R E C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ F R S _ F A C _ N A I C S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 6 : 4 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ F A C _ N A I C S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ F R S _ F A C _ N A I C S ] (  
 	 [ S T _ R E C _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ N A I C S _ C D ]   [ v a r c h a r ] ( 6 )   N O T   N U L L ,  
 	 [ N A I C S _ P R I M _ I N D ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C N A I C S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ R E C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ F R S _ F A C _ O R G ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 6 : 5 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ F A C _ O R G ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ F R S _ F A C _ O R G ] (  
 	 [ S T _ R E C _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ A F F I L _ T Y P E ]   [ v a r c h a r ] ( 4 0 )   N U L L ,  
 	 [ A F F I L _ S T A R T _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ A F F I L _ E N D _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ E M A I L _ A D D ]   [ v a r c h a r ] ( 1 2 0 )   N U L L ,  
 	 [ T E L _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ P H _ E X T ]   [ v a r c h a r ] ( 5 )   N U L L ,  
 	 [ F A X _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ A L T _ T E L _ N U M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ O R G _ F O R M A L _ N M ]   [ v a r c h a r ] ( 8 0 )   N U L L ,  
 	 [ O R G _ D U N S _ N U M ]   [ v a r c h a r ] ( 9 )   N U L L ,  
 	 [ O R G _ T Y P E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ E M P L O Y E R _ I N D ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
 	 [ S T _ B U S I N E S S _ I N D ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ U L T _ P A R E N T _ N M ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ U L T _ P A R E N T _ D U N S _ N U M ]   [ v a r c h a r ] ( 9 )   N U L L ,  
 	 [ M A I L _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ S U P P L E M _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ M A I L _ A D D _ C I T Y _ N M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ C D ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ N M ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ M A I L _ A D D _ C O _ N M ]   [ v a r c h a r ] ( 4 4 )   N U L L ,  
 	 [ M A I L _ A D D _ Z I P _ C D ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
   C O N S T R A I N T   [ P K _ F R S _ F A C O R G ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ R E C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ F R S _ F A C _ S I C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 0 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ F A C _ S I C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ F R S _ F A C _ S I C ] (  
 	 [ S T _ R E C _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ S I C _ C D ]   [ v a r c h a r ] ( 4 )   N O T   N U L L ,  
 	 [ S I C _ P R I M _ I N D ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C S I C ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ R E C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ F R S _ G E O ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 1 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ G E O ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ F R S _ G E O ] (  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ L A T _ M E A S U R E ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
 	 [ L O N _ M E A S U R E ]   [ v a r c h a r ] ( 1 1 )   N O T   N U L L ,  
 	 [ H O R I Z _ A C C U R _ M E A S U R E ]   [ v a r c h a r ] ( 6 )   N U L L ,  
 	 [ H O R I Z _ C O L L _ M E T H ]   [ v a r c h a r ] ( 6 0 )   N U L L ,  
 	 [ H O R I Z _ R E F _ D A T U M _ N M ]   [ v a r c h a r ] ( 7 )   N U L L ,  
 	 [ S R C _ M A P _ S C A L E _ N U M ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ R E F _ P O I N T ]   [ v a r c h a r ] ( 6 0 )   N U L L ,  
 	 [ D A T A _ C O L L _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ G E O _ T Y P E _ N M ]   [ v a r c h a r ] ( 6 )   N U L L ,  
 	 [ L O C _ C O M M E N T S ]   [ v a r c h a r ] ( 1 5 0 )   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H ]   [ v a r c h a r ] ( 6 0 )   N U L L ,  
 	 [ V E R T _ M E A S U R E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ V E R T _ A C C U R _ M E A S U R E ]   [ v a r c h a r ] ( 8 )   N U L L ,  
 	 [ V E R T _ R E F _ D A T U M _ N M ]   [ v a r c h a r ] ( 1 7 )   N U L L ,  
 	 [ D A T A _ S R C _ N M ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ C O O R D _ D A T A _ S R C _ N M ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ S U B _ E N T _ I N D ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ S U B _ E N T _ T Y P E _ N M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
   C O N S T R A I N T   [ P K _ F R S _ G E O ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ F A C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ F R S _ E I ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 5 : 3 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ E I ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ F R S _ E I ] (  
 	 [ S T _ E I _ I N D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ I N F _ S Y S _ A C ]   [ v a r c h a r ] ( 2 0 )   N U L L ,  
 	 [ I N F _ S Y S _ I N D ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ E N V _ I N T _ T Y P E ]   [ v a r c h a r ] ( 6 0 )   N U L L ,  
 	 [ F E D _ S T _ I N T ]   [ c h a r ] ( 1 )   N U L L ,  
 	 [ E N V _ I N T _ S T A R T _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ I N T _ S T A R T _ D A T E _ Q U A L ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ E N V _ I N T _ E N D _ D A T E ]   [ v a r c h a r ] ( 1 0 )   N U L L ,  
 	 [ I N T _ E N D _ D A T E _ Q U A L ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
   C O N S T R A I N T   [ P K _ E I ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ E I _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ F R S _ A L T _ N M ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 5 : 2 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ A L T _ N M ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ F R S _ A L T _ N M ] (  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ A L T _ N M ]   [ v a r c h a r ] ( 8 0 )   N O T   N U L L ,  
 	 [ A L T _ N A M E _ T Y P E ]   [ v a r c h a r ] ( 2 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ F R S _ A L T _ N M ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ F A C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ F R S _ A D D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 5 : 2 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ A D D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ F R S _ A D D ] (  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 1 2 )   N O T   N U L L ,  
 	 [ A F F I L _ T Y P E ]   [ v a r c h a r ] ( 4 0 )   N U L L ,  
 	 [ M A I L _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ S U P P L E M _ A D D ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ M A I L _ A D D _ C I T Y _ N M ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ C D ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ M A I L _ A D D _ S T _ N M ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ M A I L _ A D D _ C O _ N M ]   [ v a r c h a r ] ( 4 4 )   N U L L ,  
 	 [ M A I L _ A D D _ Z I P _ C D ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
   C O N S T R A I N T   [ P K _ M A I L _ A D D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S T _ F A C _ I N D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ F A C _ I N D _ T Y P E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 4 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ I N D _ T Y P E ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ F A C _ I N D _ T Y P E ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ C o n t a c t T y p e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ I N D _ T Y P E ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ F A C _ I N D _ E M A I L ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 3 8   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ I N D _ E M A I L ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ F A C _ I N D _ E M A I L ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ E l e c t r o n i c A d d r e s s T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ E l e c t r o n i c A d d r e s s T y p e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ I N D _ E M A I L ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ c m p ] . [ T 2 _ F A C _ I N D _ P H O N E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 4 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ I N D _ P H O N E ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ c m p ] . [ T 2 _ F A C _ I N D _ P H O N E ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ T e l e p h o n e N u m b e r T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ T e l e p h o n e N u m b e r T y p e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ T e l e p h o n e E x t e n s i o n N u m b e r T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ I N D _ P H O N E ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ C A F O _ P E R M I T ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 0 : 1 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ P E R M I T ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ C A F O _ P E R M I T ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F K ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ P e r m i t I d ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P e r m i t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ O t h e r P e r m i t I d ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P r o g r a m N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P e r m i t T y p e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P e r m i t T y p e C o d e L i s t I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ P e r m i t T y p e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ P e r m i t ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ F A C _ G E O ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 0 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ G E O ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ G E O ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ A _ M E A S U R E ]   [ v a r c h a r ] ( 1 0 )   N O T   N U L L ,  
 	 [ B _ M E A S U R E ]   [ v a r c h a r ] ( 1 1 )   N O T   N U L L ,  
 	 [ S R C _ M A P _ S C A L E _ N U M ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ A C C U R _ M E A S U R E _ V A L U E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ A C C U R _ M E A S U R E _ U N I T C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ A C C U R _ M E A S U R E _ U N I T C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ A C C U R _ M E A S U R E _ U N I T _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ A C C U R _ P R E C _ T X T ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ A C C U R _ R E S U L T _ Q U A L _ C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ A C C U R _ R E S U L T _ Q U A L _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ A C C U R _ R E S U L T _ Q U A L _ N M ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ C O L L _ M E T H _ I D C O D E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ C O L L _ M E T H _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ C O L L _ M E T H _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ C O L L _ M E T H _ D E S C ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ C O L L _ M E T H _ D E V I A T I O N S ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R E F _ P O I N T _ C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R E F _ P O I N T _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ R E F _ P O I N T _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ R E F _ D A T U M _ C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ R E F _ D A T U M _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ H O R I Z _ R E F _ D A T U M _ N M ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ D A T A _ C O L L _ D A T E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L O C _ C O M M E N T S ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ M E A S U R E _ V A L U E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ M E A S U R E _ U N I T C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ M E A S U R E _ U N I T C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ M E A S U R E _ U N I T _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ M E A S U R E _ P R E C _ T X T ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ M E A S U R E _ R E S U L T _ Q U A L _ C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ M E A S U R E _ R E S U L T _ Q U A L _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ M E A S U R E _ R E S U L T _ Q U A L _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ I D C O D E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ D E S C ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ D E V I A T I O N S ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ R E F _ D A T U M _ C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ R E F _ D A T U M _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R T _ R E F _ D A T U M _ N M ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R I F _ M E T H _ I D C O D E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R I F _ M E T H _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R I F _ M E T H _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R I F _ M E T H _ D E S C ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ V E R I F _ M E T H _ D E V I A T I O N S ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C O O R D _ D A T A _ S R C _ C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C O O R D _ D A T A _ S R C _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C O O R D _ D A T A _ S R C _ N M ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ G E O _ T Y P E _ C D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ G E O _ T Y P E _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ G E O _ T Y P E _ N M ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ G E O ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ F A C _ U I C _ I D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 0 7   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ U I C _ I D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ U I C _ I D ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ U I C I d e n t i f i c a t i o n N u m b e r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ U I C _ I D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ F A C _ S I C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 4 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ S I C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ S I C ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ S I C C o d e ]   [ v a r c h a r ] ( 4 )   N O T   N U L L ,  
 	 [ S I C P r i m a r y I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C _ S I C ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ F A C _ D U N D B _ I D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 3 : 2 9   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ D U N D B _ I D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ D U N D B _ I D ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F a c i l i t y D u n B r a d s t r e e t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ D U N D B _ I D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ F A C _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 1 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ I N D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ I n d i v i d u a l I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ I n d i v i d u a l T i t l e T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ N a m e P r e f i x T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ I n d i v i d u a l F u l l N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ F i r s t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M i d d l e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ L a s t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ N a m e S u f f i x T e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g A d d r e s s T e x t ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ M a i l i n g S u p p l e m e n t a l A d d r e s s T e x t ]   [ v a r c h a r ] ( 5 0 )   N U L L ,  
 	 [ M a i l i n g A d d r e s s C i t y N a m e ]   [ v a r c h a r ] ( 3 0 )   N U L L ,  
 	 [ M a i l i n g S t a t e C o d e ]   [ v a r c h a r ] ( 2 )   N U L L ,  
 	 [ M a i l i n g S t a t e C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g S t a t e N a m e ]   [ v a r c h a r ] ( 3 5 )   N U L L ,  
 	 [ M a i l i n g A d d r e s s P o s t a l C o d e ]   [ v a r c h a r ] ( 1 4 )   N U L L ,  
 	 [ M a i l i n g C o u n t r y C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g C o u n t r y C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a i l i n g C o u n t r y N a m e ]   [ v a r c h a r ] ( 4 4 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ I N D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ F A C _ N P D E S _ I D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 3 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ N P D E S _ I D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ N P D E S _ I D ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ N P D E S I d e n t i f i c a t i o n N u m b e r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ N P D E S _ I D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ F A C _ R C R A _ I D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 3 7   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ R C R A _ I D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ R C R A _ I D ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ R C R A I d e n t i f i c a t i o n N u m b e r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ R C R A _ I D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ F A C _ N A I C S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 3 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ N A I C S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ N A I C S ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ N A I C S C o d e ]   [ v a r c h a r ] ( 6 )   N O T   N U L L ,  
 	 [ N A I C S I n d u s t r y C o d e ]   [ v a r c h a r ] ( 5 )   N U L L ,  
 	 [ N A I C S G r o u p C o d e ]   [ v a r c h a r ] ( 4 )   N U L L ,  
 	 [ N A I C S S u b s e c t o r C o d e ]   [ v a r c h a r ] ( 3 )   N U L L ,  
 	 [ N A I C S S e c t o r C o d e ]   [ v a r c h a r ] ( 2 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ N A I C S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ C H E M _ I N V ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 3 : 0 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ I N V ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ C h e m i c a l I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ E H S I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ T r a d e S e c r e t I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ C A S N u m b e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C h e m S u b s t a n c e S y s t e m a t i c N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ E P A C h e m i c a l R e g i s t r y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ E P A C h e m i c a l I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ C h e m i c a l N a m e C o n t e x t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ I N V ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ C H E M _ I N V _ P H Y S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 3 : 1 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ I N V _ P H Y S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ P H Y S ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ C h e m i c a l P h y s i c a l S t a t e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ I N V _ P H Y S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ C H E M _ I N V _ H L T H ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 3 : 1 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ I N V _ H L T H ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ H L T H ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ H e a l t h E f f e c t s ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ I N V _ H L T H ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ C H E M _ I N V _ H A Z ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 3 : 0 8   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ I N V _ H A Z ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ H A Z ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ H a z a r d T y p e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ I N V _ H A Z ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ C H E M _ L O C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 3 : 2 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ L O C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ C H E M _ L O C ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ C o n f i d e n t i a l L o c a t i o n I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ S t o r a g e T y p e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t o r a g e T y p e D e s c r i p t i o n ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t o r a g e L o c T e m p e r a t u r e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t o r a g e L o c T e m p e r a t u r e D e s c ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t o r a g e L o c P r e s s u r e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t o r a g e L o c P r e s s u r e D e s c ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ S t o r a g e L o c D e s c r i p t i o n ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a x i m u m A m o u n t A t L o c a t i o n ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M e a s u r e m e n t U n i t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ L O C ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ C H E M _ I N V _ D T L S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 3 : 0 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ I N V _ D T L S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ D T L S ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ N u m b e r O f D a y s O n s i t e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ M a x i m u m D a i l y A m o u n t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ M a x i m u m C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ A v e r a g e D a i l y A m o u n t ]   [ v a r c h a r ] ( 2 5 5 )   N U L L ,  
 	 [ A v e r a g e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ I N V _ D T L S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     T a b l e   [ d b o ] . [ T 2 _ C H E M _ M I X ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 3 : 2 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 S E T   A N S I _ P A D D I N G   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ M I X ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 B E G I N  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ C H E M _ M I X ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   N O T   N U L L ,  
 	 [ C A S N u m b e r ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ C o m p o n e n t ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ C o m p o n e n t P e r c e n t a g e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
 	 [ W e i g h t O r V o l u m e ]   [ v a r c h a r ] ( 2 5 5 )   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ M I X ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
 E N D  
 G O  
 S E T   A N S I _ P A D D I N G   O F F  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ F A C _ N A I C S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ F A C _ N A I C S ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ F A C _ N A I C S ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ F A C _ N A I C S . N A I C S C o d e  
 ,   T 2 _ F A C _ N A I C S . N A I C S I n d u s t r y C o d e  
 ,   T 2 _ F A C _ N A I C S . N A I C S G r o u p C o d e  
 ,   T 2 _ F A C _ N A I C S . N A I C S S u b s e c t o r C o d e  
 ,   T 2 _ F A C _ N A I C S . N A I C S S e c t o r C o d e  
 F R O M   d b o . T 2 _ F A C _ N A I C S   I N N E R   J O I N   d b o . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ N A I C S . F K _ G U I D   =   T 2 _ F A C _ S I T E . P K _ G U I D ) '  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ T I E R 2 _ G e t T I E R 2 B y C h a n g e D a t e ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T I E R 2 _ G e t T I E R 2 B y C h a n g e D a t e ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 T K   C o n r a d  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 7 - 2 0  
 - -   D e s c r i p t i o n : 	 H E R E - T I E R 2   F l o w   d a t a   r e t r i e v a l    
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ T I E R 2 _ G e t T I E R 2 B y C h a n g e D a t e ]  
 	 @ C h a n g e D a t e   d a t e t i m e ,  
         @ L i s t I n d e x   i n t  
 A S  
 B E G I N  
 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 S E T   N O C O U N T   O N ;  
  
 - -   D E C L A R E   @ C h a n g e D a t e   d a t e t i m e  
 - -   s e t   @ c h a n g e D a t e   =   ' ' 1 9 0 0 - 0 1 - 0 1 ' '  
  
 / *  
  
         D O   N O T   C H A N G E   T H E   O R D E R   O F   T H E S E   S E L E C T S  
         T H E S E   A R E   M A P P E D   T O   O B J E C T S  
  
 * /  
  
 D E C L A R E   @ f l o w T y p e   v a r c h a r ( 5 0 )  
 S E T   @ f l o w T y p e   =   ' ' H E R E - T I E R 2 ' ' ;  
  
 - -   0 .   T 2 _ S U B M I S S I O N  
 I F   @ L i s t I n d e x   =   0  
  
         S E L E C T 	 d b o . T 2 _ S U B M I S S I O N . *  
         F R O M   d b o . T 2 _ S U B M I S S I O N  
         J O I N   d b o . T 2 _ R E P O R T   O N   d b o . T 2 _ S U B M I S S I O N . P K _ G U I D   =   d b o . T 2 _ R E P O R T . F K _ G U I D  
         J O I N   d b o . T 2 _ F A C _ S I T E   O N   d b o . T 2 _ R E P O R T . P K _ G U I D   =   d b o . T 2 _ F A C _ S I T E . F K _ G U I D  
         J O I N   d b o . C H A N G E D _ F A C I L I T I E S   O N   d b o . C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   d b o . T 2 _ F A C _ S I T E . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   d b o . C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 d b o . C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   d b o . C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
         G R O U P   B Y  
         T 2 _ S U B M I S S I O N . P K _ G U I D  
         , T 2 _ S U B M I S S I O N . S u b m i s s i o n D a t e  
         , T 2 _ S U B M I S S I O N . S u b m i s s i o n I d e n t i f i e r  
         , T 2 _ S U B M I S S I O N . S u b m i s s i o n M e t h o d  
         , T 2 _ S U B M I S S I O N . S u b m i s s i o n S t a t u s ;  
  
  
 - -   1 .   T 2 _ R E P O R T  
 E L S E   I F   @ L i s t I n d e x   =   1  
  
         S E L E C T 	 d b o . T 2 _ R E P O R T . *  
         F R O M   d b o . T 2 _ R E P O R T  
         J O I N   d b o . T 2 _ F A C _ S I T E   O N   d b o . T 2 _ R E P O R T . P K _ G U I D   =   d b o . T 2 _ F A C _ S I T E . F K _ G U I D  
         J O I N   d b o . C H A N G E D _ F A C I L I T I E S   O N   d b o . C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   d b o . T 2 _ F A C _ S I T E . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   d b o . C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 d b o . C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   d b o . C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
         G R O U P   B Y  
         T 2 _ R E P O R T . F K _ G U I D  
         , T 2 _ R E P O R T . P K _ G U I D  
         , T 2 _ R E P O R T . R e p l a c e d R e p o r t I d e n t i f i e r  
         , T 2 _ R E P O R T . R e p o r t C r e a t e B y N a m e  
         , T 2 _ R E P O R T . R e p o r t C r e a t e D a t e  
         , T 2 _ R E P O R T . R e p o r t C r e a t e T i m e  
         , T 2 _ R E P O R T . R e p o r t D u e D a t e  
         , T 2 _ R E P O R T . R e p o r t I d e n t i f i e r  
         , T 2 _ R E P O R T . R e p o r t i n g P e r i o d E n d D a t e  
         , T 2 _ R E P O R T . R e p o r t i n g P e r i o d S t a r t D a t e  
         , T 2 _ R E P O R T . R e p o r t R e c e i v e d D a t e  
         , T 2 _ R E P O R T . R e p o r t R e c i p i e n t N a m e  
         , T 2 _ R E P O R T . R e p o r t T y p e  
         , T 2 _ R E P O R T . R e v i s i o n I n d i c a t o r ;  
  
  
 - -   2 .   T 2 _ F A C _ S I T E  
 E L S E   I F   @ L i s t I n d e x   =   2  
  
         S E L E C T 	 d b o . T 2 _ F A C _ S I T E . *  
         F R O M   d b o . T 2 _ F A C _ S I T E  
         J O I N   d b o . C H A N G E D _ F A C I L I T I E S   O N   d b o . C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   d b o . T 2 _ F A C _ S I T E . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   d b o . C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 d b o . C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   d b o . C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0 ;  
  
  
 - -   3 .   T 2 _ F A C _ D U N D B _ I D  
 E L S E   I F   @ L i s t I n d e x   =   3  
  
         S E L E C T 	 D B . *  
         F R O M   d b o . T 2 _ F A C _ D U N D B _ I D   D B  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   D B . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 - -   4 .   T 2 _ F A C _ G E O  
 E L S E   I F   @ L i s t I n d e x   =   4  
  
         S E L E C T 	 G . *  
         F R O M   d b o . T 2 _ F A C _ G E O   G  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   G . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 - -   5 .   T 2 _ F A C _ N A I C S  
 E L S E   I F   @ L i s t I n d e x   =   5  
  
         S E L E C T 	 N . *  
         F R O M   d b o . T 2 _ F A C _ N A I C S   N  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   N . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 - -   6 .   T 2 _ F A C _ N P D E S _ I D  
 E L S E   I F   @ L i s t I n d e x   =   6  
  
         S E L E C T 	 N . *  
         F R O M   d b o . T 2 _ F A C _ N P D E S _ I D   N  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   N . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 - -   7 .   T 2 _ F A C _ R C R A _ I D  
 E L S E   I F   @ L i s t I n d e x   =   7  
  
         S E L E C T 	 R . *  
         F R O M   d b o . T 2 _ F A C _ R C R A _ I D   R  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   R . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 - -   8 .   T 2 _ F A C _ S I C  
 E L S E   I F   @ L i s t I n d e x   =   8  
  
         S E L E C T 	 S . *  
         F R O M   d b o . T 2 _ F A C _ S I C   S  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   S . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 - -   9 .   T 2 _ F A C _ U I C _ I D  
 E L S E   I F   @ L i s t I n d e x   =   9  
  
         S E L E C T 	 U . *  
         F R O M   d b o . T 2 _ F A C _ U I C _ I D   U  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   U . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 - -   1 0 .   T 2 _ F A C _ I N D  
 E L S E   I F   @ L i s t I n d e x   =   1 0  
  
         S E L E C T 	 I . *  
         F R O M   d b o . T 2 _ F A C _ I N D   I  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 - -   1 1 .   T 2 _ F A C _ I N D _ E M A I L  
 E L S E   I F   @ L i s t I n d e x   =   1 1  
  
         S E L E C T 	 E M A I L . *  
         F R O M   d b o . T 2 _ F A C _ I N D _ E M A I L   E M A I L  
         J O I N   d b o . T 2 _ F A C _ I N D   I   O N   I . P K _ G U I D   =   E M A I L . F K _ G U I D  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 - -   1 2 .   T 2 _ F A C _ I N D _ P H O N E  
 E L S E   I F   @ L i s t I n d e x   =   1 2  
  
         S E L E C T 	 P H O N E . *  
         F R O M   d b o . T 2 _ F A C _ I N D _ P H O N E   P H O N E  
         J O I N   d b o . T 2 _ F A C _ I N D   I   O N   I . P K _ G U I D   =   P H O N E . F K _ G U I D  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 - -   1 3 .   T 2 _ F A C _ I N D _ T Y P E  
 E L S E   I F   @ L i s t I n d e x   =   1 3  
  
         S E L E C T 	 T Y P E . *  
         F R O M   d b o . T 2 _ F A C _ I N D _ T Y P E   T Y P E  
         J O I N   d b o . T 2 _ F A C _ I N D   I   O N   I . P K _ G U I D   =   T Y P E . F K _ G U I D  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 - -   1 4 .   T 2 _ C H E M _ I N V  
 E L S E   I F   @ L i s t I n d e x   =   1 4  
  
         S E L E C T 	 I N V . *  
         F R O M   d b o . T 2 _ C H E M _ I N V   I N V  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I N V . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 - -   1 5 .   T 2 _ C H E M _ I N V _ D T L S  
 E L S E   I F   @ L i s t I n d e x   =   1 5  
  
         S E L E C T 	 D T L S . *  
         F R O M   d b o . T 2 _ C H E M _ I N V _ D T L S   D T L S  
         J O I N   d b o . T 2 _ C H E M _ I N V   I N V   O N   I N V . P K _ G U I D   =   D T L S . F K _ G U I D  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I N V . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 - -   1 6 .   T 2 _ C H E M _ I N V _ H A Z  
 E L S E   I F   @ L i s t I n d e x   =   1 6  
  
         S E L E C T 	 H A Z . *  
         F R O M   d b o . T 2 _ C H E M _ I N V _ H A Z   H A Z  
         J O I N   d b o . T 2 _ C H E M _ I N V   I N V   O N   I N V . P K _ G U I D   =   H A Z . F K _ G U I D  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I N V . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 - -   1 7 .     T 2 _ C H E M _ I N V _ H L T H  
 E L S E   I F   @ L i s t I n d e x   =   1 7  
  
         S E L E C T 	 H L T H . *  
         F R O M   d b o . T 2 _ C H E M _ I N V _ H L T H   H L T H  
         J O I N   d b o . T 2 _ C H E M _ I N V   I N V   O N   I N V . P K _ G U I D   =   H L T H . F K _ G U I D  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I N V . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 - -   1 8 .     T 2 _ C H E M _ I N V _ P H Y S  
 E L S E   I F   @ L i s t I n d e x   =   1 8  
  
         S E L E C T 	 P H Y S . *  
         F R O M   d b o . T 2 _ C H E M _ I N V _ P H Y S   P H Y S  
         J O I N   d b o . T 2 _ C H E M _ I N V   I N V   O N   I N V . P K _ G U I D   =   P H Y S . F K _ G U I D  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I N V . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 - -   1 9 .     T 2 _ C H E M _ L O C  
 E L S E   I F   @ L i s t I n d e x   =   1 9  
  
         S E L E C T 	 L O C . *  
         F R O M   d b o . T 2 _ C H E M _ L O C   L O C  
         J O I N   d b o . T 2 _ C H E M _ I N V   I N V   O N   I N V . P K _ G U I D   =   L O C . F K _ G U I D  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I N V . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 - -   2 0 .     T 2 _ C H E M _ M I X  
 E L S E   I F   @ L i s t I n d e x   =   2 0  
  
         S E L E C T 	 M I X . *  
         F R O M   d b o . T 2 _ C H E M _ M I X   M I X  
         J O I N   d b o . T 2 _ C H E M _ I N V   I N V   O N   I N V . P K _ G U I D   =   M I X . F K _ G U I D  
         J O I N   d b o . T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I N V . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
 E N D  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ N E _ T I E R 2 _ I N I T ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ N E _ T I E R 2 _ I N I T ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	   K e v i n   J a m e s   ( W i n d s o r   S o l u t i o n s ,   I n c . )  
 - -   C r e a t e   d a t e :     J u l y   0 6 ,   2 0 0 7  
 - -   D e s c r i p t i o n : 	   T h i s   p r o c e d u r e   w i l l   s e t - u p   t h e   H E R E   F R S   t a b l e s   f o r    
 - -                               p r o c e s s i n g .        
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ N E _ T I E R 2 _ I N I T ]   @ v a l u e   I N T   O U T P U T  
  
 A S  
 B E G I N  
         D E C L A R E   @ E R R O R _ C O D E   I N T  
 	 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 	 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 	 S E T   N O C O U N T   O N ;  
  
         - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
         - -   D E L E T E   T 2 _ S U B M I S S I O N :     D e l e t e   r e c o r d s   f r o m   t h e   C O M P A R E   s c h e m a   t o   p r e p a r e   t h e     - -  
         - -                                     t a b l e s   f o r   d a t a   p o p u l a t e d   f r o m   t h e   p r e v i o u s   r u n   i n           - -  
         - -                                     t h e   S T A G I N G   s c h e m a .  
         - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 D E L E T E   F R O M   [ c m p ] . [ T 2 _ S U B M I S S I O N ]  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ S U B M I S S I O N  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ S U B M I S S I O N  
 	 S E L E C T   *   F R O M   d b o . T 2 _ S U B M I S S I O N  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ R E P O R T  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ R E P O R T  
 	 S E L E C T   *   F R O M   d b o . T 2 _ R E P O R T  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ F A C _ S I T E  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ F A C _ S I T E  
 	 S E L E C T   *   F R O M   d b o . T 2 _ F A C _ S I T E  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ F A C _ D U N D B _ I D  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ F A C _ D U N D B _ I D  
 	 S E L E C T   *   F R O M   d b o . T 2 _ F A C _ D U N D B _ I D  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ F A C _ G E O  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ F A C _ G E O  
 	 S E L E C T   *   F R O M   d b o . T 2 _ F A C _ G E O  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ F A C _ N A I C S  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ F A C _ N A I C S  
 	 S E L E C T   *   F R O M   d b o . T 2 _ F A C _ N A I C S  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ F A C _ N P D E S _ I D  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ F A C _ N P D E S _ I D  
 	 S E L E C T   *   F R O M   d b o . T 2 _ F A C _ N P D E S _ I D  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ F A C _ R C R A _ I D  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ F A C _ R C R A _ I D  
 	 S E L E C T   *   F R O M   d b o . T 2 _ F A C _ R C R A _ I D  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ F A C _ S I C  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ F A C _ S I C  
 	 S E L E C T   *   F R O M   d b o . T 2 _ F A C _ S I C  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ F A C _ U I C _ I D  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ F A C _ U I C _ I D  
 	 S E L E C T   *   F R O M   d b o . T 2 _ F A C _ U I C _ I D  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ F A C _ I N D  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ F A C _ I N D  
 	 S E L E C T   *   F R O M   d b o . T 2 _ F A C _ I N D  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ F A C _ I N D _ E M A I L  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ F A C _ I N D _ E M A I L  
 	 S E L E C T   *   F R O M   d b o . T 2 _ F A C _ I N D _ E M A I L  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ F A C _ I N D _ P H O N E  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ F A C _ I N D _ P H O N E  
 	 S E L E C T   *   F R O M   d b o . T 2 _ F A C _ I N D _ P H O N E  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ F A C _ I N D _ T Y P E  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ F A C _ I N D _ T Y P E  
 	 S E L E C T   *   F R O M   d b o . T 2 _ F A C _ I N D _ T Y P E  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ C H E M _ I N V  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ C H E M _ I N V  
 	 S E L E C T   *   F R O M   d b o . T 2 _ C H E M _ I N V  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ C H E M _ I N V _ D T L S  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ C H E M _ I N V _ D T L S  
 	 S E L E C T   *   F R O M   d b o . T 2 _ C H E M _ I N V _ D T L S  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ C H E M _ I N V _ H A Z  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ C H E M _ I N V _ H A Z  
 	 S E L E C T   *   F R O M   d b o . T 2 _ C H E M _ I N V _ H A Z  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ C H E M _ I N V _ H L T H  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ C H E M _ I N V _ H L T H  
 	 S E L E C T   *   F R O M   d b o . T 2 _ C H E M _ I N V _ H L T H  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ C H E M _ I N V _ P H Y S  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ C H E M _ I N V _ P H Y S  
 	 S E L E C T   *   F R O M   d b o . T 2 _ C H E M _ I N V _ P H Y S  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ C H E M _ L O C  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ C H E M _ L O C  
 	 S E L E C T   *   F R O M   d b o . T 2 _ C H E M _ L O C  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     T 2 _ C H E M _ M I X  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   c m p . T 2 _ C H E M _ M I X  
 	 S E L E C T   *   F R O M   d b o . T 2 _ C H E M _ M I X  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 E N D  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ S U B M I S S I O N ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ S U B M I S S I O N ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ S U B M I S S I O N ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 - - ,   T 2 _ S U B M I S S I O N . S u b m i s s i o n I d e n t i f i e r  
 ,   T 2 _ S U B M I S S I O N . S u b m i s s i o n D a t e  
 ,   T 2 _ S U B M I S S I O N . S u b m i s s i o n S t a t u s  
 ,   T 2 _ S U B M I S S I O N . S u b m i s s i o n M e t h o d  
 F R O M   d b o . T 2 _ S U B M I S S I O N   I N N E R   J O I N   d b o . T 2 _ R E P O R T       O N   ( T 2 _ R E P O R T . F K _ G U I D   =   T 2 _ S U B M I S S I O N . P K _ G U I D )  
                                               I N N E R   J O I N   d b o . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ S I T E . F K _ G U I D   =   T 2 _ R E P O R T . P K _ G U I D )  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ F A C _ R C R A _ I D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ F A C _ R C R A _ I D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ F A C _ R C R A _ I D ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ F A C _ R C R A _ I D . R C R A I d e n t i f i c a t i o n N u m b e r  
 F R O M   d b o . T 2 _ F A C _ R C R A _ I D   I N N E R   J O I N   d b o . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ R C R A _ I D . F K _ G U I D   =   T 2 _ F A C _ S I T E . P K _ G U I D ) '  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ N E _ C A F O _ I N I T ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ N E _ C A F O _ I N I T ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
  
  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	   K e v i n   J a m e s   ( W i n d s o r   S o l u t i o n s ,   I n c . )  
 - -   C r e a t e   d a t e :     J u l y   0 6 ,   2 0 0 7  
 - -   D e s c r i p t i o n : 	   T h i s   p r o c e d u r e   w i l l   s e t - u p   t h e   H E R E   C A F O   t a b l e s   f o r    
 - -                               p r o c e s s i n g .        
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ N E _ C A F O _ I N I T ]     @ v a l u e   I N T   O U T P U T  
  
 A S  
 B E G I N  
  
         D E C L A R E   @ E R R O R _ C O D E   I N T  
 	 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 	 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 	 S E T   N O C O U N T   O N ;  
  
         - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
         - -   D E L E T E   F R S _ F A C :     D e l e t e   r e c o r d s   f r o m   t h e   C O M P A R E   s c h e m a   t o   p r e p a r e   t h e     - -  
         - -                                     t a b l e s   f o r   d a t a   p o p u l a t e d   f r o m   t h e   p r e v i o u s   r u n   i n           - -  
         - -                                     t h e   S T A G I N G   s c h e m a .  
         - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
         D E L E T E   F R O M   [ c m p ] . [ C A F O _ F A C ]  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ C A F O _ F A C ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ C A F O _ F A C ]  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ C A F O _ A D D ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ C A F O _ A D D ]  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ C A F O _ A N I M A L ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ C A F O _ A N I M A L ]  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ C A F O _ G E O ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ C A F O _ G E O ]  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ C A F O _ R E G _ D T L S ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ C A F O _ R E G _ D T L S ]  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ C A F O _ P E R M I T ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ C A F O _ P E R M I T ]  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 E N D  
  
  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ N E _ C A F O _ L O A D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ N E _ C A F O _ L O A D ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 T K   C o n r a d   ( W i n d s o r   S o l u t i o n s ,   I n c . )  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 6 - 1 8  
 - -   D e s c r i p t i o n : 	 L o a d s   t h e   C A F O   s c h e m a   t a b l e s   i n   p r e p a r a t i o n   f o r   c r e a t i n g   a n   X M L   f i l e .  
 - -                             N O T E :   t h i s   i s   t h e   p r o d u c t i o n   s p r o c .   T h e   o t h e r   C A F O   l o a d   p r o c e d u r e  
 - -                             i s   s o l e l y   f o r   t e s t i n g   o u t   t h e   C A F O   p l u g - i n .  
 - -   A s s u m p t i o n s : 	 T h i s   r u n s   a f t e r   t h e   p r o c e d u r e   t o   l o a d   t h e   F R S   s c h e m a   f o r   N e b r a s k a  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ N E _ C A F O _ L O A D ]   @ v a l u e   I N T   O U T P U T  
 	 - -   A d d   t h e   p a r a m e t e r s   f o r   t h e   s t o r e d   p r o c e d u r e   h e r e  
 A S  
 B E G I N  
 	 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 	 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 	 S E T   N O C O U N T   O N ;  
  
         D E C L A R E   @ E R R O R _ C O D E   I N T  
  
         - -   C l e a r   e x i s t i n g   r e c o r d s   i n   C A F O _ F A C  
 	 D E L E T E   F R O M   [ d b o ] . [ C A F O _ F A C ]  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     d b o . C A F O _ F a c i l i t y   - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ d b o ] . [ C A F O _ F A C ]  
 	 S E L E C T  
 	 	 	 	 N e w I d ( )   - -   < P K ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , F A C . F A C _ S I T E N M   - -   < F a c i l i t y S i t e N a m e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , N U L L   - -   < F a c i l i t y A l t N a m e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , N U L L   - -   < F a c i l i t y I n f o U R L ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , N U L L   - -   < F a c i l i t y R e g i s t r y I D ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , E I . S T _ F A C _ I N D   - -   < S t a t e F a c i l i t y I D ,   v a r c h a r ( 2 5 5 ) , > )  
  
 	 F R O M   d b o . F R S _ F A C   F A C  
 	 J O I N   d b o . F R S _ E I   E I   O N   F A C . S T _ F A C _ I N D   =   E I . S T _ F A C _ I N D  
 	 J O I N   d b o . N E _ C A F O _ S p e c i e s   C A F O S P E C   O N   F A C . S T _ F A C _ I N D   =   C O N V E R T ( V A R C H A R ,   C A F O S P E C . F A C I D )  
 	 W H E R E   E I . E N V _ I N T _ T Y P E   =   ' ' L W C ' '  
 	 G R O U P   B Y  
 	 	 F A C . F A C _ S I T E N M  
 	 , 	 E I . S T _ F A C _ I N D  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     d b o . C A F O _ A n i m a l T y p e   - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ d b o ] . [ C A F O _ A N I M A L ]  
 	 S E L E C T  
 	 	 	 	 N e w I d ( )   A S   P K   - -   < P K ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , C A F O F A C . P K   A S   F K   - -   < F K ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , C A F O M A P . S t a n d a r d C o d e   A S   A n i m a l T y p e C o d e   - -   < A n i m a l T y p e C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , C A F O M A P . D e s c r i p t i o n   A S   A n i m a l T y p e N a m e   - -   < A n i m a l T y p e N a m e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , C A F O S P E C . M A X A N I   A S   T o t a l N u m s E a c h L i v e s t o c k   - -   < T o t a l N u m s E a c h L i v e s t o c k ,   i n t , >  
 	 	 	       , C A S E   W H E N   I S N U L L ( C A F O O P E N . O L O T S ,   ' ' ' ' )   =   ' ' Y ' '   T H E N   C A F O S P E C . M A X A N I   E L S E   N U L L   E N D   A S   O p e n C o u n t   - -   < O p e n C o u n t ,   i n t , >  
 	 	 	       , C A S E   W H E N   I S N U L L ( C A F O O P E N . O L O T S ,   ' ' ' ' )   < >   ' ' Y ' '   T H E N   C A F O S P E C . M A X A N I   E L S E   N U L L   E N D   A S   H o u s e d U n d e r R o o f C o u n t   - -   < H o u s e d U n d e r R o o f C o u n t ,   i n t , > )  
 	 F R O M   d b o . C A F O _ F A C   C A F O F A C  
 	 J O I N   d b o . N E _ C A F O _ S p e c i e s   C A F O S P E C   O N  
 	 	 C A F O F A C . S t a t e F a c i l i t y I D   =   C O N V E R T ( V A R C H A R ,   C A F O S P E C . F A C I D )  
 	 L E F T   J O I N   d b o . N E _ C A F O _ O p e n L o t s   C A F O O P E N   O N  
 	 	 C A F O S P E C . F A C I D   =   C A F O O P E N . F A C I D   A N D  
 	 	 C A F O S P E C . S P E C I E   =   C A F O O P E N . S P E C I E  
 	 J O I N   d b o . L o o k u p _ C A F O _ M a p p i n g   C A F O M A P   O N  
 	 	 C A F O M A P . D e s c r i p t i o n   =   C A F O S P E C . S P E C I E  
 	 W H E R E  
 	 	 C A F O M A P . S t a t e   =   ' ' N E ' '  
 	 G R O U P   B Y  
 	         C A F O F A C . P K  
 	       , C A F O M A P . S t a n d a r d C o d e  
 	       , C A F O M A P . D e s c r i p t i o n  
 	       , C A F O S P E C . M A X A N I  
 	       , C A F O O P E N . O L O T S  
  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 E N D  
  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     U s e r D e f i n e d F u n c t i o n   [ d b o ] . [ u d f t _ D i s p l a y C A F O I n f o ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ u d f t _ D i s p l a y C A F O I n f o ] ' )   A N D   t y p e   i n   ( N ' F N ' ,   N ' I F ' ,   N ' T F ' ,   N ' F S ' ,   N ' F T ' ) )  
 B E G I N  
 e x e c u t e   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 T K   C o n r a d   ( W i n d s o r   S o l u t i o n s ,   I n c . )  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 7 - 2 5  
 - -   D e s c r i p t i o n : 	 R e t u r n s   s e l e c t e d   C A F O   d a t a   f o r   a   p a s s e d - i n   F a c i l i t y   I D  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   F U N C T I O N   [ d b o ] . [ u d f t _ D i s p l a y C A F O I n f o ]    
 ( 	  
 	 - -   A d d   t h e   p a r a m e t e r s   f o r   t h e   f u n c t i o n   h e r e  
 	 @ F A C I D   i n t  
 )  
 R E T U R N S   T A B L E    
 A S  
 R E T U R N    
 (  
 	 - -   A d d   t h e   S E L E C T   s t a t e m e n t   w i t h   p a r a m e t e r   r e f e r e n c e s   h e r e  
 S E L E C T  
 	 F A C . S T _ F A C _ I N D   A S   F A C _ S T _ F A C _ I N D  
 , 	 F A C . F A C _ R E G _ I N D   A S   F A C _ F A C _ R E G _ I N D  
 , 	 F A C . F A C _ S I T E N M   A S   F A C _ F A C _ S I T E N M  
 , 	 F A C . F A C _ S I T E T Y P E _ N M   A S   F A C _ F A C _ S I T E T Y P E _ N M  
 , 	 F A C . F E D _ F A C   A S   F A C _ F E D _ F A C  
 , 	 F A C . T R I B _ L A N D   A S   F A C _ T R I B _ L A N D  
 , 	 F A C . T R I B _ L A N D _ N M   A S   F A C _ T R I B _ L A N D _ N M  
 , 	 F A C . C O N G _ D I S T _ N U M   A S   F A C _ C O N G _ D I S T _ N U M  
 , 	 F A C . L E G _ D I S T _ N U M   A S   F A C _ L E G _ D I S T _ N U M  
 , 	 F A C . H U C _ C D   A S   F A C _ H U C _ C D  
 , 	 F A C . L O C _ A D D   A S   F A C _ L O C _ A D D  
 , 	 F A C . S U P P L E M _ L O C   A S   F A C _ S U P P L E M _ L O C  
 , 	 F A C . L O C A L _ N M   A S   F A C _ L O C A L _ N M  
 , 	 F A C . C N T Y _ S T _ F I P S _ C D   A S   F A C _ C N T Y _ S T _ F I P S _ C D  
 , 	 F A C . C N T Y _ N M   A S   F A C _ C N T Y _ N M  
 , 	 F A C . S T _ C D   A S   F A C _ S T _ C D  
 , 	 F A C . S T _ N M   A S   F A C _ S T _ N M  
 , 	 F A C . C O _ N M   A S   F A C _ C O _ N M  
 , 	 F A C . L O C _ Z I P _ C D   A S   F A C _ L O C _ Z I P _ C D  
 , 	 F A C . L O C _ D E S C   A S   F A C _ L O C _ D E S C  
 , 	 F A C . D A T A _ S R C _ N M   A S   F A C _ D A T A _ S R C _ N M  
 , 	 F A C . R E P O R T E D _ D A T E   A S   F A C _ R E P O R T E D _ D A T E  
 , 	 F A C . S T _ F A C _ S Y S _ A C   A S   F A C _ S T _ F A C _ S Y S _ A C  
 , 	 E I . S T _ E I _ I N D   A S   E I _ S T _ E I _ I N D  
 , 	 E I . S T _ F A C _ I N D   A S   E I _ S T _ F A C _ I N D  
 , 	 E I . I N F _ S Y S _ A C   A S   E I _ I N F _ S Y S _ A C  
 , 	 E I . I N F _ S Y S _ I N D   A S   E I _ I N F _ S Y S _ I N D  
 , 	 E I . E N V _ I N T _ T Y P E   A S   E I _ E N V _ I N T _ T Y P E  
 , 	 E I . F E D _ S T _ I N T   A S   E I _ F E D _ S T _ I N T  
 , 	 E I . E N V _ I N T _ S T A R T _ D A T E   A S   E I _ E N V _ I N T _ S T A R T _ D A T E  
 , 	 E I . I N T _ S T A R T _ D A T E _ Q U A L   A S   E I _ I N T _ S T A R T _ D A T E _ Q U A L  
 , 	 E I . E N V _ I N T _ E N D _ D A T E   A S   E I _ E N V _ I N T _ E N D _ D A T E  
 , 	 E I . I N T _ E N D _ D A T E _ Q U A L   A S   E I _ I N T _ E N D _ D A T E _ Q U A L  
 , 	 C A F O . P K   A S   C A F O _ P K  
 , 	 C A F O . F a c i l i t y S i t e N a m e   A S   C A F O _ F a c i l i t y S i t e N a m e  
 , 	 C A F O . F a c i l i t y A l t N a m e   A S   C A F O _ F a c i l i t y A l t N a m e  
 , 	 C A F O . F a c i l i t y I n f o U R L   A S   C A F O _ F a c i l i t y I n f o U R L  
 , 	 C A F O . F a c i l i t y R e g i s t r y I D   A S   C A F O _ F a c i l i t y R e g i s t r y I D  
 , 	 C A F O . S t a t e F a c i l i t y I D   A S   C A F O _ S t a t e F a c i l i t y I D  
 , 	 C A F O A N I . P K   A S   C A F O A N I _ P K  
 , 	 C A F O A N I . F K   A S   C A F O A N I _ F K  
 , 	 C A F O A N I . A n i m a l T y p e C o d e   A S   C A F O A N I _ A n i m a l T y p e C o d e  
 , 	 C A F O A N I . A n i m a l T y p e N a m e   A S   C A F O A N I _ A n i m a l T y p e N a m e  
 , 	 C A F O A N I . T o t a l N u m s E a c h L i v e s t o c k   A S   C A F O A N I _ T o t a l N u m s E a c h L i v e s t o c k  
 , 	 C A F O A N I . O p e n C o u n t   A S   C A F O A N I _ O p e n C o u n t  
 , 	 C A F O A N I . H o u s e d U n d e r R o o f C o u n t   A S   C A F O A N I _ H o u s e d U n d e r R o o f C o u n t  
  
 F R O M   d b o . F R S _ F A C   F A C  
 J O I N   d b o . F R S _ E I   E I   O N   F A C . S T _ F A C _ I N D   =   E I . S T _ F A C _ I N D  
 J O I N   d b o . C A F O _ F A C   C A F O  
 	 J O I N   d b o . C A F O _ A N I M A L   C A F O A N I   O N   C A F O . P K   =   C A F O A N I . F K  
 O N   F A C . S T _ F A C _ I N D   =   C A F O . S t a t e F a c i l i t y I D  
  
 W H E R E   F A C . S T _ F A C _ I N D   =   C O N V E R T ( V A R C H A R ,   @ F A C I D )  
 ) '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     U s e r D e f i n e d F u n c t i o n   [ d b o ] . [ u d f t _ D i s p l a y F a c i l i t y I n f o ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ u d f t _ D i s p l a y F a c i l i t y I n f o ] ' )   A N D   t y p e   i n   ( N ' F N ' ,   N ' I F ' ,   N ' T F ' ,   N ' F S ' ,   N ' F T ' ) )  
 B E G I N  
 e x e c u t e   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 T K   C o n r a d   ( W i n d s o r   S o l u t i o n s ,   I n c . )  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 7 - 2 5  
 - -   D e s c r i p t i o n : 	 R e t u r n s   s e l e c t e d   f a c i l i t y   d a t a   f o r   a   p a s s e d - i n   F a c i l i t y   I D  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   F U N C T I O N   [ d b o ] . [ u d f t _ D i s p l a y F a c i l i t y I n f o ]    
 ( 	  
 	 - -   A d d   t h e   p a r a m e t e r s   f o r   t h e   f u n c t i o n   h e r e  
 	 @ F A C I D   i n t  
 )  
 R E T U R N S   T A B L E    
 A S  
 R E T U R N    
 (  
 	 - -   A d d   t h e   S E L E C T   s t a t e m e n t   w i t h   p a r a m e t e r   r e f e r e n c e s   h e r e  
 S E L E C T  
 	 F A C . S T _ F A C _ I N D   A S   F A C _ S T _ F A C _ I N D  
 , 	 F A C . F A C _ R E G _ I N D   A S   F A C _ F A C _ R E G _ I N D  
 , 	 F A C . F A C _ S I T E N M   A S   F A C _ F A C _ S I T E N M  
 , 	 F A C . F A C _ S I T E T Y P E _ N M   A S   F A C _ F A C _ S I T E T Y P E _ N M  
 , 	 F A C . F E D _ F A C   A S   F A C _ F E D _ F A C  
 , 	 F A C . T R I B _ L A N D   A S   F A C _ T R I B _ L A N D  
 , 	 F A C . T R I B _ L A N D _ N M   A S   F A C _ T R I B _ L A N D _ N M  
 , 	 F A C . C O N G _ D I S T _ N U M   A S   F A C _ C O N G _ D I S T _ N U M  
 , 	 F A C . L E G _ D I S T _ N U M   A S   F A C _ L E G _ D I S T _ N U M  
 , 	 F A C . H U C _ C D   A S   F A C _ H U C _ C D  
 , 	 F A C . L O C _ A D D   A S   F A C _ L O C _ A D D  
 , 	 F A C . S U P P L E M _ L O C   A S   F A C _ S U P P L E M _ L O C  
 , 	 F A C . L O C A L _ N M   A S   F A C _ L O C A L _ N M  
 , 	 F A C . C N T Y _ S T _ F I P S _ C D   A S   F A C _ C N T Y _ S T _ F I P S _ C D  
 , 	 F A C . C N T Y _ N M   A S   F A C _ C N T Y _ N M  
 , 	 F A C . S T _ C D   A S   F A C _ S T _ C D  
 , 	 F A C . S T _ N M   A S   F A C _ S T _ N M  
 , 	 F A C . C O _ N M   A S   F A C _ C O _ N M  
 , 	 F A C . L O C _ Z I P _ C D   A S   F A C _ L O C _ Z I P _ C D  
 , 	 F A C . L O C _ D E S C   A S   F A C _ L O C _ D E S C  
 , 	 F A C . D A T A _ S R C _ N M   A S   F A C _ D A T A _ S R C _ N M  
 , 	 F A C . R E P O R T E D _ D A T E   A S   F A C _ R E P O R T E D _ D A T E  
 , 	 F A C . S T _ F A C _ S Y S _ A C   A S   F A C _ S T _ F A C _ S Y S _ A C  
 , 	 E I . S T _ E I _ I N D   A S   E I _ S T _ E I _ I N D  
 , 	 E I . S T _ F A C _ I N D   A S   E I _ S T _ F A C _ I N D  
 , 	 E I . I N F _ S Y S _ A C   A S   E I _ I N F _ S Y S _ A C  
 , 	 E I . I N F _ S Y S _ I N D   A S   E I _ I N F _ S Y S _ I N D  
 , 	 E I . E N V _ I N T _ T Y P E   A S   E I _ E N V _ I N T _ T Y P E  
 , 	 E I . F E D _ S T _ I N T   A S   E I _ F E D _ S T _ I N T  
 , 	 E I . E N V _ I N T _ S T A R T _ D A T E   A S   E I _ E N V _ I N T _ S T A R T _ D A T E  
 , 	 E I . I N T _ S T A R T _ D A T E _ Q U A L   A S   E I _ I N T _ S T A R T _ D A T E _ Q U A L  
 , 	 E I . E N V _ I N T _ E N D _ D A T E   A S   E I _ E N V _ I N T _ E N D _ D A T E  
 , 	 E I . I N T _ E N D _ D A T E _ Q U A L   A S   E I _ I N T _ E N D _ D A T E _ Q U A L  
  
 F R O M   d b o . F R S _ F A C   F A C  
 J O I N   d b o . F R S _ E I   E I   O N   F A C . S T _ F A C _ I N D   =   E I . S T _ F A C _ I N D  
 L E F T   J O I N   d b o . C A F O _ F A C   C A F O  
 	 J O I N   d b o . C A F O _ A N I M A L   C A F O A N I   O N   C A F O . P K   =   C A F O A N I . F K  
 O N   F A C . S T _ F A C _ I N D   =   C A F O . S t a t e F a c i l i t y I D  
 L E F T   J O I N   d b o . T 2 _ F A C _ S I T E   T 2  
 	 J O I N   d b o . T 2 _ C H E M _ I N V   T 2 C H E M I N V   O N   T 2 . P K _ G U I D   =   T 2 C H E M I N V . F K _ G U I D  
 	 J O I N   d b o . T 2 _ C H E M _ L O C   T 2 C H E M L O C   O N   T 2 C H E M I N V . P K _ G U I D   =   T 2 C H E M L O C . F K _ G U I D  
 O N   F A C . S T _ F A C _ I N D   =   T 2 . F a c i l i t y S i t e I d e n t i f i e r  
  
 W H E R E   F A C . S T _ F A C _ I N D   =   C O N V E R T ( V A R C H A R ,   @ F A C I D )  
  
 )  
  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ C A F O _ A D D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ C A F O _ A D D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ C A F O _ A D D ]   A S  
 S E L E C T   C A F O _ F A C . S t a t e F a c i l i t y I D  
           ,   L o c a t i o n A d d r e s s  
           ,   S u p p l e m e n t a l A d d r e s s  
           ,   L o c a l i t y N a m e  
           ,   C o u n t y N a m e  
           ,   S t a t e N a m e  
           ,   S t a t e U S P S C o d e  
           ,   A d d r e s s P o s t a l C o d e  
     F R O M   d b o . C A F O _ F A C   I N N E R   J O I N   d b o . C A F O _ A D D   O N   ( C A F O _ F A C . P K   =   C A F O _ A D D . F K ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ C A F O _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ C A F O _ F A C ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ C A F O _ F A C ]   A S  
 s e l e c t   S t a t e F a c i l i t y I D  
         ,   F a c i l i t y S i t e N a m e  
 	 ,   F a c i l i t y A l t N a m e  
 	 ,   F a c i l i t y I n f o U R L  
 	 ,   F a c i l i t y R e g i s t r y I D  
     f r o m   d b o . C A F O _ F A C   '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ C A F O _ A N I M A L ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ C A F O _ A N I M A L ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - - - - - - - - - - - - - - - -  
 - -     C A F O _ A N I M A L     - -  
 - - - - - - - - - - - - - - - -  
 C R E A T E   V I E W   [ d b o ] . [ v w _ C A F O _ A N I M A L ]   A S  
 s e l e c t   C A F O _ F A C . S t a t e F a c i l i t y I D  
 	 ,   A n i m a l T y p e C o d e  
 	 ,   A n i m a l T y p e N a m e  
 	 ,   T o t a l N u m s E a c h L i v e s t o c k  
 	 ,   O p e n C o u n t  
 	 ,   H o u s e d U n d e r R o o f C o u n t  
     f r o m   d b o . C A F O _ A N I M A L   I N N E R   J O I N   d b o . C A F O _ F A C   o n   ( C A F O _ F A C . P K   =   C A F O _ A N I M A L . F K ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ C A F O _ P E R M I T ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ C A F O _ P E R M I T ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ C A F O _ P E R M I T ]   A S  
 s e l e c t   C A F O _ F A C . S t a t e F a c i l i t y I D  
 	 ,   P e r m i t I d  
 	 ,   P e r m i t N a m e  
 	 ,   O t h e r P e r m i t I d  
 	 ,   P r o g r a m N a m e  
 	 ,   P e r m i t T y p e C o d e  
 	 ,   P e r m i t T y p e C o d e L i s t I D  
 	 ,   P e r m i t T y p e N a m e  
     f r o m   d b o . C A F O _ P E R M I T   I N N E R   J O I N   d b o . C A F O _ R E G _ D T L S   o n   ( C A F O _ R E G _ D T L S . P K   =   C A F O _ P E R M I T . F K )  
                                               I N N E R   J O I N   d b o . C A F O _ F A C   o n   ( C A F O _ F A C . P K   =   C A F O _ R E G _ D T L S . F K ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ C A F O _ R E G _ D T L S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ C A F O _ R E G _ D T L S ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' - - - - - - - - - - - - - - - - - - - - -  
 - -     C A F O _ R E G _ D T L S     - -  
 - - - - - - - - - - - - - - - - - - - - -  
 C R E A T E   V I E W   [ d b o ] . [ v w _ C A F O _ R E G _ D T L S ]   A S  
 s e l e c t     C A F O _ F A C . S t a t e F a c i l i t y I D  
         ,   D i s c h r g F r o m P r o d A r e a  
 	 ,   A u t h o r i z e d D i s c h a r g e  
 	 ,   U n a u t h o r i z e d D i s c h a r g e  
 	 ,   P e r m i t t i n g A u t h R e p R e c D a t e  
 	 ,   I s A n i m a l F a c i l i t y T y p e C A F O  
 	 ,   L i q M a n u r e V a l u e  
 	 ,   L i q M a n u r e U n i t C o d e  
 	 ,   L i q M a n u r e U n i t C o d e L i s t I D  
 	 ,   L i q M a n u r e U n i t N a m e  
 	 ,   L i q M a n u r e P r e c  
 	 ,   L i q M a n u r e R e s u l t C o d e  
 	 ,   L i q M a n u r e R e s u l t C o d e L i s t I D  
 	 ,   L i q M a n u r e R e s u l t N a m e  
 	 ,   L i q M a n u r e T r a n V a l u e  
 	 ,   L i q M a n u r e T r a n U n i t C o d e  
 	 ,   L i q M a n u r e T r a n U n i t C o d e L i s t I D  
 	 ,   L i q M a n u r e T r a n U n i t N a m e  
 	 ,   L i q M a n u r e T r a n P r e c  
 	 ,   L i q M a n u r e T r a n R e s u l t C o d e  
 	 ,   L i q M a n u r e T r a n R e s u l t C o d e L i s t I D  
 	 ,   L i q M a n u r e T r a n R e s u l t N a m e  
 	 ,   S o l M a n u r e V a l u e  
 	 ,   S o l M a n u r e U n i t C o d e  
 	 ,   S o l M a n u r e U n i t C o d e L i s t I D  
 	 ,   S o l M a n u r e U n i t N a m e  
 	 ,   S o l M a n u r e P r e c  
 	 ,   S o l M a n u r e R e s u l t C o d e  
 	 ,   S o l M a n u r e R e s u l t C o d e L i s t I D  
 	 ,   S o l M a n u r e R e s u l t N a m e  
 	 ,   S o l M a n u r e T r a n V a l u e  
 	 ,   S o l M a n u r e T r a n U n i t C o d e  
 	 ,   S o l M a n u r e T r a n U n i t C o d e L i s t I D  
 	 ,   S o l M a n u r e T r a n U n i t N a m e  
 	 ,   S o l M a n u r e T r a n P r e c  
 	 ,   S o l M a n u r e T r a n R e s u l t C o d e  
 	 ,   S o l M a n u r e T r a n R e s u l t C o d e L i s t I D  
 	 ,   S o l M a n u r e T r a n R e s u l t N a m e  
 	 ,   N M P D e v C e r t P l a n A p p r o v e d  
 	 ,   T o t a l N u m A c r e s N M P I d e n t i f i e d  
 	 ,   T o t a l N u m A c r e s U s e d L a n d A p p  
     f r o m   d b o . C A F O _ R E G _ D T L S   I N N E R   J O I N   d b o . C A F O _ F A C   o n   ( C A F O _ F A C . P K   =   C A F O _ R E G _ D T L S . F K ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ C A F O _ G E O ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ C A F O _ G E O ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ C A F O _ G E O ]   A S  
 s e l e c t   C A F O _ F A C . S t a t e F a c i l i t y I D  
 	 , L a t i t u d e  
 	 , L o n g i t u d e  
 	 , H o r i z A c c u r V a l u e  
 	 , H o r i z A c c u r U n i t C o d e  
 	 , H o r i z A c c u r U n i t C o d e L i s t I D  
 	 , H o r i z A c c u r U n i t N a m e  
 	 , P r e c T e x t  
 	 , R e s u l t Q u a l C o d e  
 	 , R e s u l t Q u a l C o d e L i s t I D  
 	 , R e s u l t Q u a l N a m e  
 	 , H o r i z M e t h o d I D C o d e  
 	 , H o r i z M e t h o d I D C o d e L i s t I D  
 	 , H o r i z M e t h o d N a m e  
 	 , H o r i z M e t h o d D e s c  
 	 , H o r i z M e t h o d D e v i a t i o n s  
 	 , H y d r o l o g i c U n i t C o d e  
 	 , L o c a t i o n C o m m e n t s  
     f r o m   d b o . C A F O _ G E O   I N N E R   J O I N   d b o . C A F O _ F A C   o n   ( C A F O _ F A C . P K   =   C A F O _ G E O . F K )  
 '  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ C A F O _ G e t C A F O B y C h a n g e D a t e ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 0 9   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ G e t C A F O B y C h a n g e D a t e ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 E r i c   S c h w e n t e r  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 6 - 2 5  
 - -   D e s c r i p t i o n : 	 C A F O   F l o w   d a t a   r e t r i e v a l    
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ C A F O _ G e t C A F O B y C h a n g e D a t e ]  
 	 @ C h a n g e D a t e   d a t e t i m e ,  
         @ L i s t I n d e x   i n t  
 A S  
 B E G I N  
  
 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 S E T   N O C O U N T   O N ;  
  
 D E C L A R E   @ f l o w T y p e   v a r c h a r ( 5 0 )  
 S E T   @ f l o w T y p e   =   ' ' H E R E - C A F O ' ' ;  
  
 - -   C A F O _ F A C  
 I F   @ L i s t I n d e x   =   0  
 	 S E L E C T 	 F . *  
 	 F R O M   d b o . C A F O _ F A C   F  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . S t a t e F a c i l i t y I D  
 	 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 	 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 	 A N D   c . I S _ D E L E T E D   =   0 ;  
  
 - -   C A F O _ A D D  
 E L S E   I F   @ L i s t I n d e x   =   1  
 	 S E L E C T 	 A . *  
 	 F R O M   d b o . C A F O _ A D D   A  
 	 J O I N   d b o . C A F O _ F A C   F   O N   F . P K   =   A . F K  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . S t a t e F a c i l i t y I D  
 	 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 	 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 	 A N D   c . I S _ D E L E T E D   =   0 ;  
  
  
 - -   C A F O _ A N I M A L  
 E L S E   I F   @ L i s t I n d e x   =   2  
 	 S E L E C T 	 A . *  
 	 F R O M   d b o . C A F O _ A N I M A L   A  
 	 J O I N   d b o . C A F O _ F A C   F   O N   F . P K   =   A . F K  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . S t a t e F a c i l i t y I D  
 	 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 	 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 	 A N D   c . I S _ D E L E T E D   =   0 ;  
  
 - -   C A F O _ G E O  
 E L S E   I F   @ L i s t I n d e x   =   3  
 	 S E L E C T 	 G . *  
 	 F R O M   d b o . C A F O _ G E O   G  
 	 J O I N   d b o . C A F O _ F A C   F   O N   F . P K   =   G . F K  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . S t a t e F a c i l i t y I D  
 	 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 	 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 	 A N D   c . I S _ D E L E T E D   =   0 ;  
  
 - -   C A F O _ R E G _ D T L S  
 E L S E   I F   @ L i s t I n d e x   =   4  
 	 S E L E C T 	 R . *  
 	 F R O M   d b o . C A F O _ R E G _ D T L S   R  
 	 J O I N   d b o . C A F O _ F A C   F   O N   F . P K   =   R . F K  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . S t a t e F a c i l i t y I D  
 	 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 	 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 	 A N D   c . I S _ D E L E T E D   =   0 ;  
  
 - -   C A F O _ P E R M I T  
 E L S E   I F   @ L i s t I n d e x   =   5  
 	 S E L E C T 	 P . *  
 	 F R O M   d b o . C A F O _ P E R M I T   P  
 	 J O I N   d b o . C A F O _ R E G _ D T L S   R   O N   R . P K   =   P . F K  
 	 J O I N   d b o . C A F O _ F A C   F   O N   F . P K   =   R . F K  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . S t a t e F a c i l i t y I D  
 	 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 	 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 	 A N D   c . I S _ D E L E T E D   =   0 ;  
  
 E N D  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ R E P O R T ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ R E P O R T ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ R E P O R T ]  
 A S  
 S E L E C T           d b o . T 2 _ F A C _ S I T E . F a c i l i t y S i t e I d e n t i f i e r ,   d b o . T 2 _ R E P O R T . R e p o r t I d e n t i f i e r ,   d b o . T 2 _ R E P O R T . R e p o r t D u e D a t e ,   d b o . T 2 _ R E P O R T . R e p o r t R e c e i v e d D a t e ,    
                                             d b o . T 2 _ R E P O R T . R e p o r t R e c i p i e n t N a m e ,   d b o . T 2 _ R E P O R T . R e p o r t i n g P e r i o d S t a r t D a t e ,   d b o . T 2 _ R E P O R T . R e p o r t i n g P e r i o d E n d D a t e ,    
                                             d b o . T 2 _ R E P O R T . R e v i s i o n I n d i c a t o r ,   d b o . T 2 _ R E P O R T . R e p l a c e d R e p o r t I d e n t i f i e r ,   d b o . T 2 _ R E P O R T . R e p o r t C r e a t e B y N a m e ,    
                                             d b o . T 2 _ R E P O R T . R e p o r t T y p e  
 F R O M                   d b o . T 2 _ R E P O R T   I N N E R   J O I N  
                                             d b o . T 2 _ F A C _ S I T E   O N   d b o . T 2 _ R E P O R T . P K _ G U I D   =   d b o . T 2 _ F A C _ S I T E . F K _ G U I D  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ F A C _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ F A C _ I N D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ F A C _ I N D ]  
 A S  
 S E L E C T            
               T 2 F . [ F a c i l i t y S i t e I d e n t i f i e r ]  
             , I N D . [ I n d i v i d u a l I d e n t i f i e r ]  
             , I N D . [ I n d i v i d u a l T i t l e T e x t ]  
             , I N D . [ N a m e P r e f i x T e x t ]  
             , I N D . [ I n d i v i d u a l F u l l N a m e ]  
             , I N D . [ F i r s t N a m e ]  
             , I N D . [ M i d d l e N a m e ]  
             , I N D . [ L a s t N a m e ]  
             , I N D . [ N a m e S u f f i x T e x t ]  
             , I N D . [ M a i l i n g A d d r e s s T e x t ]  
             , I N D . [ M a i l i n g S u p p l e m e n t a l A d d r e s s T e x t ]  
             , I N D . [ M a i l i n g A d d r e s s C i t y N a m e ]  
             , I N D . [ M a i l i n g S t a t e C o d e ]  
             , I N D . [ M a i l i n g S t a t e C o d e L i s t I d e n t i f i e r ]  
             , I N D . [ M a i l i n g S t a t e N a m e ]  
             , I N D . [ M a i l i n g A d d r e s s P o s t a l C o d e ]  
             , I N D . [ M a i l i n g C o u n t r y C o d e ]  
             , I N D . [ M a i l i n g C o u n t r y C o d e L i s t I d e n t i f i e r ]  
             , I N D . [ M a i l i n g C o u n t r y N a m e ]  
     F R O M   [ d b o ] . [ T 2 _ F A C _ I N D ]   I N D  
 J O I N   [ d b o ] . [ T 2 _ F A C _ S I T E ]   T 2 F   O N   I N D . F K _ G U I D   =   T 2 F . P K _ G U I D  
                                              
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ F A C _ N P D E S _ I D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ F A C _ N P D E S _ I D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ F A C _ N P D E S _ I D ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ F A C _ N P D E S _ I D . N P D E S I d e n t i f i c a t i o n N u m b e r  
 F R O M   d b o . T 2 _ F A C _ N P D E S _ I D   I N N E R   J O I N   d b o . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ N P D E S _ I D . F K _ G U I D   =   T 2 _ F A C _ S I T E . P K _ G U I D ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ F A C _ U I C _ I D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ F A C _ U I C _ I D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ F A C _ U I C _ I D ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ F A C _ U I C _ I D . U I C I d e n t i f i c a t i o n N u m b e r  
 F R O M   d b o . T 2 _ F A C _ U I C _ I D   I N N E R   J O I N   d b o . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ U I C _ I D . F K _ G U I D   =   T 2 _ F A C _ S I T E . P K _ G U I D ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ F A C _ S I C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ F A C _ S I C ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ F A C _ S I C ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ F A C _ S I C . S I C C o d e  
 ,   T 2 _ F A C _ S I C . S I C P r i m a r y I n d i c a t o r  
 F R O M   d b o . T 2 _ F A C _ S I C   I N N E R   J O I N   d b o . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ S I C . F K _ G U I D   =   T 2 _ F A C _ S I T E . P K _ G U I D ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ F A C _ D U N D B _ I D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ F A C _ D U N D B _ I D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ F A C _ D U N D B _ I D ]   A S    
 S E L E C T    
  
 	 T 2 F . F a c i l i t y S i t e I d e n t i f i e r  
 , 	 T 2 D U N D B . F a c i l i t y D u n B r a d s t r e e t C o d e  
 F R O M   d b o . T 2 _ F A C _ D U N D B _ I D   T 2 D U N D B  
 I N N E R   J O I N   d b o . T 2 _ F A C _ S I T E   T 2 F   O N   T 2 D U N D B . F K _ G U I D   =   T 2 F . P K _ G U I D '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ C H E M _ I N V _ D T L S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 9   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ C H E M _ I N V _ D T L S ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ C H E M _ I N V _ D T L S ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ C H E M _ I N V _ D T L S . N u m b e r O f D a y s O n s i t e  
 ,   T 2 _ C H E M _ I N V _ D T L S . M a x i m u m D a i l y A m o u n t  
 ,   T 2 _ C H E M _ I N V _ D T L S . M a x i m u m C o d e  
 ,   T 2 _ C H E M _ I N V _ D T L S . A v e r a g e D a i l y A m o u n t  
 ,   T 2 _ C H E M _ I N V _ D T L S . A v e r a g e C o d e  
 F R O M   d b o . T 2 _ C H E M _ I N V _ D T L S   I N N E R   J O I N   d b o . T 2 _ C H E M _ I N V   O N   ( T 2 _ C H E M _ I N V _ D T L S . F K _ G U I D   =   T 2 _ C H E M _ I N V . P K _ G U I D )   I N N E R   J O I N   d b o . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ S I T E . P K _ G U I D   =   T 2 _ C H E M _ I N V . F K _ G U I D )  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ C H E M _ I N V _ P H Y S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ C H E M _ I N V _ P H Y S ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ C H E M _ I N V _ P H Y S ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ C H E M _ I N V _ P H Y S . C h e m i c a l P h y s i c a l S t a t e  
 F R O M   d b o . T 2 _ C H E M _ I N V _ P H Y S   I N N E R   J O I N   d b o . T 2 _ C H E M _ I N V   O N   ( T 2 _ C H E M _ I N V _ P H Y S . F K _ G U I D   =   T 2 _ C H E M _ I N V . P K _ G U I D )   I N N E R   J O I N   d b o . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ S I T E . P K _ G U I D   =   T 2 _ C H E M _ I N V . F K _ G U I D )  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ C H E M _ I N V _ H L T H ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ C H E M _ I N V _ H L T H ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ C H E M _ I N V _ H L T H ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ C H E M _ I N V _ H L T H . H e a l t h E f f e c t s  
 F R O M   d b o . T 2 _ C H E M _ I N V _ H L T H   I N N E R   J O I N   d b o . T 2 _ C H E M _ I N V   O N   ( T 2 _ C H E M _ I N V _ H L T H . F K _ G U I D   =   T 2 _ C H E M _ I N V . P K _ G U I D )   I N N E R   J O I N   d b o . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ S I T E . P K _ G U I D   =   T 2 _ C H E M _ I N V . F K _ G U I D )  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ C H E M _ I N V _ H A Z ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 9   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ C H E M _ I N V _ H A Z ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ C H E M _ I N V _ H A Z ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ C H E M _ I N V _ H A Z . H a z a r d T y p e  
 F R O M   d b o . T 2 _ C H E M _ I N V _ H A Z   I N N E R   J O I N   d b o . T 2 _ C H E M _ I N V   O N   ( T 2 _ C H E M _ I N V _ H A Z . F K _ G U I D   =   T 2 _ C H E M _ I N V . P K _ G U I D )   I N N E R   J O I N   d b o . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ S I T E . P K _ G U I D   =   T 2 _ C H E M _ I N V . F K _ G U I D )  
 '  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ F R S _ G e t F R S B y C h a n g e D a t e ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ G e t F R S B y C h a n g e D a t e ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 M a r k   C h m a r n y  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 7 - 0 9  
 - -   D e s c r i p t i o n : 	 F R S   F l o w   d a t a   r e t r i e v a l    
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ F R S _ G e t F R S B y C h a n g e D a t e ]  
 	 @ C h a n g e D a t e   d a t e t i m e  
 A S  
 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 S E T   N O C O U N T   O N ;  
  
  
 D E C L A R E   @ f l o w T y p e   v a r c h a r ( 5 0 )  
 S E T   @ f l o w T y p e   =   ' ' H E R E - F R S ' ' ;  
  
  
 - - F R S _ F A C  
 S E L E C T 	 f . *  
 F R O M   d b o . F R S _ F A C   f  
 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   o n   c . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 A N D   c . I S _ D E L E T E D   =   0 ;  
  
  
 - - F R S _ F A C _ I N D  
 S E L E C T 	 f . *  
 F R O M   d b o . F R S _ F A C _ I N D   f  
 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   o n   c . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 A N D   c . I S _ D E L E T E D   =   0 ;  
  
  
 - - F R S _ F A C _ N A I C S  
 S E L E C T 	 f . *  
 F R O M   d b o . F R S _ F A C _ N A I C S   f  
 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   o n   c . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 A N D   c . I S _ D E L E T E D   =   0 ;  
  
  
 - - F R S _ F A C _ O R G  
 S E L E C T 	 f . *  
 F R O M   d b o . F R S _ F A C _ O R G   f  
 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   o n   c . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 A N D   c . I S _ D E L E T E D   =   0 ;  
  
  
 - - F R S _ F A C _ S I C  
 S E L E C T 	 f . *  
 F R O M   d b o . F R S _ F A C _ S I C   f  
 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   o n   c . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 A N D   c . I S _ D E L E T E D   =   0 ;  
  
  
 - - F R S _ A D D  
 S E L E C T 	 f . *  
 F R O M   d b o . F R S _ A D D   f  
 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   o n   c . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 A N D   c . I S _ D E L E T E D   =   0 ;  
  
  
 - - F R S _ A L T _ N M  
 S E L E C T 	 f . *  
 F R O M   d b o . F R S _ A L T _ N M   f  
 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   o n   c . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 A N D   c . I S _ D E L E T E D   =   0 ;  
  
  
 - - F R S _ G E O  
 S E L E C T 	 f . *  
 F R O M   d b o . F R S _ G E O   f  
 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   o n   c . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 A N D   c . I S _ D E L E T E D   =   0 ;  
  
  
  
 - - F R S _ E I  
 S E L E C T 	 f . *  
 F R O M   d b o . F R S _ E I   f  
 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   o n   c . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 A N D   c . I S _ D E L E T E D   =   0 ;  
  
  
 - - F R S _ E I _ I N D  
 S E L E C T 	 f . *  
 F R O M   d b o . F R S _ E I _ I N D   f  
 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   o n   c . S T _ F A C _ I N D   =   f . S T _ E I _ I N D  
 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 A N D   c . I S _ D E L E T E D   =   0 ;  
  
  
 - - F R S _ E I _ N A I C S  
 S E L E C T 	 f . *  
 F R O M   d b o . F R S _ E I _ N A I C S   f  
 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   o n   c . S T _ F A C _ I N D   =   f . S T _ E I _ I N D  
 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 A N D   c . I S _ D E L E T E D   =   0 ;  
  
  
 - - F R S _ E I _ O R G  
 S E L E C T 	 f . *  
 F R O M   d b o . F R S _ E I _ O R G   f  
 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   o n   c . S T _ F A C _ I N D   =   f . S T _ E I _ I N D  
 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 A N D   c . I S _ D E L E T E D   =   0 ;  
  
  
 - - F R S _ E I _ S I C  
 S E L E C T 	 f . *  
 F R O M   d b o . F R S _ E I _ S I C   f  
 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   o n   c . S T _ F A C _ I N D   =   f . S T _ E I _ I N D  
 W H E R E   c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 A N D   c . I S _ D E L E T E D   =   0 ;  
  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ F R S _ G e t F R S B y N a m e ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ G e t F R S B y N a m e ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 M a r k   C h m a r n y  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 7 - 0 9  
 - -   D e s c r i p t i o n : 	 F R S   F l o w   d a t a   r e t r i e v a l    
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ F R S _ G e t F R S B y N a m e ]  
 	 @ n a m e   v a r c h a r ( 5 0 )  
 A S  
 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 S E T   N O C O U N T   O N ;  
  
  
 - - F R S _ F A C  
 S E L E C T 	 n . *  
 F R O M   F R S _ F A C   n  
 W H E R E   n . F A C _ S I T E N M   l i k e   @ n a m e ;  
  
  
 - - F R S _ F A C _ I N D  
 S E L E C T 	 f . *  
 F R O M   F R S _ F A C _ I N D   f  
 J O I N   F R S _ F A C   n   O N   f . S T _ F A C _ I N D   =   n . S T _ F A C _ I N D  
 W H E R E   n . F A C _ S I T E N M   l i k e   @ n a m e ;  
  
  
 - - F R S _ F A C _ N A I C S  
 S E L E C T 	 f . *  
 F R O M   F R S _ F A C _ N A I C S   f  
 J O I N   F R S _ F A C   n   O N   f . S T _ F A C _ I N D   =   n . S T _ F A C _ I N D  
 W H E R E   n . F A C _ S I T E N M   l i k e   @ n a m e ;  
  
  
 - - F R S _ F A C _ O R G  
 S E L E C T 	 f . *  
 F R O M   F R S _ F A C _ O R G   f  
 J O I N   F R S _ F A C   n   O N   f . S T _ F A C _ I N D   =   n . S T _ F A C _ I N D  
 W H E R E   n . F A C _ S I T E N M   l i k e   @ n a m e ;  
  
  
 - - F R S _ F A C _ S I C  
 S E L E C T 	 f . *  
 F R O M   F R S _ F A C _ S I C   f  
 J O I N   F R S _ F A C   n   O N   f . S T _ F A C _ I N D   =   n . S T _ F A C _ I N D  
 W H E R E   n . F A C _ S I T E N M   l i k e   @ n a m e ;  
  
  
 - - F R S _ A D D  
 S E L E C T 	 f . *  
 F R O M   F R S _ A D D   f  
 J O I N   F R S _ F A C   n   O N   f . S T _ F A C _ I N D   =   n . S T _ F A C _ I N D  
 W H E R E   n . F A C _ S I T E N M   l i k e   @ n a m e ;  
  
  
 - - F R S _ A L T _ N M  
 S E L E C T 	 f . *  
 F R O M   F R S _ A L T _ N M   f  
 J O I N   F R S _ F A C   n   O N   f . S T _ F A C _ I N D   =   n . S T _ F A C _ I N D  
 W H E R E   n . F A C _ S I T E N M   l i k e   @ n a m e ;  
  
  
 - - F R S _ G E O  
 S E L E C T 	 f . *  
 F R O M   F R S _ G E O   f  
 J O I N   F R S _ F A C   n   O N   f . S T _ F A C _ I N D   =   n . S T _ F A C _ I N D  
 W H E R E   n . F A C _ S I T E N M   l i k e   @ n a m e ;  
  
  
  
 - - F R S _ E I  
 S E L E C T 	 f . *  
 F R O M   F R S _ E I   f  
 J O I N   F R S _ F A C   n   O N   f . S T _ F A C _ I N D   =   n . S T _ F A C _ I N D  
 W H E R E   n . F A C _ S I T E N M   l i k e   @ n a m e ;  
  
  
 - - F R S _ E I _ I N D  
 S E L E C T 	 E I _ I N D . *  
 F R O M   F R S _ E I _ I N D   E I _ I N D  
 J O I N   F R S _ E I   E I   O N   E I _ I N D . S T _ E I _ I N D   =   E I . S T _ E I _ I N D  
 J O I N   F R S _ F A C   n   O N   E I . S T _ E I _ I N D   =   n . S T _ F A C _ I N D  
 W H E R E   n . F A C _ S I T E N M   l i k e   @ n a m e ;  
  
  
 - - F R S _ E I _ N A I C S  
 S E L E C T 	 E I _ N A I C S . *  
 F R O M   F R S _ E I _ N A I C S   E I _ N A I C S  
 J O I N   F R S _ E I   E I   O N   E I _ N A I C S . S T _ E I _ I N D   =   E I . S T _ E I _ I N D  
 J O I N   F R S _ F A C   n   O N   E I . S T _ E I _ I N D   =   n . S T _ F A C _ I N D  
 W H E R E   n . F A C _ S I T E N M   l i k e   @ n a m e ;  
  
  
 - - F R S _ E I _ O R G  
 S E L E C T 	 E I _ O R G . *  
 F R O M   F R S _ E I _ O R G   E I _ O R G  
 J O I N   F R S _ E I   E I   O N   E I _ O R G . S T _ E I _ I N D   =   E I . S T _ E I _ I N D  
 J O I N   F R S _ F A C   n   O N   E I . S T _ E I _ I N D   =   n . S T _ F A C _ I N D  
 W H E R E   n . F A C _ S I T E N M   l i k e   @ n a m e ;  
  
  
 - - F R S _ E I _ S I C  
 S E L E C T 	 E I _ S I C . *  
 F R O M   F R S _ E I _ S I C   E I _ S I C  
 J O I N   F R S _ E I   E I   O N   E I _ S I C . S T _ E I _ I N D   =   E I . S T _ E I _ I N D  
 J O I N   F R S _ F A C   n   O N   E I . S T _ E I _ I N D   =   n . S T _ F A C _ I N D  
 W H E R E   n . F A C _ S I T E N M   l i k e   @ n a m e ;  
  
  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ F R S _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ F R S _ F A C ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ F R S _ F A C ]   A S  
 s e l e c t   S T _ F A C _ I N D  
 	 ,   F A C _ R E G _ I N D  
 	 ,   F A C _ S I T E N M  
 	 ,   F A C _ S I T E T Y P E _ N M  
 	 ,   F E D _ F A C  
 	 ,   T R I B _ L A N D  
 	 ,   T R I B _ L A N D _ N M  
 	 ,   C O N G _ D I S T _ N U M  
 	 ,   L E G _ D I S T _ N U M  
 	 ,   H U C _ C D  
 	 ,   L O C _ A D D  
 	 ,   S U P P L E M _ L O C  
 	 ,   L O C A L _ N M  
 	 ,   C N T Y _ S T _ F I P S _ C D  
 	 ,   C N T Y _ N M  
 	 ,   S T _ C D  
 	 ,   S T _ N M  
 	 ,   C O _ N M  
 	 ,   L O C _ Z I P _ C D  
 	 ,   L O C _ D E S C  
 	 ,   D A T A _ S R C _ N M  
 	 - - ,   R E P O R T E D _ D A T E   ( R e m o v e d :     C a u s e s   a l l   f a c i l i t i e s   t o   b e   s e n t   i n   H E R E   c h a n g e   p r o c e s s i n g )  
 	 ,   S T _ F A C _ S Y S _ A C  
     f r o m   d b o . F R S _ F A C   '  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ N E _ F R S _ L O A D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ N E _ F R S _ L O A D ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 K e v i n   J a m e s   ( W i n d s o r   S o l u t i o n s ,   I n c . )  
 - -   C r e a t e   d a t e :   J u n e   1 3 ,   2 0 0 7  
 - -   D e s c r i p t i o n : 	 T h i s   p r o c e d u r e   w i l l   l o a d   f a c i l i t y   d a t a   a n d   r e l a t e d  
 - -                             d a t a   e l e m e n t s   i n t o   t h e   H E R E   s t a g i n g   d a t a b a s e .  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ N E _ F R S _ L O A D ]   @ v a l u e   I N T   O U T P U T  
  
 A S  
 B E G I N  
  
         D E C L A R E   @ E R R O R _ C O D E   I N T  
  
 	 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 	 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 	 S E T   N O C O U N T   O N ;  
  
         - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
         - -   D E L E T E   F A C I L I T I E S :     A s s o c i a t e d   r e c o r d s   t o   f a c i l i t y   a r e   c a s c a d e   d e l e t e d     - -  
         - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 D E L E T E   F R O M   F R S _ F A C  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 / *    
 S T E P   1 :   L o a d   d a t a   f r o m   I I S D B  
 * /  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   F R S _ F A C  
 S E L E C T  
  
 	 C A S E   W H E N   L E N ( S T _ F A C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ F A C _ I N D   E N D   A S   S T _ F A C _ I N D  
 , 	 C A S E   W H E N   L E N ( F A C _ R E G _ I N D )   =   0   T H E N   N U L L   E L S E   F A C _ R E G _ I N D   E N D   A S   F A C _ R E G _ I N D  
 , 	 C A S E   W H E N   L E N ( F A C _ S I T E N M )   =   0   T H E N   N U L L   E L S E   F A C _ S I T E N M   E N D   A S   F A C _ S I T E N M  
 , 	 C A S E   W H E N   L E N ( F A C _ S I T E T Y P E _ N M )   =   0   T H E N   N U L L   E L S E   F A C _ S I T E T Y P E _ N M   E N D   A S   F A C _ S I T E T Y P E _ N M  
 , 	 C A S E   W H E N   L E N ( F E D _ F A C )   =   0   T H E N   N U L L   E L S E   F E D _ F A C   E N D   A S   F E D _ F A C  
 , 	 C A S E   W H E N   L E N ( T R I B _ L A N D )   =   0   T H E N   N U L L   E L S E   T R I B _ L A N D   E N D   A S   T R I B _ L A N D  
 , 	 C A S E   W H E N   L E N ( T R I B _ L A N D _ N M )   =   0   T H E N   N U L L   E L S E   T R I B _ L A N D _ N M   E N D   A S   T R I B _ L A N D _ N M  
 , 	 C A S E   W H E N   L E N ( C O N G _ D I S T _ N U M )   =   0   T H E N   N U L L   E L S E   C O N G _ D I S T _ N U M   E N D   A S   C O N G _ D I S T _ N U M  
 , 	 C A S E   W H E N   L E N ( L E G _ D I S T _ N U M )   =   0   T H E N   N U L L   E L S E   L E G _ D I S T _ N U M   E N D   A S   L E G _ D I S T _ N U M  
 , 	 C A S E   W H E N   L E N ( H U C _ C D )   =   0   T H E N   N U L L   E L S E   H U C _ C D   E N D   A S   H U C _ C D  
 , 	 C A S E   W H E N   L E N ( L O C _ A D D )   =   0   T H E N   N U L L   E L S E   L O C _ A D D   E N D   A S   L O C _ A D D  
 , 	 C A S E   W H E N   L E N ( S U P P L E M _ L O C )   =   0   T H E N   N U L L   E L S E   S U P P L E M _ L O C   E N D   A S   S U P P L E M _ L O C  
 , 	 C A S E   W H E N   L E N ( L O C A L _ N M )   =   0   T H E N   N U L L   E L S E   L O C A L _ N M   E N D   A S   L O C A L _ N M  
 , 	 C A S E   W H E N   L E N ( C N T Y _ S T _ F I P S _ C D )   =   0   T H E N   N U L L   E L S E   C N T Y _ S T _ F I P S _ C D   E N D   A S   C N T Y _ S T _ F I P S _ C D  
 , 	 C A S E   W H E N   L E N ( C N T Y _ N M )   =   0   T H E N   N U L L   E L S E   C N T Y _ N M   E N D   A S   C N T Y _ N M  
 , 	 C A S E   W H E N   L E N ( S T _ C D )   =   0   T H E N   N U L L   E L S E   S T _ C D   E N D   A S   S T _ C D  
 , 	 C A S E   W H E N   L E N ( S T _ N M )   =   0   T H E N   N U L L   E L S E   S T _ N M   E N D   A S   S T _ N M  
 , 	 C A S E   W H E N   L E N ( C O _ N M )   =   0   T H E N   N U L L   E L S E   C O _ N M   E N D   A S   C O _ N M  
 , 	 C A S E   W H E N   ( L E N ( L O C _ Z I P _ C D )   =   0   O R   L O C _ Z I P _ C D   =   ' ' - ' ' )   T H E N   N U L L   E L S E   L O C _ Z I P _ C D   E N D   A S   L O C _ Z I P _ C D  
 , 	 C A S E   W H E N   L E N ( L O C _ D E S C )   =   0   T H E N   N U L L   E L S E   L O C _ D E S C   E N D   A S   L O C _ D E S C  
 , 	 C A S E   W H E N   L E N ( D A T A _ S R C _ N M )   =   0   T H E N   N U L L   E L S E   D A T A _ S R C _ N M   E N D   A S   D A T A _ S R C _ N M  
 , 	 C A S E   W H E N   L E N ( R E P O R T E D _ D A T E )   =   0   T H E N   N U L L   E L S E   R E P O R T E D _ D A T E   E N D   A S   R E P O R T E D _ D A T E  
 , 	 C A S E   W H E N   L E N ( S T _ F A C _ S Y S _ A C )   =   0   T H E N   N U L L   E L S E   S T _ F A C _ S Y S _ A C   E N D   A S   S T _ F A C _ S Y S _ A C  
  
 F R O M  
 	 (  
 	 S E L E C T   D I S T I N C T   N E _ F a c i l i t y . F A C I D   A S   S T _ F A C _ I N D  
   	 	   ,   N U L L   A S   F A C _ R E G _ I N D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y . F A C N A M ) )   A S   F A C _ S I T E N M  
 	 	   ,   N U L L   A S   F A C _ S I T E T Y P E _ N M  
 	 	   ,   N U L L   A S   F E D _ F A C  
 	 	   ,   N U L L   A S   T R I B _ L A N D  
 	 	   ,   N U L L   A S   T R I B _ L A N D _ N M  
 - - 	 T K C 	 7 / 9 	 a d d   a   l e a d i n g   z e r o   t o   t h e   c o n g r e s s i o n a l   a n d   l e g i s l a t i v e   d i s t r i c t   c o d e s   i f  
 - - 	 	 	 l e n g t h   i s   l e s s   t h a n   2  
 	 	   ,   d b o . u d f s _ P a d L e a d i n g Z e r o e s ( N E _ F a c i l i t y . C D I S T ,   2 )   A S   C O N G _ D I S T _ N U M  
 	 	   ,   d b o . u d f s _ P a d L e a d i n g Z e r o e s ( N E _ F a c i l i t y . L D I S T ,   2 )   A S   L E G _ D I S T _ N U M  
 	 	   ,   N U L L   A S   H U C _ C D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y . S T R E E T ) )   A S   L O C _ A D D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y . O P T A D R ) )   A S   S U P P L E M _ L O C  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y . C I T Y ) )   A S   L O C A L _ N M  
 	 	   ,   d b o . u d f s _ P a d L e a d i n g Z e r o e s ( N E _ F a c i l i t y . C N Y F I P ,   5 )   A S   C N T Y _ S T _ F I P S _ C D  
 	 	   ,   C A S E   W H E N   I S N U L L ( N E _ F a c i l i t y . C O U N T Y ,   ' ' ' ' )   =   ' ' ' '   T H E N   N U L L   E L S E   L T R I M ( R T R I M ( N E _ F a c i l i t y . C O U N T Y ) )   E N D   A S   C N T Y _ N M  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y . S T A T E ) )   A S   S T _ C D  
 	 	   ,   ( S E L E C T   S T A T E _ N A M E    
 	 	     	     F R O M   L o o k u p _ U S P S _ S t a t e s    
 	 	 	   W H E R E   L o o k u p _ U S P S _ S t a t e s . S t a t e _ C o d e   =   N E _ F a c i l i t y . S T A T E )   A S   S T _ N M  
 	 	   ,   ' ' U n i t e d   S t a t e s ' '   A S   C O _ N M  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y . Z I P C O D ) )   +   C A S E   W H E N   L E N ( I S N U L L ( N E _ F a c i l i t y . Z I P P L S , ' ' ' ' ) )   >   0   T H E N   ' ' - ' '   +   L T R I M ( R T R I M ( N E _ F a c i l i t y . Z I P P L S ) )   E L S E   ' ' ' '   E N D   A S   L O C _ Z I P _ C D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y . L O C D S C ) )   A S   L O C _ D E S C  
 	 	   ,   ' ' N E - I I S ' '   A S   D A T A _ S R C _ N M  
                   ,   d b o . u d f s _ D a t e O r T i m e X M L ( N E _ F a c i l i t y _ C h a n g e D a t e . C D A T E ,   0 )   A S   R E P O R T E D _ D A T E  
 	 	   ,   ' ' N E - I I S ' '   A S   S T _ F A C _ S Y S _ A C  
 	     F R O M   N E _ F a c i l i t y   I N N E R   J O I N   N E _ F a c i l i t y _ E I  
 	 	 	 	 	 	 	 	 	 O N   (       N E _ F a c i l i t y . f a c i d   =   N E _ F a c i l i t y _ E I . f a c i d   )  
 	                                       L E F T   J O I N   N E _ F a c i l i t y _ C h a n g e D a t e  
 	 	 	 	 	 	 	 	 	 O N   (       N E _ F a c i l i t y . f a c i d   =   N E _ F a c i l i t y _ C h a n g e D a t e . f a c i d   )  
 	 	 W H E R E   N E _ F a c i l i t y _ E I . P R G A C R   I N  
 	 	 	 (  
 	 	 	 S E L E C T   P R G A C R   F R O M   L o o k u p _ P R G A C R  
 	 	 	 W H E R E   A C T I V E   =   1  
 	 	 	 )  
 	 )   A S   G 1  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ E I     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
  
 - -   T K C   9 / 2 6 / 2 0 0 7 	 C h a n g e   t h e   m a p p i n g   t o   E I   a c r o n y m   t o   b e   t h e   p r o g r a m   a c r o n y m   r a t h e r   t h a n   ' ' N E - I I S ' '  
 	 I N S E R T   I N T O   F R S _ E I  
 S E L E C T  
 	 C A S E   W H E N   L E N ( S T _ E I _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ E I _ I N D   E N D   A S   S T _ E I _ I N D  
 , 	 C A S E   W H E N   L E N ( S T _ F A C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ F A C _ I N D   E N D   A S   S T _ F A C _ I N D  
 , 	 C A S E   W H E N   L E N ( I N F _ S Y S _ A C )   =   0   T H E N   N U L L   E L S E   I N F _ S Y S _ A C   E N D   A S   I N F _ S Y S _ A C  
 , 	 C A S E   W H E N   ( L E N ( I N F _ S Y S _ I N D )   =   0   O R   I S N U L L ( I N F _ S Y S _ I N D , ' ' - ' ' )   =   ' ' - ' ' )   T H E N   N U L L   E L S E   I N F _ S Y S _ I N D   E N D   A S   I N F _ S Y S _ I N D  
 , 	 C A S E   W H E N   L E N ( E N V _ I N T _ T Y P E )   =   0   T H E N   N U L L   E L S E   E N V _ I N T _ T Y P E   E N D   A S   E N V _ I N T _ T Y P E  
 , 	 C A S E   W H E N   L E N ( F E D _ S T _ I N T )   =   0   T H E N   N U L L   E L S E   F E D _ S T _ I N T   E N D   A S   F E D _ S T _ I N T  
 , 	 C A S E   W H E N   L E N ( E N V _ I N T _ S T A R T _ D A T E )   =   0   T H E N   N U L L   E L S E   E N V _ I N T _ S T A R T _ D A T E   E N D   A S   E N V _ I N T _ S T A R T _ D A T E  
 , 	 C A S E   W H E N   L E N ( I N T _ S T A R T _ D A T E _ Q U A L )   =   0   T H E N   N U L L   E L S E   I N T _ S T A R T _ D A T E _ Q U A L   E N D   A S   I N T _ S T A R T _ D A T E _ Q U A L  
 , 	 C A S E   W H E N   L E N ( E N V _ I N T _ E N D _ D A T E )   =   0   T H E N   N U L L   E L S E   E N V _ I N T _ E N D _ D A T E   E N D   A S   E N V _ I N T _ E N D _ D A T E  
 , 	 C A S E   W H E N   L E N ( I N T _ E N D _ D A T E _ Q U A L )   =   0   T H E N   N U L L   E L S E   I N T _ E N D _ D A T E _ Q U A L   E N D   A S   I N T _ E N D _ D A T E _ Q U A L  
  
 F R O M  
 	 (  
 	 S E L E C T   D I S T I N C T  
                       n e w i d ( )           	 A S   S T _ E I _ I N D  
 	 	   ,     N E _ F a c i l i t y _ E I . F A C I D   A S   S T _ F A C _ I N D  
 - - 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ E I . P R G A C R ) )             	 A S   I N F _ S Y S _ A C  
 	 	   ,   ' ' N E - I I S ' ' 	 	 	 	 	 	 	 	 	 	 A S   I N F _ S Y S _ A C  
 	 	   ,   L T R I M ( R T R I M ( P R G I D 1 ) ) + ' ' - ' ' + L T R I M ( R T R I M ( P R G I D 2 ) ) 	 	 	 	 	 	 	 A S   I N F _ S Y S _ I N D  
 - - 	 	   ,   N U L L 	 	 	 	 	 	 	 	 	 	 	 A S   E N V _ I N T _ T Y P E  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ E I . P R G A C R ) ) 	 	 	 	 	 	 A S   E N V _ I N T _ T Y P E  
 	 	   ,   ' ' S ' ' 	 	 	 	 	 	 	 	 	 	 	 A S   F E D _ S T _ I N T  
                   ,   d b o . u d f s _ D a t e O r T i m e X M L ( N E _ F a c i l i t y _ E I . A D A T E ,   0 )   A S   E N V _ I N T _ S T A R T _ D A T E  
 	 	   ,   ' ' E I   S t a r t   D a t e ' ' 	 	 	 	 	 	 	 	 A S   I N T _ S T A R T _ D A T E _ Q U A L  
                   ,   C A S E  
 	 	 	 	 W H E N   D A T E D I F F ( D D ,   N E _ F a c i l i t y _ E I . I D A T E ,   ' ' 1 8 9 9 - 0 1 - 0 1 ' ' )   =   0   T H E N   N U L L  
 	 	 	 	 E L S E   d b o . u d f s _ D a t e O r T i m e X M L ( N E _ F a c i l i t y _ E I . I D A T E ,   0 )  
 	 	 	 E N D                                                                                   A S   E N V _ I N T _ E N D _ D A T E  
 	 	   ,   ' ' E I   E n d   D a t e ' ' 	 	 	 	 	 	 	 	 A S   I N T _ E N D _ D A T E _ Q U A L  
 	     F R O M   N E _ F a c i l i t y   I N N E R   J O I N   N E _ F a c i l i t y _ E I    
 	 	 	 	 	 	 	       O N   ( N E _ F a c i l i t y . F A C I D   =   N E _ F a c i l i t y _ E I . F A C I D )  
 	 	 	 	 	 	 	 I N N E R   J O I N   F R S _ F A C  
 	 	 	 	 	 	 	       O N   ( F R S _ F A C . S T _ F A C _ I N D   =   N E _ F a c i l i t y . f a c i d   )  
 	 	 W H E R E   N E _ F a c i l i t y _ E I . P R G A C R   I N  
 	 	 	 (  
 	 	 	 S E L E C T   P R G A C R   F R O M   L o o k u p _ P R G A C R  
 	 	 	 W H E R E   A C T I V E   =   1  
 	 	 	 )  
 	 )   A S   G 1  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ A D D     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
  
 	 I N S E R T   I N T O   F R S _ A D D  
 S E L E C T  
 	 C A S E   W H E N   L E N ( S T _ F A C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ F A C _ I N D   E N D   A S   S T _ F A C _ I N D  
 , 	 C A S E   W H E N   L E N ( A F F I L _ T Y P E )   =   0   T H E N   N U L L   E L S E   A F F I L _ T Y P E   E N D   A S   A F F I L _ T Y P E  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D   E N D   A S   M A I L _ A D D  
 , 	 C A S E   W H E N   L E N ( S U P P L E M _ A D D )   =   0   T H E N   N U L L   E L S E   S U P P L E M _ A D D   E N D   A S   S U P P L E M _ A D D  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ C I T Y _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ C I T Y _ N M   E N D   A S   M A I L _ A D D _ C I T Y _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ S T _ C D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ S T _ C D   E N D   A S   M A I L _ A D D _ S T _ C D  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ S T _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ S T _ N M   E N D   A S   M A I L _ A D D _ S T _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ C O _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ C O _ N M   E N D   A S   M A I L _ A D D _ C O _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ Z I P _ C D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ Z I P _ C D   E N D   A S   M A I L _ A D D _ Z I P _ C D  
  
 F R O M  
 	 (  
 	 S E L E C T   F A C I D   A S   S T _ F A C _ I N D  
 	 ,   N U L L   A S   A F F I L _ T Y P E  
 	 ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ M a i l i n g . M A I L ) )   A S   M A I L _ A D D  
 	 ,   C A S E   W H E N   N E _ F a c i l i t y _ M a i l i n g . S U I T E   < >   ' ' ' '  
 	 	 T H E N   ' ' S u i t e :   ' '   +   L T R I M ( R T R I M ( S U I T E ) )  
 	     E N D   A S   S U P P L E M _ A D D  
 	 ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ M a i l i n g . C I T Y ) )   A S   M A I L _ A D D _ C I T Y _ N M  
 	 ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ M a i l i n g . S T A T E ) )   A S   M A I L _ A D D _ S T _ C D  
 	 ,   ( S E L E C T   S T A T E _ N A M E    
                   F R O M   L o o k u p _ U S P S _ S t a t e s    
                 W H E R E   L o o k u p _ U S P S _ S t a t e s . S t a t e _ C o d e   =   N E _ F a c i l i t y _ M a i l i n g . S T A T E )   A S   M A I L _ A D D _ S T _ N M  
 	 ,   ' ' U n i t e d   S t a t e s ' '   A S   M A I L _ A D D _ C O _ N M  
 	 ,   C A S E   W H E N   N E _ F a c i l i t y _ M a i l i n g . Z I P P L S   =   ' ' ' '  
 	 	 T H E N   L T R I M ( R T R I M ( N E _ F a c i l i t y _ M a i l i n g . Z I P C O D ) )  
 	 	 E L S E   L T R I M ( R T R I M ( N E _ F a c i l i t y _ M a i l i n g . Z I P C O D ) ) + ' ' - ' '   + L T R I M ( R T R I M ( N E _ F a c i l i t y _ M a i l i n g . Z I P P L S ) )  
 	     E N D   A S   M A I L _ A D D _ Z I P _ C D  
 	 f r o m   N E _ F a c i l i t y _ M a i l i n g   I N N E R   J O I N   F R S _ F A C  
 	 	 	 	 	 	 	 	 O N   ( F R S _ F A C . S T _ F A C _ I N D   =   N E _ F a c i l i t y _ M a i l i n g . f a c i d   )  
         )   G 1  
  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
 	  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ A L T _ N M     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   F R S _ A L T _ N M  
  
 S E L E C T  
 	 C A S E   W H E N   L E N ( S T _ F A C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ F A C _ I N D   E N D   A S   S T _ F A C _ I N D  
 , 	 C A S E   W H E N   L E N ( A L T _ N M )   =   0   T H E N   N U L L   E L S E   A L T _ N M   E N D   A S   A L T _ N M  
 , 	 C A S E   W H E N   L E N ( A L T _ N A M E _ T Y P E )   =   0   T H E N   N U L L   E L S E   A L T _ N A M E _ T Y P E   E N D   A S   A L T _ N A M E _ T Y P E  
  
 F R O M  
 	 (  
 	 S E L E C T   D I S T I N C T   F A C I D   A S   S T _ F A C _ I N D  
 	 	   ,   L T R I M ( R T R I M ( M A X ( F A C N A M ) ) )   A S   A L T _ N M  
 	 	   ,   L T R I M ( R T R I M ( A L T _ N A M E _ T Y P E ) )   A S   A L T _ N A M E _ T Y P E  
 	     F R O M   ( S E L E C T 	 A L T . F A C I D   A S   F A C I D  
 	   	                   ,   S U B S T R I N G ( A L T . F A C N A M , 1 , 8 0 )   A S   F A C N A M  
 	 	 	 	   ,   N U L L   A S   A L T _ N A M E _ T Y P E   - -   < A L T _ N A M E _ T Y P E ,   v a r c h a r ( 2 5 ) , > )    
 	 	 	 	   ,   F A C . *  
 	 	 	     F R O M   d b o . F R S _ F A C   F A C   I N N E R   J O I N   d b o . N E _ F a c i l i t y _ A l t N a m e   A L T  
 	 	 	 	 	 	 	 	 	     O N   (         F A C . S T _ F A C _ I N D   =   A L T . F A C I D   ) )   G 1  
 G R O U P   B Y   F A C I D  
 / *  
   	 	 	 	 	 	 	 	 	 	     A N D   A L T . F A C N A M   =   ( S E L E C T   T O P   1   A 2 . F A C N A M  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	     F R O M   d b o . N E _ F a c i l i t y _ A l t N a m e   A 2  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	   W H E R E   A 2 . F A C I D   =   A L T . F A C I D  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	   O R D E R   B Y   A 2 . C D A T E   D E S C ) )   G 1  
 * /  
 	 )   G 1  
 W H E R E   L E N ( I S N U L L ( G 1 . A L T _ N M , ' ' ' ' ) )   >   0  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ G E O     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   F R S _ G E O  
  
 S E L E C T  
 	 C A S E   W H E N   L E N ( S T _ F A C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ F A C _ I N D   E N D   A S   S T _ F A C _ I N D  
 , 	 C A S E   W H E N   L E N ( L A T _ M E A S U R E )   =   0   T H E N   N U L L   E L S E   L A T _ M E A S U R E   E N D   A S   L A T _ M E A S U R E  
 , 	 C A S E   W H E N   L E N ( L O N _ M E A S U R E )   =   0   T H E N   N U L L   E L S E   L O N _ M E A S U R E   E N D   A S   L O N _ M E A S U R E  
 , 	 C A S E   W H E N   L E N ( H O R I Z _ A C C U R _ M E A S U R E )   =   0   T H E N   N U L L   E L S E   H O R I Z _ A C C U R _ M E A S U R E   E N D   A S   H O R I Z _ A C C U R _ M E A S U R E  
 , 	 C A S E   W H E N   L E N ( H O R I Z _ C O L L _ M E T H )   =   0   T H E N   N U L L   E L S E   H O R I Z _ C O L L _ M E T H   E N D   A S   H O R I Z _ C O L L _ M E T H  
 , 	 C A S E   W H E N   L E N ( H O R I Z _ R E F _ D A T U M _ N M )   =   0   T H E N   N U L L   E L S E   H O R I Z _ R E F _ D A T U M _ N M   E N D   A S   H O R I Z _ R E F _ D A T U M _ N M  
 , 	 C A S E   W H E N   L E N ( S R C _ M A P _ S C A L E _ N U M )   =   0   T H E N   N U L L   E L S E   S R C _ M A P _ S C A L E _ N U M   E N D   A S   S R C _ M A P _ S C A L E _ N U M  
 , 	 C A S E   W H E N   L E N ( R E F _ P O I N T )   =   0   T H E N   N U L L   E L S E   R E F _ P O I N T   E N D   A S   R E F _ P O I N T  
 , 	 C A S E   W H E N   L E N ( D A T A _ C O L L _ D A T E )   =   0   T H E N   N U L L   E L S E   D A T A _ C O L L _ D A T E   E N D   A S   D A T A _ C O L L _ D A T E  
 , 	 C A S E   W H E N   L E N ( G E O _ T Y P E _ N M )   =   0   T H E N   N U L L   E L S E   G E O _ T Y P E _ N M   E N D   A S   G E O _ T Y P E _ N M  
 , 	 C A S E   W H E N   L E N ( L O C _ C O M M E N T S )   =   0   T H E N   N U L L   E L S E   L O C _ C O M M E N T S   E N D   A S   L O C _ C O M M E N T S  
 , 	 C A S E   W H E N   L E N ( V E R T _ C O L L _ M E T H )   =   0   T H E N   N U L L   E L S E   V E R T _ C O L L _ M E T H   E N D   A S   V E R T _ C O L L _ M E T H  
 , 	 C A S E   W H E N   L E N ( V E R T _ M E A S U R E )   =   0   T H E N   N U L L   E L S E   V E R T _ M E A S U R E   E N D   A S   V E R T _ M E A S U R E  
 , 	 C A S E   W H E N   L E N ( V E R T _ A C C U R _ M E A S U R E )   =   0   T H E N   N U L L   E L S E   V E R T _ A C C U R _ M E A S U R E   E N D   A S   V E R T _ A C C U R _ M E A S U R E  
 , 	 C A S E   W H E N   L E N ( V E R T _ R E F _ D A T U M _ N M )   =   0   T H E N   N U L L   E L S E   V E R T _ R E F _ D A T U M _ N M   E N D   A S   V E R T _ R E F _ D A T U M _ N M  
 , 	 C A S E   W H E N   L E N ( D A T A _ S R C _ N M )   =   0   T H E N   N U L L   E L S E   D A T A _ S R C _ N M   E N D   A S   D A T A _ S R C _ N M  
 , 	 C A S E   W H E N   L E N ( C O O R D _ D A T A _ S R C _ N M )   =   0   T H E N   N U L L   E L S E   C O O R D _ D A T A _ S R C _ N M   E N D   A S   C O O R D _ D A T A _ S R C _ N M  
 , 	 C A S E   W H E N   L E N ( S U B _ E N T _ I N D )   =   0   T H E N   N U L L   E L S E   S U B _ E N T _ I N D   E N D   A S   S U B _ E N T _ I N D  
 , 	 C A S E   W H E N   L E N ( S U B _ E N T _ T Y P E _ N M )   =   0   T H E N   N U L L   E L S E   S U B _ E N T _ T Y P E _ N M   E N D   A S   S U B _ E N T _ T Y P E _ N M  
  
 F R O M  
 	 (  
 	 S E L E C T   N E _ F a c i l i t y _ C o o r d . F A C I D   A S   S T _ F A C _ I N D  
 	 	   ,   N E _ F a c i l i t y _ C o o r d . L A T   A S   L A T _ M E A S U R E  
 	 	   ,   N E _ F a c i l i t y _ C o o r d . L O N   A S   L O N _ M E A S U R E  
 	 	   ,   N U L L   A S   H O R I Z _ A C C U R _ M E A S U R E  
 	 	   ,   C A S E   W H E N   U P P E R ( N E _ F a c i l i t y _ C o o r d . L L S R C )   l i k e   ' ' G P S % ' '    
 	 	 	   T H E N   ' ' G P S   -   U N S P E C I F I E D ' '    
 	 	 	   E L S E   C A S E   W H E N   U P P E R ( N E _ F a c i l i t y _ C o o r d . L L S R C )   =   ' ' L E G A L ' '    
 	 	 	   T H E N   ' ' U N K N O W N ' '    
 	 	 	   E L S E   C A S E   W H E N   U P P E R ( N E _ F a c i l i t y _ C o o r d . L L S R C )   l i k e   ' ' D I G % ' '    
 	 	 	   T H E N   ' ' I N T E R P O L A T I O N - O T H E R ' '    
 	 	 	   E L S E   C A S E   W H E N   U P P E R ( N E _ F a c i l i t y _ C o o r d . L L S R C )   l i k e   ' ' A D D M A T % ' '    
 	 	 	   T H E N   ' ' A D D R E S S   M A T C H I N G - O T H E R ' '    
 	 	 	   E L S E   ' ' U N K N O W N ' '    
 	 	       E N D    
 	 	       E N D    
 	 	       E N D    
 	 	       E N D   A S   H O R I Z _ C O L L _ M E T H  
 	 	   ,   C A S E   W H E N   ( I S N U L L ( N E _ F a c i l i t y _ C o o r d . H R E F D T M , ' ' ' ' )   =   ' ' ' '   O R   I S N U L L ( N E _ F a c i l i t y _ C o o r d . R D A T U M , ' ' ' ' )   =   ' ' ' ' )   T H E N   N U L L  
 	 	 	 	 E L S E   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o o r d . H R E F D T M ) )   +   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o o r d . R D A T U M ) )  
 	 	 	 E N D   A S   H O R I Z _ R E F _ D A T U M _ N M  
 	 	   ,   N U L L   A S   S R C _ M A P _ S C A L E _ N U M  
 	 	   ,   N U L L   A S   R E F _ P O I N T  
                   ,   d b o . u d f s _ D a t e O r T i m e X M L ( N E _ F a c i l i t y _ C o o r d . C D A T E ,   0 )   A S   D A T A _ C O L L _ D A T E  
 - -                   ,   R E P L A C E ( C O N V E R T ( V A R C H A R ,   N E _ F a c i l i t y _ C o o r d . C D A T E ,   1 0 1 ) , ' ' / ' ' , ' ' ' ' )   A S   D A T A _ C O L L _ D A T E  
 	 	   ,   N U L L   A S   G E O _ T Y P E _ N M  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o o r d . L L D E S C ) )   A S   L O C _ C O M M E N T S  
 	 	   ,   N U L L   A S   V E R T _ C O L L _ M E T H  
 	 	   ,   N U L L   A S   V E R T _ M E A S U R E  
 	 	   ,   N U L L   A S   V E R T _ A C C U R _ M E A S U R E  
 	 	   ,   N U L L   A S   V E R T _ R E F _ D A T U M _ N M  
 	 	   ,   N U L L   A S   D A T A _ S R C _ N M  
 	 	   ,   N U L L   A S   C O O R D _ D A T A _ S R C _ N M  
 	 	   ,   N U L L   A S   S U B _ E N T _ I N D  
 	 	   ,   N U L L   A S   S U B _ E N T _ T Y P E _ N M  
 	     F R O M   N E _ F a c i l i t y _ C o o r d   I N N E R   J O I N   F R S _ F A C  
 	 	 	 	 	 	 	 	 O N   ( F R S _ F A C . S T _ F A C _ I N D   =   N E _ F a c i l i t y _ C o o r d . F A C I D   )  
 	 )   A S   G 1  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C _ I N D     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 - -   T K C   9 / 2 6 / 2 0 0 7 	 O n l y   a d d   c o n t a c t s   a t   t h i s   l e v e l   w h e r e   P R G A C R   =   ' ' D E Q ' '  
 	 I N S E R T   I N T O   F R S _ F A C _ I N D  
  
 S E L E C T  
  
 	 C A S E   W H E N   L E N ( S T _ R E C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ R E C _ I N D   E N D   A S   S T _ R E C _ I N D  
 , 	 C A S E   W H E N   L E N ( S T _ F A C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ F A C _ I N D   E N D   A S   S T _ F A C _ I N D  
 , 	 C A S E   W H E N   L E N ( A F F I L _ T Y P E )   =   0   T H E N   N U L L   E L S E   A F F I L _ T Y P E   E N D   A S   A F F I L _ T Y P E  
 , 	 C A S E   W H E N   L E N ( A F F I L _ S T A R T _ D A T E )   =   0   T H E N   N U L L   E L S E   A F F I L _ S T A R T _ D A T E   E N D   A S   A F F I L _ S T A R T _ D A T E  
 , 	 C A S E   W H E N   L E N ( A F F I L _ E N D _ D A T E )   =   0   T H E N   N U L L   E L S E   A F F I L _ E N D _ D A T E   E N D   A S   A F F I L _ E N D _ D A T E  
 , 	 C A S E   W H E N   L E N ( E M A I L _ A D D )   =   0   T H E N   N U L L   E L S E   E M A I L _ A D D   E N D   A S   E M A I L _ A D D  
 , 	 C A S E   W H E N   L E N ( T E L _ N U M )   =   0   T H E N   N U L L   E L S E   T E L _ N U M   E N D   A S   T E L _ N U M  
 , 	 C A S E   W H E N   L E N ( P H _ E X T )   =   0   T H E N   N U L L   E L S E   P H _ E X T   E N D   A S   P H _ E X T  
 , 	 C A S E   W H E N   L E N ( F A X _ N U M )   =   0   T H E N   N U L L   E L S E   F A X _ N U M   E N D   A S   F A X _ N U M  
 , 	 C A S E   W H E N   L E N ( A L T _ T E L _ N U M )   =   0   T H E N   N U L L   E L S E   A L T _ T E L _ N U M   E N D   A S   A L T _ T E L _ N U M  
 , 	 C A S E   W H E N   L E N ( I N D _ F U L L _ N M )   =   0   T H E N   N U L L   E L S E   I N D _ F U L L _ N M   E N D   A S   I N D _ F U L L _ N M  
 , 	 C A S E   W H E N   L E N ( I N D _ T I T L E )   =   0   T H E N   N U L L   E L S E   I N D _ T I T L E   E N D   A S   I N D _ T I T L E  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D   E N D   A S   M A I L _ A D D  
 , 	 C A S E   W H E N   L E N ( S U P P L E M _ A D D )   =   0   T H E N   N U L L   E L S E   S U P P L E M _ A D D   E N D   A S   S U P P L E M _ A D D  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ C I T Y _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ C I T Y _ N M   E N D   A S   M A I L _ A D D _ C I T Y _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ S T _ C D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ S T _ C D   E N D   A S   M A I L _ A D D _ S T _ C D  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ S T _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ S T _ N M   E N D   A S   M A I L _ A D D _ S T _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ C O _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ C O _ N M   E N D   A S   M A I L _ A D D _ C O _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ Z I P _ C D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ Z I P _ C D   E N D   A S   M A I L _ A D D _ Z I P _ C D  
  
 F R O M  
 	 (  
 	 S E L E C T   n e w i d ( )     A S   S T _ R E C _ I N D  
 	     	   ,   N E _ F a c i l i t y _ C o n t a c t s . F A C I D   A S   S T _ F A C _ I N D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . C T D S C ) )   A S   A F F I L _ T Y P E  
 	 	   ,   d b o . u d f s _ D a t e O r T i m e X M L ( N E _ F a c i l i t y _ C o n t a c t s . A D A T E ,   0 )   A S   A F F I L _ S T A R T _ D A T E  
 	 	   ,   d b o . u d f s _ D a t e O r T i m e X M L ( N E _ F a c i l i t y _ C o n t a c t s . I D A T E ,   0 )   A S   A F F I L _ E N D _ D A T E  
 	 	   ,   C A S E   W H E N   N E _ F a c i l i t y _ C o n t a c t s . E M A D R   < >   ' ' ' '   A N D   N E _ F a c i l i t y _ C o n t a c t s . E M D O M   < >   ' ' ' '  
 	   	 	   T H E N   N E _ F a c i l i t y _ C o n t a c t s . E M A D R + ' ' @ ' ' + N E _ F a c i l i t y _ C o n t a c t s . E M D O M    
 	 	       E N D   A S   E M A I L _ A D D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . P H O N E ) )   A S   T E L _ N U M  
 	 	   ,   N U L L   A S   P H _ E X T  
 	 	   ,   N U L L   A S   F A X _ N U M  
 	 	   ,   N U L L   A S   A L T _ T E L _ N U M  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . A D R S E E ) )   A S   I N D _ F U L L _ N M  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . P O S T T L ) )   A S   I N D _ T I T L E  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . M A I L ) )   A S   M A I L _ A D D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . O P T A D R ) )   A S   S U P P L E M _ A D D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . C I T Y ) )   A S   M A I L _ A D D _ C I T Y _ N M  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . S T A T E ) )   A S   M A I L _ A D D _ S T _ C D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . S T N A M ) )   A S   M A I L _ A D D _ S T _ N M  
 	 	   ,   ' ' U n i t e d   S t a t e s ' '   A S   M A I L _ A D D _ C O _ N M  
 	 	   ,   C A S E   W H E N   N E _ F a c i l i t y _ C o n t a c t s . Z I P P L S   =   ' ' ' '  
 	 	   	   T H E N   N E _ F a c i l i t y _ C o n t a c t s . Z I P C O D  
 	 	 	   E L S E   N E _ F a c i l i t y _ C o n t a c t s . Z I P C O D + ' ' - ' '   + N E _ F a c i l i t y _ C o n t a c t s . Z I P P L S      
 	 	       E N D   A S   M A I L _ A D D _ Z I P _ C D  
 	     F R O M   N E _ F a c i l i t y _ C o n t a c t s   I N N E R   J O I N   F R S _ F A C  
 	 	 	 	 	 	 	 	   O N   ( F R S _ F A C . S T _ F A C _ I N D   =   N E _ F a c i l i t y _ C o n t a c t s . f a c i d   )  
 	 W H E R E   N E _ F a c i l i t y _ C o n t a c t s . P R G A C R   =   ' ' D E Q ' '  
 	 )   A S   G 1  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ E I _ I N D     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
  
 I N S E R T   I N T O   F R S _ E I _ I N D  
  
 S E L E C T  
  
 	 C A S E   W H E N   L E N ( S T _ R E C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ R E C _ I N D   E N D   A S   S T _ R E C _ I N D  
 , 	 C A S E   W H E N   L E N ( S T _ E I _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ E I _ I N D   E N D   A S   S T _ E I _ I N D  
 , 	 C A S E   W H E N   L E N ( A F F I L _ T Y P E )   =   0   T H E N   N U L L   E L S E   A F F I L _ T Y P E   E N D   A S   A F F I L _ T Y P E  
 , 	 C A S E   W H E N   L E N ( A F F I L _ S T A R T _ D A T E )   =   0   T H E N   N U L L   E L S E   A F F I L _ S T A R T _ D A T E   E N D   A S   A F F I L _ S T A R T _ D A T E  
 , 	 C A S E   W H E N   L E N ( A F F I L _ E N D _ D A T E )   =   0   T H E N   N U L L   E L S E   A F F I L _ E N D _ D A T E   E N D   A S   A F F I L _ E N D _ D A T E  
 , 	 C A S E   W H E N   L E N ( E M A I L _ A D D )   =   0   T H E N   N U L L   E L S E   E M A I L _ A D D   E N D   A S   E M A I L _ A D D  
 , 	 C A S E   W H E N   L E N ( T E L _ N U M )   =   0   T H E N   N U L L   E L S E   T E L _ N U M   E N D   A S   T E L _ N U M  
 , 	 C A S E   W H E N   L E N ( P H _ E X T )   =   0   T H E N   N U L L   E L S E   P H _ E X T   E N D   A S   P H _ E X T  
 , 	 C A S E   W H E N   L E N ( F A X _ N U M )   =   0   T H E N   N U L L   E L S E   F A X _ N U M   E N D   A S   F A X _ N U M  
 , 	 C A S E   W H E N   L E N ( A L T _ T E L _ N U M )   =   0   T H E N   N U L L   E L S E   A L T _ T E L _ N U M   E N D   A S   A L T _ T E L _ N U M  
 , 	 C A S E   W H E N   L E N ( I N D _ F U L L _ N M )   =   0   T H E N   N U L L   E L S E   I N D _ F U L L _ N M   E N D   A S   I N D _ F U L L _ N M  
 , 	 C A S E   W H E N   L E N ( I N D _ T I T L E )   =   0   T H E N   N U L L   E L S E   I N D _ T I T L E   E N D   A S   I N D _ T I T L E  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D   E N D   A S   M A I L _ A D D  
 , 	 C A S E   W H E N   L E N ( S U P P L E M _ A D D )   =   0   T H E N   N U L L   E L S E   S U P P L E M _ A D D   E N D   A S   S U P P L E M _ A D D  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ C I T Y _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ C I T Y _ N M   E N D   A S   M A I L _ A D D _ C I T Y _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ S T _ C D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ S T _ C D   E N D   A S   M A I L _ A D D _ S T _ C D  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ S T _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ S T _ N M   E N D   A S   M A I L _ A D D _ S T _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ C O _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ C O _ N M   E N D   A S   M A I L _ A D D _ C O _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ Z I P _ C D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ Z I P _ C D   E N D   A S   M A I L _ A D D _ Z I P _ C D  
  
 F R O M  
 	 (  
 	 S E L E C T   n e w i d ( )     A S   S T _ R E C _ I N D  
 	     	   ,   E I . S T _ E I _ I N D   A S   S T _ E I _ I N D  
 	 	   ,   L T R I M ( R T R I M ( C . C T D S C ) )   A S   A F F I L _ T Y P E  
 	 	   ,   d b o . u d f s _ D a t e O r T i m e X M L ( C . A D A T E ,   0 )   A S   A F F I L _ S T A R T _ D A T E  
 	 	   ,   d b o . u d f s _ D a t e O r T i m e X M L ( C . I D A T E ,   0 )   A S   A F F I L _ E N D _ D A T E  
 	 	   ,   C A S E   W H E N   C . E M A D R   < >   ' ' ' '   A N D   C . E M D O M   < >   ' ' ' '  
 	   	 	   T H E N   C . E M A D R + ' ' @ ' ' + C . E M D O M    
 	 	       E N D   A S   E M A I L _ A D D  
 	 	   ,   L T R I M ( R T R I M ( C . P H O N E ) )   A S   T E L _ N U M  
 	 	   ,   N U L L   A S   P H _ E X T  
 	 	   ,   N U L L   A S   F A X _ N U M  
 	 	   ,   N U L L   A S   A L T _ T E L _ N U M  
 	 	   ,   L T R I M ( R T R I M ( C . A D R S E E ) )   A S   I N D _ F U L L _ N M  
 	 	   ,   L T R I M ( R T R I M ( C . P O S T T L ) )   A S   I N D _ T I T L E  
 	 	   ,   L T R I M ( R T R I M ( C . M A I L ) )   A S   M A I L _ A D D  
 	 	   ,   L T R I M ( R T R I M ( C . O P T A D R ) )   A S   S U P P L E M _ A D D  
 	 	   ,   L T R I M ( R T R I M ( C . C I T Y ) )   A S   M A I L _ A D D _ C I T Y _ N M  
 	 	   ,   L T R I M ( R T R I M ( C . S T A T E ) )   A S   M A I L _ A D D _ S T _ C D  
 	 	   ,   L T R I M ( R T R I M ( C . S T N A M ) )   A S   M A I L _ A D D _ S T _ N M  
 	 	   ,   ' ' U n i t e d   S t a t e s ' '   A S   M A I L _ A D D _ C O _ N M  
 	 	   ,   C A S E   W H E N   C . Z I P P L S   =   ' ' ' '  
 	 	   	   T H E N   C . Z I P C O D  
 	 	 	   E L S E   C . Z I P C O D + ' ' - ' '   + C . Z I P P L S      
 	 	       E N D   A S   M A I L _ A D D _ Z I P _ C D  
 	     F R O M   N E _ F a c i l i t y _ C o n t a c t s   C  
 	 	 I N N E R   J O I N   d b o . F R S _ E I   E I   O N  
 	 	 	 E I . S T _ F A C _ I N D   =   C . F A C I D   A N D  
 	 	 	 E I . E N V _ I N T _ T Y P E   =   C . P R G A C R  
  
 	 W H E R E   C . P R G A C R   < >   ' ' D E Q ' '  
  
 	 )   A S   G 1  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C _ O R G     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - -  
         I N S E R T   I N T O   F R S _ F A C _ O R G  
  
 S E L E C T  
 	 C A S E   W H E N   L E N ( S T _ R E C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ R E C _ I N D   E N D   A S   S T _ R E C _ I N D  
 , 	 C A S E   W H E N   L E N ( S T _ F A C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ F A C _ I N D   E N D   A S   S T _ F A C _ I N D  
 , 	 C A S E   W H E N   L E N ( A F F I L _ T Y P E )   =   0   T H E N   N U L L   E L S E   A F F I L _ T Y P E   E N D   A S   A F F I L _ T Y P E  
 , 	 C A S E   W H E N   L E N ( A F F I L _ S T A R T _ D A T E )   =   0   T H E N   N U L L   E L S E   A F F I L _ S T A R T _ D A T E   E N D   A S   A F F I L _ S T A R T _ D A T E  
 , 	 C A S E   W H E N   L E N ( A F F I L _ E N D _ D A T E )   =   0   T H E N   N U L L   E L S E   A F F I L _ E N D _ D A T E   E N D   A S   A F F I L _ E N D _ D A T E  
 , 	 C A S E   W H E N   L E N ( E M A I L _ A D D )   =   0   T H E N   N U L L   E L S E   E M A I L _ A D D   E N D   A S   E M A I L _ A D D  
 , 	 C A S E   W H E N   L E N ( T E L _ N U M )   =   0   T H E N   N U L L   E L S E   T E L _ N U M   E N D   A S   T E L _ N U M  
 , 	 C A S E   W H E N   L E N ( P H _ E X T )   =   0   T H E N   N U L L   E L S E   P H _ E X T   E N D   A S   P H _ E X T  
 , 	 C A S E   W H E N   L E N ( F A X _ N U M )   =   0   T H E N   N U L L   E L S E   F A X _ N U M   E N D   A S   F A X _ N U M  
 , 	 C A S E   W H E N   L E N ( A L T _ T E L _ N U M )   =   0   T H E N   N U L L   E L S E   A L T _ T E L _ N U M   E N D   A S   A L T _ T E L _ N U M  
 , 	 C A S E   W H E N   L E N ( O R G _ F O R M A L _ N M )   =   0   T H E N   N U L L   E L S E   O R G _ F O R M A L _ N M   E N D   A S   O R G _ F O R M A L _ N M  
 , 	 C A S E   W H E N   L E N ( O R G _ D U N S _ N U M )   =   0   T H E N   N U L L   E L S E   O R G _ D U N S _ N U M   E N D   A S   O R G _ D U N S _ N U M  
 , 	 C A S E   W H E N   L E N ( O R G _ T Y P E )   =   0   T H E N   N U L L   E L S E   O R G _ T Y P E   E N D   A S   O R G _ T Y P E  
 , 	 C A S E   W H E N   L E N ( E M P L O Y E R _ I N D )   =   0   T H E N   N U L L   E L S E   E M P L O Y E R _ I N D   E N D   A S   E M P L O Y E R _ I N D  
 , 	 C A S E   W H E N   L E N ( S T _ B U S I N E S S _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ B U S I N E S S _ I N D   E N D   A S   S T _ B U S I N E S S _ I N D  
 , 	 C A S E   W H E N   L E N ( U L T _ P A R E N T _ N M )   =   0   T H E N   N U L L   E L S E   U L T _ P A R E N T _ N M   E N D   A S   U L T _ P A R E N T _ N M  
 , 	 C A S E   W H E N   L E N ( U L T _ P A R E N T _ D U N S _ N U M )   =   0   T H E N   N U L L   E L S E   U L T _ P A R E N T _ D U N S _ N U M   E N D   A S   U L T _ P A R E N T _ D U N S _ N U M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D   E N D   A S   M A I L _ A D D  
 , 	 C A S E   W H E N   L E N ( S U P P L E M _ A D D )   =   0   T H E N   N U L L   E L S E   S U P P L E M _ A D D   E N D   A S   S U P P L E M _ A D D  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ C I T Y _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ C I T Y _ N M   E N D   A S   M A I L _ A D D _ C I T Y _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ S T _ C D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ S T _ C D   E N D   A S   M A I L _ A D D _ S T _ C D  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ S T _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ S T _ N M   E N D   A S   M A I L _ A D D _ S T _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ C O _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ C O _ N M   E N D   A S   M A I L _ A D D _ C O _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ Z I P _ C D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ Z I P _ C D   E N D   A S   M A I L _ A D D _ Z I P _ C D  
  
 F R O M  
 	 (  
 	 S E L E C T   n e w i d ( )     A S   S T _ R E C _ I N D  
 	 	   ,   N E _ F a c _ R e s p o n s i b l e P a r t y . F A C I D   A S   S T _ F A C _ I N D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . R P D S C ) )   A S   A F F I L _ T Y P E  
 	 	   ,   d b o . u d f s _ D a t e O r T i m e X M L ( N E _ F a c _ R e s p o n s i b l e P a r t y . A D A T E ,   0 )   A S   A F F I L _ S T A R T _ D A T E  
 	 	   ,   d b o . u d f s _ D a t e O r T i m e X M L ( N E _ F a c _ R e s p o n s i b l e P a r t y . I D A T E ,   0 )   A S   A F F I L _ E N D _ D A T E  
 	 	   ,   N U L L   A S   E M A I L _ A D D  
 	 	   ,   N U L L   A S   T E L _ N U M  
 	 	   ,   N U L L   A S   P H _ E X T  
 	 	   ,   N U L L   A S   F A X _ N U M  
 	 	   ,   N U L L   A S   A L T _ T E L _ N U M  
                   ,   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . R P N A M E ) )   A S   O R G _ F O R M A L _ N M  
 	 	   ,   N U L L   A S   O R G _ D U N S _ N U M  
 	 	   ,   L T R I M ( R T R I M ( S U B S T R I N G ( N E _ F a c _ R e s p o n s i b l e P a r t y . F O E D S C , 1 , 1 0 ) ) )   A S   O R G _ T Y P E  
 	 	   ,   N U L L   A S   E M P L O Y E R _ I N D  
 	 	   ,   N U L L   A S   S T _ B U S I N E S S _ I N D  
 	 	   ,   N U L L   A S   U L T _ P A R E N T _ N M  
 	 	   ,   N U L L   A S   U L T _ P A R E N T _ D U N S _ N U M  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . M A I L ) )   A S   M A I L _ A D D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . O P T A D R ) )   A S   S U P P L E M _ A D D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . C I T Y ) )   A S   M A I L _ A D D _ C I T Y _ N M  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . S T A T E ) )   A S   M A I L _ A D D _ S T _ C D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . S T N A M ) )   A S   M A I L _ A D D _ S T _ N M  
 	 	   ,   ' ' U n i t e d   S t a t e s ' '   A S   M A I L _ A D D _ C O _ N M  
 	 	   ,   C A S E   W H E N   N E _ F a c _ R e s p o n s i b l e P a r t y . Z I P P L S   =   ' ' ' '  
 	 	 	   T H E N   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . Z I P C O D ) )  
 	 	 	   E L S E   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . Z I P C O D ) ) + ' ' - ' '   + L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . Z I P P L S ) )  
 	 	       E N D   A S   M A I L _ A D D _ Z I P _ C D  
 	     F R O M   N E _ F a c _ R e s p o n s i b l e P a r t y   I N N E R   J O I N   F R S _ F A C  
 	 	 	 	 	 	 	 	             O N   ( F R S _ F A C . S T _ F A C _ I N D   =   N E _ F a c _ R e s p o n s i b l e P a r t y . f a c i d   )  
 	 )   A S   G 1  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ E I _ S I C     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - -  
  
 	 I N S E R T   I N T O   F R S _ E I _ S I C  
 	 S E L E C T   N E W I D ( )   A S   S T _ R E C _ I N D  
 	 	   ,   E . S T _ E I _ I N D   A S   S T _ E I _ I N D  
 	 	   ,   d b o . u d f s _ P a d L e a d i n g Z e r o e s ( S . S I C C O D ,   4 )   A S   S I C _ C D  
 	 	   ,   C A S E   W H E N   S . S I C P R I   =   1    
                           T H E N   ' ' P R I M A R Y ' '  
                                 W H E N   S . S I C P R I   =   2    
                           T H E N   ' ' S E C O N D A R Y ' '  
                           E L S E   ' ' U N K N O W N ' '  
                       E N D   A S   S I C _ P R I M _ I N D  
 	 F R O M   N E _ F a c i l i t y _ S I C   S  
 	 I N N E R   J O I N   F R S _ F A C   F   O N   F . S T _ F A C _ I N D   =   S . F A C I D  
 	 J O I N   F R S _ E I   E   O N  
 	 	 E . S T _ F A C _ I N D   =   S . F A C I D  
 	 A N D 	 E . E N V _ I N T _ T Y P E   =   S . P R G A C R  
 	 A N D   E . I N F _ S Y S _ I N D   =   ( L T R I M ( R T R I M ( S . P R G I D 1 ) )   +   ' ' - ' '   +   L T R I M ( R T R I M ( S . P R G I D 2 ) ) )  
  
 	 W H E R E   S . P R G A C R   < >   ' ' D E Q ' '  
 	 A N D   d b o . u d f s _ P a d L e a d i n g Z e r o e s ( S . S I C C O D ,   4 )   < >   ' ' 0 0 0 0 ' '  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C _ S I C   - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - -  
  
 	 I N S E R T   I N T O   F R S _ F A C _ S I C  
 	 S E L E C T   N E W I D ( )   A S   S T _ R E C _ I N D  
 	 	   ,   F . S T _ F A C _ I N D   A S   S T _ F A C _ I N D  
 	 	   ,   d b o . u d f s _ P a d L e a d i n g Z e r o e s ( S . S I C C O D ,   4 )   A S   S I C _ C D  
 	 	   ,   C A S E   W H E N   S . S I C P R I   =   1    
                           T H E N   ' ' P R I M A R Y ' '  
                                 W H E N   S . S I C P R I   =   2    
                           T H E N   ' ' S E C O N D A R Y ' '  
                           E L S E   ' ' U N K N O W N ' '  
                       E N D   A S   S I C _ P R I M _ I N D  
 	 F R O M   N E _ F a c i l i t y _ S I C   S  
 	 I N N E R   J O I N   F R S _ F A C   F   O N   F . S T _ F A C _ I N D   =   S . F A C I D  
 	 W H E R E   S . P R G A C R   =   ' ' D E Q ' '  
 	 A N D   d b o . u d f s _ P a d L e a d i n g Z e r o e s ( S . S I C C O D ,   4 )   < >   ' ' 0 0 0 0 ' '  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
  
 / *    
 S T E P   2 :   L o a d   d a t a   f r o m   t h e   N o d e   F l o w   i n   d a t a b a s e   -   i . e . ,   d a t a   r e c e i v e d   f r o m   E P A ' ' s   F R S   f o r   R M P   F a c i l i t i e s    
 * /  
  
  
 I N S E R T   I N T O   F R S _ F A C  
                       ( S T _ F A C _ I N D  
                       , F A C _ R E G _ I N D  
                       , F A C _ S I T E N M  
                       , F A C _ S I T E T Y P E _ N M  
                       , F E D _ F A C  
                       , T R I B _ L A N D  
                       , T R I B _ L A N D _ N M  
                       , C O N G _ D I S T _ N U M  
                       , L E G _ D I S T _ N U M  
                       , H U C _ C D  
                       , L O C _ A D D  
                       , S U P P L E M _ L O C  
                       , L O C A L _ N M  
                       , C N T Y _ S T _ F I P S _ C D  
                       , C N T Y _ N M  
                       , S T _ C D  
                       , S T _ N M  
                       , C O _ N M  
                       , L O C _ Z I P _ C D  
                       , L O C _ D E S C  
                       , D A T A _ S R C _ N M  
                       , R E P O R T E D _ D A T E  
                       , S T _ F A C _ S Y S _ A C )  
 S E L E C T   D I S T I N C T   S T A T E F A C I L I T Y I D E N T I F I E R  
             , F A C I L I T Y R E G I S T R Y I D E N T I F I E R  
             , F A C I L I T Y S I T E N A M E  
             , F A C I L I T Y S I T E T Y P E N A M E  
             , F E D E R A L F A C I L I T Y I N D I C A T O R  
             , T R I B A L L A N D I N D I C A T O R  
             , T R I B A L L A N D N A M E  
             , C O N G R E S S I O N A L D I S T R I C T N U M B E R  
             , L E G I S L A T I V E D I S T R I C T N U M B E R  
             , H U C C O D E  
             , L O C A T I O N A D D R E S S  
             , S U P P L E M E N T A L L O C A T I O N  
             , L O C A L I T Y N A M E  
             , C O U N T Y S T A T E F I P S C O D E  
             , C O U N T Y N A M E  
             , S T A T E U S P S  
             , S T A T E N A M E  
             , C O U N T R Y N A M E  
             , L O C A T I O N Z I P C O D E  
             , L O C A T I O N D E S C R I P T I O N T E X T  
 	     , S O U R C E O F D A T A  
             , C O N V E R T ( V A R C H A R ( 1 0 ) ,   L A S T R E P O R T E D D A T E ,   1 2 6 )   A S   L A S T R E P O R T E D D A T E  
             , S T A T E F A C I L I T Y S Y S T E M A C R O N Y M  
     F R O M   N o d e _ F l o w _ I n . d b o . F R S _ F A C I L I T Y S I T E   F    
 	 L E F T   O U T E R   J O I N   N o d e _ F l o w _ I n . d b o . F R S _ L O C A T I O N A D D R E S S   L   O N   L . F K   =   F . P K ;  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 I N S E R T   I N T O   F R S _ A D D  
                       ( S T _ F A C _ I N D  
                       , A F F I L _ T Y P E  
                       , M A I L _ A D D  
                       , S U P P L E M _ A D D  
                       , M A I L _ A D D _ C I T Y _ N M  
                       , M A I L _ A D D _ S T _ C D  
                       , M A I L _ A D D _ S T _ N M  
                       , M A I L _ A D D _ C O _ N M  
                       , M A I L _ A D D _ Z I P _ C D )  
 S E L E C T   D I S T I N C T   S T A T E F A C I L I T Y I D E N T I F I E R  
 	     ,   ' ' F A C I L I T Y   M A I L I N G ' '  
             , M A I L I N G A D D R E S S  
             , S U P P L E M E N T A L A D D R E S S  
             , M A I L I N G A D D R E S S C I T Y N A M E  
             , M A I L I N G A D D R E S S S T A T E U S P S  
             , M A I L I N G A D D R E S S S T A T E N A M E  
             , M A I L I N G A D D R E S S C O U N T R Y  
             , M A I L I N G A D D R E S S Z I P C O D E  
     F R O M   N o d e _ F l o w _ I n . d b o . F R S _ F A C I L I T Y S I T E ;  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 I N S E R T   I N T O   F R S _ A L T _ N M  
                       ( S T _ F A C _ I N D  
                       , A L T _ N M  
                       , A L T _ N A M E _ T Y P E )  
 S E L E C T   D I S T I N C T    
 S T A T E F A C I L I T Y I D E N T I F I E R ,  
 L E F T ( A L T E R N A T I V E N A M E , 8 0 ) ,  
 L E F T ( A L T E R N A T I V E N A M E T Y P E T E X T , 2 5 )  
 F R O M   N o d e _ F l o w _ I n . d b o . F R S _ F A C I L I T Y S I T E ;  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 I N S E R T   I N T O   F R S _ E I  
                       ( S T _ E I _ I N D  
                       , S T _ F A C _ I N D  
                       , I N F _ S Y S _ A C  
                       , I N F _ S Y S _ I N D  
                       , E N V _ I N T _ T Y P E  
                       , F E D _ S T _ I N T  
                       , E N V _ I N T _ S T A R T _ D A T E  
                       , I N T _ S T A R T _ D A T E _ Q U A L  
                       , E N V _ I N T _ E N D _ D A T E  
                       , I N T _ E N D _ D A T E _ Q U A L )  
 S E L E C T   D I S T I N C T   E . P K  
 	     , S T A T E F A C I L I T Y I D E N T I F I E R  
             , I N F O R M A T I O N S Y S T E M A C R O N Y M  
             , I N F O R M A T I O N S Y S T E M I D E N T I F I E R  
             , C A S E   W H E N   E N V I R O N M E N T A L I N T E R E S T T Y P E T E X T   =   ' ' R M P   R E P O R T E R ' '   T H E N   ' ' R M P ' '   E L S E   E N V I R O N M E N T A L I N T E R E S T T Y P E T E X T   E N D  
             , F E D E R A L S T A T E I N T E R E S T I N D I C A T O R  
             , C O N V E R T ( V A R C H A R ( 1 0 ) ,   E N V I R O N M E N T A L I N T E R E S T S T A R T D A T E ,   1 2 6 )   E N V I R O N M E N T A L I N T E R E S T S T A R T D A T E  
             , I N T E R E S T S T A R T D A T E Q U A L I F I E R T E X T  
             , C O N V E R T ( V A R C H A R ( 1 0 ) ,   E N V I R O N M E N T A L I N T E R E S T E N D D A T E ,   1 2 6 )   E N V I R O N M E N T A L I N T E R E S T E N D D A T E  
             , I N T E R E S T E N D D A T E Q U A L I F I E R T E X T  
     F R O M   N o d e _ F l o w _ I n . d b o . F R S _ E N V I R O N M E N T A L I N T E R E S T   E  
 	 J O I N     N o d e _ F l o w _ I n . d b o . F R S _ F A C I L I T Y S I T E   F   O N   F . P K   =   E . F K ;  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 I N S E R T   I N T O   F R S _ G E O  
                       ( S T _ F A C _ I N D  
                       , L A T _ M E A S U R E  
                       , L O N _ M E A S U R E  
                       , H O R I Z _ A C C U R _ M E A S U R E  
                       , H O R I Z _ C O L L _ M E T H  
                       , H O R I Z _ R E F _ D A T U M _ N M  
                       , S R C _ M A P _ S C A L E _ N U M  
                       , R E F _ P O I N T  
                       , D A T A _ C O L L _ D A T E  
                       , G E O _ T Y P E _ N M  
                       , L O C _ C O M M E N T S  
                       , V E R T _ C O L L _ M E T H  
                       , V E R T _ M E A S U R E  
                       , V E R T _ A C C U R _ M E A S U R E  
                       , V E R T _ R E F _ D A T U M _ N M  
                       , D A T A _ S R C _ N M  
                       , C O O R D _ D A T A _ S R C _ N M  
                       , S U B _ E N T _ I N D  
                       , S U B _ E N T _ T Y P E _ N M )  
 S E L E C T   D I S T I N C T   S T A T E F A C I L I T Y I D E N T I F I E R  
             , L A T I T U D E M E A S U R E  
             , L O N G I T U D E M E A S U R E  
             , H O R I Z O N T A L A C C U R A C Y M E A S U R E  
             , H O R I Z O N T A L C O L L E C T I O N M E T H O D  
             , H O R I Z O N T A L R E F E R E N C E D A T U M  
             , S O U R C E M A P S C A L E N U M B E R  
             , R E F E R E N C E P O I N T T E X T  
             , C O N V E R T ( V A R C H A R ( 1 0 ) ,   D A T A C O L L E C T I O N D A T E ,   1 2 6 )   D A T A C O L L E C T I O N D A T E  
             , G E O M E T R I C T Y P E N A M E  
             , L O C A T I O N C O M M E N T S T E X T  
             , V E R T I C A L C O L L E C T I O N M E T H O D  
             , V E R T I C A L M E A S U R E  
             , V E R T I C A L A C C U R A C Y M E A S U R E  
             , V E R T I C A L R E F E R E N C E D A T U M  
             , D A T A S O U R C E  
             , C O O R D I N A T E D A T A S O U R C E  
             , S U B E N T I T Y I D E N T I F I E R  
             , S U B E N T I T Y T Y P E N A M E  
     F R O M   N o d e _ F l o w _ I n . d b o . F R S _ G E O G R A P H I C C O O R D I N A T E S   G  
 	 J O I N     N o d e _ F l o w _ I n . d b o . F R S _ F A C I L I T Y S I T E   F   O N   F . P K   =   G . F K ;  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 I N S E R T   I N T O   F R S _ F A C _ I N D  
                       ( S T _ R E C _ I N D  
                       , S T _ F A C _ I N D  
                       , A F F I L _ T Y P E  
                       , A F F I L _ S T A R T _ D A T E  
                       , A F F I L _ E N D _ D A T E  
                       , E M A I L _ A D D  
                       , T E L _ N U M  
                       , P H _ E X T  
                       , F A X _ N U M  
                       , A L T _ T E L _ N U M  
                       , I N D _ F U L L _ N M  
                       , I N D _ T I T L E  
                       , M A I L _ A D D  
                       , S U P P L E M _ A D D  
                       , M A I L _ A D D _ C I T Y _ N M  
                       , M A I L _ A D D _ S T _ C D  
                       , M A I L _ A D D _ S T _ N M  
                       , M A I L _ A D D _ C O _ N M  
                       , M A I L _ A D D _ Z I P _ C D )  
 S E L E C T   D I S T I N C T   I . P K ,  
 	       S T A T E F A C I L I T Y I D E N T I F I E R  
             , A F F I L I A T I O N T Y P E T E X T  
             , C O N V E R T ( V A R C H A R ( 1 0 ) ,   A F F I L I A T I O N S T A R T D A T E ,   1 2 6 )   A F F I L I A T I O N S T A R T D A T E  
             , C O N V E R T ( V A R C H A R ( 1 0 ) ,   A F F I L I A T I O N E N D D A T E ,   1 2 6 )   A F F I L I A T I O N E N D D A T E  
             , E M A I L A D D R E S S  
             , T E L E P H O N E N U M B E R  
             , P H O N E E X T E N S I O N  
             , F A X N U M B E R  
             , A L T E R N A T E T E L E P H O N E N U M B E R  
             , I N D I V I D U A L F U L L N A M E  
             , I N D I V I D U A L T I T L E T E X T  
             , I . M A I L I N G A D D R E S S  
             , I . S U P P L E M E N T A L A D D R E S S  
             , I . M A I L I N G A D D R E S S C I T Y N A M E  
             , I . M A I L I N G A D D R E S S S T A T E U S P S  
             , I . M A I L I N G A D D R E S S S T A T E N A M E  
             , I . M A I L I N G A D D R E S S C O U N T R Y  
             , I . M A I L I N G A D D R E S S Z I P C O D E  
       F R O M   N o d e _ F l o w _ I n . d b o . F R S _ I N D I V I D U A L _ F A C I L I T Y   I  
 	 J O I N     N o d e _ F l o w _ I n . d b o . F R S _ F A C I L I T Y S I T E   F   O N   F . P K   =   I . F K ;  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 I N S E R T   I N T O   F R S _ F A C _ O R G  
                       ( S T _ R E C _ I N D  
                       , S T _ F A C _ I N D  
                       , A F F I L _ T Y P E  
                       , A F F I L _ S T A R T _ D A T E  
                       , A F F I L _ E N D _ D A T E  
                       , E M A I L _ A D D  
                       , T E L _ N U M  
                       , P H _ E X T  
                       , F A X _ N U M  
                       , A L T _ T E L _ N U M  
                       , O R G _ F O R M A L _ N M  
                       , O R G _ D U N S _ N U M  
                       , O R G _ T Y P E  
                       , E M P L O Y E R _ I N D  
                       , S T _ B U S I N E S S _ I N D  
                       , U L T _ P A R E N T _ N M  
                       , U L T _ P A R E N T _ D U N S _ N U M  
                       , M A I L _ A D D  
                       , S U P P L E M _ A D D  
                       , M A I L _ A D D _ C I T Y _ N M  
                       , M A I L _ A D D _ S T _ C D  
                       , M A I L _ A D D _ S T _ N M  
                       , M A I L _ A D D _ C O _ N M  
                       , M A I L _ A D D _ Z I P _ C D )  
 S E L E C T   D I S T I N C T   O . P K ,  
 	       S T A T E F A C I L I T Y I D E N T I F I E R  
             , A F F I L I A T I O N T Y P E T E X T  
             , C O N V E R T ( V A R C H A R ( 1 0 ) ,   A F F I L I A T I O N S T A R T D A T E ,   1 2 6 )   A F F I L I A T I O N S T A R T D A T E  
             , C O N V E R T ( V A R C H A R ( 1 0 ) ,   A F F I L I A T I O N E N D D A T E ,   1 2 6 )   A F F I L I A T I O N E N D D A T E  
             , E M A I L A D D R E S S  
             , T E L E P H O N E N U M B E R  
             , P H O N E E X T E N S I O N  
             , F A X N U M B E R  
             , A L T E R N A T E T E L E P H O N E N U M B E R  
 	     , O R G A N I Z A T I O N F O R M A L N A M E  
             , O R G A N I Z A T I O N D U N S N U M B E R  
             , O R G A N I Z A T I O N T Y P E T E X T  
             , E M P L O Y E R I D E N T I F I E R  
             , S T A T E B U S I N E S S I D E N T I F I E R  
             , U L T I M A T E P A R E N T N A M E  
             , U L T I M A T E P A R E N T D U N S N U M B E R  
             , O . M A I L I N G A D D R E S S  
             , O . S U P P L E M E N T A L A D D R E S S  
             , O . M A I L I N G A D D R E S S C I T Y N A M E  
             , O . M A I L I N G A D D R E S S S T A T E U S P S  
             , O . M A I L I N G A D D R E S S S T A T E N A M E  
             , O . M A I L I N G A D D R E S S C O U N T R Y  
             , O . M A I L I N G A D D R E S S Z I P C O D E  
     F R O M   N o d e _ F l o w _ I n . d b o . F R S _ O R G A N I Z A T I O N _ F A C I L I T Y   O  
 	 J O I N     N o d e _ F l o w _ I n . d b o . F R S _ F A C I L I T Y S I T E   F   O N   F . P K   =   O . F K ;  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 I N S E R T   I N T O   F R S _ F A C _ S I C  
                       ( S T _ R E C _ I N D  
                       , S T _ F A C _ I N D  
                       , S I C _ C D  
                       , S I C _ P R I M _ I N D )  
 S E L E C T   S . P K  
             , S T A T E F A C I L I T Y I D E N T I F I E R  
             , d b o . u d f s _ P a d L e a d i n g Z e r o e s ( S I C C O D E ,   4 )  
             , S I C P R I M A R Y I N D I C A T O R  
     F R O M   N o d e _ F l o w _ I n . d b o . F R S _ S I C C O D E _ F A C I L I T Y   S  
 	 J O I N     N o d e _ F l o w _ I n . d b o . F R S _ F A C I L I T Y S I T E   F   O N   F . P K   =   S . F K ;  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 I N S E R T   I N T O   F R S _ F A C _ N A I C S  
                       ( S T _ R E C _ I N D  
                       , S T _ F A C _ I N D  
                       , N A I C S _ C D  
                       , N A I C S _ P R I M _ I N D )  
 S E L E C T   N . P K  
             , S T A T E F A C I L I T Y I D E N T I F I E R  
             , d b o . u d f s _ P a d L e a d i n g Z e r o e s ( N A I C S C O D E ,   6 )  
             , N A I C S P R I M A R Y I N D I C A T O R  
     F R O M   N o d e _ F l o w _ I n . d b o . F R S _ N A I C S C O D E _ F A C I L I T Y   N  
 	 J O I N     N o d e _ F l o w _ I n . d b o . F R S _ F A C I L I T Y S I T E   F   O N   F . P K   =   N . F K ;  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 E N D  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ F R S _ G e t F R S D a t a ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ G e t F R S D a t a ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 M a r k   C h m a r n y  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 7 - 0 9  
 - -   D e s c r i p t i o n : 	 F R S   F l o w   d a t a   r e t r i e v a l    
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ F R S _ G e t F R S D a t a ]  
 	 @ C h a n g e D a t e   d a t e t i m e ,  
         @ L i s t I n d e x   i n t  
 A S  
 B E G I N  
 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 S E T   N O C O U N T   O N ;  
  
 - - F R S _ F A C  
 I F   @ L i s t I n d e x   =   0  
  
         S E L E C T 	 f . *  
         F R O M   d b o . F R S _ F A C   f  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   O N   f . S T _ F A C _ I N D   =   c . S T _ F A C _ I N D  
         W H E R E  
 	 	 c . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
 	 A N D 	 c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e ;  
  
 - - F R S _ F A C _ I N D  
 E L S E   I F   @ L i s t I n d e x   =   1  
  
         S E L E C T 	 i n d . *  
         F R O M   d b o . F R S _ F A C _ I N D   i n d  
         J O I N   d b o . F R S _ F A C   f   O N   i n d . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   O N   f . S T _ F A C _ I N D   =   c . S T _ F A C _ I N D  
         W H E R E  
 	 	 c . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
 	 A N D 	 c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e ;  
  
 - - F R S _ F A C _ N A I C S  
 E L S E   I F   @ L i s t I n d e x   =   2  
  
         S E L E C T 	 N A I C S . *  
         F R O M   d b o . F R S _ F A C _ N A I C S   N A I C S  
         J O I N   d b o . F R S _ F A C   f   O N   N A I C S . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   O N   f . S T _ F A C _ I N D   =   c . S T _ F A C _ I N D  
         W H E R E  
 	 	 c . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
 	 A N D 	 c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e ;  
  
 - - F R S _ F A C _ O R G  
 E L S E   I F   @ L i s t I n d e x   =   3  
  
         S E L E C T 	 O R G . *  
         F R O M   d b o . F R S _ F A C _ O R G   O R G  
         J O I N   d b o . F R S _ F A C   f   O N   O R G . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   O N   f . S T _ F A C _ I N D   =   c . S T _ F A C _ I N D  
         W H E R E  
 	 	 c . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
 	 A N D 	 c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e ;  
  
 - - F R S _ F A C _ S I C  
 E L S E   I F   @ L i s t I n d e x   =   4  
  
         S E L E C T 	 S I C . *  
         F R O M   d b o . F R S _ F A C _ S I C   S I C  
         J O I N   d b o . F R S _ F A C   f   O N   S I C . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   O N   f . S T _ F A C _ I N D   =   c . S T _ F A C _ I N D  
         W H E R E  
 	 	 c . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
 	 A N D 	 c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e ;  
  
 - - F R S _ A D D  
 E L S E   I F   @ L i s t I n d e x   =   5  
  
         S E L E C T 	 F A D D . *  
         F R O M   d b o . F R S _ A D D   F A D D  
         J O I N   d b o . F R S _ F A C   f   O N   F A D D . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   O N   f . S T _ F A C _ I N D   =   c . S T _ F A C _ I N D  
         W H E R E  
 	 	 c . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
 	 A N D 	 c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e ;  
  
 - - F R S _ A L T _ N M  
 E L S E   I F   @ L i s t I n d e x   =   6  
  
         S E L E C T 	 A L T _ N M . *  
         F R O M   d b o . F R S _ A L T _ N M   A L T _ N M  
         J O I N   d b o . F R S _ F A C   f   O N   A L T _ N M . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   O N   f . S T _ F A C _ I N D   =   c . S T _ F A C _ I N D  
         W H E R E  
 	 	 c . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
 	 A N D 	 c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e ;  
  
 - - F R S _ G E O  
 E L S E   I F   @ L i s t I n d e x   =   7  
  
         S E L E C T 	 G E O . *  
         F R O M   d b o . F R S _ G E O   G E O  
         J O I N   d b o . F R S _ F A C   f   O N   G E O . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   O N   f . S T _ F A C _ I N D   =   c . S T _ F A C _ I N D  
         W H E R E  
 	 	 c . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
 	 A N D 	 c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e ;  
  
 - - F R S _ E I  
 E L S E   I F   @ L i s t I n d e x   =   8  
  
         S E L E C T 	 E I . *  
         F R O M   d b o . F R S _ E I   E I  
         J O I N   d b o . F R S _ F A C   f   O N   E I . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   O N   f . S T _ F A C _ I N D   =   c . S T _ F A C _ I N D  
         W H E R E  
 	 	 c . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
 	 A N D 	 c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e ;  
  
 - - F R S _ E I _ I N D  
 E L S E   I F   @ L i s t I n d e x   =   9  
  
         S E L E C T 	 E I _ I N D . *  
         F R O M   d b o . F R S _ E I _ I N D   E I _ I N D  
         J O I N   d b o . F R S _ E I   E I   O N   E I _ I N D . S T _ E I _ I N D   =   E I . S T _ E I _ I N D  
         J O I N   d b o . F R S _ F A C   f   O N   E I . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   O N   f . S T _ F A C _ I N D   =   c . S T _ F A C _ I N D  
         W H E R E  
 	 	 c . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
 	 A N D 	 c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e ;  
  
 - - F R S _ E I _ N A I C S  
 E L S E   I F   @ L i s t I n d e x   =   1 0  
  
         S E L E C T 	 E I _ N A I C S . *  
         F R O M   d b o . F R S _ E I _ N A I C S   E I _ N A I C S  
         J O I N   d b o . F R S _ E I   E I   O N   E I _ N A I C S . S T _ E I _ I N D   =   E I . S T _ E I _ I N D  
         J O I N   d b o . F R S _ F A C   f   O N   E I . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   O N   f . S T _ F A C _ I N D   =   c . S T _ F A C _ I N D  
         W H E R E  
 	 	 c . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
 	 A N D 	 c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e ;  
  
 - - F R S _ E I _ O R G  
 E L S E   I F   @ L i s t I n d e x   =   1 1  
  
         S E L E C T 	 E I _ O R G . *  
         F R O M   d b o . F R S _ E I _ O R G   E I _ O R G  
         J O I N   d b o . F R S _ E I   E I   O N   E I _ O R G . S T _ E I _ I N D   =   E I . S T _ E I _ I N D  
         J O I N   d b o . F R S _ F A C   f   O N   E I . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   O N   f . S T _ F A C _ I N D   =   c . S T _ F A C _ I N D  
         W H E R E  
 	 	 c . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
 	 A N D 	 c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e ;  
  
 - - F R S _ E I _ S I C  
 E L S E   I F   @ L i s t I n d e x   =   1 2  
  
         S E L E C T 	 E I _ S I C . *  
         F R O M   d b o . F R S _ E I _ S I C   E I _ S I C  
         J O I N   d b o . F R S _ E I   E I   O N   E I _ S I C . S T _ E I _ I N D   =   E I . S T _ E I _ I N D  
         J O I N   d b o . F R S _ F A C   f   O N   E I . S T _ F A C _ I N D   =   f . S T _ F A C _ I N D  
 	 J O I N   d b o . C H A N G E D _ F A C I L I T I E S   c   O N   f . S T _ F A C _ I N D   =   c . S T _ F A C _ I N D  
         W H E R E  
 	 	 c . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
 	 A N D 	 c . U P D A T E _ D A T E   > =   @ C h a n g e D a t e ;  
  
 E N D  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     U s e r D e f i n e d F u n c t i o n   [ d b o ] . [ u d f t _ D i s p l a y T i e r 2 I n f o ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ u d f t _ D i s p l a y T i e r 2 I n f o ] ' )   A N D   t y p e   i n   ( N ' F N ' ,   N ' I F ' ,   N ' T F ' ,   N ' F S ' ,   N ' F T ' ) )  
 B E G I N  
 e x e c u t e   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 T K   C o n r a d   ( W i n d s o r   S o l u t i o n s ,   I n c . )  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 7 - 2 5  
 - -   D e s c r i p t i o n : 	 R e t u r n s   s e l e c t e d   T i e r   I I   d a t a   f o r   a   p a s s e d - i n   F a c i l i t y   I D  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   F U N C T I O N   [ d b o ] . [ u d f t _ D i s p l a y T i e r 2 I n f o ]    
 ( 	  
 	 - -   A d d   t h e   p a r a m e t e r s   f o r   t h e   f u n c t i o n   h e r e  
 	 @ F A C I D   i n t  
 )  
 R E T U R N S   T A B L E    
 A S  
 R E T U R N    
 (  
 	 - -   A d d   t h e   S E L E C T   s t a t e m e n t   w i t h   p a r a m e t e r   r e f e r e n c e s   h e r e  
 S E L E C T  
 	 F A C . S T _ F A C _ I N D   A S   F A C _ S T _ F A C _ I N D  
 , 	 F A C . F A C _ R E G _ I N D   A S   F A C _ F A C _ R E G _ I N D  
 , 	 F A C . F A C _ S I T E N M   A S   F A C _ F A C _ S I T E N M  
 , 	 F A C . F A C _ S I T E T Y P E _ N M   A S   F A C _ F A C _ S I T E T Y P E _ N M  
 , 	 F A C . F E D _ F A C   A S   F A C _ F E D _ F A C  
 , 	 F A C . T R I B _ L A N D   A S   F A C _ T R I B _ L A N D  
 , 	 F A C . T R I B _ L A N D _ N M   A S   F A C _ T R I B _ L A N D _ N M  
 , 	 F A C . C O N G _ D I S T _ N U M   A S   F A C _ C O N G _ D I S T _ N U M  
 , 	 F A C . L E G _ D I S T _ N U M   A S   F A C _ L E G _ D I S T _ N U M  
 , 	 F A C . H U C _ C D   A S   F A C _ H U C _ C D  
 , 	 F A C . L O C _ A D D   A S   F A C _ L O C _ A D D  
 , 	 F A C . S U P P L E M _ L O C   A S   F A C _ S U P P L E M _ L O C  
 , 	 F A C . L O C A L _ N M   A S   F A C _ L O C A L _ N M  
 , 	 F A C . C N T Y _ S T _ F I P S _ C D   A S   F A C _ C N T Y _ S T _ F I P S _ C D  
 , 	 F A C . C N T Y _ N M   A S   F A C _ C N T Y _ N M  
 , 	 F A C . S T _ C D   A S   F A C _ S T _ C D  
 , 	 F A C . S T _ N M   A S   F A C _ S T _ N M  
 , 	 F A C . C O _ N M   A S   F A C _ C O _ N M  
 , 	 F A C . L O C _ Z I P _ C D   A S   F A C _ L O C _ Z I P _ C D  
 , 	 F A C . L O C _ D E S C   A S   F A C _ L O C _ D E S C  
 , 	 F A C . D A T A _ S R C _ N M   A S   F A C _ D A T A _ S R C _ N M  
 , 	 F A C . R E P O R T E D _ D A T E   A S   F A C _ R E P O R T E D _ D A T E  
 , 	 F A C . S T _ F A C _ S Y S _ A C   A S   F A C _ S T _ F A C _ S Y S _ A C  
 , 	 E I . S T _ E I _ I N D   A S   E I _ S T _ E I _ I N D  
 , 	 E I . S T _ F A C _ I N D   A S   E I _ S T _ F A C _ I N D  
 , 	 E I . I N F _ S Y S _ A C   A S   E I _ I N F _ S Y S _ A C  
 , 	 E I . I N F _ S Y S _ I N D   A S   E I _ I N F _ S Y S _ I N D  
 , 	 E I . E N V _ I N T _ T Y P E   A S   E I _ E N V _ I N T _ T Y P E  
 , 	 E I . F E D _ S T _ I N T   A S   E I _ F E D _ S T _ I N T  
 , 	 E I . E N V _ I N T _ S T A R T _ D A T E   A S   E I _ E N V _ I N T _ S T A R T _ D A T E  
 , 	 E I . I N T _ S T A R T _ D A T E _ Q U A L   A S   E I _ I N T _ S T A R T _ D A T E _ Q U A L  
 , 	 E I . E N V _ I N T _ E N D _ D A T E   A S   E I _ E N V _ I N T _ E N D _ D A T E  
 , 	 E I . I N T _ E N D _ D A T E _ Q U A L   A S   E I _ I N T _ E N D _ D A T E _ Q U A L  
 , 	 T 2 . P K _ G U I D   A S   T 2 _ P K _ G U I D  
 , 	 T 2 . F K _ G U I D   A S   T 2 _ F K _ G U I D  
 , 	 T 2 . F a c i l i t y S i t e I d e n t i f i e r   A S   T 2 _ F a c i l i t y S i t e I d e n t i f i e r  
 , 	 T 2 . F a c i l i t y S i t e N a m e   A S   T 2 _ F a c i l i t y S i t e N a m e  
 , 	 T 2 . F a c i l i t y S t a t u s   A S   T 2 _ F a c i l i t y S t a t u s  
 , 	 T 2 . L o c a t i o n A d d r e s s T e x t   A S   T 2 _ L o c a t i o n A d d r e s s T e x t  
 , 	 T 2 . S u p p l e m e n t a l L o c a t i o n T e x t   A S   T 2 _ S u p p l e m e n t a l L o c a t i o n T e x t  
 , 	 T 2 . L o c a l i t y N a m e   A S   T 2 _ L o c a l i t y N a m e  
 , 	 T 2 . S t a t e C o d e   A S   T 2 _ S t a t e C o d e  
 , 	 T 2 . S t a t e C o d e L i s t I d e n t i f i e r   A S   T 2 _ S t a t e C o d e L i s t I d e n t i f i e r  
 , 	 T 2 . S t a t e N a m e   A S   T 2 _ S t a t e N a m e  
 , 	 T 2 . A d d r e s s P o s t a l C o d e   A S   T 2 _ A d d r e s s P o s t a l C o d e  
 , 	 T 2 . C o u n t r y C o d e   A S   T 2 _ C o u n t r y C o d e  
 , 	 T 2 . C o u n t r y C o d e L i s t I d e n t i f i e r   A S   T 2 _ C o u n t r y C o d e L i s t I d e n t i f i e r  
 , 	 T 2 . C o u n t r y N a m e   A S   T 2 _ C o u n t r y N a m e  
 , 	 T 2 . C o u n t y C o d e   A S   T 2 _ C o u n t y C o d e  
 , 	 T 2 . C o u n t y C o d e L i s t I d e n t i f i e r   A S   T 2 _ C o u n t y C o d e L i s t I d e n t i f i e r  
 , 	 T 2 . C o u n t y N a m e   A S   T 2 _ C o u n t y N a m e  
 , 	 T 2 . T r i b a l C o d e   A S   T 2 _ T r i b a l C o d e  
 , 	 T 2 . T r i b a l C o d e L i s t I d e n t i f i e r   A S   T 2 _ T r i b a l C o d e L i s t I d e n t i f i e r  
 , 	 T 2 . T r i b a l N a m e   A S   T 2 _ T r i b a l N a m e  
 , 	 T 2 . T r i b a l L a n d N a m e   A S   T 2 _ T r i b a l L a n d N a m e  
 , 	 T 2 . T r i b a l L a n d I n d i c a t o r   A S   T 2 _ T r i b a l L a n d I n d i c a t o r  
 , 	 T 2 . L o c a t i o n D e s c r i p t i o n T e x t   A S   T 2 _ L o c a t i o n D e s c r i p t i o n T e x t  
 , 	 T 2 . M a i l i n g F a c i l i t y S i t e N a m e   A S   T 2 _ M a i l i n g F a c i l i t y S i t e N a m e  
 , 	 T 2 . M a i l i n g A d d r e s s T e x t   A S   T 2 _ M a i l i n g A d d r e s s T e x t  
 , 	 T 2 . M a i l i n g S u p p l e m e n t a l A d d r e s s T e x t   A S   T 2 _ M a i l i n g S u p p l e m e n t a l A d d r e s s T e x t  
 , 	 T 2 . M a i l i n g A d d r e s s C i t y N a m e   A S   T 2 _ M a i l i n g A d d r e s s C i t y N a m e  
 , 	 T 2 . M a i l i n g S t a t e C o d e   A S   T 2 _ M a i l i n g S t a t e C o d e  
 , 	 T 2 . M a i l i n g S t a t e C o d e L i s t I d e n t i f i e r   A S   T 2 _ M a i l i n g S t a t e C o d e L i s t I d e n t i f i e r  
 , 	 T 2 . M a i l i n g S t a t e N a m e   A S   T 2 _ M a i l i n g S t a t e N a m e  
 , 	 T 2 . M a i l i n g A d d r e s s P o s t a l C o d e   A S   T 2 _ M a i l i n g A d d r e s s P o s t a l C o d e  
 , 	 T 2 . M a i l i n g C o u n t r y C o d e   A S   T 2 _ M a i l i n g C o u n t r y C o d e  
 , 	 T 2 . M a i l i n g C o u n t r y C o d e L i s t I d e n t i f i e r   A S   T 2 _ M a i l i n g C o u n t r y C o d e L i s t I d e n t i f i e r  
 , 	 T 2 . M a i l i n g C o u n t r y N a m e   A S   T 2 _ M a i l i n g C o u n t r y N a m e  
 , 	 T 2 . P a r e n t C o m p a n y N a m e N A I n d i c a t o r   A S   T 2 _ P a r e n t C o m p a n y N a m e N A I n d i c a t o r  
 , 	 T 2 . P a r e n t C o m p a n y N a m e T e x t   A S   T 2 _ P a r e n t C o m p a n y N a m e T e x t  
 , 	 T 2 . P a r e n t D u n B r a d s t r e e t C o d e   A S   T 2 _ P a r e n t D u n B r a d s t r e e t C o d e  
 , 	 T 2 C H E M I N V . P K _ G U I D   A S   T 2 C H E M I N V _ P K _ G U I D  
 , 	 T 2 C H E M I N V . F K _ G U I D   A S   T 2 C H E M I N V _ F K _ G U I D  
 , 	 T 2 C H E M I N V . C h e m i c a l I d e n t i f i e r   A S   T 2 C H E M I N V _ C h e m i c a l I d e n t i f i e r  
 , 	 T 2 C H E M I N V . E H S I n d i c a t o r   A S   T 2 C H E M I N V _ E H S I n d i c a t o r  
 , 	 T 2 C H E M I N V . T r a d e S e c r e t I n d i c a t o r   A S   T 2 C H E M I N V _ T r a d e S e c r e t I n d i c a t o r  
 , 	 T 2 C H E M I N V . C A S N u m b e r   A S   T 2 C H E M I N V _ C A S N u m b e r  
 , 	 T 2 C H E M I N V . C h e m S u b s t a n c e S y s t e m a t i c N a m e   A S   T 2 C H E M I N V _ C h e m S u b s t a n c e S y s t e m a t i c N a m e  
 , 	 T 2 C H E M I N V . E P A C h e m i c a l R e g i s t r y N a m e   A S   T 2 C H E M I N V _ E P A C h e m i c a l R e g i s t r y N a m e  
 , 	 T 2 C H E M I N V . E P A C h e m i c a l I d e n t i f i e r   A S   T 2 C H E M I N V _ E P A C h e m i c a l I d e n t i f i e r  
 , 	 T 2 C H E M I N V . C h e m i c a l N a m e C o n t e x t   A S   T 2 C H E M I N V _ C h e m i c a l N a m e C o n t e x t  
 , 	 T 2 C H E M L O C . P K _ G U I D   A S   T 2 C H E M L O C _ P K _ G U I D  
 , 	 T 2 C H E M L O C . F K _ G U I D   A S   T 2 C H E M L O C _ F K _ G U I D  
 , 	 T 2 C H E M L O C . C o n f i d e n t i a l L o c a t i o n I n d i c a t o r   A S   T 2 C H E M L O C _ C o n f i d e n t i a l L o c a t i o n I n d i c a t o r  
 , 	 T 2 C H E M L O C . S t o r a g e T y p e C o d e   A S   T 2 C H E M L O C _ S t o r a g e T y p e C o d e  
 , 	 T 2 C H E M L O C . S t o r a g e T y p e D e s c r i p t i o n   A S   T 2 C H E M L O C _ S t o r a g e T y p e D e s c r i p t i o n  
 , 	 T 2 C H E M L O C . S t o r a g e L o c T e m p e r a t u r e C o d e   A S   T 2 C H E M L O C _ S t o r a g e L o c T e m p e r a t u r e C o d e  
 , 	 T 2 C H E M L O C . S t o r a g e L o c T e m p e r a t u r e D e s c   A S   T 2 C H E M L O C _ S t o r a g e L o c T e m p e r a t u r e D e s c  
 , 	 T 2 C H E M L O C . S t o r a g e L o c P r e s s u r e C o d e   A S   T 2 C H E M L O C _ S t o r a g e L o c P r e s s u r e C o d e  
 , 	 T 2 C H E M L O C . S t o r a g e L o c P r e s s u r e D e s c   A S   T 2 C H E M L O C _ S t o r a g e L o c P r e s s u r e D e s c  
 , 	 T 2 C H E M L O C . S t o r a g e L o c D e s c r i p t i o n   A S   T 2 C H E M L O C _ S t o r a g e L o c D e s c r i p t i o n  
 , 	 T 2 C H E M L O C . M a x i m u m A m o u n t A t L o c a t i o n   A S   T 2 C H E M L O C _ M a x i m u m A m o u n t A t L o c a t i o n  
 , 	 T 2 C H E M L O C . M e a s u r e m e n t U n i t   A S   T 2 C H E M L O C _ M e a s u r e m e n t U n i t  
  
  
 F R O M   d b o . F R S _ F A C   F A C  
 J O I N   d b o . F R S _ E I   E I   O N   F A C . S T _ F A C _ I N D   =   E I . S T _ F A C _ I N D  
 J O I N   d b o . T 2 _ F A C _ S I T E   T 2  
 	 J O I N   d b o . T 2 _ C H E M _ I N V   T 2 C H E M I N V   O N   T 2 . P K _ G U I D   =   T 2 C H E M I N V . F K _ G U I D  
 	 J O I N   d b o . T 2 _ C H E M _ L O C   T 2 C H E M L O C   O N   T 2 C H E M I N V . P K _ G U I D   =   T 2 C H E M L O C . F K _ G U I D  
 O N   F A C . S T _ F A C _ I N D   =   T 2 . F a c i l i t y S i t e I d e n t i f i e r  
  
 W H E R E   F A C . S T _ F A C _ I N D   =   C O N V E R T ( V A R C H A R ,   @ F A C I D )  
  
 )  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ N E _ F R S _ I N I T ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ N E _ F R S _ I N I T ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	   K e v i n   J a m e s   ( W i n d s o r   S o l u t i o n s ,   I n c . )  
 - -   C r e a t e   d a t e :     J u l y   0 6 ,   2 0 0 7  
 - -   D e s c r i p t i o n : 	   T h i s   p r o c e d u r e   w i l l   s e t - u p   t h e   H E R E   F R S   t a b l e s   f o r    
 - -                               p r o c e s s i n g .        
 - -  
 - -   M a i n t e n a n c e   N o t e s :  
 - -   D a t e :                   A n a l y s t :               D e s c r i p t i o n :  
 - -   - - - - - - - - - - -       - - - - - - - - - - - - -     - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 - -   0 6 - J U L - 2 0 0 7       K J a m e s                   N e w   p r o c e d u r e  
 - -   1 9 - J U L - 2 0 0 7       K J a m e s                   A d d e d   e r r o r   c h e c k i n g   t o   s u p p o r t   t r a n s a c t i o n  
 - -                                                             b a s e d   p r o c e s s i n g   o f   H E R E   d a t a   l o a d s .  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ N E _ F R S _ I N I T ]   @ v a l u e   I N T   O U T P U T  
  
 A S  
 B E G I N  
         D E C L A R E   @ E R R O R _ C O D E   I N T  
  
 	 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 	 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 	 S E T   N O C O U N T   O N ;  
  
         - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
         - -   D E L E T E   F R S _ F A C :     D e l e t e   r e c o r d s   f r o m   t h e   C O M P A R E   s c h e m a   t o   p r e p a r e   t h e     - -  
         - -                                     t a b l e s   f o r   d a t a   p o p u l a t e d   f r o m   t h e   p r e v i o u s   r u n   i n           - -  
         - -                                     t h e   S T A G I N G   s c h e m a .  
         - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 D E L E T E   F R O M   [ c m p ] . [ F R S _ F A C ]  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R  
         I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - - - - -  
         - -     F A C I L I T Y   D A T A     - -  
         - -     F A C I L I T Y   D A T A     - -  
         - -     F A C I L I T Y   D A T A     - -  
         - - - - - - - - - - - - - - - - - - - - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ F R S _ F A C ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ F R S _ F A C ]  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R  
         I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ A D D     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
         I N S E R T   I N T O   [ c m p ] . [ F R S _ A D D ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ F R S _ A D D ]  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R  
         I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ A L T _ N M     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ F R S _ A L T _ N M ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ F R S _ A L T _ N M ]  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R  
         I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C _ D E L     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ F R S _ F A C _ D E L ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ F R S _ F A C _ D E L ]  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R  
         I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C _ I N D     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ F R S _ F A C _ I N D ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ F R S _ F A C _ I N D ]  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R  
         I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C _ N A I C S     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ F R S _ F A C _ N A I C S ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ F R S _ F A C _ N A I C S ]  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R  
         I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C _ O R G     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ F R S _ F A C _ O R G ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ F R S _ F A C _ O R G ]  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R  
         I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C _ S I C     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ F R S _ F A C _ S I C ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ F R S _ F A C _ S I C ]  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R  
         I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ G E O     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ F R S _ G E O ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ F R S _ G E O ]  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R  
         I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
         - -     E N V I R O N M E N T A L   I N T E R T E S T   D A T A     - -  
         - -     E N V I R O N M E N T A L   I N T E R T E S T   D A T A     - -  
         - -     E N V I R O N M E N T A L   I N T E R T E S T   D A T A     - -  
         - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ E I     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ F R S _ E I ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ F R S _ E I ]  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R  
         I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ E I _ I N D     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ F R S _ E I _ I N D ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ F R S _ E I _ I N D ]  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R  
         I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ E I _ N A I C S     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ F R S _ E I _ N A I C S ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ F R S _ E I _ N A I C S ]  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R  
         I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ E I _ O R G     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ F R S _ E I _ O R G ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ F R S _ E I _ O R G ]  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R  
         I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ E I _ S I C     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ c m p ] . [ F R S _ E I _ S I C ]    
 	 S E L E C T   *   F R O M   [ d b o ] . [ F R S _ E I _ S I C ]  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R  
         I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 E N D  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ N E _ F R S _ L O A D _ 2 0 0 7 1 0 1 1 ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ N E _ F R S _ L O A D _ 2 0 0 7 1 0 1 1 ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 K e v i n   J a m e s   ( W i n d s o r   S o l u t i o n s ,   I n c . )  
 - -   C r e a t e   d a t e :   J u n e   1 3 ,   2 0 0 7  
 - -   D e s c r i p t i o n : 	 T h i s   p r o c e d u r e   w i l l   l o a d   f a c i l i t y   d a t a   a n d   r e l a t e d  
 - -                             d a t a   e l e m e n t s   i n t o   t h e   H E R E   s t a g i n g   d a t a b a s e .  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ N E _ F R S _ L O A D _ 2 0 0 7 1 0 1 1 ]   @ v a l u e   I N T   O U T P U T  
  
 A S  
 B E G I N  
  
         D E C L A R E   @ E R R O R _ C O D E   I N T  
  
 	 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 	 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 	 S E T   N O C O U N T   O N ;  
  
 - -   T K C   9 / 2 7 / 2 0 0 7 	 T h i s   s t a t e m e n t   i s   c u r r e n t l y   c a u s i n g   d u p l i c a t e   e r r o r s .   B e c a u s e  
 - - 	 	 	 d e l e t e d   f a c i l i t i e s   a r e   h a n d l e d   b y   a n   e n t i r e l y   d i f f e r e n t  
 - - 	 	 	 p r o c e s s   f o r   t h e   H E R E   p r o j e c t ,   t h i s   s t a t e m e n t   c a n   b e  
 - - 	 	 	 r e m o v e d   f r o m   t h e   H E R E   v e r s i o n .  
 / *  
         - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
         - -   A D D   D E L E T E D   F A C I L I T I E S   T O   F R S _ F A C _ D E L   t a b l e                                                           - -  
         - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
  
 I N S E R T   I N T O   [ d b o ] . [ F R S _ F A C _ D E L ]  
 S E L E C T  
                         F R S . S T _ F A C _ I N D   A S   S T _ F A C _ I N D   - -   < S T _ F A C _ I N D ,   v a r c h a r ( 1 2 ) , >  
                       , L E F T ( C O N V E R T ( V A R C H A R ,   G e t D a t e ( ) ,   1 2 6 ) ,   1 0 )   A S   D E L E T I O N _ D A T E   - -   < D E L E T I O N _ D A T E ,   v a r c h a r ( 1 0 ) , >  
                       , F R S . S T _ F A C _ S Y S _ A C   A S   S T _ F A C _ S Y S _ A C   - -   < S T _ F A C _ S Y S _ A C ,   v a r c h a r ( 2 0 ) , > )  
  
 	 	 F R O M   d b o . F R S _ F A C   F R S  
 	 	 W H E R E   F R S . S T _ F A C _ I N D   N O T   I N  
 	 	 (  
 	 	 S E L E C T   C A S T ( F A C I D   A S   V A R C H A R )   F R O M   d b o . N E _ F a c i l i t y  
 	 	 )  
  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
 * /  
         - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
         - -   D E L E T E   F A C I L I T I E S :     A s s o c i a t e d   r e c o r d s   t o   f a c i l i t y   a r e   c a s c a d e   d e l e t e d     - -  
         - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 D E L E T E   F R O M   F R S _ F A C  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   F R S _ F A C  
 S E L E C T  
  
 	 C A S E   W H E N   L E N ( S T _ F A C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ F A C _ I N D   E N D   A S   S T _ F A C _ I N D  
 , 	 C A S E   W H E N   L E N ( F A C _ R E G _ I N D )   =   0   T H E N   N U L L   E L S E   F A C _ R E G _ I N D   E N D   A S   F A C _ R E G _ I N D  
 , 	 C A S E   W H E N   L E N ( F A C _ S I T E N M )   =   0   T H E N   N U L L   E L S E   F A C _ S I T E N M   E N D   A S   F A C _ S I T E N M  
 , 	 C A S E   W H E N   L E N ( F A C _ S I T E T Y P E _ N M )   =   0   T H E N   N U L L   E L S E   F A C _ S I T E T Y P E _ N M   E N D   A S   F A C _ S I T E T Y P E _ N M  
 , 	 C A S E   W H E N   L E N ( F E D _ F A C )   =   0   T H E N   N U L L   E L S E   F E D _ F A C   E N D   A S   F E D _ F A C  
 , 	 C A S E   W H E N   L E N ( T R I B _ L A N D )   =   0   T H E N   N U L L   E L S E   T R I B _ L A N D   E N D   A S   T R I B _ L A N D  
 , 	 C A S E   W H E N   L E N ( T R I B _ L A N D _ N M )   =   0   T H E N   N U L L   E L S E   T R I B _ L A N D _ N M   E N D   A S   T R I B _ L A N D _ N M  
 , 	 C A S E   W H E N   L E N ( C O N G _ D I S T _ N U M )   =   0   T H E N   N U L L   E L S E   C O N G _ D I S T _ N U M   E N D   A S   C O N G _ D I S T _ N U M  
 , 	 C A S E   W H E N   L E N ( L E G _ D I S T _ N U M )   =   0   T H E N   N U L L   E L S E   L E G _ D I S T _ N U M   E N D   A S   L E G _ D I S T _ N U M  
 , 	 C A S E   W H E N   L E N ( H U C _ C D )   =   0   T H E N   N U L L   E L S E   H U C _ C D   E N D   A S   H U C _ C D  
 , 	 C A S E   W H E N   L E N ( L O C _ A D D )   =   0   T H E N   N U L L   E L S E   L O C _ A D D   E N D   A S   L O C _ A D D  
 , 	 C A S E   W H E N   L E N ( S U P P L E M _ L O C )   =   0   T H E N   N U L L   E L S E   S U P P L E M _ L O C   E N D   A S   S U P P L E M _ L O C  
 , 	 C A S E   W H E N   L E N ( L O C A L _ N M )   =   0   T H E N   N U L L   E L S E   L O C A L _ N M   E N D   A S   L O C A L _ N M  
 , 	 C A S E   W H E N   L E N ( C N T Y _ S T _ F I P S _ C D )   =   0   T H E N   N U L L   E L S E   C N T Y _ S T _ F I P S _ C D   E N D   A S   C N T Y _ S T _ F I P S _ C D  
 , 	 C A S E   W H E N   L E N ( C N T Y _ N M )   =   0   T H E N   N U L L   E L S E   C N T Y _ N M   E N D   A S   C N T Y _ N M  
 , 	 C A S E   W H E N   L E N ( S T _ C D )   =   0   T H E N   N U L L   E L S E   S T _ C D   E N D   A S   S T _ C D  
 , 	 C A S E   W H E N   L E N ( S T _ N M )   =   0   T H E N   N U L L   E L S E   S T _ N M   E N D   A S   S T _ N M  
 , 	 C A S E   W H E N   L E N ( C O _ N M )   =   0   T H E N   N U L L   E L S E   C O _ N M   E N D   A S   C O _ N M  
 , 	 C A S E   W H E N   ( L E N ( L O C _ Z I P _ C D )   =   0   O R   L O C _ Z I P _ C D   =   ' ' - ' ' )   T H E N   N U L L   E L S E   L O C _ Z I P _ C D   E N D   A S   L O C _ Z I P _ C D  
 , 	 C A S E   W H E N   L E N ( L O C _ D E S C )   =   0   T H E N   N U L L   E L S E   L O C _ D E S C   E N D   A S   L O C _ D E S C  
 , 	 C A S E   W H E N   L E N ( D A T A _ S R C _ N M )   =   0   T H E N   N U L L   E L S E   D A T A _ S R C _ N M   E N D   A S   D A T A _ S R C _ N M  
 , 	 C A S E   W H E N   L E N ( R E P O R T E D _ D A T E )   =   0   T H E N   N U L L   E L S E   R E P O R T E D _ D A T E   E N D   A S   R E P O R T E D _ D A T E  
 , 	 C A S E   W H E N   L E N ( S T _ F A C _ S Y S _ A C )   =   0   T H E N   N U L L   E L S E   S T _ F A C _ S Y S _ A C   E N D   A S   S T _ F A C _ S Y S _ A C  
  
 F R O M  
 	 (  
 	 S E L E C T   D I S T I N C T   N E _ F a c i l i t y . F A C I D   A S   S T _ F A C _ I N D  
   	 	   ,   N U L L   A S   F A C _ R E G _ I N D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y . F A C N A M ) )   A S   F A C _ S I T E N M  
 	 	   ,   N U L L   A S   F A C _ S I T E T Y P E _ N M  
 	 	   ,   N U L L   A S   F E D _ F A C  
 	 	   ,   N U L L   A S   T R I B _ L A N D  
 	 	   ,   N U L L   A S   T R I B _ L A N D _ N M  
 - - 	 T K C 	 7 / 9 	 a d d   a   l e a d i n g   z e r o   t o   t h e   c o n g r e s s i o n a l   a n d   l e g i s l a t i v e   d i s t r i c t   c o d e s   i f  
 - - 	 	 	 l e n g t h   i s   l e s s   t h a n   2  
 	 	   ,   d b o . u d f s _ P a d L e a d i n g Z e r o e s ( N E _ F a c i l i t y . C D I S T ,   2 )   A S   C O N G _ D I S T _ N U M  
 	 	   ,   d b o . u d f s _ P a d L e a d i n g Z e r o e s ( N E _ F a c i l i t y . L D I S T ,   2 )   A S   L E G _ D I S T _ N U M  
 	 	   ,   N U L L   A S   H U C _ C D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y . S T R E E T ) )   A S   L O C _ A D D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y . O P T A D R ) )   A S   S U P P L E M _ L O C  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y . C I T Y ) )   A S   L O C A L _ N M  
 	 	   ,   d b o . u d f s _ P a d L e a d i n g Z e r o e s ( N E _ F a c i l i t y . C N Y F I P ,   5 )   A S   C N T Y _ S T _ F I P S _ C D  
 	 	   ,   C A S E   W H E N   I S N U L L ( N E _ F a c i l i t y . C O U N T Y ,   ' ' ' ' )   =   ' ' ' '   T H E N   N U L L   E L S E   L T R I M ( R T R I M ( N E _ F a c i l i t y . C O U N T Y ) )   E N D   A S   C N T Y _ N M  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y . S T A T E ) )   A S   S T _ C D  
 	 	   ,   ( S E L E C T   S T A T E _ N A M E    
 	 	     	     F R O M   L o o k u p _ U S P S _ S t a t e s    
 	 	 	   W H E R E   L o o k u p _ U S P S _ S t a t e s . S t a t e _ C o d e   =   N E _ F a c i l i t y . S T A T E )   A S   S T _ N M  
 	 	   ,   ' ' U n i t e d   S t a t e s ' '   A S   C O _ N M  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y . Z I P C O D ) )   +   C A S E   W H E N   L E N ( I S N U L L ( N E _ F a c i l i t y . Z I P P L S , ' ' ' ' ) )   >   0   T H E N   ' ' - ' '   +   L T R I M ( R T R I M ( N E _ F a c i l i t y . Z I P P L S ) )   E L S E   ' ' ' '   E N D   A S   L O C _ Z I P _ C D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y . L O C D S C ) )   A S   L O C _ D E S C  
 	 	   ,   ' ' N E - I I S ' '   A S   D A T A _ S R C _ N M  
                   ,   d b o . u d f s _ D a t e O r T i m e X M L ( N E _ F a c i l i t y _ C h a n g e D a t e . C D A T E ,   0 )   A S   R E P O R T E D _ D A T E  
 	 	   ,   ' ' N E - I I S ' '   A S   S T _ F A C _ S Y S _ A C  
 	     F R O M   N E _ F a c i l i t y   I N N E R   J O I N   N E _ F a c i l i t y _ E I  
 	 	 	 	 	 	 	 	 	 O N   (       N E _ F a c i l i t y . f a c i d   =   N E _ F a c i l i t y _ E I . f a c i d   )  
 	                                       L E F T   J O I N   N E _ F a c i l i t y _ C h a n g e D a t e  
 	 	 	 	 	 	 	 	 	 O N   (       N E _ F a c i l i t y . f a c i d   =   N E _ F a c i l i t y _ C h a n g e D a t e . f a c i d   )  
 	 	 W H E R E   N E _ F a c i l i t y _ E I . P R G A C R   I N  
 	 	 	 (  
 	 	 	 S E L E C T   P R G A C R   F R O M   L o o k u p _ P R G A C R  
 	 	 	 W H E R E   A C T I V E   =   1  
 	 	 	 )  
 	 )   A S   G 1  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ E I     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
  
 - -   T K C   9 / 2 6 / 2 0 0 7 	 C h a n g e   t h e   m a p p i n g   t o   E I   a c r o n y m   t o   b e   t h e   p r o g r a m   a c r o n y m   r a t h e r   t h a n   ' ' N E - I I S ' '  
 	 I N S E R T   I N T O   F R S _ E I  
 S E L E C T  
 	 C A S E   W H E N   L E N ( S T _ E I _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ E I _ I N D   E N D   A S   S T _ E I _ I N D  
 , 	 C A S E   W H E N   L E N ( S T _ F A C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ F A C _ I N D   E N D   A S   S T _ F A C _ I N D  
 , 	 C A S E   W H E N   L E N ( I N F _ S Y S _ A C )   =   0   T H E N   N U L L   E L S E   I N F _ S Y S _ A C   E N D   A S   I N F _ S Y S _ A C  
 , 	 C A S E   W H E N   ( L E N ( I N F _ S Y S _ I N D )   =   0   O R   I S N U L L ( I N F _ S Y S _ I N D , ' ' - ' ' )   =   ' ' - ' ' )   T H E N   N U L L   E L S E   I N F _ S Y S _ I N D   E N D   A S   I N F _ S Y S _ I N D  
 , 	 C A S E   W H E N   L E N ( E N V _ I N T _ T Y P E )   =   0   T H E N   N U L L   E L S E   E N V _ I N T _ T Y P E   E N D   A S   E N V _ I N T _ T Y P E  
 , 	 C A S E   W H E N   L E N ( F E D _ S T _ I N T )   =   0   T H E N   N U L L   E L S E   F E D _ S T _ I N T   E N D   A S   F E D _ S T _ I N T  
 , 	 C A S E   W H E N   L E N ( E N V _ I N T _ S T A R T _ D A T E )   =   0   T H E N   N U L L   E L S E   E N V _ I N T _ S T A R T _ D A T E   E N D   A S   E N V _ I N T _ S T A R T _ D A T E  
 , 	 C A S E   W H E N   L E N ( I N T _ S T A R T _ D A T E _ Q U A L )   =   0   T H E N   N U L L   E L S E   I N T _ S T A R T _ D A T E _ Q U A L   E N D   A S   I N T _ S T A R T _ D A T E _ Q U A L  
 , 	 C A S E   W H E N   L E N ( E N V _ I N T _ E N D _ D A T E )   =   0   T H E N   N U L L   E L S E   E N V _ I N T _ E N D _ D A T E   E N D   A S   E N V _ I N T _ E N D _ D A T E  
 , 	 C A S E   W H E N   L E N ( I N T _ E N D _ D A T E _ Q U A L )   =   0   T H E N   N U L L   E L S E   I N T _ E N D _ D A T E _ Q U A L   E N D   A S   I N T _ E N D _ D A T E _ Q U A L  
  
 F R O M  
 	 (  
 	 S E L E C T   D I S T I N C T  
                       n e w i d ( )           	 A S   S T _ E I _ I N D  
 	 	   ,     N E _ F a c i l i t y _ E I . F A C I D   A S   S T _ F A C _ I N D  
 - - 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ E I . P R G A C R ) )             	 A S   I N F _ S Y S _ A C  
 	 	   ,   ' ' N E - I I S ' ' 	 	 	 	 	 	 	 	 	 	 A S   I N F _ S Y S _ A C  
 	 	   ,   L T R I M ( R T R I M ( P R G I D 1 ) ) + ' ' - ' ' + L T R I M ( R T R I M ( P R G I D 2 ) ) 	 	 	 	 	 	 	 A S   I N F _ S Y S _ I N D  
 - - 	 	   ,   N U L L 	 	 	 	 	 	 	 	 	 	 	 A S   E N V _ I N T _ T Y P E  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ E I . P R G A C R ) ) 	 	 	 	 	 	 A S   E N V _ I N T _ T Y P E  
 	 	   ,   ' ' S ' ' 	 	 	 	 	 	 	 	 	 	 	 A S   F E D _ S T _ I N T  
                   ,   d b o . u d f s _ D a t e O r T i m e X M L ( N E _ F a c i l i t y _ E I . A D A T E ,   0 )   A S   E N V _ I N T _ S T A R T _ D A T E  
 	 	   ,   ' ' E I   S t a r t   D a t e ' ' 	 	 	 	 	 	 	 	 A S   I N T _ S T A R T _ D A T E _ Q U A L  
                   ,   C A S E  
 	 	 	 	 W H E N   D A T E D I F F ( D D ,   N E _ F a c i l i t y _ E I . I D A T E ,   ' ' 1 8 9 9 - 0 1 - 0 1 ' ' )   =   0   T H E N   N U L L  
 	 	 	 	 E L S E   d b o . u d f s _ D a t e O r T i m e X M L ( N E _ F a c i l i t y _ E I . I D A T E ,   0 )  
 	 	 	 E N D                                                                                   A S   E N V _ I N T _ E N D _ D A T E  
 	 	   ,   ' ' E I   E n d   D a t e ' ' 	 	 	 	 	 	 	 	 A S   I N T _ E N D _ D A T E _ Q U A L  
 	     F R O M   N E _ F a c i l i t y   I N N E R   J O I N   N E _ F a c i l i t y _ E I    
 	 	 	 	 	 	 	       O N   ( N E _ F a c i l i t y . F A C I D   =   N E _ F a c i l i t y _ E I . F A C I D )  
 	 	 	 	 	 	 	 I N N E R   J O I N   F R S _ F A C  
 	 	 	 	 	 	 	       O N   ( F R S _ F A C . S T _ F A C _ I N D   =   N E _ F a c i l i t y . f a c i d   )  
 	 	 W H E R E   N E _ F a c i l i t y _ E I . P R G A C R   I N  
 	 	 	 (  
 	 	 	 S E L E C T   P R G A C R   F R O M   L o o k u p _ P R G A C R  
 	 	 	 W H E R E   A C T I V E   =   1  
 	 	 	 )  
 	 )   A S   G 1  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ A D D     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
  
 	 I N S E R T   I N T O   F R S _ A D D  
 S E L E C T  
 	 C A S E   W H E N   L E N ( S T _ F A C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ F A C _ I N D   E N D   A S   S T _ F A C _ I N D  
 , 	 C A S E   W H E N   L E N ( A F F I L _ T Y P E )   =   0   T H E N   N U L L   E L S E   A F F I L _ T Y P E   E N D   A S   A F F I L _ T Y P E  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D   E N D   A S   M A I L _ A D D  
 , 	 C A S E   W H E N   L E N ( S U P P L E M _ A D D )   =   0   T H E N   N U L L   E L S E   S U P P L E M _ A D D   E N D   A S   S U P P L E M _ A D D  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ C I T Y _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ C I T Y _ N M   E N D   A S   M A I L _ A D D _ C I T Y _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ S T _ C D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ S T _ C D   E N D   A S   M A I L _ A D D _ S T _ C D  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ S T _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ S T _ N M   E N D   A S   M A I L _ A D D _ S T _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ C O _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ C O _ N M   E N D   A S   M A I L _ A D D _ C O _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ Z I P _ C D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ Z I P _ C D   E N D   A S   M A I L _ A D D _ Z I P _ C D  
  
 F R O M  
 	 (  
 	 S E L E C T   F A C I D   A S   S T _ F A C _ I N D  
 	 ,   N U L L   A S   A F F I L _ T Y P E  
 	 ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ M a i l i n g . M A I L ) )   A S   M A I L _ A D D  
 	 ,   C A S E   W H E N   N E _ F a c i l i t y _ M a i l i n g . S U I T E   < >   ' ' ' '  
 	 	 T H E N   ' ' S u i t e :   ' '   +   L T R I M ( R T R I M ( S U I T E ) )  
 	     E N D   A S   S U P P L E M _ A D D  
 	 ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ M a i l i n g . C I T Y ) )   A S   M A I L _ A D D _ C I T Y _ N M  
 	 ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ M a i l i n g . S T A T E ) )   A S   M A I L _ A D D _ S T _ C D  
 	 ,   ( S E L E C T   S T A T E _ N A M E    
                   F R O M   L o o k u p _ U S P S _ S t a t e s    
                 W H E R E   L o o k u p _ U S P S _ S t a t e s . S t a t e _ C o d e   =   N E _ F a c i l i t y _ M a i l i n g . S T A T E )   A S   M A I L _ A D D _ S T _ N M  
 	 ,   ' ' U n i t e d   S t a t e s ' '   A S   M A I L _ A D D _ C O _ N M  
 	 ,   C A S E   W H E N   N E _ F a c i l i t y _ M a i l i n g . Z I P P L S   =   ' ' ' '  
 	 	 T H E N   L T R I M ( R T R I M ( N E _ F a c i l i t y _ M a i l i n g . Z I P C O D ) )  
 	 	 E L S E   L T R I M ( R T R I M ( N E _ F a c i l i t y _ M a i l i n g . Z I P C O D ) ) + ' ' - ' '   + L T R I M ( R T R I M ( N E _ F a c i l i t y _ M a i l i n g . Z I P P L S ) )  
 	     E N D   A S   M A I L _ A D D _ Z I P _ C D  
 	 f r o m   N E _ F a c i l i t y _ M a i l i n g   I N N E R   J O I N   F R S _ F A C  
 	 	 	 	 	 	 	 	 O N   ( F R S _ F A C . S T _ F A C _ I N D   =   N E _ F a c i l i t y _ M a i l i n g . f a c i d   )  
         )   G 1  
  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
 	  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ A L T _ N M     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   F R S _ A L T _ N M  
  
 S E L E C T  
 	 C A S E   W H E N   L E N ( S T _ F A C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ F A C _ I N D   E N D   A S   S T _ F A C _ I N D  
 , 	 C A S E   W H E N   L E N ( A L T _ N M )   =   0   T H E N   N U L L   E L S E   A L T _ N M   E N D   A S   A L T _ N M  
 , 	 C A S E   W H E N   L E N ( A L T _ N A M E _ T Y P E )   =   0   T H E N   N U L L   E L S E   A L T _ N A M E _ T Y P E   E N D   A S   A L T _ N A M E _ T Y P E  
  
 F R O M  
 	 (  
 	 S E L E C T   D I S T I N C T   F A C I D   A S   S T _ F A C _ I N D  
 	 	   ,   L T R I M ( R T R I M ( M A X ( F A C N A M ) ) )   A S   A L T _ N M  
 	 	   ,   L T R I M ( R T R I M ( A L T _ N A M E _ T Y P E ) )   A S   A L T _ N A M E _ T Y P E  
 	     F R O M   ( S E L E C T 	 A L T . F A C I D   A S   F A C I D  
 	   	                   ,   S U B S T R I N G ( A L T . F A C N A M , 1 , 8 0 )   A S   F A C N A M  
 	 	 	 	   ,   N U L L   A S   A L T _ N A M E _ T Y P E   - -   < A L T _ N A M E _ T Y P E ,   v a r c h a r ( 2 5 ) , > )    
 	 	 	 	   ,   F A C . *  
 	 	 	     F R O M   d b o . F R S _ F A C   F A C   I N N E R   J O I N   d b o . N E _ F a c i l i t y _ A l t N a m e   A L T  
 	 	 	 	 	 	 	 	 	     O N   (         F A C . S T _ F A C _ I N D   =   A L T . F A C I D   ) )   G 1  
 G R O U P   B Y   F A C I D  
 / *  
   	 	 	 	 	 	 	 	 	 	     A N D   A L T . F A C N A M   =   ( S E L E C T   T O P   1   A 2 . F A C N A M  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	     F R O M   d b o . N E _ F a c i l i t y _ A l t N a m e   A 2  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	   W H E R E   A 2 . F A C I D   =   A L T . F A C I D  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	   O R D E R   B Y   A 2 . C D A T E   D E S C ) )   G 1  
 * /  
 	 )   G 1  
 W H E R E   L E N ( I S N U L L ( G 1 . A L T _ N M , ' ' ' ' ) )   >   0  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ G E O     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   F R S _ G E O  
  
 S E L E C T  
 	 C A S E   W H E N   L E N ( S T _ F A C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ F A C _ I N D   E N D   A S   S T _ F A C _ I N D  
 , 	 C A S E   W H E N   L E N ( L A T _ M E A S U R E )   =   0   T H E N   N U L L   E L S E   L A T _ M E A S U R E   E N D   A S   L A T _ M E A S U R E  
 , 	 C A S E   W H E N   L E N ( L O N _ M E A S U R E )   =   0   T H E N   N U L L   E L S E   L O N _ M E A S U R E   E N D   A S   L O N _ M E A S U R E  
 , 	 C A S E   W H E N   L E N ( H O R I Z _ A C C U R _ M E A S U R E )   =   0   T H E N   N U L L   E L S E   H O R I Z _ A C C U R _ M E A S U R E   E N D   A S   H O R I Z _ A C C U R _ M E A S U R E  
 , 	 C A S E   W H E N   L E N ( H O R I Z _ C O L L _ M E T H )   =   0   T H E N   N U L L   E L S E   H O R I Z _ C O L L _ M E T H   E N D   A S   H O R I Z _ C O L L _ M E T H  
 , 	 C A S E   W H E N   L E N ( H O R I Z _ R E F _ D A T U M _ N M )   =   0   T H E N   N U L L   E L S E   H O R I Z _ R E F _ D A T U M _ N M   E N D   A S   H O R I Z _ R E F _ D A T U M _ N M  
 , 	 C A S E   W H E N   L E N ( S R C _ M A P _ S C A L E _ N U M )   =   0   T H E N   N U L L   E L S E   S R C _ M A P _ S C A L E _ N U M   E N D   A S   S R C _ M A P _ S C A L E _ N U M  
 , 	 C A S E   W H E N   L E N ( R E F _ P O I N T )   =   0   T H E N   N U L L   E L S E   R E F _ P O I N T   E N D   A S   R E F _ P O I N T  
 , 	 C A S E   W H E N   L E N ( D A T A _ C O L L _ D A T E )   =   0   T H E N   N U L L   E L S E   D A T A _ C O L L _ D A T E   E N D   A S   D A T A _ C O L L _ D A T E  
 , 	 C A S E   W H E N   L E N ( G E O _ T Y P E _ N M )   =   0   T H E N   N U L L   E L S E   G E O _ T Y P E _ N M   E N D   A S   G E O _ T Y P E _ N M  
 , 	 C A S E   W H E N   L E N ( L O C _ C O M M E N T S )   =   0   T H E N   N U L L   E L S E   L O C _ C O M M E N T S   E N D   A S   L O C _ C O M M E N T S  
 , 	 C A S E   W H E N   L E N ( V E R T _ C O L L _ M E T H )   =   0   T H E N   N U L L   E L S E   V E R T _ C O L L _ M E T H   E N D   A S   V E R T _ C O L L _ M E T H  
 , 	 C A S E   W H E N   L E N ( V E R T _ M E A S U R E )   =   0   T H E N   N U L L   E L S E   V E R T _ M E A S U R E   E N D   A S   V E R T _ M E A S U R E  
 , 	 C A S E   W H E N   L E N ( V E R T _ A C C U R _ M E A S U R E )   =   0   T H E N   N U L L   E L S E   V E R T _ A C C U R _ M E A S U R E   E N D   A S   V E R T _ A C C U R _ M E A S U R E  
 , 	 C A S E   W H E N   L E N ( V E R T _ R E F _ D A T U M _ N M )   =   0   T H E N   N U L L   E L S E   V E R T _ R E F _ D A T U M _ N M   E N D   A S   V E R T _ R E F _ D A T U M _ N M  
 , 	 C A S E   W H E N   L E N ( D A T A _ S R C _ N M )   =   0   T H E N   N U L L   E L S E   D A T A _ S R C _ N M   E N D   A S   D A T A _ S R C _ N M  
 , 	 C A S E   W H E N   L E N ( C O O R D _ D A T A _ S R C _ N M )   =   0   T H E N   N U L L   E L S E   C O O R D _ D A T A _ S R C _ N M   E N D   A S   C O O R D _ D A T A _ S R C _ N M  
 , 	 C A S E   W H E N   L E N ( S U B _ E N T _ I N D )   =   0   T H E N   N U L L   E L S E   S U B _ E N T _ I N D   E N D   A S   S U B _ E N T _ I N D  
 , 	 C A S E   W H E N   L E N ( S U B _ E N T _ T Y P E _ N M )   =   0   T H E N   N U L L   E L S E   S U B _ E N T _ T Y P E _ N M   E N D   A S   S U B _ E N T _ T Y P E _ N M  
  
 F R O M  
 	 (  
 	 S E L E C T   N E _ F a c i l i t y _ C o o r d . F A C I D   A S   S T _ F A C _ I N D  
 	 	   ,   N E _ F a c i l i t y _ C o o r d . L A T   A S   L A T _ M E A S U R E  
 	 	   ,   N E _ F a c i l i t y _ C o o r d . L O N   A S   L O N _ M E A S U R E  
 	 	   ,   N U L L   A S   H O R I Z _ A C C U R _ M E A S U R E  
 	 	   ,   C A S E   W H E N   U P P E R ( N E _ F a c i l i t y _ C o o r d . L L S R C )   l i k e   ' ' G P S % ' '    
 	 	 	   T H E N   ' ' G P S   -   U N S P E C I F I E D ' '    
 	 	 	   E L S E   C A S E   W H E N   U P P E R ( N E _ F a c i l i t y _ C o o r d . L L S R C )   =   ' ' L E G A L ' '    
 	 	 	   T H E N   ' ' U N K N O W N ' '    
 	 	 	   E L S E   C A S E   W H E N   U P P E R ( N E _ F a c i l i t y _ C o o r d . L L S R C )   l i k e   ' ' D I G % ' '    
 	 	 	   T H E N   ' ' I N T E R P O L A T I O N - O T H E R ' '    
 	 	 	   E L S E   C A S E   W H E N   U P P E R ( N E _ F a c i l i t y _ C o o r d . L L S R C )   l i k e   ' ' A D D M A T % ' '    
 	 	 	   T H E N   ' ' A D D R E S S   M A T C H I N G - O T H E R ' '    
 	 	 	   E L S E   ' ' U N K N O W N ' '    
 	 	       E N D    
 	 	       E N D    
 	 	       E N D    
 	 	       E N D   A S   H O R I Z _ C O L L _ M E T H  
 	 	   ,   C A S E   W H E N   ( I S N U L L ( N E _ F a c i l i t y _ C o o r d . H R E F D T M , ' ' ' ' )   =   ' ' ' '   O R   I S N U L L ( N E _ F a c i l i t y _ C o o r d . R D A T U M , ' ' ' ' )   =   ' ' ' ' )   T H E N   N U L L  
 	 	 	 	 E L S E   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o o r d . H R E F D T M ) )   +   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o o r d . R D A T U M ) )  
 	 	 	 E N D   A S   H O R I Z _ R E F _ D A T U M _ N M  
 	 	   ,   N U L L   A S   S R C _ M A P _ S C A L E _ N U M  
 	 	   ,   N U L L   A S   R E F _ P O I N T  
                   ,   d b o . u d f s _ D a t e O r T i m e X M L ( N E _ F a c i l i t y _ C o o r d . C D A T E ,   0 )   A S   D A T A _ C O L L _ D A T E  
 - -                   ,   R E P L A C E ( C O N V E R T ( V A R C H A R ,   N E _ F a c i l i t y _ C o o r d . C D A T E ,   1 0 1 ) , ' ' / ' ' , ' ' ' ' )   A S   D A T A _ C O L L _ D A T E  
 	 	   ,   N U L L   A S   G E O _ T Y P E _ N M  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o o r d . L L D E S C ) )   A S   L O C _ C O M M E N T S  
 	 	   ,   N U L L   A S   V E R T _ C O L L _ M E T H  
 	 	   ,   N U L L   A S   V E R T _ M E A S U R E  
 	 	   ,   N U L L   A S   V E R T _ A C C U R _ M E A S U R E  
 	 	   ,   N U L L   A S   V E R T _ R E F _ D A T U M _ N M  
 	 	   ,   N U L L   A S   D A T A _ S R C _ N M  
 	 	   ,   N U L L   A S   C O O R D _ D A T A _ S R C _ N M  
 	 	   ,   N U L L   A S   S U B _ E N T _ I N D  
 	 	   ,   N U L L   A S   S U B _ E N T _ T Y P E _ N M  
 	     F R O M   N E _ F a c i l i t y _ C o o r d   I N N E R   J O I N   F R S _ F A C  
 	 	 	 	 	 	 	 	 O N   ( F R S _ F A C . S T _ F A C _ I N D   =   N E _ F a c i l i t y _ C o o r d . F A C I D   )  
 	 )   A S   G 1  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C _ I N D     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 - -   T K C   9 / 2 6 / 2 0 0 7 	 O n l y   a d d   c o n t a c t s   a t   t h i s   l e v e l   w h e r e   P R G A C R   =   ' ' D E Q ' '  
 	 I N S E R T   I N T O   F R S _ F A C _ I N D  
  
 S E L E C T  
  
 	 C A S E   W H E N   L E N ( S T _ R E C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ R E C _ I N D   E N D   A S   S T _ R E C _ I N D  
 , 	 C A S E   W H E N   L E N ( S T _ F A C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ F A C _ I N D   E N D   A S   S T _ F A C _ I N D  
 , 	 C A S E   W H E N   L E N ( A F F I L _ T Y P E )   =   0   T H E N   N U L L   E L S E   A F F I L _ T Y P E   E N D   A S   A F F I L _ T Y P E  
 , 	 C A S E   W H E N   L E N ( A F F I L _ S T A R T _ D A T E )   =   0   T H E N   N U L L   E L S E   A F F I L _ S T A R T _ D A T E   E N D   A S   A F F I L _ S T A R T _ D A T E  
 , 	 C A S E   W H E N   L E N ( A F F I L _ E N D _ D A T E )   =   0   T H E N   N U L L   E L S E   A F F I L _ E N D _ D A T E   E N D   A S   A F F I L _ E N D _ D A T E  
 , 	 C A S E   W H E N   L E N ( E M A I L _ A D D )   =   0   T H E N   N U L L   E L S E   E M A I L _ A D D   E N D   A S   E M A I L _ A D D  
 , 	 C A S E   W H E N   L E N ( T E L _ N U M )   =   0   T H E N   N U L L   E L S E   T E L _ N U M   E N D   A S   T E L _ N U M  
 , 	 C A S E   W H E N   L E N ( P H _ E X T )   =   0   T H E N   N U L L   E L S E   P H _ E X T   E N D   A S   P H _ E X T  
 , 	 C A S E   W H E N   L E N ( F A X _ N U M )   =   0   T H E N   N U L L   E L S E   F A X _ N U M   E N D   A S   F A X _ N U M  
 , 	 C A S E   W H E N   L E N ( A L T _ T E L _ N U M )   =   0   T H E N   N U L L   E L S E   A L T _ T E L _ N U M   E N D   A S   A L T _ T E L _ N U M  
 , 	 C A S E   W H E N   L E N ( I N D _ F U L L _ N M )   =   0   T H E N   N U L L   E L S E   I N D _ F U L L _ N M   E N D   A S   I N D _ F U L L _ N M  
 , 	 C A S E   W H E N   L E N ( I N D _ T I T L E )   =   0   T H E N   N U L L   E L S E   I N D _ T I T L E   E N D   A S   I N D _ T I T L E  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D   E N D   A S   M A I L _ A D D  
 , 	 C A S E   W H E N   L E N ( S U P P L E M _ A D D )   =   0   T H E N   N U L L   E L S E   S U P P L E M _ A D D   E N D   A S   S U P P L E M _ A D D  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ C I T Y _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ C I T Y _ N M   E N D   A S   M A I L _ A D D _ C I T Y _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ S T _ C D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ S T _ C D   E N D   A S   M A I L _ A D D _ S T _ C D  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ S T _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ S T _ N M   E N D   A S   M A I L _ A D D _ S T _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ C O _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ C O _ N M   E N D   A S   M A I L _ A D D _ C O _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ Z I P _ C D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ Z I P _ C D   E N D   A S   M A I L _ A D D _ Z I P _ C D  
  
 F R O M  
 	 (  
 	 S E L E C T   n e w i d ( )     A S   S T _ R E C _ I N D  
 	     	   ,   N E _ F a c i l i t y _ C o n t a c t s . F A C I D   A S   S T _ F A C _ I N D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . C T D S C ) )   A S   A F F I L _ T Y P E  
 	 	   ,   d b o . u d f s _ D a t e O r T i m e X M L ( N E _ F a c i l i t y _ C o n t a c t s . A D A T E ,   0 )   A S   A F F I L _ S T A R T _ D A T E  
 	 	   ,   d b o . u d f s _ D a t e O r T i m e X M L ( N E _ F a c i l i t y _ C o n t a c t s . I D A T E ,   0 )   A S   A F F I L _ E N D _ D A T E  
 	 	   ,   C A S E   W H E N   N E _ F a c i l i t y _ C o n t a c t s . E M A D R   < >   ' ' ' '   A N D   N E _ F a c i l i t y _ C o n t a c t s . E M D O M   < >   ' ' ' '  
 	   	 	   T H E N   N E _ F a c i l i t y _ C o n t a c t s . E M A D R + ' ' @ ' ' + N E _ F a c i l i t y _ C o n t a c t s . E M D O M    
 	 	       E N D   A S   E M A I L _ A D D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . P H O N E ) )   A S   T E L _ N U M  
 	 	   ,   N U L L   A S   P H _ E X T  
 	 	   ,   N U L L   A S   F A X _ N U M  
 	 	   ,   N U L L   A S   A L T _ T E L _ N U M  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . A D R S E E ) )   A S   I N D _ F U L L _ N M  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . P O S T T L ) )   A S   I N D _ T I T L E  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . M A I L ) )   A S   M A I L _ A D D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . O P T A D R ) )   A S   S U P P L E M _ A D D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . C I T Y ) )   A S   M A I L _ A D D _ C I T Y _ N M  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . S T A T E ) )   A S   M A I L _ A D D _ S T _ C D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c i l i t y _ C o n t a c t s . S T N A M ) )   A S   M A I L _ A D D _ S T _ N M  
 	 	   ,   ' ' U n i t e d   S t a t e s ' '   A S   M A I L _ A D D _ C O _ N M  
 	 	   ,   C A S E   W H E N   N E _ F a c i l i t y _ C o n t a c t s . Z I P P L S   =   ' ' ' '  
 	 	   	   T H E N   N E _ F a c i l i t y _ C o n t a c t s . Z I P C O D  
 	 	 	   E L S E   N E _ F a c i l i t y _ C o n t a c t s . Z I P C O D + ' ' - ' '   + N E _ F a c i l i t y _ C o n t a c t s . Z I P P L S      
 	 	       E N D   A S   M A I L _ A D D _ Z I P _ C D  
 	     F R O M   N E _ F a c i l i t y _ C o n t a c t s   I N N E R   J O I N   F R S _ F A C  
 	 	 	 	 	 	 	 	   O N   ( F R S _ F A C . S T _ F A C _ I N D   =   N E _ F a c i l i t y _ C o n t a c t s . f a c i d   )  
 	 W H E R E   N E _ F a c i l i t y _ C o n t a c t s . P R G A C R   =   ' ' D E Q ' '  
 	 )   A S   G 1  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ E I _ I N D     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
  
 I N S E R T   I N T O   F R S _ E I _ I N D  
  
 S E L E C T  
  
 	 C A S E   W H E N   L E N ( S T _ R E C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ R E C _ I N D   E N D   A S   S T _ R E C _ I N D  
 , 	 C A S E   W H E N   L E N ( S T _ E I _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ E I _ I N D   E N D   A S   S T _ E I _ I N D  
 , 	 C A S E   W H E N   L E N ( A F F I L _ T Y P E )   =   0   T H E N   N U L L   E L S E   A F F I L _ T Y P E   E N D   A S   A F F I L _ T Y P E  
 , 	 C A S E   W H E N   L E N ( A F F I L _ S T A R T _ D A T E )   =   0   T H E N   N U L L   E L S E   A F F I L _ S T A R T _ D A T E   E N D   A S   A F F I L _ S T A R T _ D A T E  
 , 	 C A S E   W H E N   L E N ( A F F I L _ E N D _ D A T E )   =   0   T H E N   N U L L   E L S E   A F F I L _ E N D _ D A T E   E N D   A S   A F F I L _ E N D _ D A T E  
 , 	 C A S E   W H E N   L E N ( E M A I L _ A D D )   =   0   T H E N   N U L L   E L S E   E M A I L _ A D D   E N D   A S   E M A I L _ A D D  
 , 	 C A S E   W H E N   L E N ( T E L _ N U M )   =   0   T H E N   N U L L   E L S E   T E L _ N U M   E N D   A S   T E L _ N U M  
 , 	 C A S E   W H E N   L E N ( P H _ E X T )   =   0   T H E N   N U L L   E L S E   P H _ E X T   E N D   A S   P H _ E X T  
 , 	 C A S E   W H E N   L E N ( F A X _ N U M )   =   0   T H E N   N U L L   E L S E   F A X _ N U M   E N D   A S   F A X _ N U M  
 , 	 C A S E   W H E N   L E N ( A L T _ T E L _ N U M )   =   0   T H E N   N U L L   E L S E   A L T _ T E L _ N U M   E N D   A S   A L T _ T E L _ N U M  
 , 	 C A S E   W H E N   L E N ( I N D _ F U L L _ N M )   =   0   T H E N   N U L L   E L S E   I N D _ F U L L _ N M   E N D   A S   I N D _ F U L L _ N M  
 , 	 C A S E   W H E N   L E N ( I N D _ T I T L E )   =   0   T H E N   N U L L   E L S E   I N D _ T I T L E   E N D   A S   I N D _ T I T L E  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D   E N D   A S   M A I L _ A D D  
 , 	 C A S E   W H E N   L E N ( S U P P L E M _ A D D )   =   0   T H E N   N U L L   E L S E   S U P P L E M _ A D D   E N D   A S   S U P P L E M _ A D D  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ C I T Y _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ C I T Y _ N M   E N D   A S   M A I L _ A D D _ C I T Y _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ S T _ C D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ S T _ C D   E N D   A S   M A I L _ A D D _ S T _ C D  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ S T _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ S T _ N M   E N D   A S   M A I L _ A D D _ S T _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ C O _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ C O _ N M   E N D   A S   M A I L _ A D D _ C O _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ Z I P _ C D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ Z I P _ C D   E N D   A S   M A I L _ A D D _ Z I P _ C D  
  
 F R O M  
 	 (  
 	 S E L E C T   n e w i d ( )     A S   S T _ R E C _ I N D  
 	     	   ,   E I . S T _ E I _ I N D   A S   S T _ E I _ I N D  
 	 	   ,   L T R I M ( R T R I M ( C . C T D S C ) )   A S   A F F I L _ T Y P E  
 	 	   ,   d b o . u d f s _ D a t e O r T i m e X M L ( C . A D A T E ,   0 )   A S   A F F I L _ S T A R T _ D A T E  
 	 	   ,   d b o . u d f s _ D a t e O r T i m e X M L ( C . I D A T E ,   0 )   A S   A F F I L _ E N D _ D A T E  
 	 	   ,   C A S E   W H E N   C . E M A D R   < >   ' ' ' '   A N D   C . E M D O M   < >   ' ' ' '  
 	   	 	   T H E N   C . E M A D R + ' ' @ ' ' + C . E M D O M    
 	 	       E N D   A S   E M A I L _ A D D  
 	 	   ,   L T R I M ( R T R I M ( C . P H O N E ) )   A S   T E L _ N U M  
 	 	   ,   N U L L   A S   P H _ E X T  
 	 	   ,   N U L L   A S   F A X _ N U M  
 	 	   ,   N U L L   A S   A L T _ T E L _ N U M  
 	 	   ,   L T R I M ( R T R I M ( C . A D R S E E ) )   A S   I N D _ F U L L _ N M  
 	 	   ,   L T R I M ( R T R I M ( C . P O S T T L ) )   A S   I N D _ T I T L E  
 	 	   ,   L T R I M ( R T R I M ( C . M A I L ) )   A S   M A I L _ A D D  
 	 	   ,   L T R I M ( R T R I M ( C . O P T A D R ) )   A S   S U P P L E M _ A D D  
 	 	   ,   L T R I M ( R T R I M ( C . C I T Y ) )   A S   M A I L _ A D D _ C I T Y _ N M  
 	 	   ,   L T R I M ( R T R I M ( C . S T A T E ) )   A S   M A I L _ A D D _ S T _ C D  
 	 	   ,   L T R I M ( R T R I M ( C . S T N A M ) )   A S   M A I L _ A D D _ S T _ N M  
 	 	   ,   ' ' U n i t e d   S t a t e s ' '   A S   M A I L _ A D D _ C O _ N M  
 	 	   ,   C A S E   W H E N   C . Z I P P L S   =   ' ' ' '  
 	 	   	   T H E N   C . Z I P C O D  
 	 	 	   E L S E   C . Z I P C O D + ' ' - ' '   + C . Z I P P L S      
 	 	       E N D   A S   M A I L _ A D D _ Z I P _ C D  
 	     F R O M   N E _ F a c i l i t y _ C o n t a c t s   C  
 	 	 I N N E R   J O I N   d b o . F R S _ E I   E I   O N  
 	 	 	 E I . S T _ F A C _ I N D   =   C . F A C I D   A N D  
 	 	 	 E I . E N V _ I N T _ T Y P E   =   C . P R G A C R  
  
 	 W H E R E   C . P R G A C R   < >   ' ' D E Q ' '  
  
 	 )   A S   G 1  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C _ O R G     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - -  
         I N S E R T   I N T O   F R S _ F A C _ O R G  
  
 S E L E C T  
 	 C A S E   W H E N   L E N ( S T _ R E C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ R E C _ I N D   E N D   A S   S T _ R E C _ I N D  
 , 	 C A S E   W H E N   L E N ( S T _ F A C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ F A C _ I N D   E N D   A S   S T _ F A C _ I N D  
 , 	 C A S E   W H E N   L E N ( A F F I L _ T Y P E )   =   0   T H E N   N U L L   E L S E   A F F I L _ T Y P E   E N D   A S   A F F I L _ T Y P E  
 , 	 C A S E   W H E N   L E N ( A F F I L _ S T A R T _ D A T E )   =   0   T H E N   N U L L   E L S E   A F F I L _ S T A R T _ D A T E   E N D   A S   A F F I L _ S T A R T _ D A T E  
 , 	 C A S E   W H E N   L E N ( A F F I L _ E N D _ D A T E )   =   0   T H E N   N U L L   E L S E   A F F I L _ E N D _ D A T E   E N D   A S   A F F I L _ E N D _ D A T E  
 , 	 C A S E   W H E N   L E N ( E M A I L _ A D D )   =   0   T H E N   N U L L   E L S E   E M A I L _ A D D   E N D   A S   E M A I L _ A D D  
 , 	 C A S E   W H E N   L E N ( T E L _ N U M )   =   0   T H E N   N U L L   E L S E   T E L _ N U M   E N D   A S   T E L _ N U M  
 , 	 C A S E   W H E N   L E N ( P H _ E X T )   =   0   T H E N   N U L L   E L S E   P H _ E X T   E N D   A S   P H _ E X T  
 , 	 C A S E   W H E N   L E N ( F A X _ N U M )   =   0   T H E N   N U L L   E L S E   F A X _ N U M   E N D   A S   F A X _ N U M  
 , 	 C A S E   W H E N   L E N ( A L T _ T E L _ N U M )   =   0   T H E N   N U L L   E L S E   A L T _ T E L _ N U M   E N D   A S   A L T _ T E L _ N U M  
 , 	 C A S E   W H E N   L E N ( O R G _ F O R M A L _ N M )   =   0   T H E N   N U L L   E L S E   O R G _ F O R M A L _ N M   E N D   A S   O R G _ F O R M A L _ N M  
 , 	 C A S E   W H E N   L E N ( O R G _ D U N S _ N U M )   =   0   T H E N   N U L L   E L S E   O R G _ D U N S _ N U M   E N D   A S   O R G _ D U N S _ N U M  
 , 	 C A S E   W H E N   L E N ( O R G _ T Y P E )   =   0   T H E N   N U L L   E L S E   O R G _ T Y P E   E N D   A S   O R G _ T Y P E  
 , 	 C A S E   W H E N   L E N ( E M P L O Y E R _ I N D )   =   0   T H E N   N U L L   E L S E   E M P L O Y E R _ I N D   E N D   A S   E M P L O Y E R _ I N D  
 , 	 C A S E   W H E N   L E N ( S T _ B U S I N E S S _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ B U S I N E S S _ I N D   E N D   A S   S T _ B U S I N E S S _ I N D  
 , 	 C A S E   W H E N   L E N ( U L T _ P A R E N T _ N M )   =   0   T H E N   N U L L   E L S E   U L T _ P A R E N T _ N M   E N D   A S   U L T _ P A R E N T _ N M  
 , 	 C A S E   W H E N   L E N ( U L T _ P A R E N T _ D U N S _ N U M )   =   0   T H E N   N U L L   E L S E   U L T _ P A R E N T _ D U N S _ N U M   E N D   A S   U L T _ P A R E N T _ D U N S _ N U M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D   E N D   A S   M A I L _ A D D  
 , 	 C A S E   W H E N   L E N ( S U P P L E M _ A D D )   =   0   T H E N   N U L L   E L S E   S U P P L E M _ A D D   E N D   A S   S U P P L E M _ A D D  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ C I T Y _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ C I T Y _ N M   E N D   A S   M A I L _ A D D _ C I T Y _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ S T _ C D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ S T _ C D   E N D   A S   M A I L _ A D D _ S T _ C D  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ S T _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ S T _ N M   E N D   A S   M A I L _ A D D _ S T _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ C O _ N M )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ C O _ N M   E N D   A S   M A I L _ A D D _ C O _ N M  
 , 	 C A S E   W H E N   L E N ( M A I L _ A D D _ Z I P _ C D )   =   0   T H E N   N U L L   E L S E   M A I L _ A D D _ Z I P _ C D   E N D   A S   M A I L _ A D D _ Z I P _ C D  
  
 F R O M  
 	 (  
 	 S E L E C T   n e w i d ( )     A S   S T _ R E C _ I N D  
 	 	   ,   N E _ F a c _ R e s p o n s i b l e P a r t y . F A C I D   A S   S T _ F A C _ I N D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . R P D S C ) )   A S   A F F I L _ T Y P E  
 	 	   ,   d b o . u d f s _ D a t e O r T i m e X M L ( N E _ F a c _ R e s p o n s i b l e P a r t y . A D A T E ,   0 )   A S   A F F I L _ S T A R T _ D A T E  
 	 	   ,   d b o . u d f s _ D a t e O r T i m e X M L ( N E _ F a c _ R e s p o n s i b l e P a r t y . I D A T E ,   0 )   A S   A F F I L _ E N D _ D A T E  
 	 	   ,   N U L L   A S   E M A I L _ A D D  
 	 	   ,   N U L L   A S   T E L _ N U M  
 	 	   ,   N U L L   A S   P H _ E X T  
 	 	   ,   N U L L   A S   F A X _ N U M  
 	 	   ,   N U L L   A S   A L T _ T E L _ N U M  
                   ,   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . R P N A M E ) )   A S   O R G _ F O R M A L _ N M  
 	 	   ,   N U L L   A S   O R G _ D U N S _ N U M  
 	 	   ,   L T R I M ( R T R I M ( S U B S T R I N G ( N E _ F a c _ R e s p o n s i b l e P a r t y . F O E D S C , 1 , 1 0 ) ) )   A S   O R G _ T Y P E  
 	 	   ,   N U L L   A S   E M P L O Y E R _ I N D  
 	 	   ,   N U L L   A S   S T _ B U S I N E S S _ I N D  
 	 	   ,   N U L L   A S   U L T _ P A R E N T _ N M  
 	 	   ,   N U L L   A S   U L T _ P A R E N T _ D U N S _ N U M  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . M A I L ) )   A S   M A I L _ A D D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . O P T A D R ) )   A S   S U P P L E M _ A D D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . C I T Y ) )   A S   M A I L _ A D D _ C I T Y _ N M  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . S T A T E ) )   A S   M A I L _ A D D _ S T _ C D  
 	 	   ,   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . S T N A M ) )   A S   M A I L _ A D D _ S T _ N M  
 	 	   ,   ' ' U n i t e d   S t a t e s ' '   A S   M A I L _ A D D _ C O _ N M  
 	 	   ,   C A S E   W H E N   N E _ F a c _ R e s p o n s i b l e P a r t y . Z I P P L S   =   ' ' ' '  
 	 	 	   T H E N   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . Z I P C O D ) )  
 	 	 	   E L S E   L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . Z I P C O D ) ) + ' ' - ' '   + L T R I M ( R T R I M ( N E _ F a c _ R e s p o n s i b l e P a r t y . Z I P P L S ) )  
 	 	       E N D   A S   M A I L _ A D D _ Z I P _ C D  
 	     F R O M   N E _ F a c _ R e s p o n s i b l e P a r t y   I N N E R   J O I N   F R S _ F A C  
 	 	 	 	 	 	 	 	             O N   ( F R S _ F A C . S T _ F A C _ I N D   =   N E _ F a c _ R e s p o n s i b l e P a r t y . f a c i d   )  
 	 )   A S   G 1  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ E I _ S I C     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - -  
  
 	 I N S E R T   I N T O   F R S _ E I _ S I C  
 	 S E L E C T   N E W I D ( )   A S   S T _ R E C _ I N D  
 	 	   ,   E . S T _ E I _ I N D   A S   S T _ E I _ I N D  
 	 	   ,   d b o . u d f s _ P a d L e a d i n g Z e r o e s ( S . S I C C O D ,   4 )   A S   S I C _ C D  
 	 	   ,   C A S E   W H E N   S . S I C P R I   =   1    
                           T H E N   ' ' P R I M A R Y ' '  
                                 W H E N   S . S I C P R I   =   2    
                           T H E N   ' ' S E C O N D A R Y ' '  
                           E L S E   ' ' U N K N O W N ' '  
                       E N D   A S   S I C _ P R I M _ I N D  
 	 F R O M   N E _ F a c i l i t y _ S I C   S  
 	 I N N E R   J O I N   F R S _ F A C   F   O N   F . S T _ F A C _ I N D   =   S . F A C I D  
 	 J O I N   F R S _ E I   E   O N  
 	 	 E . S T _ F A C _ I N D   =   S . F A C I D  
 	 A N D 	 E . E N V _ I N T _ T Y P E   =   S . P R G A C R  
 	 A N D   E . I N F _ S Y S _ I N D   =   ( L T R I M ( R T R I M ( S . P R G I D 1 ) )   +   ' ' - ' '   +   L T R I M ( R T R I M ( S . P R G I D 2 ) ) )  
  
 	 W H E R E   S . P R G A C R   < >   ' ' D E Q ' '  
 	 A N D   d b o . u d f s _ P a d L e a d i n g Z e r o e s ( S . S I C C O D ,   4 )   < >   ' ' 0 0 0 0 ' '  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     F R S _ F A C _ S I C   - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - -  
  
 	 I N S E R T   I N T O   F R S _ F A C _ S I C  
 	 S E L E C T   N E W I D ( )   A S   S T _ R E C _ I N D  
 	 	   ,   F . S T _ F A C _ I N D   A S   S T _ F A C _ I N D  
 	 	   ,   d b o . u d f s _ P a d L e a d i n g Z e r o e s ( S . S I C C O D ,   4 )   A S   S I C _ C D  
 	 	   ,   C A S E   W H E N   S . S I C P R I   =   1    
                           T H E N   ' ' P R I M A R Y ' '  
                                 W H E N   S . S I C P R I   =   2    
                           T H E N   ' ' S E C O N D A R Y ' '  
                           E L S E   ' ' U N K N O W N ' '  
                       E N D   A S   S I C _ P R I M _ I N D  
 	 F R O M   N E _ F a c i l i t y _ S I C   S  
 	 I N N E R   J O I N   F R S _ F A C   F   O N   F . S T _ F A C _ I N D   =   S . F A C I D  
 	 W H E R E   S . P R G A C R   =   ' ' D E Q ' '  
 	 A N D   d b o . u d f s _ P a d L e a d i n g Z e r o e s ( S . S I C C O D ,   4 )   < >   ' ' 0 0 0 0 ' '  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
  
 - -   O l d   v e r s i o n :  
 / *  
         I N S E R T   I N T O   [ d b o ] . [ F R S _ E I _ S I C ]  
  
 S E L E C T  
 	 C A S E   W H E N   L E N ( S T _ R E C _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ R E C _ I N D   E N D   A S   S T _ R E C _ I N D  
 , 	 C A S E   W H E N   L E N ( S T _ E I _ I N D )   =   0   T H E N   N U L L   E L S E   S T _ E I _ I N D   E N D   A S   S T _ E I _ I N D  
 , 	 C A S E   W H E N   L E N ( S I C _ C D )   =   0   T H E N   N U L L   E L S E   S I C _ C D   E N D   A S   S I C _ C D  
 , 	 C A S E   W H E N   L E N ( S I C _ P R I M _ I N D )   =   0   T H E N   N U L L   E L S E   S I C _ P R I M _ I N D   E N D   A S   S I C _ P R I M _ I N D  
  
 F R O M  
 	 (  
         S E L E C T   N e w I d ( )   A S   S T _ R E C _ I N D   - -   < S T _ R E C _ I N D ,   v a r c h a r ( 3 6 ) , >  
                   ,   L T R I M ( R T R I M ( S G . S T _ E I _ I N D ) )   A S   S T _ E I _ I N D   - -   < S T _ E I _ I N D ,   v a r c h a r ( 3 6 ) , >  
                   ,   d b o . u d f s _ P a d L e a d i n g Z e r o e s ( S G . S I C C O D ,   4 )   A S   S I C _ C D   - -   < S I C _ C D ,   v a r c h a r ( 4 ) , >  
 	 	   ,   C A S E   W H E N   S G . S I C P R I   =   1    
                           T H E N   ' ' P R I M A R Y ' '  
                                 W H E N   S G . S I C P R I   =   2    
                           T H E N   ' ' S E C O N D A R Y ' '  
                           E L S E   ' ' U N K N O W N ' '  
                       E N D   A S   S I C _ P R I M _ I N D   - -   < S I C _ P R I M _ I N D ,   v a r c h a r ( 1 0 ) , >  
             F R O M   ( S E L E C T   E I . S T _ E I _ I N D  
 	 	 	 	   ,   S I C . S I C C O D  
 	 	 	 	   ,   S I C . S I C P R I  
   	                     F R O M   F R S _ E I   E I   J O I N   N E _ F a c i l i t y _ S I C   S I C    
                                                               O N   E I . S T _ F A C _ I N D   =   S I C . F A C I D  
 	 	                                             A N D   E I . I N F _ S Y S _ I N D   =   ( L T R I M ( R T R I M ( S I C . P R G I D 1 ) )   +   ' ' - ' '   +   L T R I M ( R T R I M ( S I C . P R G I D 2 ) ) )  
 	 	                                             A N D   E I . E N V _ I N T _ T Y P E   =   S I C . P R G A C R  
 	                   G R O U P   B Y   E I . S T _ E I _ I N D  
 	 	 	 	   ,   S I C . S I C C O D  
 	 	 	 	   ,   S I C . S I C P R I )   S G  
 	 )   A S   G 1  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
 * /  
  
 E N D  
  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ C H E M _ M I X ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ C H E M _ M I X ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ C H E M _ M I X ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ C H E M _ M I X . C A S N u m b e r  
 ,   T 2 _ C H E M _ M I X . C o m p o n e n t  
 ,   T 2 _ C H E M _ M I X . C o m p o n e n t P e r c e n t a g e  
 ,   T 2 _ C H E M _ M I X . W e i g h t O r V o l u m e  
 F R O M   d b o . T 2 _ C H E M _ M I X   I N N E R   J O I N   d b o . T 2 _ C H E M _ I N V   O N   ( T 2 _ C H E M _ M I X . F K _ G U I D   =   T 2 _ C H E M _ I N V . P K _ G U I D )   I N N E R   J O I N   d b o . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ S I T E . P K _ G U I D   =   T 2 _ C H E M _ I N V . F K _ G U I D )  
 '  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ L o a d _ H E R E _ D o m a i n V a l u e s ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ L o a d _ H E R E _ D o m a i n V a l u e s ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 T K   C o n r a d  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 7 - 2 0  
 - -   D e s c r i p t i o n : 	 L o a d s   t h e   H E R E _ D o m a i n L i s t   a n d   H E R E _ D o m a i n L i s t I t e m s   t a b l e s .  
 - -                             F o r   e a c h   t y p e   o f   d a t a ,   t h e   p r o c e d u r e   w i l l   c h e c k   t h e   s o u r c e  
 - -                             l o o k u p   t a b l e s   t o   s e e   i f   a n y   r e c o r d s   i n   e a c h   t a b l e   h a s   a  
 - -                             c h a n g e   d a t e   g r e a t e r   t h a n   t h e   c h a n g e   d a t e   a s s o c i a t e d   w i t h   t h e  
 - -                             l i s t .   I f   s o ,   t h e n   t h e   e n t i r e   c o n t e n t s   o f   t h a t   d o m a i n   l i s t  
 - -                             w i l l   b e   d e l e t e d   a n d   r e p l a c e d   w i t h   t h e   l a t e s t   c o n t e n t s   f r o m  
 - -                             t h e   l o o k u p   t a b l e .   T h e   n e x t   t i m e   t h e   d o m a i n   l i s t   i s   g e n e r a t e d ,  
 - -                             i t   w i l l   p r o d u c e   o n l y   t h o s e   r e c o r d s   w h e r e   t h e   c h a n g e   d a t e   i s  
 - -                             g r e a t e r   t h a n   t h e   p a s s e d - i n   c h a n g e   d a t e .  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ L o a d _ H E R E _ D o m a i n V a l u e s ]    
 	 - -   A d d   t h e   p a r a m e t e r s   f o r   t h e   s t o r e d   p r o c e d u r e   h e r e  
 A S  
 B E G I N  
 	 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 	 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 	 S E T   N O C O U N T   O N ;  
  
 	 - -   D e c l a r e   l o c a l   v a r i a b l e s  
  
 	 D E C L A R E   @ P K _ G U I D 	 V A R C H A R ( 3 6 )  
 	 D E C L A R E   @ E R R O R _ C O D E 	 I N T  
  
         - -   I n s e r t   s t a t e m e n t s   f o r   p r o c e d u r e   h e r e  
  
 - -   C A F O  
  
 - - 	 T h e   C A F O   c o d e s   a r e   m a p p e d   i n   t w o   s t a g e s .   C A F O _ C o d e M a p p i n g   m a p s   t h e   s t a t e - s p e c i f i c  
 - - 	 C A F O   c o d e s   t o   t h e i r   c o u n t e r p a r t s   i n   t h e   s t a n d a r d   C A F O   s c h e m a .   C A F O _ A n i m a l U n i t s  
 - - 	 m a p s   t h e   C A F O   s t a n d a r d   c o d e s   t o   t h e   a n i m a l   u n i t s .  
  
 - -   C A F O   C o d e s  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ C A F O _ A n i m a l U n i t s )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   L I K E   ' ' C A F O _ A n i m a l U n i t s ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   C A F O - r e l a t e d   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   L I K E   ' ' C A F O _ A n i m a l U n i t s ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   p e r f o r m   i n s e r t s   f o r   C A F O   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' C A F O _ A n i m a l U n i t s ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , S t a n d a r d C o d e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , C O N V E R T ( V A R C H A R ,   A n i m a l U n i t s )   A S   A n i m a l U n i t s   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , S t a n d a r d D e s c r i p t i o n   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ C A F O _ A n i m a l U n i t s  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   C A M E O  
  
 - - 	 E a c h   e n t r y   f o r   t h e   C A M E O   d a t a   c o n s i s t s   o f   a   u n i q u e   I D   f r o m   a   t a b l e  
 - - 	 a l o n g   w i t h   a   p a r t i c u l a r   c o d e .  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ C A M E O )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   L I K E   ' ' C A M E O _ % ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   C A M E O - r e l a t e d   c o d e s  
  
 	 	 D E L E T E   F R O M   [ d b o ] . [ H E R E _ D o m a i n L i s t ]   W H E R E   D o m a i n L i s t N a m e   L I K E   ' ' C A M E O _ % ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   P e r f o r m   i n s e r t s   f o r   C A M E O   c o d e s  
  
 	 - -   C A M E O _ N a m e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' C A M E O _ N a m e s ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , C O N V E R T ( V A R C H A R ,   C A M E O . I d )   A S   I d   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , C A M E O . N A M E   A S   C a m e o N a m e   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , ' ' C h e m i c a l   N a m e ' '   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ C A M E O   C A M E O  
 	 	 W H E R E   I S N U L L ( C A M E O . N A M E ,   ' ' ' ' )   < >   ' ' ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - -   C A M E O _ C A S _ N u m b e r  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' C A M E O _ C A S _ N u m b e r ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , C O N V E R T ( V A R C H A R ,   C A M E O . I d )   A S   I d   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , C A M E O . C A S   A S   C a m e o C A S   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , ' ' C h e m i c a l   C A S   N u m b e r ' '   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ C A M E O   C A M E O  
 	 	 W H E R E   I S N U L L ( C A M E O . C A S ,   ' ' ' ' )   < >   ' ' ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - -   C A M E O _ U N N A _ N u m b e r  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' C A M E O _ U N N A _ N u m b e r ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , C O N V E R T ( V A R C H A R ,   C A M E O . I d )   A S   I d   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , C A M E O . U N N A   A S   C a m e o U N N A   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , ' ' C h e m i c a l   U N N A   N u m b e r ' '   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ C A M E O   C A M E O  
 	 	 W H E R E   I S N U L L ( C A M E O . U N N A ,   ' ' ' ' )   < >   ' ' ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - -   C A M E O _ S T C C _ N u m b e r  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' C A M E O _ S T C C _ N u m b e r ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , C O N V E R T ( V A R C H A R ,   C A M E O . I d )   A S   I d   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , C A M E O . S T C C   A S   C a m e o S T C C   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , ' ' C h e m i c a l   S T C C   N u m b e r ' '   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ C A M E O   C A M E O  
 	 	 W H E R E   I S N U L L ( C A M E O . S T C C ,   ' ' ' ' )   < >   ' ' ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - -   C A M E O _ C H R I S _ N u m b e r  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' C A M E O _ C H R I S _ N u m b e r ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , C O N V E R T ( V A R C H A R ,   C A M E O . I d )   A S   I d   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , C A M E O . C H R I S   A S   C a m e o C H R I S   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , ' ' C h e m i c a l   C H R I S   N u m b e r ' '   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ C A M E O   C A M E O  
 	 	 W H E R E   I S N U L L ( C A M E O . C H R I S ,   ' ' ' ' )   < >   ' ' ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - -   C A M E O _ C A M E O _ N u m b e r  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' C A M E O _ C A M E O _ N u m b e r ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , C O N V E R T ( V A R C H A R ,   C A M E O . I d )   A S   I d   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , C A M E O . C A M E O   A S   C a m e o C A M E O   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , ' ' C h e m i c a l   C A M E O   N u m b e r   ( a n d   U R L   f o r   C A M E O   C h e m i c a l s   w e b s i t e ) ' '   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ C A M E O   C A M E O  
 	 	 W H E R E   I S N U L L ( C A M E O . C A M E O ,   ' ' ' ' )   < >   ' ' ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   N E   C o u n t i e s  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ C o u n t i e s _ N E )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   =   ' ' N E _ C o u n t i e s _ M a p p i n g ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   ' ' N E _ C o u n t i e s _ M a p p i n g ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   =   ' ' N E _ C o u n t i e s _ M a p p i n g ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   I n s e r t   ' ' N E _ C o u n t i e s _ M a p p i n g ' '   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' N E _ C o u n t i e s _ M a p p i n g ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , d b o . u d f s _ P a d L e a d i n g Z e r o e s ( C T Y . F I P S C o d e ,   5 )   A S   F I P S C o d e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , C T Y . C o u n t y N a m e   A S   C o u n t y N a m e   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , ' ' N E   C o u n t y   a n d   F I P S   c o d e s ' '   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ C o u n t i e s _ N E   C T Y  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   E n v i r o n m e n t a l   I n t e r e s t   M a p p i n g  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ E I _ M a p p i n g )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   =   ' ' E I _ M a p p i n g ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   ' ' E I _ M a p p i n g ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   =   ' ' E I _ M a p p i n g ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   I n s e r t   ' ' E I _ M a p p i n g ' '   c o d e s  
  
 - -   T K C   9 / 2 6 / 2 0 0 7 	 A d d   p i p e s   ( | )   i n b e t w e e n   f i e l d s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' E I _ M a p p i n g ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , I S N U L L ( E I . E n v i r o n m e n t a l I n t e r e s t T y p e T e x t _ S o u r c e ,   ' ' ' ' )   A S   E I _ S o u r c e C o d e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , I S N U L L ( E I . E n v i r o n m e n t a l I n t e r e s t T y p e T e x t _ H E R E C l i e n t ,   ' ' N o n e ' ' )   A S   H E R E C l i e n t N a m e   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , N U L L   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ E I _ M a p p i n g   E I  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   H o r i z o n t a l C o l l e c t i o n M e t h o d  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ H o r i z o n t a l C o l l e c t i o n M e t h o d )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   =   ' ' H o r i z o n t a l C o l l e c t i o n M e t h o d ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   ' ' H o r i z o n t a l C o l l e c t i o n M e t h o d ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   =   ' ' H o r i z o n t a l C o l l e c t i o n M e t h o d ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   I n s e r t   ' ' H o r i z o n t a l C o l l e c t i o n M e t h o d ' '   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' H o r i z o n t a l C o l l e c t i o n M e t h o d ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , H C M . C o d e   A S   C o d e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , H C M . D e s c r i p t i o n   A S   D e s c r i p t i o n   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , N U L L   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ H o r i z o n t a l C o l l e c t i o n M e t h o d   H C M  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
 	  
 	 E N D  
  
 - -   I n d u s t r y C l a s s _ N A I C S C o d e s  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ I n d u s t r y C l a s s _ N A I C S C o d e s )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   =   ' ' I n d u s t r y C l a s s _ N A I C S C o d e s ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   ' ' I n d u s t r y C l a s s _ N A I C S C o d e s ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   =   ' ' I n d u s t r y C l a s s _ N A I C S C o d e s ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   I n s e r t   ' ' I n d u s t r y C l a s s _ N A I C S C o d e s ' '   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' I n d u s t r y C l a s s _ N A I C S C o d e s ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , C o d e   A S   C o d e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , S h o r t D e s c   A S   S h o r t D e s c   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , L o n g D e s c   A S   L o n g D e s c   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ I n d u s t r y C l a s s _ N A I C S C o d e s  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   I n d u s t r y C l a s s _ S I C C o d e s  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ I n d u s t r y C l a s s _ S I C C o d e s )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   =   ' ' I n d u s t r y C l a s s _ S I C C o d e s ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   ' ' I n d u s t r y C l a s s _ S I C C o d e s ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   =   ' ' I n d u s t r y C l a s s _ S I C C o d e s ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   I n s e r t   ' ' I n d u s t r y C l a s s _ S I C C o d e s ' '   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' I n d u s t r y C l a s s _ S I C C o d e s ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , C o d e   A S   C o d e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , S h o r t D e s c   A S   S h o r t D e s c   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , L o n g D e s c   A S   L o n g D e s c   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ I n d u s t r y C l a s s _ S I C C o d e s  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   N I O S H _ S e q u e n c e _ C A S  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ N I O S H _ S e q u e n c e _ C A S   W H E R E   I S N U L L ( C A S N o ,   ' ' ' ' )   < >   ' ' ' ' )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   =   ' ' N I O S H _ S e q u e n c e _ C A S ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   ' ' N I O S H _ S e q u e n c e _ C A S ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   =   ' ' N I O S H _ S e q u e n c e _ C A S ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   I n s e r t   ' ' N I O S H _ S e q u e n c e _ C A S ' '   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' N I O S H _ S e q u e n c e _ C A S ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , C A S N o   A S   C A S N u m b e r   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , M I N ( L E F T ( S e q u e n c e N o ,   4 ) )   A S   N I O S H _ S e q u e n c e _ C A S   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , ' ' C o d e   =   C A S   N u m b e r ,   D e s c r i p t i o n   =   N I O S H   s e q u e n c e ' '   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ N I O S H _ S e q u e n c e _ C A S  
 	 	 W H E R E   I S N U L L ( C A S N o ,   ' ' ' ' )   < >   ' ' ' '  
 	 	 G R O U P   B Y   C A S N o  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   S D W I S _ A c t i v i t y F l a g C o d e s  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ S D W I S _ A c t i v i t y F l a g C o d e s )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   =   ' ' S D W I S _ A c t i v i t y F l a g C o d e s ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   ' ' S D W I S _ A c t i v i t y F l a g C o d e s ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   =   ' ' S D W I S _ A c t i v i t y F l a g C o d e s ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   I n s e r t   ' ' S D W I S _ A c t i v i t y F l a g C o d e s ' '   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' S D W I S _ A c t i v i t y F l a g C o d e s ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , C o d e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , D e s c r i p t i o n   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , N U L L   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ S D W I S _ A c t i v i t y F l a g C o d e s  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   S D W I S _ A f f i l i a t i o n T y p e s  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ S D W I S _ A f f i l i a t i o n T y p e s )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   =   ' ' S D W I S _ A f f i l i a t i o n T y p e s ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   ' ' S D W I S _ A f f i l i a t i o n T y p e s ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   =   ' ' S D W I S _ A f f i l i a t i o n T y p e s ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   I n s e r t   ' ' S D W I S _ A f f i l i a t i o n T y p e s ' '   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' S D W I S _ A f f i l i a t i o n T y p e s ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , C o d e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , D e s c r i p t i o n   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , E x t D e s c r i p t i o n   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ S D W I S _ A f f i l i a t i o n T y p e s  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   S D W I S _ A v a i l a b i l i t y C o d e s  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ S D W I S _ A v a i l a b i l i t y C o d e s )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   =   ' ' S D W I S _ A v a i l a b i l i t y C o d e s ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   ' ' S D W I S _ A v a i l a b i l i t y C o d e s ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   =   ' ' S D W I S _ A v a i l a b i l i t y C o d e s ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   I n s e r t   ' ' S D W I S _ A v a i l a b i l i t y C o d e s ' '   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' S D W I S _ A v a i l a b i l i t y C o d e s ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , C o d e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , D e s c r i p t i o n   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , N U L L   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ S D W I S _ A v a i l a b i l i t y C o d e s  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   S D W I S _ F a c i l i t y T y p e C o d e s  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ S D W I S _ F a c i l i t y T y p e C o d e s )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   =   ' ' S D W I S _ F a c i l i t y T y p e C o d e s ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   ' ' S D W I S _ F a c i l i t y T y p e C o d e s ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   =   ' ' S D W I S _ F a c i l i t y T y p e C o d e s ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   I n s e r t   ' ' S D W I S _ F a c i l i t y T y p e C o d e s ' '   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' S D W I S _ F a c i l i t y T y p e C o d e s ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , C o d e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , D e s c r i p t i o n   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , N U L L   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ S D W I S _ F a c i l i t y T y p e C o d e s  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   S D W I S _ F a c i l i t y W a t e r T y p e C o d e s  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ S D W I S _ F a c i l i t y W a t e r T y p e C o d e s )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   =   ' ' S D W I S _ F a c i l i t y W a t e r T y p e C o d e s ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   ' ' S D W I S _ F a c i l i t y W a t e r T y p e C o d e s ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   =   ' ' S D W I S _ F a c i l i t y W a t e r T y p e C o d e s ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   I n s e r t   ' ' S D W I S _ F a c i l i t y W a t e r T y p e C o d e s ' '   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' S D W I S _ F a c i l i t y W a t e r T y p e C o d e s ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , C o d e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , D e s c r i p t i o n   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , N U L L   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ S D W I S _ F a c i l i t y W a t e r T y p e C o d e s  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   S D W I S _ O w n e r T y p e s  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ S D W I S _ O w n e r T y p e s )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   =   ' ' S D W I S _ O w n e r T y p e s ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   ' ' S D W I S _ O w n e r T y p e s ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   =   ' ' S D W I S _ O w n e r T y p e s ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   I n s e r t   ' ' S D W I S _ O w n e r T y p e s ' '   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' S D W I S _ O w n e r T y p e s ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , C o d e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , D e s c r i p t i o n   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , N U L L   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ S D W I S _ O w n e r T y p e s  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   S D W I S _ P W S T y p e s  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ S D W I S _ P W S T y p e s )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   =   ' ' S D W I S _ P W S T y p e s ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   ' ' S D W I S _ P W S T y p e s ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   =   ' ' S D W I S _ P W S T y p e s ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   I n s e r t   ' ' S D W I S _ P W S T y p e s ' '   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' S D W I S _ P W S T y p e s ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , C o d e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , D e s c r i p t i o n   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , N U L L   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ S D W I S _ P W S T y p e s  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   T i e r I I _ R e p o r t i n g R a n g e s  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ T i e r I I _ R e p o r t i n g R a n g e s )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   L I K E   ' ' T i e r I I _ R e p o r t i n g R a n g e s _ % ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   ' ' T i e r I I _ R e p o r t i n g R a n g e s _ % ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   L I K E   ' ' T i e r I I _ R e p o r t i n g R a n g e s _ % ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - -   I n s e r t   ' ' T i e r I I _ R e p o r t i n g R a n g e s _ F r o m ' '   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' T i e r I I _ R e p o r t i n g R a n g e s _ F r o m ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , R a n g e V a l u e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , W e i g h t R a n g e F r o m   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , N U L L   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ T i e r I I _ R e p o r t i n g R a n g e s  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - -   I n s e r t   ' ' T i e r I I _ R e p o r t i n g R a n g e s _ T o ' '   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' T i e r I I _ R e p o r t i n g R a n g e s _ T o ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , R a n g e V a l u e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , W e i g h t R a n g e T o   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , N U L L   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ T i e r I I _ R e p o r t i n g R a n g e s  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   T i e r I I _ S t o r a g e C o n d i t i o n s  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ T i e r I I _ S t o r a g e C o n d i t i o n s )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   L I K E   ' ' T i e r I I _ S t o r a g e C o n d i t i o n s _ % ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   D e l e t e   a l l   ' ' T i e r I I _ S t o r a g e C o n d i t i o n s _ % ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   L I K E   ' ' T i e r I I _ S t o r a g e C o n d i t i o n s _ % ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - -   T i e r I I _ S t o r a g e C o n d i t i o n s _ P r e s s u r e  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' T i e r I I _ S t o r a g e C o n d i t i o n s _ P r e s s u r e ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , S t o r a g e C o n d i t i o n C o d e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , S t o r a g e C o n d i t i o n D e s c r i p t i o n   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , N U L L   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ T i e r I I _ S t o r a g e C o n d i t i o n s  
 	 	 W H E R E   C o n d i t i o n T y p e   =   ' ' P R E S S U R E ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - -   T i e r I I _ S t o r a g e C o n d i t i o n s _ T e m p e r a t u r e  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' T i e r I I _ S t o r a g e C o n d i t i o n s _ T e m p e r a t u r e ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , S t o r a g e C o n d i t i o n C o d e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , S t o r a g e C o n d i t i o n D e s c r i p t i o n   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , N U L L   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ T i e r I I _ S t o r a g e C o n d i t i o n s  
 	 	 W H E R E   C o n d i t i o n T y p e   =   ' ' T E M P E R A T U R E ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   T i e r I I _ S t o r a g e T y p e s  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ S D W I S _ P W S T y p e s )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   =   ' ' T i e r I I _ S t o r a g e T y p e s ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   ' ' T i e r I I _ S t o r a g e T y p e s ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   =   ' ' T i e r I I _ S t o r a g e T y p e s ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   I n s e r t   ' ' T i e r I I _ S t o r a g e T y p e s ' '   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' T i e r I I _ S t o r a g e T y p e s ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , S t o r a g e C o d e   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , S t o r a g e D e s c r i p t i o n   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , N U L L   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ T i e r I I _ S t o r a g e T y p e s  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   U S P S _ S t a t e s  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ U S P S _ S t a t e s   W H E R E   S T A T E _ C O D E   < >   ' ' A E ' ' )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   =   ' ' U S P S _ S t a t e s ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   ' ' U S P S _ S t a t e s ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   =   ' ' U S P S _ S t a t e s ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   I n s e r t   ' ' U S P S _ S t a t e s ' '   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' U S P S _ S t a t e s ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , S T A T E _ C O D E   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , S T A T E _ N A M E   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , N U L L   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ U S P S _ S t a t e s  
 	 	 W H E R E   S T A T E _ C O D E   < >   ' ' A E ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
 - -   C o n t a c t _ P r i o r i t i z a t i o n  
  
 	 I F  
 	 (  
 	 ( S E L E C T   M A X ( C h a n g e D a t e )   F R O M   d b o . L o o k u p _ C o n t a c t P r i o r i t i z a t i o n )   >  
 	 	 (  
 	 	 S E L E C T   I S N U L L ( M I N ( C h a n g e D a t e ) ,   ' ' 1 9 0 0 - 0 1 - 0 1 ' ' )   F R O M   d b o . H E R E _ D o m a i n L i s t  
 	 	 W H E R E   D o m a i n L i s t N a m e   =   ' ' C o n t a c t _ P r i o r i t i z a t i o n ' '  
 	 	 )  
 	 )  
  
 	 B E G I N  
  
 - -   R e m o v e   a l l   ' ' C o n t a c t _ P r i o r i t i z a t i o n ' '   c o d e s  
  
 	 	 D E L E T E   F R O M   d b o . H E R E _ D o m a i n L i s t   W H E R E   D o m a i n L i s t N a m e   =   ' ' C o n t a c t _ P r i o r i t i z a t i o n ' '  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   I n s e r t   ' ' C o n t a c t _ P r i o r i t i z a t i o n ' '   c o d e s  
  
 	 	 S E L E C T   @ P K _ G U I D   =   N e w I d ( )  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	 	 	   V A L U E S  
 	 	 	 	       ( @ P K _ G U I D  
 	 	 	 	       , ' ' C o n t a c t _ P r i o r i t i z a t i o n ' '  
 	 	 	 	       , ' ' N E ' '  
 	 	 	 	       , G E T D A T E ( ) )  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 	 I N S E R T   I N T O   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 	 	 S E L E C T  
 	 	 	 	 	 N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , @ P K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	 	       , I S N U L L ( P r o g r a m N a m e ,   ' ' ' ' )   +   ' ' | ' '    
 	 	 	 	 + 	 I S N U L L ( C o n t a c t A f f i l i a t i o n T y p e ,   ' ' ' ' )   - -   < I t e m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , C A S T ( S o r t P r i o r i t y   A S   V A R C H A R ( 2 5 5 ) )   - -   < I t e m T e x t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	 	       , ' ' P r o g r a m   N a m e   a n d   c o n t a c t   a f f i l i a t i o n   t y p e   c o n c a t e n a t e d   w i t h   p i p e s   i n b e t w e e n ' '   - -   < I t e m D e s c r i p t i o n T e x t ,   v a r c h a r ( 4 0 0 0 ) , > )  
  
 	 	 F R O M   d b o . L o o k u p _ C o n t a c t P r i o r i t i z a t i o n  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 E N D  
  
  
 E N D  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ F R S _ F A C _ D E L ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ F R S _ F A C _ D E L ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ F R S _ F A C _ D E L ]   A S  
 s e l e c t   F R S _ F A C _ D E L . *  
     f r o m   d b o . F R S _ F A C _ D E L   '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ F R S _ E I _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ F R S _ E I _ I N D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ F R S _ E I _ I N D ]   A S  
 s e l e c t   F R S _ E I . S T _ F A C _ I N D  
 	 ,   A F F I L _ T Y P E  
 	 ,   A F F I L _ S T A R T _ D A T E  
 	 ,   A F F I L _ E N D _ D A T E  
 	 ,   E M A I L _ A D D  
 	 ,   T E L _ N U M  
 	 ,   P H _ E X T  
 	 ,   F A X _ N U M  
 	 ,   A L T _ T E L _ N U M  
 	 ,   I N D _ F U L L _ N M  
 	 ,   I N D _ T I T L E  
 	 ,   M A I L _ A D D  
 	 ,   S U P P L E M _ A D D  
 	 ,   M A I L _ A D D _ C I T Y _ N M  
 	 ,   M A I L _ A D D _ S T _ C D  
 	 ,   M A I L _ A D D _ S T _ N M  
 	 ,   M A I L _ A D D _ C O _ N M  
 	 ,   M A I L _ A D D _ Z I P _ C D  
     f r o m   d b o . F R S _ E I _ I N D   I N N E R   J O I N   d b o . F R S _ E I   o n   ( F R S _ E I . S T _ E I _ I N D   =   F R S _ E I _ I N D . S T _ E I _ I N D ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ F A C _ G E O ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ F A C _ G E O ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ F A C _ G E O ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ F A C _ G E O . A _ M E A S U R E  
 ,   T 2 _ F A C _ G E O . B _ M E A S U R E  
 ,   T 2 _ F A C _ G E O . S R C _ M A P _ S C A L E _ N U M  
 ,   T 2 _ F A C _ G E O . H O R I Z _ A C C U R _ M E A S U R E _ V A L U E  
 ,   T 2 _ F A C _ G E O . H O R I Z _ A C C U R _ M E A S U R E _ U N I T C D  
 ,   T 2 _ F A C _ G E O . H O R I Z _ A C C U R _ M E A S U R E _ U N I T C D L I S T I D  
 ,   T 2 _ F A C _ G E O . H O R I Z _ A C C U R _ M E A S U R E _ U N I T _ N A M E  
 ,   T 2 _ F A C _ G E O . H O R I Z _ A C C U R _ P R E C _ T X T  
 ,   T 2 _ F A C _ G E O . H O R I Z _ A C C U R _ R E S U L T _ Q U A L _ C D  
 ,   T 2 _ F A C _ G E O . H O R I Z _ A C C U R _ R E S U L T _ Q U A L _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . H O R I Z _ A C C U R _ R E S U L T _ Q U A L _ N M  
 ,   T 2 _ F A C _ G E O . H O R I Z _ C O L L _ M E T H _ I D C O D E  
 ,   T 2 _ F A C _ G E O . H O R I Z _ C O L L _ M E T H _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . H O R I Z _ C O L L _ M E T H _ N A M E  
 ,   T 2 _ F A C _ G E O . H O R I Z _ C O L L _ M E T H _ D E S C  
 ,   T 2 _ F A C _ G E O . H O R I Z _ C O L L _ M E T H _ D E V I A T I O N S  
 ,   T 2 _ F A C _ G E O . R E F _ P O I N T _ C D  
 ,   T 2 _ F A C _ G E O . R E F _ P O I N T _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . R E F _ P O I N T _ N A M E  
 ,   T 2 _ F A C _ G E O . H O R I Z _ R E F _ D A T U M _ C D  
 ,   T 2 _ F A C _ G E O . H O R I Z _ R E F _ D A T U M _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . H O R I Z _ R E F _ D A T U M _ N M  
 ,   T 2 _ F A C _ G E O . D A T A _ C O L L _ D A T E  
 ,   T 2 _ F A C _ G E O . L O C _ C O M M E N T S  
 ,   T 2 _ F A C _ G E O . V E R T _ M E A S U R E _ V A L U E  
 ,   T 2 _ F A C _ G E O . V E R T _ M E A S U R E _ U N I T C D  
 ,   T 2 _ F A C _ G E O . V E R T _ M E A S U R E _ U N I T C D L I S T I D  
 ,   T 2 _ F A C _ G E O . V E R T _ M E A S U R E _ U N I T _ N A M E  
 ,   T 2 _ F A C _ G E O . V E R T _ M E A S U R E _ P R E C _ T X T  
 ,   T 2 _ F A C _ G E O . V E R T _ M E A S U R E _ R E S U L T _ Q U A L _ C D  
 ,   T 2 _ F A C _ G E O . V E R T _ M E A S U R E _ R E S U L T _ Q U A L _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . V E R T _ M E A S U R E _ R E S U L T _ Q U A L _ N A M E  
 ,   T 2 _ F A C _ G E O . V E R T _ C O L L _ M E T H _ I D C O D E  
 ,   T 2 _ F A C _ G E O . V E R T _ C O L L _ M E T H _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . V E R T _ C O L L _ M E T H _ N A M E  
 ,   T 2 _ F A C _ G E O . V E R T _ C O L L _ M E T H _ D E S C  
 ,   T 2 _ F A C _ G E O . V E R T _ C O L L _ M E T H _ D E V I A T I O N S  
 ,   T 2 _ F A C _ G E O . V E R T _ R E F _ D A T U M _ C D  
 ,   T 2 _ F A C _ G E O . V E R T _ R E F _ D A T U M _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . V E R T _ R E F _ D A T U M _ N M  
 ,   T 2 _ F A C _ G E O . V E R I F _ M E T H _ I D C O D E  
 ,   T 2 _ F A C _ G E O . V E R I F _ M E T H _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . V E R I F _ M E T H _ N A M E  
 ,   T 2 _ F A C _ G E O . V E R I F _ M E T H _ D E S C  
 ,   T 2 _ F A C _ G E O . V E R I F _ M E T H _ D E V I A T I O N S  
 ,   T 2 _ F A C _ G E O . C O O R D _ D A T A _ S R C _ C D  
 ,   T 2 _ F A C _ G E O . C O O R D _ D A T A _ S R C _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . C O O R D _ D A T A _ S R C _ N M  
 ,   T 2 _ F A C _ G E O . G E O _ T Y P E _ C D  
 ,   T 2 _ F A C _ G E O . G E O _ T Y P E _ C D L I S T I D  
 ,   T 2 _ F A C _ G E O . G E O _ T Y P E _ N M  
 F R O M   d b o . T 2 _ F A C _ G E O   I N N E R   J O I N   d b o . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ G E O . F K _ G U I D   =   T 2 _ F A C _ S I T E . P K _ G U I D ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ F A C _ I N D _ P H O N E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ F A C _ I N D _ P H O N E ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ F A C _ I N D _ P H O N E ]  
 A S  
 S E L E C T           d b o . T 2 _ F A C _ S I T E . F a c i l i t y S i t e I d e n t i f i e r ,   d b o . T 2 _ F A C _ I N D _ P H O N E . T e l e p h o n e N u m b e r T e x t ,   d b o . T 2 _ F A C _ I N D _ P H O N E . T e l e p h o n e N u m b e r T y p e N a m e ,    
                                             d b o . T 2 _ F A C _ I N D _ P H O N E . T e l e p h o n e E x t e n s i o n N u m b e r T e x t  
 F R O M                   d b o . T 2 _ F A C _ I N D _ P H O N E   I N N E R   J O I N  
                                             d b o . T 2 _ F A C _ I N D   O N   d b o . T 2 _ F A C _ I N D . P K _ G U I D   =   d b o . T 2 _ F A C _ I N D _ P H O N E . F K _ G U I D   I N N E R   J O I N  
                                             d b o . T 2 _ F A C _ S I T E   O N   d b o . T 2 _ F A C _ S I T E . P K _ G U I D   =   d b o . T 2 _ F A C _ I N D . F K _ G U I D  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ F R S _ E I _ N A I C S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ F R S _ E I _ N A I C S ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ F R S _ E I _ N A I C S ]   A S  
 s e l e c t     F R S _ E I . S T _ F A C _ I N D  
 ,   N A I C S _ C D  
 ,   N A I C S _ P R I M _ I N D  
     f r o m   d b o . F R S _ E I _ N A I C S   I N N E R   J O I N   d b o . F R S _ E I   o n   ( F R S _ E I . S T _ E I _ I N D   =   F R S _ E I _ N A I C S . S T _ E I _ I N D ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ F A C _ I N D _ E M A I L ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ F A C _ I N D _ E M A I L ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ F A C _ I N D _ E M A I L ]  
 A S  
 S E L E C T           d b o . T 2 _ F A C _ S I T E . F a c i l i t y S i t e I d e n t i f i e r ,   d b o . T 2 _ F A C _ I N D _ E M A I L . E l e c t r o n i c A d d r e s s T e x t ,   d b o . T 2 _ F A C _ I N D _ E M A I L . E l e c t r o n i c A d d r e s s T y p e N a m e  
 F R O M                   d b o . T 2 _ F A C _ I N D _ E M A I L   I N N E R   J O I N  
                                             d b o . T 2 _ F A C _ I N D   O N   d b o . T 2 _ F A C _ I N D . P K _ G U I D   =   d b o . T 2 _ F A C _ I N D _ E M A I L . F K _ G U I D   I N N E R   J O I N  
                                             d b o . T 2 _ F A C _ S I T E   O N   d b o . T 2 _ F A C _ S I T E . P K _ G U I D   =   d b o . T 2 _ F A C _ I N D . F K _ G U I D  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ F R S _ E I _ O R G ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ F R S _ E I _ O R G ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ F R S _ E I _ O R G ]   A S  
 s e l e c t       F R S _ E I . S T _ F A C _ I N D  
 	 ,   A F F I L _ T Y P E  
 	 ,   A F F I L _ S T A R T _ D A T E  
 	 ,   A F F I L _ E N D _ D A T E  
 	 ,   E M A I L _ A D D  
 	 ,   T E L _ N U M  
 	 ,   P H _ E X T  
 	 ,   F A X _ N U M  
 	 ,   A L T _ T E L _ N U M  
 	 ,   O R G _ F O R M A L _ N M  
 	 ,   O R G _ D U N S _ N U M  
 	 ,   O R G _ T Y P E  
 	 ,   E M P L O Y E R _ I N D  
 	 ,   S T _ B U S I N E S S _ I N D  
 	 ,   U L T _ P A R E N T _ N M  
 	 ,   U L T _ P A R E N T _ D U N S _ N U M  
 	 ,   M A I L _ A D D  
 	 ,   S U P P L E M _ A D D  
 	 ,   M A I L _ A D D _ C I T Y _ N M  
 	 ,   M A I L _ A D D _ S T _ C D  
 	 ,   M A I L _ A D D _ S T _ N M  
 	 ,   M A I L _ A D D _ C O _ N M  
 	 ,   M A I L _ A D D _ Z I P _ C D  
     f r o m   d b o . F R S _ E I _ O R G   I N N E R   J O I N   d b o . F R S _ E I   o n   ( F R S _ E I . S T _ E I _ I N D   =   F R S _ E I _ O R G . S T _ E I _ I N D ) '  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ G e t _ H E R E _ M a n i f e s t D a t a ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ G e t _ H E R E _ M a n i f e s t D a t a ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 T K   C o n r a d  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 7 - 1 8  
 - -   D e s c r i p t i o n : 	 L o a d s   t h e   H E R E   M a n i f e s t   t a b l e  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ G e t _ H E R E _ M a n i f e s t D a t a ]    
 	 @ c h a n g e D a t e   D a t e T i m e  
  
 A S  
 S E T   N O C O U N T   O N ;  
  
 S E L E C T   [ T r a n s a c t i o n I d ]  
             , [ E n d p o i n t U R L ]  
             , [ D a t a E x c h a n g e N a m e ]  
             , C O N V E R T ( B I T ,   C A S E   W H E N   [ I s F a c i l i t y S o u r c e I n d i c a t o r ]   =   ' ' Y ' '   T H E N   1   E L S E   0   E N D )   a s   I s F a c i l i t y S o u r c e I n d i c a t o r  
             , [ S o u r c e S y s t e m N a m e ]  
             , C O N V E R T ( B I T ,   C A S E   W H E N   [ F u l l R e p l a c e I n d i c a t o r ]   =   ' ' Y ' '   T H E N   1   E L S E   0   E N D )   a s   F u l l R e p l a c e I n d i c a t o r  
             , [ C r e a t e d D a t e ]  
     F R O M   [ d b o ] . [ H E R E _ M a n i f e s t ]  
  
         W H E R E   [ C r e a t e d D a t e ]   > =   @ c h a n g e D a t e  
  
 O R D E R   B Y   [ C r e a t e d D a t e ] ;  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ L o a d _ H E R E _ M a n i f e s t ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ L o a d _ H E R E _ M a n i f e s t ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 T K   C o n r a d  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 7 - 1 8  
 - -   D e s c r i p t i o n : 	 L o a d s   t h e   H E R E   M a n i f e s t   t a b l e  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ L o a d _ H E R E _ M a n i f e s t ]    
 	 - -   A d d   t h e   p a r a m e t e r s   f o r   t h e   s t o r e d   p r o c e d u r e   h e r e  
 	 @ T r a n s a c t i o n I d 	 	 	 	 v a r c h a r ( 2 5 5 )    
 , 	 @ E n d p o i n t U R L 	 	 	 	 v a r c h a r ( 5 0 0 )  
 , 	 @ D a t a E x c h a n g e N a m e 	 	 	 v a r c h a r ( 2 5 5 )  
 , 	 @ I s F a c i l i t y S o u r c e I n d i c a t o r 	 b i t  
 , 	 @ S o u r c e S y s t e m N a m e 	 	 	 v a r c h a r ( 2 5 5 )  
 , 	 @ F u l l R e p l a c e I n d i c a t o r 	 	 b i t  
  
 A S  
 B E G I N  
 	 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 	 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 	 S E T   N O C O U N T   O N ;  
  
         - -   I n s e r t   s t a t e m e n t s   f o r   p r o c e d u r e   h e r e  
  
 - -   T K C   9 / 2 4 / 2 0 0 7 	 I f   t h e   f i l e   t o   b e   i n s e r t e d   i s   a   " f u l l   r e p l a c e " ,   d e l e t e   a l l  
 - - 	 	 	 	 	 p r e - e x i s t i n g   f i l e s   f o r   t h a t   f l o w  
 - -   G F O   1 2 / 2 4 / 2 0 0 7 	 I f   F R S   h a s   a   f u l l   r e f r e s h ,   t h e n   a l s o   d e l e t e   t h e   H E R E   D e l e t e   f i l e s  
  
 I F   @ F u l l R e p l a c e I n d i c a t o r   =   1  
 	 B E G I N  
 	 	 D E L E T E   F R O M   H E R E _ M a n i f e s t   W H E R E   [ D a t a E x c h a n g e N a m e ]   =   @ D a t a E x c h a n g e N a m e  
 	         I F   @ D a t a E x c h a n g e N a m e   =   ' ' H E R E - F R S ' '      
                         D E L E T E   F R O M   H E R E _ M a n i f e s t   W H E R E   [ D a t a E x c h a n g e N a m e ]   =   ' ' H E R E - D E L E T E ' ' ;  
             E N D ;  
        
  
 I N S E R T   I N T O   [ d b o ] . [ H E R E _ M a n i f e s t ]  
                       ( [ T r a n s a c t i o n I d ]  
                       , [ E n d p o i n t U R L ]  
                       , [ D a t a E x c h a n g e N a m e ]  
                       , [ I s F a c i l i t y S o u r c e I n d i c a t o r ]  
                       , [ S o u r c e S y s t e m N a m e ]  
                       , [ F u l l R e p l a c e I n d i c a t o r ]  
                       , [ C r e a t e d D a t e ] )  
           V A L U E S  
                       ( @ T r a n s a c t i o n I d  
                       , @ E n d p o i n t U R L  
                       , @ D a t a E x c h a n g e N a m e  
                       , C A S E   W H E N   @ I s F a c i l i t y S o u r c e I n d i c a t o r   =   1   T H E N   ' ' Y ' '   E L S E   ' ' N ' '   E N D  
                       , @ S o u r c e S y s t e m N a m e  
                       , C A S E   W H E N   @ F u l l R e p l a c e I n d i c a t o r   =   1   T H E N   ' ' Y ' '   E L S E   ' ' N ' '   E N D  
                       , G e t D a t e ( ) )  
  
 E N D  
  
  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ F A C _ I N D _ T Y P E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ F A C _ I N D _ T Y P E ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ F A C _ I N D _ T Y P E ]  
 A S  
 S E L E C T           d b o . T 2 _ F A C _ S I T E . F a c i l i t y S i t e I d e n t i f i e r ,   d b o . T 2 _ F A C _ I N D _ T Y P E . C o n t a c t T y p e  
 F R O M                   d b o . T 2 _ F A C _ I N D _ T Y P E   I N N E R   J O I N  
                                             d b o . T 2 _ F A C _ I N D   O N   d b o . T 2 _ F A C _ I N D . P K _ G U I D   =   d b o . T 2 _ F A C _ I N D _ T Y P E . F K _ G U I D   I N N E R   J O I N  
                                             d b o . T 2 _ F A C _ S I T E   O N   d b o . T 2 _ F A C _ S I T E . P K _ G U I D   =   d b o . T 2 _ F A C _ I N D . F K _ G U I D  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ F R S _ E I _ S I C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ F R S _ E I _ S I C ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ F R S _ E I _ S I C ]   A S  
 s e l e c t   F R S _ E I . S T _ F A C _ I N D  
 	 ,   S I C _ C D  
 	 ,   S I C _ P R I M _ I N D  
     f r o m   d b o . F R S _ E I _ S I C   I N N E R   J O I N   d b o . F R S _ E I   o n   ( F R S _ E I . S T _ E I _ I N D   =   F R S _ E I _ S I C . S T _ E I _ I N D ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ F R S _ F A C _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ F R S _ F A C _ I N D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' - - - - - - - - - - - - - - - - - - -  
 C R E A T E   V I E W   [ d b o ] . [ v w _ F R S _ F A C _ I N D ]   A S  
 s e l e c t   S T _ F A C _ I N D  
 	 ,   A F F I L _ T Y P E  
 	 ,   A F F I L _ S T A R T _ D A T E  
 	 ,   A F F I L _ E N D _ D A T E  
 	 ,   E M A I L _ A D D  
 	 ,   T E L _ N U M  
 	 ,   P H _ E X T  
 	 ,   F A X _ N U M  
 	 ,   A L T _ T E L _ N U M  
 	 ,   I N D _ F U L L _ N M  
 	 ,   I N D _ T I T L E  
 	 ,   M A I L _ A D D  
 	 ,   S U P P L E M _ A D D  
 	 ,   M A I L _ A D D _ C I T Y _ N M  
 	 ,   M A I L _ A D D _ S T _ C D  
 	 ,   M A I L _ A D D _ S T _ N M  
 	 ,   M A I L _ A D D _ C O _ N M  
 	 ,   M A I L _ A D D _ Z I P _ C D  
     f r o m   d b o . F R S _ F A C _ I N D   '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ F R S _ F A C _ N A I C S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ F R S _ F A C _ N A I C S ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ F R S _ F A C _ N A I C S ]   A S  
 s e l e c t   S T _ F A C _ I N D  
           ,   N A I C S _ C D  
           ,   N A I C S _ P R I M _ I N D  
     f r o m   d b o . F R S _ F A C _ N A I C S   '  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ G e t _ H E R E _ D o m a i n V a l u e s D a t a ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ G e t _ H E R E _ D o m a i n V a l u e s D a t a ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 T K   C o n r a d  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 7 - 1 9  
 - -   D e s c r i p t i o n : 	 R e t u r n s   c o n t e n t s   o f   D o m a i n   V a l u e s   a n d   D o m a i n   V a l u e   I t e m s  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ G e t _ H E R E _ D o m a i n V a l u e s D a t a ]    
 	 ( @ c h a n g e D a t e   D a t e T i m e ,  
         @ L i s t I n d e x   i n t )  
 A S  
 B E G I N  
 	 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 	 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 	 S E T   N O C O U N T   O N ;  
  
         - -   I n s e r t   s t a t e m e n t s   f o r   p r o c e d u r e   h e r e  
  
 I F   @ L i s t I n d e x   =   0  
  
 	 S E L E C T   [ P K _ G U I D ]   a s   L i s t I d  
 	 	     , [ D o m a i n L i s t N a m e ]   a s   L i s t N a m e  
 	 	     , [ O r i g i n a t i n g P a r t n e r N a m e ]   a s   L i s t O w n e r N a m e  
 	     F R O M   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 	     W H E R E   C h a n g e D a t e   > =   @ c h a n g e D a t e ;  
  
 E L S E  
  
 	 S E L E C T    
 	 	 	 L . [ F K _ G U I D ]   a s   L i s t I d  
 	 	     , L . [ I t e m C o d e ]   a s   I t e m C o d e  
 	 	     , L . [ I t e m T e x t ]   a s   I t e m V a l u e  
 	 	     , L . [ I t e m D e s c r i p t i o n T e x t ]   a s   I t e m D e s c  
 	     F R O M   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]   L  
 	 J O I N   [ d b o ] . [ H E R E _ D o m a i n L i s t ]   D   O N   D . P K _ G U I D   =   L . F K _ G U I D  
 	 W H E R E   D . C h a n g e D a t e   > =   @ c h a n g e D a t e ;  
  
 E N D  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ H E R E _ D o m a i n L i s t _ I t e m s ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 8   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ H E R E _ D o m a i n L i s t _ I t e m s ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 C R E A T E   V I E W   [ d b o ] . [ v w _ H E R E _ D o m a i n L i s t _ I t e m s ]  
 A S  
 S E L E C T           d b o . H E R E _ D o m a i n L i s t . P K _ G U I D   A S   H E R E _ D o m a i n L i s t _ P K ,   d b o . H E R E _ D o m a i n L i s t . D o m a i n L i s t N a m e ,   d b o . H E R E _ D o m a i n L i s t . O r i g i n a t i n g P a r t n e r N a m e ,   d b o . H E R E _ D o m a i n L i s t . C h a n g e D a t e ,  
                                             d b o . H E R E _ D o m a i n L i s t I t e m . P K _ G U I D   A S   H E R E _ D o m a i n L i s t I t e m _ P K ,   d b o . H E R E _ D o m a i n L i s t I t e m . I t e m C o d e ,   d b o . H E R E _ D o m a i n L i s t I t e m . I t e m T e x t ,    
                                             d b o . H E R E _ D o m a i n L i s t I t e m . I t e m D e s c r i p t i o n T e x t  
 F R O M                   d b o . H E R E _ D o m a i n L i s t   I N N E R   J O I N  
                                             d b o . H E R E _ D o m a i n L i s t I t e m   O N   d b o . H E R E _ D o m a i n L i s t . P K _ G U I D   =   d b o . H E R E _ D o m a i n L i s t I t e m . F K _ G U I D  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ F R S _ F A C _ O R G ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ F R S _ F A C _ O R G ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' - - - - - - - - - - - - - - - - - - -  
 - -     F R S _ F A C _ O R G     - -  
 - - - - - - - - - - - - - - - - - - -  
 C R E A T E   V I E W   [ d b o ] . [ v w _ F R S _ F A C _ O R G ]   A S  
 s e l e c t   S T _ F A C _ I N D  
 	 ,   A F F I L _ T Y P E  
 	 ,   A F F I L _ S T A R T _ D A T E  
 	 ,   A F F I L _ E N D _ D A T E  
 	 ,   E M A I L _ A D D  
 	 ,   T E L _ N U M  
 	 ,   P H _ E X T  
 	 ,   F A X _ N U M  
 	 ,   A L T _ T E L _ N U M  
 	 ,   O R G _ F O R M A L _ N M  
 	 ,   O R G _ D U N S _ N U M  
 	 ,   O R G _ T Y P E  
 	 ,   E M P L O Y E R _ I N D  
 	 ,   S T _ B U S I N E S S _ I N D  
 	 ,   U L T _ P A R E N T _ N M  
 	 ,   U L T _ P A R E N T _ D U N S _ N U M  
 	 ,   M A I L _ A D D  
 	 ,   S U P P L E M _ A D D  
 	 ,   M A I L _ A D D _ C I T Y _ N M  
 	 ,   M A I L _ A D D _ S T _ C D  
 	 ,   M A I L _ A D D _ S T _ N M  
 	 ,   M A I L _ A D D _ C O _ N M  
 	 ,   M A I L _ A D D _ Z I P _ C D  
     f r o m   d b o . F R S _ F A C _ O R G '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ C A F O _ A D D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ C A F O _ A D D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ C A F O _ A D D ]   A S  
 S E L E C T   C A F O _ F A C . S t a t e F a c i l i t y I D  
           ,   L o c a t i o n A d d r e s s  
           ,   S u p p l e m e n t a l A d d r e s s  
           ,   L o c a l i t y N a m e  
           ,   C o u n t y N a m e  
           ,   S t a t e N a m e  
           ,   S t a t e U S P S C o d e  
           ,   A d d r e s s P o s t a l C o d e  
     F R O M   c m p . C A F O _ F A C   I N N E R   J O I N   c m p . C A F O _ A D D   O N   ( C A F O _ F A C . P K   =   C A F O _ A D D . F K )  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ F R S _ F A C _ S I C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 7   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ F R S _ F A C _ S I C ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ F R S _ F A C _ S I C ]   A S  
 s e l e c t   S T _ F A C _ I N D  
 	 ,   S I C _ C D  
 	 ,   S I C _ P R I M _ I N D  
     f r o m   d b o . F R S _ F A C _ S I C   '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ C A F O _ A N I M A L ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ C A F O _ A N I M A L ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ C A F O _ A N I M A L ]   A S  
 s e l e c t   C A F O _ F A C . S t a t e F a c i l i t y I D  
 	 ,   A n i m a l T y p e C o d e  
 	 ,   A n i m a l T y p e N a m e  
 	 ,   T o t a l N u m s E a c h L i v e s t o c k  
 	 ,   O p e n C o u n t  
 	 ,   H o u s e d U n d e r R o o f C o u n t  
     f r o m   c m p . C A F O _ A N I M A L   I N N E R   J O I N   c m p . C A F O _ F A C   o n   ( C A F O _ F A C . P K   =   C A F O _ A N I M A L . F K ) '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ C A F O _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ C A F O _ F A C ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ C A F O _ F A C ]   A S  
 s e l e c t   S t a t e F a c i l i t y I D  
         ,   F a c i l i t y S i t e N a m e  
 	 ,   F a c i l i t y A l t N a m e  
 	 ,   F a c i l i t y I n f o U R L  
 	 ,   F a c i l i t y R e g i s t r y I D  
     f r o m   c m p . C A F O _ F A C    
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ C A F O _ G E O ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ C A F O _ G E O ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ C A F O _ G E O ]   A S  
 s e l e c t   C A F O _ F A C . S t a t e F a c i l i t y I D  
 	 , L a t i t u d e  
 	 , L o n g i t u d e  
 	 , H o r i z A c c u r V a l u e  
 	 , H o r i z A c c u r U n i t C o d e  
 	 , H o r i z A c c u r U n i t C o d e L i s t I D  
 	 , H o r i z A c c u r U n i t N a m e  
 	 , P r e c T e x t  
 	 , R e s u l t Q u a l C o d e  
 	 , R e s u l t Q u a l C o d e L i s t I D  
 	 , R e s u l t Q u a l N a m e  
 	 , H o r i z M e t h o d I D C o d e  
 	 , H o r i z M e t h o d I D C o d e L i s t I D  
 	 , H o r i z M e t h o d N a m e  
 	 , H o r i z M e t h o d D e s c  
 	 , H o r i z M e t h o d D e v i a t i o n s  
 	 , H y d r o l o g i c U n i t C o d e  
 	 , L o c a t i o n C o m m e n t s  
     f r o m   c m p . C A F O _ G E O   I N N E R   J O I N   c m p . C A F O _ F A C   o n   ( C A F O _ F A C . P K   =   C A F O _ G E O . F K )  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ C A F O _ P E R M I T ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ C A F O _ P E R M I T ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ C A F O _ P E R M I T ]   A S  
 s e l e c t   C A F O _ F A C . S t a t e F a c i l i t y I D  
 	 ,   P e r m i t I d  
 	 ,   P e r m i t N a m e  
 	 ,   O t h e r P e r m i t I d  
 	 ,   P r o g r a m N a m e  
 	 ,   P e r m i t T y p e C o d e  
 	 ,   P e r m i t T y p e C o d e L i s t I D  
 	 ,   P e r m i t T y p e N a m e  
     f r o m   c m p . C A F O _ P E R M I T   I N N E R   J O I N   c m p . C A F O _ R E G _ D T L S   o n   ( C A F O _ R E G _ D T L S . P K   =   C A F O _ P E R M I T . F K )  
                                               I N N E R   J O I N   c m p . C A F O _ F A C   o n   ( C A F O _ F A C . P K   =   C A F O _ R E G _ D T L S . F K )  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ C A F O _ R E G _ D T L S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ C A F O _ R E G _ D T L S ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' - - - - - - - - - - - - - - - - - - - - -  
 - -     C A F O _ R E G _ D T L S     - -  
 - - - - - - - - - - - - - - - - - - - - -  
 C R E A T E   V I E W   [ c m p ] . [ v w _ C A F O _ R E G _ D T L S ]   A S  
 s e l e c t     C A F O _ F A C . S t a t e F a c i l i t y I D  
         ,   D i s c h r g F r o m P r o d A r e a  
 	 ,   A u t h o r i z e d D i s c h a r g e  
 	 ,   U n a u t h o r i z e d D i s c h a r g e  
 	 ,   P e r m i t t i n g A u t h R e p R e c D a t e  
 	 ,   I s A n i m a l F a c i l i t y T y p e C A F O  
 	 ,   L i q M a n u r e V a l u e  
 	 ,   L i q M a n u r e U n i t C o d e  
 	 ,   L i q M a n u r e U n i t C o d e L i s t I D  
 	 ,   L i q M a n u r e U n i t N a m e  
 	 ,   L i q M a n u r e P r e c  
 	 ,   L i q M a n u r e R e s u l t C o d e  
 	 ,   L i q M a n u r e R e s u l t C o d e L i s t I D  
 	 ,   L i q M a n u r e R e s u l t N a m e  
 	 ,   L i q M a n u r e T r a n V a l u e  
 	 ,   L i q M a n u r e T r a n U n i t C o d e  
 	 ,   L i q M a n u r e T r a n U n i t C o d e L i s t I D  
 	 ,   L i q M a n u r e T r a n U n i t N a m e  
 	 ,   L i q M a n u r e T r a n P r e c  
 	 ,   L i q M a n u r e T r a n R e s u l t C o d e  
 	 ,   L i q M a n u r e T r a n R e s u l t C o d e L i s t I D  
 	 ,   L i q M a n u r e T r a n R e s u l t N a m e  
 	 ,   S o l M a n u r e V a l u e  
 	 ,   S o l M a n u r e U n i t C o d e  
 	 ,   S o l M a n u r e U n i t C o d e L i s t I D  
 	 ,   S o l M a n u r e U n i t N a m e  
 	 ,   S o l M a n u r e P r e c  
 	 ,   S o l M a n u r e R e s u l t C o d e  
 	 ,   S o l M a n u r e R e s u l t C o d e L i s t I D  
 	 ,   S o l M a n u r e R e s u l t N a m e  
 	 ,   S o l M a n u r e T r a n V a l u e  
 	 ,   S o l M a n u r e T r a n U n i t C o d e  
 	 ,   S o l M a n u r e T r a n U n i t C o d e L i s t I D  
 	 ,   S o l M a n u r e T r a n U n i t N a m e  
 	 ,   S o l M a n u r e T r a n P r e c  
 	 ,   S o l M a n u r e T r a n R e s u l t C o d e  
 	 ,   S o l M a n u r e T r a n R e s u l t C o d e L i s t I D  
 	 ,   S o l M a n u r e T r a n R e s u l t N a m e  
 	 ,   N M P D e v C e r t P l a n A p p r o v e d  
 	 ,   T o t a l N u m A c r e s N M P I d e n t i f i e d  
 	 ,   T o t a l N u m A c r e s U s e d L a n d A p p  
     f r o m   c m p . C A F O _ R E G _ D T L S   I N N E R   J O I N   c m p . C A F O _ F A C   o n   ( C A F O _ F A C . P K   =   C A F O _ R E G _ D T L S . F K )  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ F R S _ G E O ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 7   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ F R S _ G E O ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ F R S _ G E O ]   A S  
 s e l e c t   F R S _ G E O . *  
     f r o m   d b o . F R S _ G E O   '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ F R S _ A D D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ F R S _ A D D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ F R S _ A D D ]   A S  
 s e l e c t   F R S _ A D D . *  
     f r o m   d b o . F R S _ A D D   ; '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ F R S _ E I ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ F R S _ E I ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ F R S _ E I ]   A S  
 S E L E C T   S T _ F A C _ I N D  
 	   ,   I N F _ S Y S _ A C  
 	   ,   I N F _ S Y S _ I N D  
 	   ,   E N V _ I N T _ T Y P E  
 	   ,   F E D _ S T _ I N T  
 	   ,   E N V _ I N T _ S T A R T _ D A T E  
 	   ,   I N T _ S T A R T _ D A T E _ Q U A L  
 	   ,   E N V _ I N T _ E N D _ D A T E  
 	   ,   I N T _ E N D _ D A T E _ Q U A L  
     F R O M   d b o . F R S _ E I   '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ F R S _ A L T _ N M ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ F R S _ A L T _ N M ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ F R S _ A L T _ N M ]   A S  
 s e l e c t   F R S _ A L T _ N M . *  
     f r o m   d b o . F R S _ A L T _ N M '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ R E P O R T ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 9   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ R E P O R T ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ R E P O R T ]  
 A S  
 S E L E C T           c m p . T 2 _ F A C _ S I T E . F a c i l i t y S i t e I d e n t i f i e r ,   c m p . T 2 _ R E P O R T . R e p o r t I d e n t i f i e r ,   c m p . T 2 _ R E P O R T . R e p o r t D u e D a t e ,   c m p . T 2 _ R E P O R T . R e p o r t R e c e i v e d D a t e ,    
                                             c m p . T 2 _ R E P O R T . R e p o r t R e c i p i e n t N a m e ,   c m p . T 2 _ R E P O R T . R e p o r t i n g P e r i o d S t a r t D a t e ,   c m p . T 2 _ R E P O R T . R e p o r t i n g P e r i o d E n d D a t e ,    
                                             c m p . T 2 _ R E P O R T . R e v i s i o n I n d i c a t o r ,   c m p . T 2 _ R E P O R T . R e p l a c e d R e p o r t I d e n t i f i e r ,   c m p . T 2 _ R E P O R T . R e p o r t C r e a t e B y N a m e ,    
                                             c m p . T 2 _ R E P O R T . R e p o r t T y p e  
 F R O M                   c m p . T 2 _ R E P O R T   I N N E R   J O I N  
                                             c m p . T 2 _ F A C _ S I T E   O N   c m p . T 2 _ R E P O R T . P K _ G U I D   =   c m p . T 2 _ F A C _ S I T E . F K _ G U I D  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ F A C _ D U N D B _ I D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ F A C _ D U N D B _ I D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ F A C _ D U N D B _ I D ]   A S    
 S E L E C T    
  
 	 T 2 F . F a c i l i t y S i t e I d e n t i f i e r  
 , 	 T 2 D U N D B . F a c i l i t y D u n B r a d s t r e e t C o d e  
 F R O M   c m p . T 2 _ F A C _ D U N D B _ I D   T 2 D U N D B  
 I N N E R   J O I N   c m p . T 2 _ F A C _ S I T E   T 2 F   O N   T 2 D U N D B . F K _ G U I D   =   T 2 F . P K _ G U I D '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ C H E M _ I N V ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ C H E M _ I N V ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ C H E M _ I N V ]   A S  
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ C H E M _ I N V . C h e m i c a l I d e n t i f i e r  
 ,   T 2 _ C H E M _ I N V . E H S I n d i c a t o r  
 ,   T 2 _ C H E M _ I N V . T r a d e S e c r e t I n d i c a t o r  
 ,   T 2 _ C H E M _ I N V . C A S N u m b e r  
 ,   T 2 _ C H E M _ I N V . C h e m S u b s t a n c e S y s t e m a t i c N a m e  
 ,   T 2 _ C H E M _ I N V . E P A C h e m i c a l R e g i s t r y N a m e  
 ,   T 2 _ C H E M _ I N V . E P A C h e m i c a l I d e n t i f i e r  
 ,   T 2 _ C H E M _ I N V . C h e m i c a l N a m e C o n t e x t  
  
 F R O M   c m p . T 2 _ C H E M _ I N V   I N N E R   J O I N   c m p . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ S I T E . P K _ G U I D   =   T 2 _ C H E M _ I N V . F K _ G U I D )  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 8   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ F A C _ S I T E ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ F A C _ S I T E ]   A S  
 S E L E C T  
               [ F a c i l i t y S i t e I d e n t i f i e r ]  
             , [ F a c i l i t y S i t e N a m e ]  
             , [ F a c i l i t y S t a t u s ]  
             , [ L o c a t i o n A d d r e s s T e x t ]  
             , [ S u p p l e m e n t a l L o c a t i o n T e x t ]  
             , [ L o c a l i t y N a m e ]  
             , [ S t a t e C o d e ]  
             , [ S t a t e C o d e L i s t I d e n t i f i e r ]  
             , [ S t a t e N a m e ]  
             , [ A d d r e s s P o s t a l C o d e ]  
             , [ C o u n t r y C o d e ]  
             , [ C o u n t r y C o d e L i s t I d e n t i f i e r ]  
             , [ C o u n t r y N a m e ]  
             , [ C o u n t y C o d e ]  
             , [ C o u n t y C o d e L i s t I d e n t i f i e r ]  
             , [ C o u n t y N a m e ]  
             , [ T r i b a l C o d e ]  
             , [ T r i b a l C o d e L i s t I d e n t i f i e r ]  
             , [ T r i b a l N a m e ]  
             , [ T r i b a l L a n d N a m e ]  
             , [ T r i b a l L a n d I n d i c a t o r ]  
             , [ L o c a t i o n D e s c r i p t i o n T e x t ]  
             , [ M a i l i n g F a c i l i t y S i t e N a m e ]  
             , [ M a i l i n g A d d r e s s T e x t ]  
             , [ M a i l i n g S u p p l e m e n t a l A d d r e s s T e x t ]  
             , [ M a i l i n g A d d r e s s C i t y N a m e ]  
             , [ M a i l i n g S t a t e C o d e ]  
             , [ M a i l i n g S t a t e C o d e L i s t I d e n t i f i e r ]  
             , [ M a i l i n g S t a t e N a m e ]  
             , [ M a i l i n g A d d r e s s P o s t a l C o d e ]  
             , [ M a i l i n g C o u n t r y C o d e ]  
             , [ M a i l i n g C o u n t r y C o d e L i s t I d e n t i f i e r ]  
             , [ M a i l i n g C o u n t r y N a m e ]  
             , [ P a r e n t C o m p a n y N a m e N A I n d i c a t o r ]  
             , [ P a r e n t C o m p a n y N a m e T e x t ]  
             , [ P a r e n t D u n B r a d s t r e e t C o d e ]  
     F R O M   [ c m p ] . [ T 2 _ F A C _ S I T E ]  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ T 2 _ F A C _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ T 2 _ F A C _ I N D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 C R E A T E   V I E W   [ c m p ] . [ v w _ T 2 _ F A C _ I N D ]  
 A S  
 S E L E C T            
               T 2 F . [ F a c i l i t y S i t e I d e n t i f i e r ]  
             , I N D . [ I n d i v i d u a l I d e n t i f i e r ]  
             , I N D . [ I n d i v i d u a l T i t l e T e x t ]  
             , I N D . [ N a m e P r e f i x T e x t ]  
             , I N D . [ I n d i v i d u a l F u l l N a m e ]  
             , I N D . [ F i r s t N a m e ]  
             , I N D . [ M i d d l e N a m e ]  
             , I N D . [ L a s t N a m e ]  
             , I N D . [ N a m e S u f f i x T e x t ]  
             , I N D . [ M a i l i n g A d d r e s s T e x t ]  
             , I N D . [ M a i l i n g S u p p l e m e n t a l A d d r e s s T e x t ]  
             , I N D . [ M a i l i n g A d d r e s s C i t y N a m e ]  
             , I N D . [ M a i l i n g S t a t e C o d e ]  
             , I N D . [ M a i l i n g S t a t e C o d e L i s t I d e n t i f i e r ]  
             , I N D . [ M a i l i n g S t a t e N a m e ]  
             , I N D . [ M a i l i n g A d d r e s s P o s t a l C o d e ]  
             , I N D . [ M a i l i n g C o u n t r y C o d e ]  
             , I N D . [ M a i l i n g C o u n t r y C o d e L i s t I d e n t i f i e r ]  
             , I N D . [ M a i l i n g C o u n t r y N a m e ]  
     F R O M   [ c m p ] . [ T 2 _ F A C _ I N D ]   I N D  
 J O I N   [ c m p ] . [ T 2 _ F A C _ S I T E ]   T 2 F   O N   I N D . F K _ G U I D   =   T 2 F . P K _ G U I D  
  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ F R S _ A D D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ F R S _ A D D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ F R S _ A D D ]   A S  
 s e l e c t   F R S _ A D D . *  
     f r o m   c m p . F R S _ A D D  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ F R S _ A L T _ N M ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 6   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ F R S _ A L T _ N M ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ F R S _ A L T _ N M ]   A S  
 s e l e c t   F R S _ A L T _ N M . *  
     f r o m   c m p . F R S _ A L T _ N M '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ F R S _ E I _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 7   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ F R S _ E I _ I N D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ F R S _ E I _ I N D ]   A S  
 s e l e c t   F R S _ E I . S T _ F A C _ I N D  
 	 ,   A F F I L _ T Y P E  
 	 ,   A F F I L _ S T A R T _ D A T E  
 	 ,   A F F I L _ E N D _ D A T E  
 	 ,   E M A I L _ A D D  
 	 ,   T E L _ N U M  
 	 ,   P H _ E X T  
 	 ,   F A X _ N U M  
 	 ,   A L T _ T E L _ N U M  
 	 ,   I N D _ F U L L _ N M  
 	 ,   I N D _ T I T L E  
 	 ,   M A I L _ A D D  
 	 ,   S U P P L E M _ A D D  
 	 ,   M A I L _ A D D _ C I T Y _ N M  
 	 ,   M A I L _ A D D _ S T _ C D  
 	 ,   M A I L _ A D D _ S T _ N M  
 	 ,   M A I L _ A D D _ C O _ N M  
 	 ,   M A I L _ A D D _ Z I P _ C D  
     f r o m   c m p . F R S _ E I _ I N D   I N N E R   J O I N   c m p . F R S _ E I   o n   ( F R S _ E I . S T _ E I _ I N D   =   F R S _ E I _ I N D . S T _ E I _ I N D )  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ F R S _ E I _ S I C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 8   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ F R S _ E I _ S I C ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ F R S _ E I _ S I C ]   A S  
 s e l e c t   F R S _ E I . S T _ F A C _ I N D  
 	 ,   S I C _ C D  
 	 ,   S I C _ P R I M _ I N D  
     f r o m   c m p . F R S _ E I _ S I C   I N N E R   J O I N   c m p . F R S _ E I   o n   ( F R S _ E I . S T _ E I _ I N D   =   F R S _ E I _ S I C . S T _ E I _ I N D )  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ F R S _ E I _ N A I C S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 7   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ F R S _ E I _ N A I C S ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ F R S _ E I _ N A I C S ]   A S  
 s e l e c t     F R S _ E I . S T _ F A C _ I N D  
 ,   N A I C S _ C D  
 ,   N A I C S _ P R I M _ I N D  
     f r o m   c m p . F R S _ E I _ N A I C S   I N N E R   J O I N   c m p . F R S _ E I   o n   ( F R S _ E I . S T _ E I _ I N D   =   F R S _ E I _ N A I C S . S T _ E I _ I N D )  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ F R S _ E I _ O R G ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 8   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ F R S _ E I _ O R G ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ F R S _ E I _ O R G ]   A S  
 s e l e c t       F R S _ E I . S T _ F A C _ I N D  
 	 ,   A F F I L _ T Y P E  
 	 ,   A F F I L _ S T A R T _ D A T E  
 	 ,   A F F I L _ E N D _ D A T E  
 	 ,   E M A I L _ A D D  
 	 ,   T E L _ N U M  
 	 ,   P H _ E X T  
 	 ,   F A X _ N U M  
 	 ,   A L T _ T E L _ N U M  
 	 ,   O R G _ F O R M A L _ N M  
 	 ,   O R G _ D U N S _ N U M  
 	 ,   O R G _ T Y P E  
 	 ,   E M P L O Y E R _ I N D  
 	 ,   S T _ B U S I N E S S _ I N D  
 	 ,   U L T _ P A R E N T _ N M  
 	 ,   U L T _ P A R E N T _ D U N S _ N U M  
 	 ,   M A I L _ A D D  
 	 ,   S U P P L E M _ A D D  
 	 ,   M A I L _ A D D _ C I T Y _ N M  
 	 ,   M A I L _ A D D _ S T _ C D  
 	 ,   M A I L _ A D D _ S T _ N M  
 	 ,   M A I L _ A D D _ C O _ N M  
 	 ,   M A I L _ A D D _ Z I P _ C D  
     f r o m   c m p . F R S _ E I _ O R G   I N N E R   J O I N   c m p . F R S _ E I   o n   ( F R S _ E I . S T _ E I _ I N D   =   F R S _ E I _ O R G . S T _ E I _ I N D )  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ F R S _ E I ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 7   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ F R S _ E I ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ F R S _ E I ]   A S  
 S E L E C T   S T _ F A C _ I N D  
 	   ,   I N F _ S Y S _ A C  
 	   ,   I N F _ S Y S _ I N D  
 	   ,   E N V _ I N T _ T Y P E  
 	   ,   F E D _ S T _ I N T  
 	   ,   E N V _ I N T _ S T A R T _ D A T E  
 	   ,   I N T _ S T A R T _ D A T E _ Q U A L  
 	   ,   E N V _ I N T _ E N D _ D A T E  
 	   ,   I N T _ E N D _ D A T E _ Q U A L  
     F R O M   c m p . F R S _ E I   '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ F R S _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 9   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ F R S _ F A C ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ F R S _ F A C ]   A S  
 s e l e c t   S T _ F A C _ I N D  
 	 ,   F A C _ R E G _ I N D  
 	 ,   F A C _ S I T E N M  
 	 ,   F A C _ S I T E T Y P E _ N M  
 	 ,   F E D _ F A C  
 	 ,   T R I B _ L A N D  
 	 ,   T R I B _ L A N D _ N M  
 	 ,   C O N G _ D I S T _ N U M  
 	 ,   L E G _ D I S T _ N U M  
 	 ,   H U C _ C D  
 	 ,   L O C _ A D D  
 	 ,   S U P P L E M _ L O C  
 	 ,   L O C A L _ N M  
 	 ,   C N T Y _ S T _ F I P S _ C D  
 	 ,   C N T Y _ N M  
 	 ,   S T _ C D  
 	 ,   S T _ N M  
 	 ,   C O _ N M  
 	 ,   L O C _ Z I P _ C D  
 	 ,   L O C _ D E S C  
 	 ,   D A T A _ S R C _ N M  
 	 - - ,   R E P O R T E D _ D A T E   ( R e m o v e d :     C a u s e s   a l l   f a c i l i t i e s   t o   b e   s e n t   i n   H E R E   c h a n g e   p r o c e s s i n g )  
 	 ,   S T _ F A C _ S Y S _ A C  
     f r o m   c m p . F R S _ F A C   '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ F R S _ F A C _ D E L ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 9   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ F R S _ F A C _ D E L ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ F R S _ F A C _ D E L ]   A S  
 s e l e c t   F R S _ F A C _ D E L . *  
     f r o m   c m p . F R S _ F A C _ D E L    
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ F R S _ F A C _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 2 9   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ F R S _ F A C _ I N D ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ F R S _ F A C _ I N D ]   A S  
 s e l e c t   S T _ F A C _ I N D  
 	 ,   A F F I L _ T Y P E  
 	 ,   A F F I L _ S T A R T _ D A T E  
 	 ,   A F F I L _ E N D _ D A T E  
 	 ,   E M A I L _ A D D  
 	 ,   T E L _ N U M  
 	 ,   P H _ E X T  
 	 ,   F A X _ N U M  
 	 ,   A L T _ T E L _ N U M  
 	 ,   I N D _ F U L L _ N M  
 	 ,   I N D _ T I T L E  
 	 ,   M A I L _ A D D  
 	 ,   S U P P L E M _ A D D  
 	 ,   M A I L _ A D D _ C I T Y _ N M  
 	 ,   M A I L _ A D D _ S T _ C D  
 	 ,   M A I L _ A D D _ S T _ N M  
 	 ,   M A I L _ A D D _ C O _ N M  
 	 ,   M A I L _ A D D _ Z I P _ C D  
     f r o m   c m p . F R S _ F A C _ I N D    
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ F R S _ F A C _ N A I C S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ F R S _ F A C _ N A I C S ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ F R S _ F A C _ N A I C S ]   A S  
 s e l e c t   S T _ F A C _ I N D  
           ,   N A I C S _ C D  
           ,   N A I C S _ P R I M _ I N D  
     f r o m   c m p . F R S _ F A C _ N A I C S    
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ F R S _ F A C _ O R G ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ F R S _ F A C _ O R G ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ F R S _ F A C _ O R G ]   A S  
 s e l e c t   S T _ F A C _ I N D  
 	 ,   A F F I L _ T Y P E  
 	 ,   A F F I L _ S T A R T _ D A T E  
 	 ,   A F F I L _ E N D _ D A T E  
 	 ,   E M A I L _ A D D  
 	 ,   T E L _ N U M  
 	 ,   P H _ E X T  
 	 ,   F A X _ N U M  
 	 ,   A L T _ T E L _ N U M  
 	 ,   O R G _ F O R M A L _ N M  
 	 ,   O R G _ D U N S _ N U M  
 	 ,   O R G _ T Y P E  
 	 ,   E M P L O Y E R _ I N D  
 	 ,   S T _ B U S I N E S S _ I N D  
 	 ,   U L T _ P A R E N T _ N M  
 	 ,   U L T _ P A R E N T _ D U N S _ N U M  
 	 ,   M A I L _ A D D  
 	 ,   S U P P L E M _ A D D  
 	 ,   M A I L _ A D D _ C I T Y _ N M  
 	 ,   M A I L _ A D D _ S T _ C D  
 	 ,   M A I L _ A D D _ S T _ N M  
 	 ,   M A I L _ A D D _ C O _ N M  
 	 ,   M A I L _ A D D _ Z I P _ C D  
     f r o m   c m p . F R S _ F A C _ O R G    
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ F R S _ F A C _ S I C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ F R S _ F A C _ S I C ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ F R S _ F A C _ S I C ]   A S  
 s e l e c t   S T _ F A C _ I N D  
 	 ,   S I C _ C D  
 	 ,   S I C _ P R I M _ I N D  
     f r o m   c m p . F R S _ F A C _ S I C    
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ c m p ] . [ v w _ F R S _ G E O ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 3 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ v w _ F R S _ G E O ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ c m p ] . [ v w _ F R S _ G E O ]   A S  
 s e l e c t   F R S _ G E O . *  
     f r o m   c m p . F R S _ G E O    
 '  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ F R S _ G e t F R S B y D e l e t e D a t e ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ G e t F R S B y D e l e t e D a t e ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 M a r k   C h m a r n y  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 7 - 0 9  
 - -   D e s c r i p t i o n : 	 F R S   F l o w   d a t a   r e t r i e v a l    
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ F R S _ G e t F R S B y D e l e t e D a t e ]  
 	 @ D e l e t e D a t e   d a t e t i m e  
 A S  
 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 S E T   N O C O U N T   O N ;  
  
  
 D E C L A R E   @ f l o w T y p e   v a r c h a r ( 5 0 )  
 S E T   @ f l o w T y p e   =   ' ' H E R E - F R S ' ' ;  
  
  
 - - F R S _ F A C  
 S E L E C T 	 c . S T _ F A C _ I N D ,   C O N V E R T ( v a r c h a r ( 1 0 ) ,   c . U P D A T E _ D A T E ,   1 2 6 )   A S   D E L E T E _ D A T E ,   ' ' N E - I I S ' '   A S   F A C _ S Y S _ N A M E    
 F R O M   d b o . C H A N G E D _ F A C I L I T I E S   c  
 W H E R E   c . U P D A T E _ D A T E   > =   @ D e l e t e D a t e  
 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 A N D   c . I S _ D E L E T E D   =   1 ;  
  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ F R S _ G e t F R S D e l e t e D a t a ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 1   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ G e t F R S D e l e t e D a t a ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 M a r k   C h m a r n y  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 7 - 0 9  
 - -   D e s c r i p t i o n : 	 F R S   F l o w   d a t a   r e t r i e v a l    
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ F R S _ G e t F R S D e l e t e D a t a ]  
 	 @ D e l e t e D a t e   d a t e t i m e  
 A S  
 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 S E T   N O C O U N T   O N ;  
  
  
 D E C L A R E   @ f l o w T y p e   v a r c h a r ( 5 0 )  
 S E T   @ f l o w T y p e   =   ' ' H E R E - F R S ' ' ;  
  
 - - F R S _ F A C  
 S E L E C T 	 c . S T _ F A C _ I N D ,  
 C O N V E R T ( v a r c h a r ( 1 0 ) ,   M A X ( c . U P D A T E _ D A T E ) ,   1 2 6 )   A S   D E L E T E _ D A T E ,  
 ' ' N E - I I S ' '   A S   F A C _ S Y S _ N A M E  
  
 F R O M   d b o . C H A N G E D _ F A C I L I T I E S   c  
 W H E R E   c . U P D A T E _ D A T E   > =   @ D e l e t e D a t e  
 A N D 	 c . F L O W _ T Y P E 	 =   @ f l o w T y p e  
 A N D   c . I S _ D E L E T E D   =   1  
 G R O U P   B Y   c . S T _ F A C _ I N D ;  
  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ C H E M _ I N V ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 8   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ C H E M _ I N V ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ C H E M _ I N V ]   A S  
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ C H E M _ I N V . C h e m i c a l I d e n t i f i e r  
 ,   T 2 _ C H E M _ I N V . E H S I n d i c a t o r  
 ,   T 2 _ C H E M _ I N V . T r a d e S e c r e t I n d i c a t o r  
 ,   T 2 _ C H E M _ I N V . C A S N u m b e r  
 ,   T 2 _ C H E M _ I N V . C h e m S u b s t a n c e S y s t e m a t i c N a m e  
 ,   T 2 _ C H E M _ I N V . E P A C h e m i c a l R e g i s t r y N a m e  
 ,   T 2 _ C H E M _ I N V . E P A C h e m i c a l I d e n t i f i e r  
 ,   T 2 _ C H E M _ I N V . C h e m i c a l N a m e C o n t e x t  
  
 F R O M   d b o . T 2 _ C H E M _ I N V   I N N E R   J O I N   d b o . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ S I T E . P K _ G U I D   =   T 2 _ C H E M _ I N V . F K _ G U I D )  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ F A C _ S I T E ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ F A C _ S I T E ]   A S  
 S E L E C T  
               [ F a c i l i t y S i t e I d e n t i f i e r ]  
             , [ F a c i l i t y S i t e N a m e ]  
             , [ F a c i l i t y S t a t u s ]  
             , [ L o c a t i o n A d d r e s s T e x t ]  
             , [ S u p p l e m e n t a l L o c a t i o n T e x t ]  
             , [ L o c a l i t y N a m e ]  
             , [ S t a t e C o d e ]  
             , [ S t a t e C o d e L i s t I d e n t i f i e r ]  
             , [ S t a t e N a m e ]  
             , [ A d d r e s s P o s t a l C o d e ]  
             , [ C o u n t r y C o d e ]  
             , [ C o u n t r y C o d e L i s t I d e n t i f i e r ]  
             , [ C o u n t r y N a m e ]  
             , [ C o u n t y C o d e ]  
             , [ C o u n t y C o d e L i s t I d e n t i f i e r ]  
             , [ C o u n t y N a m e ]  
             , [ T r i b a l C o d e ]  
             , [ T r i b a l C o d e L i s t I d e n t i f i e r ]  
             , [ T r i b a l N a m e ]  
             , [ T r i b a l L a n d N a m e ]  
             , [ T r i b a l L a n d I n d i c a t o r ]  
             , [ L o c a t i o n D e s c r i p t i o n T e x t ]  
             , [ M a i l i n g F a c i l i t y S i t e N a m e ]  
             , [ M a i l i n g A d d r e s s T e x t ]  
             , [ M a i l i n g S u p p l e m e n t a l A d d r e s s T e x t ]  
             , [ M a i l i n g A d d r e s s C i t y N a m e ]  
             , [ M a i l i n g S t a t e C o d e ]  
             , [ M a i l i n g S t a t e C o d e L i s t I d e n t i f i e r ]  
             , [ M a i l i n g S t a t e N a m e ]  
             , [ M a i l i n g A d d r e s s P o s t a l C o d e ]  
             , [ M a i l i n g C o u n t r y C o d e ]  
             , [ M a i l i n g C o u n t r y C o d e L i s t I d e n t i f i e r ]  
             , [ M a i l i n g C o u n t r y N a m e ]  
             , [ P a r e n t C o m p a n y N a m e N A I n d i c a t o r ]  
             , [ P a r e n t C o m p a n y N a m e T e x t ]  
             , [ P a r e n t D u n B r a d s t r e e t C o d e ]  
     F R O M   [ d b o ] . [ T 2 _ F A C _ S I T E ]  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 4 8   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 C R E A T E   V I E W   [ d b o ] . [ v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y ]  
  
 A S  
 S E L E C T  
  
 C O N V E R T ( V A R C H A R , F A C I D )  
 +   I S N U L L ( L T R I M ( R T R I M ( F A C N A M ) ) ,   ' ' ' ' )  
 +   C O N V E R T ( V A R C H A R ,   I S N U L L ( C A S N O ,   0 ) )  
 +   I S N U L L ( L T R I M ( R T R I M ( R P T N A M ) ) ,   ' ' ' ' )  
 +   C O N V E R T ( V A R C H A R ,   I S N U L L ( M A X M N T ,   0 ) )  
 +   C O N V E R T ( V A R C H A R ,   I S N U L L ( A V G M N T ,   0 ) )  
 +   C O N V E R T ( V A R C H A R ,   I S N U L L ( C H E M I D ,   0 ) )  
 +   I S N U L L ( L T R I M ( R T R I M ( C H M S R T ) ) ,   ' ' ' ' )  
 +   C O N V E R T ( V A R C H A R ,   I S N U L L ( A C T A V G ,   0 ) )  
 +   C O N V E R T ( V A R C H A R ,   I S N U L L ( A C T M A X ,   0 ) )  
 +   I S N U L L ( D E L ,   ' ' ' ' )  
 +   I S N U L L ( F I R E ,   ' ' ' ' )  
 +   I S N U L L ( G A S ,   ' ' ' ' )  
 +   I S N U L L ( I M M ,   ' ' ' ' )  
 +   I S N U L L ( L I Q U I D ,   ' ' ' ' )  
 +   I S N U L L ( M I X ,   ' ' ' ' )  
 +   I S N U L L ( P U R E ,   ' ' ' ' )  
 +   I S N U L L ( R E A C ,   ' ' ' ' )  
 +   I S N U L L ( S O L I D ,   ' ' ' ' )  
 +   C O N V E R T ( V A R C H A R ,   I S N U L L ( S T D A Y S ,   0 ) )  
 +   I S N U L L ( S U D R E L ,   ' ' ' ' )  
 +   I S N U L L ( T R D S E C ,   ' ' ' ' )  
 +   I S N U L L ( Y R ,   ' ' ' ' )   A S   C h e m U n i q u e K e y  
  
 , F A C I D  
 , F A C N A M  
 , C A S N O  
 , R P T N A M  
 , S T O R L C  
 , M A X M N T  
 , A V G M N T  
 , C H E M I D  
 , C H M S R T  
 , A C T A V G  
 , A C T M A X  
 , C D A T E  
 , C O N F  
 , D E L  
 , F I R E  
 , G A S  
 , I M M  
 , L I Q U I D  
 , M I X  
 , M O D S Q  
 , M O D Y R  
 , P R S S R E  
 , P U R E  
 , R E A C  
 , S O L I D  
 , S T D A Y S  
 , S T O R C D  
 , S U D R E L  
 , T E M P C D  
 , T R D S E C  
 , U S E R I D  
 , Y R  
  
 F R O M   [ d b o ] . [ N E _ T i e r I I _ C h e m i c a l s ]  
 '  
 G O  
 / * * * * * *   O b j e c t :     V i e w   [ d b o ] . [ v w _ T 2 _ C H E M _ L O C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 5 0   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . v i e w s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ v w _ T 2 _ C H E M _ L O C ] ' ) )  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N ' C R E A T E   V I E W   [ d b o ] . [ v w _ T 2 _ C H E M _ L O C ]   A S    
 S E L E C T   t 2 _ f a c _ s i t e . F a c i l i t y S i t e I d e n t i f i e r  
 ,   T 2 _ C H E M _ L O C . C o n f i d e n t i a l L o c a t i o n I n d i c a t o r  
 ,   T 2 _ C H E M _ L O C . S t o r a g e T y p e C o d e  
 ,   T 2 _ C H E M _ L O C . S t o r a g e T y p e D e s c r i p t i o n  
 ,   T 2 _ C H E M _ L O C . S t o r a g e L o c T e m p e r a t u r e C o d e  
 ,   T 2 _ C H E M _ L O C . S t o r a g e L o c T e m p e r a t u r e D e s c  
 ,   T 2 _ C H E M _ L O C . S t o r a g e L o c P r e s s u r e C o d e  
 ,   T 2 _ C H E M _ L O C . S t o r a g e L o c P r e s s u r e D e s c  
 ,   T 2 _ C H E M _ L O C . S t o r a g e L o c D e s c r i p t i o n  
 ,   T 2 _ C H E M _ L O C . M a x i m u m A m o u n t A t L o c a t i o n  
 ,   T 2 _ C H E M _ L O C . M e a s u r e m e n t U n i t  
 F R O M   d b o . T 2 _ C H E M _ L O C   I N N E R   J O I N   d b o . T 2 _ C H E M _ I N V   O N   ( T 2 _ C H E M _ L O C . F K _ G U I D   =   T 2 _ C H E M _ I N V . P K _ G U I D )   I N N E R   J O I N   d b o . T 2 _ F A C _ S I T E   O N   ( T 2 _ F A C _ S I T E . P K _ G U I D   =   T 2 _ C H E M _ I N V . F K _ G U I D )  
 '  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ N E _ T I E R 2 _ L O A D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ N E _ T I E R 2 _ L O A D ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 T K   C o n r a d   ( W i n d s o r   S o l u t i o n s ,   I n c . )  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 6 - 1 8  
 - -   D e s c r i p t i o n : 	 I n s e r t ' ' s   N e b r a s k a   T i e r   I I   d a t a   i n t o   t h e   s c h e m a   t a b l e s   f o r   X M L   f i l e   c r e a t i o n  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ N E _ T I E R 2 _ L O A D ]   @ v a l u e   I N T   O U T P U T  
 	 - -   A d d   t h e   p a r a m e t e r s   f o r   t h e   s t o r e d   p r o c e d u r e   h e r e  
 A S  
 B E G I N  
 	 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 	 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 	 S E T   N O C O U N T   O N ;  
  
         - -   I n s e r t   s t a t e m e n t s   f o r   p r o c e d u r e   h e r e  
  
 - -   d e c l a r e   l o c a l   v a r i a b l e s  
  
 D E C L A R E   @ S t a r t D a t e 	 V A R C H A R ( 2 5 )  
 D E C L A R E   @ E n d D a t e 	 V A R C H A R ( 2 5 )  
 D E C L A R E   @ D u e D a t e 	 V A R C H A R ( 2 5 )  
 D E C L A R E   @ E R R O R _ C O D E   I N T  
  
 - -   s e t   c o n s t a n t s  
  
 S E T   @ S t a r t D a t e   =   ' ' 1 / 1 ' '  
 S E T   @ E n d D a t e   =   ' ' 1 2 / 3 1 ' '  
 S E T   @ D u e D a t e   =   ' ' 1 / 1 ' '  
  
 - -   r e m o v e   a l l   p r e v i o u s   r e c o r d s   i n   t h e   T 2   h i e r a r c h y  
  
         - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
         - -   D E L E T E   F A C I L I T I E S :     A s s o c i a t e d   r e c o r d s   a r e   c a s c a d e - d e l e t e d   - -  
         - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 D E L E T E   F R O M   [ d b o ] . [ T 2 _ S U B M I S S I O N ]  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     [ T 2 _ S U B M I S S I O N ]     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ d b o ] . [ T 2 _ S U B M I S S I O N ]  
           V A L U E S  
                       ( N e w I d ( )   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
                       , N e w I d ( )   - -   < S u b m i s s i o n I d e n t i f i e r ,   v a r c h a r ( 3 6 ) , >  
                       , L E F T ( C O N V E R T ( V A R C H A R ,   G E T D A T E ( ) ,   1 2 6 ) ,   1 0 )   - -   < S u b m i s s i o n D a t e ,   v a r c h a r ( 2 5 ) , >  
                       , N U L L   - -   < S u b m i s s i o n S t a t u s ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   - -   < S u b m i s s i o n M e t h o d ,   v a r c h a r ( 2 5 5 ) , >  
                       )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     [ T 2 _ R E P O R T ]     - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ d b o ] . [ T 2 _ R E P O R T ]  
 	 S E L E C T  
                 N e w I d ( )   A S   P K _ G U I D   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
               , S . P K _ G U I D   A S   F K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
               , E I . S T _ F A C _ I N D   A S   R e p o r t I d e n t i f i e r   - -   < R e p o r t I d e n t i f i e r ,   v a r c h a r ( 2 5 5 ) , >  
               , L E F T ( C O N V E R T ( V A R C H A R ,   ( C O N V E R T ( D A T E T I M E ,   @ D u e D a t e   +   ' ' / ' '   +   C O N V E R T ( V A R C H A R ,   C O N V E R T ( I N T ,   C . Y R )   +   1 ) ) ) ,   1 2 6 ) ,   1 0 )   A S   R e p o r t D u e D a t e   - -   < R e p o r t D u e D a t e ,   v a r c h a r ( 2 5 ) , >  
               , N U L L   A S   R e p o r t R e c e i v e d D a t e   - -   < R e p o r t R e c e i v e d D a t e ,   v a r c h a r ( 2 5 ) , >  
               , N U L L   A S   R e p o r t R e c i p i e n t N a m e   - -   < R e p o r t R e c i p i e n t N a m e ,   v a r c h a r ( 2 5 5 ) , >  
               , L E F T ( C O N V E R T ( V A R C H A R ,   ( C O N V E R T ( D A T E T I M E ,   @ S t a r t D a t e   +   ' ' / ' '   +   C . Y R ) ) ,   1 2 6 ) ,   1 0 )   A S   R e p o r t i n g P e r i o d S t a r t D a t e   - -   < R e p o r t i n g P e r i o d S t a r t D a t e ,   v a r c h a r ( 2 5 ) , >  
               , L E F T ( C O N V E R T ( V A R C H A R ,   ( C O N V E R T ( D A T E T I M E ,   @ E n d D a t e   +   ' ' / ' '   +   C . Y R ) ) ,   1 2 6 ) ,   1 0 )   A S   R e p o r t i n g P e r i o d E n d D a t e   - -   < R e p o r t i n g P e r i o d E n d D a t e ,   v a r c h a r ( 2 5 ) , >  
               , N U L L   A S   R e v i s i o n I n d i c a t o r   - -   < R e v i s i o n I n d i c a t o r ,   v a r c h a r ( 2 5 5 ) , >  
               , N U L L   A S   R e p l a c e d R e p o r t I d e n t i f i e r   - -   < R e p l a c e d R e p o r t I d e n t i f i e r ,   v a r c h a r ( 2 5 5 ) , >  
               , N U L L   A S   R e p o r t C r e a t e B y N a m e   - -   < R e p o r t C r e a t e B y N a m e ,   v a r c h a r ( 2 5 5 ) , >  
               , L E F T ( C O N V E R T ( V A R C H A R ,   G E T D A T E ( ) ,   1 2 6 ) ,   1 0 )   A S   R e p o r t C r e a t e D a t e   - -   < R e p o r t C r e a t e D a t e ,   v a r c h a r ( 2 5 ) , >  
               , R I G H T ( C O N V E R T ( V A R C H A R ,   G E T D A T E ( ) ,   1 2 6 ) ,   1 2 )   A S   R e p o r t C r e a t e T i m e   - -   < R e p o r t C r e a t e T i m e ,   v a r c h a r ( 2 5 ) , >  
               , N U L L   A S   R e p o r t T y p e   - -   < R e p o r t T y p e ,   v a r c h a r ( 2 5 5 ) , > )  
 F R O M   [ d b o ] . [ T 2 _ S U B M I S S I O N ]   S ,  
 d b o . F R S _ E I   E I  
 J O I N   d b o . v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y   C   O N   E I . S T _ F A C _ I N D   =   C O N V E R T ( V A R C H A R ,   C . F A C I D )  
 W H E R E  
  
 - -   l i m i t   t o   o n l y   t h e   m o s t   r e c e n t   r e p o r t i n g   y e a r   p e r   f a c i l i t y  
  
 	 C . Y R   =  
 	 	 (  
 	 	 S E L E C T   M A X ( C 2 . Y R )  
 	 	 F R O M   d b o . v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y   C 2  
 	 	 W H E R E   C 2 . F A C I D   =   C . F A C I D  
 	 	 )  
 	 A N D   Y E A R ( G E T D A T E ( ) )   -   C O N V E R T ( I N T ,   C . Y R )   <   4  
  
 - -   a n d   o n l y   t h e   T i t l e   3   p r o g r a m   ( e . g . ,   T i e r   I I )  
  
 A N D   E I . E N V _ I N T _ T Y P E   =   ' ' T L 3 ' '  
  
 G R O U P   B Y  
 	 S . P K _ G U I D  
 , 	 C . Y R  
 , 	 E I . S T _ F A C _ I N D  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     d b o . T 2 _ F A C _ S I T E   - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
  
 I N S E R T   I N T O   [ d b o ] . [ T 2 _ F A C _ S I T E ]  
 S E L E C T  
                         N e w I d ( )   A S   P K _ G U I D   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
                       , R . P K _ G U I D   A S   F K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
                       , E I . S T _ F A C _ I N D   A S   F a c i l i t y S i t e I d e n t i f i e r   - -   < F a c i l i t y S i t e I d e n t i f i e r ,   v a r c h a r ( 2 5 5 ) , >  
                       , F A C . F A C _ S I T E N M   A S   F a c i l i t y S i t e N a m e   - -   < F a c i l i t y S i t e N a m e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   F a c i l i t y S t a t u s   - -   < F a c i l i t y S t a t u s ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   L o c a t i o n A d d r e s s T e x t   - -   < L o c a t i o n A d d r e s s T e x t ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   S u p p l e m e n t a l L o c a t i o n T e x t   - -   < S u p p l e m e n t a l L o c a t i o n T e x t ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   L o c a l i t y N a m e   - -   < L o c a l i t y N a m e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   S t a t e C o d e   - -   < S t a t e C o d e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   S t a t e C o d e L i s t I d e n t i f i e r   - -   < S t a t e C o d e L i s t I d e n t i f i e r ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   S t a t e N a m e   - -   < S t a t e N a m e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   A d d r e s s P o s t a l C o d e   - -   < A d d r e s s P o s t a l C o d e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   C o u n t r y C o d e   - -   < C o u n t r y C o d e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   C o u n t r y C o d e L i s t I d e n t i f i e r   - -   < C o u n t r y C o d e L i s t I d e n t i f i e r ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   C o u n t r y N a m e   - -   < C o u n t r y N a m e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   C o u n t y C o d e   - -   < C o u n t y C o d e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   C o u n t y C o d e L i s t I d e n t i f i e r   - -   < C o u n t y C o d e L i s t I d e n t i f i e r ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   C o u n t y N a m e   - -   < C o u n t y N a m e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   T r i b a l C o d e   - -   < T r i b a l C o d e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   T r i b a l C o d e L i s t I d e n t i f i e r   - -   < T r i b a l C o d e L i s t I d e n t i f i e r ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   T r i b a l N a m e   - -   < T r i b a l N a m e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   T r i b a l L a n d N a m e   - -   < T r i b a l L a n d N a m e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   T r i b a l L a n d I n d i c a t o r   - -   < T r i b a l L a n d I n d i c a t o r ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   L o c a t i o n D e s c r i p t i o n T e x t   - -   < L o c a t i o n D e s c r i p t i o n T e x t ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   M a i l i n g F a c i l i t y S i t e N a m e   - -   < M a i l i n g F a c i l i t y S i t e N a m e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   M a i l i n g A d d r e s s T e x t   - -   < M a i l i n g A d d r e s s T e x t ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   M a i l i n g S u p p l e m e n t a l A d d r e s s T e x t   - -   < M a i l i n g S u p p l e m e n t a l A d d r e s s T e x t ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   M a i l i n g A d d r e s s C i t y N a m e   - -   < M a i l i n g A d d r e s s C i t y N a m e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   M a i l i n g S t a t e C o d e   - -   < M a i l i n g S t a t e C o d e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   M a i l i n g S t a t e C o d e L i s t I d e n t i f i e r   - -   < M a i l i n g S t a t e C o d e L i s t I d e n t i f i e r ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   M a i l i n g S t a t e N a m e   - -   < M a i l i n g S t a t e N a m e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   M a i l i n g A d d r e s s P o s t a l C o d e   - -   < M a i l i n g A d d r e s s P o s t a l C o d e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   M a i l i n g C o u n t r y C o d e   - -   < M a i l i n g C o u n t r y C o d e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   M a i l i n g C o u n t r y C o d e L i s t I d e n t i f i e r   - -   < M a i l i n g C o u n t r y C o d e L i s t I d e n t i f i e r ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   M a i l i n g C o u n t r y N a m e   - -   < M a i l i n g C o u n t r y N a m e ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   P a r e n t C o m p a n y N a m e N A I n d i c a t o r   - -   < P a r e n t C o m p a n y N a m e N A I n d i c a t o r ,   v a r c h a r ( 1 ) , >  
                       , N U L L   A S   P a r e n t C o m p a n y N a m e T e x t   - -   < P a r e n t C o m p a n y N a m e T e x t ,   v a r c h a r ( 2 5 5 ) , >  
                       , N U L L   A S   P a r e n t D u n B r a d s t r e e t C o d e   - -   < P a r e n t D u n B r a d s t r e e t C o d e ,   v a r c h a r ( 2 5 5 ) , > )  
  
 F R O M   d b o . F R S _ F A C   F A C  
 J O I N   d b o . F R S _ E I   E I   O N   F A C . S T _ F A C _ I N D   =   E I . S T _ F A C _ I N D  
 J O I N   d b o . v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y   C   O N   E I . S T _ F A C _ I N D   =   C O N V E R T ( V A R C H A R ,   C . F A C I D )  
 J O I N   d b o . T 2 _ R E P O R T   R   O N  
 	 C . Y R   =   Y E A R ( R . R e p o r t i n g P e r i o d E n d D a t e )  
 A N D 	 R . R e p o r t I d e n t i f i e r   =   C O N V E R T ( V A R C H A R ,   C . F A C I D )    
  
 W H E R E   E I . E N V _ I N T _ T Y P E   =   ' ' T L 3 ' '  
  
 G R O U P   B Y  
 	 R . P K _ G U I D  
 , 	 E I . S T _ F A C _ I N D  
 , 	 F A C . F A C _ S I T E N M  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     d b o . T 2 _ C H E M _ I N V   - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
  
 I N S E R T   I N T O   [ d b o ] . [ T 2 _ C H E M _ I N V ]  
 S E L E C T  
 	 P K _ G U I D  
 , 	 F K _ G U I D  
 , 	 C h e m i c a l I d e n t i f i e r  
 , 	 E H S I n d i c a t o r  
 , 	 T r a d e S e c r e t I n d i c a t o r  
 , 	 C A S E   W H E N   C A S N u m b e r   =   0   T H E N   N U L L   E L S E   C A S N u m b e r   E N D   A S   C A S N u m b e r  
 , 	 C A S E   W H E N   L E N ( C h e m S u b s t a n c e S y s t e m a t i c N a m e )   =   0   T H E N   N U L L   E L S E   C h e m S u b s t a n c e S y s t e m a t i c N a m e   E N D   A S   C h e m S u b s t a n c e S y s t e m a t i c N a m e  
 , 	 C A S E   W H E N   L E N ( E P A C h e m i c a l R e g i s t r y N a m e )   =   0   T H E N   N U L L   E L S E   E P A C h e m i c a l R e g i s t r y N a m e   E N D   A S   E P A C h e m i c a l R e g i s t r y N a m e  
 , 	 C A S E   W H E N   L E N ( E P A C h e m i c a l I d e n t i f i e r )   =   0   T H E N   N U L L   E L S E   E P A C h e m i c a l I d e n t i f i e r   E N D   A S   E P A C h e m i c a l I d e n t i f i e r  
 , 	 C A S E   W H E N   L E N ( C h e m i c a l N a m e C o n t e x t )   =   0   T H E N   N U L L   E L S E   C h e m i c a l N a m e C o n t e x t   E N D   A S   C h e m i c a l N a m e C o n t e x t  
  
 F R O M  
 	 (  
 	 S E L E C T  
 	 	 	 	 N e w I d ( )   A S   P K _ G U I D   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	       , F . P K _ G U I D   A S   F K _ G U I D   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	       , C H E M . C h e m U n i q u e K e y   A S   C h e m i c a l I d e n t i f i e r   - -   < C h e m i c a l I d e n t i f i e r ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , ' ' N ' '   A S   E H S I n d i c a t o r   - -   < E H S I n d i c a t o r ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , C A S E   W H E N   I S N U L L ( C H E M . T R D S E C , ' ' ' ' )   =   ' ' Y ' '   T H E N   ' ' Y ' '   E L S E   ' ' N ' '   E N D   A S   T r a d e S e c r e t I n d i c a t o r   - -   < T r a d e S e c r e t I n d i c a t o r ,   v a r c h a r ( 2 5 5 ) , > )  
 	 	 	       , C H E M . C A S N O   A S   C A S N u m b e r   - -   < C A S N u m b e r ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , L T R I M ( R T R I M ( C H E M . R P T N A M ) )   A S   C h e m S u b s t a n c e S y s t e m a t i c N a m e   - -   < C h e m S u b s t a n c e S y s t e m a t i c N a m e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , L T R I M ( R T R I M ( C H E M . C H M S R T ) )   A S   E P A C h e m i c a l R e g i s t r y N a m e   - -   < E P A C h e m i c a l R e g i s t r y N a m e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , N U L L   A S   E P A C h e m i c a l I d e n t i f i e r   - -   < E P A C h e m i c a l I d e n t i f i e r ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , N U L L   A S   C h e m i c a l N a m e C o n t e x t   - -   < C h e m i c a l N a m e C o n t e x t ,   v a r c h a r ( 2 5 5 ) , > )  
  
 	 F R O M   d b o . T 2 _ F A C _ S I T E   F  
 	 J O I N   d b o . v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y   C H E M   O N   F . F a c i l i t y S i t e I d e n t i f i e r   =   C O N V E R T ( V A R C H A R ,   C H E M . F A C I D )  
 	 J O I N   d b o . T 2 _ R E P O R T   R   O N   R . P K _ G U I D   =   F . F K _ G U I D  
 W H E R E   C H E M . Y R   =   Y E A R ( R . R e p o r t i n g P e r i o d E n d D a t e )  
  
 	 G R O U P   B Y  
 	 	 F . P K _ G U I D  
 	 , 	 C H E M . C h e m U n i q u e K e y  
 	 , 	 C H E M . T R D S E C  
 	 , 	 C H E M . C A S N O  
 	 , 	 L T R I M ( R T R I M ( C H E M . R P T N A M ) )  
 	 , 	 L T R I M ( R T R I M ( C H E M . C H M S R T ) )  
 	 )   A S   G 1  
  
 	 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     d b o . T 2 _ C H E M _ I N V _ D T L S   - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
  
 I N S E R T   I N T O   [ d b o ] . [ T 2 _ C H E M _ I N V _ D T L S ]  
 S E L E C T  
 	 P K _ G U I D  
 , 	 F K _ G U I D  
 , 	 N u m b e r O f D a y s O n s i t e  
 , 	 M a x i m u m D a i l y A m o u n t  
 , 	 C A S E   W H E N   L E N ( M a x i m u m C o d e )   =   0   T H E N   N U L L   E L S E   M a x i m u m C o d e   E N D   A S   M a x i m u m C o d e  
 , 	 A v e r a g e D a i l y A m o u n t  
 , 	 C A S E   W H E N   L E N ( A v e r a g e C o d e )   =   0   T H E N   N U L L   E L S E   A v e r a g e C o d e   E N D   A S   A v e r a g e C o d e  
 F R O M  
 	 (  
 	 S E L E C T  
 	 	 	 	 N e w I d ( )   A S   P K _ G U I D   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	       , C . P K _ G U I D   A S   F K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	       , C H E M . S T D A Y S   A S   N u m b e r O f D a y s O n s i t e   - -   < N u m b e r O f D a y s O n s i t e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , C H E M . A C T M A X   A S   M a x i m u m D a i l y A m o u n t   - -   < M a x i m u m D a i l y A m o u n t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , C A S E   W H E N   L E N ( L T R I M ( R T R I M ( C H E M . M A X M N T ) ) )   <   2   T H E N   ' ' 0 ' '   +   L T R I M ( R T R I M ( C H E M . M A X M N T ) )   E L S E   L T R I M ( R T R I M ( C H E M . M A X M N T ) )   E N D   A S   M a x i m u m C o d e   - -   < M a x i m u m C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , C H E M . A C T A V G   A S   A v e r a g e D a i l y A m o u n t   - -   < A v e r a g e D a i l y A m o u n t ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , C A S E   W H E N   L E N ( L T R I M ( R T R I M ( C H E M . A V G M N T ) ) )   <   2   T H E N   ' ' 0 ' '   +   L T R I M ( R T R I M ( C H E M . A V G M N T ) )   E L S E   L T R I M ( R T R I M ( C H E M . A V G M N T ) )   E N D   A S   A v e r a g e C o d e   - -   < A v e r a g e C o d e ,   v a r c h a r ( 2 5 5 ) , > )  
  
 	 F R O M   d b o . v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y   C H E M  
 	 J O I N   d b o . T 2 _ C H E M _ I N V   C   O N   C . C h e m i c a l I d e n t i f i e r   =   C H E M . C h e m U n i q u e K e y  
  
 	 G R O U P   B Y  
 	 	 C . P K _ G U I D  
 	 , 	 C H E M . S T D A Y S  
 	 , 	 C H E M . A C T M A X  
 	 , 	 C H E M . M A X M N T  
 	 , 	 C H E M . A C T A V G  
 	 , 	 C H E M . A V G M N T  
 	 )   A S   G 1  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     d b o . T 2 _ C H E M _ I N V _ H A Z   - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
  
 - -   F I R E  
  
 I N S E R T   I N T O   [ d b o ] . [ T 2 _ C H E M _ I N V _ H A Z ]  
 	 S E L E C T  
 	 	 	 	 N e w I d ( )   A S   P K _ G U I D   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	       , C . P K _ G U I D   A S   F K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	       , ' ' F i r e ' '   A S   H a z a r d T y p e   - -   < H a z a r d T y p e ,   v a r c h a r ( 2 5 5 ) , > )  
  
 	 F R O M   d b o . v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y   C H E M  
 	 J O I N   d b o . T 2 _ C H E M _ I N V   C   O N   C . C h e m i c a l I d e n t i f i e r   =   C H E M . C h e m U n i q u e K e y  
 	 W H E R E   C H E M . F I R E   =   ' ' Y ' '  
  
 	 G R O U P   B Y   C . P K _ G U I D  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   P R E S S U R E  
  
 I N S E R T   I N T O   [ d b o ] . [ T 2 _ C H E M _ I N V _ H A Z ]  
 	 S E L E C T  
 	 	 	 	 N e w I d ( )   A S   P K _ G U I D   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	       , C . P K _ G U I D   A S   F K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	       , ' ' P r e s s u r e ' '   A S   H a z a r d T y p e   - -   < H a z a r d T y p e ,   v a r c h a r ( 2 5 5 ) , > )  
  
 	 F R O M   d b o . v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y   C H E M  
 	 J O I N   d b o . T 2 _ C H E M _ I N V   C   O N   C . C h e m i c a l I d e n t i f i e r   =   C H E M . C h e m U n i q u e K e y  
 	 W H E R E   C H E M . S U D R E L   =   ' ' Y ' '  
  
 	 G R O U P   B Y   C . P K _ G U I D  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   R E A C T I V I T Y  
  
 I N S E R T   I N T O   [ d b o ] . [ T 2 _ C H E M _ I N V _ H A Z ]  
 	 S E L E C T  
 	 	 	 	 N e w I d ( )   A S   P K _ G U I D   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	       , C . P K _ G U I D   A S   F K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	       , ' ' R e a c t i v i t y ' '   A S   H a z a r d T y p e   - -   < H a z a r d T y p e ,   v a r c h a r ( 2 5 5 ) , > )  
  
 	 F R O M   d b o . v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y   C H E M  
 	 J O I N   d b o . T 2 _ C H E M _ I N V   C   O N   C . C h e m i c a l I d e n t i f i e r   =   C H E M . C h e m U n i q u e K e y  
 	 W H E R E   C H E M . R E A C   =   ' ' Y ' '  
  
 	 G R O U P   B Y   C . P K _ G U I D  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     d b o . T 2 _ C H E M _ I N V _ H L T H   - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
  
 - -   I m m e d i a t e / A c u t e  
  
 I N S E R T   I N T O   [ d b o ] . [ T 2 _ C H E M _ I N V _ H L T H ]  
 	 S E L E C T  
 	 	 	 	 N e w I d ( )   A S   P K _ G U I D   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	       , C . P K _ G U I D   A S   F K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	       , ' ' I m m e d i a t e / A c u t e ' '   A S   H e a l t h E f f e c t s   - -   < H e a l t h E f f e c t s ,   v a r c h a r ( 2 5 5 ) , > )  
  
 	 F R O M   d b o . v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y   C H E M  
 	 J O I N   d b o . T 2 _ C H E M _ I N V   C   O N   C . C h e m i c a l I d e n t i f i e r   =   C H E M . C h e m U n i q u e K e y  
 	 W H E R E   C H E M . I M M   =   ' ' Y ' '  
  
 	 G R O U P   B Y   C . P K _ G U I D  
  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   D e l a y e d / C h r o n i c  
  
 I N S E R T   I N T O   [ d b o ] . [ T 2 _ C H E M _ I N V _ H L T H ]  
 S E L E C T  
                         N e w I d ( )   A S   P K _ G U I D   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
                       , C . P K _ G U I D   A S   F K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
                       , ' ' D e l a y e d / C h r o n i c ' '   A S   H e a l t h E f f e c t s   - -   < H e a l t h E f f e c t s ,   v a r c h a r ( 2 5 5 ) , > )  
  
 F R O M   d b o . v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y   C H E M  
 J O I N   d b o . T 2 _ C H E M _ I N V   C   O N   C . C h e m i c a l I d e n t i f i e r   =   C H E M . C h e m U n i q u e K e y  
 W H E R E   C H E M . D E L   =   ' ' Y ' '  
  
 G R O U P   B Y   C . P K _ G U I D  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     d b o . T 2 _ C H E M _ I N V _ P H Y S   - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
  
 - -   P u r e  
  
 I N S E R T   I N T O   [ d b o ] . [ T 2 _ C H E M _ I N V _ P H Y S ]  
 S E L E C T  
                         N e w I d ( )   A S   P K _ G U I D   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
                       , C . P K _ G U I D   A S   F K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
                       , ' ' P u r e ' '   A S   C h e m i c a l P h y s i c a l S t a t e   - -   < C h e m i c a l P h y s i c a l S t a t e ,   v a r c h a r ( 2 5 5 ) , > )  
  
 F R O M   d b o . v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y   C H E M  
 J O I N   d b o . T 2 _ C H E M _ I N V   C   O N   C . C h e m i c a l I d e n t i f i e r   =   C H E M . C h e m U n i q u e K e y  
 W H E R E   C H E M . P U R E   =   ' ' Y ' '  
  
 G R O U P   B Y   C . P K _ G U I D  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   M i x  
  
 I N S E R T   I N T O   [ d b o ] . [ T 2 _ C H E M _ I N V _ P H Y S ]  
 S E L E C T  
                         N e w I d ( )   A S   P K _ G U I D   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
                       , C . P K _ G U I D   A S   F K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
                       , ' ' M i x ' '   A S   C h e m i c a l P h y s i c a l S t a t e   - -   < C h e m i c a l P h y s i c a l S t a t e ,   v a r c h a r ( 2 5 5 ) , > )  
  
 F R O M   d b o . v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y   C H E M  
 J O I N   d b o . T 2 _ C H E M _ I N V   C   O N   C . C h e m i c a l I d e n t i f i e r   =   C H E M . C h e m U n i q u e K e y  
 W H E R E   C H E M . M I X   =   ' ' Y ' '  
  
 G R O U P   B Y   C . P K _ G U I D  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   S o l i d  
  
 I N S E R T   I N T O   [ d b o ] . [ T 2 _ C H E M _ I N V _ P H Y S ]  
 S E L E C T  
                         N e w I d ( )   A S   P K _ G U I D   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
                       , C . P K _ G U I D   A S   F K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
                       , ' ' S o l i d ' '   A S   C h e m i c a l P h y s i c a l S t a t e   - -   < C h e m i c a l P h y s i c a l S t a t e ,   v a r c h a r ( 2 5 5 ) , > )  
  
 F R O M   d b o . v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y   C H E M  
 J O I N   d b o . T 2 _ C H E M _ I N V   C   O N   C . C h e m i c a l I d e n t i f i e r   =   C H E M . C h e m U n i q u e K e y  
 W H E R E   C H E M . S O L I D   =   ' ' Y ' '  
  
 G R O U P   B Y   C . P K _ G U I D  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   L i q u i d  
  
 I N S E R T   I N T O   [ d b o ] . [ T 2 _ C H E M _ I N V _ P H Y S ]  
 S E L E C T  
                         N e w I d ( )   A S   P K _ G U I D   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
                       , C . P K _ G U I D   A S   F K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
                       , ' ' L i q u i d ' '   A S   C h e m i c a l P h y s i c a l S t a t e   - -   < C h e m i c a l P h y s i c a l S t a t e ,   v a r c h a r ( 2 5 5 ) , > )  
  
 F R O M   d b o . v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y   C H E M  
 J O I N   d b o . T 2 _ C H E M _ I N V   C   O N   C . C h e m i c a l I d e n t i f i e r   =   C H E M . C h e m U n i q u e K e y  
 W H E R E   C H E M . L I Q U I D   =   ' ' Y ' '  
  
 G R O U P   B Y   C . P K _ G U I D  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 - -   G a s  
  
 I N S E R T   I N T O   [ d b o ] . [ T 2 _ C H E M _ I N V _ P H Y S ]  
 S E L E C T  
                         N e w I d ( )   A S   P K _ G U I D   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
                       , C . P K _ G U I D   A S   F K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
                       , ' ' G a s ' '   A S   C h e m i c a l P h y s i c a l S t a t e   - -   < C h e m i c a l P h y s i c a l S t a t e ,   v a r c h a r ( 2 5 5 ) , > )  
  
 F R O M   d b o . v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y   C H E M  
 J O I N   d b o . T 2 _ C H E M _ I N V   C   O N   C . C h e m i c a l I d e n t i f i e r   =   C H E M . C h e m U n i q u e K e y  
 W H E R E   C H E M . G A S   =   ' ' Y ' '  
  
 G R O U P   B Y   C . P K _ G U I D  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     I N S E R T :     d b o . T 2 _ C H E M _ L O C   - -  
 	 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 I N S E R T   I N T O   [ d b o ] . [ T 2 _ C H E M _ L O C ]  
 S E L E C T  
 	 P K _ G U I D  
 , 	 F K _ G U I D  
 , 	 C o n f i d e n t i a l L o c a t i o n I n d i c a t o r  
 , 	 C A S E   W H E N   L E N ( S t o r a g e T y p e C o d e )   =   0   T H E N   N U L L   E L S E   S t o r a g e T y p e C o d e   E N D   A S   S t o r a g e T y p e C o d e  
 , 	 C A S E   W H E N   L E N ( S t o r a g e T y p e D e s c r i p t i o n )   =   0   T H E N   N U L L   E L S E   S t o r a g e T y p e D e s c r i p t i o n   E N D   A S   S t o r a g e T y p e D e s c r i p t i o n  
 , 	 C A S E   W H E N   L E N ( S t o r a g e L o c T e m p e r a t u r e C o d e )   =   0   T H E N   N U L L   E L S E   S t o r a g e L o c T e m p e r a t u r e C o d e   E N D   A S   S t o r a g e L o c T e m p e r a t u r e C o d e  
 , 	 C A S E   W H E N   L E N ( S t o r a g e L o c T e m p e r a t u r e D e s c )   =   0   T H E N   N U L L   E L S E   S t o r a g e L o c T e m p e r a t u r e D e s c   E N D   A S   S t o r a g e L o c T e m p e r a t u r e D e s c  
 , 	 C A S E   W H E N   L E N ( S t o r a g e L o c P r e s s u r e C o d e )   =   0   T H E N   N U L L   E L S E   S t o r a g e L o c P r e s s u r e C o d e   E N D   A S   S t o r a g e L o c P r e s s u r e C o d e  
 , 	 C A S E   W H E N   L E N ( S t o r a g e L o c P r e s s u r e D e s c )   =   0   T H E N   N U L L   E L S E   S t o r a g e L o c P r e s s u r e D e s c   E N D   A S   S t o r a g e L o c P r e s s u r e D e s c  
 , 	 C A S E   W H E N   L E N ( S t o r a g e L o c D e s c r i p t i o n )   =   0   T H E N   N U L L   E L S E   S t o r a g e L o c D e s c r i p t i o n   E N D   A S   S t o r a g e L o c D e s c r i p t i o n  
 , 	 C A S E   W H E N   L E N ( M a x i m u m A m o u n t A t L o c a t i o n )   =   0   T H E N   N U L L   E L S E   M a x i m u m A m o u n t A t L o c a t i o n   E N D   A S   M a x i m u m A m o u n t A t L o c a t i o n  
 , 	 C A S E   W H E N   L E N ( M e a s u r e m e n t U n i t )   =   0   T H E N   N U L L   E L S E   M e a s u r e m e n t U n i t   E N D   A S   M e a s u r e m e n t U n i t  
 F R O M  
 	 (  
 	 S E L E C T  
 	 	 	 	 N e w I d ( )   A S   P K _ G U I D   - -   < P K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	       , C . P K _ G U I D   A S   F K _ G U I D   - -   < F K _ G U I D ,   v a r c h a r ( 3 6 ) , >  
 	 	 	       , C A S E   W H E N   I S N U L L ( C H E M . C O N F , ' ' ' ' )   =   ' ' Y ' '   T H E N   ' ' Y ' '   E L S E   ' ' N ' '   E N D   A S   C o n f i d e n t i a l L o c a t i o n I n d i c a t o r   - -   < C o n f i d e n t i a l L o c a t i o n I n d i c a t o r ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , C H E M . S T O R C D   A S   S t o r a g e T y p e C o d e   - -   < S t o r a g e T y p e C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , N U L L   A S   S t o r a g e T y p e D e s c r i p t i o n   - -   < S t o r a g e T y p e D e s c r i p t i o n ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , C H E M . T E M P C D   A S   S t o r a g e L o c T e m p e r a t u r e C o d e   - -   < S t o r a g e L o c a t i o n T e m p e r a t u r e C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , N U L L   A S   S t o r a g e L o c T e m p e r a t u r e D e s c   - -   < S t o r a g e L o c a t i o n T e m p e r a t u r e D e s c r i p t i o n ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , C H E M . P R S S R E   S t o r a g e L o c P r e s s u r e C o d e   - -   < S t o r a g e L o c a t i o n P r e s s u r e C o d e ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , N U L L   A S   S t o r a g e L o c P r e s s u r e D e s c   - -   < S t o r a g e L o c a t i o n P r e s s u r e D e s c r i p t i o n ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , L T R I M ( R T R I M ( C H E M . S T O R L C ) )   A S   S t o r a g e L o c D e s c r i p t i o n   - -   < S t o r a g e L o c a t i o n D e s c r i p t i o n ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , N U L L   A S   M a x i m u m A m o u n t A t L o c a t i o n   - -   < M a x i m u m A m o u n t A t L o c a t i o n ,   v a r c h a r ( 2 5 5 ) , >  
 	 	 	       , N U L L   A S   M e a s u r e m e n t U n i t   - -   < M e a s u r e m e n t U n i t ,   v a r c h a r ( 2 5 5 ) , > )  
  
 	 F R O M   d b o . v w _ N E _ T i e r I I _ C h e m i c a l s _ C h e m U n i q u e K e y   C H E M  
 	 J O I N   d b o . T 2 _ C H E M _ I N V   C   O N   C . C h e m i c a l I d e n t i f i e r   =   C H E M . C h e m U n i q u e K e y  
 	 )   A S   G 1  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
  
 E N D  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ N E _ F R S _ D E L T A ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 3   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ N E _ F R S _ D E L T A ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
  
  
  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ N E _ F R S _ D E L T A ]   @ v a l u e   I N T   O U T P U T  
 A S  
  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 K e v i n   J a m e s   ( W i n d s o r   S o l u t i o n s ,   I n c . )  
 - -   C r e a t e   d a t e :   J u n e   2 0 ,   2 0 0 7  
 - -   D e s c r i p t i o n : 	 T h i s   p r o c e d u r e   w i l l   p r o c e s s e s   F R S   f a c i l i t y   d a t a   c h a n g e s  
 - -                             a n d   m a i n t a i n   t h e   f a c i l i t y   c h a n g e   c o n t r o l   t a b l e   C H A N G E D _ F A C I L I T I E S  
 - -                             f o r   t h e   S t a t e   o f   N e b r a s k a   i n   r e l a t i o n   t o   t h e   H E R E   a p p l i c a t i o n .     T h e  
 - -                             t a b l e   C H A N G E D _ F A C I L I T E S   i s   u s e d   t o   c o n t r o l   w h a t   . x m l   f i l e s   a r e   b u i l t  
 - -                             a n d   s e n t   t o   a   H E R E   c l i e n t   t o   s y n c r o n i z e   t h e   c l i e n t   w i t h   t h e   s o u r c e    
 - -                             s y s t e m s .  
 - -  
 - -   P R O C E S S I N G   F L O W :  
 - -  
 - - 	 A .     P r o c e s s   I N S E R T s :     I n s e r t   n e w   r e c o r d s   i n t o   t h e   t a b l e   C H A N G E D _ F A C I L I T E S   w h e n   a   n e w   f a c i l i y   o r    
 - -                                                 r e l a t e d   d a t a   t o   a   f a c i l i y   h a s   b e e n   a d d e d   t o   t h e   s o u r c e   s y s t e m .  
 - - 	 	 0 1 .     F R S _ A D D    
 - - 	 	 0 2 .     F R S _ A L T _ N M  
 - - 	 	 0 3 .     F R S _ E I  
 - - 	 	 0 4 .     F R S _ E I _ I N D    
 - - 	 	 0 5 .     F R S _ E I _ N A I C S  
 - - 	 	 0 6 .     F R S _ E I _ O R G  
 - - 	 	 0 7 .     F R S _ E I _ S I C  
 - - 	 	 0 8 .     F R S _ F A C  
 - - 	 	 0 9 .     F R S _ F A C _ D E L  
 - - 	 	 1 0 .     F R S _ F A C _ I N D  
 - - 	 	 1 1 .     F R S _ F A C _ N A I C S  
 - - 	 	 1 2 .     F R S _ F A C _ O R G  
 - - 	 	 1 3 .     F R S _ F A C _ S I C  
 - - 	 	 1 4 .     F R S _ G E O  
 - -  
 - - 	 B .     P r o c e s s   U P D A T E s :     U p d a t e   r e c o r d s   i n   t h e   C H A N G E D _ F A C I L I T E S   t a b l e   w h e n   d a t a   r e l a t e d   t o   a   f a c i l i t y   i s  
 - -                                                 m o d i f i e d   ( M o d i f i e d   D a t a   E l e m e n t s )   o r   w h e n   d a t a   r e l a t e d   t o   a   f a c i l i t y   i s   d e l e t e d  
 - -                                                 ( D e l e t e d   D a t a   E l e m e n t s ) .     E a c h   w i l l   t r i g g e r   t h e   e n t i r e   f a c i l i t y   d a t a s e t   t o   b e  
 - -                                                 i n c l u d e d   i n   t h e   " d a i l y "   . x m l   f i l e .  
 - -  
 - -             - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 - -             - -     M o d i f i e d   &   D e l e t e d   D a t a   E l e m e n t s     - -  
 - -             - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 - - 	 	 0 1 .     F R S _ A D D    
 - - 	 	 0 2 .     F R S _ A L T _ N M  
 - - 	 	 0 3 .     F R S _ E I  
 - - 	 	 0 4 .     F R S _ E I _ I N D    
 - - 	 	 0 5 .     F R S _ E I _ N A I C S  
 - - 	 	 0 6 .     F R S _ E I _ O R G  
 - - 	 	 0 7 .     F R S _ E I _ S I C  
 - - 	 	 0 8 .     F R S _ F A C     ( M o d i f i e d   O n l y )  
 - - 	 	 0 9 .     F R S _ F A C _ D E L  
 - - 	 	 1 0 .     F R S _ F A C _ I N D  
 - - 	 	 1 1 .     F R S _ F A C _ N A I C S  
 - - 	 	 1 2 .     F R S _ F A C _ O R G  
 - - 	 	 1 3 .     F R S _ F A C _ S I C  
 - - 	 	 1 4 .     F R S _ G E O  
 - -          
 - - 	 C .     P r o c e s s   D E L E T E s :     S e t   a   f a c i l i t y   r e c o r d ' ' s   I S _ D E L E T E D   f l a g   i n   t h e   t a b l e   C H A N G E D _ F A C I L I T E S    
 - -                                                 t o   " D E L E T E D "   w h e n   a   f a c i l i y   i s   r e m o v e d   f r o m   t h e   s o u r c e   s y s t e m .    
 - - 	 	 0 1 .     F R S _ F A C  
 - -          
 - -   M a i n t e n a n c e   N o t e s :  
 - -   D a t e                     A n a l y s t                 D e s c r i p t i o n  
 - -   - - - - - - - - - - -       - - - - - - - - - - - - -     - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 - -   2 0 - J U N - 2 0 0 7       K J a m e s                   N e w   p r o c e d u r e  
 - -   1 9 - J U L - 2 0 0 7       K J a m e s                   A d d e d   e r r o r   c h e c k i n g   t o   s u p p o r t   t r a n s a c t i o n  
 - -                                                             b a s e d   p r o c e s s i n g   o f   H E R E   d a t a   l o a d s .  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 B E G I N  
 	 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 	 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 	 S E T   N O C O U N T   O N ;  
         D E C L A R E   @ E R R O R _ C O D E   I N T  
  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - -   P r o c e s s   I n s e r t s     - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
  
         - - - - - - - - - - - - - -  
         - -     F R S _ F A C   - -  
         - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   S T _ F A C _ I N D ,   ' ' H E R E - F R S ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ F R S _ F A C  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ F R S _ F A C )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S T _ F A C _ I N D  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' ' )  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - -  
         - -     F R S _ A D D   - -  
         - - - - - - - - - - - - - -  
             I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
             S E L E C T   D I S T I N C T   S T _ F A C _ I N D ,   ' ' H E R E - F R S ' ' ,   g e t d a t e ( ) ,   0  
                 F R O M   ( S E L E C T   *  
                                 F R O M   d b o . v w _ F R S _ A D D  
                             E X C E P T   S E L E C T   *  
                                               F R O M   c m p . v w _ F R S _ A D D )   T E M P T A B L E  
               W H E R E   N O T   E X I S T S   ( S E L E C T   1  
                                                       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
                                                     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S T _ F A C _ I N D  
                                                         A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' ' )  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - -  
         - -     F R S _ A L T _ N M   - -  
         - - - - - - - - - - - - - - - - -  
             I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
             S E L E C T   D I S T I N C T   S T _ F A C _ I N D ,   ' ' H E R E - F R S ' ' ,   g e t d a t e ( ) ,   0  
                 F R O M   ( S E L E C T   *  
                                 F R O M   d b o . v w _ F R S _ A L T _ N M  
                             E X C E P T   S E L E C T   *  
                                               F R O M   c m p . v w _ F R S _ A L T _ N M )   T E M P T A B L E  
               W H E R E   N O T   E X I S T S   ( S E L E C T   1  
                                                       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
                                                     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S T _ F A C _ I N D  
                                                         A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' ' )  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - -  
         - -     F R S _ E I   - -  
         - - - - - - - - - - - - - -  
             I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
             S E L E C T   D I S T I N C T   S T _ F A C _ I N D ,   ' ' H E R E - F R S ' ' ,   g e t d a t e ( ) ,   0  
                 F R O M   ( S E L E C T   *  
                                 F R O M   d b o . v w _ F R S _ E I  
                             E X C E P T   S E L E C T   *  
                                               F R O M   c m p . v w _ F R S _ E I )   T E M P T A B L E  
               W H E R E   N O T   E X I S T S   ( S E L E C T   1  
                                                       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
                                                     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S T _ F A C _ I N D  
                                                         A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' ' )  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - -  
         - -     F R S _ E I _ I N D   - -  
         - - - - - - - - - - - - - - - - -  
             I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
             S E L E C T   D I S T I N C T   S T _ F A C _ I N D ,   ' ' H E R E - F R S ' ' ,   g e t d a t e ( ) ,   0  
                 F R O M   ( S E L E C T   *  
                                 F R O M   d b o . v w _ F R S _ E I _ I N D  
                             E X C E P T   S E L E C T   *  
                                               F R O M   c m p . v w _ F R S _ E I _ I N D )   T E M P T A B L E  
               W H E R E   N O T   E X I S T S   ( S E L E C T   1  
                                                       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
                                                     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S T _ F A C _ I N D  
                                                         A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' ' )  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - - -  
         - -     F R S _ E I _ N A I C S   - -  
         - - - - - - - - - - - - - - - - - - -  
             I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
             S E L E C T   D I S T I N C T   S T _ F A C _ I N D ,   ' ' H E R E - F R S ' ' ,   g e t d a t e ( ) ,   0  
                 F R O M   ( S E L E C T   *  
                                 F R O M   d b o . v w _ F R S _ E I _ N A I C S  
                             E X C E P T   S E L E C T   *  
                                               F R O M   c m p . v w _ F R S _ E I _ N A I C S )   T E M P T A B L E  
               W H E R E   N O T   E X I S T S   ( S E L E C T   1  
                                                       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
                                                     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S T _ F A C _ I N D  
                                                         A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' ' )  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - -  
         - -     F R S _ E I _ O R G   - -  
         - - - - - - - - - - - - - - - - -  
             I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
             S E L E C T   D I S T I N C T   S T _ F A C _ I N D ,   ' ' H E R E - F R S ' ' ,   g e t d a t e ( ) ,   0  
                 F R O M   ( S E L E C T   *  
                                 F R O M   d b o . v w _ F R S _ E I _ O R G  
                             E X C E P T   S E L E C T   *  
                                               F R O M   c m p . v w _ F R S _ E I _ O R G )   T E M P T A B L E  
               W H E R E   N O T   E X I S T S   ( S E L E C T   1  
                                                       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
                                                     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S T _ F A C _ I N D  
                                                         A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' ' )  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - -  
         - -     F R S _ E I _ S I C   - -  
         - - - - - - - - - - - - - - - - - -  
             I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
             S E L E C T   D I S T I N C T   S T _ F A C _ I N D ,   ' ' H E R E - F R S ' ' ,   g e t d a t e ( ) ,   0  
                 F R O M   ( S E L E C T   *  
                                 F R O M   d b o . v w _ F R S _ E I _ S I C  
                             E X C E P T   S E L E C T   *  
                                               F R O M   c m p . v w _ F R S _ E I _ S I C )   T E M P T A B L E  
               W H E R E   N O T   E X I S T S   ( S E L E C T   1  
                                                       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
                                                     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S T _ F A C _ I N D  
                                                         A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' ' )  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - -  
         - -     F R S _ F A C _ D E L   - -  
         - - - - - - - - - - - - - - - - - -  
             I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
             S E L E C T   D I S T I N C T   S T _ F A C _ I N D ,   ' ' H E R E - F R S ' ' ,   g e t d a t e ( ) ,   0  
                 F R O M   ( S E L E C T   *  
                                 F R O M   d b o . v w _ F R S _ F A C _ D E L  
                             E X C E P T    
                             S E L E C T   *  
                                 F R O M   c m p . v w _ F R S _ F A C _ D E L )   T E M P T A B L E  
               W H E R E   N O T   E X I S T S   ( S E L E C T   1  
                                                       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
                                                     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S T _ F A C _ I N D  
                                                         A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' ' )  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - -  
         - -     F R S _ F A C _ I N D   - -  
         - - - - - - - - - - - - - - - - - -  
             I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
             S E L E C T   D I S T I N C T   S T _ F A C _ I N D ,   ' ' H E R E - F R S ' ' ,   g e t d a t e ( ) ,   0  
                 F R O M   ( S E L E C T   *  
                                 F R O M   d b o . v w _ F R S _ F A C _ I N D  
                             E X C E P T    
                             S E L E C T   *  
                                 F R O M   c m p . v w _ F R S _ F A C _ I N D )   T E M P T A B L E  
               W H E R E   N O T   E X I S T S   ( S E L E C T   1  
                                                       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
                                                     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S T _ F A C _ I N D  
                                                         A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' ' )  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - - - -  
         - -     F R S _ F A C _ N A I C S   - -  
         - - - - - - - - - - - - - - - - - - - -  
             I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
             S E L E C T   D I S T I N C T   S T _ F A C _ I N D ,   ' ' H E R E - F R S ' ' ,   g e t d a t e ( ) ,   0  
                 F R O M   ( S E L E C T   *  
                                 F R O M   d b o . v w _ F R S _ F A C _ N A I C S  
                             E X C E P T    
                             S E L E C T   *  
                                 F R O M   c m p . v w _ F R S _ F A C _ N A I C S )   T E M P T A B L E  
               W H E R E   N O T   E X I S T S   ( S E L E C T   1  
                                                       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
                                                     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S T _ F A C _ I N D  
                                                         A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' ' )  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - -  
         - -     F R S _ F A C _ O R G   - -  
         - - - - - - - - - - - - - - - - - -  
             I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
             S E L E C T   D I S T I N C T   S T _ F A C _ I N D ,   ' ' H E R E - F R S ' ' ,   g e t d a t e ( ) ,   0  
                 F R O M   ( S E L E C T   *  
                                 F R O M   d b o . v w _ F R S _ F A C _ O R G  
                             E X C E P T    
                             S E L E C T   *  
                                 F R O M   c m p . v w _ F R S _ F A C _ O R G )   T E M P T A B L E  
               W H E R E   N O T   E X I S T S   ( S E L E C T   1  
                                                       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
                                                     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S T _ F A C _ I N D  
                                                         A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' ' )  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - -  
         - -     F R S _ F A C _ S I C   - -  
         - - - - - - - - - - - - - - - - - -  
             I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
             S E L E C T   D I S T I N C T   S T _ F A C _ I N D ,   ' ' H E R E - F R S ' ' ,   g e t d a t e ( ) ,   0  
                 F R O M   ( S E L E C T   *  
                                 F R O M   d b o . v w _ F R S _ F A C _ S I C  
                             E X C E P T    
                             S E L E C T   *  
                                 F R O M   c m p . v w _ F R S _ F A C _ S I C )   T E M P T A B L E  
               W H E R E   N O T   E X I S T S   ( S E L E C T   1  
                                                       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
                                                     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S T _ F A C _ I N D  
                                                         A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' ' )  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - -  
         - -     F R S _ G E O   - -  
         - - - - - - - - - - - - - -  
             I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
             S E L E C T   D I S T I N C T   S T _ F A C _ I N D ,   ' ' H E R E - F R S ' ' ,   g e t d a t e ( ) ,   0  
                 F R O M   ( S E L E C T   *  
                                 F R O M   d b o . v w _ F R S _ G E O  
                             E X C E P T    
 	 	 	     S E L E C T   *  
                                 F R O M   c m p . v w _ F R S _ G E O )   T E M P T A B L E  
               W H E R E   N O T   E X I S T S   ( S E L E C T   1  
                                                       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
                                                     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S T _ F A C _ I N D  
                                                         A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' ' )  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - -   P r o c e s s   U p d a t e s     - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
     - -     M o d i f i e d   D a t a   E l e m e n t s     ( S t a g i n g   v e r s u s   C o m p a r e )     - -  
     - -     E x a m p l e :     I f   a n   i n d i v i d u a l ' ' s   n a m e   i s   u p d a t e d   f o r   a   f a c i l i t y   i n   t h e   s o u r c e  
     - -                         s y s t e m   t h e n   t h e   f o l l o w i n g   S Q L   s t a t e m e n t s   w o u l d   c a p t u r e   t h a t  
     - -                         u p d a t e .     T h e   f a c i l i t y   u p d a t e   d a t e   i s   r e s e t ,   t h e r e b y   " t r i g g e r i n g "  
     - -                         t h e   e n t i r e   f a c i l i t i e s   r e c o r d   s e t   t o   b e   a d d e d   t o   t h e   d a i l y  
     - -                         . x m l   f i l e .     T h e   e n t i r e   f a c i l i t y   r e c o r d   w o u l d   b e   r e b u i l t   i n   t h e    
     - -                         H E R E   c l i e n t ,   a n d   i n   t h e   e n d   t h e   m o d i f i e d   i n d i v i d u a l ' ' s   n a m e   w i l l   b e  
     - -                         u p d a t e d   t h e   H E R E   a p p l i c a t i o n .  
     - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
          
         - - - - - - - - - - - - - -  
         - -     F R S _ F A C   - -  
         - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S T _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ F A C  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ F A C )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ F A C  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ F A C )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - -  
         - -     F R S _ A D D   - -  
         - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S T _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ A D D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ A D D )  
                                                                                                             U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ A D D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ A D D )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - -  
         - -     F R S _ A L T _ N M   - -  
         - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S T _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ A L T _ N M  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ A L T _ N M )  
 	 	 	 	 	 	 	 	 	 	 	 	 	       U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ A L T _ N M  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ A L T _ N M )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - -  
         - -     F R S _ E I   - -  
         - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S T _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ E I  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ E I )  
                                                                                                             U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ E I  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ E I )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - -  
         - -     F R S _ E I _ I N D   - -  
         - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S T _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ E I _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ E I _ I N D )  
 	 	 	 	 	 	 	 	 	 	 	 	 	       U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ E I _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ E I _ I N D )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E  
                                                                                             )    
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - - -  
         - -     F R S _ E I _ N A I C S   - -  
         - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S T _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ E I _ N A I C S  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ E I _ N A I C S )  
 	 	 	 	 	 	 	 	 	 	 	 	 	       U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ E I _ N A I C S  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ E I _ N A I C S )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E  
                                                                                             )    
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - -  
         - -     F R S _ E I _ O R G   - -  
         - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S T _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ E I _ O R G  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ E I _ O R G )  
 	 	 	 	 	 	 	 	 	 	 	 	 	       U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ E I _ O R G  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ E I _ O R G )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E  
                                                                                             )    
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - -  
         - -     F R S _ E I _ S I C   - -  
         - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S T _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ E I _ S I C  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ E I _ S I C )  
 	 	 	 	 	 	 	 	 	 	 	 	 	       U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ E I _ S I C  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ E I _ S I C )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E  
                                                                                             )    
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - -  
         - -     F R S _ F A C _ D E L   - -  
         - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S T _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ F A C _ D E L  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ F A C _ D E L )  
 	 	 	 	 	 	 	 	 	 	 	 	 	       U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ F A C _ D E L  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ F A C _ D E L )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E  
                                                                                             )    
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - -  
         - -     F R S _ F A C _ I N D   - -  
         - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S T _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ F A C _ I N D )  
 	 	 	 	 	 	 	 	 	 	 	 	 	       U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ F A C _ I N D )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E  
                                                                                             )    
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - - - -  
         - -     F R S _ F A C _ N A I C S   - -  
         - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S T _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ F A C _ N A I C S  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ F A C _ N A I C S )  
 	 	 	 	 	 	 	 	 	 	 	 	 	       U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ F A C _ N A I C S  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ F A C _ N A I C S )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E  
                                                                                             )    
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - -  
         - -     F R S _ F A C _ O R G   - -  
         - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S T _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ F A C _ O R G  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ F A C _ O R G )  
 	 	 	 	 	 	 	 	 	 	 	 	 	       U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ F A C _ O R G  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ F A C _ O R G )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E  
                                                                                             )    
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - -  
         - -     F R S _ F A C _ S I C   - -  
         - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S T _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ F A C _ S I C  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ F A C _ S I C )  
 	 	 	 	 	 	 	 	 	 	 	 	 	       U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ F A C _ S I C  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ F A C _ S I C )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E  
                                                                                             )    
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - -  
         - -     F R S _ G E O   - -  
         - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S T _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ G E O  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ G E O )  
 	 	 	 	 	 	 	 	 	 	 	 	 	       U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ G E O  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ F R S _ G E O )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E  
                                                                                             )    
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
  
      
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - -   P r o c e s s   D e l e t e s     - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
         - - - - - - - - - - - - - - -  
         - -     F R S _ F A C     - -  
         - -     N O T E :     F R S _ F A C   i s   h a n d l e d   l a s t   f o r   a   v e r y   s p e c i f i c   r e a s o n .     A l l   " d e l e t e s "   t r i g g e r e d   b y    
         - - - - - - - - - - - - - - -  
 	 U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	       S E T   I S _ D E L E T E D   =   1  
 	           ,   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	   W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   (   S E L E C T   C M P _ T A B L E . S T _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ F R S _ F A C   C M P _ T A B L E  
 	 	 	 	 	 	 	 	 	 	 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	     F R O M   d b o . v w _ F R S _ F A C   S T G _ T A B L E  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	   W H E R E   S T G _ T A B L E . S T _ F A C _ I N D   =   C M P _ T A B L E . S T _ F A C _ I N D ) )    
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - F R S ' '     - -   I F   W E   C A R E ,   O T H E R W I S E   M A R K   A L L   D E L E T E D   R E G A R D L E S S   O F   F L O W _ T Y P E ?  
             S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 E N D  
  
  
  
  
  
  
  
  
  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ N E _ C A F O _ D E L T A ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 2   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ N E _ C A F O _ D E L T A ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
  
  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ N E _ C A F O _ D E L T A ]     @ v a l u e   I N T   O U T P U T  
  
 A S  
  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 K e v i n   J a m e s   ( W i n d s o r   S o l u t i o n s ,   I n c . )  
 - -   C r e a t e   d a t e :   J u l y   0 4 ,   2 0 0 7  
 - -   D e s c r i p t i o n : 	 T h i s   p r o c e d u r e   w i l l   p r o c e s s e s   C A F O   d a t a   c h a n g e s  
 - -                             a n d   m a i n t a i n   t h e   f a c i l i t y   c h a n g e   c o n t r o l   t a b l e   C H A N G E D _ F A C I L I T I E S  
 - -                             f o r   t h e   S t a t e   o f   N e b r a s k a   i n   r e l a t i o n   t o   t h e   H E R E   a p p l i c a t i o n .     T h e  
 - -                             t a b l e   C H A N G E D _ F A C I L I T E S   i s   u s e d   t o   c o n t r o l   w h a t   . x m l   f i l e s   a r e   b u i l t  
 - -                             a n d   s e n t   t o   a   H E R E   c l i e n t   t o   s y n c r o n i z e   t h e   c l i e n t s   w i t h   t h e s e   s o u r c e    
 - -                             s y s t e m s .  
 - -  
 - -   P R O C E S S I N G   F L O W :  
 - -  
 - - 	 A .     P r o c e s s   I N S E R T s :     I n s e r t   n e w   r e c o r d s   i n t o   t h e   t a b l e   C H A N G E D _ F A C I L I T E S   w h e n   a   n e w   f a c i l i y   o r    
 - -                                                 r e l a t e d   d a t a   t o   a   f a c i l i y   h a s   b e e n   a d d e d   t o   t h e   s o u r c e   s y s t e m .  
 - - 	 	 0 1 .     C A F O _ A D D    
 - - 	 	 0 2 .     C A F O _ A N I M A L  
 - - 	 	 0 3 .     C A F O _ F A C  
 - - 	 	 0 4 .     C A F O _ G E O    
 - - 	 	 0 5 .     C A F O _ P E R M I T  
 - - 	 	 0 6 .     C A F O _ R E G _ D T L S  
 - -  
 - - 	 B .     P r o c e s s   U P D A T E s :     U p d a t e   r e c o r d s   i n   t h e   C H A N G E D _ F A C I L I T E S   t a b l e   w h e n   d a t a   r e l a t e d   t o   a   f a c i l i t y   i s  
 - -                                                 m o d i f i e d   ( M o d i f i e d   D a t a   E l e m e n t s )   o r   w h e n   d a t a   r e l a t e d   t o   a   f a c i l i t y   i s   d e l e t e d  
 - -                                                 ( D e l e t e d   D a t a   E l e m e n t s ) .     E a c h   w i l l   t r i g g e r   t h e   e n t i r e   f a c i l i t y   d a t a s e t   t o   b e  
 - -                                                 i n c l u d e d   i n   t h e   " d a i l y "   . x m l   f i l e .  
 - -  
 - -             - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 - -             - -     M o d i f i e d   &   D e l e t e d   D a t a    
 - -             - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 - - 	 	 0 1 .     C A F O _ A D D    
 - - 	 	 0 2 .     C A F O _ A N I M A L  
 - - 	 	 0 3 .     C A F O _ F A C   ( M o d i f i e d   O n l y ! ! )  
 - - 	 	 0 4 .     C A F O _ G E O    
 - - 	 	 0 5 .     C A F O _ P E R M I T  
 - - 	 	 0 6 .     C A F O _ R E G _ D T L S  
 - - 	 	  
 - - 	 C .     P r o c e s s   D E L E T E s :     S e t   a   f a c i l i t y   r e c o r d ' ' s   I S _ D E L E T E D   f l a g   i n   t h e   t a b l e   C H A N G E D _ F A C I L I T E S    
 - -                                                 t o   " D E L E T E D "   w h e n   a   f a c i l i y   i s   r e m o v e d   f r o m   t h e   s o u r c e   s y s t e m .    
 - - 	 	 0 1 .     C A F O _ F A C    
 - -          
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 B E G I N  
     S E T   N O C O U N T   O N ;  
  
     D E C L A R E   @ E R R O R _ C O D E   I N T  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - -   P r o c e s s   I n s e r t s     - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
         - - - - - - - - - - - - - -  
         - -     C A F O _ A D D   - -  
         - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   S t a t e F a c i l i t y I D ,   ' ' H E R E - C A F O ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *   F R O M   d b o . v w _ C A F O _ A D D  
                             E X C E P T  
                             S E L E C T   *   F R O M   c m p . v w _ C A F O _ A D D  
                             )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S t a t e F a c i l i t y I D  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - C A F O ' ' )  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - -  
         - -     C A F O _ A N I M A L   - -  
         - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   S t a t e F a c i l i t y I D ,   ' ' H E R E - C A F O ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *   F R O M   d b o . v w _ C A F O _ A N I M A L  
                             E X C E P T  
                             S E L E C T   *   F R O M   c m p . v w _ C A F O _ A N I M A L  
                             )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S t a t e F a c i l i t y I D  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - C A F O ' ' )  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - -  
         - -     C A F O _ F A C   - -  
         - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   S t a t e F a c i l i t y I D ,   ' ' H E R E - C A F O ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *   F R O M   d b o . v w _ C A F O _ F A C  
                             E X C E P T  
                             S E L E C T   *   F R O M   c m p . v w _ C A F O _ F A C  
                             )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S t a t e F a c i l i t y I D  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - C A F O ' ' )  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - -  
         - -     C A F O _ G E O   - -  
         - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   S t a t e F a c i l i t y I D ,   ' ' H E R E - C A F O ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *   F R O M   d b o . v w _ C A F O _ G E O  
                             E X C E P T  
                             S E L E C T   *   F R O M   c m p . v w _ C A F O _ G E O  
                             )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S t a t e F a c i l i t y I D  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - C A F O ' ' )  
     	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - -  
         - -     C A F O _ P E R M I T   - -  
         - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   S t a t e F a c i l i t y I D ,   ' ' H E R E - C A F O ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *   F R O M   d b o . v w _ C A F O _ P E R M I T  
                             E X C E P T  
                             S E L E C T   *   F R O M   c m p . v w _ C A F O _ P E R M I T  
                             )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S t a t e F a c i l i t y I D  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - C A F O ' ' )  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - - - -  
         - -     C A F O _ R E G _ D T L S   - -  
         - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   S t a t e F a c i l i t y I D ,   ' ' H E R E - C A F O ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *   F R O M   d b o . v w _ C A F O _ R E G _ D T L S  
                             E X C E P T  
                             S E L E C T   *   F R O M   c m p . v w _ C A F O _ R E G _ D T L S  
                             )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . S t a t e F a c i l i t y I D  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - C A F O ' ' )  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - -   P r o c e s s   U p d a t e s     - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
     - -     M o d i f i e d   &   D e l e t e d   E l e m e n t s  
     - -     E x a m p l e :     I f   a n   i n d i v i d u a l ' ' s   n a m e   i s   u p d a t e d   f o r   a   f a c i l i t y   i n   t h e   s o u r c e  
     - -                         s y s t e m   t h e n   t h e   f o l l o w i n g   S Q L   s t a t e m e n t s   w o u l d   c a p t u r e   t h a t  
     - -                         u p d a t e .     T h e   f a c i l i t y   u p d a t e   d a t e   i s   r e s e t ,   t h e r e b y   " t r i g g e r i n g "  
     - -                         t h e   e n t i r e   f a c i l i t i e s   r e c o r d   s e t   t o   b e   a d d e d   t o   t h e   d a i l y  
     - -                         . x m l   f i l e .     T h e   e n t i r e   f a c i l i t y   r e c o r d   w o u l d   b e   r e b u i l t   i n   t h e    
     - -                         H E R E   c l i e n t ,   a n d   i n   t h e   e n d   t h e   m o d i f i e d   i n d i v i d u a l ' ' s   n a m e   w i l l   b e  
     - -                         u p d a t e d   t h e   H E R E   a p p l i c a t i o n .  
     - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
     / *   N O T E :   T h e   c o m p a r e   b e t w e e n   d b o   a n d   c m p   w i l l   r e t u r n   t h e   r e c o r d s   t h a t   h a v e   b e e n    
                       m o d i f i e d   i n   t h e   s o u r c e   s y s t e m .     T h e   c m p   a n d   d b o   w i l l   r e t u r n   r e c o r d s  
                       t h a t   h a v e   b e e n   d e l e t e d   f r o m   t h e   s o u r c e   s y s t e m .     T h e   s e c o n d   c o m p a r e   i s  
                       n e c e s s a r y   d u e   t o   t h e   f a c t   t h a t   t h e r e   m a y   b e   m u l t i p l e   a d d r e s s e s   f o r   a    
                       s i n g l e   f a c i l i t y .     I f   o n e   o f   t h e   a d d r e s s e s   w e r e   d e l e t e d   t h e n   j u s t   a    
                       t e s t   t o   d e t e r m i n e   i f   t h e   f a c i l i t y   d o e s   n o t   e x i s t   i s   n o t   e n o u g h .     T h e  
                       s a m e   i s   a p p l i e d   t o   o t h e r   C A F O   d a t a   g r o u p i n g s   a l s o ,   e x c e p t   f a c i l i t y .  
             * /  
  
         - - - - - - - - - - - - - - -  
         - -     C A F O _ A D D   - -  
         - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S t a t e F a c i l i t y I D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ C A F O _ A D D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ C A F O _ A D D )  
 	 	 	 	 	 	 	 	 	 	 	 	 	       U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	 	     ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ C A F O _ A D D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ C A F O _ A D D ) )   T E M P T A B L E )  
 	           A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - C A F O ' '  
                   A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - -  
         - -     C A F O _ A N I M A L   - -  
         - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S t a t e F a c i l i t y I D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ C A F O _ A N I M A L  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ C A F O _ A N I M A L )  
 	 	 	 	 	 	 	 	 	 	 	 	 	       U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	 	     ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ C A F O _ A N I M A L  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ C A F O _ A N I M A L ) )   T E M P T A B L E )  
 	           A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - C A F O ' '  
                   A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - -  
         - -     C A F O _ F A C   - -  
         - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S t a t e F a c i l i t y I D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ C A F O _ F A C  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ C A F O _ F A C  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - C A F O ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - -  
         - -     C A F O _ G E O   - -  
         - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S t a t e F a c i l i t y I D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ C A F O _ G E O  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ C A F O _ G E O )  
 	 	 	 	 	 	 	 	 	 	 	 	 	       U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	 	     ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ C A F O _ G E O  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ C A F O _ G E O ) )   T E M P T A B L E )  
 	           A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - C A F O ' '  
                   A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - -  
         - -     C A F O _ P E R M I T   - -  
         - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S t a t e F a c i l i t y I D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ C A F O _ P E R M I T  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ C A F O _ P E R M I T )  
 	 	 	 	 	 	 	 	 	 	 	 	 	       U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	 	     ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ C A F O _ P E R M I T  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ C A F O _ P E R M I T ) )   T E M P T A B L E )  
 	           A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - C A F O ' '  
                   A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - - - -  
         - -     C A F O _ R E G _ D T L S   - -  
         - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   S t a t e F a c i l i t y I D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ C A F O _ R E G _ D T L S  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ C A F O _ R E G _ D T L S )  
 	 	 	 	 	 	 	 	 	 	 	 	 	       U N I O N  
 	 	 	 	 	 	 	 	 	 	 	 	 	     ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ C A F O _ R E G _ D T L S  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ C A F O _ R E G _ D T L S ) )   T E M P T A B L E )  
 	           A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - C A F O ' '  
                   A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - -   P r o c e s s   D e l e t e s     - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
         - - - - - - - - - - - - - - -  
         - -     F R S _ F A C     - -  
         - -     N O T E :     F R S _ F A C   i s   h a n d l e d   l a s t   f o r   a   v e r y   s p e c i f i c   r e a s o n .     A l l   " d e l e t e s "   t r i g g e r e d   b y    
         - - - - - - - - - - - - - - -  
 	 U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	       S E T   I S _ D E L E T E D   =   1  
 	           ,   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	   W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   (   S E L E C T   C M P _ T A B L E . S t a t e F a c i l i t y I D  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ C A F O _ F A C   C M P _ T A B L E  
 	 	 	 	 	 	 	 	 	 	 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	     F R O M   d b o . v w _ C A F O _ F A C   S T G _ T A B L E  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	   W H E R E   S T G _ T A B L E . S t a t e F a c i l i t y I D   =   C M P _ T A B L E . S t a t e F a c i l i t y I D ) )    
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - C A F O ' '     - -   I F   W E   C A R E ,   O T H E R W I S E   M A R K   A L L   D E L E T E D   R E G A R D L E S S   O F   F L O W _ T Y P E ?  
 	 S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 E N D  
  
  
  
  
  
  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ N E _ T I E R 2 _ D E L T A ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 5   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ N E _ T I E R 2 _ D E L T A ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ N E _ T I E R 2 _ D E L T A ]   @ v a l u e   I N T   O U T P U T  
 A S  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 K e v i n   J a m e s   ( W i n d s o r   S o l u t i o n s ,   I n c . )  
 - -   C r e a t e   d a t e :   J u n e   2 0 ,   2 0 0 7  
 - -   D e s c r i p t i o n : 	 T h i s   p r o c e d u r e   w i l l   p r o c e s s e s   T I E R   I I   d a t a   c h a n g e s  
 - -                             a n d   m a i n t a i n   t h e   c h a n g e   c o n t r o l   t a b l e   C H A N G E D _ F A C I L I T I E S  
 - -                             f o r   t h e   S t a t e   o f   N e b r a s k a   i n   r e l a t i o n   t o   t h e   H E R E   a p p l i c a t i o n .     T h e  
 - -                             t a b l e   C H A N G E D _ F A C I L I T E S   i s   u s e d   t o   c o n t r o l   w h a t   . x m l   f i l e s   a r e   b u i l t  
 - -                             a n d   s e n t   t o   a   H E R E   c l i e n t   t o   s y n c r o n i z e   t h e   c l i e n t   w i t h   t h e   s o u r c e    
 - -                             s y s t e m s .  
 - -  
 - -   P R O C E S S I N G   F L O W :  
 - -  
 - - 	 A .     P r o c e s s   I N S E R T s :     I n s e r t   n e w   r e c o r d s   i n t o   t h e   t a b l e   C H A N G E D _ F A C I L I T E S   w h e n   a   n e w   f a c i l i y   o r    
 - -                                                 r e l a t e d   d a t a   t o   a   f a c i l i y   h a s   b e e n   a d d e d   t o   t h e   s o u r c e   s y s t e m .  
 - - 	 	 0 1 .     T 2 _ C H E M _ I N V  
 - - 	 	 0 2 .     T 2 _ C H E M _ I N V _ D T L S  
 - - 	 	 0 3 .     T 2 _ C H E M _ I N V _ H A Z  
 - - 	 	 0 4 .     T 2 _ C H E M _ I N V _ H L T H  
 - - 	 	 0 5 .     T 2 _ C H E M _ I N V _ P H Y S  
 - - 	 	 0 6 .     T 2 _ C H E M _ L O C  
 - - 	 	 0 7 .     T 2 _ C H E M _ M I X  
 - - 	 	 0 8 .     T 2 _ F A C _ D U N D B _ I D  
 - - 	 	 0 9 .     T 2 _ F A C _ G E O  
 - - 	 	 1 0 .     T 2 _ F A C _ I N D  
 - - 	 	 1 1 .     T 2 _ F A C _ I N D _ E M A I L  
 - - 	 	 1 2 .     T 2 _ F A C _ I N D _ P H O N E  
 - - 	 	 1 3 .     T 2 _ F A C _ I N D _ T Y P E  
 - - 	 	 1 4 .     T 2 _ F A C _ N A I C S  
 - - 	 	 1 5 .     T 2 _ F A C _ N P D E S _ I D  
 - - 	 	 1 6 .     T 2 _ F A C _ R C R A _ I D  
 - - 	 	 1 7 .     T 2 _ F A C _ S I C  
 - - 	 	 1 8 .     T 2 _ F A C _ S I T E  
 - - 	 	 1 9 .     T 2 _ F A C _ U I C _ I D  
 - - 	 	 2 0 .     T 2 _ R E P O R T  
 - - 	 	 2 1 .     T 2 _ S U B M I S S I O N  
 - -  
 - - 	 B .     P r o c e s s   U P D A T E s :     U p d a t e   r e c o r d s   i n   t h e   C H A N G E D _ F A C I L I T E S   t a b l e   w h e n   d a t a   r e l a t e d   t o   a   f a c i l i t y   i s  
 - -                                                 m o d i f i e d   ( M o d i f i e d   D a t a   E l e m e n t s )   o r   w h e n   d a t a   r e l a t e d   t o   a   f a c i l i t y   i s   d e l e t e d  
 - -                                                 ( D e l e t e d   D a t a   E l e m e n t s ) .     E a c h   w i l l   t r i g g e r   t h e   e n t i r e   f a c i l i t y   d a t a s e t   t o   b e  
 - -                                                 i n c l u d e d   i n   t h e   " d a i l y "   . x m l   f i l e .  
 - -  
 - -             - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 - -             - -     M o d i f i e d   &   D e l e t e d   D a t a   E l e m e n t s     - -  
 - -             - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
 - - 	 	 0 1 .     T 2 _ C H E M _ I N V  
 - - 	 	 0 2 .     T 2 _ C H E M _ I N V _ D T L S  
 - - 	 	 0 3 .     T 2 _ C H E M _ I N V _ H A Z  
 - - 	 	 0 4 .     T 2 _ C H E M _ I N V _ H L T H  
 - - 	 	 0 5 .     T 2 _ C H E M _ I N V _ P H Y S  
 - - 	 	 0 6 .     T 2 _ C H E M _ L O C  
 - - 	 	 0 7 .     T 2 _ C H E M _ M I X  
 - - 	 	 0 8 .     T 2 _ F A C _ D U N D B _ I D  
 - - 	 	 0 9 .     T 2 _ F A C _ G E O  
 - - 	 	 1 0 .     T 2 _ F A C _ I N D  
 - - 	 	 1 1 .     T 2 _ F A C _ I N D _ E M A I L  
 - - 	 	 1 2 .     T 2 _ F A C _ I N D _ P H O N E  
 - - 	 	 1 3 .     T 2 _ F A C _ I N D _ T Y P E  
 - - 	 	 1 4 .     T 2 _ F A C _ N A I C S  
 - - 	 	 1 5 .     T 2 _ F A C _ N P D E S _ I D  
 - - 	 	 1 6 .     T 2 _ F A C _ R C R A _ I D  
 - - 	 	 1 7 .     T 2 _ F A C _ S I C  
 - - 	 	 1 8 .     T 2 _ F A C _ S I T E  
 - - 	 	 1 9 .     T 2 _ F A C _ U I C _ I D  
 - - 	 	 2 0 .     T 2 _ R E P O R T  
 - - 	 	 2 1 .     T 2 _ S U B M I S S I O N  
  
 - -          
 - - 	 C .     P r o c e s s   D E L E T E s :     S e t   a   f a c i l i t y   r e c o r d ' ' s   I S _ D E L E T E D   f l a g   i n   t h e   t a b l e   C H A N G E D _ F A C I L I T E S    
 - -                                                 t o   " D E L E T E D "   w h e n   a   f a c i l i t y   i s   r e m o v e d   f r o m   t h e   s o u r c e   s y s t e m .    
 - - 	 	 1 9 .     T 2 _ F A C _ S I T E  
 - -          
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 B E G I N  
 	 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 	 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 	 S E T   N O C O U N T   O N ;  
         D E C L A R E   @ E R R O R _ C O D E   I N T  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - -   P r o c e s s   I n s e r t s     - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ C H E M _ I N V  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ I N V  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ C H E M _ I N V )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ C H E M _ I N V _ D T L S  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ I N V _ D T L S  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ C H E M _ I N V _ D T L S )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ C H E M _ I N V _ H A Z  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ I N V _ H A Z  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ C H E M _ I N V _ H A Z )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ C H E M _ I N V _ H L T H  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ I N V _ H L T H  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ C H E M _ I N V _ H L T H )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ C H E M _ I N V _ P H Y S  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ I N V _ P H Y S  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ C H E M _ I N V _ P H Y S )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ C H E M _ L O C  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ L O C  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ C H E M _ L O C )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ C H E M _ M I X  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ M I X  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ C H E M _ M I X )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ D U N D B _ I D  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ D U N D B _ I D  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ F A C _ D U N D B _ I D )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
         - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ G E O  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ G E O  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ F A C _ G E O )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ I N D  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ I N D  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ F A C _ I N D )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ I N D _ E M A I L  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ I N D _ E M A I L  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ F A C _ I N D _ E M A I L )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ I N D _ P H O N E  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ I N D _ P H O N E  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ F A C _ I N D _ P H O N E )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ I N D _ T Y P E  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ I N D _ T Y P E  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ F A C _ I N D _ T Y P E )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ N A I C S  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ N A I C S  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ F A C _ N A I C S )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ N P D E S _ I D  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ N P D E S _ I D  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ F A C _ N P D E S _ I D )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ R C R A _ I D  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ R C R A _ I D  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ F A C _ R C R A _ I D )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ S I C  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ S I C  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ F A C _ S I C )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ S I T E  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ S I T E  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ F A C _ S I T E )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ U I C _ I D  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ U I C _ I D  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ F A C _ U I C _ I D )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ R E P O R T  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ R E P O R T  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ R E P O R T )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ S U B M I S S I O N  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     I N S E R T   I N T O   d b o . C H A N G E D _ F A C I L I T I E S  
 	     S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r ,   ' ' H E R E - T I E R 2 ' ' ,   g e t d a t e ( ) ,   0  
 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 F R O M   d b o . v w _ T 2 _ S U B M I S S I O N  
 	 	 	     E X C E P T   S E L E C T   *  
 	 	 	 	 	       F R O M   c m p . v w _ T 2 _ S U B M I S S I O N )   T E M P T A B L E  
 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	       F R O M   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	 	 	 	 	     W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T E M P T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' ' )  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - -   P r o c e s s   U p d a t e s     - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
     - -     M o d i f i e d   D a t a   E l e m e n t s     ( S t a g i n g   v e r s u s   C o m p a r e )     - -  
     - -     E x a m p l e :     I f   a n   i n d i v i d u a l ' ' s   n a m e   i s   u p d a t e d   f o r   a   f a c i l i t y   i n   t h e   s o u r c e  
     - -                         s y s t e m   t h e n   t h e   f o l l o w i n g   S Q L   s t a t e m e n t s   w o u l d   c a p t u r e   t h a t  
     - -                         u p d a t e .     T h e   f a c i l i t y   u p d a t e   d a t e   i s   r e s e t ,   t h e r e b y   " t r i g g e r i n g "  
     - -                         t h e   e n t i r e   f a c i l i t i e s   r e c o r d   s e t   t o   b e   a d d e d   t o   t h e   d a i l y  
     - -                         . x m l   f i l e .     T h e   e n t i r e   f a c i l i t y   r e c o r d   w o u l d   b e   r e b u i l t   i n   t h e    
     - -                         H E R E   c l i e n t ,   a n d   i n   t h e   e n d   t h e   m o d i f i e d   i n d i v i d u a l ' ' s   n a m e   w i l l   b e  
     - -                         u p d a t e d   t h e   H E R E   a p p l i c a t i o n .  
     - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ C H E M _ I N V  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ I N V  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ C H E M _ I N V )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ C H E M _ I N V  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ I N V )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ C H E M _ I N V _ D T L S  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ I N V _ D T L S  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ C H E M _ I N V _ D T L S )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ C H E M _ I N V _ D T L S  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ I N V _ D T L S )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ C H E M _ I N V _ H A Z  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ I N V _ H A Z  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ C H E M _ I N V _ H A Z )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ C H E M _ I N V _ H A Z  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ I N V _ H A Z )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ C H E M _ I N V _ H L T H  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ I N V _ H L T H  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ C H E M _ I N V _ H L T H )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ C H E M _ I N V _ H L T H  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ I N V _ H L T H )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ C H E M _ I N V _ P H Y S  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ I N V _ P H Y S  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ C H E M _ I N V _ P H Y S )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ C H E M _ I N V _ P H Y S  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ I N V _ P H Y S )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ C H E M _ L O C  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ L O C  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ C H E M _ L O C )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ C H E M _ L O C  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ L O C )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ C H E M _ M I X  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ M I X  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ C H E M _ M I X )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ C H E M _ M I X  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ C H E M _ M I X )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ D U N D B _ I D  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ D U N D B _ I D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ D U N D B _ I D )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ D U N D B _ I D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ D U N D B _ I D )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ G E O  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ G E O  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ G E O )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ G E O  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ G E O )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ I N D  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ I N D )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ I N D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ I N D )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ I N D _ E M A I L  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ I N D _ E M A I L  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ I N D _ E M A I L )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ I N D _ E M A I L  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ I N D _ E M A I L )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ I N D _ P H O N E  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ I N D _ P H O N E  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ I N D _ P H O N E )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ I N D _ P H O N E  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ I N D _ P H O N E )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ I N D _ T Y P E  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ I N D _ T Y P E  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ I N D _ T Y P E )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ I N D _ T Y P E  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ I N D _ T Y P E )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ N A I C S  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ N A I C S  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ N A I C S )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ N A I C S  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ N A I C S )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ N P D E S _ I D  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ N P D E S _ I D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ N P D E S _ I D )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ N P D E S _ I D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ N P D E S _ I D )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ R C R A _ I D  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ R C R A _ I D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ R C R A _ I D )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ R C R A _ I D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ R C R A _ I D )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ S I C  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ S I C  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ S I C )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ S I C  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ S I C )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ S I T E  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ S I T E  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ S I T E )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ S I T E  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ S I T E )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ F A C _ U I C _ I D  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ U I C _ I D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ U I C _ I D )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ U I C _ I D  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ F A C _ U I C _ I D )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ R E P O R T  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ R E P O R T  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ R E P O R T )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ R E P O R T  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ R E P O R T )  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
 / *  
  
  
 - -   T K C :   S u b m i s s i o n   s h o u l d   n o t   b e   a   c r i t e r i a  
  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	 - -     T 2 _ S U B M I S S I O N  
 	 - - - - - - - - - - - - - - - - - - - - - - - - -  
 	     U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	 	   S E T   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	 	       ,   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
 	       W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   ( S E L E C T   D I S T I N C T   F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   ( S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ S U B M I S S I O N  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ S U B M I S S I O N  
 	 	 	 	 	 	 	 	 	 	 	 	 	     U N I O N  
                                                                                                             S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ S U B M I S S I O N  
 	 	 	 	 	 	 	 	 	 	 	 	 	     E X C E P T    
 	 	 	 	 	 	 	 	 	 	 	 	 	     S E L E C T   *  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   d b o . v w _ T 2 _ S U B M I S S I O N  
 	 	 	 	 	 	 	 	 	 	 	 	 	     )   T E M P T A B L E )  
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '  
               A N D   d a t e d i f f ( D D , C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E , G E T D A T E ( ) )   >   0  
         S E L E C T   @ E R R O R _ C O D E   =   @ @ E R R O R   I F   @ E R R O R _ C O D E   < >   0   R E T U R N   5 0 0 0 0  
 * /  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - -   P r o c e s s   D e l e t e s     - -  
     - - - - - - - - - - - - - - - - - - - - - -  
     - - - - - - - - - - - - - - - - - - - - - -  
         - - - - - - - - - - - - - - - - - - -  
         - -     T 2 _ F A C _ S I T E     - -  
         - -     N O T E :     F R S _ F A C   i s   h a n d l e d   l a s t   f o r   a   v e r y   s p e c i f i c   r e a s o n .     A l l   " d e l e t e s "   t r i g g e r e d   b y    
         - - - - - - - - - - - - - - - - - - -  
 	 U P D A T E   d b o . C H A N G E D _ F A C I L I T I E S  
 	       S E T   I S _ D E L E T E D   =   1  
 	           ,   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   =   G E T D A T E ( )  
 	   W H E R E   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   I N   (   S E L E C T   C M P _ T A B L E . F a c i l i t y S i t e I d e n t i f i e r  
 	 	 	 	 	 	 	 	 	 	 	 	 F R O M   c m p . v w _ T 2 _ F A C _ S I T E   C M P _ T A B L E  
 	 	 	 	 	 	 	 	 	 	 	       W H E R E   N O T   E X I S T S   ( S E L E C T   1  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	     F R O M   d b o . v w _ T 2 _ F A C _ S I T E   S T G _ T A B L E  
 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	 	   W H E R E   S T G _ T A B L E . F a c i l i t y S i t e I d e n t i f i e r   =   C M P _ T A B L E . F a c i l i t y S i t e I d e n t i f i e r ) )    
 	       A N D   C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E   =   ' ' H E R E - T I E R 2 ' '     - -   I F   W E   C A R E ,   O T H E R W I S E   M A R K   A L L   D E L E T E D   R E G A R D L E S S   O F   F L O W _ T Y P E ?  
  
 E N D  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     S t o r e d P r o c e d u r e   [ d b o ] . [ N E _ H E R E _ P R O C E S S ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 1 4   * * * * * * /  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ N E _ H E R E _ P R O C E S S ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 B E G I N  
 E X E C   d b o . s p _ e x e c u t e s q l   @ s t a t e m e n t   =   N '  
  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 K e v i n   J a m e s   ( W i n d s o r   S o l u t i o n s ,   I n c . )  
 - -   C r e a t e   d a t e :   J u n e   1 3 ,   2 0 0 7  
 - -   D e s c r i p t i o n : 	 T h i s   p r o c e d u r e   w i l l   l o a d   f a c i l i t y   d a t a   a n d   r e l a t e d  
 - -                             d a t a   e l e m e n t s   i n t o   t h e   H E R E   s t a g i n g   d a t a b a s e .     T h e   v a l u e  
 - -                             r e t u r n e d   f r o m   e a c h   c a l l e d   s t o r e d   p r o c e d u r e   i s   i n s p e c t e d  
 - -                             t o   d e t e r m i n e   i f   a n y   e r r o r   w e r e   e n c o u n t e r e d   d u r i n g   p r o c e s s i n g .  
 - -                             I f   a n   e r r o r   i s   d e t e t e d   t h e n   t h e   E R R O R _ H A N D L E R   i n v o k e s   a    
 - -                             r o l l b a c k   o n   t h e   e n t i r e   t r a n s a c t i o n   a n d   t h e   d a t a   r e t u r n s   t o    
 - -                             i t ' ' s   o r i g i n a l   s t a t e .  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ d b o ] . [ N E _ H E R E _ P R O C E S S ]    
     @ F L O W _ T Y P E                     V A R C H A R ( 5 0 )    
  
 A S  
 B E G I N  
  
     D E C L A R E   @ r e t u r n _ v a l u e   i n t  
     D E C L A R E   @ v a l u e   i n t  
  
     / *   B E G I N   A N   E X P L I C I T   T R A N S A C T I O N   * /  
     B E G I N   T R A N   @ F L O W _ T Y P E  
  
     I F   @ F L O W _ T Y P E   =   ' ' H E R E _ F R S ' '  
         B E G I N  
  
             / *     P R O C E S S   F R S   D A T A     * /  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ F R S _ I N I T ]   @ v a l u e   O U T P U T  
                 P R I N T   ' ' I N I T   R V :   ' '   +   c o n v e r t ( v a r c h a r , @ r e t u r n _ v a l u e )  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ F R S _ L O A D ]   @ v a l u e   O U T P U T  
                 P R I N T   ' ' L O A D   R V :   ' '   +   c o n v e r t ( v a r c h a r , @ r e t u r n _ v a l u e )  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ F R S _ D E L T A ]   @ v a l u e   O U T P U T  
                 P R I N T   ' ' D E L T A   R V :   ' '   +   c o n v e r t ( v a r c h a r , @ r e t u r n _ v a l u e )  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
  
         E N D  
     E L S E    
     I F   @ F L O W _ T Y P E   =   ' ' H E R E _ C A F O ' '  
         B E G I N  
  
             / *     P R O C E S S   C A F O   D A T A     * /  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ C A F O _ I N I T ]   @ v a l u e   O U T P U T  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ C A F O _ L O A D ]   @ v a l u e   O U T P U T  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ C A F O _ D E L T A ]   @ v a l u e   O U T P U T  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
  
         E N D  
     E L S E    
     I F   @ F L O W _ T Y P E   =   ' ' H E R E _ T I E R 2 ' '  
         B E G I N  
  
             / *     P R O C E S S   T I E R 2   D A T A     * /  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ T I E R 2 _ I N I T ]   @ v a l u e   O U T P U T  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ T I E R 2 _ L O A D ]   @ v a l u e   O U T P U T  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ T I E R 2 _ D E L T A ]   @ v a l u e   O U T P U T  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
  
         E N D  
     E L S E  
     I F   @ F L O W _ T Y P E   =   ' ' H E R E _ C O M P L E T E ' '  
         B E G I N  
  
             / *     P r o c e s s   F R S     * /  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ F R S _ I N I T ]   @ v a l u e   O U T P U T  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ F R S _ L O A D ]   @ v a l u e   O U T P U T  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ F R S _ D E L T A ]   @ v a l u e   O U T P U T  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
  
             / *     P r o c e s s   C A F O     * /  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ C A F O _ I N I T ]   @ v a l u e   O U T P U T  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ C A F O _ L O A D ]   @ v a l u e   O U T P U T  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ C A F O _ D E L T A ]   @ v a l u e   O U T P U T  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
  
             / *     P r o c e s s   T I E R 2     * /  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ T I E R 2 _ I N I T ]   @ v a l u e   O U T P U T  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ T I E R 2 _ L O A D ]   @ v a l u e   O U T P U T  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
             E X E C   @ r e t u r n _ v a l u e   =   [ N E _ T I E R 2 _ D E L T A ]   @ v a l u e   O U T P U T  
                 I F   @ r e t u r n _ v a l u e   < >   0   G O T O   E R R O R _ H A N D L E R  
  
         E N D  
  
     E R R O R _ H A N D L E R :  
         I F   @ r e t u r n _ v a l u e   < >   0  
                 R O L L B A C K   T R A N   @ F L O W _ T Y P E  
         E L S E    
                 C O M M I T   T R A N   @ F L O W _ T Y P E  
  
 E N D  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
 '    
 E N D  
 G O  
 / * * * * * *   O b j e c t :     C h e c k   [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 6 7 3 F 4 B 0 5 ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 5 0   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . c h e c k _ c o n s t r a i n t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 6 7 3 F 4 B 0 5 ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ N A I C S ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ N A I C S ]     W I T H   C H E C K   A D D   C H E C K     ( ( l e n ( [ N A I C S C o d e ] ) > = ( 6 ) ) )  
 G O  
 / * * * * * *   O b j e c t :     C h e c k   [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 6 8 3 3 6 F 3 E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 5 0   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . c h e c k _ c o n s t r a i n t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 6 8 3 3 6 F 3 E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ N A I C S ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ N A I C S ]     W I T H   C H E C K   A D D   C H E C K     ( ( l e n ( [ N A I C S I n d u s t r y C o d e ] ) > = ( 5 ) ) )  
 G O  
 / * * * * * *   O b j e c t :     C h e c k   [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 6 9 2 7 9 3 7 7 ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 5 0   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . c h e c k _ c o n s t r a i n t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 6 9 2 7 9 3 7 7 ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ N A I C S ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ N A I C S ]     W I T H   C H E C K   A D D   C H E C K     ( ( l e n ( [ N A I C S G r o u p C o d e ] ) > = ( 4 ) ) )  
 G O  
 / * * * * * *   O b j e c t :     C h e c k   [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 6 A 1 B B 7 B 0 ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 5 0   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . c h e c k _ c o n s t r a i n t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 6 A 1 B B 7 B 0 ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ N A I C S ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ N A I C S ]     W I T H   C H E C K   A D D   C H E C K     ( ( l e n ( [ N A I C S S u b s e c t o r C o d e ] ) > = ( 3 ) ) )  
 G O  
 / * * * * * *   O b j e c t :     C h e c k   [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 6 B 0 F D B E 9 ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 5 0   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . c h e c k _ c o n s t r a i n t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 6 B 0 F D B E 9 ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ N A I C S ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ N A I C S ]     W I T H   C H E C K   A D D   C H E C K     ( ( l e n ( [ N A I C S S e c t o r C o d e ] ) > = ( 2 ) ) )  
 G O  
 / * * * * * *   O b j e c t :     C h e c k   [ C K _ _ T 2 _ F A C _ S I _ _ S I C C o _ _ 7 0 C 8 B 5 3 F ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 5 9   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . c h e c k _ c o n s t r a i n t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ C K _ _ T 2 _ F A C _ S I _ _ S I C C o _ _ 7 0 C 8 B 5 3 F ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ S I C ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ S I C ]     W I T H   C H E C K   A D D   C H E C K     ( ( l e n ( [ S I C C o d e ] ) > = ( 4 ) ) )  
 G O  
 / * * * * * *   O b j e c t :     C h e c k   [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 2 8 E D 1 2 D 1 ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 3 1   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . c h e c k _ c o n s t r a i n t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 2 8 E D 1 2 D 1 ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ N A I C S ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ N A I C S ]     W I T H   C H E C K   A D D   C H E C K     ( ( l e n ( [ N A I C S C o d e ] ) > = ( 6 ) ) )  
 G O  
 / * * * * * *   O b j e c t :     C h e c k   [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 2 9 E 1 3 7 0 A ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 3 1   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . c h e c k _ c o n s t r a i n t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 2 9 E 1 3 7 0 A ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ N A I C S ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ N A I C S ]     W I T H   C H E C K   A D D   C H E C K     ( ( l e n ( [ N A I C S I n d u s t r y C o d e ] ) > = ( 5 ) ) )  
 G O  
 / * * * * * *   O b j e c t :     C h e c k   [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 2 A D 5 5 B 4 3 ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 3 1   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . c h e c k _ c o n s t r a i n t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 2 A D 5 5 B 4 3 ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ N A I C S ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ N A I C S ]     W I T H   C H E C K   A D D   C H E C K     ( ( l e n ( [ N A I C S G r o u p C o d e ] ) > = ( 4 ) ) )  
 G O  
 / * * * * * *   O b j e c t :     C h e c k   [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 2 B C 9 7 F 7 C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 3 1   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . c h e c k _ c o n s t r a i n t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 2 B C 9 7 F 7 C ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ N A I C S ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ N A I C S ]     W I T H   C H E C K   A D D   C H E C K     ( ( l e n ( [ N A I C S S u b s e c t o r C o d e ] ) > = ( 3 ) ) )  
 G O  
 / * * * * * *   O b j e c t :     C h e c k   [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 2 C B D A 3 B 5 ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 3 2   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . c h e c k _ c o n s t r a i n t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C K _ _ T 2 _ F A C _ N A _ _ N A I C S _ _ 2 C B D A 3 B 5 ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ N A I C S ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ N A I C S ]     W I T H   C H E C K   A D D   C H E C K     ( ( l e n ( [ N A I C S S e c t o r C o d e ] ) > = ( 2 ) ) )  
 G O  
 / * * * * * *   O b j e c t :     C h e c k   [ C K _ _ T 2 _ F A C _ S I _ _ S I C C o _ _ 3 1 8 2 5 8 D 2 ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 4 0   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . c h e c k _ c o n s t r a i n t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C K _ _ T 2 _ F A C _ S I _ _ S I C C o _ _ 3 1 8 2 5 8 D 2 ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ S I C ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ S I C ]     W I T H   C H E C K   A D D   C H E C K     ( ( l e n ( [ S I C C o d e ] ) > = ( 4 ) ) )  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ L o c A d d r e s s _ F a c i l i t y ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 2 4   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ L o c A d d r e s s _ F a c i l i t y ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ C A F O _ A D D ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ C A F O _ A D D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ L o c A d d r e s s _ F a c i l i t y ]   F O R E I G N   K E Y ( [ F K ] )  
 R E F E R E N C E S   [ c m p ] . [ C A F O _ F A C ]   ( [ P K ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ C A F O _ A D D ]   C H E C K   C O N S T R A I N T   [ F K _ L o c A d d r e s s _ F a c i l i t y ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ A n i m a l T y p e _ F a c i l i t y ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 2 9   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ A n i m a l T y p e _ F a c i l i t y ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ C A F O _ A N I M A L ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ C A F O _ A N I M A L ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ A n i m a l T y p e _ F a c i l i t y ]   F O R E I G N   K E Y ( [ F K ] )  
 R E F E R E N C E S   [ c m p ] . [ C A F O _ F A C ]   ( [ P K ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ C A F O _ A N I M A L ]   C H E C K   C O N S T R A I N T   [ F K _ A n i m a l T y p e _ F a c i l i t y ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ G e o L o c _ F a c i l i t y ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 4 5   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ G e o L o c _ F a c i l i t y ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ C A F O _ G E O ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ C A F O _ G E O ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ G e o L o c _ F a c i l i t y ]   F O R E I G N   K E Y ( [ F K ] )  
 R E F E R E N C E S   [ c m p ] . [ C A F O _ F A C ]   ( [ P K ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ C A F O _ G E O ]   C H E C K   C O N S T R A I N T   [ F K _ G e o L o c _ F a c i l i t y ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ P e r m i t _ R e g D e t a i l s ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 4 : 5 1   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ P e r m i t _ R e g D e t a i l s ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ C A F O _ P E R M I T ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ C A F O _ P E R M I T ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ P e r m i t _ R e g D e t a i l s ]   F O R E I G N   K E Y ( [ F K ] )  
 R E F E R E N C E S   [ c m p ] . [ C A F O _ R E G _ D T L S ]   ( [ P K ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ C A F O _ P E R M I T ]   C H E C K   C O N S T R A I N T   [ F K _ P e r m i t _ R e g D e t a i l s ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ R e g D e t a i l s _ F a c i l i t y ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 5 : 1 8   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ R e g D e t a i l s _ F a c i l i t y ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ C A F O _ R E G _ D T L S ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ C A F O _ R E G _ D T L S ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ R e g D e t a i l s _ F a c i l i t y ]   F O R E I G N   K E Y ( [ F K ] )  
 R E F E R E N C E S   [ c m p ] . [ C A F O _ F A C ]   ( [ P K ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ C A F O _ R E G _ D T L S ]   C H E C K   C O N S T R A I N T   [ F K _ R e g D e t a i l s _ F a c i l i t y ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ A D D _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 5 : 2 4   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ A D D _ F A C ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ A D D ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ A D D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ A D D _ F A C ]   F O R E I G N   K E Y ( [ S T _ F A C _ I N D ] )  
 R E F E R E N C E S   [ c m p ] . [ F R S _ F A C ]   ( [ S T _ F A C _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ A D D ]   C H E C K   C O N S T R A I N T   [ F K _ A D D _ F A C ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ A L T _ N M _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 5 : 2 7   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ A L T _ N M _ F A C ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ A L T _ N M ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ A L T _ N M ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ A L T _ N M _ F A C ]   F O R E I G N   K E Y ( [ S T _ F A C _ I N D ] )  
 R E F E R E N C E S   [ c m p ] . [ F R S _ F A C ]   ( [ S T _ F A C _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ A L T _ N M ]   C H E C K   C O N S T R A I N T   [ F K _ A L T _ N M _ F A C ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ E I _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 5 : 3 3   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ E I _ F A C ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ E I ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ E I ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ E I _ F A C ]   F O R E I G N   K E Y ( [ S T _ F A C _ I N D ] )  
 R E F E R E N C E S   [ c m p ] . [ F R S _ F A C ]   ( [ S T _ F A C _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ E I ]   C H E C K   C O N S T R A I N T   [ F K _ E I _ F A C ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ E I I N D _ E I ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 5 : 4 6   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ E I I N D _ E I ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ E I _ I N D ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ E I _ I N D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ E I I N D _ E I ]   F O R E I G N   K E Y ( [ S T _ E I _ I N D ] )  
 R E F E R E N C E S   [ c m p ] . [ F R S _ E I ]   ( [ S T _ E I _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ E I _ I N D ]   C H E C K   C O N S T R A I N T   [ F K _ E I I N D _ E I ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ E I N A I C S _ E I ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 5 : 5 0   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ E I N A I C S _ E I ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ E I _ N A I C S ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ E I _ N A I C S ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ E I N A I C S _ E I ]   F O R E I G N   K E Y ( [ S T _ E I _ I N D ] )  
 R E F E R E N C E S   [ c m p ] . [ F R S _ E I ]   ( [ S T _ E I _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ E I _ N A I C S ]   C H E C K   C O N S T R A I N T   [ F K _ E I N A I C S _ E I ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ E I O R G _ E I ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 6 : 0 5   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ E I O R G _ E I ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ E I _ O R G ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ E I _ O R G ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ E I O R G _ E I ]   F O R E I G N   K E Y ( [ S T _ E I _ I N D ] )  
 R E F E R E N C E S   [ c m p ] . [ F R S _ E I ]   ( [ S T _ E I _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ E I _ O R G ]   C H E C K   C O N S T R A I N T   [ F K _ E I O R G _ E I ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ E I S I C _ E I ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 6 : 0 8   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ E I S I C _ E I ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ E I _ S I C ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ E I _ S I C ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ E I S I C _ E I ]   F O R E I G N   K E Y ( [ S T _ E I _ I N D ] )  
 R E F E R E N C E S   [ c m p ] . [ F R S _ E I ]   ( [ S T _ E I _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ E I _ S I C ]   C H E C K   C O N S T R A I N T   [ F K _ E I S I C _ E I ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ F A C I N D _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 6 : 3 8   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ F A C I N D _ F A C ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ F A C _ I N D ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ F A C _ I N D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C I N D _ F A C ]   F O R E I G N   K E Y ( [ S T _ F A C _ I N D ] )  
 R E F E R E N C E S   [ c m p ] . [ F R S _ F A C ]   ( [ S T _ F A C _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ F A C _ I N D ]   C H E C K   C O N S T R A I N T   [ F K _ F A C I N D _ F A C ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ F A C N A I C S _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 6 : 4 1   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ F A C N A I C S _ F A C ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ F A C _ N A I C S ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ F A C _ N A I C S ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C N A I C S _ F A C ]   F O R E I G N   K E Y ( [ S T _ F A C _ I N D ] )  
 R E F E R E N C E S   [ c m p ] . [ F R S _ F A C ]   ( [ S T _ F A C _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ F A C _ N A I C S ]   C H E C K   C O N S T R A I N T   [ F K _ F A C N A I C S _ F A C ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ F A C O R G _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 6 : 5 7   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ F A C O R G _ F A C ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ F A C _ O R G ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ F A C _ O R G ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C O R G _ F A C ]   F O R E I G N   K E Y ( [ S T _ F A C _ I N D ] )  
 R E F E R E N C E S   [ c m p ] . [ F R S _ F A C ]   ( [ S T _ F A C _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ F A C _ O R G ]   C H E C K   C O N S T R A I N T   [ F K _ F A C O R G _ F A C ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ F A C S I C _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 0 0   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ F A C S I C _ F A C ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ F A C _ S I C ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ F A C _ S I C ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C S I C _ F A C ]   F O R E I G N   K E Y ( [ S T _ F A C _ I N D ] )  
 R E F E R E N C E S   [ c m p ] . [ F R S _ F A C ]   ( [ S T _ F A C _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ F A C _ S I C ]   C H E C K   C O N S T R A I N T   [ F K _ F A C S I C _ F A C ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ F R S _ G E O _ H C M ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 1 2   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ F R S _ G E O _ H C M ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ G E O ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ G E O ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ F R S _ G E O _ H C M ]   F O R E I G N   K E Y ( [ H O R I Z _ C O L L _ M E T H ] )  
 R E F E R E N C E S   [ d b o ] . [ H O R I Z _ C O L L _ M E T H ]   ( [ C O L L E C T _ M E T H _ D E S C ] )  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ G E O ]   C H E C K   C O N S T R A I N T   [ F K _ F R S _ G E O _ H C M ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ G E O _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 1 2   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ G E O _ F A C ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F R S _ G E O ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ G E O ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ G E O _ F A C ]   F O R E I G N   K E Y ( [ S T _ F A C _ I N D ] )  
 R E F E R E N C E S   [ c m p ] . [ F R S _ F A C ]   ( [ S T _ F A C _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ F R S _ G E O ]   C H E C K   C O N S T R A I N T   [ F K _ G E O _ F A C ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ C H E M _ I N V _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 1 9   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ C H E M _ I N V _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ C H E M _ I N V ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ C H E M _ I N V ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ C H E M _ I N V ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ C H E M _ I N V _ D T L S _ T 2 _ C H E M _ I N V ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 2 5   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ C H E M _ I N V _ D T L S _ T 2 _ C H E M _ I N V ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ C H E M _ I N V _ D T L S ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ C H E M _ I N V _ D T L S ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ D T L S _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ C H E M _ I N V _ D T L S ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ D T L S _ T 2 _ C H E M _ I N V ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ C H E M _ I N V _ H A Z _ T 2 _ C H E M _ I N V ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 2 7   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ C H E M _ I N V _ H A Z _ T 2 _ C H E M _ I N V ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ C H E M _ I N V _ H A Z ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ C H E M _ I N V _ H A Z ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ H A Z _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ C H E M _ I N V _ H A Z ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ H A Z _ T 2 _ C H E M _ I N V ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ C H E M _ I N V _ H L T H _ T 2 _ C H E M _ I N V ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 3 0   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ C H E M _ I N V _ H L T H _ T 2 _ C H E M _ I N V ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ C H E M _ I N V _ H L T H ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ C H E M _ I N V _ H L T H ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ H L T H _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ C H E M _ I N V _ H L T H ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ H L T H _ T 2 _ C H E M _ I N V ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ C H E M _ I N V _ P H Y S _ T 2 _ C H E M _ I N V ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 3 3   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ C H E M _ I N V _ P H Y S _ T 2 _ C H E M _ I N V ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ C H E M _ I N V _ P H Y S ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ C H E M _ I N V _ P H Y S ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ P H Y S _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ C H E M _ I N V _ P H Y S ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ P H Y S _ T 2 _ C H E M _ I N V ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ C H E M _ L O C _ T 2 _ C H E M _ I N V ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 4 1   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ C H E M _ L O C _ T 2 _ C H E M _ I N V ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ C H E M _ L O C ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ C H E M _ L O C ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ L O C _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ C H E M _ L O C ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ L O C _ T 2 _ C H E M _ I N V ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ C H E M _ M I X _ T 2 _ C H E M _ I N V ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 4 6   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ C H E M _ M I X _ T 2 _ C H E M _ I N V ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ C H E M _ M I X ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ C H E M _ M I X ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ M I X _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ C H E M _ M I X ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ M I X _ T 2 _ C H E M _ I N V ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ D U N D B _ I D _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 7 : 4 9   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ F A C _ D U N D B _ I D _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ D U N D B _ I D ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ D U N D B _ I D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ D U N D B _ I D _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ D U N D B _ I D ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ D U N D B _ I D _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ G E O _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 2 2   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ F A C _ G E O _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ G E O ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ G E O ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ G E O _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ G E O ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ G E O _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ I N D _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 3 5   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ F A C _ I N D _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ I N D ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ I N D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ I N D ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ I N D _ E M A I L _ T 2 _ F A C _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 3 8   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ F A C _ I N D _ E M A I L _ T 2 _ F A C _ I N D ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ I N D _ E M A I L ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ I N D _ E M A I L ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ E M A I L _ T 2 _ F A C _ I N D ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ F A C _ I N D ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ I N D _ E M A I L ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ E M A I L _ T 2 _ F A C _ I N D ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ I N D _ P H O N E _ T 2 _ F A C _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 4 2   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ F A C _ I N D _ P H O N E _ T 2 _ F A C _ I N D ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ I N D _ P H O N E ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ I N D _ P H O N E ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ P H O N E _ T 2 _ F A C _ I N D ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ F A C _ I N D ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ I N D _ P H O N E ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ P H O N E _ T 2 _ F A C _ I N D ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ I N D _ T Y P E _ T 2 _ F A C _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 4 5   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ F A C _ I N D _ T Y P E _ T 2 _ F A C _ I N D ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ I N D _ T Y P E ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ I N D _ T Y P E ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ T Y P E _ T 2 _ F A C _ I N D ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ F A C _ I N D ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ I N D _ T Y P E ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ T Y P E _ T 2 _ F A C _ I N D ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ N A I C S _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 5 0   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ F A C _ N A I C S _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ N A I C S ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ N A I C S ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ N A I C S _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ N A I C S ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ N A I C S _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ N P D E S _ I D _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 5 3   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ F A C _ N P D E S _ I D _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ N P D E S _ I D ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ N P D E S _ I D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ N P D E S _ I D _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ N P D E S _ I D ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ N P D E S _ I D _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ R C R A _ I D _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 5 6   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ F A C _ R C R A _ I D _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ R C R A _ I D ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ R C R A _ I D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ R C R A _ I D _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ R C R A _ I D ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ R C R A _ I D _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ S I C _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 8 : 5 9   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ F A C _ S I C _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ S I C ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ S I C ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ S I C _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ S I C ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ S I C _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ S I T E _ T 2 _ R E P O R T ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 9 : 2 3   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ F A C _ S I T E _ T 2 _ R E P O R T ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ S I T E ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ S I T E ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ S I T E _ T 2 _ R E P O R T ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ R E P O R T ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ S I T E ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ S I T E _ T 2 _ R E P O R T ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ U I C _ I D _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 9 : 2 6   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ F A C _ U I C _ I D _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ F A C _ U I C _ I D ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ U I C _ I D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ U I C _ I D _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ F A C _ U I C _ I D ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ U I C _ I D _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ R E P O R T _ T 2 _ S U B M I S S I O N ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 9 : 3 5   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ F K _ T 2 _ R E P O R T _ T 2 _ S U B M I S S I O N ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ c m p ] . [ T 2 _ R E P O R T ] ' ) )  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ R E P O R T ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ R E P O R T _ T 2 _ S U B M I S S I O N ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ c m p ] . [ T 2 _ S U B M I S S I O N ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ c m p ] . [ T 2 _ R E P O R T ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ R E P O R T _ T 2 _ S U B M I S S I O N ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ L o c A d d r e s s _ F a c i l i t y ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 9 : 4 5   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ L o c A d d r e s s _ F a c i l i t y ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ A D D ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ A D D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ L o c A d d r e s s _ F a c i l i t y ]   F O R E I G N   K E Y ( [ F K ] )  
 R E F E R E N C E S   [ d b o ] . [ C A F O _ F A C ]   ( [ P K ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ A D D ]   C H E C K   C O N S T R A I N T   [ F K _ L o c A d d r e s s _ F a c i l i t y ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ A n i m a l T y p e _ F a c i l i t y ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 1 9 : 5 0   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ A n i m a l T y p e _ F a c i l i t y ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ A N I M A L ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ A N I M A L ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ A n i m a l T y p e _ F a c i l i t y ]   F O R E I G N   K E Y ( [ F K ] )  
 R E F E R E N C E S   [ d b o ] . [ C A F O _ F A C ]   ( [ P K ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ A N I M A L ]   C H E C K   C O N S T R A I N T   [ F K _ A n i m a l T y p e _ F a c i l i t y ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ G e o L o c _ F a c i l i t y ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 0 : 0 7   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ G e o L o c _ F a c i l i t y ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ G E O ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ G E O ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ G e o L o c _ F a c i l i t y ]   F O R E I G N   K E Y ( [ F K ] )  
 R E F E R E N C E S   [ d b o ] . [ C A F O _ F A C ]   ( [ P K ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ G E O ]   C H E C K   C O N S T R A I N T   [ F K _ G e o L o c _ F a c i l i t y ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ P e r m i t _ R e g D e t a i l s ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 0 : 1 3   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ P e r m i t _ R e g D e t a i l s ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ P E R M I T ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ P E R M I T ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ P e r m i t _ R e g D e t a i l s ]   F O R E I G N   K E Y ( [ F K ] )  
 R E F E R E N C E S   [ d b o ] . [ C A F O _ R E G _ D T L S ]   ( [ P K ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ P E R M I T ]   C H E C K   C O N S T R A I N T   [ F K _ P e r m i t _ R e g D e t a i l s ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ R e g D e t a i l s _ F a c i l i t y ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 0 : 3 9   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ R e g D e t a i l s _ F a c i l i t y ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ R E G _ D T L S ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ R E G _ D T L S ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ R e g D e t a i l s _ F a c i l i t y ]   F O R E I G N   K E Y ( [ F K ] )  
 R E F E R E N C E S   [ d b o ] . [ C A F O _ F A C ]   ( [ P K ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ R E G _ D T L S ]   C H E C K   C O N S T R A I N T   [ F K _ R e g D e t a i l s _ F a c i l i t y ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ A D D _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 0 : 4 9   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ A D D _ F A C ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ A D D ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ A D D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ A D D _ F A C ]   F O R E I G N   K E Y ( [ S T _ F A C _ I N D ] )  
 R E F E R E N C E S   [ d b o ] . [ F R S _ F A C ]   ( [ S T _ F A C _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ A D D ]   C H E C K   C O N S T R A I N T   [ F K _ A D D _ F A C ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ A L T _ N M _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 0 : 5 2   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ A L T _ N M _ F A C ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ A L T _ N M ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ A L T _ N M ]     W I T H   N O C H E C K   A D D     C O N S T R A I N T   [ F K _ A L T _ N M _ F A C ]   F O R E I G N   K E Y ( [ S T _ F A C _ I N D ] )  
 R E F E R E N C E S   [ d b o ] . [ F R S _ F A C ]   ( [ S T _ F A C _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ A L T _ N M ]   C H E C K   C O N S T R A I N T   [ F K _ A L T _ N M _ F A C ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ E I _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 0 : 5 9   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ E I _ F A C ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ E I ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ E I ]     W I T H   N O C H E C K   A D D     C O N S T R A I N T   [ F K _ E I _ F A C ]   F O R E I G N   K E Y ( [ S T _ F A C _ I N D ] )  
 R E F E R E N C E S   [ d b o ] . [ F R S _ F A C ]   ( [ S T _ F A C _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ E I ]   C H E C K   C O N S T R A I N T   [ F K _ E I _ F A C ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ E I I N D _ E I ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 1 : 1 1   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ E I I N D _ E I ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ E I _ I N D ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ E I _ I N D ]     W I T H   N O C H E C K   A D D     C O N S T R A I N T   [ F K _ E I I N D _ E I ]   F O R E I G N   K E Y ( [ S T _ E I _ I N D ] )  
 R E F E R E N C E S   [ d b o ] . [ F R S _ E I ]   ( [ S T _ E I _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ E I _ I N D ]   C H E C K   C O N S T R A I N T   [ F K _ E I I N D _ E I ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ E I N A I C S _ E I ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 1 : 1 4   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ E I N A I C S _ E I ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ E I _ N A I C S ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ E I _ N A I C S ]     W I T H   N O C H E C K   A D D     C O N S T R A I N T   [ F K _ E I N A I C S _ E I ]   F O R E I G N   K E Y ( [ S T _ E I _ I N D ] )  
 R E F E R E N C E S   [ d b o ] . [ F R S _ E I ]   ( [ S T _ E I _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ E I _ N A I C S ]   C H E C K   C O N S T R A I N T   [ F K _ E I N A I C S _ E I ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ E I O R G _ E I ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 1 : 2 9   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ E I O R G _ E I ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ E I _ O R G ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ E I _ O R G ]     W I T H   N O C H E C K   A D D     C O N S T R A I N T   [ F K _ E I O R G _ E I ]   F O R E I G N   K E Y ( [ S T _ E I _ I N D ] )  
 R E F E R E N C E S   [ d b o ] . [ F R S _ E I ]   ( [ S T _ E I _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ E I _ O R G ]   C H E C K   C O N S T R A I N T   [ F K _ E I O R G _ E I ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ E I S I C _ E I ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 1 : 3 3   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ E I S I C _ E I ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ E I _ S I C ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ E I _ S I C ]     W I T H   N O C H E C K   A D D     C O N S T R A I N T   [ F K _ E I S I C _ E I ]   F O R E I G N   K E Y ( [ S T _ E I _ I N D ] )  
 R E F E R E N C E S   [ d b o ] . [ F R S _ E I ]   ( [ S T _ E I _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ E I _ S I C ]   C H E C K   C O N S T R A I N T   [ F K _ E I S I C _ E I ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ F A C I N D _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 2 : 0 2   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ F A C I N D _ F A C ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ F A C _ I N D ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ F A C _ I N D ]     W I T H   N O C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C I N D _ F A C ]   F O R E I G N   K E Y ( [ S T _ F A C _ I N D ] )  
 R E F E R E N C E S   [ d b o ] . [ F R S _ F A C ]   ( [ S T _ F A C _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ F A C _ I N D ]   C H E C K   C O N S T R A I N T   [ F K _ F A C I N D _ F A C ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ F A C N A I C S _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 2 : 0 5   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ F A C N A I C S _ F A C ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ F A C _ N A I C S ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ F A C _ N A I C S ]     W I T H   N O C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C N A I C S _ F A C ]   F O R E I G N   K E Y ( [ S T _ F A C _ I N D ] )  
 R E F E R E N C E S   [ d b o ] . [ F R S _ F A C ]   ( [ S T _ F A C _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ F A C _ N A I C S ]   C H E C K   C O N S T R A I N T   [ F K _ F A C N A I C S _ F A C ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ F A C O R G _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 2 : 2 0   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ F A C O R G _ F A C ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ F A C _ O R G ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ F A C _ O R G ]     W I T H   N O C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C O R G _ F A C ]   F O R E I G N   K E Y ( [ S T _ F A C _ I N D ] )  
 R E F E R E N C E S   [ d b o ] . [ F R S _ F A C ]   ( [ S T _ F A C _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ F A C _ O R G ]   C H E C K   C O N S T R A I N T   [ F K _ F A C O R G _ F A C ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ F A C S I C _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 2 : 2 4   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ F A C S I C _ F A C ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ F A C _ S I C ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ F A C _ S I C ]     W I T H   N O C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C S I C _ F A C ]   F O R E I G N   K E Y ( [ S T _ F A C _ I N D ] )  
 R E F E R E N C E S   [ d b o ] . [ F R S _ F A C ]   ( [ S T _ F A C _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ F A C _ S I C ]   C H E C K   C O N S T R A I N T   [ F K _ F A C S I C _ F A C ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ F R S _ G E O _ H C M ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 2 : 3 6   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ F R S _ G E O _ H C M ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ G E O ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ G E O ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ F R S _ G E O _ H C M ]   F O R E I G N   K E Y ( [ H O R I Z _ C O L L _ M E T H ] )  
 R E F E R E N C E S   [ d b o ] . [ H O R I Z _ C O L L _ M E T H ]   ( [ C O L L E C T _ M E T H _ D E S C ] )  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ G E O ]   C H E C K   C O N S T R A I N T   [ F K _ F R S _ G E O _ H C M ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ G E O _ F A C ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 2 : 3 6   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ G E O _ F A C ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F R S _ G E O ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ G E O ]     W I T H   N O C H E C K   A D D     C O N S T R A I N T   [ F K _ G E O _ F A C ]   F O R E I G N   K E Y ( [ S T _ F A C _ I N D ] )  
 R E F E R E N C E S   [ d b o ] . [ F R S _ F A C ]   ( [ S T _ F A C _ I N D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F R S _ G E O ]   C H E C K   C O N S T R A I N T   [ F K _ G E O _ F A C ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ H E R E _ D o m a i n L i s t I t e m _ H E R E _ D o m a i n L i s t ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 2 : 4 4   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ H E R E _ D o m a i n L i s t I t e m _ H E R E _ D o m a i n L i s t ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ H E R E _ D o m a i n L i s t I t e m _ H E R E _ D o m a i n L i s t ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ H E R E _ D o m a i n L i s t ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]   C H E C K   C O N S T R A I N T   [ F K _ H E R E _ D o m a i n L i s t I t e m _ H E R E _ D o m a i n L i s t ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ C H E M _ I N V _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 3 : 0 1   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ C H E M _ I N V _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ I N V ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ C H E M _ I N V _ D T L S _ T 2 _ C H E M _ I N V ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 3 : 0 6   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ C H E M _ I N V _ D T L S _ T 2 _ C H E M _ I N V ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ I N V _ D T L S ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ D T L S ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ D T L S _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ D T L S ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ D T L S _ T 2 _ C H E M _ I N V ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ C H E M _ I N V _ H A Z _ T 2 _ C H E M _ I N V ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 3 : 0 8   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ C H E M _ I N V _ H A Z _ T 2 _ C H E M _ I N V ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ I N V _ H A Z ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ H A Z ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ H A Z _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ H A Z ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ H A Z _ T 2 _ C H E M _ I N V ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ C H E M _ I N V _ H L T H _ T 2 _ C H E M _ I N V ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 3 : 1 1   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ C H E M _ I N V _ H L T H _ T 2 _ C H E M _ I N V ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ I N V _ H L T H ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ H L T H ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ H L T H _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ H L T H ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ H L T H _ T 2 _ C H E M _ I N V ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ C H E M _ I N V _ P H Y S _ T 2 _ C H E M _ I N V ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 3 : 1 4   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ C H E M _ I N V _ P H Y S _ T 2 _ C H E M _ I N V ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ I N V _ P H Y S ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ P H Y S ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ P H Y S _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ P H Y S ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ P H Y S _ T 2 _ C H E M _ I N V ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ C H E M _ L O C _ T 2 _ C H E M _ I N V ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 3 : 2 2   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ C H E M _ L O C _ T 2 _ C H E M _ I N V ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ L O C ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ L O C ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ L O C _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ L O C ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ L O C _ T 2 _ C H E M _ I N V ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ C H E M _ M I X _ T 2 _ C H E M _ I N V ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 3 : 2 6   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ C H E M _ M I X _ T 2 _ C H E M _ I N V ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ M I X ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ M I X ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ M I X _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ M I X ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ M I X _ T 2 _ C H E M _ I N V ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ D U N D B _ I D _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 3 : 2 9   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ F A C _ D U N D B _ I D _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ D U N D B _ I D ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ D U N D B _ I D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ D U N D B _ I D _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ D U N D B _ I D ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ D U N D B _ I D _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ G E O _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 0 2   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ F A C _ G E O _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ G E O ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ G E O ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ G E O _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ G E O ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ G E O _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ I N D _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 1 5   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ F A C _ I N D _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ I N D ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ I N D _ E M A I L _ T 2 _ F A C _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 1 9   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ F A C _ I N D _ E M A I L _ T 2 _ F A C _ I N D ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ I N D _ E M A I L ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ E M A I L ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ E M A I L _ T 2 _ F A C _ I N D ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ I N D ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ E M A I L ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ E M A I L _ T 2 _ F A C _ I N D ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ I N D _ P H O N E _ T 2 _ F A C _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 2 3   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ F A C _ I N D _ P H O N E _ T 2 _ F A C _ I N D ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ I N D _ P H O N E ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ P H O N E ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ P H O N E _ T 2 _ F A C _ I N D ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ I N D ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ P H O N E ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ P H O N E _ T 2 _ F A C _ I N D ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ I N D _ T Y P E _ T 2 _ F A C _ I N D ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 2 6   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ F A C _ I N D _ T Y P E _ T 2 _ F A C _ I N D ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ I N D _ T Y P E ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ T Y P E ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ T Y P E _ T 2 _ F A C _ I N D ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ I N D ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ T Y P E ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ T Y P E _ T 2 _ F A C _ I N D ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ N A I C S _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 3 1   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ F A C _ N A I C S _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ N A I C S ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ N A I C S ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ N A I C S _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ N A I C S ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ N A I C S _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ N P D E S _ I D _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 3 4   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ F A C _ N P D E S _ I D _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ N P D E S _ I D ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ N P D E S _ I D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ N P D E S _ I D _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ N P D E S _ I D ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ N P D E S _ I D _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ R C R A _ I D _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 3 7   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ F A C _ R C R A _ I D _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ R C R A _ I D ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ R C R A _ I D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ R C R A _ I D _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ R C R A _ I D ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ R C R A _ I D _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ S I C _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 4 : 4 0   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ F A C _ S I C _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ S I C ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ S I C ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ S I C _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ S I C ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ S I C _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ S I T E _ T 2 _ R E P O R T ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 0 4   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ F A C _ S I T E _ T 2 _ R E P O R T ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ S I T E ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ S I T E ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ S I T E _ T 2 _ R E P O R T ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ R E P O R T ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ S I T E ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ S I T E _ T 2 _ R E P O R T ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ F A C _ U I C _ I D _ T 2 _ F A C _ S I T E ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 0 7   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ F A C _ U I C _ I D _ T 2 _ F A C _ S I T E ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ U I C _ I D ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ U I C _ I D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ U I C _ I D _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ U I C _ I D ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ U I C _ I D _ T 2 _ F A C _ S I T E ]  
 G O  
 / * * * * * *   O b j e c t :     F o r e i g n K e y   [ F K _ T 2 _ R E P O R T _ T 2 _ S U B M I S S I O N ]         S c r i p t   D a t e :   1 1 / 2 6 / 2 0 0 8   1 4 : 2 5 : 1 6   * * * * * * /  
 I F   N O T   E X I S T S   ( S E L E C T   *   F R O M   s y s . f o r e i g n _ k e y s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F K _ T 2 _ R E P O R T _ T 2 _ S U B M I S S I O N ] ' )   A N D   p a r e n t _ o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ R E P O R T ] ' ) )  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ R E P O R T ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ R E P O R T _ T 2 _ S U B M I S S I O N ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ S U B M I S S I O N ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ R E P O R T ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ R E P O R T _ T 2 _ S U B M I S S I O N ]  
 G O  
 