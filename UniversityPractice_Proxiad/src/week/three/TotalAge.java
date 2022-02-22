package week.three;

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class TotalAge {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner scan = new Scanner(System.in);
		Map<String,Person> people = new HashMap<>();
		Arrays.stream(scan.nextLine().split(", ")).forEach(kvp -> {
			String[] kvpArgs = kvp.split(":");
			people.put(kvpArgs[0],new Person(kvpArgs[0],Integer.parseInt(kvpArgs[1])));
		});
		
		Integer totalAge = people.values().stream().reduce(0,(partialAge,person) -> partialAge + person.getAge(),Integer::sum);
		System.out.println(totalAge);
	}

}

class Person {
	private String name;
	private int age;
	
	Person(String name,int age){
		this.name = name;
		this.age = age;
	}
	
	String getName() {
		return this.name;
	}
	
	int getAge() {
		return this.age;
	}
}
