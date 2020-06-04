using System;
using System.Data;
using System.Data.Common;
using Npgsql;

namespace Polyhedrons
{
    public class PostgresDatabase : IDatabase
    {
        public void SavePolygon(FigureData polygon, string name)
        {
            var connection = PostgresConnection.GetInstance();

            try
            {
                connection.Open();

                string sql = "insert into polygons (name, type, x_coords, y_coords) " +
                             "values (@name, @type, @x_coords, @y_coords)";

                var command = new NpgsqlCommand(sql, connection);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@type", polygon.PolygonType);

                var dictionary = FigureData.GetArraysFromCoords(polygon.Coords);
                command.Parameters.AddWithValue("@x_coords", dictionary["xCoords"]);
                command.Parameters.AddWithValue("@y_coords", dictionary["yCoords"]);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void SavePolyhedron(FigureData polyhedron, string name)
        {
            var connection = PostgresConnection.GetInstance();

            try
            {
                connection.Open();

                string sql = "insert into polyhedrons (name, type, base_type, x_coords, y_coords, height) " +
                             "values (@name, @type, @base_type, @x_coords, @y_coords, @height)";

                var command = new NpgsqlCommand(sql, connection);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@type", polyhedron.PolyhedronType);
                command.Parameters.AddWithValue("@base_type", polyhedron.PolygonType);

                var dictionary = FigureData.GetArraysFromCoords(polyhedron.Coords);
                command.Parameters.AddWithValue("@x_coords", dictionary["xCoords"]);
                command.Parameters.AddWithValue("@y_coords", dictionary["yCoords"]);

                command.Parameters.AddWithValue("@height", polyhedron.Height);

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public FigureData LoadPolygon(string name)
        {
            var connection = PostgresConnection.GetInstance();
            try
            {
                connection.Open();

                string sql = "select type, x_coords, y_coords from polygons where name=@name";

                var command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("@name", name);

                var dataReader = command.ExecuteReader();

                if (!dataReader.Read())
                    throw new DataException("Figure does not exist");

                FigureData figureData = new FigureData();
                figureData.PolygonType = (string) dataReader[0];
                figureData.Coords = FigureData.GetCoordsFromArrays((double[]) dataReader[1], (double[]) dataReader[2]);

                return figureData;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public FigureData LoadPolyhedron(string name)
        {
            var connection = PostgresConnection.GetInstance();
            try
            {
                connection.Open();

                string sql = "select base_type, type, x_coords, y_coords, height from polyhedrons where name=@name";

                var command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("@name", name);

                var dataReader = command.ExecuteReader();
                if (!dataReader.Read())
                    throw new DataException("Figure does not exist");

                FigureData figureData = new FigureData();

                figureData.PolygonType = (string) dataReader[0];
                figureData.PolyhedronType = (string) dataReader[1];
                figureData.Coords = FigureData.GetCoordsFromArrays((double[]) dataReader[2], (double[]) dataReader[3]);
                figureData.Height = (double) dataReader[4];

                return figureData;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return new FigureData();
        }

        public int PolygonsCount()
        {
            var connection = PostgresConnection.GetInstance();
            int result = -1;

            try
            {
                connection.Open();

                var command = new NpgsqlCommand("select polygons_count()", connection);
                result = (int) command.ExecuteScalar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public int PolyhedronsCount()
        {
            var connection = PostgresConnection.GetInstance();
            int result = -1;

            try
            {
                connection.Open();

                var command = new NpgsqlCommand("select polyhedrons_count()", connection);
                result = (int) command.ExecuteScalar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }

        public int FiguresCount()
        {
            var connection = PostgresConnection.GetInstance();
            int result = -1;

            try
            {
                connection.Open();

                var command = new NpgsqlCommand("select polyhedrons_count() + polygons_count()", connection);
                result = (int) command.ExecuteScalar();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return result;
        }
    }
}