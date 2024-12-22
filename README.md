### **Лабораторна робота №7**
## **Завдання**
# **Додати методи для роботи з файлами:**
1. Метод для серіалізації (збереження) колекції List об’єктів предметної області у файл з форматом .csv.
2. Метод для десеріалізації (читання) колекції з файлу формату .csv.
3. Метод для серіалізації (збереження) колекції List об’єктів предметної області у файл з форматом .json.
4. Метод для десеріалізації (читання) колекції з файлу формату .json.
# **Модифікувати меню програми:**
1. Додати об’єкт.
2. Вивести на екран об’єкти.
3. Знайти об’єкт.
4. Видалити об’єкт.
5. Демонстрація поведінки об’єктів.
6. Демонстрація роботи static методів.
7. Зберегти колекцію об’єктів у файлі.
8. Зчитати колекцію об’єктів з файлу.
9. Очистити колекцію об’єктів.
10. Вийти з програми.
# **Тестування**
Додати або скоригувати unit-тести для нових/перероблених методів.

Запустити всі наявні unit-тести (нові та з попередньої лабораторної роботи) і досягти повного їх проходження.

Детально протестувати програму, зокрема:

Тестування пунктів меню 7-9.

Перевірка десеріалізації з файлу .csv, включаючи перетворення "битих" рядків (рядків з пропущеними даними та невірними типами даних).
## **Виконання роботи**
	Опис класів та методів залишається з минулих лабораторних робіт. Додав до програми методи для переведення об’єктів колекції у файл типу .csv та .json, також відповідно додав методи які зчитують файли тих самих типів та додають їх об’єкти до колекції, якщо вони проходять тести. Створив відповідні перевірки.
	Створив діаграми класів:
 ![image](https://github.com/user-attachments/assets/17957717-d740-4f0e-8b0b-08bbcfc62279)
Рисунок 1 – Діаграма класів основної програми
![image](https://github.com/user-attachments/assets/bfdcba08-1e26-459c-b2d1-5adc0cb917d8)
Рисунок 2 – Діаграма класів тест-проєкту (ProductTesting)
![image](https://github.com/user-attachments/assets/86589e23-55e0-4c33-9f5e-5df7b3a48c8d)
Рисунок 3 – Діаграма класів тест-проєкту (ProgrammtTesting)
![image](https://github.com/user-attachments/assets/e9eec4d6-b314-4a35-af96-5995957ade99)
Рисунок 4 – Виконання тестів до програми


