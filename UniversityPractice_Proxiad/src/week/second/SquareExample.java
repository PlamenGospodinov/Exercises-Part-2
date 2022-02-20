package week.second;

public class SquareExample {

	public static void main(String[] args) {
		double a = 5.0;
		Square s = (double x) -> 4*x;
		double answer = s.calcularePerimeter(a);
		System.out.println(answer);

	}

}

@FunctionalInterface
interface Square{
	double calcularePerimeter(double a);
}
