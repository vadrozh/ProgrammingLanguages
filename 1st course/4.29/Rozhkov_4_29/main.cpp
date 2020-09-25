/*
 * Author: Rozhkov Vadim
 *
 * Group: СБС-901, 3 подгруппа
 *
 * Task, #: 4.29
 *
 * Description: Вывести на экран таблицу размером 24 x 80, состоящую из нулей и единиц, такую, что единицы образуют
 *              аналог окружности, заданной своим центром (позиция в таблице) и целочисленным радиусом.
*/

#include <iostream>
#include <cstdio>
#include <cmath>
#include <typeinfo>

int const x_size = 24, y_size = 80;

void fillCenterCoordinates(int* center_x, int* center_y);
void fillCircleRadius(int* radius);

void outFlat(int[x_size][y_size]);
void getMatrix(int**, int, int, int, int, int, int);
int init_C(int, int, int*);
void cooperateFlatCircle(int[x_size][y_size], int**, int, int, int, int);

int main()
{
    int center_x = -1, center_y = -1;
    fillCenterCoordinates(&center_x, &center_y);

    int radius = -1;
    fillCircleRadius(&radius);

    int flat[x_size][y_size];

    for (int i = 0; i < x_size; i++) {
        for (int j = 0; j < y_size; j++) {
            flat[i][j] = 0;
        }
    }

    if (radius > sqrt(x_size * x_size + y_size * y_size)) {
        outFlat(flat);
        return 0;
    }

    int matrix_s = 2 * radius + 1;

    int** p_circle_matrix = new int* [matrix_s];
    for (int i = 0; i < matrix_s; i++) {
        p_circle_matrix[i] = new int[matrix_s];
    }
    for (int i = 0; i < matrix_s; i++) {
        for (int j = 0; j < matrix_s; j++) {
            p_circle_matrix[i][j] = 0;
        }
    }
    p_circle_matrix[radius][2 * radius] = 1;

    int x_start = radius;
    int y_start = 2 * radius;

    getMatrix(p_circle_matrix, x_start, y_start, x_start, y_start, radius, 0);

    for (int i = 0; i < matrix_s; i++) {
        for (int j = 0; j < matrix_s; j++) {
            printf(" %d", p_circle_matrix[i][j]);
        }
        printf("\n");
    }

    // почти победа, совместим окружность и поле

    cooperateFlatCircle(flat, p_circle_matrix, matrix_s, radius, center_x, center_y);

    outFlat(flat);
}

void fillCenterCoordinates(int* center_x, int* center_y)
{
    printf("Enter coordinates(x,y) of circle center(only int numbers) \n");
    scanf("%i", center_x);
    scanf("%i", center_y);
    if (*center_x <= 0 || *center_y <= 0) {
        printf("Invalid coordinates, try again");
        fillCenterCoordinates(center_x, center_y);
    }
}

void fillCircleRadius(int* radius)
{
    printf("Enter enter circle radius(only int numbers) \n");
    scanf("%i", radius);
    if (*radius <= 0) {
        printf("Invalid radius, try again");
        fillCircleRadius(radius);
    }
}

void outFlat(int flat[x_size][y_size]) {
    for (int i = 0; i < x_size; i++) {
        for (int j = 0; j < y_size; j++) {
            printf("%d", flat[i][j]);
        }
        printf("\n");
    }
}

void getMatrix(int** matrix, int x_start, int y_start, int x, int y, int r, int k) {
    int b_x = 0;
    int b_y = 0;

    while (true) {
        int i_m = 3;
        int i_i = init_C(x, r, &i_m);

        int j_m = 3;
        int j_i = init_C(y, r, &j_m);


        float length = 0;
        float best_len = 0;
        for (int i = i_i; i < i_m; i++) {
            for (int j = j_i; j < j_m; j++) {
                if (matrix[x - 1 + i][y - 1 + j] == 0) {
                    length = sqrt(pow((x - 1 + i) - r, 2) + pow((y - 1 + j) - r, 2));
                    if (abs(length - r) <= abs(best_len - r)) {
                        best_len = length;
                        b_x = x - 1 + i;
                        b_y = y - 1 + j;
                    }
                }
            }
        }
        x = b_x;
        y = b_y;
        matrix[x][y] = 1;

        if (x_start == b_x && y_start == b_y) {
            break;
        }
        if (k == 2) {
            matrix[x_start][y_start] = 0;
        }
        k++;
    }
}

int init_C(int c, int r, int* p_c_max) {
    int i = 0;
    if (c == 0) {
        i = 1;
    }
    if (c == 2 * r) {
        *p_c_max = 2;
    }
    return i;
}

void cooperateFlatCircle(int flat[x_size][y_size], int** matrix, int m_size, int r, int x, int y) {
    int i_i = x - r - 1;
    int i_e = x + r;

    int k = 0;
    int f = 0;
    int f_m = 0;
    if (i_i < 0) {
        k = r - x;
        i_i = 0;
        i_e += 1;
    }
    if (i_e > x_size - 1) {
        i_e = x_size;
    }
    int j_i = y - r - 1;
    int j_e = y + r;
    if (j_i < 0) {
        f = r - y;
        j_e += 1;
        f_m = f;
        j_i = 0;
    }
    if (j_e > y_size - 1) {
        j_e = y_size;
    }
    for (int i = i_i; i < i_e; i++) {
        for (int j = j_i; j < j_e; j++) {
            flat[i][j] = matrix[k][f];
            f++;
        }
        f = f_m;
        k++;
    }
}
