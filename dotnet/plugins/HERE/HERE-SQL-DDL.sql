I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C H A N G E D _ F A C I L I T I E S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ C H A N G E D _ F A C I L I T I E S ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ C H A N G E D _ F A C I L I T I E S ] (  
 	 [ S T _ F A C _ I N D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F L O W _ T Y P E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ U P D A T E _ D A T E ]   [ d a t e t i m e ]   N O T   N U L L ,  
 	 [ I S _ D E L E T E D ]   [ b i t ]   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ C H G _ F A C ]   P R I M A R Y   K E Y   N O N C L U S T E R E D    
 (  
 	 [ S T _ F A C _ I N D ]   A S C ,  
 	 [ F L O W _ T Y P E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   C L U S T E R E D   I N D E X   [ I X _ C H A N G E D _ F A C I L I T I E S _ U P D A T E _ D A T E ]   O N   [ d b o ] . [ C H A N G E D _ F A C I L I T I E S ]    
 (  
 	 [ U P D A T E _ D A T E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ H E R E _ D o m a i n L i s t ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ H E R E _ D o m a i n L i s t ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ H E R E _ D o m a i n L i s t ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ D o m a i n L i s t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ O r i g i n a t i n g P a r t n e r N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ C h a n g e D a t e ]   [ d a t e t i m e ]   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ H E R E _ D o m a i n L i s t ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ I t e m C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ I t e m T e x t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ I t e m D e s c r i p t i o n T e x t ]   [ v a r c h a r ] ( 4 0 0 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ H E R E _ D o m a i n L i s t I t e m ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ H E R E _ D o m a i n L i s t I t e m _ H E R E _ D o m a i n L i s t ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ H E R E _ D o m a i n L i s t ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ H E R E _ D o m a i n L i s t I t e m ]   C H E C K   C O N S T R A I N T   [ F K _ H E R E _ D o m a i n L i s t I t e m _ H E R E _ D o m a i n L i s t ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ H E R E _ M a n i f e s t ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ H E R E _ M a n i f e s t ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ H E R E _ M a n i f e s t ] (  
 	 [ T r a n s a c t i o n I d ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ E n d p o i n t U R L ]   [ v a r c h a r ] ( 5 0 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ D a t a E x c h a n g e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ I s F a c i l i t y S o u r c e I n d i c a t o r ]   [ c h a r ] ( 1 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ S o u r c e S y s t e m N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F u l l R e p l a c e I n d i c a t o r ]   [ c h a r ] ( 1 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ C r e a t e d D a t e ]   [ d a t e t i m e ]   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ H E R E _ M a n i f e s t ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ T r a n s a c t i o n I d ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ G e t _ H E R E _ D o m a i n V a l u e s D a t a ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 D R O P   P R O C E D U R E   [ d b o ] . [ G e t _ H E R E _ D o m a i n V a l u e s D a t a ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 T K   C o n r a d  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 7 - 1 9  
 - -   D e s c r i p t i o n : 	 R e t u r n s   c o n t e n t s   o f   D o m a i n   V a l u e s   a n d   D o m a i n   V a l u e   I t e m s  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ G e t _ H E R E _ D o m a i n V a l u e s D a t a ]    
 	 @ c h a n g e D a t e   D a t e T i m e ,  
         @ L i s t I n d e x   i n t  
 A S  
 B E G I N  
 	 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 	 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 	 S E T   N O C O U N T   O N ;  
  
         - -   I n s e r t   s t a t e m e n t s   f o r   p r o c e d u r e   h e r e  
 I F   @ L i s t I n d e x   =   0  
  
         S E L E C T   [ P K _ G U I D ]   a s   L i s t I d  
                     , [ D o m a i n L i s t N a m e ]   a s   L i s t N a m e  
                     , [ O r i g i n a t i n g P a r t n e r N a m e ]   a s   L i s t O w n e r N a m e  
             F R O M   [ H E R E _ D o m a i n L i s t ]  
             W H E R E   C h a n g e D a t e   > =   @ c h a n g e D a t e ;  
  
 E L S E  
  
         S E L E C T    
 	 	         L . [ F K _ G U I D ]   a s   L i s t I d  
                     , L . [ I t e m C o d e ]   a s   I t e m C o d e  
                     , L . [ I t e m T e x t ]   a s   I t e m V a l u e  
                     , L . [ I t e m D e s c r i p t i o n T e x t ]   a s   I t e m D e s c  
             F R O M   [ H E R E _ D o m a i n L i s t I t e m ]   L  
         J O I N   [ H E R E _ D o m a i n L i s t ]   D   O N   D . P K _ G U I D   =   L . F K _ G U I D  
         W H E R E   D . C h a n g e D a t e   > =   @ c h a n g e D a t e ;  
  
 E N D  
  
  
  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ G e t _ H E R E _ M a n i f e s t D a t a ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 D R O P   P R O C E D U R E   [ d b o ] . [ G e t _ H E R E _ M a n i f e s t D a t a ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 T K   C o n r a d  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 7 - 1 8  
 - -   D e s c r i p t i o n : 	 L o a d s   t h e   H E R E   M a n i f e s t   t a b l e  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ G e t _ H E R E _ M a n i f e s t D a t a ]    
 	 @ c h a n g e D a t e   D a t e T i m e  
  
 A S  
 S E T   N O C O U N T   O N ;  
  
 S E L E C T   [ T r a n s a c t i o n I d ]  
             , [ E n d p o i n t U R L ]  
             , [ D a t a E x c h a n g e N a m e ]  
             , C O N V E R T ( B I T ,   C A S E   W H E N   [ I s F a c i l i t y S o u r c e I n d i c a t o r ]   =   ' Y '   T H E N   1   E L S E   0   E N D )   a s   I s F a c i l i t y S o u r c e I n d i c a t o r  
             , [ S o u r c e S y s t e m N a m e ]  
             , C O N V E R T ( B I T ,   C A S E   W H E N   [ F u l l R e p l a c e I n d i c a t o r ]   =   ' Y '   T H E N   1   E L S E   0   E N D )   a s   F u l l R e p l a c e I n d i c a t o r  
             , [ C r e a t e d D a t e ]  
     F R O M   [ H E R E _ M a n i f e s t ]  
  
         W H E R E   [ C r e a t e d D a t e ]   > =   @ c h a n g e D a t e  
  
 O R D E R   B Y   [ C r e a t e d D a t e ] ;  
  
  
  
  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ F A C _ D T L S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ F A C _ D T L S ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ F A C _ D T L S ] (  
 	 [ F A C _ D T L S _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C _ D T L S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ F A C _ D T L S _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ F A C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ F A C ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ F A C ] (  
 	 [ F A C _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F A C _ D T L S _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ C O N G _ D I S T _ N U M _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L E G I _ D I S T _ N U M _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H U C _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F A C _ U R L _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ D E L E T E D _ O N _ D A T E ]   [ d a t e t i m e ]   N U L L ,  
 	 [ F A C _ A C T I V E _ I N D I ]   [ v a r c h a r ] ( 1 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F A C _ S I T E _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F E D _ F A C _ I N D I ]   [ v a r c h a r ] ( 4 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F A C _ S I T E _ I D E N _ C O N T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F A C _ S I T E _ I D E N _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F A C _ S I T E _ T Y P E _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F A C _ S I T E _ T Y P E _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L I S T _ V E R S _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L I S T _ V E R S _ A G N _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L O C _ A D D R _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S U P P _ L O C _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L O C A _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T R I B _ L A N D _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T R I B _ L A N D _ I N D I ]   [ v a r c h a r ] ( 4 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L O C _ D E S C _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S T A _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S T A _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L O C _ A D D R _ C O D E _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L O C _ A D D R _ C O D E _ L I S T _ V E R S _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L O C _ A D D R _ C O D E _ L I S T _ V E R _ A G N _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ A D D R _ P O S T _ C O D E _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ A D D R _ P O S T _ C O D E _ C O N T ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C T R Y _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C T R Y _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L O C _ A D D R _ C O D _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L O C _ A D D R _ C O D E _ L I S T _ V E R S _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L O C _ A D D R _ C O D E _ L I S _ V E R _ A G N _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C N T Y _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C N T Y _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L O C _ A D D R _ C O D E _ L I S T _ V E R _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L O C _ A D D R _ C O D _ L I S _ V E R _ A G N _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L O C _ A D D _ C O D _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M A I L _ A D D R _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S U P P _ A D D R _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M A I L _ A D D R _ C I T Y _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M A I L _ A D D R _ S T A _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M A I L _ A D D R _ S T A _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M A I L _ A D D R _ C O D E _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M A I L _ A D D R _ C O D E _ L I S T _ V E R S _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M A I L _ A D D R _ C O D E _ L I S _ V E R _ A G N _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M A I L _ A D D R _ A D D R _ P O S T _ C O D E _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M A I L _ A D D R _ A D D R _ P O S T _ C O D E _ C O N T ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M A I L _ A D D R _ C T R Y _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M A I L _ A D D R _ C T R Y _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M A I L _ A D D R _ C O D _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M A I L _ A D D R _ C O D E _ L I S T _ V E R S _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M A I L _ A D D R _ C O D _ L I S _ V E R _ A G N _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ O R I G _ P A R T _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ I N F O _ S Y S _ A C R O _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L A S T _ U P D T _ D A T E ]   [ d a t e t i m e ]   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C I L I T Y _ I D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ F A C _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A _ M A _ A D _ A D _ P O ]   O N   [ d b o ] . [ F A C I D _ F A C ]    
 (  
 	 [ M A I L _ A D D R _ A D D R _ P O S T _ C O D E _ V A L ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ A D _ P O _ C O _ V A ]   O N   [ d b o ] . [ F A C I D _ F A C ]    
 (  
 	 [ A D D R _ P O S T _ C O D E _ V A L ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ C N T Y _ N A M E ]   O N   [ d b o ] . [ F A C I D _ F A C ]    
 (  
 	 [ C N T Y _ N A M E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ F A _ S I _ I D _ V A ]   O N   [ d b o ] . [ F A C I D _ F A C ]    
 (  
 	 [ F A C _ S I T E _ I D E N _ V A L ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ F A C _ D T L S _ I D ]   O N   [ d b o ] . [ F A C I D _ F A C ]    
 (  
 	 [ F A C _ D T L S _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ F A C _ S I T _ N A M ]   O N   [ d b o ] . [ F A C I D _ F A C ]    
 (  
 	 [ F A C _ S I T E _ N A M E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ I N _ S Y _ A C _ N A ]   O N   [ d b o ] . [ F A C I D _ F A C ]    
 (  
 	 [ I N F O _ S Y S _ A C R O _ N A M E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ L A S _ U P D _ D A T ]   O N   [ d b o ] . [ F A C I D _ F A C ]    
 (  
 	 [ L A S T _ U P D T _ D A T E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ L O C A _ N A M E ]   O N   [ d b o ] . [ F A C I D _ F A C ]    
 (  
 	 [ L O C A _ N A M E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ M A _ A D _ S T _ C O ]   O N   [ d b o ] . [ F A C I D _ F A C ]    
 (  
 	 [ M A I L _ A D D R _ S T A _ C O D E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ O R I _ P A R _ N A M ]   O N   [ d b o ] . [ F A C I D _ F A C ]    
 (  
 	 [ O R I G _ P A R T _ N A M E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ S T A _ C O D E ]   O N   [ d b o ] . [ F A C I D _ F A C ]    
 (  
 	 [ S T A _ C O D E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C _ F A C _ D T L S ]   F O R E I G N   K E Y ( [ F A C _ D T L S _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ F A C _ D T L S ]   ( [ F A C _ D T L S _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C ]   C H E C K   C O N S T R A I N T   [ F K _ F A C _ F A C _ D T L S ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ A F F L ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ A F F L ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ A F F L ] (  
 	 [ A F F L _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F A C _ D T L S _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ A F F L _ I D E N ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ I N D V _ T I T L E _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ N A M E _ P R E F I X _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ I N D V _ F U L L _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F I R S T _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M I D D L E _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L A S T _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ N A M E _ S U F F I X _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ I N D V _ I D E N _ C O N T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ I N D V _ I D E N _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ O R G _ F O R M A L _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ O R G _ I D E N _ C O N T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ O R G _ I D E N _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M A I L _ A D D R _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S U P P _ A D D R _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M A I L _ A D D R _ C I T Y _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S T A _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S T A _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L I S T _ V E R S _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L I S T _ V E R S _ A G N _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ A D D R _ P O S T _ C O D E _ C O N T ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ A D D R _ P O S T _ C O D E _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C T R Y _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C T R Y _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C T R Y _ I D E N _ C O D E _ L I S T _ V E R S _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C T R Y _ I D E N _ C O D E _ L I S _ V E R _ A G N _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C T R Y _ I D E N _ C O D E _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ A F F L ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ A F F L _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ A F F _ A D _ P O _ C O _ V A ]   O N   [ d b o ] . [ F A C I D _ A F F L ]    
 (  
 	 [ A D D R _ P O S T _ C O D E _ V A L ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ A F F L _ F A C _ D T L _ I D ]   O N   [ d b o ] . [ F A C I D _ A F F L ]    
 (  
 	 [ F A C _ D T L S _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ A F F L _ S T A _ C O D E ]   O N   [ d b o ] . [ F A C I D _ A F F L ]    
 (  
 	 [ S T A _ C O D E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   U N I Q U E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C I D _ A F F L ]   O N   [ d b o ] . [ F A C I D _ A F F L ]    
 (  
 	 [ A F F L _ I D E N ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ A F F L ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ A F F L _ F A C _ D T L S ]   F O R E I G N   K E Y ( [ F A C _ D T L S _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ F A C _ D T L S ]   ( [ F A C _ D T L S _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ A F F L ]   C H E C K   C O N S T R A I N T   [ F K _ A F F L _ F A C _ D T L S ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ E N V R _ I N T R ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R ] (  
 	 [ E N V R _ I N T R _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F A C _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ E N V R _ I N T R _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ E N V R _ I N T R _ T Y P E _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ E N V R _ I N T R _ S T A R T _ D A T E ]   [ d a t e t i m e ]   N U L L ,  
 	 [ E N V R _ I N T R _ S T A R T _ D A T E _ Q U A L _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ E N V R _ I N T R _ E N D _ D A T E ]   [ d a t e t i m e ]   N U L L ,  
 	 [ E N V R _ I N T R _ E N D _ D A T E _ Q U A L _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ E N V R _ I N T R _ A C T I V E _ I N D I ]   [ v a r c h a r ] ( 1 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ E N V R _ I N T R _ U R L _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ O R I G _ P A R T _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ I N F O _ S Y S _ A C R O _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L A S T _ U P D T _ D A T E ]   [ d a t e t i m e ]   N U L L ,  
 	 [ A G N _ T Y P E _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ A G N _ T Y P E _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L I S T _ V E R S _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L I S T _ V E R S _ A G N _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ E N V R _ I N T R ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ E N V R _ I N T R _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ E N _ I N _ I N _ S Y _ A C ]   O N   [ d b o ] . [ F A C I D _ E N V R _ I N T R ]    
 (  
 	 [ I N F O _ S Y S _ A C R O _ N A M E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ E N V _ I N _ L A _ U P _ D A ]   O N   [ d b o ] . [ F A C I D _ E N V R _ I N T R ]    
 (  
 	 [ L A S T _ U P D T _ D A T E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ E N V _ I N _ O R _ P A _ N A ]   O N   [ d b o ] . [ F A C I D _ E N V R _ I N T R ]    
 (  
 	 [ O R I G _ P A R T _ N A M E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ E N V R _ I N T _ F A C _ I D ]   O N   [ d b o ] . [ F A C I D _ E N V R _ I N T R ]    
 (  
 	 [ F A C _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ E N V R _ I N T R _ F A C ]   F O R E I G N   K E Y ( [ F A C _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ F A C ]   ( [ F A C _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R ]   C H E C K   C O N S T R A I N T   [ F K _ E N V R _ I N T R _ F A C ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ E N V R _ I N T R _ A L T _ I D E N ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ A L T _ I D E N ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ A L T _ I D E N ] (  
 	 [ E N V R _ I N T R _ A L T _ I D E N _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ E N V R _ I N T R _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ A L T _ I D E N _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ A L T _ I D E N _ T Y P E _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ E N V _ I N T _ A L T _ I D E ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ E N V R _ I N T R _ A L T _ I D E N _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ E N _ I N _ A L _ I D _ E N ]   O N   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ A L T _ I D E N ]    
 (  
 	 [ E N V R _ I N T R _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ A L T _ I D E N ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ E N _ I N _ A L _ I D _ E N ]   F O R E I G N   K E Y ( [ E N V R _ I N T R _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ E N V R _ I N T R ]   ( [ E N V R _ I N T R _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ A L T _ I D E N ]   C H E C K   C O N S T R A I N T   [ F K _ E N _ I N _ A L _ I D _ E N ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ E N V R _ I N T R _ E L E C _ A D D R ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ E L E C _ A D D R ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ E L E C _ A D D R ] (  
 	 [ E N V R _ I N T R _ E L E C _ A D D R _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ E N V R _ I N T R _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ E L E C _ A D D R _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ E L E C _ A D D R _ T Y P E _ N A M E ]   [ v a r c h a r ] ( 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ E N V _ I N T _ E L E _ A D D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ E N V R _ I N T R _ E L E C _ A D D R _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ E N _ I N _ E L _ A D _ E N ]   O N   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ E L E C _ A D D R ]    
 (  
 	 [ E N V R _ I N T R _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ E L E C _ A D D R ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ E N _ I N _ E L _ A D _ E N ]   F O R E I G N   K E Y ( [ E N V R _ I N T R _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ E N V R _ I N T R ]   ( [ E N V R _ I N T R _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ E L E C _ A D D R ]   C H E C K   C O N S T R A I N T   [ F K _ E N _ I N _ E L _ A D _ E N ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ A F F L ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ A F F L ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ A F F L ] (  
 	 [ E N V R _ I N T R _ F A C _ A F F L _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ E N V R _ I N T R _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ A F F L _ I D E N ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ A F F L _ T Y P E _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ A F F L _ S T A R T _ D A T E ]   [ d a t e t i m e ]   N U L L ,  
 	 [ A F F L _ E N D _ D A T E ]   [ d a t e t i m e ]   N U L L ,  
 	 [ A F F L _ S T A T _ T E X T ]   [ v a r c h a r ] ( 4 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ A F F L _ S T A T _ D E T R _ D A T E ]   [ d a t e t i m e ]   N U L L ,  
   C O N S T R A I N T   [ P K _ E N V _ I N T _ F A C _ A F F ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ E N V R _ I N T R _ F A C _ A F F L _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ E I _ A F F L _ I D E N ]   O N   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ A F F L ]    
 (  
 	 [ A F F L _ I D E N ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ E N _ I N _ F A _ A F _ E N ]   O N   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ A F F L ]    
 (  
 	 [ E N V R _ I N T R _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ A F F L ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ E N _ I N _ F A _ A F _ E N ]   F O R E I G N   K E Y ( [ E N V R _ I N T R _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ E N V R _ I N T R ]   ( [ E N V R _ I N T R _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ A F F L ]   C H E C K   C O N S T R A I N T   [ F K _ E N _ I N _ F A _ A F _ E N ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ A F F L ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C I D _ E N V R _ I N T R _ F A C _ A F F L _ F A C I D _ A F F L ]   F O R E I G N   K E Y ( [ A F F L _ I D E N ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ A F F L ]   ( [ A F F L _ I D E N ] )  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ A F F L ]   C H E C K   C O N S T R A I N T   [ F K _ F A C I D _ E N V R _ I N T R _ F A C _ A F F L _ F A C I D _ A F F L ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ N A I C S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ N A I C S ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ N A I C S ] (  
 	 [ E N V R _ I N T R _ F A C _ N A I C S _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ E N V R _ I N T R _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F A C _ N A I C S _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F A C _ N A I C S _ P R I _ I N D I ]   [ v a r c h a r ] ( 9 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ E N V _ I N T _ F A C _ N A I ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ E N V R _ I N T R _ F A C _ N A I C S _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ E N _ I N _ F A _ N A _ E N ]   O N   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ N A I C S ]    
 (  
 	 [ E N V R _ I N T R _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ N A I C S ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ E N _ I N _ F A _ N A _ E N ]   F O R E I G N   K E Y ( [ E N V R _ I N T R _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ E N V R _ I N T R ]   ( [ E N V R _ I N T R _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ N A I C S ]   C H E C K   C O N S T R A I N T   [ F K _ E N _ I N _ F A _ N A _ E N ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ S I C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ S I C ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ S I C ] (  
 	 [ E N V R _ I N T R _ F A C _ S I C _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ E N V R _ I N T R _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ S I C _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S I C _ P R I _ I N D I ]   [ v a r c h a r ] ( 9 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ E N V _ I N T _ F A C _ S I C ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ E N V R _ I N T R _ F A C _ S I C _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ E N _ I N _ F A _ S I _ E N ]   O N   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ S I C ]    
 (  
 	 [ E N V R _ I N T R _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ S I C ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ E N _ I N _ F A _ S I _ E N ]   F O R E I G N   K E Y ( [ E N V R _ I N T R _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ E N V R _ I N T R ]   ( [ E N V R _ I N T R _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ E N V R _ I N T R _ F A C _ S I C ]   C H E C K   C O N S T R A I N T   [ F K _ E N _ I N _ F A _ S I _ E N ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ A L T _ N A M E ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ A L T _ N A M E ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ A L T _ N A M E ] (  
 	 [ A L T _ N A M E _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F A C _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ A L T _ N A M E _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ A L T _ N A M E _ T Y P E _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ A L T _ N A M E ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ A L T _ N A M E _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ A L T _ N A M E _ F A C _ I D ]   O N   [ d b o ] . [ F A C I D _ A L T _ N A M E ]    
 (  
 	 [ F A C _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ A L T _ N A M E ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ A L T _ N A M E _ F A C ]   F O R E I G N   K E Y ( [ F A C _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ F A C ]   ( [ F A C _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ A L T _ N A M E ]   C H E C K   C O N S T R A I N T   [ F K _ A L T _ N A M E _ F A C ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ F A C _ A L T _ I D E N ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ F A C _ A L T _ I D E N ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ F A C _ A L T _ I D E N ] (  
 	 [ F A C _ A L T _ I D E N _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F A C _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ A L T _ I D E N _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ A L T _ I D E N _ T Y P E _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C _ A L T _ I D E N ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ F A C _ A L T _ I D E N _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ A L _ I D _ F A _ I D ]   O N   [ d b o ] . [ F A C I D _ F A C _ A L T _ I D E N ]    
 (  
 	 [ F A C _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C _ A L T _ I D E N ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C _ A L T _ I D E _ F A C ]   F O R E I G N   K E Y ( [ F A C _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ F A C ]   ( [ F A C _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C _ A L T _ I D E N ]   C H E C K   C O N S T R A I N T   [ F K _ F A C _ A L T _ I D E _ F A C ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ A F F L _ E L E C _ A D D R ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ A F F L _ E L E C _ A D D R ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ A F F L _ E L E C _ A D D R ] (  
 	 [ A F F L _ E L E C _ A D D R _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ A F F L _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ E L E C _ A D D R _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ E L E C _ A D D R _ T Y P E _ N A M E ]   [ v a r c h a r ] ( 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ A F F L _ E L E C _ A D D R ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ A F F L _ E L E C _ A D D R _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ A F F _ E L _ A D _ A F _ I D ]   O N   [ d b o ] . [ F A C I D _ A F F L _ E L E C _ A D D R ]    
 (  
 	 [ A F F L _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ A F F L _ E L E C _ A D D R ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ A F F _ E L E _ A D D _ A F F ]   F O R E I G N   K E Y ( [ A F F L _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ A F F L ]   ( [ A F F L _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ A F F L _ E L E C _ A D D R ]   C H E C K   C O N S T R A I N T   [ F K _ A F F _ E L E _ A D D _ A F F ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ F A C _ E L E C _ A D D R ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ F A C _ E L E C _ A D D R ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ F A C _ E L E C _ A D D R ] (  
 	 [ F A C _ E L E C _ A D D R _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F A C _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ E L E C _ A D D R _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ E L E C _ A D D R _ T Y P E _ N A M E ]   [ v a r c h a r ] ( 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C _ E L E C _ A D D R ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ F A C _ E L E C _ A D D R _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ E L _ A D _ F A _ I D ]   O N   [ d b o ] . [ F A C I D _ F A C _ E L E C _ A D D R ]    
 (  
 	 [ F A C _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C _ E L E C _ A D D R ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C _ E L E _ A D D _ F A C ]   F O R E I G N   K E Y ( [ F A C _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ F A C ]   ( [ F A C _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C _ E L E C _ A D D R ]   C H E C K   C O N S T R A I N T   [ F K _ F A C _ E L E _ A D D _ F A C ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ F A C _ F A C _ A F F L ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ F A C _ F A C _ A F F L ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ F A C _ F A C _ A F F L ] (  
 	 [ F A C _ F A C _ A F F L _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F A C _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ A F F L _ I D E N ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ A F F L _ T Y P E _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ A F F L _ S T A R T _ D A T E ]   [ d a t e t i m e ]   N U L L ,  
 	 [ A F F L _ E N D _ D A T E ]   [ d a t e t i m e ]   N U L L ,  
 	 [ A F F L _ S T A T _ T E X T ]   [ v a r c h a r ] ( 4 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ A F F L _ S T A T _ D E T R _ D A T E ]   [ d a t e t i m e ]   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C _ F A C _ A F F L ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ F A C _ F A C _ A F F L _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ A F F L _ I D E N ]   O N   [ d b o ] . [ F A C I D _ F A C _ F A C _ A F F L ]    
 (  
 	 [ A F F L _ I D E N ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ F A _ A F _ F A _ I D ]   O N   [ d b o ] . [ F A C I D _ F A C _ F A C _ A F F L ]    
 (  
 	 [ F A C _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C _ F A C _ A F F L ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C _ F A C _ A F F _ F A C ]   F O R E I G N   K E Y ( [ F A C _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ F A C ]   ( [ F A C _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C _ F A C _ A F F L ]   C H E C K   C O N S T R A I N T   [ F K _ F A C _ F A C _ A F F _ F A C ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C _ F A C _ A F F L ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C I D _ F A C _ F A C _ A F F L _ F A C I D _ A F F L ]   F O R E I G N   K E Y ( [ A F F L _ I D E N ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ A F F L ]   ( [ A F F L _ I D E N ] )  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C _ F A C _ A F F L ]   C H E C K   C O N S T R A I N T   [ F K _ F A C I D _ F A C _ F A C _ A F F L _ F A C I D _ A F F L ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ F A C _ F A C _ N A I C S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ F A C _ F A C _ N A I C S ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ F A C _ F A C _ N A I C S ] (  
 	 [ F A C _ F A C _ N A I C S _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F A C _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F A C _ N A I C S _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F A C _ N A I C S _ P R I _ I N D I ]   [ v a r c h a r ] ( 9 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C _ F A C _ N A I C S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ F A C _ F A C _ N A I C S _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ F A _ N A _ F A _ I D ]   O N   [ d b o ] . [ F A C I D _ F A C _ F A C _ N A I C S ]    
 (  
 	 [ F A C _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C _ F A C _ N A I C S ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C _ F A C _ N A I _ F A C ]   F O R E I G N   K E Y ( [ F A C _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ F A C ]   ( [ F A C _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C _ F A C _ N A I C S ]   C H E C K   C O N S T R A I N T   [ F K _ F A C _ F A C _ N A I _ F A C ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ F A C _ F A C _ S I C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ F A C _ F A C _ S I C ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ F A C _ F A C _ S I C ] (  
 	 [ F A C _ F A C _ S I C _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F A C _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ S I C _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S I C _ P R I _ I N D I ]   [ v a r c h a r ] ( 9 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C _ F A C _ S I C ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ F A C _ F A C _ S I C _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ F A _ S I _ F A _ I D ]   O N   [ d b o ] . [ F A C I D _ F A C _ F A C _ S I C ]    
 (  
 	 [ F A C _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C _ F A C _ S I C ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C _ F A C _ S I C _ F A C ]   F O R E I G N   K E Y ( [ F A C _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ F A C ]   ( [ F A C _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C _ F A C _ S I C ]   C H E C K   C O N S T R A I N T   [ F K _ F A C _ F A C _ S I C _ F A C ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ F A C _ G E O _ L O C _ D E S C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ F A C _ G E O _ L O C _ D E S C ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ F A C _ G E O _ L O C _ D E S C ] (  
 	 [ F A C _ G E O _ L O C _ D E S C _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F A C _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ S R C _ M A P _ S C A L E _ N U M ]   [ v a r c h a r ] ( 2 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ D A T A _ C O L L _ D A T E ]   [ d a t e t i m e ]   N U L L ,  
 	 [ L O C _ C O M M _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S R S _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S R S _ D I M ]   [ v a r c h a r ] ( 1 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L A T I T U D E ]   [ d e c i m a l ] ( 1 9 ,   1 4 )   N U L L ,  
 	 [ L O N G I T U D E ]   [ d e c i m a l ] ( 1 9 ,   1 4 )   N U L L ,  
 	 [ E L E V A T I O N ]   [ d e c i m a l ] ( 1 9 ,   1 4 )   N U L L ,  
 	 [ M E A S _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M E A S _ P R E C _ T E X T ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M E A S _ U N I T _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M E A S _ U N I T _ N A M E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L I S T _ V E R S _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L I S T _ V E R S _ A G N _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R S L T _ Q U A L _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R S L T _ Q U A L _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R S L T _ Q U A L _ C O D E _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R S L T _ Q U A L _ C O D E _ L I S T _ V E R S _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R S L T _ Q U A L _ C O D E _ L I S _ V E R _ A G N _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M E T H _ I D E N _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M E T H _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M E T H _ D E S C _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M E T H _ D E V I _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R Z _ C O L L _ M E T H _ C O D _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R Z _ C O L L _ M E T H _ C O D _ L I S _ V E R _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R _ C O L _ M E T _ C O D _ L I S _ V E R _ A G N _ I D ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ G E O _ R E F _ P T _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ G E O _ R E F _ P T _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ G E O _ R E F _ P T _ C O D E _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ G E O _ R E F _ P T _ C O D E _ L I S T _ V E R S _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ G E O _ R E F _ P T _ C O D _ L I S _ V E R _ A G N _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ M E T H _ I D E N _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ M E T H _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ M E T H _ D E S C _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ M E T H _ D E V I _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ C O D _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ C O D _ L I S _ V E R _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R _ C O L _ M E T _ C O D _ L I S _ V E R _ A G N _ I D ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R F _ M E T H _ M E T H _ I D E N _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R F _ M E T H _ M E T H _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R F _ M E T H _ M E T H _ D E S C _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R F _ M E T H _ M E T H _ D E V I _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R F _ M E T H _ C O D E _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R F _ M E T H _ C O D E _ L I S T _ V E R S _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R F _ M E T H _ C O D E _ L I S _ V E R _ A G N _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O R D _ D A T A _ S R C _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O R D _ D A T A _ S R C _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O R D _ D A T A _ S R C _ C O D E _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O R D _ D A T A _ S R C _ C O D E _ L I S _ V E R _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O R _ D A T _ S R C _ C O D _ L I S _ V E R _ A G N _ I D ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C _ G E O _ L O C _ D E S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ F A C _ G E O _ L O C _ D E S C _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A _ G E _ L O _ D E _ F A ]   O N   [ d b o ] . [ F A C I D _ F A C _ G E O _ L O C _ D E S C ]    
 (  
 	 [ F A C _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ G E _ L O _ D E _ E L ]   O N   [ d b o ] . [ F A C I D _ F A C _ G E O _ L O C _ D E S C ]    
 (  
 	 [ E L E V A T I O N ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ G E _ L O _ D E _ L A ]   O N   [ d b o ] . [ F A C I D _ F A C _ G E O _ L O C _ D E S C ]    
 (  
 	 [ L A T I T U D E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ G E _ L O _ D E _ L O ]   O N   [ d b o ] . [ F A C I D _ F A C _ G E O _ L O C _ D E S C ]    
 (  
 	 [ L O N G I T U D E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C _ G E O _ L O C _ D E S C ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C _ G E _ L O _ D E _ F A ]   F O R E I G N   K E Y ( [ F A C _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ F A C ]   ( [ F A C _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C _ G E O _ L O C _ D E S C ]   C H E C K   C O N S T R A I N T   [ F K _ F A C _ G E _ L O _ D E _ F A ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ F A C _ P R I _ G E O _ L O C _ D E S C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ F A C _ P R I _ G E O _ L O C _ D E S C ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ F A C _ P R I _ G E O _ L O C _ D E S C ] (  
 	 [ F A C _ P R I _ G E O _ L O C _ D E S C _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F A C _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ S R C _ M A P _ S C A L E _ N U M ]   [ v a r c h a r ] ( 2 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ D A T A _ C O L L _ D A T E ]   [ d a t e t i m e ]   N U L L ,  
 	 [ L O C _ C O M M _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S R S _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S R S _ D I M ]   [ v a r c h a r ] ( 1 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L A T I T U D E ]   [ d e c i m a l ] ( 1 9 ,   1 4 )   N U L L ,  
 	 [ L O N G I T U D E ]   [ d e c i m a l ] ( 1 9 ,   1 4 )   N U L L ,  
 	 [ E L E V A T I O N ]   [ d e c i m a l ] ( 1 9 ,   1 4 )   N U L L ,  
 	 [ M E A S _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M E A S _ P R E C _ T E X T ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M E A S _ U N I T _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M E A S _ U N I T _ N A M E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L I S T _ V E R S _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L I S T _ V E R S _ A G N _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R S L T _ Q U A L _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R S L T _ Q U A L _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R S L T _ Q U A L _ C O D E _ L I S T _ V E R S _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R S L T _ Q U A L _ C O D E _ L I S _ V E R _ A G N _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R S L T _ Q U A L _ C O D E _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M E T H _ I D E N _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M E T H _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M E T H _ D E S C _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M E T H _ D E V I _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R Z _ C O L L _ M E T H _ C O D _ L I S _ V E R _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R _ C O L _ M E T _ C O D _ L I S _ V E R _ A G N _ I D ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R Z _ C O L L _ M E T H _ C O D _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ G E O _ R E F _ P T _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ G E O _ R E F _ P T _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ G E O _ R E F _ P T _ C O D E _ L I S T _ V E R S _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ G E O _ R E F _ P T _ C O D _ L I S _ V E R _ A G N _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ G E O _ R E F _ P T _ C O D E _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ M E T H _ I D E N _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ M E T H _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ M E T H _ D E S C _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ M E T H _ D E V I _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ C O D _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ C O D _ L I S _ V E R _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R _ C O L _ M E T _ C O D _ L I S _ V E R _ A G N _ I D ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R F _ M E T H _ M E T H _ I D E N _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R F _ M E T H _ M E T H _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R F _ M E T H _ M E T H _ D E S C _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R F _ M E T H _ M E T H _ D E V I _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R F _ M E T H _ C O D E _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R F _ M E T H _ C O D E _ L I S T _ V E R S _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R F _ M E T H _ C O D E _ L I S _ V E R _ A G N _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O R D _ D A T A _ S R C _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O R D _ D A T A _ S R C _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O R D _ D A T A _ S R C _ C O D E _ L I S _ V E R _ I D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O R _ D A T _ S R C _ C O D _ L I S _ V E R _ A G N _ I D ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O R D _ D A T A _ S R C _ C O D E _ L S T _ V E R _ V A L ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C _ P R _ G E _ L O _ D E ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ F A C _ P R I _ G E O _ L O C _ D E S C _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A _ P R _ G E _ L O _ 0 2 ]   O N   [ d b o ] . [ F A C I D _ F A C _ P R I _ G E O _ L O C _ D E S C ]    
 (  
 	 [ L A T I T U D E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A _ P R _ G E _ L O _ 0 3 ]   O N   [ d b o ] . [ F A C I D _ F A C _ P R I _ G E O _ L O C _ D E S C ]    
 (  
 	 [ L O N G I T U D E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A _ P R _ G E _ L O _ 0 4 ]   O N   [ d b o ] . [ F A C I D _ F A C _ P R I _ G E O _ L O C _ D E S C ]    
 (  
 	 [ E L E V A T I O N ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A _ P R _ G E _ L O _ D E ]   O N   [ d b o ] . [ F A C I D _ F A C _ P R I _ G E O _ L O C _ D E S C ]    
 (  
 	 [ F A C _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C _ P R I _ G E O _ L O C _ D E S C ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ F A _ P R _ G E _ L O _ D E ]   F O R E I G N   K E Y ( [ F A C _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ F A C ]   ( [ F A C _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ F A C _ P R I _ G E O _ L O C _ D E S C ]   C H E C K   C O N S T R A I N T   [ F K _ F A _ P R _ G E _ L O _ D E ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ S H A P E ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ S H A P E ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ S H A P E ] (  
 	 [ S H A P E _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F A C _ G E O _ L O C _ D E S C _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T Y P E ]   [ v a r c h a r ] ( 1 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ S R S _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S R S _ D I M ]   [ v a r c h a r ] ( 1 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ S H A P E ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S H A P E _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ S H _ F A _ G E _ L O _ D E ]   O N   [ d b o ] . [ F A C I D _ S H A P E ]    
 (  
 	 [ F A C _ G E O _ L O C _ D E S C _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ S H A P E ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ S H A _ F A _ G E _ L O _ D E ]   F O R E I G N   K E Y ( [ F A C _ G E O _ L O C _ D E S C _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ F A C _ G E O _ L O C _ D E S C ]   ( [ F A C _ G E O _ L O C _ D E S C _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ S H A P E ]   C H E C K   C O N S T R A I N T   [ F K _ S H A _ F A _ G E _ L O _ D E ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ P O S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ P O S ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ P O S ] (  
 	 [ P O S _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ S H A P E _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ O R D E R _ I N D E X ]   [ i n t ]   N O T   N U L L ,  
 	 [ L A T I T U D E ]   [ d e c i m a l ] ( 1 9 ,   1 4 )   N U L L ,  
 	 [ L O N G I T U D E ]   [ d e c i m a l ] ( 1 9 ,   1 4 )   N U L L ,  
 	 [ E L E V A T I O N ]   [ d e c i m a l ] ( 1 9 ,   1 4 )   N U L L ,  
   C O N S T R A I N T   [ P K _ P O S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P O S _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ P O S _ E L E V A T I O N ]   O N   [ d b o ] . [ F A C I D _ P O S ]    
 (  
 	 [ E L E V A T I O N ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ P O S _ L A T I T U D E ]   O N   [ d b o ] . [ F A C I D _ P O S ]    
 (  
 	 [ L A T I T U D E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ P O S _ L O N G I T U D E ]   O N   [ d b o ] . [ F A C I D _ P O S ]    
 (  
 	 [ L O N G I T U D E ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ P O S _ S H A P E _ I D ]   O N   [ d b o ] . [ F A C I D _ P O S ]    
 (  
 	 [ S H A P E _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ P O S ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ P O S _ S H A P E ]   F O R E I G N   K E Y ( [ S H A P E _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ S H A P E ]   ( [ S H A P E _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ P O S ]   C H E C K   C O N S T R A I N T   [ F K _ P O S _ S H A P E ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ F A C I D _ T E L E P H O N I C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ F A C I D _ T E L E P H O N I C ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ F A C I D _ T E L E P H O N I C ] (  
 	 [ T E L E P H O N I C _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ A F F L _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T E L E _ N U M _ T E X T ]   [ v a r c h a r ] ( 2 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T E L E _ N U M _ T Y P E _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T E L E _ E X T _ N U M _ T E X T ]   [ v a r c h a r ] ( 2 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ T E L E P H O N I C ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ T E L E P H O N I C _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ T E L E P H O _ A F F L _ I D ]   O N   [ d b o ] . [ F A C I D _ T E L E P H O N I C ]    
 (  
 	 [ A F F L _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ T E L E P H O N I C ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T E L E P H O N I C _ A F F L ]   F O R E I G N   K E Y ( [ A F F L _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ F A C I D _ A F F L ]   ( [ A F F L _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ F A C I D _ T E L E P H O N I C ]   C H E C K   C O N S T R A I N T   [ F K _ T E L E P H O N I C _ A F F L ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ F A C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ C A F O _ F A C ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ C A F O _ F A C ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F A C I L I T Y S I T E N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F A C I L I T Y A L T N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F A C I L I T Y I N F O U R L ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F A C I L I T Y R E G I S T R Y I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S T A T E F A C I L I T Y I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ F A C I L I T Y ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ A D D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ C A F O _ A D D ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ C A F O _ A D D ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ L O C A T I O N A D D R E S S ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S U P P L E M E N T A L A D D R E S S ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L O C A L I T Y N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O U N T Y N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S T A T E N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S T A T E U S P S C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ A D D R E S S P O S T A L C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ L O C A T I O N A D D R E S S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ C A F O _ A D D _ C A F O _ F A C ]   O N   [ d b o ] . [ C A F O _ A D D ]    
 (  
 	 [ F K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ A D D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ L O C A D D R E S S _ F A C I L I T Y ]   F O R E I G N   K E Y ( [ F K ] )  
 R E F E R E N C E S   [ d b o ] . [ C A F O _ F A C ]   ( [ P K ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ A D D ]   C H E C K   C O N S T R A I N T   [ F K _ L O C A D D R E S S _ F A C I L I T Y ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ A N I M A L ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ C A F O _ A N I M A L ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ C A F O _ A N I M A L ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ A N I M A L T Y P E C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ A N I M A L T Y P E N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T O T A L N U M S E A C H L I V E S T O C K ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ O P E N C O U N T ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O U S E D U N D E R R O O F C O U N T ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ A N I M A L T Y P E ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ C A F O _ A N I M A L _ C A F O _ F A C ]   O N   [ d b o ] . [ C A F O _ A N I M A L ]    
 (  
 	 [ F K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ A N I M A L ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ A N I M A L T Y P E _ F A C I L I T Y ]   F O R E I G N   K E Y ( [ F K ] )  
 R E F E R E N C E S   [ d b o ] . [ C A F O _ F A C ]   ( [ P K ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ A N I M A L ]   C H E C K   C O N S T R A I N T   [ F K _ A N I M A L T Y P E _ F A C I L I T Y ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ G E O ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ C A F O _ G E O ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ C A F O _ G E O ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ L A T I T U D E ]   [ v a r c h a r ] ( 1 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ L O N G I T U D E ]   [ v a r c h a r ] ( 1 1 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ H O R I Z A C C U R V A L U E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z A C C U R U N I T C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z A C C U R U N I T C O D E L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z A C C U R U N I T N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ P R E C T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R E S U L T Q U A L C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R E S U L T Q U A L C O D E L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R E S U L T Q U A L N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z M E T H O D I D C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z M E T H O D I D C O D E L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z M E T H O D N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z M E T H O D D E S C ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z M E T H O D D E V I A T I O N S ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H Y D R O L O G I C U N I T C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L O C A T I O N C O M M E N T S ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ G E O G R A P H I C L O C A T I O N ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ C A F O _ G E O _ C A F O _ F A C ]   O N   [ d b o ] . [ C A F O _ G E O ]    
 (  
 	 [ F K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ G E O ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ G E O L O C _ F A C I L I T Y ]   F O R E I G N   K E Y ( [ F K ] )  
 R E F E R E N C E S   [ d b o ] . [ C A F O _ F A C ]   ( [ P K ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ G E O ]   C H E C K   C O N S T R A I N T   [ F K _ G E O L O C _ F A C I L I T Y ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ R E G _ D T L S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ C A F O _ R E G _ D T L S ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ C A F O _ R E G _ D T L S ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ D I S C H R G F R O M P R O D A R E A ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ A U T H O R I Z E D D I S C H A R G E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ U N A U T H O R I Z E D D I S C H A R G E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ P E R M I T T I N G A U T H R E P R E C D A T E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ I S A N I M A L F A C I L I T Y T Y P E C A F O ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L I Q M A N U R E V A L U E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L I Q M A N U R E U N I T C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L I Q M A N U R E U N I T C O D E L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L I Q M A N U R E U N I T N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L I Q M A N U R E P R E C ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L I Q M A N U R E R E S U L T C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L I Q M A N U R E R E S U L T C O D E L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L I Q M A N U R E R E S U L T N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L I Q M A N U R E T R A N V A L U E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L I Q M A N U R E T R A N U N I T C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L I Q M A N U R E T R A N U N I T C O D E L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L I Q M A N U R E T R A N U N I T N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L I Q M A N U R E T R A N P R E C ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L I Q M A N U R E T R A N R E S U L T C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L I Q M A N U R E T R A N R E S U L T C O D E L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L I Q M A N U R E T R A N R E S U L T N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S O L M A N U R E V A L U E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S O L M A N U R E U N I T C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S O L M A N U R E U N I T C O D E L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S O L M A N U R E U N I T N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S O L M A N U R E P R E C ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S O L M A N U R E R E S U L T C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S O L M A N U R E R E S U L T C O D E L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S O L M A N U R E R E S U L T N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S O L M A N U R E T R A N V A L U E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S O L M A N U R E T R A N U N I T C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S O L M A N U R E T R A N U N I T C O D E L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S O L M A N U R E T R A N U N I T N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S O L M A N U R E T R A N P R E C ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S O L M A N U R E T R A N R E S U L T C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S O L M A N U R E T R A N R E S U L T C O D E L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S O L M A N U R E T R A N R E S U L T N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ N M P D E V C E R T P L A N A P P R O V E D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T O T A L N U M A C R E S N M P I D E N T I F I E D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T O T A L N U M A C R E S U S E D L A N D A P P ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ R E G U L A T O R Y D E T A I L S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ C A F O _ R E G _ D T L S _ C A F O _ F A C ]   O N   [ d b o ] . [ C A F O _ R E G _ D T L S ]    
 (  
 	 [ F K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ R E G _ D T L S ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ R E G D E T A I L S _ F A C I L I T Y ]   F O R E I G N   K E Y ( [ F K ] )  
 R E F E R E N C E S   [ d b o ] . [ C A F O _ F A C ]   ( [ P K ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ R E G _ D T L S ]   C H E C K   C O N S T R A I N T   [ F K _ R E G D E T A I L S _ F A C I L I T Y ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ P E R M I T ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ C A F O _ P E R M I T ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ C A F O _ P E R M I T ] (  
 	 [ P K ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ P E R M I T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ P E R M I T N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ O T H E R P E R M I T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ P R O G R A M N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ P E R M I T T Y P E C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ P E R M I T T Y P E C O D E L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ P E R M I T T Y P E N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ C A F O _ P E R M I T ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ C A F O _ P E R M I T _ C A F O _ R E G _ D T L S ]   O N   [ d b o ] . [ C A F O _ P E R M I T ]    
 (  
 	 [ F K ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ P E R M I T ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ P E R M I T _ R E G D E T A I L S ]   F O R E I G N   K E Y ( [ F K ] )  
 R E F E R E N C E S   [ d b o ] . [ C A F O _ R E G _ D T L S ]   ( [ P K ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ C A F O _ P E R M I T ]   C H E C K   C O N S T R A I N T   [ F K _ P E R M I T _ R E G D E T A I L S ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ C A F O _ G e t C A F O B y C h a n g e D a t e ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 D R O P   P R O C E D U R E   [ d b o ] . [ C A F O _ G e t C A F O B y C h a n g e D a t e ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
  
  
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
 S E T   @ f l o w T y p e   =   ' H E R E - C A F O ' ;  
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
  
  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T A N K S _ S U B M I S S I O N ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T A N K S _ S U B M I S S I O N ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T A N K S _ S U B M I S S I O N ] (  
 	 [ S U B M I S S I O N _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ S U B M I S S I O N ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ S U B M I S S I O N _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T A N K S _ F A C _ S I T E ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T A N K S _ F A C _ S I T E ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T A N K S _ F A C _ S I T E ] (  
 	 [ F A C _ S I T E _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ S U B M I S S I O N _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F A C _ S I T E _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F E D E R A L _ F A C _ I N D ]   [ v a r c h a r ] ( 4 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F A C _ S I T E _ I D E N _ C O N T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F A C _ S I T E _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F A C _ S I T E _ T Y P E _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F A C _ S I T E _ T Y P E _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L I S T _ V E R S I O N _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L I S T _ V E R S I O N _ A G E N C Y _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O D E _ L I S T _ V A L U E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C _ S I T E ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ F A C _ S I T E _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ S I T E _ S U B _ I D ]   O N   [ d b o ] . [ T A N K S _ F A C _ S I T E ]    
 (  
 	 [ S U B M I S S I O N _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T A N K S _ F A C _ S I T E ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ F A C _ S I T E _ S U B M I S ]   F O R E I G N   K E Y ( [ S U B M I S S I O N _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T A N K S _ S U B M I S S I O N ]   ( [ S U B M I S S I O N _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T A N K S _ F A C _ S I T E ]   C H E C K   C O N S T R A I N T   [ F K _ F A C _ S I T E _ S U B M I S ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T A N K S _ T A N K ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T A N K S _ T A N K ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T A N K S _ T A N K ] (  
 	 [ T A N K _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F A C _ S I T E _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T A N K _ T Y P E _ T E X T ]   [ v a r c h a r ] ( 3 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T A N K _ U S E _ S T A T U S _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T A N K _ I D E N _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T A N K _ I N S T A L L _ D A T E ]   [ d a t e t i m e ]   N U L L ,  
 	 [ T A N K _ I S _ C O N F _ I N D ]   [ v a r c h a r ] ( 1 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T A N K _ C O N S T _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T A N K _ D E S C _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T A N K _ L O C _ D E S C _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ T A N K ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ T A N K _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ T A N K _ F A C _ S I T _ I D ]   O N   [ d b o ] . [ T A N K S _ T A N K ]    
 (  
 	 [ F A C _ S I T E _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T A N K S _ T A N K ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T A N K _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F A C _ S I T E _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T A N K S _ F A C _ S I T E ]   ( [ F A C _ S I T E _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T A N K S _ T A N K ]   C H E C K   C O N S T R A I N T   [ F K _ T A N K _ F A C _ S I T E ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T A N K S _ E X T E R N A L _ P R O T E C T I O N ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T A N K S _ E X T E R N A L _ P R O T E C T I O N ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T A N K S _ E X T E R N A L _ P R O T E C T I O N ] (  
 	 [ E X T E R N A L _ P R O T E C T I O N _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T A N K _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ E X T E R N _ P R O T E C T I ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ E X T E R N A L _ P R O T E C T I O N _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ E X T E _ P R O _ T A N _ I D ]   O N   [ d b o ] . [ T A N K S _ E X T E R N A L _ P R O T E C T I O N ]    
 (  
 	 [ T A N K _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T A N K S _ E X T E R N A L _ P R O T E C T I O N ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ E X T E R _ P R O T _ T A N K ]   F O R E I G N   K E Y ( [ T A N K _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T A N K S _ T A N K ]   ( [ T A N K _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T A N K S _ E X T E R N A L _ P R O T E C T I O N ]   C H E C K   C O N S T R A I N T   [ F K _ E X T E R _ P R O T _ T A N K ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T A N K S _ I N T E R N A L _ P R O T E C T I O N ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T A N K S _ I N T E R N A L _ P R O T E C T I O N ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T A N K S _ I N T E R N A L _ P R O T E C T I O N ] (  
 	 [ I N T E R N A L _ P R O T E C T I O N _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T A N K _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ I N T E R N _ P R O T E C T I ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ I N T E R N A L _ P R O T E C T I O N _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ I N T E _ P R O _ T A N _ I D ]   O N   [ d b o ] . [ T A N K S _ I N T E R N A L _ P R O T E C T I O N ]    
 (  
 	 [ T A N K _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T A N K S _ I N T E R N A L _ P R O T E C T I O N ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ I N T E R _ P R O T _ T A N K ]   F O R E I G N   K E Y ( [ T A N K _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T A N K S _ T A N K ]   ( [ T A N K _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T A N K S _ I N T E R N A L _ P R O T E C T I O N ]   C H E C K   C O N S T R A I N T   [ F K _ I N T E R _ P R O T _ T A N K ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T A N K S _ T A N K _ C O M P A R T ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T A N K S _ T A N K _ C O M P A R T ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T A N K S _ T A N K _ C O M P A R T ] (  
 	 [ T A N K _ C O M P A R T _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T A N K _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T A N K _ C O M P A R T _ C A P A C I T Y _ N U M ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T A N K _ C O M P A R T _ I N S T A L L _ D A T E ]   [ d a t e t i m e ]   N U L L ,  
 	 [ T A N K _ C O M P A R T _ I D E N _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T A N K _ C O M P A R T _ H A S _ S E C _ C O N T _ I N D ]   [ v a r c h a r ] ( 1 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ P I P I N G _ S Y S T E M _ T Y P E _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ P I P I N G _ H A S _ S E C _ C O N T _ I N D ]   [ v a r c h a r ] ( 1 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T A N K _ C O N T E N T _ I S _ M I X T U R E _ I N D ]   [ v a r c h a r ] ( 1 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T A N K _ C O N T E N T _ I S _ C O N F _ I N D ]   [ v a r c h a r ] ( 1 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ T A N K _ C O M P A R T ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ T A N K _ C O M P A R T _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ T A N K _ C O M _ T A N _ I D ]   O N   [ d b o ] . [ T A N K S _ T A N K _ C O M P A R T ]    
 (  
 	 [ T A N K _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T A N K S _ T A N K _ C O M P A R T ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T A N K _ C O M P A _ T A N K ]   F O R E I G N   K E Y ( [ T A N K _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T A N K S _ T A N K ]   ( [ T A N K _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T A N K S _ T A N K _ C O M P A R T ]   C H E C K   C O N S T R A I N T   [ F K _ T A N K _ C O M P A _ T A N K ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T A N K S _ C H E M _ S U B S _ I D E N ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T A N K S _ C H E M _ S U B S _ I D E N ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T A N K S _ C H E M _ S U B S _ I D E N ] (  
 	 [ C H E M _ S U B S _ I D E N _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T A N K _ C O M P A R T _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ E P A _ C H E M _ I N T E R N A L _ N U M ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C A S _ R E G _ N U M ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C H E M _ S U B S _ S Y S T E M A T I C _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ E P A _ C H E M _ R E G _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ E P A _ C H E M _ I D E N ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C H E M _ N A M E _ C O N T E X T _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ E P A _ C H E M _ R E G _ N A M E _ S R C _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ E P A _ C H E M _ R E G _ N A M E _ C O N T E X T _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C H E M _ S U B S _ D E F I N I T I O N _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C H E M _ S U B S _ C O M M E N T _ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C H E M _ S U B S _ S Y N O N Y M _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M O L E C U L A R _ F O R M U L A _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C H E M _ S U B S _ F O R M U L A _ W G H T _ Q N T Y ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C H E M _ S U B S _ T Y P E _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C H E M _ S U B S _ L I N E A R _ S T R U _ C O D E ]   [ v a r c h a r ] ( 5 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C H E M _ S T R U _ G R A P H I C A L _ D I A G R A M ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C H E M _ S U B S _ C L A S S I F I C A T I O N _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C H E M _ S Y N O N Y M _ S T A T U S _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C H E M _ S Y N O N Y M _ S R C _ N A M E ]   [ v a r c h a r ] ( 1 2 8 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ C H E M _ S U B S _ I D E N ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ C H E M _ S U B S _ I D E N _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ C H _ S U _ I D _ T A _ C O ]   O N   [ d b o ] . [ T A N K S _ C H E M _ S U B S _ I D E N ]    
 (  
 	 [ T A N K _ C O M P A R T _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T A N K S _ C H E M _ S U B S _ I D E N ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ C H E _ S U _ I D _ T A _ C O ]   F O R E I G N   K E Y ( [ T A N K _ C O M P A R T _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T A N K S _ T A N K _ C O M P A R T ]   ( [ T A N K _ C O M P A R T _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T A N K S _ C H E M _ S U B S _ I D E N ]   C H E C K   C O N S T R A I N T   [ F K _ C H E _ S U _ I D _ T A _ C O ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T A N K S _ P I P I N G _ C O N S T ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T A N K S _ P I P I N G _ C O N S T ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T A N K S _ P I P I N G _ C O N S T ] (  
 	 [ P I P I N G _ C O N S T _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T A N K _ C O M P A R T _ I D ]   [ v a r c h a r ] ( 4 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T E X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ P I P I N G _ C O N S T ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P I P I N G _ C O N S T _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ P I P _ C O _ T A _ C O _ I D ]   O N   [ d b o ] . [ T A N K S _ P I P I N G _ C O N S T ]    
 (  
 	 [ T A N K _ C O M P A R T _ I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T A N K S _ P I P I N G _ C O N S T ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ P I P _ C O N _ T A N _ C O M ]   F O R E I G N   K E Y ( [ T A N K _ C O M P A R T _ I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T A N K S _ T A N K _ C O M P A R T ]   ( [ T A N K _ C O M P A R T _ I D ] )  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T A N K S _ P I P I N G _ C O N S T ]   C H E C K   C O N S T R A I N T   [ F K _ P I P _ C O N _ T A N _ C O M ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ S U B M I S S I O N ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ S U B M I S S I O N ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ S U B M I S S I O N ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ S u b m i s s i o n I d e n t i f i e r ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S u b m i s s i o n D a t e ]   [ v a r c h a r ] ( 2 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S u b m i s s i o n S t a t u s ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S u b m i s s i o n M e t h o d ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ S U B M I S S I O N ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ R E P O R T ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ R E P O R T ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ R E P O R T ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ R e p o r t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ R e p o r t D u e D a t e ]   [ v a r c h a r ] ( 2 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R e p o r t R e c e i v e d D a t e ]   [ v a r c h a r ] ( 2 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R e p o r t R e c i p i e n t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R e p o r t i n g P e r i o d S t a r t D a t e ]   [ v a r c h a r ] ( 2 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R e p o r t i n g P e r i o d E n d D a t e ]   [ v a r c h a r ] ( 2 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R e v i s i o n I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R e p l a c e d R e p o r t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R e p o r t C r e a t e B y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R e p o r t C r e a t e D a t e ]   [ v a r c h a r ] ( 2 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R e p o r t C r e a t e T i m e ]   [ v a r c h a r ] ( 2 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R e p o r t T y p e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ R E P O R T ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ T 2 _ R E P O R T _ T 2 _ S U B ]   O N   [ d b o ] . [ T 2 _ R E P O R T ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ R E P O R T ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ R E P O R T _ T 2 _ S U B M I S S I O N ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ S U B M I S S I O N ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ R E P O R T ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ R E P O R T _ T 2 _ S U B M I S S I O N ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ S I T E ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ F A C _ S I T E ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ S I T E ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F a c i l i t y S i t e I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F a c i l i t y S i t e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F a c i l i t y S t a t u s ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L o c a t i o n A d d r e s s T e x t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S u p p l e m e n t a l L o c a t i o n T e x t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L o c a l i t y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S t a t e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S t a t e C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S t a t e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ A d d r e s s P o s t a l C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C o u n t r y C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C o u n t r y C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C o u n t r y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C o u n t y C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C o u n t y C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C o u n t y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T r i b a l C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T r i b a l C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T r i b a l N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T r i b a l L a n d N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ T r i b a l L a n d I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L o c a t i o n D e s c r i p t i o n T e x t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l F a c i l i t y S i t e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l A d d r e s s T e x t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l S u p p l e m e n t a l A d d r e s s T e x t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l A d d r e s s C i t y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l S t a t e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l S t a t e C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l S t a t e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l A d d r e s s P o s t a l C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l C o u n t r y C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l C o u n t r y C o d e L i s t I d e n t i f i e r   ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l C o u n t r y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ P a r e n t C o m p a n y N a m e N A I n d i c a t o r ]   [ v a r c h a r ] ( 1 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ P a r e n t C o m p a n y N a m e T e x t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ P a r e n t D u n B r a d s t r e e t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ F i r e D i s t r i c t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ S I T E ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ S I T E _ T 2 _ R E P O R T ]   O N   [ d b o ] . [ T 2 _ F A C _ S I T E ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ S I T E ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ S I T E _ T 2 _ R E P O R T ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ R E P O R T ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ S I T E ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ S I T E _ T 2 _ R E P O R T ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ I N V ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ C h e m i c a l I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ E H S I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T r a d e S e c r e t I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ C A S N u m b e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C h e m S u b s t a n c e S y s t e m a t i c N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ E P A C h e m i c a l R e g i s t r y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ E P A C h e m i c a l I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C h e m i c a l N a m e C o n t e x t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ I N V ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ C H E M _ I N V _ F A C _ S I T E ]   O N   [ d b o ] . [ T 2 _ C H E M _ I N V ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ T 2 _ F A C _ S I T E ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ D U N D B _ I D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ F A C _ D U N D B _ I D ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ D U N D B _ I D ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F a c i l i t y D u n B r a d s t r e e t C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ D U N D B _ I D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ D U N D B _ I D _ F A C _ S I T E ]   O N   [ d b o ] . [ T 2 _ F A C _ D U N D B _ I D ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ D U N D B _ I D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ D U N D B _ I D _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ D U N D B _ I D ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ D U N D B _ I D _ T 2 _ F A C _ S I T E ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ G E O ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ F A C _ G E O ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ G E O ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ A _ M E A S U R E ]   [ v a r c h a r ] ( 1 0 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ B _ M E A S U R E ]   [ v a r c h a r ] ( 1 1 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ S R C _ M A P _ S C A L E _ N U M ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z _ A C C _ M E A S U R E _ V A L U E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z _ A C C _ M E A S U R E _ U N I T C D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z _ A C C _ M E A S U R E _ U N I T C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z _ A C C _ M E A S U R E _ U N I T _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z _ A C C _ P R E C _ T X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z _ A C C _ R E S U L T _ Q U A L _ C D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z _ A C C _ R E S U L T _ Q U A L _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z _ A C C _ R E S U L T _ Q U A L _ N M ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z _ C O L L _ M E T H _ I D C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z _ C O L L _ M E T H _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z _ C O L L _ M E T H _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z _ C O L L _ M E T H _ D E S C ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z _ C O L L _ M E T H _ D E V I A T I O N S ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R E F _ P O I N T _ C D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R E F _ P O I N T _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ R E F _ P O I N T _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z _ R E F _ D A T U M _ C D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z _ R E F _ D A T U M _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ H O R I Z _ R E F _ D A T U M _ N M ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ D A T A _ C O L L _ D A T E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L O C _ C O M M E N T S ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ M E A S _ V A L U E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ M E A S _ U N I T C D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ M E A S _ U N I T C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ M E A S _ U N I T _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ M E A S _ P R E C _ T X T ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ M E A S _ R E S U L T _ Q U A L _ C D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ M E A S _ R E S U L T _ Q U A L _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ M E A S _ R E S U L T _ Q U A L _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ I D C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ D E S C ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ C O L L _ M E T H _ D E V I A T I O N S ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ R E F _ D A T U M _ C D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ R E F _ D A T U M _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R T _ R E F _ D A T U M _ N M ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R I F _ M E T H _ I D C O D E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R I F _ M E T H _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R I F _ M E T H _ N A M E ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R I F _ M E T H _ D E S C ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ V E R I F _ M E T H _ D E V I A T I O N S ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O O R D _ D A T A _ S R C _ C D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O O R D _ D A T A _ S R C _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C O O R D _ D A T A _ S R C _ N M ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ G E O _ T Y P E _ C D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ G E O _ T Y P E _ C D L I S T I D ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ G E O _ T Y P E _ N M ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ G E O ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ G E O _ F A C _ S I T E ]   O N   [ d b o ] . [ T 2 _ F A C _ G E O ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ G E O ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ G E O _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ G E O ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ G E O _ T 2 _ F A C _ S I T E ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ I N D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ I n d i v i d u a l I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ I n d i v i d u a l T i t l e T e x t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ N a m e P r e f i x T e x t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ I n d i v i d u a l F u l l N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F i r s t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M i d d l e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ L a s t N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ N a m e S u f f i x T e x t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l A d d r e s s T e x t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l S u p p l e m e n t a l A d d r e s s T e x t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l A d d r e s s C i t y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l S t a t e C o d e ]   [ v a r c h a r ] ( 2 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l S t a t e C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l S t a t e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l A d d r e s s P o s t a l C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l C o u n t r y C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l C o u n t r y C o d e L i s t I d e n t i f i e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a i l C o u n t r y N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ I N D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ I N D _ F A C _ S I T E ]   O N   [ d b o ] . [ T 2 _ F A C _ I N D ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D ]     W I T H   N O C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ T 2 _ F A C _ S I T E ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ N A I C S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ F A C _ N A I C S ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ N A I C S ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ N A I C S C o d e ]   [ v a r c h a r ] ( 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ N A I C S I n d u s t r y C o d e ]   [ v a r c h a r ] ( 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ N A I C S G r o u p C o d e ]   [ v a r c h a r ] ( 4 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ N A I C S S u b s e c t o r C o d e ]   [ v a r c h a r ] ( 3 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ N A I C S S e c t o r C o d e ]   [ v a r c h a r ] ( 2 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ N A I C S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ N A I C S _ F A C _ S I T E ]   O N   [ d b o ] . [ T 2 _ F A C _ N A I C S ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ N A I C S ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ N A I C S _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ N A I C S ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ N A I C S _ T 2 _ F A C _ S I T E ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ N P D E S _ I D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ F A C _ N P D E S _ I D ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ N P D E S _ I D ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ N P D E S I d e n t i f i c a t i o n N u m b e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ N P D E S _ I D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ N P D E S _ I D _ F A C _ S I T E ]   O N   [ d b o ] . [ T 2 _ F A C _ N P D E S _ I D ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ N P D E S _ I D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ N P D E S _ I D _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ N P D E S _ I D ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ N P D E S _ I D _ T 2 _ F A C _ S I T E ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ R C R A _ I D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ F A C _ R C R A _ I D ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ R C R A _ I D ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ R C R A I d e n t i f i c a t i o n N u m b e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ R C R A _ I D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ R C R A _ I D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ R C R A _ I D _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ R C R A _ I D ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ R C R A _ I D _ T 2 _ F A C _ S I T E ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ S I C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ F A C _ S I C ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ S I C ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ S I C C o d e ]   [ v a r c h a r ] ( 4 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ S I C P r i m a r y I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ F A C _ S I C ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ S I C _ F A C _ S I T E ]   O N   [ d b o ] . [ T 2 _ F A C _ S I C ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ S I C ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ S I C _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ S I C ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ S I C _ T 2 _ F A C _ S I T E ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ U I C _ I D ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ F A C _ U I C _ I D ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ U I C _ I D ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ U I C I d e n t i f i c a t i o n N u m b e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ U I C _ I D ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ U I C _ I D _ F A C _ S I T E ]   O N   [ d b o ] . [ T 2 _ F A C _ U I C _ I D ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ U I C _ I D ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ U I C _ I D _ T 2 _ F A C _ S I T E ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ S I T E ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ U I C _ I D ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ U I C _ I D _ T 2 _ F A C _ S I T E ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ I N V _ D T L S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ D T L S ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ D T L S ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ N u m b e r O f D a y s O n s i t e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ M a x i m u m D a i l y A m o u n t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a x i m u m C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ A v e r a g e D a i l y A m o u n t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ A v e r a g e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ I N V _ D T L S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ C H E M _ I N V _ D T L S _ C H E M _ I N V ]   O N   [ d b o ] . [ T 2 _ C H E M _ I N V _ D T L S ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ D T L S ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ D T L S _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ D T L S ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ D T L S _ T 2 _ C H E M _ I N V ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ I N V _ H A Z ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ H A Z ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ H A Z ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ H a z a r d T y p e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ I N V _ H A Z ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ C H E M _ I N V _ H A Z _ C H E M _ I N V ]   O N   [ d b o ] . [ T 2 _ C H E M _ I N V _ H A Z ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ H A Z ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ H A Z _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ H A Z ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ H A Z _ T 2 _ C H E M _ I N V ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ I N V _ H L T H ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ H L T H ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ H L T H ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ H e a l t h E f f e c t s ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ I N V _ H L T H ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ C H E M _ I N V _ H L T H _ C H E M _ I N V ]   O N   [ d b o ] . [ T 2 _ C H E M _ I N V _ H L T H ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ H L T H ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ H L T H _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ H L T H ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ H L T H _ T 2 _ C H E M _ I N V ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ I N V _ P H Y S ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ P H Y S ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ P H Y S ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ C h e m i c a l P h y s i c a l S t a t e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ I N V _ P H Y S ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ C H E M _ I N V _ P H Y S _ C H E M _ I N V ]   O N   [ d b o ] . [ T 2 _ C H E M _ I N V _ P H Y S ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ P H Y S ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ P H Y S _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ I N V _ P H Y S ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ I N V _ P H Y S _ T 2 _ C H E M _ I N V ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ L O C ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ C H E M _ L O C ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ C H E M _ L O C ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ C o n f i d e n t i a l L o c a t i o n I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ S t o r a g e T y p e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S t o r a g e T y p e D e s c r i p t i o n ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S t o r a g e L o c T e m p e r a t u r e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S t o r a g e L o c T e m p e r a t u r e D e s c ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S t o r a g e L o c P r e s s u r e C o d e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S t o r a g e L o c P r e s s u r e D e s c ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ S t o r a g e L o c D e s c r i p t i o n ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M a x i m u m A m o u n t A t L o c a t i o n ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ M e a s u r e m e n t U n i t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ L O C ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ C H E M _ L O C _ C H E M _ I N V ]   O N   [ d b o ] . [ T 2 _ C H E M _ L O C ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ L O C ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ L O C _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ L O C ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ L O C _ T 2 _ C H E M _ I N V ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ C H E M _ M I X ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ C H E M _ M I X ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ C H E M _ M I X ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ C A S N u m b e r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C o m p o n e n t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ C o m p o n e n t P e r c e n t a g e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ W e i g h t O r V o l u m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
 	 [ E H S I n d i c a t o r ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ C H E M _ M I X ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ M I X ]     W I T H   C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ C H E M _ M I X _ T 2 _ C H E M _ I N V ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ C H E M _ I N V ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ C H E M _ M I X ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ C H E M _ M I X _ T 2 _ C H E M _ I N V ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ I N D _ E M A I L ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ E M A I L ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ E M A I L ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ E l e c t r o n i c A d d r e s s T e x t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ E l e c t r o n i c A d d r e s s T y p e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ I N D _ E M A I L ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ I N D _ E M A I L _ F A C _ I N D ]   O N   [ d b o ] . [ T 2 _ F A C _ I N D _ E M A I L ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ E M A I L ]     W I T H   N O C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ E M A I L _ T 2 _ F A C _ I N D ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ I N D ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ E M A I L ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ E M A I L _ T 2 _ F A C _ I N D ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ I N D _ P H O N E ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ P H O N E ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ P H O N E ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T e l e p h o n e N u m b e r T e x t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T e l e p h o n e N u m b e r T y p e N a m e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ T e l e p h o n e E x t e n s i o n N u m b e r T e x t ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ I N D _ P H O N E ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ I N D _ P H O N E _ F A C _ I N D ]   O N   [ d b o ] . [ T 2 _ F A C _ I N D _ P H O N E ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ P H O N E ]     W I T H   N O C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ P H O N E _ T 2 _ F A C _ I N D ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ I N D ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ P H O N E ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ P H O N E _ T 2 _ F A C _ I N D ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T 2 _ F A C _ I N D _ T Y P E ] ' )   A N D   t y p e   i n   ( N ' U ' ) )  
 D R O P   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ T Y P E ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
 C R E A T E   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ T Y P E ] (  
 	 [ P K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ F K _ G U I D ]   [ v a r c h a r ] ( 3 6 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
 	 [ C o n t a c t T y p e ]   [ v a r c h a r ] ( 2 5 5 )   C O L L A T E   S Q L _ L a t i n 1 _ G e n e r a l _ C P 1 _ C I _ A S   N O T   N U L L ,  
   C O N S T R A I N T   [ P K _ T 2 _ F A C _ I N D _ T Y P E ]   P R I M A R Y   K E Y   C L U S T E R E D    
 (  
 	 [ P K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 )   O N   [ P R I M A R Y ]  
  
 G O  
  
 C R E A T E   N O N C L U S T E R E D   I N D E X   [ I X _ F A C _ I N D _ T Y P E _ F A C _ I N D ]   O N   [ d b o ] . [ T 2 _ F A C _ I N D _ T Y P E ]    
 (  
 	 [ F K _ G U I D ]   A S C  
 ) W I T H   ( P A D _ I N D E X     =   O F F ,   S T A T I S T I C S _ N O R E C O M P U T E     =   O F F ,   S O R T _ I N _ T E M P D B   =   O F F ,   I G N O R E _ D U P _ K E Y   =   O F F ,   D R O P _ E X I S T I N G   =   O F F ,   O N L I N E   =   O F F ,   A L L O W _ R O W _ L O C K S     =   O N ,   A L L O W _ P A G E _ L O C K S     =   O N )   O N   [ P R I M A R Y ]  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ T Y P E ]     W I T H   N O C H E C K   A D D     C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ T Y P E _ T 2 _ F A C _ I N D ]   F O R E I G N   K E Y ( [ F K _ G U I D ] )  
 R E F E R E N C E S   [ d b o ] . [ T 2 _ F A C _ I N D ]   ( [ P K _ G U I D ] )  
 O N   U P D A T E   C A S C A D E  
 O N   D E L E T E   C A S C A D E  
 G O  
 A L T E R   T A B L E   [ d b o ] . [ T 2 _ F A C _ I N D _ T Y P E ]   C H E C K   C O N S T R A I N T   [ F K _ T 2 _ F A C _ I N D _ T Y P E _ T 2 _ F A C _ I N D ]  
 G O  
 I F     E X I S T S   ( S E L E C T   *   F R O M   s y s . o b j e c t s   W H E R E   o b j e c t _ i d   =   O B J E C T _ I D ( N ' [ d b o ] . [ T I E R 2 _ G e t T I E R 2 B y C h a n g e D a t e ] ' )   A N D   t y p e   i n   ( N ' P ' ,   N ' P C ' ) )  
 D R O P   P R O C E D U R E   [ d b o ] . [ T I E R 2 _ G e t T I E R 2 B y C h a n g e D a t e ]  
 G O  
 S E T   A N S I _ N U L L S   O N  
 G O  
 S E T   Q U O T E D _ I D E N T I F I E R   O N  
 G O  
  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 - -   A u t h o r : 	 	 T K   C o n r a d  
 - -   C r e a t e   d a t e :   2 0 0 7 - 0 7 - 2 0  
 - -   D e s c r i p t i o n : 	 H E R E - T I E R 2   F l o w   d a t a   r e t r i e v a l    
  
 - -                                     M o d i f i c a t i o n s  
 - -  
 - -     D a t e               D e v e l o p e r                             C h a n g e s  
 - -   0 5 1 3 0 8 	 	 P J M 	 	 	 A d d   H E R E   s c h e m a   t o   C h a n g e d F a c i l i t i e s   t a b l e s  
 - -  
 - -   = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
 C R E A T E   P R O C E D U R E   [ T I E R 2 _ G e t T I E R 2 B y C h a n g e D a t e ]  
 	 @ C h a n g e D a t e   d a t e t i m e ,  
         @ L i s t I n d e x   i n t  
 A S  
 - -   S E T   N O C O U N T   O N   a d d e d   t o   p r e v e n t   e x t r a   r e s u l t   s e t s   f r o m  
 - -   i n t e r f e r i n g   w i t h   S E L E C T   s t a t e m e n t s .  
 S E T   N O C O U N T   O N ;  
  
 - -   D E C L A R E   @ C h a n g e D a t e   d a t e t i m e  
 - -   s e t   @ c h a n g e D a t e   =   ' 1 9 0 0 - 0 1 - 0 1 '  
  
 / *  
  
         D O   N O T   C H A N G E   T H E   O R D E R   O F   T H E S E   S E L E C T S  
         T H E S E   A R E   M A P P E D   T O   O B J E C T S  
  
 * /  
  
 D E C L A R E   @ f l o w T y p e   v a r c h a r ( 5 0 )  
 S E T   @ f l o w T y p e   =   ' H E R E - T I E R 2 ' ;  
  
 - -   0 .   T 2 _ S U B M I S S I O N  
 I F   @ L i s t I n d e x   =   0  
  
         S E L E C T 	 T 2 _ S U B M I S S I O N . *  
         F R O M   T 2 _ S U B M I S S I O N  
         J O I N   T 2 _ R E P O R T   O N   T 2 _ S U B M I S S I O N . P K _ G U I D   =   T 2 _ R E P O R T . F K _ G U I D  
         J O I N   T 2 _ F A C _ S I T E   O N   T 2 _ R E P O R T . P K _ G U I D   =   T 2 _ F A C _ S I T E . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   O N   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T 2 _ F A C _ S I T E . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
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
         S E L E C T 	 T 2 _ R E P O R T . *  
         F R O M   T 2 _ R E P O R T  
         J O I N   T 2 _ F A C _ S I T E   O N   T 2 _ R E P O R T . P K _ G U I D   =   T 2 _ F A C _ S I T E . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   O N   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T 2 _ F A C _ S I T E . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0  
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
         S E L E C T 	 T 2 _ F A C _ S I T E . *  
         F R O M   T 2 _ F A C _ S I T E  
         J O I N   C H A N G E D _ F A C I L I T I E S   O N   C H A N G E D _ F A C I L I T I E S . S T _ F A C _ I N D   =   T 2 _ F A C _ S I T E . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C H A N G E D _ F A C I L I T I E S . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C H A N G E D _ F A C I L I T I E S . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C H A N G E D _ F A C I L I T I E S . I S _ D E L E T E D   =   0 ;  
  
  
 - -   3 .   T 2 _ F A C _ D U N D B _ I D  
 E L S E   I F   @ L i s t I n d e x   =   3  
  
         S E L E C T 	 D B . *  
         F R O M   T 2 _ F A C _ D U N D B _ I D   D B  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   D B . F K _ G U I D  
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
         F R O M   T 2 _ F A C _ G E O   G  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   G . F K _ G U I D  
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
         F R O M   T 2 _ F A C _ N A I C S   N  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   N . F K _ G U I D  
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
         F R O M   T 2 _ F A C _ N P D E S _ I D   N  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   N . F K _ G U I D  
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
         F R O M   T 2 _ F A C _ R C R A _ I D   R  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   R . F K _ G U I D  
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
         F R O M   T 2 _ F A C _ S I C   S  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   S . F K _ G U I D  
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
         F R O M   T 2 _ F A C _ U I C _ I D   U  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   U . F K _ G U I D  
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
         F R O M   T 2 _ F A C _ I N D   I  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I . F K _ G U I D  
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
         F R O M   T 2 _ F A C _ I N D _ E M A I L   E M A I L  
         J O I N   T 2 _ F A C _ I N D   I   O N   I . P K _ G U I D   =   E M A I L . F K _ G U I D  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I . F K _ G U I D  
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
         F R O M   T 2 _ F A C _ I N D _ P H O N E   P H O N E  
         J O I N   T 2 _ F A C _ I N D   I   O N   I . P K _ G U I D   =   P H O N E . F K _ G U I D  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I . F K _ G U I D  
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
         F R O M   T 2 _ F A C _ I N D _ T Y P E   T Y P E  
         J O I N   T 2 _ F A C _ I N D   I   O N   I . P K _ G U I D   =   T Y P E . F K _ G U I D  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I . F K _ G U I D  
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
         F R O M   T 2 _ C H E M _ I N V   I N V  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I N V . F K _ G U I D  
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
         F R O M   T 2 _ C H E M _ I N V _ D T L S   D T L S  
         J O I N   T 2 _ C H E M _ I N V   I N V   O N   I N V . P K _ G U I D   =   D T L S . F K _ G U I D  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I N V . F K _ G U I D  
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
         F R O M   T 2 _ C H E M _ I N V _ H A Z   H A Z  
         J O I N   T 2 _ C H E M _ I N V   I N V   O N   I N V . P K _ G U I D   =   H A Z . F K _ G U I D  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I N V . F K _ G U I D  
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
         F R O M   T 2 _ C H E M _ I N V _ H L T H   H L T H  
         J O I N   T 2 _ C H E M _ I N V   I N V   O N   I N V . P K _ G U I D   =   H L T H . F K _ G U I D  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I N V . F K _ G U I D  
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
         F R O M   T 2 _ C H E M _ I N V _ P H Y S   P H Y S  
         J O I N   T 2 _ C H E M _ I N V   I N V   O N   I N V . P K _ G U I D   =   P H Y S . F K _ G U I D  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I N V . F K _ G U I D  
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
         F R O M   T 2 _ C H E M _ L O C   L O C  
         J O I N   T 2 _ C H E M _ I N V   I N V   O N   I N V . P K _ G U I D   =   L O C . F K _ G U I D  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I N V . F K _ G U I D  
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
         F R O M   T 2 _ C H E M _ M I X   M I X  
         J O I N   T 2 _ C H E M _ I N V   I N V   O N   I N V . P K _ G U I D   =   M I X . F K _ G U I D  
         J O I N   T 2 _ F A C _ S I T E   F   O N   F . P K _ G U I D   =   I N V . F K _ G U I D  
         J O I N   C H A N G E D _ F A C I L I T I E S   C   o n   C . S T _ F A C _ I N D   =   F . F a c i l i t y S i t e I d e n t i f i e r  
         W H E R E   C . U P D A T E _ D A T E   > =   @ C h a n g e D a t e  
         A N D 	 C . F L O W _ T Y P E 	 =   @ f l o w T y p e  
         A N D   C . I S _ D E L E T E D   =   0 ;  
  
  
 G O  
 