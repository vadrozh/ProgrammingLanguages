/*
 * Author: Rozhkov Vadim
 *
 * Group: СБС-901, 3 подгруппа
 *
 * Task, #: 5.34
 *
 * Description: Дано предложение с набором ключевых слов и еще n предложений. Вывести предложения в порядке убывания количества входящих в них
 *              ключевых слов. Предложения, в которые не входит ни одного ключевого слова, не выводить.
*/

#include <iostream>
#include <cstdio>
#include <cstdlib>
#include <ctime>
#include <string.h>

int getKeySentenceSize();
//Returns sentence max size

char* getKeySentence(int size);
//Returns pointer to sentence with keywords

int getCountOfSentences();
//Returns count of sentences

char** getSentences(int count, int size);
//Returns pointer to array of sentences

int getCountOfWords(char* sentence, size_t size);
//Returns count of words in sentence

char** getWordsArray(char* sentence, int wordCount, int size);
//Returns pointer to words array from sentence chopped by " " symbol

int* calcKeyWordsInSentences(char** sentences, char** keyWords, int sentencesCount, int keyWordsCount, int size);
//Returns integer array with count of all keywords in every sentencez

void printSentencesByKeyWordsCount(char** sentences, int sentencesCount, int* sentencesKeyWordsCounter, int size);
//Prints all sentences with keywords in order by keywords count

int main()
{
    size_t sentenceSize = getKeySentenceSize();
    char* keySentence = getKeySentence(sentenceSize);

    size_t sentencesCount = getCountOfSentences();
    char** sentences = getSentences(sentencesCount, sentenceSize);

    int keyWordsCount = getCountOfWords(keySentence, sentenceSize);
    char** keyWords = getWordsArray(keySentence, keyWordsCount, sentenceSize);
        
    int* sentencesKeyWordsCounter = calcKeyWordsInSentences(sentences, keyWords, sentencesCount, keyWordsCount, sentenceSize);
    printSentencesByKeyWordsCount(sentences, sentencesCount, sentencesKeyWordsCounter, sentenceSize);

    for (size_t i = 0; i < sentencesCount; i++)
        delete[] sentences[i];
    delete[] sentences;
    delete[] keySentence;
    delete[] keyWords;
    delete[] sentencesKeyWordsCounter;

    return 0;
}

int getKeySentenceSize()
{
    printf_s("Enter max size of sentence \n");
    int size = 0;
    scanf_s("%d", &size);
    while (size <= 0)
    {
        printf_s("Wrong size(<=0), enter another");
        scanf_s("%d", &size);
    }
    return size;
}

char* getKeySentence(int size)
{
    char* keySentence = new char[size + 1];
    printf_s("Enter sentence with keyword \n");
    while (getchar() != '\n');
    scanf_s("%[^\n]s", keySentence, size);
    return keySentence;
}

int getCountOfSentences()
{
    printf_s("Enter count of sentences \n");
    int count = 0;
    scanf_s("%d", &count);
    while (count <= 0)
    {
        printf_s("Wrong count(<=0), enter another");
        scanf_s("%d", &count);
    }
    return count;
}

char** getSentences(int count, int size)
{
    char** sentences = new char* [count];
    for (int i = 0; i < count; i++) {
        sentences[i] = new char[size+1];
        printf_s("Enter sentence #%d \n", i);
        while (getchar() != '\n');
        scanf_s("%[^\n]s", sentences[i], size);
    }
    return sentences;
}

int getCountOfWords(char* sentence, size_t size)
{
    char* temp = new char[size];
    strncpy_s(temp, size, sentence, size);

    char* context = nullptr;
    temp = strtok_s(temp, " ", &context);
    int i = 0;
    while (temp) {
        ++i;
        temp = strtok_s(NULL, " ", &context);
    }
    delete[] temp;
    return i;
}

char** getWordsArray(char* sentence, int wordCount, int size)
{
    char** words = new char* [wordCount];

    char* context = nullptr;
    char* temp = strtok_s(sentence, " ", &context);
    int i = 0;
    while (temp) {
        words[i] = temp;
        ++i;
        temp = strtok_s(NULL, " ", &context);
    }

    return words;
}

int* calcKeyWordsInSentences(char** sentences, char** keyWords, int sentencesCount, int keyWordsCount, int size)
{
    int* counter = new int[sentencesCount];
    for (int i = 0; i < sentencesCount; i++)
        counter[i] = 0;

    char* temp = nullptr;
    for (int i = 0; i < sentencesCount; i++)
        for (int j = 0; j < keyWordsCount; j++) {
            temp = strstr(sentences[i], keyWords[j]);
            while (temp) {
                ++counter[i];
                temp = strstr(temp + 1, keyWords[j]);
            }
        }

    return counter;
}

void printSentencesByKeyWordsCount(char** sentences, int sentencesCount, int* sentencesKeyWordsCounter, int size)
{
    printf_s("Sentences by max keywords: \n");
    int max = -1, maxPos = -1;
    while (max != 0) {
        max = -1;
        for (int i = 0; i < sentencesCount; i++)
            if (sentencesKeyWordsCounter[i] > max) {
                max = sentencesKeyWordsCounter[i];
                maxPos = i;
            }
        if (max)
            printf_s("%s \n", sentences[maxPos]);
        sentencesKeyWordsCounter[maxPos] = 0;
    }
}
