package week.second;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class SortEvenNumbers {
	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		String[] inputData = scan.nextLine().split(", ");
		List<Integer> nums = new ArrayList<>();
		for(String element : inputData) {
			nums.add(Integer.parseInt(element));
		}
		
		nums.removeIf(n -> n % 2 != 0);
		System.out.println(nums.toString());
		nums.sort((a,b) -> a.compareTo(b));
		System.out.println(nums.toString());
	}
}
