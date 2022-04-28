package composite;

public class CompositeMain {
	
	public static void main(String[] args) {

		Manager manager1 = new Manager("Georgi", 9000);
		Developer dev1 = new Developer("Ivan", 2000);
		
		Manager manager2 = new Manager("Petar", 7500);
		Developer dev2 = new Developer("Stoyan", 4000);
		Developer dev3 = new Developer("Stamat", 7000);

		Manager manager3 = new Manager("Gergana", 7000);
		Developer dev4 = new Developer("Maria", 5000);
		
		manager1.add(dev1);
		manager1.add(manager2);
		manager1.add(manager3);
		
		manager2.add(dev2);
		manager2.add(dev3);

		manager3.add(dev4);
		
		manager1.printData();
	}
}
