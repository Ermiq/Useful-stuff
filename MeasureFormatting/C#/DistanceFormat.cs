///	Format the given amount of meters into "X m", "X.XX km" or "X.X mln km" string.

string FormatDistance(float value)
{
	if (value < 1000)
		return value.ToString("0") + " m";
	else
	{
		value *= 0.001f;
		if (value >= 1000000)
		{
			value *= 0.000001f;
			return value.ToString("0.0") + " mln km";
		}
		else
			return value.ToString("0.00") + " km";
	}
}
