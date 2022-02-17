package week.first;

import java.util.ArrayDeque;
import java.util.Deque;
import java.util.Scanner;

public class Main {
	public static void main(String[] args) {
		CustomList<Integer> list = new CustomList<>();
		list.add(5);
		list.add(7);
		list.add(9);

//		System.out.println(list.size());
		System.out.println(list.get(0));
		System.out.println(list.get(1));
		System.out.println(list.get(2));
//		System.out.println(list.get(8));
//		System.out.println(list.contains(5));
//		System.out.println(list.contains(15));

		System.out.println("----");
		System.out.println(list.removeAt(1));
		
		//Brackets exercise
		/*
		
		Scanner scan = new Scanner(System.in);
		
		String line = scan.nextLine();
		
		Deque<Integer> bracketsIndices = new ArrayDeque<>();
		
		for (int i = 0; i < line.length(); i++) {
			if (line.charAt(i) == '(' ) {
				bracketsIndices.push(i);
			} else if (line.charAt(i) == ')') {
				int oppeningScopeIndex = bracketsIndices.pop();
				System.out.println(line.substring(oppeningScopeIndex, i + 1));
			}
		}*/
		
		//Trying CustomLinkedList
		CustomLinkedList<String> linkedList = new CustomLinkedList<>();
		
		linkedList.addFirst("Ivan");
		linkedList.addFirst("Georgi");
		linkedList.addFirst("Hristina");
		
		System.out.println(linkedList.size());
		String removeFirst = linkedList.removeFirst();
		System.out.println(removeFirst);
		removeFirst = linkedList.removeFirst();
		System.out.println(removeFirst);
		removeFirst = linkedList.removeFirst();
		/*System.out.println(removeFirst);
		removeFirst = linkedList.removeFirst();
		*/
		//Trying CustomDoublyLinkedList
		CustomDoublyLinkedList<String> linkedDoublyList = new CustomDoublyLinkedList<>();
		
		linkedDoublyList.addFirst("Ivan");
		linkedDoublyList.addFirst("Georgi");
		linkedDoublyList.addFirst("Hristina");
		
		System.out.println(linkedDoublyList.size());
		String removeDoublyFirst = linkedDoublyList.removeFirst();
		System.out.println(removeDoublyFirst);
		//removeDoublyFirst = linkedDoublyList.removeFirst();
		//System.out.println(removeDoublyFirst);
		//removeDoublyFirst = linkedDoublyList.removeFirst();
		/*System.out.println(removeDoublyFirst);
		removeDoublyFirst = linkedDoublyList.removeFirst();*/
	}
}
