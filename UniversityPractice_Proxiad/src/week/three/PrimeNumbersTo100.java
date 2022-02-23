package week.three;

import java.util.stream.Collectors;
import java.util.stream.IntStream;

public class PrimeNumbersTo100 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		IntStream.rangeClosed(2, 100).filter(x -> IntStream.range(2, x).noneMatch(i -> x%i==0)).boxed().collect(Collectors.toList()).forEach(x -> System.out.print(x + " " ));
	}

}
