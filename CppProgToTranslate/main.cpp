#include <iostream>
#include <ctime>
#include <windows.h>

#include "HeapSort.h" 
#include "MergeSort.h"
#include "BubbleSort.h"

using namespace std;

void print_array(int* arr, int arr_length) {
	for (int i = 0; i < arr_length; i++) {
		cout << arr[i] << ' ';
	}
}

// Управляющая программа
int main()
{
	setlocale(0, "");
	srand(time(0));

	int experiments_count = 10;	
	int array_length	  = 10;

	for (int i = 0; i < experiments_count; i++) {
		cout << endl << "Experiment #" << i + 1 << endl;		
		cout << "	Array lentgth: " << array_length << endl;	

		int* array_for_heapsort = new int[array_length];
		int* array_for_mergesort = new int[array_length];
		int* array_for_bubblesort = new int[array_length];
		int* array_for_optimized_bubblesort = new int[array_length];

		cout << "	Array elements: ";
		for (int j = 0; j < array_length; j++) {	
			int new_array_element = -50 + rand() % 100;

			array_for_mergesort[j] = new_array_element;
			array_for_heapsort[j] = new_array_element;
			array_for_bubblesort[j] = new_array_element;
			array_for_optimized_bubblesort[j] = new_array_element;
			cout << new_array_element << ' ';
		}		

		HeapSort heap_sorter(array_for_heapsort, array_length);
		BubbleSort bubble_sorter;
		MergeSort merge_sorter;

		clock_t timestamp_before_heapsort, timestamp_after_heapsort,
			timestamp_after_mergesort, timestamp_after_bubblesort,
			timestamp_after_optimized_bubblesort;

		timestamp_before_heapsort = clock();

		heap_sorter.sort();
		Sleep(500);
		timestamp_after_heapsort = clock();

		merge_sorter.sort(array_for_mergesort, 0, array_length - 1);
		Sleep(500);
		timestamp_after_mergesort = clock();

		bubble_sorter.default_sort(array_for_bubblesort, array_length);
		Sleep(500);
		timestamp_after_bubblesort = clock();

		bubble_sorter.optimized_sort(array_for_optimized_bubblesort, array_length);
		Sleep(500);
		timestamp_after_optimized_bubblesort = clock();

		cout << endl << "	Heapsorted array: ";		
		print_array(array_for_heapsort, array_length);		

		cout << endl << "	Mergesorted array: ";	
		print_array(array_for_mergesort, array_length);	

		cout << endl << "	Bubblesorted array: ";	
		print_array(array_for_bubblesort, array_length);

		cout << endl << "	Optimized bubblesorted array: ";	
		print_array(array_for_optimized_bubblesort, array_length);

		cout << endl << "	Heapsort time: " << 
			timestamp_after_heapsort - timestamp_before_heapsort - 500 << endl;
		
		cout << "	Mergesort time: " <<
			timestamp_after_mergesort - timestamp_after_heapsort - 500 << endl;

		cout << "	Bubblesort time: " << 
			timestamp_after_bubblesort - timestamp_after_mergesort - 500 << endl;

		cout << "	Optimized bublesort time: " << 
			timestamp_after_optimized_bubblesort - timestamp_after_bubblesort - 500 << endl;

		array_length += 1 + rand() % 5;
	}    
}