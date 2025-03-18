## Задание: Создание системы для управления Instagram

### Описание задачи
Разработайте **консольное приложение** на базе **.NET 9** с использованием **Dapper** и **PostgreSQL** для управления данными Instagram, включая управление пользователями, постами, лайками и комментариями.

### 1. База данных
Создайте базу данных PostgreSQL с четырьмя основными таблицами:

Вот SQL код для создания таблиц в базе данных, с учетом структуры, которую вы описали:

```sql
-- Таблица для пользователей (Users)
CREATE TABLE Users (
    UserId INT PRIMARY KEY,  -- Уникальный идентификатор пользователя
    Username VARCHAR(100),   -- Имя пользователя
    Email VARCHAR(150),      -- Электронная почта
    FullName VARCHAR(150),   -- Полное имя пользователя
    RegistrationDate DATE    -- Дата регистрации
);

-- Таблица для постов (Posts)
CREATE TABLE Posts (
    PostId INT PRIMARY KEY,   -- Уникальный идентификатор поста
    UserId INT,               -- Идентификатор пользователя, который создал пост
    Content TEXT,             -- Содержание поста
    CreationDate DATE,        -- Дата создания поста
    LikesCount INT,           -- Количество лайков на посте
    FOREIGN KEY (UserId) REFERENCES Users(UserId)  -- Внешний ключ для связи с таблицей Users
);

-- Таблица для лайков (Likes)
CREATE TABLE Likes (
    LikeId INT PRIMARY KEY,   -- Уникальный идентификатор лайка
    UserId INT,               -- Идентификатор пользователя, который поставил лайк
    PostId INT,               -- Идентификатор поста, на который поставлен лайк
    LikeDate DATE,            -- Дата лайка
    FOREIGN KEY (UserId) REFERENCES Users(UserId),  -- Внешний ключ для связи с таблицей Users
    FOREIGN KEY (PostId) REFERENCES Posts(PostId)   -- Внешний ключ для связи с таблицей Posts
);

-- Таблица для комментариев (Comments)
CREATE TABLE Comments (
    CommentId INT PRIMARY KEY,   -- Уникальный идентификатор комментария
    UserId INT,                  -- Идентификатор пользователя, который оставил комментарий
    PostId INT,                  -- Идентификатор поста, к которому оставлен комментарий
    Content TEXT,                -- Текст комментария
    CreationDate DATE,           -- Дата создания комментария
    FOREIGN KEY (UserId) REFERENCES Users(UserId),  -- Внешний ключ для связи с таблицей Users
    FOREIGN KEY (PostId) REFERENCES Posts(PostId)   -- Внешний ключ для связи с таблицей Posts
);
```

---

### 2. CRUD-операции

#### Управление пользователями (`Users`):
- **Создание пользователя** — добавление нового пользователя.  
- **Просмотр пользователей** — вывод всех пользователей.  
- **Детальный просмотр пользователя** — получение информации о пользователе по его идентификатору.  
- **Редактирование данных пользователя** — обновление данных пользователя.  
- **Удаление пользователя** — удаление пользователя.

#### Управление постами (`Posts`):
- **Создание поста** — добавление нового поста.  
- **Просмотр всех постов** — вывод всех постов.  
- **Детальный просмотр поста** — получение информации о конкретном посте.  
- **Редактирование поста** — обновление поста.  
- **Удаление поста** — удаление поста.

#### Управление лайками (`Likes`):
- **Поставить лайк** — пользователь ставит лайк на пост.  
- **Просмотр лайков на посте** — вывод всех лайков для конкретного поста.  
- **Удалить лайк** — удаление лайка с поста.

#### Управление комментариями (`Comments`):
- **Добавление комментария** — добавление комментария к посту.  
- **Просмотр комментариев поста** — вывод всех комментариев к конкретному посту.  
- **Удалить комментарий** — удаление комментария.

---

### 3. SQL-запросы

1. **Получить список всех пользователей, отсортированных по дате регистрации**:
2. **Получить количество лайков на определенном посте**:
3. **Получить все посты пользователя с ID 7 с количеством лайков и комментариев, используя JOIN**:
4. **Получить топ-5 постов с наибольшим количеством лайков и комментариев**:
5. **Получить посты с количеством комментариев больше 3**:

---

### 4. Технологические требования

- **Используемые технологии**:  
  - **.NET 9** — для создания консольного приложения.  
  - **Dapper** — для легковесного доступа к базе данных.  
  - **Npgsql** — для подключения к PostgreSQL.


### 5. Пример данных

#### 1. **`Users` (Пользователи)**

