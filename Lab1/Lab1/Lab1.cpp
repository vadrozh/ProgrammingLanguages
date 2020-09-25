#include <iostream>

int main()
{
    setlocale(LC_ALL, "Russian");
    int stack[50]; //массив для хранения элементов стека
    int count = 0; // счетчик числа элементов в стеке
    int key = 0, elem = 0; // выбранный пункт меню и значение вводимого/выводимого элемента
    while (key != 3) {
        printf("\nСодержимое стека: ");
        print_stack(stack, count); // функция вывода содержимого стека на печать
        printf("1.Добавить элемент в стек.\n");
        printf("2.Извлечь элемент из стека. \n");
        printf("3.Выход из программы.\n")
            printf("Выберитеоперацию: ");
        scanf_s("%i", &key);
        if (key == 1) {
            printf("Введите значение элемента : ");
            scanf_s("%i", &elem);
            push(stack, &count, elem);// Функция добавления элемента в стек
        }
        if (key == 2) {
            if (count == 0)
                printf("\n Извлечение элемента невозможно.\n");
            else
                printf("\n Извлеченный элемент=%i\n", pop(stack, &count));//Функция извлечения из стека
        }
    }

    return 0;
}