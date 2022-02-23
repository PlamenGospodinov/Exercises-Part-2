package week.three;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class AlaBalaPortokala {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner scan = new Scanner(System.in);
		//.filter(s -> s.matches("\\b[a-zA-z]+(?:[-]?[a-z]+)*\\b"))
		String[] words = Arrays.stream(scan.nextLine().split(" |\\. ")).map(String::toLowerCase).toArray(String[]::new);
		Map<String,Integer> wordsMap = new HashMap<>();
		
		for(String word : words) {
			int count = wordsMap.containsKey(word) ? wordsMap.get(word) : 0;
			wordsMap.put(word, count + 1);
			System.out.println(word);
			
		}
		
		Map<String, Integer> sortedMap = 
				wordsMap.entrySet().stream().sorted(Entry.<String, Integer>comparingByKey())
			    .sorted(Entry.<String, Integer>comparingByValue().reversed()).limit(3)
			    .collect(Collectors.toMap(Entry::getKey, Entry::getValue,
			                              (e1, e2) -> e1, LinkedHashMap::new));
		sortedMap.entrySet().forEach(e ->{
			System.out.printf("%s -> %s ", e.getKey(),e.getValue());
			System.out.println();
		});
		
	}

}
