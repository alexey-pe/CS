#include <iostream>
#include <string>

using namespace std;

int main()
{
    string xStr, yStr;
    cin >> xStr;
    cin >> yStr;

    int x = atoi(xStr.c_str());
    int y = atoi(yStr.c_str());

    auto trick = [](int x) { return sqrt(((x * x + 4) * 14 / (double)7 - 8) * 50) + 47 - 10 * x; };
    
    string result = (trick(x) == y) ? "Magic" : "Too much juice";

    cout << result << endl;
}
