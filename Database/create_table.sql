CREATE TABLE students
(
    id            serial PRIMARY KEY,
    student_name  text NOT NULL,
    study_group   text NOT NULL,
    date_of_birth date NOT NULL
);