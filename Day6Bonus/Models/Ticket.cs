namespace Day6Bonus.Models
{
    public class Ticket
    {
        public string Title { get; set; }=string.Empty;

        public string Image_url { get; set; }=string.Empty;

        public static List<Ticket> tickets= new List<Ticket>() { new Ticket { Title="ticket#1" , Image_url = "car1.jpg"},
            new Ticket { Title = "ticket#2", Image_url = "car2.jpg" }
            , new Ticket { Title="ticket#3" , Image_url = "car3.jpg"}

        };

        public static List<Ticket> GetTickets() { return tickets; }
    }
}
