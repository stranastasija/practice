# Простой Black_Jack на python (без ставок и соперников)

import random

#  2 - валет, 3 - дама, 4 - король, 11 - туз
koloda = [6,7,8,9,10,2,3,4,11] * 4

# shuffle - перемешивает колоду
random.shuffle(koloda)

print('Поиграем?')
count = 0

while True:
    choice = input('Будете брать карту? yes - y/no - n\n')
    if choice == 'y':
        current = koloda.pop()
        print('Вам попалась карта достоинством %d' %current)
        count += current
        if count > 21:
            print('Извините, но вы проиграли')
            break
        elif count == 21:
            print('Поздравляю, вы набрали 21!')
            break
        else:
            print('У вас %d очков.' %count)
    elif choice == 'n':
        print('У вас %d очков и вы закончили игру.' %count)
        break

print('До новых встреч!')