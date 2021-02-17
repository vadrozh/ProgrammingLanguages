/*
 * Author: Рожков Вадим
 *
 * Group: СБС-901, 2 подгруппа
 *
 * Task, #: 5.5(22 вариант)
 *
 * Description: Реализуйте заголовочный файл с описанием трех классов. Базовый класс Build должен содержать информацию о зданиях в виде трех полей:
                    1) Компания застройщик (Firm, текстовое поле),
                    2) Количество этажей (NumberF, целочисленное поле),
                    3) Год постройки (YearB, целочисленное поле).
                Данный класс должен содержать конструктор с параметрами, а также следующие методы:
                    1) Print(), метод возвращает сведения о здании в виде одной текстовой строки с тремя полями (Компания, Этажность, Год), разделенными пробелом.
                    2) ChangeF(), метод изменяет поле Firm, в качестве параметра методу передается новое наименование компании застройщика.
                    3) ChangeN(), метод изменяет поле NumberF, в качестве параметра методу передается новое количество этажей.
                    4) ChangeY(), метод изменяет поле YearB, в качестве параметра методу передается новый год постройки.
                Второй класс Shop должен быть потомком класса Build и содержать информацию о магазинах с дополнительным полем Square, содержащее величину торговых площадей. Класс
                должен содержать конструктор с параметрами, позволяющий заполнять поле данного класса, а также поля базового класса. В классе Shop должны быть реализованы два метода:
                    1) ChangeS(), метод изменяет поле Square, в качестве параметра методу передается новое значение торговых площадей.
                    2) Print(), метод возвращает сведения о магазине в виде одной текстовой строки с четырьмя полями (Компания, Этажность, Возраст, Площадь), разделенными пробелом. В
                       качестве параметра методу передается текущий год. Если текущий год меньше года выпуска, то вместо возраста выводится фраза «еще не построен».
                Третий класс Flat должен быть потомком класса Build и содержать информацию о жилых домах и дополнительное поле Kvar, содержащее количество квартир в доме. Класс должен
                содержать конструктор с параметрами, позволяющий заполнять поле данного класса, а также поля базового класса. В классе Bus должны быть реализованы два метода:
                    1) ChangeK(), метод изменяет поле Kvar, в качестве параметра методу передается новое количество квартир.
                    2) Print(), метод возвращает сведения о жилом доме в виде одной текстовой строки с четырьмя полями (Компания, Этажность, Возраст, Количество_квартир), разделенными
                       пробелом. В качестве параметра методу передается текущий год. Если текущий год меньше года выпуска, то вместо возраста выводится фраза «еще не построен».
                Напишите программу, которая получает на входе текстовый файл Input.txt с записями о постройках. В первой строке файла указан текущий год. Далее идут записи в виде строк. В
                одной строке файла содержится одна запись о магазине или жилом доме. Запись о магазине имеет пять полей, разделенных пробелом в следующем формате:
                    М Компания Этажность Год Площадь
                Первая буква ‘М’ в строке является признаком магазина. Запись о жилом доме имеет пять полей, разделенных пробелом в следующем формате:
                    Ж Компания Этажность Год Количество_квартир
                Первая буква ‘Ж’ в строке является признаком жилого дома. Программа должна создавать три динамических массива. Первый динамический массив
                должен состоять из объектов класса Shop и содержать записи о магазинах, перечисленных во входном файле. Второй динамический массив должен состоять из объектов класса Flat и
                содержать записи о жилых домах, перечисленных во входном файле. Третий динамический массив должен состоять из объектов класса Build и содержать сведения о магазинах и жилых
                домах, перечисленных во входном файле. После этого программа должна создать три файла Shop.txt, Flat.txt и Build.txt. В первый файл должны быть помещены сведения о магазинах в виде
                строк, формируемых методом Print() класса Shop. Во второй файл должны быть помещены сведения о жилых домах в виде строк, формируемых методом Print() класса Flat. В третий файл
                должны быть помещены сведения о магазинах и жилых домах в виде строк, формируемых методом Print() класса Build.
 *
*/

#include <iostream>
#include <string>
#include <sstream>
#include <fstream>
#include <vector>

#include "shop.h"
#include "flat.h"

enum class ReadErrorCode
{
    NO_ERROR = 0,
    OPEN_ERROR,
    GENERAL_READ_ERROR,
    YEAR_READ_ERROR,
    DATA_SIZE_ERROR,
    DATA_TYPE_ERROR
};

