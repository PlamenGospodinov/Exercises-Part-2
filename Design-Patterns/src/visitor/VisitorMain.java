package visitor;

public class VisitorMain {

	public static void main(String[] args) {

		Product apple = new Fruit("Apple", 2.5, 2);
		Product book = new Book("12312ASA12", "The witcher", 60);
		
		ShoppingCartVisitor calc = new PriceCalculator();
		double applePrice = apple.accept(calc);
		double bookPrice = book.accept(calc);

	}
}