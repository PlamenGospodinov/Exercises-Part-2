package week.second;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.function.Function;

public class VAT {
	public static void main(String[] args) {
		
	Scanner scanner = new Scanner(System.in);
	String[] inputLine = scanner.nextLine().split(", ");
	List<Double> prices = new ArrayList<>();
	Function<String, Double> calcVat = p -> Double.parseDouble(p) * 1.2;
	
	for(String pric : inputLine) {
		prices.add(calcVat.apply(pric));
	}
	System.out.println(prices);
	
	}
}
