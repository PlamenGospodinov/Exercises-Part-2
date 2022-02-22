package week.three;

import java.util.Arrays;
import java.util.OptionalDouble;
import java.util.Scanner;

public class SmallestEvenNumber {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner scanner = new Scanner(System.in);
		OptionalDouble findFirstEvenNumber = Arrays.stream(scanner.nextLine().split(" ")).filter(n -> !n.isEmpty()).mapToDouble(Double::parseDouble).filter(n -> n%2 == 0).sorted().findFirst();
		if(findFirstEvenNumber.isPresent()) {
			System.out.printf("%.2f",findFirstEvenNumber.getAsDouble());
		}
		else {
			System.out.println("No match");
		}
	}

}
