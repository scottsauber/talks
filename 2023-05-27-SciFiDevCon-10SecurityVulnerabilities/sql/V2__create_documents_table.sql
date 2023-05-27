CREATE TABLE documents
(
    id         uuid DEFAULT gen_random_uuid() PRIMARY KEY,
    file_path varchar(100) not null
);