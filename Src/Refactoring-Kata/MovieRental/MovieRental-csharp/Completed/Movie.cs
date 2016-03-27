namespace MovieRental_csharp.Completed
{
    public class Movie {
	    public const int REGULAR = 0;
	    public const int NEW_RELEASE = 1;
        public const int CHILDRENS = 2;
	
        public string Title { get; set; }
        public int PriceCode { get; set; }
	
	    public Movie(string title, int priceCode){
		    Title = title;
		    PriceCode = priceCode;
	    }
	
    }
}
