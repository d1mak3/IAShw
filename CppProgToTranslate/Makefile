all: ProgToTranslate

ProgToTranslate: main.o HeapSort.o MergeSort.o BubbleSort.o
	g++ main.o HeapSort.o MergeSort.o BubbleSort.o -o main

main.o: main.cpp
	g++ -c main.cpp

HeapSort.o: HeapSort.cpp
	g++ -c HeapSort.cpp

MergeSort.o: MergeSort.cpp
	g++ -c MergeSort.cpp

BubbleSort.o: BubbleSort.cpp
	g++ -c BubbleSort.cpp

clean:
	rm -rf *.o ProgToTranslate