package week.three;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Scanner;

public class PopulationByDistricts {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner scan = new Scanner(System.in);
		String[] cityToken = scan.nextLine().split(" ");
		Map<String, List<Integer>> population = new HashMap<>();
		
		for(String token : cityToken) {
			String[] cityArgs = scan.nextLine().split(":");
			population.putIfAbsent(cityArgs[0], new ArrayList<>());
			population.get(cityArgs[0]).add(Integer.parseInt(cityArgs[1]));
		}
		
		population.entrySet().stream()
			.filter(c -> c.getValue().stream().reduce(0, Integer::sum) > 10)
			.sorted((e1, e2) -> Integer.compare(
					e2.getValue().stream().mapToInt(Integer::valueOf).sum(), 
					e1.getValue().stream().mapToInt(Integer::valueOf).sum()
			)).forEach(e -> {
				System.out.printf("%s: ", e.getKey());
				e.getValue().stream().sorted((a, b) -> Integer.compare(b, a)).forEach(p -> System.out.print(p + " "));
				System.out.println();
			});
	}

}
