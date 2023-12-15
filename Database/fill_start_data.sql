COPY students (id, student_name, study_group, date_of_birth)
    FROM '/data/database/students.csv'
    DELIMITER ','
    CSV HEADER;