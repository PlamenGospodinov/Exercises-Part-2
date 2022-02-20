package week.second;

import java.util.Scanner;
import java.util.function.BiFunction;

public class Sum {

	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		String[] inputLine = scanner.nextLine().split(", ");
		int sum = 0; 
		
		BiFunction<String, String, Integer> calculateSum = (a,b) -> Integer.parseInt(a) + Integer.parseInt(b);
		
		for(int i = 0;i<inputLine.length-1;i++) {
			sum += calculateSum.apply(inputLine[i],inputLine[i+1]);
			
			System.out.println(sum);
		}
	}

}
