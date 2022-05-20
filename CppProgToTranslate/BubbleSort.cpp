#include "BubbleSort.h"
#include <iostream>

BubbleSort::BubbleSort() {
	
}

BubbleSort::~BubbleSort() {

}

void BubbleSort::default_sort(int* array_to_sort, int array_length) {
	for (int i = 0; i < array_length; i++)
    {
        for (int j = 0; j < array_length - 1; j++)
        {
            if (array_to_sort[j] > array_to_sort[j + 1])
            {
                int temp = array_to_sort[j + 1];
                array_to_sort[j + 1] = array_to_sort[j];
                array_to_sort[j] = temp;
            }
        }
    }
}

void BubbleSort::optimized_sort(int* array_to_sort, int array_length) {
	for (int i = 0; i < array_length; i++)
    {
        for (int j = 0; j < array_length - i - 1; j++)
        {
            if (array_to_sort[j] > array_to_sort[j + 1])
            {
                int temp = array_to_sort[j + 1];
                array_to_sort[j + 1] = array_to_sort[j];
                array_to_sort[j] = temp;
            }
        }
    }
}