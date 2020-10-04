﻿/*
 * Author: Рожков Вадим
 *
 * Group: СБС-901, 2 подгруппа
 *
 * Task, #: 3.22
 *
 * Description: Напишите программу, которая считывает из файла одномерный массив, элементами которого являются вещественные числа и сортирует его:
 *              А) по невозрастанию сортировкой вставками;
 *              В) по неубыванию сортировкой обменом.
 *              Для реализации программы должен быть создан класс sort, содержащий три поля с режимом доступа private: размеры массива и указатель на массив. Класс должен содержать
 *              метод, выполняющий считывание массива из файла, два метода сортировок и метод, выводящий массив на консоль. Все методы должны быть с режимом доступа public.
 *              Методу, считывающему массив из файла, в качестве параметра должен передаваться указатель на файловую переменную открытого файла. Память под массив должна
 *              выделяться динамически в методе, считывающем массив из файла. Проверка наличия файла и открытие файла должны выполняться в функции main(). Кроме этого в функции
 *              main() должен создаваться объект класса и поочередно вызываться методы объекта в следующем порядке:
 *              1) чтение из файла,
 *              2) вывод массива на консоль,
 *              3) сортировка первым методом,
 *              4) вывод массива на консоль,
 *              5) чтение из файла,
 *              6) вывод массива на консоль,
 *              7) сортировка вторым методом,
 *              8) вывод массива на консоль.
 *              Файл должен иметь следующий формат: в первой строке указывается количество элементов массива. Во второй строке элементы массива, разделенные пробелом
 *
*/

#include <iostream>
#include "sortition.h"

using namespace std;

int main()
{
    sortition sort;
    sort.readArrayFromFile("../array.txt");
    sort.printArray();
    return 0;
}