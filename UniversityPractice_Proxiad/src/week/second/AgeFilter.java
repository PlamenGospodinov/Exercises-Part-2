package week.second;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.function.Consumer;
import java.util.function.Predicate;

public class AgeFilter {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		String[] input = scan.nextLine().split(", ");
		Map<String, Integer> people = new HashMap<>();
		for(String person : input){
			String[] individual = person.split(" ");
			people.put(individual[0], Integer.parseInt(individual[1]));
		}
		Predicate<Integer> checkAge = age -> age < 25;
		Consumer<String> printer = p -> System.out.println(p);
		printWhoPassedCheck(people, checkAge, printer);
		
	}
	
	public static void printWhoPassedCheck(Map<String,Integer> peopleMap,Predicate<Integer> check,Consumer<String> printerConsumer) {
		peopleMap.forEach((name,age) -> {
			if(check.test(age))
				printerConsumer.accept(name);
		});
	}

}
