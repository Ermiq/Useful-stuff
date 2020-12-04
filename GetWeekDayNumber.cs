// Returns the number of the day in a week.
// year, month, day - the date.
// sundayFirst - should be true for the contries where week starts on Sunday
static int GetDayOfWeek(int year, int month, int day, bool sundayFirst) {
  int c = y/100;
	if (m < 3) {
		y -= 1;
		m += 10;
	}
	else m -= 2;
		
	int dowraw = (d + Math.Floor(2.6 * m - 0.2) - 2 * c + y + Math.Floor(y / 4) + Math.Floor(c / 4));

	// Here we get the remainder of dowraw divided by 7.
	// Basically, could be just "dowraw % 7"
	int dow = Math.Floor(dowraw / 7);
	dow = dow * 7;
	dow = dowraw - dow;
	if (dow == 0) dow = 7;

	// Move days for Mon-Sun week variant.
	if (!sundayFirst) {
		dow -= 1;
		if (dow == 0) dow = 7;
	}
	return dow;
}