```sql
INSERT INTO Users (UserId, Username, Email, FullName, RegistrationDate)
VALUES
(1, 'john_doe', 'john.doe@example.com', 'John Doe', '2024-01-15'),
(2, 'jane_smith', 'jane.smith@example.com', 'Jane Smith', '2024-02-20'),
(3, 'susan_james', 'susan.james@example.com', 'Susan James', '2024-03-05'),
(4, 'mike_brown', 'mike.brown@example.com', 'Mike Brown', '2024-03-12'),
(5, 'lucy_white', 'lucy.white@example.com', 'Lucy White', '2024-04-10'),
(6, 'william_black', 'william.black@example.com', 'William Black', '2024-05-01'),
(7, 'emily_davis', 'emily.davis@example.com', 'Emily Davis', '2024-05-15'),
(8, 'robert_miller', 'robert.miller@example.com', 'Robert Miller', '2024-06-02'),
(9, 'david_lee', 'david.lee@example.com', 'David Lee', '2024-06-20'),
(10, 'emma_wilson', 'emma.wilson@example.com', 'Emma Wilson', '2024-07-01');
```

---

#### 2. **`Posts` (Посты)**

```sql
INSERT INTO Posts (PostId, UserId, Content, CreationDate, LikesCount)
VALUES
(1, 1, 'Had a great time at the beach!', '2024-07-10', 45),
(2, 2, 'Enjoying a sunny day at the park.', '2024-07-11', 120),
(3, 3, 'Check out my new painting!', '2024-07-12', 80),
(4, 4, 'Learning how to cook Italian food.', '2024-07-15', 50),
(5, 5, 'Visited a beautiful waterfall today.', '2024-07-16', 200),
(6, 6, 'Just finished reading a great book!', '2024-07-18', 90),
(7, 7, 'Exploring the city’s new art exhibit.', '2024-07-19', 150),
(8, 8, 'Baking cookies with my family.', '2024-07-20', 75),
(9, 9, 'New workout routine completed!', '2024-07-21', 60),
(10, 10, 'Hiking in the mountains this weekend!', '2024-07-22', 130);
```

---

#### 3. **`Likes` (Лайки)**

```sql
INSERT INTO Likes (LikeId, UserId, PostId, LikeDate)
VALUES
(1, 2, 1, '2024-07-10'),
(2, 3, 1, '2024-07-10'),
(3, 4, 2, '2024-07-11'),
(4, 5, 2, '2024-07-11'),
(5, 6, 3, '2024-07-12'),
(6, 7, 3, '2024-07-12'),
(7, 8, 4, '2024-07-15'),
(8, 9, 4, '2024-07-15'),
(9, 10, 5, '2024-07-16'),
(10, 1, 5, '2024-07-16'),
(11, 2, 6, '2024-07-18'),
(12, 3, 6, '2024-07-18'),
(13, 4, 7, '2024-07-19'),
(14, 5, 7, '2024-07-19'),
(15, 6, 8, '2024-07-20'),
(16, 7, 8, '2024-07-20'),
(17, 8, 9, '2024-07-21'),
(18, 9, 9, '2024-07-21'),
(19, 10, 10, '2024-07-22');
```

---

#### 4. **`Comments` (Комментарии)**

```sql
INSERT INTO Comments (CommentId, UserId, PostId, Content, CreationDate)
VALUES
(1, 3, 1, 'Looks amazing! Wish I was there.', '2024-07-10'),
(2, 4, 1, 'I love the beach too!', '2024-07-10'),
(3, 5, 2, 'So beautiful! Enjoy!', '2024-07-11'),
(4, 6, 2, 'I want to visit there one day!', '2024-07-11'),
(5, 7, 3, 'Your painting is stunning!', '2024-07-12'),
(6, 8, 3, 'I can’t wait to see more of your work!', '2024-07-12'),
(7, 9, 4, 'I love cooking Italian food!', '2024-07-15'),
(8, 10, 4, 'This sounds delicious! Share the recipe?', '2024-07-15'),
(9, 1, 5, 'What a stunning waterfall! Where is it?', '2024-07-16'),
(10, 2, 5, 'Looks like an awesome hike, where was this?', '2024-07-16'),
(11, 3, 6, 'Great book, I read it too!', '2024-07-18'),
(12, 4, 6, 'I love that book! So inspiring!', '2024-07-18'),
(13, 5, 7, 'The exhibit was incredible!', '2024-07-19'),
(14, 6, 7, 'What a fun experience!', '2024-07-19'),
(15, 7, 8, 'Baking with family is always fun!', '2024-07-20'),
(16, 8, 8, 'Looks like a blast!', '2024-07-20'),
(17, 9, 9, 'Congrats on finishing the routine!', '2024-07-21'),
(18, 10, 9, 'Great job! Keep it up!', '2024-07-21'),
(19, 1, 10, 'The hike was amazing, wasn’t it?', '2024-07-22'),
(20, 2, 10, 'Such a beautiful view! Where is this?', '2024-07-22');
```