#include <iostream>
#include <limits>
#include <stack>
#include <vector>

using namespace std;

class PointCloud
{
private:
    vector<pair<double, double>> _points;
    stack<double> _minDistances2;
    double GetMinPairwiseDistance2();

public:
    double GetMinPairwiseDistance();
    void AddPoint(double x, double y);
    void RemoveMostRecentlyAddedPoint();
};

int main()
{
    int n, q;
    cin >> n >> q;

    PointCloud pointCloud;
    for (int i = 0; i < n; ++i)
    {
        double x, y;
        cin >> x >> y;
        pointCloud.AddPoint(x, y);
    }

    for (int j = 0; j < q; ++j)
    {
        int command;
        cin >> command;

        if (command == 0)
        {
            pointCloud.RemoveMostRecentlyAddedPoint();
        }
        else
        {
            double x, y;
            cin >> x >> y;
            pointCloud.AddPoint(x, y);
        }

        cout << pointCloud.GetMinPairwiseDistance() << endl;
    }
}

double PointCloud::GetMinPairwiseDistance2()
{
    if (_minDistances2.empty())
    {
        return numeric_limits<double>::max();
    }

    return _minDistances2.top();
}

double PointCloud::GetMinPairwiseDistance()
{
    return sqrt(GetMinPairwiseDistance2());
}

void PointCloud::AddPoint(double x, double y)
{
    double minDistance2 = GetMinPairwiseDistance2();

    for (size_t i = 0; i < _points.size(); ++i)
    {
        const auto [x1, y1] = _points[i];
        const double dx = x - x1;
        const double dy = y - y1;
        const double distance2 = dx * dx + dy * dy;

        if (distance2 < minDistance2)
        {
            minDistance2 = distance2;
        }
    }

    _points.emplace_back(make_pair(x, y));
    _minDistances2.push(minDistance2);
}

void PointCloud::RemoveMostRecentlyAddedPoint()
{
    _points.pop_back();
    _minDistances2.pop();
}
