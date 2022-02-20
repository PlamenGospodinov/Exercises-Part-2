package week.second;

import java.util.Scanner;
import java.util.function.Predicate;

public class WordsWithCapitalLetter {

	public static void main(String[] args) {
		Scanner scan = new Scanner(System.in);
		String[] line = scan.nextLine().split(", ");
		
		Predicate<String> isWordCapitalized = s->s.charAt(0) == s.toUpperCase().charAt(0);
		for(String word : line) {
			if(isWordCapitalized.test(word)) {
				System.out.println(word);
			}
		}
	}

}
