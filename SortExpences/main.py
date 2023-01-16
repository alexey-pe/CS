import csv
from operator import lt, gt, itemgetter


def main():
    expenses = read('in.txt')

    cheapfirst = compose(lt, itemgetter(1))
    costlyfirst = compose(gt, itemgetter(1))
    chronological = compose(lt, itemgetter(0))
    recentfirst = compose(gt, itemgetter(0))

    insertion_sort(expenses, chronological)

    total = sum(itemgetter(1)(e) for e in expenses)
    print("Total amount: ", total)

    for e in expenses:
        print(e)


def compose(predicate, keyextractor):
    def predicate_on_keys(left, right):
        return predicate(keyextractor(left), keyextractor(right))
    return predicate_on_keys


def is_sorted(elements, predicate):
    prev = None
    for cur in elements:
        if prev is not None and predicate(cur, prev):
            return False
        prev = cur
    return True


def insertion_sort(elements, predicate):
    """Sort the elements provided according to the predicate specified by the attributes obtained by keyextractor."""
    # Special case:  empty sequence.
    k = -1
    assert len(elements[:k + 1]) == len([]), 'Sorting reached none elements.'
    assert is_sorted(elements[:k + 1], predicate), 'Elements up to and including the element reached must be sorted.'

    # Special case:  a sequence of a single element.
    if len(elements) > 0:
        k = k + 1  # k == 0
        print('Reached element by index ', k, ' with value ', elements[k])
        assert len(elements[:k + 1]) == 1, 'Sorting reached the front element.'
        assert is_sorted(elements[:k + 1], predicate), 'A single element is always sorted.'
        print(elements)

    for k in range(1, len(elements)):
        val = elements[k]
        print('Reached element by index ', k, ' and value ', val)
        assert is_sorted(elements[:k], predicate),\
            'Elements up to but excluding the element reached must already be sorted.'
        i = k
        while i > 0 and predicate(val, elements[i - 1]):
            elements[i] = elements[i - 1]
            i = i - 1
        assert i >= 0
        elements[i] = val
        assert is_sorted(elements[:k + 1], predicate),\
            'Elements up to and including the element reached must be sorted.'
        print(elements)

    assert len(elements[:k + 1]) == len(elements), 'Sorting must reach the last element.'


def read(filename):
    def reverse_date(date):
        day_month_year = date.split('-')
        return '-'.join(reversed(day_month_year))

    def make_timestamp(date, time):
        return ' '.join([reverse_date(date), time])

    def transform(line):
        return make_timestamp(line[0], line[1]), float(line[2])

    with open(filename) as infile:
        reader = csv.reader(infile, delimiter=' ')
        expenses = [transform(line) for line in reader]

    return expenses


if __name__ == '__main__':
    main()
