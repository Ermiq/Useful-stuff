///	Format the given amount of meters into "X m", "X.XX km" or "X.X mln km" string.

using std::string;

string TrimFloatAfterDot(float& value, int afterDotNum);
string FormatDistance(float& value);

/// <summary>
/// Cut out the float value to leave only the desired amount of didgts after the dot.
/// Usage:
/// 	TrimFloatAfterDot(12.212121, 3) => 12.212
/// </summary>
string TrimFloatAfterDot(float& value, int afterDotNum)
{
	string r = to_string(value);
	return r.substr(0, r.find(".") + afterDotNum + 1);
}

string FormatDistance(float& value)
{
	if (value < 1000)
		return to_string((int)value) + " m";
	else
	{
		value *= 0.001f;
		if (value >= 1000000)
		{
			value *= 0.000001;
			return TrimFloatAfterDot(value, 1) + " mln km";
		}
		else
		{
			return TrimFloatAfterDot(value, 2) + " km";
		}
	}
}
