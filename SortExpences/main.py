import csv


def main():
    expenses = read('in.txt')

    def descending(left, right):
        return left > right

    def ascending(left, right):
        return left < right
    insertion_sort_desc(expenses, ascending)

    total = sum((e[1] for e in expenses))
    print("Total amount: ", total)

    for e in expenses:
        print(e)


def is_sorted(elements, predicate):
    prev = None
    for cur in elements:
        if prev is not None and predicate(cur, prev):
            return False
        prev = cur
    return True


def insertion_sort_desc(elements, predicate):
    """Sort the elements provided according to the predicate specified."""
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
        print('Reached element by index ', k, ' with value ', val)
        assert is_sorted(elements[:k], predicate), 'Elements up to but excluding the element reached must already be sorted.'
        i = k
        while i > 0 and predicate(val, elements[i - 1]):
            elements[i] = elements[i - 1]
            i = i - 1
        assert i >= 0
        elements[i] = val
        assert is_sorted(elements[:k + 1], predicate), 'Elements up to and including the element reached must be sorted.'
        print(elements)

    assert len(elements[:k + 1]) == len(elements), 'Sorting must reach the last element.'


def read(filename):
    infile = open(filename)
    reader = csv.reader(infile, delimiter=' ')
    expenses = []
    for line in reader:
        date_month_year = line[0].split('-')
        year_month_date = '-'.join(reversed(date_month_year))

        timestamp = ' '.join([year_month_date, line[1]])
        expenses.append((timestamp, float(line[2])))

    return expenses


if __name__ == '__main__':
    main()
