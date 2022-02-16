package week.first;

public class Polymorphism {
	public static void main(String[] args) {
		
		AnimalPoly person = new PersonPoly();
		AnimalPoly cat = new Cat();
		AnimalPoly dog = new Dog();
		AnimalPoly duck = new Duck();
		
		
		person.makeSound();
		dog.makeSound();
		cat.makeSound();
		duck.makeSound();
		
		System.out.println(sum(1,2));
		System.out.println(sum(1,2,3));
	}
	
	//Overloading polymorphism
	public static int sum(int first,int second) {
		return first + second;
	}
	
	public static double sum(double first,double second) {
		return first + second;
	}
	
	public static int sum(int first,int second,int third) {
		return first + second + third;
	}
}

class AnimalPoly{
	void makeSound() {
		System.out.println("Hello");
	};
}

class PersonPoly extends AnimalPoly{

	@Override
	void makeSound() {
		System.out.println("Hi");
	}
}

class Cat extends AnimalPoly{

	@Override
	void makeSound() {
		System.out.println("Meow");
	}
}

class Dog extends AnimalPoly{

	@Override
	void makeSound() {
		System.out.println("Woof");
	}
}


class Duck extends AnimalPoly{

	@Override
	void makeSound() {
		System.out.println("Quack");
	}
}
