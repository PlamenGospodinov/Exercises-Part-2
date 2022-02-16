package week.first;

public class CustomLinkedList<E> {
	private Node<E> first;
	private int size;
	
	public CustomLinkedList() {
		this.size = 0;
	}
	
	public int size() {
		return this.size;
	}
	
	public void addFirst(E element) {
		Node<E> node = new Node<>(element, null);
		
		if (this.first != null) {
			node.next = this.first;
		}
		this.first = node;
		this.size++;
	}
	
	public E removeFirst() {
		if (this.first == null) {
			throw new IllegalArgumentException();
		}
		Node<E> oldFirstElement = this.first;
		Node<E> newFirstElement = this.first.next;
		this.first = newFirstElement;
		
		this.size--;
		
		return oldFirstElement.element;
	}
	
	private static class Node<E> {
		E element;
		Node<E> next;
		
		Node(E element, Node<E> next) {
			this.element = element;
			this.next = next;
		}
	}

}