// Returns a list of int arrays with all the possible unique combination in a given amount of elements with a given combination length.
// If we have an array of 10 integers, and we need to know how many unique combinations could be made with a length of 3.
// Like {1,2,3}, {0,2,8}, {4,6,7}, {1,3,9}...
// 
//	Usage:
//		int[] numbers = new int[] { 0,1,2,3,4,5,6,7,8,9};
//		int cominationLength = 3;
//		List<int[]> allCombinations = CombinationResolver.GetAllCombinations(combinationLength, numbers) as List<int[]>;
//		foreach (int[] combo in allCombunations) {
//			Print(combo.ToString());
//		}
//	Result:
//		{0,1,2}
//		{0,1,3}
//		{0,1,4}
//		{0,1,5}
//		...
//		{0,1,8}
//		{0,1,9}
//		{0,2,3}
//		{0,2,4}
//		...
//		{6,8,9}
//		{7,8,9}
//

public class CombinationResolver {
	
	public static List<int[]> GetAllCombinations (int comboLength, List<Object> elements) {
		List<int[]> result = new List<int[]> ();
		
		List<int[]> comboIndexes = GetComboIndexes(comboLength, elements.Count);
		for (int i = 0; i < comboIndexes.Count; i++) {
			Object[] combo = new Object[comboLength];
			for (int j = 0; j < comboLength; j++) {
				combo[j] = comboIndexes[i][elements[j]];
			}
			result.Add(combo);
  		}
  		return result;
	}

	static List<int[]> GetComboIndexes(int comboLength, int elementsCount) {
		List<int[]> result = new List<int[]>();
		int[] output = new int[comboLength];
		
		// The very first combination gotta look like {0,1,2} or {0,1,2,3} or {0,1,2,3,4,5}
		for (int i = 0; i < comboLength; i++) {
			output[i] = i;
		}
		
		while (true) {
			int[] combo = output.Clone() as int[];
			result.Add(combo);
			if (!IncrementIndexes(output, elementsCount - comboLength + 1))
				break;
		}
		return result;
	}

	////
	// For 2x2 matrix and comboLength=2 this method will return:
	//	{0,1}
	//	{0,2}
	//	{0,3}
	//	{1,2}
	//	{1,3}
	//	{2,3}
	static bool IncrementIndexes (int[] indexes, int maxIncrement) {
		bool max = false;
		indexes[indexes.Length - 1]++; // E.g., changed {0,1,2,<5>} to { 0,1,2,<6> }

		// Check out all the indexes after the incrementation starting from the last one.
		for (int i = indexes.Length - 1; i >= 0; i--) {
			if (max) {
				// When the last incremented index is out of boundaries, bool max will be true.
				// E.g., the max index limit is 5, but we got {0,1,2,<6>} in the previous for(i) loop.
				// It means we should increment the current index in the loop.
				// It was the 3rd index {0,1,2,<6>}, now we're at the 2nd {0,1,<2>,6}...
				indexes[i]++;
				// Got {0,1,<3>,6}
				// ... and then set all the following indexes to the apropriate values in a row (gotta get {0,1,<3>,4})
				for (int j = i; j < indexes.Length; j++) {
					indexes[j] = indexes[i]+(j - i);
				}
			}
			// Check if out of boundaries.
			// We're still in the for(i) loop), and if we get true, next loop will trigger the rearrangement process above.
			if (indexes[i] >= i + maxIncrement) {
				max = true;
				// If we're at the most left index, let the call method know that we can't increment any further.
				if (i == 0)
					return false;
			}
			else
				max = false;
		}
		return true;
	}
}
