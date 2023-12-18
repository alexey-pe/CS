import collections
from enum import Enum
from operator import itemgetter
import itertools
# from itertools import pairwise


class Components(Enum):
    X: int = 1
    Y: int = 2

    def __int__(self):
        return self.value


X = int(Components.X)
Y = int(Components.Y)


def main():
    points = []
    try:
        n = int(input())
        for i in range(1, n + 1):
            line = input()
            x, y = map(int, line.split(' '))
            points.append((i, x, y))
            # print(str(i) + ': ' + ','.join((str(x), str(y))))
        # print(points)

        x_sorted = list(points)
        x_sorted.sort(key=itemgetter(1))
        # print(x_sorted)

        y_sorted = points
        y_sorted.sort(key=itemgetter(2))
        # print(y_sorted)

        dist_sorted = [p for p in itertools.chain(pairwise(x_sorted), pairwise(y_sorted))]
        dist_sorted.sort(key=lambda p: p[0][0])
        dist_sorted.sort(key=lambda p: p[0][0] + p[1][0])
        dist_sorted.sort(key=lambda p: min(abs(p[0][X] - p[1][X]), abs(p[0][Y] - p[1][Y])))
        # print(dist_sorted)

        closest = dist_sorted[0]
        print(f'{closest[0][0]} {closest[1][0]}')

    except Exception as ex:
        print(ex)


def tee(iterable, n=2):
    it = iter(iterable)
    deques = [collections.deque() for i in range(n)]
    def gen(mydeque):
        while True:
            if not mydeque:             # when the local deque is empty
                try:
                    newval = next(it)   # fetch a new value and
                except StopIteration:
                    return
                for d in deques:        # load it to all the deques
                    d.append(newval)
            yield mydeque.popleft()
    return tuple(gen(d) for d in deques)


def pairwise(iterable):
    "s -> (s0,s1), (s1,s2), (s2, s3), ..."
    a, b = tee(iterable)
    next(b, None)
    return zip(a, b)


# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    main()
