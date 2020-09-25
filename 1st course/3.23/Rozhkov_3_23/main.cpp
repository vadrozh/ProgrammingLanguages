/*
 * Author: Rozhkov Vadim
 *
 * Group: СБС-901, 3 подгруппа
 *
 * Task, #: 3.23
 *
 * Description: Задан массив целых чисел из 11 элементов. Сформировать из него массив уникальных значений с сохранением порядка следования чисел
 *              (убрать из исходного массива все повторяющиеся значения). В сформированнном массиве найти два элемента, которые при сортировке по возрастанию и по
 *              убыванию смещаются со своих позиций наиболее далеко.
*/


#include <iostream>
#include <cstdio>
#include <cstdlib>
#include <ctime>
#include <cmath>

using namespace std;

void fillArrayByKeyBoard(int array[], const int size);
void fillArrayByRandom(int array[], const int size);

void printArray(int array[], const int size);
void copyArray(int array[], int resultArray[], const int size);

int removeNonUniqueNumbers(int array[], const int size);
//returns new size of array

void sortArray(int array[], const int size, bool type = true); // true = to bigger, false = to smaller

int findElement(int element, int array[], const int size);
//returns element position

void findOffsets(int sortArray[], int originalArray[], const int size);

int main()
{
    const int size = 11;
    int array[size];

    printf("Fill array by keyboard(enter 0) or by random(enter 1)?\n");
    int type;
    scanf("%i", &type);
    if (!type)
            fillArrayByKeyBoard(array, size);
        else
            fillArrayByRandom(array, size);

    int newSize = removeNonUniqueNumbers(array, size);
    printArray(array, newSize);

    int smallerArray[size];
    copyArray(array, smallerArray, newSize);
    sortArray(smallerArray, newSize, false);
    printArray(smallerArray, newSize);

    int biggerArray[size];
    copyArray(array, biggerArray, newSize);
    sortArray(biggerArray, newSize);
    printArray(biggerArray, newSize);

    printf("-------------------------\n");
    printf("Sort to max offsets:\n");
    findOffsets(biggerArray, array, size);
    printf("-------------------------\n");
    printf("Sort to min offsets:\n");
    findOffsets(smallerArray, array, size);

    return 0;
}

void fillArrayByKeyBoard(int array[], const int size)
{
    printf("Enter array of 11 numbers\n");
    for (int i = 0; i < size; i++){
        printf("a%i: ", i);
        scanf("%i", &array[i]);
    }
}

void fillArrayByRandom(int array[], const int size)
{
    srand(time(nullptr));
    for (int i = 0; i < size; i++){
        array[i] = rand();
    }
}

void printArray(int array[], const int size)
{
    for (int i = 0; i < size; i++)
        printf("%i ", array[i]);
    printf("\n");
}

void copyArray(int array[], int resultArray[], const int size)
{
    for (int i = 0; i < size; ++i)
        resultArray[i] = array[i];
}

int removeNonUniqueNumbers(int array[], const int size)
{
    int newSize = size;
    for (int i = 0; i < newSize; ++i)
        for (int j = i+1; j < newSize; ++j) {
            if (array[i] == array[j]) {
                for (int k = j; k < newSize - 1; ++k) {
                    array[k] = array[k+1];
                }
                --newSize;
            }
        }
    return newSize;
}

void sortArray(int array[], const int size, bool type)
{
    for (int i = 0; i < size - 1; ++i)
        for (int j = 0; j < size - i - 1; ++j)
            if (type) {
                if (array[j] > array[j+1]){
                    int temp = array[j];
                    array[j] = array[j+1];
                    array[j+1] = temp;
                }
            } else {
                if (array[j] < array[j+1]){
                    int temp = array[j];
                    array[j] = array[j+1];
                    array[j+1] = temp;
                }
            }
}

int findElement(int element, int array[], const int size)
{
    for (int i = 0; i < size; ++i)
        if (array[i] == element)
            return i;
    return -1;
}

void findOffsets(int sortArray[], int originalArray[], const int size)
{
    int firstMax = 0, secondMax = 0;
    for (int i = 0; i < size; ++i) {
        int elementPos = findElement(originalArray[i], sortArray, size);
        if (abs(i-elementPos) > firstMax){
            secondMax = firstMax;
            firstMax = i;
        }
    }
    printf("First max offset: #%i \n", firstMax);
    printf("Second max offset: #%i \n", secondMax);
}


