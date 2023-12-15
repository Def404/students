CREATE DATABASE university
    ENCODING 'UTF-8'
    LC_COLLATE 'ru_RU.UTF-8'
    LC_CTYPE 'ru_RU.UTF-8';

CREATE TABLE students (
    id serial PRIMARY KEY,
    student_name text NOT NULL,
    study_group text NOT NULL,
    date_of_birth date NOT NULL
);

COPY students(id, student_name, study_group, date_of_birth)
FROM 'students.csv'
DELIMITER ','
CSV HEADER;