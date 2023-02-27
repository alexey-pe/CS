#include <iostream>
#include <numeric>
#include <vector>

using namespace std;

template<typename T>
class SegmentQueriableArray
{
private:
    using vector_type = vector<T>;
    using const_iterator_type = typename vector_type::const_iterator;
    vector_type _totals;

    SegmentQueriableArray(const vector_type& a);

    int GetSegmentSum(size_t l, size_t r) const;

public:
    static const SegmentQueriableArray Create(const vector_type& a);

    int GetZeroSumSegmentsCount(size_t l, size_t r) const;
};

int main()
{
    int n;
    cin >> n;

    vector<int> a;
    a.reserve(n);
    for (int i = 0; i < n; ++i)
    {
        int ai;
        cin >> ai;
        a.push_back(ai);
    }

    using element_type = decltype(a)::value_type;
    const auto sqa = SegmentQueriableArray<element_type>::Create(a);

    int q;
    cin >> q;
    for (int i = 0; i < q; ++i)
    {
        int l, r;
        cin >> l >> r;

        int count = sqa.GetZeroSumSegmentsCount(l, r);
        cout << count << endl;
    }
}

template<typename T>
SegmentQueriableArray<T>::SegmentQueriableArray(const vector_type& a) :
    _totals(a.size() + 1)
{
    partial_sum(a.begin(), a.end(), _totals.begin() + 1);
}

template<typename T>
int SegmentQueriableArray<T>::GetSegmentSum(size_t l, size_t r) const
{
    return _totals[r] - _totals[l - 1];
}

template<typename T>
const SegmentQueriableArray<T> SegmentQueriableArray<T>::Create(const vector_type& a)
{
    return SegmentQueriableArray(a);
}

template<typename T>
int SegmentQueriableArray<T>::GetZeroSumSegmentsCount(size_t l, size_t r) const
{
    int result = 0;
    for (size_t ll = l; ll <= r; ++ll)
    {
        for (size_t rr = ll; rr <= r; ++rr)
        {
            if (GetSegmentSum(ll, rr) == 0)
            {
                ++result;
            }
        }
    }

    return result;
}
