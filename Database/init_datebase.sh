psql -U postgres -d postgres -f /data/database/create_database.sql
psql -U postgres -d university -f /data/database/create_table.sql
psql -U postgres -d university -f /data/database/fill_start_data.sql