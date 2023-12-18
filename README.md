# Students

## Описание кода

Строка подключения к БД

```csharp
var connectionString =
    "Server=192.168.150.2;Port=5432;Database=university;User Id=postgres;Password=def555;Pooling=true;";
```

SQL запрос 

```postgresql
SELECT * 
FROM students 
ORDER BY date_of_birth
```

Вывод результата

Для вывода результата использовалась библиотека `ConsoleTable`

```csharp
var table = new ConsoleTable("id", "student_name", "study_group", "date_of_birth");
       
foreach (var student in students)
{
    table.AddRow(student.id, student.student_name, student.study_group, DateOnly.FromDateTime(student.date_of_birth));
}

table.Write(Format.Alternative);
```

Класс student

```csharp
public class Student
{
    public int id { get; set; }
    public string student_name { get; set; }
    public string study_group { get; set; }
    public DateTime date_of_birth { get; set; }
}
```

## База данных

Данные для БД хранятся в файлк .env 

```text
POSTGRES_USER=postgres
POSTGRES_PASSWORD=def555
PGDATA=/data/postgres
```

### Скрипт инициализации БД
```postgresql
CREATE DATABASE university;

\c university;

CREATE TABLE students
(
    id            serial PRIMARY KEY,
    student_name  text NOT NULL,
    study_group   text NOT NULL,
    date_of_birth date NOT NULL
);

COPY students (id, student_name, study_group, date_of_birth)
    FROM '/data/database/students.csv'
    DELIMITER ','
    CSV HEADER;
```

## Запуск

```shell
docker compose -f docker-compose.prod.yml up
```