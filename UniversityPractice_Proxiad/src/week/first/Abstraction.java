package week.first;

public class Abstraction {
	public static void main(String[] args) {
		Animal person = new Person();
		person.makeSound();
		Mammal personTwo = new Person();
		personTwo.walk();
		Person personThree = new Person();
		personThree.walk();
		personThree.makeSound();
	}
}

abstract class Animal{
	private int legs;
	
	abstract void makeSound();
}

interface Mammal{
	void walk();
}

class Person extends Animal implements Mammal{

	@Override
	void makeSound() {
		System.out.println("Hi");
	}

	@Override
	public void walk() {
		System.out.println("Just walk");
		
	}
	
}
