package visitor;

public interface Product {
	
	double accept(ShoppingCartVisitor visitor);
}