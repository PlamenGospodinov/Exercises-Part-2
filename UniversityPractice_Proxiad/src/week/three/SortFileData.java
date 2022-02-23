package week.three;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Stream;

public class SortFileData {

	public static void main(String[] args) throws IOException {
		// TODO Auto-generated method stub
		String path = "C:\\Users\\Plamen\\OneDrive\\Работен плот\\Proxiad\\persons.txt";
		String[] lines = Files.lines(Paths.get(path)).toArray(String[]::new);
		String[] persons = Arrays.stream(lines).filter(l -> !l.isEmpty()).toArray(String[]::new);
		
		List<Person> personList = new ArrayList<>();
		for(String person : persons) {
			String[] singleLine = person.split(",|\\=");
			Person pers = new Person(singleLine[1],singleLine[3],Integer.parseInt(singleLine[5]),singleLine[7],singleLine[9],Integer.parseInt(singleLine[11]));
			personList.add(pers);
		}
		
		String longestName = "";
		for(Person p : personList) {
			String combinedName = p.getFirstName() + " " + p.getLastName();
			if(combinedName.length() > longestName.length()) {
				longestName = combinedName;
			}
		}
		System.out.println("Най дълго име: " + longestName + " ," + " Дължина на името: " + (longestName.length()-1));
		int peopleAt25 = (int) personList.stream().filter(p -> (p.getNumber() == 25)).count();
		System.out.println("Хората живеещи на улица с номер 25 са: " + peopleAt25 + "-ма");
		
	}
	
	private static class Person{
		private String firstName;
		private String lastName;
		private int age;
		private String city;
		private String street;
		private int number;
		Person(String firstName,String lastName,int age,String city,String street,int number) {
			this.firstName = firstName;
			this.lastName = lastName;
			this.age = age;
			this.city = city;
			this.street = street;
			this.number = number;
		}
		
		public String getFirstName(){
			return firstName;
		}
		
		public String getLastName(){
			return lastName;
		}
		
		public int getAge(){
			return age;
		}
		
		
		public String getCity(){
			return city;
		}
		
		public String getStreet(){
			return street;
		}
		
		public int getNumber(){
			return number;
		}
	}

}


