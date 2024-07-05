#include<stdio.h>
#include<conio.h>
void sub1(int z [ ][4]);
main(void)
{ int a, b;
 int z[3][4] = {1,2,3,4,5,6,7,8,9,10,11,12};
 sub1(z);
 for(a = 0; a < 3; ++a)
 { for (b = 0; b < 4; ++b)
 printf("%d",z[a][b]);
 printf("\n"); }
getch( ); }
void sub1(int z[ ][4])
{ int a, b;
for (a = 0; a < 3; ++a)
 for(b = 0; b<4; ++b)
 if (z[a][b] % 2) == 1)
 z[a][b]= z[a][b]--;
}