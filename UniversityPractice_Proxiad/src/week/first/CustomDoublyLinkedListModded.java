package week.first;

import java.util.Iterator;
import java.util.NoSuchElementException;

public class CustomDoublyLinkedList<E> implements Iterable<E> {
	private NodeDouble<E> head;
	private NodeDouble<E> tail;
	private int size;
	
	public CustomDoublyLinkedList() {
		this.size = 0;
	}
	
	public int size() {
		return this.size;
	}
	
	public E getFirst() {
		return this.head != null ? this.head.element : null;
	}
	
	public E getTail() {
		return this.tail != null ? this.tail.element : null;
	}
	
	public void addFirst(E element) {
		NodeDouble<E> node = new NodeDouble<>(element,head,null);
		if(head != null) {
			head.prev = node;
		}
		head = node;
		if(tail == null) {
			tail = node;
		}
		size++;
		
	}
	
	public E removeFirst() {
		if(this.head == null) {
			throw new IllegalArgumentException();
		}
		if(size == 0) throw new NoSuchElementException();
		NodeDouble<E> oldFirstElement = this.head;
		NodeDouble<E> newFirstElement = this.head.next;
		this.head = newFirstElement;
		if(this.head.next == null) {
			throw new IllegalArgumentException();
		}
		else {
			this.head.next = newFirstElement.next;
		}
		
		size--;
		return newFirstElement.element;
	}
	
	public void addLast(E element) {
		NodeDouble<E> node = new NodeDouble<>(element, null,tail);
		
		if(tail != null) {
        	tail.next = node;
        }
        tail = node;
        if(head == null) {
        	head = node;
        }
        size++;
	}
	
	public E removeLast() {
		if(this.tail == null) {
			throw new IllegalArgumentException();
		}
		if (size == 0) throw new NoSuchElementException();
		NodeDouble<E> oldLastElement = this.tail;
		NodeDouble<E> newLastElement = this.tail.prev;
		this.tail = newLastElement;
		this.tail.next = null;
		size--;
		return newLastElement.element;

	}
	
	private static class NodeDouble<E> {
		E element;
		NodeDouble<E> next;
		NodeDouble<E> prev;
	
		public NodeDouble(E element, NodeDouble<E> next, NodeDouble<E> prev) {
			this.element = element;
			this.next = next;
			this.prev = prev;
		}
	}

	@Override
	public Iterator<E> iterator() {
		// TODO Auto-generated method stub
		return new CustomIterator<>(this);
	}
	private static class CustomIterator<E> implements Iterator<E>{
		NodeDouble<E> current;
		
		public CustomIterator(CustomDoublyLinkedList<E> list) {
			current = list.head;
		}
	
		@Override
		public boolean hasNext() {
			// TODO Auto-generated method stub
			return this.current != null;
		}

		@Override
		public E next() {
			// TODO Auto-generated method stub
			E data = this.current.element;
			this.current = this.current.next;
			return data;
		}
	}

}
