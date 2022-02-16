package week.first;

public class CustomList<T> {
	private Object[] elements;
	private int size;
	
	public CustomList() {
		this.elements = new Object[10];
		this.size = 0;
	}
	
	public void add(T element) {
		if (this.elements.length == this.size) {
			doubleArraySize();
		}
		this.elements[size++] = element;
	}
	
	public T get(int index) {
		if (index >= this.size || index < 0) {
			throw new IndexOutOfBoundsException();
		}
		return (T) elements[index];
	}
	
	public boolean contains(T element) {
		for(int i = 0; i < this.elements.length; i++) {
			if (this.elements[i] == element) {
				return true;
			}
		}
		return false;
	}
	
	public int size() {
		return this.size;
	}
	
	public T removeAt(int index) {
		if (index >= this.size || index < 0) {
			throw new IndexOutOfBoundsException();
		}
		T element = (T) this.elements[index];
		for (int i = index; i < this.elements.length - 1; i++) {
			this.elements[i] = this.elements[i + 1];
		}
		
		this.size--;
		
		if (this.size <= this.elements.length / 4) {
			reduceArraySize();
		}
		
		return element;
	}
	
	private void doubleArraySize() {
		Object[] newArray = new Object[this.elements.length * 2];
		for (int i = 0; i < this.elements.length; i++) {
			newArray[i] = this.elements[i];
		}
		
		this.elements = newArray;
	}
	
	private void reduceArraySize() {
		Object[] newArray = new Object[this.elements.length / 2];
		for (int i = 0; i < newArray.length; i++) {
			newArray[i] = this.elements[i];
		}
		
		this.elements = newArray;
	}
}