ReadErrorCode readInput(string filePath, unsigned int* currentYear, vector<build>* builds, vector<shop>* shops, vector<flat>* flats);
bool writeOutput(string filePath, vector<build>* builds, unsigned int currentYear = 0);
bool writeOutput(string filePath, vector<shop>* shops, unsigned int currentYear = 0);
bool writeOutput(string filePath, vector<flat>* flats, unsigned int currentYear = 0);

int main()
{
    setlocale(LC_ALL, "Russian");

    unsigned int currentYear = 0;
    vector<build> builds;
    vector<shop> shops;
    vector<flat> flats;

    switch (readInput("../input.txt", &currentYear, &builds, &shops, &flats))
    {
    case ReadErrorCode::NO_ERROR:
        cout << "Файл успешно считан." << endl;
        break;
    case ReadErrorCode::OPEN_ERROR:
        cout << "Не удалось открыть файл." << endl;
        break;
    case ReadErrorCode::GENERAL_READ_ERROR:
        cout << "Не удалось считать первую строку." << endl;
        break;
    case ReadErrorCode::YEAR_READ_ERROR:
        cout << "Не удалось считать текущий год." << endl;
        break;
    case ReadErrorCode::DATA_SIZE_ERROR:
        cout << "Не удалось считать здание (количество слов в строке не равно 5)" << endl;
        break;
    case ReadErrorCode::DATA_TYPE_ERROR:
        cout << "Не удалось опознать тип здания (неизвестная буква)" << endl;
        break;
    default:
        cout << "Произошла магия." << endl;
        break;
    }

    if (writeOutput("../builds.txt", &builds))
        cout << "Общий файл построек успешно записан." << endl;
    if (writeOutput("../shops.txt", &shops, currentYear))
        cout << "Файл с магазинами успешно записан." << endl;
    if (writeOutput("../flats.txt", &flats, currentYear))
        cout << "Файл с домами успешно записан." << endl;

    return 0;
}

ReadErrorCode readInput(string filePath, unsigned int* currentYear, vector<build>* builds, vector<shop>* shops, vector<flat>* flats)
{
    ifstream input(filePath);
    if (!input.is_open())
        return ReadErrorCode::OPEN_ERROR;

    while (!input.eof()) {
        string stringBuffer;
        vector<string> data;
        getline(input, stringBuffer);
        if (input.fail()) {
            input.close();
            return ReadErrorCode::GENERAL_READ_ERROR;
        }
        if (!stringBuffer.empty())
            if (!*currentYear) {
                *currentYear = stoi(stringBuffer);
                if (!*currentYear) {
                    input.close();
                    return ReadErrorCode::YEAR_READ_ERROR;
                }
            } else {
                stringstream stream(stringBuffer);
                string wordBuffer;
                while (stream >> wordBuffer)
                    data.push_back(wordBuffer);
                if (data.size() != 5) {
                    input.close();
                    return ReadErrorCode::DATA_SIZE_ERROR;
                }
                builds->push_back(build(data.at(1), stoi(data.at(2)), stoi(data.at(3))));
                if (data.at(0) == "М")
                    shops->push_back(shop(data.at(1), stoi(data.at(2)), stoi(data.at(3)), stoi(data.at(4))));
                else if (data.at(0) == "Ж")
                    flats->push_back(flat(data.at(1), stoi(data.at(2)), stoi(data.at(3)), stoi(data.at(4))));
                else {
                    input.close();
                    return ReadErrorCode::DATA_TYPE_ERROR;
                }
            }
    }

    input.close();
    return ReadErrorCode::NO_ERROR;
}

bool writeOutput(string filePath, vector<build>* builds, unsigned int currentYear)
{
    if (!builds->empty()) {
        ofstream output(filePath);
        if (output.is_open()) {
            for (size_t i = 0; i < builds->size(); i++)
                output << builds->at(i).printBuildData() << endl;
            output.close();
        }
        else
            return false;
    }
    return true;
}

bool writeOutput(string filePath, vector<shop>* shops, unsigned int currentYear)
{
    if (!shops->empty()) {
        ofstream output(filePath);
        if (output.is_open()) {
            for (size_t i = 0; i < shops->size(); i++)
                output << shops->at(i).printShopData(currentYear) << endl;
            output.close();
        } else
            return false;
    }
    return true;
}

bool writeOutput(string filePath, vector<flat>* flats, unsigned int currentYear)
{
    if (!flats->empty()) {
        ofstream output(filePath);
        if (output.is_open()) {
            for (size_t i = 0; i < flats->size(); i++)
                output << flats->at(i).printFlatData(currentYear) << endl;
            output.close();
        }
        else
            return false;
    }
    return true;
}