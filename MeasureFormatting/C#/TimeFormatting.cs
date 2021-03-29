public static void GetTimeFromSeconds(float secondsTotal, out int s, out int m, out int h, out int d, out int y)
{
	s = m = h = d = y = 0;

	s = (int)(secondsTotal % 60);
	// substruct the seconds remainder from the total amount (75 - 15 = 60, 125 - 5 = 120).
	secondsTotal -= s;
	// if nothing left then it was less than 1 minute (45 - 0 = 45).
	if (secondsTotal < 60)
		return;
	
	// secondsTotal / 60 => how many minutes total
	// % 60 => how many minutes remain after splitting to whole hours
	m = (int)(secondsTotal / 60 % 60);
	// substruct the minutes remainder from the total amount (every minute takes 60 secs from the total)
	secondsTotal -= m * 60;
	// if there's not enough seconds remain in the total to get at least 1 whole hour (3600 secs)
	// then it means there was less than 1 hour.
	if (secondsTotal < 3600)
		return;

	// secondsTotal / 3600 => how many hours total
	// % 24 => what will remain after splitting to whole days (24 hours)
	h = (int)(secondsTotal / 3600 % 24);
	// every whole hour takes 3600 secs from the total
	secondsTotal -= h * 3600;
	// 24 hours = 86400 seconds.
	// If there's less remaining than it was less than 24 hours.
	if (secondsTotal < 86400)
		return;

	// secondsTotal/ 86400 => how many days total
	// % 365 => how many will remain after splitting to years
	d = (int)(secondsTotal / 86400 % 365);
	// substruct whole days
	secondsTotal -= d * 86400;
	// 1 year = 31536000 secs.
	// is there enough secs remaining to get a whole year?
	if (secondsTotal < 31536000)
		return;

	y = (int)(secondsTotal / 31536000);
}