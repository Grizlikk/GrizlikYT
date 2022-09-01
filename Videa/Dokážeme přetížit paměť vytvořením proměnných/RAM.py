# Příprava proměnných
pole=[]
zapis="a"

# Zadání množství průchodů
ram=int(input("Zadejte mnozstvi pruchodu: "))

# Vytváření dlouhého textového řetězce
for i in range(1000):
    zapis=zapis+"abcdefghijklmnopqrstuvwxyz123456789"

# Kopírování textového řetězce "zapis" do pole
for i in range(ram):
    pole.append(zapis)

# Konec programu
input("Hotovo!")