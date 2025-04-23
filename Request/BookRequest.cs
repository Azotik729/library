namespace Library.Request
{
    //public record BookRequest(
    //    int IdBook, int IdUser, int IdWriter, int IdChapter, string DataPost, decimal Price, string name
    //    );

    public class BookRequest ()
    {
        public int IdBook { get; set; }
        public int IdUser { get; set; }

        public int IdWriter { get; set; }

        public int IdChapter { get; set; }

        public string DataPost { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }
    }



}
