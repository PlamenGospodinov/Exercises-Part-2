package week.three;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class FindTwoUnique10To20 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner scanner = new Scanner(System.in);
		/*
		String[] inputLine = scanner.nextLine().split(", ");
		Set<Integer> nums = new HashSet<>();
		
		for(String arg : inputLine) {
			if(nums.size() >= 2) {
				break;
			}
			int num = Integer.parseInt(arg);
			if(num >=10 && num <= 20) {
				nums.add(num);
			}
					
			
		}
		System.out.println(nums);*/
		Arrays.stream(scanner.nextLine().split(" ")).map(Integer::parseInt).distinct().filter(n -> n>=10 && n <= 20).limit(2).forEach(n -> System.out.println(n + " "));
	}

}
