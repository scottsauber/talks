CREATE TABLE customers
(
    id         uuid DEFAULT gen_random_uuid() PRIMARY KEY,
    first_name varchar(100) not null,
    last_name  varchar(100) not null
);