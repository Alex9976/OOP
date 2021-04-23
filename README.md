# OOP
[![CodeFactor](https://www.codefactor.io/repository/github/alex9976/oop/badge)](https://www.codefactor.io/repository/github/alex9976/oop)
## Lab 1 (Ознакомление с концепциями ООП):
Построить иерархию классов. Распределить классы по модулям. В главном модуле программы добавить в список различные объекты (статическая инициализация).

## Lab 2 (Создание объектов на уровне пользовательского интерфейса):
Расширить пример так, чтобы объекты можно было создавать на уровне пользовательского интерфейса. Создание объекта должно выполняться так, чтобы добавление нового класса в систему не требовало изменения существующего кода (выбор типа с помощью оператора case/switch и множественного if делать нельзя).

## Lab 3 (Сериализация объектов):
Реализовать сериализацию/десереализацию объектов из полученной иерархии классов в файл/из файла. 
В пользовательском интерфейсе необходимо реализовать следующие функции:
+ возможность изменять свойства объектов (редактирование);
+ добавлять/удалять объекты из списка;
+ сериализация/десериализация списка объектов.
Добавление новых классов в иерархию не должно приводить к необходимости переписать существующий код, и не использовать if-else/switch-case, рефлексию.

## Lab 4 (Плагины):
Расширить имеющуюся иерархию новыми классами с помощью динамической загрузки модуля (плагина). Новые модули должны добавлять или расширять функциональность базовой программы: новый класс в иерархии, функции по работе с ним, новые элементы в пользовательскм интерфейсе для работы с новым классом.

## Lab 5 (Плагины - функциональность):
На основе плагинов реализовать возможность обработки структур перед сохранением в файл и после загрузки из файла(трансформация XML данных в JSON). Дополнительная функциональность должна находиться в меню настроек и зависит от загруженных плагинов. Загрузка плагинов производится автоматически из папки, либо выбором файла с плагином через пользовательский интерфейс.

## Lab 6 (Паттерны):
На базе предыдущей лабораторной работы обменяться с товарищем функциональными плагинами (минимум одним) и адаптировать их в этой же работе помощью паттерна Адаптер. Опционально реализовать 2 паттерна (любых) в программе.
