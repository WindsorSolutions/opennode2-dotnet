#region License
/*
Copyright (c) 2009, The Environmental Council of the States (ECOS)
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

 * Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
 * Redistributions in binary form must reproduce the above copyright
   notice, this list of conditions and the following disclaimer in the
   documentation and/or other materials provided with the distribution.
 * Neither the name of the ECOS nor the names of its contributors may
   be used to endorse or promote products derived from this software
   without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
"AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
POSSIBILITY OF SUCH DAMAGE.
*/
#endregion

��u s i n g   S y s t e m . R e f l e c t i o n ;  
 u s i n g   S y s t e m . S e c u r i t y ;  
 u s i n g   S y s t e m . R u n t i m e . C o m p i l e r S e r v i c e s ;  
 u s i n g   S y s t e m . R u n t i m e . I n t e r o p S e r v i c e s ;  
  
 / /   G e n e r a l   I n f o r m a t i o n   a b o u t   a n   a s s e m b l y   i s   c o n t r o l l e d   t h r o u g h   t h e   f o l l o w i n g    
 / /   s e t   o f   a t t r i b u t e s .   C h a n g e   t h e s e   a t t r i b u t e   v a l u e s   t o   m o d i f y   t h e   i n f o r m a t i o n  
 / /   a s s o c i a t e d   w i t h   a n   a s s e m b l y .  
 [ a s s e m b l y :   A s s e m b l y T i t l e ( " I o n i c ' s   Z i p   L i b r a r y " ) ]  
 [ a s s e m b l y :   A s s e m b l y D e s c r i p t i o n ( " a   l i b r a r y   f o r   h a n d l i n g   z i p   a r c h i v e s .   h t t p : / / w w w . c o d e p l e x . c o m / D o t N e t Z i p " ) ]  
 [ a s s e m b l y :   A s s e m b l y C o n f i g u r a t i o n ( " " ) ]  
 [ a s s e m b l y :   A s s e m b l y C o m p a n y ( " M i c r o s o f t " ) ]  
 [ a s s e m b l y :   A s s e m b l y P r o d u c t ( " Z i p L i b r a r y " ) ]  
 [ a s s e m b l y :   A s s e m b l y C o p y r i g h t ( " C o p y r i g h t   �   D i n o   C h i e s a   2 0 0 7 ,   2 0 0 8 " ) ]  
 [ a s s e m b l y :   A s s e m b l y T r a d e m a r k ( " " ) ]  
 [ a s s e m b l y :   A s s e m b l y C u l t u r e ( " " ) ]  
  
 / /   S e t t i n g   C o m V i s i b l e   t o   f a l s e   m a k e s   t h e   t y p e s   i n   t h i s   a s s e m b l y   n o t   v i s i b l e    
 / /   t o   C O M   c o m p o n e n t s .     I f   y o u   n e e d   t o   a c c e s s   a   t y p e   i n   t h i s   a s s e m b l y   f r o m    
 / /   C O M ,   s e t   t h e   C o m V i s i b l e   a t t r i b u t e   t o   t r u e   o n   t h a t   t y p e .  
 [ a s s e m b l y :   C o m V i s i b l e ( f a l s e ) ]  
  
 / /   T h e   f o l l o w i n g   G U I D   i s   f o r   t h e   I D   o f   t h e   t y p e l i b   i f   t h i s   p r o j e c t   i s   e x p o s e d   t o   C O M  
 [ a s s e m b l y :   G u i d ( " d f d 2 b 1 f 6 - e 3 b e - 4 3 d 1 - 9 b 4 3 - 1 1 a a e 1 e 9 0 1 d 8 " ) ]  
  
 [ a s s e m b l y : S y s t e m . C L S C o m p l i a n t ( t r u e ) ]  
  
 / /   w o r k i t e m   4 6 9 8  
 [ a s s e m b l y :   A l l o w P a r t i a l l y T r u s t e d C a l l e r s ]    
  
 / /   V e r s i o n   i n f o r m a t i o n   f o r   a n   a s s e m b l y   c o n s i s t s   o f   t h e   f o l l o w i n g   f o u r   v a l u e s :  
 / /  
 / /             M a j o r   V e r s i o n  
 / /             M i n o r   V e r s i o n    
 / /             B u i l d   N u m b e r  
 / /             R e v i s i o n  
 / /  
 / /   Y o u   c a n   s p e c i f y   a l l   t h e   v a l u e s   o r   y o u   c a n   d e f a u l t   t h e   R e v i s i o n   a n d   B u i l d   N u m b e r s    
 / /   b y   u s i n g   t h e   ' * '   a s   s h o w n   b e l o w :  
 [ a s s e m b l y :   A s s e m b l y V e r s i o n ( " 1 . 6 . 3 . 1 8 " ) ]  
 [ a s s e m b l y :   A s s e m b l y F i l e V e r s i o n ( " 1 . 6 . 3 . 1 8 " ) ]  
 