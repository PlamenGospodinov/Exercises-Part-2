package week.three;

import java.util.ArrayList;
import java.util.List;

public class ReduceDemo {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		List<Integer> nums = new ArrayList<>();
		nums.add(5);
		nums.add(15);
		nums.add(25);
		nums.add(53);
		nums.add(54);
		nums.add(55);
		
		Integer sum = nums.stream().reduce(0, (a,b) -> a+b);
		System.out.println(sum);
	}

}
