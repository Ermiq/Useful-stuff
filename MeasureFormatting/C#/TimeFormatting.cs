public static void GetTimeFromSeconds(float secondsTotal, out int s, out int m, out int h, out int d, out int y)
{
	s = m = h = d = y = 0;

	s = (int)(secondsTotal % 60);
	secondsTotal -= s;
	if (secondsTotal < 60)
		return;

	m = (int)(secondsTotal / 60 % 60);
	secondsTotal -= m * 60;
	if (secondsTotal < 3600)
		return;

	h = (int)(secondsTotal / 3600 % 24);
	secondsTotal -= h * 3600;
	if (secondsTotal < 86400)
		return;

	d = (int)(secondsTotal / 86400 % 365);
	secondsTotal -= d * 86400;
	if (secondsTotal < 31536000)
		return;

	y = (int)(secondsTotal / 31536000);
}
