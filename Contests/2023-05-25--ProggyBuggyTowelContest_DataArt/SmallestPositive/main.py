# This is a sample Python script.

# Press Shift+F10 to execute it or replace it with your code.
# Press Double Shift to search everywhere for classes, files, tool windows, actions, and settings.


def main():
    # Given a sequence of N integers, find the smallest positive element of it.

    seq = list()

    try:
        seqstr = input('Enter sequence:')
        seq = [int(x) for x in seqstr.split(' ')]
    except Exception as ex:
        print('Invalid sequence.')

    result = smallest_positive(seq)
    print(f'Smallest positive element: {result}')


def smallest_positive(seq):
    return 0


# Press the green button in the gutter to run the script.
if __name__ == '__main__':
    main()
