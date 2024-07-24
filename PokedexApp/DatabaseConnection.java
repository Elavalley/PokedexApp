import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;

public class DatabaseConnection {
    public static void main(String[] args) {
        String url = "jdbc:sqlite:{file}";  
        Connection conn = null;
        Statement stmt = null;
        ResultSet rs = null;

        try {
            Class.forName("org.sqlite.JDBC");

            conn = DriverManager.getConnection(url);
            
            System.out.println("Connected to the database successfully!");

            stmt = conn.createStatement();

            String sql = "SELECT * FROM your_table_name"; 
            rs = stmt.executeQuery(sql);

            while (rs.next()) {
                int id = rs.getInt("id");  
                String name = rs.getString("name");  

                System.out.println("ID: " + id + ", Name: " + name);
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                if (rs != null) rs.close();
                if (stmt != null) stmt.close();
                if (conn != null) conn.close();
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }
}
