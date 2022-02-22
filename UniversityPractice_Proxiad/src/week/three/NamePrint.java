package week.three;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class NamePrint {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner scanner = new Scanner(System.in);
		String[] names = scanner.nextLine().split(" ");
		Set<String> letters = new HashSet<>(Arrays.asList(scanner.nextLine().split(" ")));
		Arrays.stream(names).filter(n -> letters.contains(String.valueOf(n.toLowerCase().charAt(0)))).sorted().limit(1).forEach(n -> System.out.println(n + " "));
	}

}
