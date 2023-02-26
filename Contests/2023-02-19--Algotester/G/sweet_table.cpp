#include <iostream>
#include <limits>
#include <stack>
#include <tuple>
#include <vector>

using namespace std;

vector<pair<double, double>> s;
double minDistance2;
size_t iMin, jMin;
stack<tuple<double, size_t, size_t>> minDistances2;

void InputPosition();
void PopPosition();

int main()
{
    int n, q;
    cin >> n >> q;

    minDistance2 = numeric_limits<double>::max();
    for (int i = 0; i < n; ++i)
    {
        InputPosition();
    }

    minDistances2.push(make_tuple(minDistance2, iMin, jMin));

    for (int j = 0; j < q; ++j)
    {
        int command;
        cin >> command;

        if (!command)
        {
            PopPosition();
        }
        else
        {
            InputPosition();
            minDistances2.push(make_tuple(minDistance2, iMin, jMin));
        }

        cout << sqrt(get<double>(minDistances2.top())) << endl;
    }
}

void InputPosition()
{
    const size_t j = s.size();
    double x2, y2;
    cin >> x2;
    cin >> y2;

    for (size_t i = 0; i < s.size(); ++i)
    {
        const auto [x1, y1] = s[i];
        const double dx = x2 - x1;
        const double dy = y2 - y1;
        const double distance2 = dx * dx + dy * dy;

        if (distance2 < minDistance2)
        {
            minDistance2 = distance2;
            iMin = i;
            jMin = j;
        }
    }

    s.emplace_back(make_pair(x2, y2));
}

void PopPosition()
{
    s.pop_back();

    const auto [ignore, i, j] = minDistances2.top();
    if (s.size() <= i || s.size() <= j)
    {
        minDistance2 = numeric_limits<double>::max();
    }

    minDistances2.pop();
}