
int countOfSongs = int.Parse(Console.ReadLine());

List<Song> songList = new List<Song>();

for (int i = 0; i < countOfSongs; i++)
{
    string[] songInfo = Console.ReadLine().Split('_');
    string songTypeList = songInfo[0];
    string songName = songInfo[1];
    string songTime = songInfo[2];

    Song currentSong = new Song(songTypeList, songName, songTime);
    songList.Add(currentSong);
}

string typeList = Console.ReadLine();

if (typeList == "all")
{
    foreach (Song song in songList)
        Console.WriteLine(song.Name);
}
else
{
    foreach(Song song in songList.Where(s => s.TypeList == typeList))
        Console.WriteLine(song.Name);
}


class Song
{
    public Song(string typeList, string name, string duration)
    {
        TypeList = typeList;
        Name = name;
        Time = duration;
    }

    public string TypeList { get; set; }

    public string Name { get; set; }

    public string Time { get; set; }
}
