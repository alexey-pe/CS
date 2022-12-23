import csv


def is_sorted_desc(elements):
    prev = None
    for cur in elements:
        if prev is not None and cur > prev:
            return False
        prev = cur
    return True


infile = open('in.txt')
reader = csv.reader(infile, delimiter=' ')
expenses = []
total = 0.0
for line in reader:
    date_month_year = line[0].split('-')
    year_month_date = '-'.join(reversed(date_month_year))

    timestamp = ' '.join([year_month_date, line[1]])
    expenses.append(timestamp)

    total += float(line[2])

print("Total amount: ", total)
# for e in expenses:
#     print(e)

# Special case:  empty sequence.
k = -1
assert len(expenses[:k + 1]) == len([]), 'Sorting reached none elements.'
assert is_sorted_desc(expenses[:k + 1]), 'Elements up to and including the element reached must be sorted.'

# # Special case:  a sequence of a single element.
if len(expenses) > 0:
    k = k + 1  # k == 0
    assert len(expenses[:k + 1]) == 1, 'Sorting reached the front element.'
    assert is_sorted_desc(expenses[:k + 1]), 'A single element is sorted.'

for k in range(1, len(expenses)):
    val = expenses[k]
    print('Reached element by index ', k, ' with value ', val)
    assert is_sorted_desc(expenses[:k]), 'Elements up to but excluding the element reached are already sorted.'
    i = k
    while i > 0 and val > expenses[i - 1]:
        expenses[i] = expenses[i - 1]
        i = i - 1
    assert i >= 0
    expenses[i] = val
    assert is_sorted_desc(expenses[:k + 1]), 'Elements up to and including the element reached must be sorted.'
    print(expenses)

assert len(expenses[:k + 1]) == len(expenses), 'Sorting must reach the last element.'

for e in expenses:
    print(e)
