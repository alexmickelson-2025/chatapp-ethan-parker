create schema if not exists chatdb;

create table if not exists chatdb.message (
    content text, 
    time_posted timestamptz, 
    username text,
    id int primary key
);