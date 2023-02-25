import math

try:
    s = input()
    (x, y) = (int(n) for n in s.split(' '))
    trick = lambda x: math.sqrt(((x * x + 4) * 14 / 7 - 8) * 50) + 47 - 10 * x
    print('Magic' if trick(x) == y else 'Too much juice')
except Exception as ex:
    pass
