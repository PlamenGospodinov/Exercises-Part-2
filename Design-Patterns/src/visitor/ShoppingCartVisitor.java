package visitor;

public interface ShoppingCartVisitor {
	double visit(Book book);
	
	double visit(Fruit fruit);
}