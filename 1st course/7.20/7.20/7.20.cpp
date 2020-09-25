/**
* Дан тестовый файл.
* Переписать его содержимое в другой файл,
* заменяя все идущие подряд пробелы на один пробел.
**/
#include <iostream>
#include <ctime>
#include <cstdlib>

int main() {
    FILE* input;
    FILE* output;
    fopen_s(&input, "C:\\Users\\vadim\\Desktop\\input.txt", "r");
    fopen_s(&output, "C:\\Users\\vadim\\Desktop\\output.txt", "w");
    if (!input || !output)
        return 0;

    int c = 0;
    int a = 0;
    while ((c = fgetc(input)) != EOF)
        if (c != ' '){
            fputc(c, output);
            a = c;
        }
        else if (a != ' ') {
            fputc(c, output);
            a = c;
        }

    fclose(input);
    fclose(output);
}

