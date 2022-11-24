import math
print ("Program na výpočet kvadratické rovnice\nTvar kvadratické rovnice: ax^2+bx+c=0")
a=float(input("Zadej koeficient a: "))
b=float(input("Zadej koeficient b: "))
c=float(input("Zadej koeficient c: "))

#Výpočet diskriminantu
d=b*b-4*a*c

#Vyřešení rovnice
if d < 0:
    print ("Rovnice nemá řešení v oboru reálných čísel")
    input ("\nStiskněte enter pro konec programu...")
    exit()

if d == 0:
    x=-b/(2*a)
    print ("Rovnice má jedno řešení \nx1=", x)
    input ("\nStiskněte enter pro konec programu...")
    exit()

if d > 0:
    x1=(-b+math.sqrt(d))/(2*a)
    x2=(-b-math.sqrt(d))/(2*a)
    print ("Rovnice má 2 řešení:\nx1=", x1, "\nx2=", x2)
    input ("\nStiskněte enter pro konec programu...")
    exit()

    