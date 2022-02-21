package week.second;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class VAT3 {
	public static void main(String[] args) {
		Scanner scanner = new Scanner(System.in);
		String[] inputLine = scanner.nextLine().split(", ");
		List<Double> prices = new ArrayList<>();

		for (String price : inputLine) {
			Calculateable calc = VAT3::calculateVat;
			prices.add(calc.calculate(price));
		}
		
		System.out.println(prices);
	}
	
	private static Double calculateVat(String price) {
		return Integer.valueOf(price) * 1.2;
	}
}

@FunctionalInterface
interface Calculateable {
	Double calculate(String num);

}
