public static void GetTimeFromSeconds(float secondsTotal, out int s, out int m, out int h, out int d, out int y)
{
	s = m = h = d = y = 0;
	float R = secondsTotal;

	s = (int)(secondsTotal % 60);
	R -= s;
	if (R < 60)
		return;
	m = (int)((secondsTotal - s) / 60 % 60);
	R -= m * 60;
	if (R < 3600)
		return;
	h = (int)(R / 3600 % 24);
	R -= h * 3600;
	if (R < 86400)
		return;
	d = (int)(R / 86400 % 365);
	R -= d * 86400;
	if (R < 31536000)
		return;
	y = (int)(R / 31536000);
}
