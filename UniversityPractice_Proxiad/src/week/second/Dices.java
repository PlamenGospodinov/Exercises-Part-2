package week.second;

import java.util.Random;
import java.util.function.Consumer;
import java.util.function.Supplier;

public class Dices {
	public static void main(String[] args) {
		Supplier<Integer> diceOptions = () -> new Random().ints(2,13).findFirst().getAsInt();
		Consumer<Integer> printer = (i) -> System.out.println(i);
		
		for(int i = 0;i<4;i++) {
			printer.accept(diceOptions.get());
		}
	}
}
