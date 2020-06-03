create database figures;

create table polygons (
    name varchar(25) primary key,
    type varchar(25) not null,
    x_coords double precision[] not null,
    y_coords double precision[] not null
);

create table polyhedrons (
    name varchar(25) primary key,
    base_type varchar(25) not null,
    type varchar(25) not null,
    x_coords double precision[] not null,
    y_coords double precision[] not null,
    height double precision not null
);

create function polygons_count() returns integer as $$
begin
    return (select count(*) from polygons);
end; $$
language plpgsql;


create function polyhedrons_count() returns integer as $$
begin
    return (select count(*) from polyhedrons);
end; $$
language plpgsql;