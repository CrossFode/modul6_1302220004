// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;

class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadVideos;
    public string username;


    public SayaTubeUser(string username)
    {
        this.username = username;
        Random random = new Random();   
        id = random.Next(10000, 99999);
    }
    public int GetTotalVideoPlayCount()
    { 
        if(uploadVideos.Count != 0) {
            
            int total = 0;
            for(int i = 0; i < uploadVideos.Count; i++)
            {
                total += uploadVideos.ElementAt(i).GetPlayCount();
            }
            return total;
        }
        else
        {
            return 0;
        }
    }
    public void AddVideo(SayaTubeVideo video)
    { 
        uploadVideos.Add(video);    
    }
    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine("user = " + username);
        for (int i = 0; i < uploadVideos.Count || i < 8; i++)
        {
            Console.WriteLine("Video" + (i + 1) + uploadVideos[i].GetTitle());
        }
}

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;
    public int GetPlayCount()
    {
        return (int)playCount;  
    }
        public string GetTitle()
        {
            return title;
        }

    public SayaTubeVideo(string title) 
    {
            int max = 200;
            Contract.Requires(title.Length <= max && title != null);
            try
            {
                checked
                {
                    if ((title == null))
                    {
                        throw new ArgumentException("Judul tidak bisa kosong");
                    }
                    else if (title.Length > max)
                    {
                        throw new ArgumentException("Judul tidak bisa melebihi 200 karakter");
                    }
                    this.title = title;
                    Random rand = new Random();
                    int minRand = 100000;
                    int maxRand = 999999;
                    this.id = rand.Next(minRand, maxRand + 1);
                    this.playCount = 0;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }

            Contract.Ensures(this.title.Length <= max && title != null);
        }

    }
    public void IncreasePlayCount(int playCount)
    {
        this.playCount += playCount;
        if (playCount > 10000000)
        {
            throw new ArgumentOutOfRangeException("playCount", "value dari playCount harus kurang dari 10.000.000 dalam pemanggilan");
        }

        try
        {

            checked
            {
                this.playCount += playCount;
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Overflow occurred while increasing play count.");
            Console.WriteLine(ex.Message);

        }
    }
    public void PrintVideoDetails()
    {
        Console.WriteLine("Id : " + id);
        Console.WriteLine("Title : " + title);
        Console.WriteLine("Jumlah Tayangan " + playCount);
    }


}

class program
{
    static void Main(String[] args)
        {
            SayaTubeUser user1 = new SayaTubeUser("Fauzan");
            
            
        }

}
