CREATE TABLE customers
(
    id         SERIAL PRIMARY KEY,
    first_name varchar(100) not null,
    last_name  varchar(100) not null
);