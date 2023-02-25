import math
import sys

n2min = sys.float_info.max


def refreshn2min(s):
    global n2min
    n2min = sys.float_info.max
    for i, p1 in enumerate(s):
        for p2 in s[i + 1:]:
            n2 = norm2(p1[0], p1[1], p2[0], p2[1])
            if n2 < n2min:
                n2min = n2


(n, q) = (int(w) for w in input().split(' '))
#print(n, q) #
s = []
while n > 0:
    (x, y) = (int(w) for w in input().split(' '))
    s.append((x, y))
    n -= 1

#for (x, y) in s: #
#    print (x, y) #

norm2 = lambda x1, y1, x2, y2: (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)

mins = []

refreshn2min(s)
    
while q > 0:
    line = input()
    (op, x, y) = (int(w) for w in line.split(' ')) if (int(line[0])) else (0, 0, 0)
    if (op):
        s.append((x, y))
    else:
        s.pop()
        mins.pop()
        n2min = None
        print(mins[-1])
        q -= 1
        continue
        #print()          #
        #for (x, y) in s: #
        #    print (x, y) #
    q -= 1

    if n2min is None:
        refreshn2min(s)
    else:
        for p in s[0:-1]:
            n2 = norm2(p[0], p[1], x, y)
            if n2 < n2min:
                n2min = n2

    mins.append(math.sqrt(n2min))
    print(mins[-1])