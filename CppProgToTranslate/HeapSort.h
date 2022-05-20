class HeapSort {
private:
	int* array_to_sort;
	int array_length;

	void heapify(int*, int, int);

public:
	HeapSort(int*, int);
	~HeapSort();

	void sort();	
};