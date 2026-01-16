using Microsoft.Data.SqlClient;
using WebApp.Models;
using WebApp.Services;

public class ProductPopulator {
    readonly string table = "dbo.Products";

    string connectionString = @"Data Source=localhost;Initial Catalog = Test; Integrated Security = True; 
    Encrypt=True;TrustServerCertificate=True;";


    public bool PopulateDatabase()
    {
        bool success = false;

        using (SqlConnection connection = new SqlConnection(connectionString)) {
            try {
                connection.Open();
                byte[] imageInfo;
                
                imageInfo = File.ReadAllBytes("wwwroot/images/products/productImage/bug.jpg");
                Insert(connection, new ProductModel { Name = "Regular Bug", Price = 0.26m, Description = "Normal bug is back on the market! We know you missed the little guy but fear not as he is back and he is plentiful... \n\n Regular Bug comes in a range of colours (in fact, he comes in every colour you can imagine), the colour bug you recieve will be random, see if you can collect them all (16,777,216 possible colours to collect!).\n\n Regular bug will be your friend for life, if you are interested in introducing one to your home, please view our extensive guide on regular bug care, available at www.welovebugssososomuch.com/regularbug. \n\n Thank you!", 
                                                        Stock = 9999, Image = imageInfo });
                imageInfo = File.ReadAllBytes("wwwroot/images/products/productImage/beetle.jpg");
                Insert(connection, new ProductModel { Name = "Beetle", Price = 0.02m, Description = "Brilliant wonderous beetle, the best we ever knew. Comes in all shapes and sizes (within reason) and might occasionally come in green if you're lucky. \n\n Do you need a new best friend? Our beetles are trained in the art of love and care, and will occasionally bring you gifts of dirt and other related items! \n\n Our beetles have recently been equipped with state of the art beetle technology, allowing for increased walk speed, improved wall grip technology, and autoflipping tech.", 
                                                        Stock = 9906, Image = imageInfo });
                imageInfo = File.ReadAllBytes("wwwroot/images/products/productImage/bird.jpg");
                Insert(connection, new ProductModel { Name = "Ladybird", Price = 0.01m, Description = "Average british 7-spotted ladybird, incredibly bright and red. A beautiful addition to any home.", 
                                                        Stock = 6857, Image = imageInfo });
                imageInfo = File.ReadAllBytes("wwwroot/images/products/productImage/ant.jpg");
                Insert(connection, new ProductModel { Name = "Ant", Price = 0.01m, Description = "A tiny yet mighty companion, known for incredible strength and teamwork. Put them in your home, your neighbours home, your best friends home, and watch them build a paradise. \n\n Does not include Queen. See also our Queen ant selection", 
                                                        Stock = 10000, Image = imageInfo });
                imageInfo = File.ReadAllBytes("wwwroot/images/products/productImage/fireant.png");
                Insert(connection, new ProductModel { Name = "Fire ant", Price = 0.01m, Description = "A tiny yet mighty companion (on fire), known for incredible strength and teamwork. Put them in your home, your neighbours home, your best friends home, and watch them build a paradise. \n\n Does not include Queen. See also our Queen ant selection", 
                                                        Stock = 9999, Image = imageInfo });
                imageInfo = File.ReadAllBytes("wwwroot/images/products/productImage/queen ant.jpg");
                Insert(connection, new ProductModel { Name = "Queen Ant", Price = 1.00m, Description = "Powerful mighty Queen. A must-have for anyone serious about ant business. With a Queen in charge, you turn the mindless ants into an army. \n\n Secure your colonies future today!", 
                                                        Stock = 1000, Image = imageInfo });
                imageInfo = File.ReadAllBytes("wwwroot/images/products/productImage/fire ant queen.jpg");
                Insert(connection, new ProductModel { Name = "Fire Ant Queen", Price = 1.05m, Description = "Powerful mighty Queen of FIRE. The Fire Ant Queen is a fierce leader known for her fiery spirit and rapid colony growth! This queen will quickly establish a vibrant and active colony of fire ants, known for their speed, agility, and teamwork. Perfect for ant enthusiasts looking for a dynamic and engaging experience, the Fire Ant Queen brings the spark that will keep your ant farm thriving. Take home this powerful monarch and watch her empire rise!", 
                                                        Stock = 90, Image = imageInfo });
                imageInfo = File.ReadAllBytes("wwwroot/images/products/productImage/rare beetle.jpg");
                Insert(connection, new ProductModel { Name = "Super Rare Beetle", Price = 1500.00m, Description = "The RAREST beetle we have ever come across, comes in sparkling rainbow. \n\n Please handle with care, mistreated bugs will fight back and you will lose.", 
                                                        Stock = 15, Image = imageInfo });
                imageInfo = File.ReadAllBytes("wwwroot/images/products/productImage/gold beetle.jpg");
                Insert(connection, new ProductModel { Name = "24 Karat Gold Plated Beetle", Price = 1000.00m, Description = "IMPORTANT NOTE - This beetle is not solid gold, it is covered in a gold plating exterior, for solid gold beetles, see 24  Karat Gold Beetle", 
                                                        Stock = 100, Image = imageInfo });
                imageInfo = File.ReadAllBytes("wwwroot/images/products/productImage/24 Karat Gold Beetle.jpg");
                Insert(connection, new ProductModel { Name = "24 Karat Gold Beetle", Price = 25000.00m, Description = "Solid gold beetle, incredibly valuable, also incredibly heavy.", 
                                                        Stock = 10, Image = imageInfo });
                imageInfo = File.ReadAllBytes("wwwroot/images/products/productImage/scarab.png");
                Insert(connection, new ProductModel { Name = "Scarab Beetle", Price = 0.10m, Description = "The mystic Scarab beetle, perfect in every way. Scarab beetles are found everywhere ( not just from egypt ). If you want an egyptian one, feel free to contact us.", 
                                                        Stock = 9999, Image = imageInfo });
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        return success;
    }

    public void Insert(SqlConnection connection, ProductModel product) {
        string sqlStatement = $"INSERT INTO {table} (Name, Price, Description, Stock, Image) VALUES (@Name, @Price, @Description, @Stock, @Image)";

        SqlCommand command = new SqlCommand(sqlStatement, connection);

        command.Parameters.AddWithValue("@Name", product.Name);
        command.Parameters.AddWithValue("@Price", product.Price);
        command.Parameters.AddWithValue("@Description", product.Description);
        command.Parameters.AddWithValue("@Stock", product.Stock);
        command.Parameters.AddWithValue("@Image", product.Image);

        command.ExecuteReader();
    }
}