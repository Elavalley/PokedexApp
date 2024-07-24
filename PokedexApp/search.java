package pokeApp;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;

public class search {
    private static final String DB_URL = "jdbc:sqlite:path_to_your_database.db";
    private Connection connection;

    public DatabaseHelper() {
        try {
            connection = DriverManager.getConnection(DB_URL);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public String getPokemonName(String searchName) {
        String result = null;
        try {
            Statement stmt = connection.createStatement();
            String query = "SELECT name FROM pokemon WHERE name = '" + searchName + "'";
            ResultSet rs = stmt.executeQuery(query);
            
            if (rs.next()) {
                result = rs.getString("name");
            }
            
            rs.close();
            stmt.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return result;
    }
}
