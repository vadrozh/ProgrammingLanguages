/*
 * Author: Rozhkov Vadim
 *
 * Group: СБС-901, 3 подгруппа
 *
 * Task, #: 6.20
 *
 * Description: Структура: информация о продуктовом товаре
 *              Поля:
 *                 * Название
 *                 * Цена
 *                 * Дата производства(число, месяц, год)
 *                 * Срок годности(в неделях)
 *              Задача: задать дату и найти все просроченные товары
 *
*/

#include <iostream>
#include <cstdio>
#include <cstdlib>
#include <ctime>
#include <string.h>

enum class Menu {
    EXIT, ADD_MANY, ADD_ONE, PRINT, CLEAR, DO
};

const size_t productNameSize = 256;

struct Product
{
    char name[productNameSize] = "not defined";
    float price = 0;
    time_t productionDate = 1;
    unsigned int shelfLife = 0;
};

void printMenu();
void reallocate(Product*& products_ptr, size_t size, size_t newSize);

size_t  addProducts(Product*& products, size_t size, unsigned int count);
Product getProduct();

void    printProduct(Product product, unsigned int position);

void    findSpoiledProducts(Product* products, size_t size);

int main()
{
    size_t productsSize = 0;
    Product* products = nullptr;
    unsigned int count = 0;

    bool stop = false;
    while (!stop) {
        printMenu();
        Menu option;
        scanf_s("%d", &option);
        switch (option)
        {
        case Menu::EXIT:
            stop = true;
            break;
        case Menu::ADD_MANY:
            printf_s("How many elements you want to add: ");
            scanf_s("%d", &count);
            productsSize = addProducts(products, productsSize, count);
            break;
        case Menu::ADD_ONE:
            productsSize = addProducts(products, productsSize, 1);
            break;
        case Menu::PRINT:
            if (products)
                for (size_t i = 0; i < productsSize; i++)
                    printProduct(products[i], i);
            else
                printf_s("\nThere is no available items to print.\n");
            break;
        case Menu::CLEAR:
            productsSize = 0;
            delete[] products;
            products = nullptr;
            printf_s("\nList of items has been cleared.\n");
            break;
        case Menu::DO:
            findSpoiledProducts(products, productsSize);
            break;
        default:
            printf_s("\nWrong option, try again\n");
            break;
        }
    }

    delete[] products;
    return 0;
}

void printMenu()
{
    printf(
        "\n\nElement item: Product{name, price, productionDate, shelfLife}\n"
        "--------------------\n"
        "Add many items: (%d)\n"
        "Add one item:   (%d)\n"
        "Print items:    (%d)\n"
        "Remove all:     (%d)\n"
        "Check expiry:   (%d)\n"
        "Exit:           (%d)\n"
        "--------------------\n"
        "Your option: ",
        Menu::ADD_MANY, Menu::ADD_ONE, Menu::PRINT,
        Menu::CLEAR, Menu::DO, Menu::EXIT
    );
}

void reallocate(Product*& products_ptr, size_t size, size_t newSize)
{
    if (!products_ptr || size >= newSize)
        return;
    Product* newProducts = new Product[newSize];
    for (size_t i = 0; i < size; i++){
        newProducts[i] = products_ptr[i];
    }
    delete[] products_ptr;
    products_ptr = newProducts;
}

size_t addProducts(Product*& products, size_t size, unsigned int count)
{
    size_t newSize = size + count;
    if (!products)
        products = new Product[newSize];
    else
        reallocate(products, size, newSize);
    for (size_t i = size; i < newSize; i++){
        printf_s(
            "\nAdding of %i product\n"
            "---------------------\n", i+1
        );
        products[i] = getProduct();
    }
    return newSize;
}

Product getProduct()
{
    Product newProduct;

    printf_s("Enter name: ");
    while (getchar() != '\n');
    scanf_s("%[^\n]s", &newProduct.name, productNameSize);

    printf_s("Enter price: ");
    scanf_s("%f", &newProduct.price);

    printf_s("Enter date of production(dd.mm.yyyy): ");
    int day = 1, month = 1, year = 1970;
    scanf_s("%d.%d.%d", &day, &month, &year);

    tm productionTime = { 0 };
    productionTime.tm_year = year - 1900;
    productionTime.tm_mon = month - 1;
    productionTime.tm_mday = day;
    productionTime.tm_isdst = -1;
    newProduct.productionDate = mktime(&productionTime);

    printf_s("Enter shelf life in weeks: ");
    scanf_s("%d", &newProduct.shelfLife);

    return newProduct;
}

void printProduct(Product product, unsigned int position)
{
    printf_s("\n-------------------\n");
    printf_s("Item #%i\n", position);
    printf_s("Name: %s\n", product.name);
    printf_s("Price: %f\n", product.price);
    char sBuffer[32];
    tm tmBuffer = { 0 };
    localtime_s(&tmBuffer, &product.productionDate);
    strftime(sBuffer, sizeof(sBuffer), "%d.%m.%Y", &tmBuffer);
    printf_s("Date of production: %s\n", sBuffer);
    printf_s("Shelf life in weeks: %i\n", product.shelfLife);
}

void findSpoiledProducts(Product* products, size_t size)
{
    printf_s("\n\nEnter date to check spoiling(dd.mm.yyyy): ");
    int day = 1, month = 1, year = 1970;
    scanf_s("%d.%d.%d", &day, &month, &year);

    tm time = { 0 };
    time.tm_year = year - 1900;
    time.tm_mon = month - 1;
    time.tm_mday = day;
    time.tm_isdst = -1;
    time_t convertedTime = mktime(&time);

    for (size_t i = 0; i < size; i++) {
        printf_s("\n-------------------\n");
        printf_s("Item #%i\n", i + 1);
        printf_s("Name: %s\n", products[i].name);
        char sBuffer[32];
        tm tmBuffer = { 0 };
        localtime_s(&tmBuffer, &products[i].productionDate);
        strftime(sBuffer, sizeof(sBuffer), "%d.%m.%Y", &tmBuffer);
        printf_s("Date of production: %s\n", sBuffer);
        printf_s("Shelf life in weeks: %i\n", products[i].shelfLife);
        
        long long int spoilingTime = products[i].shelfLife;
        printf_s("Is spoiled: %s", (spoilingTime * 7 * 24 * 60 * 60 + mktime(&tmBuffer)) >= convertedTime ? "No" : "Yes");
    }
}
