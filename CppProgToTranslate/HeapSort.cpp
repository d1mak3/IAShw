#include "HeapSort.h"
#include <iostream>

using namespace std;

HeapSort::HeapSort(int* new_array, int new_array_length) {
    array_to_sort = new_array;
    array_length = new_array_length;
}

HeapSort::~HeapSort() {

}

// Процедура для преобразования в двоичную кучу поддерева с корневым узлом i, что является
// индексом в arr[]. n - размер кучи
void HeapSort::heapify(int* arr, int n, int i) {
    int largest = i; 

    // Инициализируем наибольший элемент как корень
    int l = 2 * i + 1; // левый = 2*i + 1
    int r = 2 * i + 2; // правый = 2*i + 2

    // Если левый дочерний элемент больше корня
    if (l < n && arr[l] > arr[largest])
        largest = l;

   // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
    if (r < n && arr[r] > arr[largest])
        largest = r;

    // Если самый большой элемент не корень
    if (largest != i)
    {
        swap(arr[i], arr[largest]);

        // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
        heapify(arr, n, largest);
    }
}

// Основная функция, выполняющая пирамидальную сортировку
void HeapSort::sort() {
    int n = array_length;

    // Построение кучи (перегруппируем массив)
    for (int i = n / 2 - 1; i >= 0; i--)
        heapify(array_to_sort, n, i);

    // Один за другим извлекаем элементы из кучи
    for (int i = n - 1; i >= 0; i--)
    {
        // Перемещаем текущий корень в конец
        swap(array_to_sort[0], array_to_sort[i]);

        // вызываем процедуру heapify на уменьшенной куче
        heapify(array_to_sort, i, 0);
    }
}