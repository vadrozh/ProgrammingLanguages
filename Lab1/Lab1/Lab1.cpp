/*
 * Author: Рожков Вадим
 *
 * Group: СБС-901, 2 подгруппа
 *
 * Task, #: 1.1(22 вариант)
 *
 * Description: На основе одномерного массива целых чисел, который может содержать не более 50 элементов, реализуйте стек.
 *              Началом массива считается нулевой элемент, а концом массива последний добавленный элемент.
 *              Операция добавления элемента в вершину стека должна выполнять добавление элемента в конец массива.
 *              Операция извлечения элемента из вершины стека должна извлекать последний элемент массива. Каждая из этих операций должна быть
 *              реализована в виде отдельной функции. Также должна быть реализована функция просмотра содержимого стека.
 *              Функция main() должна содержать меню работы со стеком. В начале работы программы и после выполнения каждой операции
 *              на экране должно отображаться текущее содержимое стека (если в стеке нет элементов, должна появляться надпись «стек пуст»)
 *              и меню из трех пунктов:
 *                  1.Добавить элемент в стек.
 *                  2.Извлечь элемент из стека.
 *                  3.Выход из программы.
 *                  Выберите операцию:
 *              В случае выбора первого пункта меню должен появляться запрос
 *                  Введите значение элемента:
 *              Введенный пользователем элемент должен добавляться в вершину стека. В случае выбора второго пункта меню на экран
 *              должен быть выведен элемент из вершины стека. Выводимый элемент удаляется из стека. При выборе третьего пункта
 *              меню программа должна завершать выполнение. При выборе пункта, отсутствующего в меню, должно выводится содержимое стека и меню.
 *
*/

#include <iostream>

enum class Menu {
    EXIT = 0, PUSH, POP, PRINT
};

const size_t stackSize = 50;

void printStack(int stack[], size_t currentSize);
void pushToStack(int stack[], size_t* currentSize, int item);
int popFromStack(int stack[], size_t* currentSize);

int main()
{
    setlocale(LC_ALL, "Russian");
    int stack[stackSize];
    size_t size = 0;

    bool stop = false;
    while (!stop) {
        printf("\n\nСодержимое стека: ");
        printStack(stack, size);
        printf("0. Выход\n");
        printf("1. Добавить элемент в стек\n");
        printf("2. Извлечь элемент из стека\n");
        printf("3. Напечатать содержимое стека\n");
        printf("Выберите операцию: ");
        Menu option;
        scanf_s("%d", &option);
        switch (option)
        {
        case Menu::EXIT:
            stop = true;
            break;
        case Menu::PUSH:
            printf("Введите значение элемента: ");
            int item;
            scanf_s("%i", &item);
            pushToStack(stack, &size, item);
            break;
        case Menu::POP:
            if (size == 0)
                printf("\nИзвлечение элемента невозможно.");
            else
                printf("\nИзвлеченный элемент: %i\n", popFromStack(stack, &size));
            break;
        case Menu::PRINT:
            printStack(stack, size);
            break;
        default:
            printf_s("\nНеправильная опция, попробуйте еще раз.");
            break;
        }
    }

    return 0;
}

void printStack(int stack[], size_t currentSize) {
    if (!currentSize)
        printf("Стек пуст\n");
    else
        for (size_t i = 0; i < currentSize; i++)
            printf("%i ", stack[i]);
    printf("\n");
}

void pushToStack(int stack[], size_t* currentSize, int item) {
    if (*currentSize == stackSize)
        printf("Стек полон. Добавление элемента невозможно.\n");
    else {
        for (size_t i = *currentSize; i > 0; i--)
            stack[i] = stack[i - 1];
        stack[0] = item;
        (*currentSize)++;
    }
}

int popFromStack(int stack[], size_t* currentSize) {
    int item = stack[0];
    for (int i = 0; i < *stack; i++)
        stack[i] = stack[i + 1];
    (*currentSize)--;
    return item;
}