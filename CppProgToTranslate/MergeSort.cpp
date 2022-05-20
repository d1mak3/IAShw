#include "MergeSort.h"
#include <iostream>

MergeSort::MergeSort() {

}

MergeSort::~MergeSort() {

}

void MergeSort::merge(int* array_to_sort, int first, int last) {
	int middle, start, final, iterator;
	int *temp_array = new int[last + 1];

	middle = (first + last) / 2; // Вычисление среднего элемента
	start = first; // Начало левой части
	final = middle + 1; // Начало правой части
	
	// Выполнять от начала до конца
	for(iterator = first; iterator <= last; iterator++) {
		if ((start <= middle) && ((final > last) || (array_to_sort[start] < array_to_sort[final]))) {
			temp_array[iterator] = array_to_sort[start];
			start++;
		}
		else {
			temp_array[iterator] = array_to_sort[final];
			final++;
		}
	}

	// Возвращение результата в список
	for (iterator = first; iterator <= last; iterator++) {
		array_to_sort[iterator] = temp_array[iterator];
	}

	delete[] temp_array; // Удаление временного массива из памяти
}

// Рекурсивная процедура сортировки
void MergeSort::sort(int* array_to_sort, int first, int last) {
	if (first < last)	{
		sort(array_to_sort, first, (first + last) / 2); // Сортировка левой части
		sort(array_to_sort, (first + last) / 2 + 1, last); // Сортировка правой части
		merge(array_to_sort, first, last); // Слияние двух частей
	}
}