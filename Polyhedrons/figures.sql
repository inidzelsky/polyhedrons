create database figures;

create table polygons (
    name varchar(25) primary key,
    type varchar(25) not null,
    x_coords integer[] not null,
    y_coords integer[] not null
);

create table polyhedrons (
    name varchar(25) primary key,
    base_name varchar(25) references polygons(name),
    type varchar(25) not null,
    height double precision not null
);