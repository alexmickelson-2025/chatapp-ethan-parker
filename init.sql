create schema if not exists postgres;
create table if not exists postgres.message (
    content text, 
    time_posted timestamptz, 
    username text,
    id int primary key
);